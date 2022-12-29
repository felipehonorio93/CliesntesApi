using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApi.Tests.Helpers
{
    public class TestsHelper
    {
        /// <summary>
        /// Método para criar uma instância da classe HttpClient
        /// </summary>
        public static HttpClient CreateClient
            => new WebApplicationFactory<Program>().CreateClient();

        /// <summary>
        /// Método para serializar um objeto em JSON (Requisição da API)
        /// </summary>
        public static StringContent CreateContent(object request)
            => new StringContent(JsonConvert.SerializeObject(request),
                        Encoding.UTF8, "application/json");

        /// <summary>
        /// Método para deserializar uma resposta obtida da API
        /// </summary>
        public static T ReadContent<T>(HttpResponseMessage result)
            => JsonConvert.DeserializeObject<T>
                        (result.Content.ReadAsStringAsync().Result);
    }
}



