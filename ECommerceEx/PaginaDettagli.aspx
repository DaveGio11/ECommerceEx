<%@ Page Title="Dettagli Prodotto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaDettagli.aspx.cs" Inherits="ECommerceEx.PaginaDettagli" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Dettagli Prodotto</h2>
        <div class="row">
            <div class="col-md-6">
                <asp:Image ID="imgProdotto" runat="server" CssClass="img-fluid" />
            </div>
            <div class="col-md-6">
                <h3>Nome Prodotto:</h3>
                <asp:Label ID="lblNomeProdotto" runat="server" Text=""></asp:Label>
                <h3>Prezzo:</h3>
                <asp:Label ID="lblPrezzo" runat="server" Text=""></asp:Label>
                <div class="mt-2">
                    <asp:Button ID="HomePage" CssClass="btn btn-primary" runat="server" Text="Home Page" OnClick="HomePage_Click" />
                    <asp:Button ID="Carrello" CssClass="btn btn-warning" runat="server" Text="Aggiungi al Carrello" OnClick="Carrello_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
