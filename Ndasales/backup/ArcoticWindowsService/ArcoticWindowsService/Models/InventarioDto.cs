using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S9.Web.Helpers.Extensoes;

namespace ArcoticWindowsService.Models
{
    public class InventarioDto
    {
        public Login login { get; set; }
        public ICollection<ArtigoInventario> artigos { get; set; }

        public string hmac 
        { 
            get 
            {
                //Cálculo da assinatura
                var _hmac = this.login.username + this.login.password;
                foreach (var artigo in this.artigos)
                {
                    _hmac = _hmac + artigo.id + artigo.data + artigo.armazem + artigo.disponivel + artigo.alocada + artigo.transito;
                }

                return "75ff65b710327683a3dee59f4e252d68";// _hmac.ToMD5();
            } 
        }
    }
}
