using System;
using System.Collections.Generic;
using static ECommerceEx._Default;

namespace ECommerceEx
{
    public partial class PaginaDettagli : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Controllo se il cookie Dettagli esiste
                if (Request.Cookies["Dettagli"] != null)
                {
                    // Ottengo il nome del prodotto memorizzato nel cookie
                    string nomeProdotto = Request.Cookies["Dettagli"].Value;

                    // Utilizzo nomeProdotto per recuperare le info del prodotto desiderato
                    Prodotto prodottoSelezionato = Prodotti.Find(p => p.NomeProdotto == nomeProdotto);

                    // Utilizzo le info del prodotto per riempire la pagina dei dettagli
                    if (prodottoSelezionato != null)
                    {
                        // Imposto i valori nelle etichette della pagina
                        lblNomeProdotto.Text = prodottoSelezionato.NomeProdotto;
                        lblPrezzo.Text = prodottoSelezionato.Prezzo.ToString();
                        imgProdotto.ImageUrl = prodottoSelezionato.ImmagineUrl;
                    }
                }
            }
        }

        protected void HomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void Carrello_Click(object sender, EventArgs e)
        {
            // Controllo se il cookie Dettagli esiste
            if (Request.Cookies["Dettagli"] != null)
            {
                // Ottengo il nome del prodotto memorizzato nel cookie
                string nomeProdotto = Request.Cookies["Dettagli"].Value;

                // Utilizzo il nome per recuperare le info del prodotto desiderato
                Prodotto prodottoSelezionato = Prodotti.Find(p => p.NomeProdotto == nomeProdotto);

                // Ottengo la lista dei prodotti nel carrello dalla sessione
                List<Prodotto> prodottiNelCarrello;
                if (Session["Carrello"] == null)
                {
                    // Se la lista non esiste ancora, la creo
                    prodottiNelCarrello = new List<Prodotto>();
                }
                else
                {
                    // Altrimenti, ottengo la lista esistente dalla sessione
                    prodottiNelCarrello = (List<Prodotto>)Session["Carrello"];
                }

                // Aggiungo il prodotto selezionato alla lista nel carrello
                prodottiNelCarrello.Add(prodottoSelezionato);

                // Aggiorno la lista nella sessione
                Session["Carrello"] = prodottiNelCarrello;

                // Reindirizzo alla pagina del carrello
                Response.Redirect("PaginaCarrello.aspx");
            }
        }


    }
}