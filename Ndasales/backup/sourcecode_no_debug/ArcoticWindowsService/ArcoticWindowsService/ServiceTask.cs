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

                //Task log
                ServiceLog.SaveServiceTask("HTTP REQUEST TO " + httpClient.BaseAddress.AbsoluteUri + ": " + Newtonsoft.Json.JsonConvert.SerializeObject(dados) + " - " + DateTime.Now);

                var result = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    //Task log
                    ServiceLog.SaveServiceTask("HTTP RESPONSE " + response.StatusCode + ": " + result + " - " + DateTime.Now);
                }
                else
                {
                    //Task log
                    ServiceLog.SaveServiceTask("HTTP RESPONSE ERROR " + response.StatusCode + ": " + result + " - " + DateTime.Now);
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

                //Task log
                ServiceLog.SaveServiceTask("HTTP REQUEST TO " + httpClient.BaseAddress.AbsoluteUri + ": " + Newtonsoft.Json.JsonConvert.SerializeObject(dados) + " - " + DateTime.Now);

                var result = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    //Task log
                    ServiceLog.SaveServiceTask("HTTP RESPONSE " + response.StatusCode + ": " + result + " - " + DateTime.Now);
                }
                else
                {
                    //Task log
                    ServiceLog.SaveServiceTask("HTTP RESPONSE ERROR " + response.StatusCode + ": " + result + " - " + DateTime.Now);
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
            dados.vendas.Add(                
                new Venda()
                {
                    _ref = "TA01",
                    data = 1425052203,
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
                            preco = 10,
                            desconto = 10,
                            preco_final = 9
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
            inventario.artigos.Add(
                new ArtigoInventario()
                {
                    id = 1,
                    data = 1425052203,
                    armazem = 10,
                    disponivel = 10,
                    alocada = 10,
                    transito = 10
                }
            );

            inventario.artigos.Add(
                new ArtigoInventario()
                {
                    id = 2,
                    data = 1425052203,
                    armazem = 20,
                    disponivel = 20,
                    alocada = 20,
                    transito = 20
                }
            );
            //--

            return inventario;
        }
    }
}
