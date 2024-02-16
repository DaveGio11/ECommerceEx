<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ECommerceEx._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .card {
            width: 100%;
            height: 100%;
        }
        .card-img-top {
            height: 200px; 
            object-fit: contain; 
        }
    </style>

    <main>
        <div class="row">
            <asp:Repeater ID="RepeaterProdotti" runat="server">
                <HeaderTemplate>
                    <div class="row">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-md-3">
                        <div  class="card">
                            <img id="Immagine" class="card-img-top" src='<%# Eval("ImmagineUrl") %>' alt="prodotto">
                            <div class="card-body">
                                <h5 id="NomeProdotto" class="card-title text-black"><%# Eval("NomeProdotto") %></h5>
                                <p id="Prezzo">€<%# Eval("Prezzo") %></p>
                                <asp:Button ID="Dettagli" CssClass="btn btn-primary" runat="server" Text="Dettagli" OnClick="Dettagli_Click"/>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <asp:Button ID="GoCarrello" CssClass="btn btn-warning my-3" runat="server" Text="Vai al Carrello" OnClick="GoCarrello_Click" />
    </main>
</asp:Content>
