<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" EnableViewState="true" ViewStateMode="Enabled" AutoEventWireup="true" CodeBehind="AgregarEstacion.aspx.cs" Inherits="ConsultaWeb.AgregarEstacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row mt-5">
        <div class="col-12 col-md-6 col-lg-5 mx-auto">
            <div class="card">
                <form id="EstacionesForm">
                    <div class="card-header bg-success text-white text-center">
                        <h5>Agregar Estacion de Servicio</h5>
                    </div>
                    <div class="card-body" style="width: 100%; overflow-x: auto">
                        <div class="form-group">
                            <label>Region</label>
                            <asp:DropDownList
                                ID="RegionDdl"
                                CssClass="form-control"
                                runat="server" />
                        </div>
                        <div class="form-group">
                            <label>Comuna</label>
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <asp:Button runat="server" OnClick="Get_Comunas" Text="Cargar Comunas" CssClass="btn btn-outline-success" />
                                </div>
                                <asp:DropDownList ID="ComunaDdl"
                                    CssClass="form-control"
                                    runat="server" />
                            </div>
                            <asp:CustomValidator
                                runat="server"
                                ID="comunaVAl"
                                ControlToValidate="ComunaDdl"
                                OnServerValidate="Validate_Comuna"
                                CssClass="text-danger"
                                ErrorMessage="Debe cargar comunas despues de elegir la region" />
                        </div>
                        <div class="form-group">
                            <label>Calle</label>
                            <asp:TextBox ID="CalleTextBox" CssClass="form-control" runat="server" />
                            <asp:RequiredFieldValidator ID="CityReqValidator"
                                ControlToValidate="CalleTextBox"
                                ErrorMessage="Ingrese el Nombre de la calle."
                                CssClass="text-danger"
                                Display="Dynamic"
                                EnableClientScript="False"
                                runat="server" />
                        </div>
                        <div class="form-group">
                            <label>Nro</label>
                            <asp:TextBox ID="NroTextBox" CssClass="form-control" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                ControlToValidate="NroTextBox"
                                ErrorMessage="Ingrese el numero"
                                CssClass="text-danger"
                                Display="Dynamic"
                                EnableClientScript="False"
                                runat="server" />
                            <asp:RangeValidator ID="RangeValidator2"
                                ControlToValidate="CapacidadMaximaTextBox"
                                MinimumValue="1"
                                MaximumValue="100000"
                                CssClass="text-danger"
                                Type="Integer"
                                ErrorMessage="Ingrese un Numero"
                                Display="Dynamic"
                                EnableClientScript="False"
                                runat="server" />
                        </div>
                        <div class="form-group">
                            <label>Codigo Postal</label>
                            <asp:TextBox ID="CodigoPostalTextBox" CssClass="form-control" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                ControlToValidate="CodigoPostalTextBox"
                                ErrorMessage="Ingrese el codigo postal"
                                CssClass="text-danger"
                                Display="Dynamic"
                                EnableClientScript="False"
                                runat="server" />
                            <asp:RangeValidator ID="RangeValidator3"
                                ControlToValidate="CodigoPostalTextBox"
                                MinimumValue="1"
                                MaximumValue="1000000"
                                CssClass="text-danger"
                                Type="Integer"
                                ErrorMessage="Ingrese un Numero Valido"
                                Display="Dynamic"
                                EnableClientScript="False"
                                runat="server" />
                        </div>
                        <div class="form-group">
                            <label>Capacidad</label>
                            <asp:TextBox ID="CapacidadMaximaTextBox" CssClass="form-control" runat="server" />
                            <asp:RangeValidator ID="RangeValidator1"
                                ControlToValidate="CapacidadMaximaTextBox"
                                MinimumValue="1"
                                MaximumValue="10000"
                                CssClass="text-danger"
                                Type="Integer"
                                ErrorMessage="Ingrese un Numero."
                                Display="Dynamic"
                                EnableClientScript="False"
                                runat="server" />
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            ControlToValidate="CapacidadMaximaTextBox"
                            ErrorMessage="Ingrese la capacidad maxima."
                            CssClass="text-danger"
                            Display="Dynamic"
                            EnableClientScript="False"
                            runat="server" />
                        <div class="form-group">
                            <label>Tarifa</label>
                            <asp:DropDownList ID="TarifaDdl" CssClass="form-control" runat="server" />
                        </div>
                        <label>Horario de Atencion</label>
                        <div class="row form-group ">
                            <div class="col col-xs-2">
                                <label for="ex1">Apertura</label>
                                <asp:TextBox ID="aperturaTxt" CssClass="form-control" TextMode="Time" runat="server" />
                            </div>
                            <div class="col col-xs-2">
                                <label for="ex2">Cierre</label>
                                <asp:TextBox ID="cierreTxt" CssClass="form-control" TextMode="Time" runat="server" />
                            </div>
                        </div>
                        <br />
                        <asp:CheckBoxList ID="weekdaychlist"
                            CellPadding="15"
                            CellSpacing="15"
                            RepeatDirection="Horizontal"
                            RepeatLayout="Flow"
                            TextAlign="Right"
                            runat="server">
                            <asp:ListItem Value="0">&nbsp;Lunes&ensp;</asp:ListItem>
                            <asp:ListItem Value="1">&nbsp;Martes&ensp;</asp:ListItem>
                            <asp:ListItem Value="2">&nbsp;Miercoles&ensp;</asp:ListItem>
                            <asp:ListItem Value="3">&nbsp;Jueves&ensp;</asp:ListItem>
                            <asp:ListItem Value="4">&nbsp;Viernes&ensp;</asp:ListItem>
                            <asp:ListItem Value="5">&nbsp;Sabado&ensp;</asp:ListItem>
                            <asp:ListItem Value="6">&nbsp;Domingo&ensp;</asp:ListItem>
                        </asp:CheckBoxList>
                       
                        <div class="card-footer d-grid gap-1">
                            <asp:Button runat="server" OnClick="Agregar" Text="Agregar" CssClass="btn btn-success d-inline" />
                            <a href="GrillaEstaciones.aspx" class="btn btn-secondary d-inline">Cancelar</a>
                        </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
