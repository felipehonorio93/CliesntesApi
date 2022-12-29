using ClientesApi.Application.Requests;
using ClientesApi.Application.Responses;
using ClientesApi.Domain.Entities;
using ClientesApi.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientesApi.Application.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        //atributos
        private readonly IClienteDomainService _clienteDomainService;

        public ClientesController(IClienteDomainService clienteDomainService)
        {
            _clienteDomainService = clienteDomainService;
        }

        [HttpPost]
        public IActionResult Post(ClientesPostRequest request)
        {
            try
            {
                var cliente = new Cliente
                {
                    Nome = request.Nome,
                    Cpf = request.Cpf,
                    Email = request.Email,
                    Telefone = request.Telefone
                };

                _clienteDomainService.Create(cliente);

                //HTTP 201 -> (CREATED)
                return StatusCode(201, new { message = "Cliente cadastrado com sucesso", cliente });
            }
            catch (ArgumentException e)
            {
                //HTTP 400 -> BAD REQUEST
                return StatusCode(400, new { message = e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 -> INTERNAL SERVER ERROR
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpPut]
        public IActionResult Put(ClientesPutRequest request)
        {
            try
            {
                var cliente = new Cliente
                {
                    IdCliente = request.IdCliente,
                    Nome = request.Nome,
                    Cpf = request.Cpf,
                    Email = request.Email,
                    Telefone = request.Telefone
                };

                _clienteDomainService.Update(cliente);

                //HTTP 200 -> (OK)
                return StatusCode(200, new { message = "Cliente atualizado com sucesso", cliente });
            }
            catch (ArgumentException e)
            {
                //HTTP 400 -> BAD REQUEST
                return StatusCode(400, new { message = e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 -> INTERNAL SERVER ERROR
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpDelete("{idCliente}")]
        public IActionResult Delete(Guid idCliente)
        {
            try
            {
                _clienteDomainService.Delete(idCliente);

                //HTTP 200 -> (OK)
                return StatusCode(200, new { message = "Cliente excluído com sucesso" });
            }
            catch (ArgumentException e)
            {
                //HTTP 400 -> BAD REQUEST
                return StatusCode(400, new { message = e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 -> INTERNAL SERVER ERROR
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ClientesGetResponse>))]
        public IActionResult GetAll()
        {
            try
            {
                var lista = new List<ClientesGetResponse>();

                foreach (var item in _clienteDomainService.GetAll())
                {
                    lista.Add(new ClientesGetResponse
                    {
                        IdCliente = item.IdCliente,
                        Nome = item.Nome,
                        Cpf = item.Cpf,
                        Email = item.Email,
                        Telefone = item.Telefone
                    });
                }

                //HTTP 200 -> (OK)
                return StatusCode(200, lista);
            }
            catch (Exception e)
            {
                //HTTP 500 -> INTERNAL SERVER ERROR
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("{idCliente}")]
        [ProducesResponseType(200, Type = typeof(ClientesGetResponse))]
        public IActionResult GetById(Guid idCliente)
        {
            try
            {
                var cliente = _clienteDomainService.GetById(idCliente);

                var response = new ClientesGetResponse
                {
                    IdCliente = cliente.IdCliente,
                    Nome = cliente.Nome,
                    Cpf = cliente.Cpf,
                    Email = cliente.Email,
                    Telefone = cliente.Telefone
                };

                //HTTP 200 -> (OK)
                return StatusCode(200, response);
            }
            catch (ArgumentException e)
            {
                //HTTP 400 -> BAD REQUEST
                return StatusCode(400, new { message = e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 -> INTERNAL SERVER ERROR
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}



