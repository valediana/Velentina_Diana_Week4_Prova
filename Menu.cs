using GestioneSpese.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//visualizza totale spese
//il metodo dovrebbe restituire la somma degli importi per ogni categoria
//ma avevo frainteso la consegna. Query che avrei dovuto usare:
//select sum(s.Importo) as [Somma], s.IdCategoria
//from Categorie c join Spese s on c.Id= s.IdCategoria
//group by s.IdCategoria
namespace GestioneSpese
{
    internal class Menu
    {
        public static void Start()
        {
            Console.WriteLine("*****Benvenuto in gestione spese*****");
            bool mostra = true;

            do {
                Console.WriteLine("-----Menu-----");
                Console.WriteLine("Digita 1 per inserire nuova spesa");
                Console.WriteLine("Digita 2 per approvare una spesa");
                Console.WriteLine("Digita 3 per eliminare una spesa");
                Console.WriteLine("Digita 4 per visualizzare spese");
                Console.WriteLine("Digita 0 per uscire");
                int scelta = 0;
                do
                {
                    Console.WriteLine("Fai la tua scelta digitando un intero fra 0 e 4");
                } while (!(int.TryParse(Console.ReadLine(), out scelta)));

                switch (scelta)
                {

                    case 1:
                        InserisciSpesa();
                        break;
                    case 2:
                        ApprovaSpesa();
                        break;
                    case 3:
                        EliminaSpesa();
                        break;
                    case 4:
                        VisualizzaSpese();
                        break;
                    case 0:
                        Console.WriteLine("Arrivederci");
                        mostra = false;
                        break;
                } 
            } while (mostra);
        }

           
        public static void VisualizzaSpese()
        {
            bool mostraVis = true;
            do
            {
                Console.WriteLine("Seleziona quali spese visualizzare");
                Console.WriteLine("Digita 1 per visualizzare le spese approvate");
                Console.WriteLine("Digita 2 per visualizzare le spese di uno specifico utente");
                Console.WriteLine("Digita 3 per visualizzare le spese per categoria");
                Console.WriteLine("Digita 0 per tornare al Menu principale");

                int sceltaV = 0;
                while (!(int.TryParse(Console.ReadLine(), out sceltaV)))
                {
                    Console.WriteLine("Fai la tua scelta:");
                }
                switch (sceltaV)
                {
                    case 1:
                        VisualizzaSpeseApprovate();
                        break;
                    case 2:
                        VisualizzaSpeseUtente();
                        break;
                    case 3:
                        VisualizzaSpeseCategoria();
                        break;
                    case 0:
                        mostraVis = false;
                        break;
                }
            } while (mostraVis);
            

        }

        private static void VisualizzaSpeseCategoria()
        {
            
            List<Categoria> categorieTrovate= ConnectedMode.VisualizzaCategorie();
            foreach(var c in categorieTrovate)
            {
                Console.WriteLine($"{c.Id} - {c.Nome}");
            }
            int IdCategoria = 0;
            while(!(int.TryParse(Console.ReadLine(),out IdCategoria)))
            {
                Console.WriteLine("Inserisci categoria di cui visualizzare spese:");
            }
            
            List<Spesa> speseTrovate=ConnectedMode.VisualizzaSpesePerCategoria(IdCategoria);
            foreach (var s in speseTrovate)
            {
                Console.WriteLine($"Id: {s.Id} - Descrizione: {s.Descrizione} - Utente: {s.Utente}");
            }
        }

        private static void VisualizzaSpeseUtente()
        {
            string nomeUtente;
            Console.WriteLine("Inserisci nome utente di cui vuoi visualizzare le spese:");
            nomeUtente = Console.ReadLine();
            List<Spesa> speseTrovate = ConnectedMode.VisualizzaSpeseUtente(nomeUtente);
            foreach (var s in speseTrovate)
            {
                Console.WriteLine($"Id: {s.Id} - Descrizione: {s.Descrizione} - Importo: {s.Importo}");
            }
        }

        private static void VisualizzaSpeseApprovate()
        {
            List<Spesa> speseTrovate = ConnectedMode.VisualizzaSpeseApprovate();
            foreach (var s in speseTrovate)
            {
                Console.WriteLine($"Id: {s.Id}  - Descrizione:  {s.Descrizione}  - Importo: {s.Importo}: ");
            }
        }

        private static void EliminaSpesa()
        {
            List<Spesa> spesePresenti=ConnectedMode.VisualizzaSpese();
            Console.WriteLine("Elenco spese:");
            foreach (var s in spesePresenti)
            {
                Console.WriteLine($"Id: {s.Id} Descrizione: {s.Descrizione} Utente: {s.Utente}");
            }
            Console.WriteLine("Elimina una spesa");
            int idRiga = 0;
            while (!(int.TryParse(Console.ReadLine(), out idRiga)))
            {
                Console.WriteLine("Digita id spesa da eliminare");
            }
            DisconnectedMode.EliminaRiga(idRiga);
        }

        private static void ApprovaSpesa()
        {
            List<Spesa> speseTotali = ConnectedMode.VisualizzaSpese();
            Console.WriteLine("Elenco spese presenti:");
            foreach (var item in speseTotali)
            {
                Console.WriteLine($"ID: {item.Id} - {item.Descrizione} - {item.Utente} - Stato approvazione: {item.Approvato}");
            }
            
            int IdSpesa = 0;
            do
            {
                Console.WriteLine("Inserisci Id della spesa da approvare:");
            } while (!(int.TryParse(Console.ReadLine(), out IdSpesa)));

            bool approvata=ConnectedMode.ApprovaSpesa(IdSpesa);
            if (approvata)
            {
                Console.WriteLine("Spesa approvata");
            }
            else
            {
                Console.WriteLine("Errore");
            }

        }

        private static void InserisciSpesa()
        {
            Spesa nuovaSpesa= new Spesa();
            Console.WriteLine("Inserisci l'utente che ha effettuato la spesa");
            nuovaSpesa.Utente= Console.ReadLine();
            Console.WriteLine("Inserisci la descrizione della spesa");
            nuovaSpesa.Descrizione= Console.ReadLine();
            DateTime data;
            do
            {
                Console.WriteLine("Inserisci la data della spesa");
            }while(!(DateTime.TryParse(Console.ReadLine(), out data)));
            nuovaSpesa.Data = data;
            decimal importo;
            do
            {
                Console.WriteLine("Inserisci l'importo della spesa");
            }while(!decimal.TryParse(Console.ReadLine(), out  importo));
            nuovaSpesa.Importo = importo;
            Console.WriteLine("Inserisci id categoria della spesa");
            nuovaSpesa.CategoriaId= int.Parse(Console.ReadLine());
            bool aggiunto = ConnectedMode.AggiungiSpesa(nuovaSpesa);
            if (aggiunto)
            {
                Console.WriteLine("Spesa aggiunta correttamente");
            }
            else
            {
                Console.WriteLine("Qualcosa è andato storto");
            }
        }
    }
}
