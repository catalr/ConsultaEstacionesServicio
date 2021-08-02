using EstacionesServicioModelo.DAL;
using ComunicacionesModel.DTO;
using EstacionesServicioModelo;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ConsultaWeb
{
    public partial class AgregarEstacion : System.Web.UI.Page
    {
        System.Net.WebClient wc = new System.Net.WebClient();
        EstacionServicioDAL esDao = new EstacionServicioDAL();
        List<Horario> horarioAgregar = new List<Horario>();
        TarifaDAL tarDao = new TarifaDAL();
        static List<Comuna> comunas;
        static List<Region> regiones;
        List<Horario>[] horarios = { new List<Horario>(), new List<Horario>(), new List<Horario>(), new List<Horario>(), new List<Horario>(), new List<Horario>(), new List<Horario>() };



        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                String jsonResponseRegiones = wc.DownloadString("https://apis.digital.gob.cl/dpa/regiones");
                regiones = JsonSerializer.Deserialize<List<Region>>(jsonResponseRegiones);
                RegionDdl.DataSource = regiones;
                RegionDdl.DataTextField = "Nombre";
                RegionDdl.DataValueField = "Codigo";
                RegionDdl.DataBind();

                List<Tarifa> tarifas = tarDao.getAll();
                TarifaDdl.DataSource = tarifas;
                TarifaDdl.DataTextField = "codigo";
                TarifaDdl.DataValueField = "codigo";
                TarifaDdl.DataBind();
            }

        }

        protected void Get_Comunas(object sender, EventArgs e)
        {
            String codRegion = RegionDdl.SelectedValue;
            String jsonResponseComunas = wc.DownloadString("https://apis.digital.gob.cl/dpa/regiones/" + codRegion + "/comunas");
            comunas = JsonSerializer.Deserialize<List<Comuna>>(jsonResponseComunas);
            ComunaDdl.DataSource = comunas;
            ComunaDdl.DataTextField = "Nombre";
            ComunaDdl.DataValueField = "Codigo";
            ComunaDdl.DataBind();
        }

        protected void Validate_Comuna(object sender, ServerValidateEventArgs e)
        {
            Comuna comuna = comunas.Find(x => x.codigo == ComunaDdl.SelectedValue);
            e.IsValid = false;
            if (ComunaDdl.SelectedValue != null)
            {
                String jsonResponseProvincia = wc.DownloadString("https://apis.digital.gob.cl/dpa/provincias/" + comuna.codigo_padre);
                Provincia provincia = JsonSerializer.Deserialize<Provincia>(jsonResponseProvincia);
                if (provincia.codigo_padre == RegionDdl.SelectedValue)
                {
                    e.IsValid = true;
                }
            }
        }

        protected void Agregar(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Agregar_Horario();
                foreach (List<Horario> lista in horarios)
                {
                    horarioAgregar.AddRange(lista);
                }
                EstacionServicio nueva = new EstacionServicio
                {
                    Direccion1 = new Direccion
                    {
                        region = regiones.Find(x => x.codigo == RegionDdl.SelectedValue).nombre,
                        comuna = comunas.Find(x => x.codigo == ComunaDdl.SelectedValue).nombre,
                        codPostal = Int32.Parse(CodigoPostalTextBox.Text),
                        nro = Int32.Parse(NroTextBox.Text),
                        calle = CalleTextBox.Text
                    },
                    capacidadMaxima = Int32.Parse(CapacidadMaximaTextBox.Text),
                    Tarifa1 = tarDao.getTarifa(TarifaDdl.SelectedValue),
                    Horario = horarioAgregar

                };
                esDao.RegistrarEstacion(nueva);
            }
        }


        protected void Agregar_Horario()
        {
            TimeSpan inicio = TimeSpan.Parse(aperturaTxt.Text);
            TimeSpan fin = TimeSpan.Parse(cierreTxt.Text);
            TimeSpan wholeDay = new TimeSpan(24, 0, 0);
            TimeSpan duracion = (fin>inicio)?fin-inicio:wholeDay-inicio+fin;
            
            foreach (ListItem item in weekdaychlist.Items)
            {
                if (item.Selected)
                {
                    short i = Int16.Parse(item.Value);
                    Horario h = new Horario()
                    {
                        Inicio = inicio,
                        Duracion = duracion,
                        Dia = i
                    };
                    horarios[i].Add(h);
                }
            }
        }

        private bool validateHorario(Horario h) //:C cant save horarios between reloads 
        {
            if (horarios[h.Dia].Count != 0)
            {
                foreach (Horario s in horarios[h.Dia])
                {
                    if (s.Inicio < h.Inicio && h.Inicio < s.Inicio + s.Duracion)
                        return false;
                    if (h.Inicio < s.Inicio && s.Inicio < h.Inicio + h.Duracion)
                        return false;
                }
            }
            return true;
        }
    }
}