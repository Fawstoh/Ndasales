using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcoticWindowsService.Models
{
    public class ArtigoInventario
    {
        public int id { get; set; }
		public int data { get; set; }
		public int armazem { get; set; }
		public int disponivel { get; set; }
		public int alocada { get; set; }
		public int transito { get; set; }

    }
}
