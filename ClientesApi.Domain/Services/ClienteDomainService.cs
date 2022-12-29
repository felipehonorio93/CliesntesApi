using ClientesApi.Domain.Entities;
using ClientesApi.Domain.Interfaces.Repositories;
using ClientesApi.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApi.Domain.Services
{
    /// <summary>
    /// Classe de serviços de dominio para cliente
    /// </summary>
    public class ClienteDomainService : IClienteDomainService
    {
        //atributo
        private readonly IClienteRepository _clienteRepository;

        //construtor para injeção de dependência (inicialização do atributo)
        public ClienteDomainService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void Create(Cliente entity)
        {
            #region CPF deve ser único para cada cliente

            if (_clienteRepository.GetByCpf(entity.Cpf) != null)
                throw new ArgumentException($"O CPF '{entity.Cpf}', já está cadastrado para outro cliente.");

            #endregion

            #region Gerando os dados automáticos do cliente

            entity.IdCliente = Guid.NewGuid();
            entity.DataHoraCadastro = DateTime.Now;
            entity.DataHoraUltimaAtualizacao = DateTime.Now;

            #endregion

            #region Realizando o cadastro do cliente

            _clienteRepository.Create(entity);

            #endregion
        }

        public void Update(Cliente entity)
        {
            #region O Cliente deve existir no banco de dados

            var cliente = _clienteRepository.GetById(entity.IdCliente.Value);
            if (cliente == null)
                throw new ArgumentException($"O Cliente não foi encontrado, verifique o ID informado.");

            #endregion

            #region CPF deve ser único para cada cliente

            var clienteByCpf = _clienteRepository.GetByCpf(entity.Cpf);
            if (clienteByCpf != null && clienteByCpf.IdCliente != entity.IdCliente)
                throw new ArgumentException($"O CPF '{entity.Cpf}', já está cadastrado para outro cliente.");

            #endregion

            #region Gerando os dados automáticos do cliente

            entity.DataHoraUltimaAtualizacao = DateTime.Now;
            entity.DataHoraCadastro = cliente.DataHoraCadastro;

            #endregion

            #region Atualizando o cadastro do cliente

            _clienteRepository.Update(entity);

            #endregion
        }

        public void Delete(Guid id)
        {
            #region O Cliente deve existir no banco de dados

            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
                throw new ArgumentException($"O Cliente não foi encontrado, verifique o ID informado.");

            #endregion

            #region Excluindo o cliente

            _clienteRepository.Delete(cliente);

            #endregion
        }

        public List<Cliente> GetAll()
        {
            return _clienteRepository.GetAll();
        }

        public Cliente GetById(Guid id)
        {
            #region O Cliente deve existir no banco de dados

            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
                throw new ArgumentException($"O Cliente não foi encontrado, verifique o ID informado.");

            #endregion

            return cliente;
        }
    }
}



