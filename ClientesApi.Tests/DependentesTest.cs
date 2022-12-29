using Bogus;
using ClientesApi.Application.Requests;
using ClientesApi.Application.Responses;
using ClientesApi.Domain.Entities;
using ClientesApi.Tests.Helpers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClientesApi.Tests
{
    public class DependentesTest
    {
        private const string _endpoint = "/api/dependentes";
        private readonly AuthenticationHeaderValue _header;

        public DependentesTest()
        {
            _header = new AuthenticationHeaderValue("Bearer", new AuthHelper().ObterTokenAcesso().Result);
        }

        [Fact]
        public async Task<Dependente> Test_Post_Dependentes_Returns_Created()
        {
            var cliente = await new ClientesTest().Test_Post_Clientes_Returns_Created();

            var faker = new Faker("pt_BR");

            var request = new DependentesPostRequest
            {
                Nome = faker.Person.FullName,
                DataNascimento = faker.Person.DateOfBirth,
                IdCliente = cliente.IdCliente
            };


            var httpClient = TestsHelper.CreateClient;
            httpClient.DefaultRequestHeaders.Authorization = _header;

            var result = await httpClient.PostAsync(_endpoint, TestsHelper.CreateContent(request));
            result.StatusCode.Should().Be(HttpStatusCode.Created);

            var response = TestsHelper.ReadContent<DependentesResult>(result);
            response.Message.Should().Contain("Dependente cadastrado com sucesso");

            return response.Dependente;
        }

        [Fact]
        public async Task Test_Put_Dependentes_Returns_Ok()
        {
            var dependente = await Test_Post_Dependentes_Returns_Created();

            var faker = new Faker("pt_BR");

            var request = new DependentesPutRequest
            {
                IdDependente = dependente.IdDependente,
                Nome = faker.Person.FullName,
                DataNascimento = faker.Person.DateOfBirth,
                IdCliente = dependente.IdCliente
            };

            var httpClient = TestsHelper.CreateClient;
            httpClient.DefaultRequestHeaders.Authorization = _header;

            var result = await httpClient.PutAsync(_endpoint, TestsHelper.CreateContent(request));
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var response = TestsHelper.ReadContent<DependentesResult>(result);
            response.Message.Should().Contain("Dependente atualizado com sucesso");
        }

        [Fact]
        public async Task Test_Delete_Dependentes_Returns_Ok()
        {
            var dependente = await Test_Post_Dependentes_Returns_Created();

            var httpClient = TestsHelper.CreateClient;
            httpClient.DefaultRequestHeaders.Authorization = _header;

            var result = await httpClient.DeleteAsync(_endpoint + "/" + dependente.IdDependente);
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var response = TestsHelper.ReadContent<DependentesResult>(result);
            response.Message.Should().Contain("Dependente excluído com sucesso");
        }

        [Fact]
        public async Task Test_GetAll_Dependentes_Returns_Ok()
        {
            var dependente = await Test_Post_Dependentes_Returns_Created();

            var httpClient = TestsHelper.CreateClient;
            httpClient.DefaultRequestHeaders.Authorization = _header;

            var result = await httpClient.GetAsync(_endpoint);
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var lista = TestsHelper.ReadContent<List<DependentesGetResponse>>(result);
            lista.FirstOrDefault(c => c.IdDependente == dependente.IdDependente)
                .Should().NotBeNull();
        }

        [Fact]
        public async Task Test_GetById_Dependentes_Returns_Ok()
        {
            var dependente = await Test_Post_Dependentes_Returns_Created();

            var httpClient = TestsHelper.CreateClient;
            httpClient.DefaultRequestHeaders.Authorization = _header;

            var result = await httpClient.GetAsync(_endpoint + "/" + dependente.IdDependente);
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var response = TestsHelper.ReadContent<DependentesGetResponse>(result);
            response.IdDependente.Should().Be(dependente.IdDependente);
        }
    }

    //Classe para deserializar os dados que a API
    //retornar após uma operação com dependentes
    public class DependentesResult
    {
        public string? Message { get; set; }
        public Dependente? Dependente { get; set; }
    }
}



