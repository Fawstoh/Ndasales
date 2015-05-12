using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcoticWindowsService.Models
{
    public class ArtigoVenda
    {
        public int id { get; set; }
        public int qty { get; set; }
        public string preco { get { return String.Format("{0:0.0}", this.preco); }  set { preco = value; } }
        public int desconto { get; set; }
        public string preco_final { get { return String.Format("{0:0.0}", this.preco_final); }  set { preco_final = value; } }

    }
}
