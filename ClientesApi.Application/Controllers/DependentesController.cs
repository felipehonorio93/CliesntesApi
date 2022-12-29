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
    public class DependentesController : ControllerBase
    {
        private readonly IDependenteDomainService _dependenteDomainService;

        public DependentesController(IDependenteDomainService dependenteDomainService)
        {
            _dependenteDomainService = dependenteDomainService;
        }

        [HttpPost]
        public IActionResult Post(DependentesPostRequest request)
        {
            try
            {
                var dependente = new Dependente
                {
                    Nome = request.Nome,
                    DataNascimento = request.DataNascimento,
                    IdCliente = request.IdCliente,
                };

                _dependenteDomainService.Create(dependente);

                //HTTP 201 -> (CREATED)
                return StatusCode(201, new { message = "Dependente cadastrado com sucesso", dependente });
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
        public IActionResult Put(DependentesPutRequest request)
        {
            try
            {
                var dependente = new Dependente
                {
                    IdDependente = request.IdDependente,
                    Nome = request.Nome,
                    DataNascimento = request.DataNascimento,
                    IdCliente = request.IdCliente,
                };

                _dependenteDomainService.Update(dependente);

                //HTTP 200 -> (OK)
                return StatusCode(200, new { message = "Dependente atualizado com sucesso", dependente });
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

        [HttpDelete("{idDependente}")]
        public IActionResult Delete(Guid idDependente)
        {
            try
            {
                _dependenteDomainService.Delete(idDependente);

                //HTTP 200 -> (OK)
                return StatusCode(200, new { message = "Dependente excluído com sucesso" });
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
        [ProducesResponseType(200, Type = typeof(List<DependentesGetResponse>))]
        public IActionResult GetAll()
        {
            try
            {
                var lista = new List<DependentesGetResponse>();

                foreach (var item in _dependenteDomainService.GetAll())
                {
                    lista.Add(new DependentesGetResponse
                    {
                        IdDependente = item.IdDependente,
                        Nome = item.Nome,
                        DataNascimento = item.DataNascimento.Value.ToString("dd/MM/yyyy")
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

        [HttpGet("{idDependente}")]
        [ProducesResponseType(200, Type = typeof(DependentesGetResponse))]
        public IActionResult GetById(Guid idDependente)
        {
            try
            {
                var dependente = _dependenteDomainService.GetById(idDependente);

                var response = new DependentesGetResponse
                {
                    IdDependente = dependente.IdDependente,
                    Nome = dependente.Nome,
                    DataNascimento = dependente.DataNascimento.Value.ToString("dd/MM/yyyy")
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



