using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerceEx
{
    public partial class _Default : Page
    {
        public class Prodotto
        {
            public string NomeProdotto { get; set; }
            public decimal Prezzo { get; set; }
            public string ImmagineUrl { get; set; }
        }

        public static List<Prodotto> Prodotti = new List<Prodotto>
        {
            new Prodotto { NomeProdotto = "I-Phone", Prezzo = 700, ImmagineUrl = "Content/img/iphone.jpg" },
            new Prodotto { NomeProdotto = "Game-Boy", Prezzo = 45, ImmagineUrl = "Content/img/Gameboy.jpg" },
            new Prodotto { NomeProdotto = "Quadro", Prezzo = 2000, ImmagineUrl = "Content/img/Quadro.jpg" },
            new Prodotto { NomeProdotto = "Maglia Lazio", Prezzo = 98, ImmagineUrl = "Content/img/lazio.jpg" },
            new Prodotto { NomeProdotto = "JoJo Fumetto", Prezzo = 20, ImmagineUrl = "Content/img/jojo.jpg" },
            new Prodotto { NomeProdotto = "Kenshiro Fumetto", Prezzo = 30, ImmagineUrl = "Content/img/Kenshiro.jpg" },
            new Prodotto { NomeProdotto = "Zoro Poster", Prezzo = 50, ImmagineUrl = "Content/img/zoro.jpg" }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            // Stampo i prodotti sul browser
            if (!IsPostBack)
            {
                RepeaterProdotti.DataSource = Prodotti;
                RepeaterProdotti.DataBind();
            }
        }

        protected void Dettagli_Click(object sender, EventArgs e)
        {
            // Trovo il pulsante cliccato all'interno dell'elemento padre RepeaterItem
            Button btnDettagli = (Button)sender;
            RepeaterItem item = (RepeaterItem)btnDettagli.NamingContainer;

            // Cerco il nome del prodotto nella card selezionata
            int index = item.ItemIndex;
            string nomeProdotto = Prodotti[index].NomeProdotto;

            // Creo un cookie per memorizzare il nome del prodotto selezionato
            HttpCookie dettagli = new HttpCookie("Dettagli", nomeProdotto);

            // Imposto la scadenza del cookie
            dettagli.Expires = DateTime.Now.AddDays(5);
            Response.Cookies.Add(dettagli);

            // Creo il collegamento alla pagina dei dettagli
            Response.Redirect("PaginaDettagli.aspx");
        }

        protected void GoCarrello_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaCarrello.aspx");
        }
    }
}