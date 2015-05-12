using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S9.Web.Helpers.Extensoes;
using Top101WebApp.Helpers.Routing;

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

                _hmac = Hmac.GetHashByMD5(ServiceRouter.AuthenticationSecret, _hmac).ToLower();

                return _hmac;
            } 
        }
    }
}
