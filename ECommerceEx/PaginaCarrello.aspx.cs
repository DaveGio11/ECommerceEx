using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using static ECommerceEx._Default;

namespace ECommerceEx
{
    public partial class PaginaCarrello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Controllo se la lista dei prodotti nel carrello è presente nella sessione
                if (Session["Carrello"] != null)
                {
                    // Ottengo la lista dei prodotti nel carrello dalla sessione
                    List<Prodotto> prodottiNelCarrello = (List<Prodotto>)Session["Carrello"];

                    // Ora puoi fare qualcosa con la lista, ad esempio visualizzarla in una griglia o in un elenco
                    // Esempio di come si potrebbe visualizzare in una griglia GridView:
                    GridView1.DataSource = prodottiNelCarrello;
                    GridView1.DataBind();

                    // Calcolo e mostro la somma dei prezzi dei prodotti nel carrello
                    decimal totalePrezzi = prodottiNelCarrello.Sum(p => p.Prezzo);
                    lblTotalePrezzi.Text = $"Totale: {totalePrezzi:C}";
                }
            }
        }

        protected void AddOther_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void Acquista_Click(object sender, EventArgs e)
        {
            if (Session["Carrello"] != null && ((List<Prodotto>)Session["Carrello"]).Count > 0)
            {
                // Calcola il prezzo totale dei prodotti nel carrello
                List<Prodotto> prodottiNelCarrello = (List<Prodotto>)Session["Carrello"];
                decimal totalePrezzi = prodottiNelCarrello.Sum(p => p.Prezzo);

                // Mostra l'alert con il messaggio "Acquisto effettuato" e il prezzo totale
                ScriptManager.RegisterStartupScript(this, GetType(), "AcquistoEffettuato", "alert('Acquisto effettuato. Totale: " + totalePrezzi.ToString("C") + "');", true);
            }
            else
            {
                // Se il carrello è vuoto, mostra un messaggio diverso
                ScriptManager.RegisterStartupScript(this, GetType(), "CarrelloVuoto", "alert('Non ci sono elementi nel carrello');", true);
            }
        }



        protected void Rimuovi_Click(object sender, EventArgs e)
        {
            // Ottieni l'ID del pulsante "Rimuovi" che ha generato l'evento
            Button btnRimuovi = (Button)sender;
            GridViewRow row = (GridViewRow)btnRimuovi.NamingContainer;
            int index = row.RowIndex;

            // Ottieni il nome del prodotto da rimuovere dalla riga selezionata
            string nomeProdottoDaRimuovere = GridView1.Rows[index].Cells[0].Text; // Assumendo che il nome del prodotto sia nella prima cella della riga

            // Controllo se la lista dei prodotti nel carrello è presente nella sessione
            if (Session["Carrello"] != null)
            {
                // Ottengo la lista dei prodotti nel carrello dalla sessione
                List<Prodotto> prodottiNelCarrello = (List<Prodotto>)Session["Carrello"];

                // Rimuovi il prodotto dalla lista in base al nome
                prodottiNelCarrello.RemoveAll(p => p.NomeProdotto == nomeProdottoDaRimuovere);

                // Aggiorna la GridView e il totale dei prezzi
                GridView1.DataSource = prodottiNelCarrello;
                GridView1.DataBind();

                // Calcolo e mostro la somma dei prezzi dei prodotti nel carrello
                decimal totalePrezzi = prodottiNelCarrello.Sum(p => p.Prezzo);
                lblTotalePrezzi.Text = $"Totale: {totalePrezzi:C}";

                // Aggiorna la sessione con la lista dei prodotti nel carrello modificata
                Session["Carrello"] = prodottiNelCarrello;
            }
        }


    }
}