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
        public string preco { get; set; }
        public int desconto { get; set; }
        public string preco_final { get; set; }

    }
}
