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
                // Calcolo il prezzo totale dei prodotti nel carrello
                List<Prodotto> prodottiNelCarrello = (List<Prodotto>)Session["Carrello"];
                decimal totalePrezzi = prodottiNelCarrello.Sum(p => p.Prezzo);

                // Mostro l'alert con il messaggio "Acquisto effettuato" e il prezzo totale se ci sono prodotti nel carrello
                ScriptManager.RegisterStartupScript(this, GetType(), "AcquistoEffettuato", "alert('Acquisto effettuato. Totale: " + totalePrezzi.ToString("C") + "');", true);
            }
            else
            {
                // Se il carrello è vuoto, l'alert scriverà Carrello Vuoto
                ScriptManager.RegisterStartupScript(this, GetType(), "CarrelloVuoto", "alert('Non ci sono elementi nel carrello');", true);
            }
        }



        protected void Rimuovi_Click(object sender, EventArgs e)
        {
            // Ottiengo l'ID del pulsante "Rimuovi"
            Button btnRimuovi = (Button)sender;
            GridViewRow row = (GridViewRow)btnRimuovi.NamingContainer;
            int index = row.RowIndex;

            // Ottiengo il nome del prodotto da rimuovere dalla riga selezionata
            string nomeProdottoDaRimuovere = GridView1.Rows[index].Cells[0].Text; // Assumendo che il nome del prodotto sia nella prima cella della riga

            // Controllo se la lista dei prodotti nel carrello è presente nella sessione
            if (Session["Carrello"] != null)
            {
                // Ottengo la lista dei prodotti nel carrello dalla sessione
                List<Prodotto> prodottiNelCarrello = (List<Prodotto>)Session["Carrello"];

                // Elimino il prodotto dalla lista in base al NomeProdotto
                prodottiNelCarrello.RemoveAll(p => p.NomeProdotto == nomeProdottoDaRimuovere);

                // Aggiorno la GridView e il totale dei prezzi
                GridView1.DataSource = prodottiNelCarrello;
                GridView1.DataBind();

                // Calcolo e mostro la somma dei prezzi dei prodotti nel carrello
                decimal totalePrezzi = prodottiNelCarrello.Sum(p => p.Prezzo);
                lblTotalePrezzi.Text = $"Totale: {totalePrezzi:C}";

                // Aggiorno la sessione con la lista dei prodotti nel carrello modificata
                Session["Carrello"] = prodottiNelCarrello;
            }
        }

        protected void SvuotaCarrello_Click(object sender, EventArgs e)
        {
            // Verifico se il carrello contiene già prodotti
            if (Session["Carrello"] != null && ((List<Prodotto>)Session["Carrello"]).Count > 0)
            {
                // Elimino tutti i prodotti dalla lista del carrello
                Session.Remove("Carrello");

                // Aggiorno la GridView e il totale dei prezzi
                GridView1.DataSource = null;
                GridView1.DataBind();
                lblTotalePrezzi.Text = "Totale: $0.00"; // Resetta il totale dei prezzi a zero (o al valore desiderato)

                // Mostro un messaggio per confermare lo svuotamento del carrello
                ScriptManager.RegisterStartupScript(this, GetType(), "CarrelloSvuotato", "alert('Carrello svuotato');", true);
            }
            else
            {
                // Se il carrello è già vuoto, mostra un altro messaggio
                ScriptManager.RegisterStartupScript(this, GetType(), "CarrelloGiaVuoto", "alert('Niente da eliminare, il carrello è già vuoto');", true);
            }
        }


    }
}