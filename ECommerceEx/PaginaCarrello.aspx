<%@ Page Title="Carrello" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaCarrello.aspx.cs" Inherits="ECommerceEx.PaginaCarrello" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h2>Carrello</h2>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="NomeProdotto" HeaderText="Nome Prodotto" />
                <asp:BoundField DataField="Prezzo" HeaderText="Prezzo" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="Rimuovi" CssClass="btn btn-danger" runat="server" Text="Rimuovi" OnClick="Rimuovi_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div>
            <asp:Label ID="lblTotalePrezzi" CssClass="my-3" runat="server"></asp:Label>
        </div>
        <div class="mt-3">
            <asp:Button ID="AddOther" CssClass="btn btn-primary" runat="server" Text="Seleziona Altro" OnClick="AddOther_Click" />
            <asp:Button ID="Acquista" CssClass="btn btn-success" runat="server" Text="Acquista" OnClick="Acquista_Click" />
            <asp:Button ID="SvuotaCarrello" CssClass="btn btn-danger" runat="server" Text="Svuota Carrello" OnClick="SvuotaCarrello_Click" />
        </div>
    </div>
</asp:Content>
