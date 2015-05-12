using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using S9.Web.Helpers;

namespace Top101WebApp.Helpers.Routing
{
    public static class ServiceRouter
    {
        /// <summary>
        /// Tempo limite para timeout de conexão remota (em milissegundos)
        /// </summary>
        public static int RemoteConectionTimeout
        {
            get
            {
                try
                {
                    return Convert.ToInt32(ConfigurationManager.AppSettings["RemoteConectionTimeout"].ToString());
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static string Inventario
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["InventarioAddress"].ToString() ?? null;  
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        public static string Vendas
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["VendasAddress"].ToString() ?? null;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        public static string AuthenticationUsername
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["AuthenticationUsername"].ToString() ?? null;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        public static string AuthenticationPassword
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["AuthenticationPassword"].ToString() ?? null;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        public static string AuthenticationSecret
        {
            get
            {
                try
                {
                    return ConfigurationManager.AppSettings["AuthenticationSecret"].ToString() ?? null;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
    }
}
