<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GrillaPuntos.aspx.cs" Inherits="ConsultaWeb.GrillaPuntos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row mt-5">
        <div class="col-12 col-md-6 col-lg-5 mx-auto">
            <div class="card">
                <div class="card-header bg-success text-white text-center">
                    <h5>Estaciones de Servicio</h5>
                </div>
                <div class="card-body" style="width: 100%; overflow-x: auto">
                    <asp:ObjectDataSource ID="puntosODS" runat="server" ParsingCulture="Current"
                        SelectMethod="ObtenerPuntosCarga" TypeName="EstacionesServicioModelo.DAL.PuntoCargaDAL" DataObjectTypeName="EstacionesServicioModelo.PuntoCarga" InsertMethod="RegistrarPunto" UpdateMethod="ActualizaPunto"></asp:ObjectDataSource>
                    <asp:GridView CssClass="table table-hover" DataKeyNames="id" ID="PuntosGridView" runat="server" AutoGenerateEditButton="True" DataSourceID="puntosODS" AllowPaging="True" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField ReadOnly="true" DataField="id" HeaderText="ID" SortExpression="id" />
                            <asp:CheckBoxField DataField="esDual" HeaderText="Es Dual?" SortExpression="esDual" />
                            <asp:BoundField DataField="capacidadMaxima" HeaderText="Capacidad" SortExpression="capacidadMaxima" />
                            <asp:BoundField DataField="fechaVencimiento" HeaderText="Fecha Vencimiento" ApplyFormatInEditMode="true" DataFormatString="{0:d}" SortExpression="fechaVencimiento" />
                        </Columns>
                    </asp:GridView>
                    <div class="input-group mb-3">
                        <asp:DropDownList CssClass="form-control" runat="server" ID="filtroCcb">
                            <asp:ListItem Value="0">Electricos</asp:ListItem>
                            <asp:ListItem Value="1">Duales</asp:ListItem>
                        </asp:DropDownList>
                        <div class="input-group-append">
                            <asp:Button CssClass="btn btn-outline-secondary" runat="server" OnClick="Filtrar" Text="Filtrar" />
                        </div>
                    </div>
                </div>
                <div class="card-footer d-grid gap-1">
                    <asp:Button runat="server" CssClass="btn btn-success" OnClick="SetFormViewCardVisible" Text="Agregar Punto de Carga Nuevo" />
                </div>
            </div>
            <div class="card" id="FormViewCard" runat="server" visible="false">
                <asp:FormView
                    DefaultMode="Insert"
                    ID="EstacionesFormView"
                    runat="server"
                    OnItemInserted="HideFormView"
                    DataSourceID="puntosODS">
                    <EditItemTemplate>
                        <div class="card-header bg-success text-white text-center">
                            <h5>Modificar</h5>
                        </div>
                        <div class="card-body" style="width: 100%; overflow-x: auto">
                            <div class="form-group">
                                <label>Id: </label>
                                <asp:TextBox ID="idTextBox" runat="server" CssClass="form-control" Text='<%# Bind("id") %>' />
                            </div>
                            <div class="form-group">
                                <label>Capacidad: </label>
                                <asp:TextBox ID="capacidadMaximaTextBox" runat="server" Text='<%# Bind("capacidadMaxima") %>' />
                            </div>
                            <div class="form-group">
                                <label>Fecha Vencimiento</label>
                                <asp:TextBox ID="fechaVencimientoTextBox" runat="server" Text='<%# Bind("fechaVencimiento") %>' />
                                <br />
                                estacionServicio:
                        <asp:TextBox ID="estacionServicioTextBox" runat="server" Text='<%# Bind("estacionServicio") %>' />
                                <br />
                                medCons:
                        <asp:TextBox ID="medConsTextBox" runat="server" Text='<%# Bind("medCons") %>' />
                                <br />
                                medTraf:
                        <asp:TextBox ID="medTrafTextBox" runat="server" Text='<%# Bind("medTraf") %>' />
                                <br />
                                esDual:
                        <asp:CheckBox ID="esDualCheckBox" runat="server" Checked='<%# Bind("esDual") %>' />
                                <br />
                                EstacionServicio1:
                        <asp:TextBox ID="EstacionServicio1TextBox" runat="server" Text='<%# Bind("EstacionServicio1") %>' />
                                <br />
                                MedidorConsumo:
                        <asp:TextBox ID="MedidorConsumoTextBox" runat="server" Text='<%# Bind("MedidorConsumo") %>' />
                                <br />
                                MedidorTrafico:
                        <asp:TextBox ID="MedidorTraficoTextBox" runat="server" Text='<%# Bind("MedidorTrafico") %>' />
                                <br />
                                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <div class="card-header bg-success text-white text-center">
                            <h5>Agregar</h5>
                        </div>
                        <div class="card-body" style="width: 100%; overflow-x: auto">
                            <div class="form-group">
                                <label>Id:</label>
                                <asp:TextBox ID="idTextBox" runat="server" TextMode="Number" CssClass="form-control" Text='<%# Bind("Id") %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                    ControlToValidate="IdTextBox"
                                    ErrorMessage="Ingrese el numero"
                                    CssClass="text-danger"
                                    Display="Dynamic"
                                    EnableClientScript="False"
                                    runat="server" />
                            </div>
                            <div class="form-group">
                                <label>Es Dual?</label>
                                <asp:CheckBox ID="esDualCheckBox" runat="server" Checked='<%# Bind("esDual") %>' />Si
                            </div>
                            <div class="form-group">
                                <label>Capacidad</label>
                                <asp:TextBox ID="TextBox2" CssClass="form-control" TextMode="Number" runat="server" Text='<%# Bind("CapacidadMaxima") %>' />
                            </div>
                            <div class="form-group">
                                <label>Fecha Vencimiento</label>
                                <asp:TextBox ID="TextBox3" CssClass="form-control" TextMode="Date" runat="server" Text='<%# Bind("FechaVencimiento","{0:d}") %>' />
                            </div>
                            <div class="form-group">
                                <label>EstacionServicio:</label>
                                <asp:ObjectDataSource ID="EstacionesODS" runat="server" DataObjectTypeName="EstacionesServicioModelo.EstacionServicio" DeleteMethod="EliminarEstacion" InsertMethod="RegistrarEstacion" SelectMethod="ObtenerEstaciones" TypeName="EstacionesServicioModelo.DAL.EstacionServicioDAL" UpdateMethod="ActualizarEstacion">
                                    <DeleteParameters>
                                        <asp:Parameter Name="id" Type="Int32" />
                                    </DeleteParameters>
                                </asp:ObjectDataSource>
                                <asp:DropDownList ID="TextBox4" CssClass="form-control" runat="server" DataSourceID="EstacionesODS" DataTextField="Id" DataValueField="Id" SelectedValue='<%# Bind("estacionServicio") %>' />
                            </div>
                            <div class="form-group">
                                <label>Medidor Trafico:</label>
                                <asp:ObjectDataSource ID="medTrafODS" runat="server" SelectMethod="ObtenerMedidores" TypeName="EstacionesServicioModelo.DAL.MedidorTraficoDAL"></asp:ObjectDataSource>
                                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" DataSourceID="medTrafODS" DataTextField="Id" DataValueField="Id" SelectedValue='<%# Bind("medTraf") %>' />
                            </div>
                            <div class="form-group">
                                <label>Medidor Consumo:</label>
                                <asp:ObjectDataSource ID="medConsODS" runat="server" SelectMethod="ObtenerMedidores" TypeName="EstacionesServicioModelo.DAL.MedidorConsumoDAL"></asp:ObjectDataSource>
                                <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server" DataSourceID="medConsODS" DataTextField="Id" DataValueField="Id" SelectedValue='<%# Bind("medCons") %>' />
                            </div>
                        </div>
                        <div class="card-footer d-grid gap-1">
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success" CausesValidation="True" CommandName="Insert" Text="Agregar" />
                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-secondary" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </div>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        id:
                        <asp:Label ID="idLabel" runat="server" Text='<%# Bind("id") %>' />
                        <br />
                        capacidadMaxima:
                        <asp:Label ID="capacidadMaximaLabel" runat="server" Text='<%# Bind("capacidadMaxima") %>' />
                        <br />
                        fechaVencimiento:
                        <asp:Label ID="fechaVencimientoLabel" runat="server" Text='<%# Bind("fechaVencimiento") %>' />
                        <br />
                        estacionServicio:
                        <asp:Label ID="estacionServicioLabel" runat="server" Text='<%# Bind("estacionServicio") %>' />
                        <br />
                        medCons:
                        <asp:Label ID="medConsLabel" runat="server" Text='<%# Bind("medCons") %>' />
                        <br />
                        medTraf:
                        <asp:Label ID="medTrafLabel" runat="server" Text='<%# Bind("medTraf") %>' />
                        <br />
                        esDual:
                        <asp:CheckBox ID="esDualCheckBox" runat="server" Checked='<%# Bind("esDual") %>' Enabled="false" />
                        <br />
                        EstacionServicio1:
                        <asp:Label ID="EstacionServicio1Label" runat="server" Text='<%# Bind("EstacionServicio1") %>' />
                        <br />
                        MedidorConsumo:
                        <asp:Label ID="MedidorConsumoLabel" runat="server" Text='<%# Bind("MedidorConsumo") %>' />
                        <br />
                        MedidorTrafico:
                        <asp:Label ID="MedidorTraficoLabel" runat="server" Text='<%# Bind("MedidorTrafico") %>' />
                        <br />
                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
                    </ItemTemplate>
                </asp:FormView>
            </div>
        </div>
    </div>
</asp:Content>
