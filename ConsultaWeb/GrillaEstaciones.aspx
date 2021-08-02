<%@ Page Title=""  Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GrillaEstaciones.aspx.cs" Inherits="ConsultaWeb.GrillaEstaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row mt-5">
        <div class="col-12 col-md-6 col-lg-5 mx-auto">
            <div class="card">
                <div class="card-header bg-success text-white text-center">
                    <h5>Estaciones de Servicio</h5>
                </div>
                <div class="card-body" style="width: 100%; overflow-x: auto">
                    <asp:ObjectDataSource ID="estacionesODS" runat="server"
                        SelectMethod="ObtenerEstaciones"  TypeName="EstacionesServicioModelo.DAL.EstacionServicioDAL" DataObjectTypeName="EstacionesServicioModelo.EstacionServicio" DeleteMethod="EliminarEstacion" InsertMethod="RegistrarEstacion" UpdateMethod="ActualizarEstacion">
                        <deleteparameters>
                            <asp:parameter name="Id" type="Int32" />
                        </deleteparameters>
                    </asp:ObjectDataSource>
                    <asp:GridView CssClass="table table-hover" DataKeyNames="Id" ID="EstacionesGridView" runat="server" AutoGenerateColumns="False" DataSourceID="estacionesODS" AllowPaging="True">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                            <asp:TemplateField HeaderText="Region">
                                <ItemTemplate>
                                    <%# Eval("Direccion1.region") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comuna">
                                <ItemTemplate>
                                    <%# Eval("Direccion1.comuna") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Direccion">
                                <ItemTemplate>
                                    <%# Eval("Direccion1").ToString() %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="capacidadMaxima" HeaderText="Cap" SortExpression="capacidadMaxima" />
                            <asp:BoundField DataField="tarifa" HeaderText="tarifa" SortExpression="tarifa" />
                            <asp:TemplateField HeaderText="Horario">
                                <ItemTemplate> 
                                    <%# Eval("HorarioList") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="BorrarBtn" runat="server" Text="Delete" CommandName="Delete"
                                    CssClass="btn btn-outline-danger" OnClick="Borrar" />
                                </ItemTemplate>                                
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="card-footer d-grid gap-1">
                    <a href="AgregarEstacion.aspx" class="btn btn-dark">Agregar Nueva Estacion</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
