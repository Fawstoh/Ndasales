using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top101WebApp.Helpers.Routing;

namespace ArcoticWindowsService.Models
{
    public class VendaDto
    {
        public Login login { get; set; }
        public ICollection<Venda> vendas { get; set; }

        public string hmac 
        { 
            get 
            {
                //Cálculo da assinatura
                var _hmac = this.login.username + this.login.password;
                foreach (var venda in this.vendas)
                {
                    _hmac = _hmac + venda._ref +
                        venda.cliente.idcliente +
                        venda.cliente.nome +
                        venda.vendedor.idvendedor +
                        venda.vendedor.nome + 
                        venda.data +
                        venda.moeda + venda.status;

                    foreach (var artigo in venda.artigos)
                    {
                        _hmac = _hmac + artigo.id + artigo.qty + artigo.preco + artigo.desconto + artigo.preco_final;
                    }
                }

                _hmac = Hmac.GetHashByMD5(ServiceRouter.AuthenticationSecret, _hmac).ToLower();

                return _hmac;
            } 
        }
    }
}
