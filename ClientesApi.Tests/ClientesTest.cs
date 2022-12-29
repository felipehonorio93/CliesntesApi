using Bogus;
using Bogus.Extensions.Brazil;
using ClientesApi.Application.Requests;
using ClientesApi.Application.Responses;
using ClientesApi.Domain.Entities;
using ClientesApi.Tests.Helpers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClientesApi.Tests
{
    public class ClientesTest
    {
        private const string _endpoint = "/api/clientes";
        private readonly AuthenticationHeaderValue _header;

        public ClientesTest()
        {
            _header = new AuthenticationHeaderValue("Bearer", new AuthHelper().ObterTokenAcesso().Result);
        }

        [Fact]
        public async Task<Cliente> Test_Post_Clientes_Returns_Created()
        {
            var faker = new Faker("pt_BR");

            var request = new ClientesPostRequest
            {
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Telefone = faker.Person.Phone,
                Cpf = faker.Person.Cpf()
            };

            var httpClient = TestsHelper.CreateClient;
            httpClient.DefaultRequestHeaders.Authorization = _header;

            var result = await httpClient.PostAsync(_endpoint, TestsHelper.CreateContent(request));
            result.StatusCode.Should().Be(HttpStatusCode.Created);

            var response = TestsHelper.ReadContent<ClientesResult>(result);
            response.Message.Should().Contain("Cliente cadastrado com sucesso");

            return response.Cliente;
        }

        [Fact]
        public async Task Test_Put_Clientes_Returns_Ok()
        {
            var cliente = await Test_Post_Clientes_Returns_Created();

            var faker = new Faker("pt_BR");

            var request = new ClientesPutRequest
            {
                IdCliente = cliente.IdCliente,
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Telefone = faker.Person.Phone,
                Cpf = faker.Person.Cpf()
            };

            var httpClient = TestsHelper.CreateClient;
            httpClient.DefaultRequestHeaders.Authorization = _header;

            var result = await httpClient.PutAsync(_endpoint, TestsHelper.CreateContent(request));
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var response = TestsHelper.ReadContent<ClientesResult>(result);
            response.Message.Should().Contain("Cliente atualizado com sucesso");
        }

        [Fact]
        public async Task Test_Delete_Clientes_Returns_Ok()
        {
            var cliente = await Test_Post_Clientes_Returns_Created();

            var httpClient = TestsHelper.CreateClient;
            httpClient.DefaultRequestHeaders.Authorization = _header;

            var result = await httpClient.DeleteAsync(_endpoint + "/" + cliente.IdCliente);
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var response = TestsHelper.ReadContent<ClientesResult>(result);
            response.Message.Should().Contain("Cliente excluído com sucesso");
        }

        [Fact]
        public async Task Test_GetAll_Clientes_Returns_Ok()
        {
            var cliente = await Test_Post_Clientes_Returns_Created();

            var httpClient = TestsHelper.CreateClient;
            httpClient.DefaultRequestHeaders.Authorization = _header;

            var result = await httpClient.GetAsync(_endpoint);
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var lista = TestsHelper.ReadContent<List<ClientesGetResponse>>(result);
            lista.FirstOrDefault(c => c.IdCliente == cliente.IdCliente)
                .Should().NotBeNull();
        }

        [Fact]
        public async Task Test_GetById_Clientes_Returns_Ok()
        {
            var cliente = await Test_Post_Clientes_Returns_Created();

            var httpClient = TestsHelper.CreateClient;
            httpClient.DefaultRequestHeaders.Authorization = _header;

            var result = await httpClient.GetAsync(_endpoint + "/" + cliente.IdCliente);
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var response = TestsHelper.ReadContent<ClientesGetResponse>(result);
            response.IdCliente.Should().Be(cliente.IdCliente);
        }
    }

    //Classe para deserializar os dados que a API
    //retornar após uma operação com cliente
    public class ClientesResult
    {
        public string? Message { get; set; }
        public Cliente? Cliente { get; set; }
    }
}



