using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ArcoticWindowsService.Models
{
    public class Venda
    {
        [JsonProperty(PropertyName = "ref")]
        public string _ref { get; set; }
		public long data    { get; set; }
		public string	moeda   { get; set; }
        public string status { get; set; }
		public Cliente	cliente { get; set; }
        public Vendedor	vendedor { get; set;}

        public ICollection<ArtigoVenda> artigos { get; set; }

    }
}
