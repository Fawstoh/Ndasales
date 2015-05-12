using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using S9.Web.Helpers.Extensoes;
using Top101WebApp.Helpers.Routing;
using ArcoticWindowsService.Models;
using System.Linq;
using System.Collections.Generic;


namespace ArcoticWindowsService
{
    public class ServiceTask
    {
        public void RunInventario()
        {
            try
            {
                //Define os Headers da requisição
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(ServiceRouter.Inventario);
                httpClient.Timeout = TimeSpan.FromMinutes(ServiceRouter.RemoteConectionTimeout);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Dados do inventário
                var dados = this.GetDadosInventario();

                // HTTP POST
                var response = httpClient.PostAsJsonAsync(string.Empty, dados).Result;

                //Salva no log a tarefa executada
                ServiceLog.SaveServiceTask("HTTP REQUEST TO " + httpClient.BaseAddress.AbsoluteUri + ": " + Newtonsoft.Json.JsonConvert.SerializeObject(dados));

                var result = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    //Salva no log a tarefa executada
                    ServiceLog.SaveServiceTask("HTTP RESPONSE " + response.StatusCode + ": " + result);
                }
                else
                {
                    //Salva no log a tarefa executada
                    ServiceLog.SaveServiceTask("HTTP RESPONSE ERROR " + response.StatusCode + ": " + result);
                }
            }
            catch (Exception ex)
            {
                ex.Save(new StackTrace(ex, true), ServiceLog.errorDir + "ERROR_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".log");
            }
        }


        public void RunVendas()
        {
            try
            {
                //Define os Headers da requisição
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(ServiceRouter.Vendas);
                httpClient.Timeout = TimeSpan.FromMinutes(ServiceRouter.RemoteConectionTimeout);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Dados do inventário
                var dados = this.GetDadosVendas();

                // HTTP POST
                var response = httpClient.PostAsJsonAsync(string.Empty, dados).Result;

                //Salva no log a tarefa executada
                ServiceLog.SaveServiceTask("HTTP REQUEST TO " + httpClient.BaseAddress.AbsoluteUri + ": " + Newtonsoft.Json.JsonConvert.SerializeObject(dados));

                var result = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    //Salva no log a tarefa executada
                    ServiceLog.SaveServiceTask("HTTP RESPONSE " + response.StatusCode + ": " + result);
                }
                else
                {
                    //Salva no log a tarefa executada
                    ServiceLog.SaveServiceTask("HTTP RESPONSE ERROR " + response.StatusCode + ": " + result);
                }
            }
            catch (Exception ex)
            {
                ex.Save(new StackTrace(ex, true), ServiceLog.errorDir + "ERROR_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".log");
            }
        }

        private object GetDadosVendas()
        {
            var dados = new VendaDto()
            {
                //Informações de acesso
                login = new Login()
                {
                    username = ServiceRouter.AuthenticationUsername,
                    password = ServiceRouter.AuthenticationPassword,
                }
            };

            //Itens da  venda
            dados.vendas = new List<Venda>();
            dados.vendas.Add(
                new Venda()
                {
                    _ref = "TA01",
                    data = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds, //Mudar essa data pela data da venda
                    moeda = "AOA",
                    status = "A",
                    cliente = new Cliente()
                    {
                        idcliente = 1,
                        nome = "Primeiro Cliente",
                    },
                    vendedor = new Vendedor()
                    {
                        idvendedor = 1,
                        nome = "Primeiro Vendedor"
                    },
                    artigos = new List<ArtigoVenda>()
                    {
                        new ArtigoVenda(){
                            id = 1,
                            qty = 1,
                            preco = "10.0", //Esse valor deve ser formatado com 1 casa decimal (as mesmas que o Kwanza usa)
                            desconto = 10,
                            preco_final = "9.0" //Esse valor deve ser formatado com 1 casa decimal (as mesmas que o Kwanza usa)
                        },
                    }
                }
            );

            return dados;
        }

        private InventarioDto GetDadosInventario()
        {
            var inventario = new InventarioDto()
            {
                //Informações de acesso
                login = new Login()
                {
                    username = ServiceRouter.AuthenticationUsername,
                    password = ServiceRouter.AuthenticationPassword,
                }
            };

            //Lista de artigos
            inventario.artigos = new List<ArtigoInventario>()
            {
                new ArtigoInventario()
                {
                    id = 1,
                    data = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds,
                    armazem = 10,
                    disponivel = 10,
                    alocada = 10,
                    transito = 10
                },
                new ArtigoInventario()
                {
                    id = 2,
                    data = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds,
                    armazem = 20,
                    disponivel = 20,
                    alocada = 20,
                    transito = 20
                }
            };
            //--

            return inventario;
        }
    }
}
