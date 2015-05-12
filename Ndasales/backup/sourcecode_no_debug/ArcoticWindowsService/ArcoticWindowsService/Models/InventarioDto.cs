using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    _hmac += artigo.id + artigo.data + artigo.armazem + artigo.disponivel + artigo.alocada + artigo.transito;
                }

                return _hmac;
            } 
        }
    }
}
