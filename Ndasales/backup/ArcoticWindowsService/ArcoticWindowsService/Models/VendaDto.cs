using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S9.Web.Helpers.Extensoes;

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
                    _hmac += venda._ref +
                        venda.cliente.idcliente +
                        venda.cliente.nome +
                        venda.vendedor.idvendedor +
                        venda.vendedor.nome + 
                        venda.data +
                        venda.moeda + venda.status;

                    foreach (var artigo in venda.artigos)
                    {
                        _hmac += artigo.id + artigo.qty + artigo.preco + artigo.desconto + artigo.preco_final;
                    }
                }

                return "e92fd4711135319264b2fd1075375a24"; //_hmac.ToMD5();
            } 
        }
    }
}
