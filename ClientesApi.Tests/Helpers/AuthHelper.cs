using ClientesApi.Application.Requests;
using ClientesApi.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApi.Tests.Helpers
{
    /// <summary>
    /// Classe auxiliar para autenticação e obtenção do TOKEN
    /// </summary>
    public class AuthHelper
    {
        public async Task<string> ObterTokenAcesso()
        {
            var request = new AuthPostRequest
            {
                Email = "admin@gmail.com",
                Senha = "adminadmin"
            };

            var result = await TestsHelper.CreateClient.PostAsync("/api/auth", TestsHelper.CreateContent(request));
            var response = TestsHelper.ReadContent<AuthGetResponse>(result);

            return response.AccessToken;
        }
    }
}



