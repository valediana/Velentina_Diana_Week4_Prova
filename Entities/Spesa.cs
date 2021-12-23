using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.Entities
{
    public class Spesa
    {
//        Id(int, PK, auto-incrementale)
//• Data(datetime)
//• CategoriaId(int, FK)
//• Descrizione(varchar(500))
//• Utente(varchar(100))
//• Importo(decimal)
//• Approvato(bit)

        public int Id { get; set; }
        public string Descrizione { get; set; }
        public string Utente { get; set; }
        public DateTime Data { get; set; }
        public decimal Importo { get; set; }
        public bool Approvato { get; set; } = false;
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }    

        public Spesa()
        {

        }

    }
}
