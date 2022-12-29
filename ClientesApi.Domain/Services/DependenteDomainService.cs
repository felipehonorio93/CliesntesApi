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
    /// Classe de regras de negócio de dominio para dependente
    /// </summary>
    public class DependenteDomainService : IDependenteDomainService
    {
        //atributos
        private readonly IDependenteRepository _dependenteRepository;
        private readonly IClienteRepository _clienteRepository;

        //construtor para injeção de dependência (inicialização dos atributos)
        public DependenteDomainService(IDependenteRepository dependenteRepository, IClienteRepository clienteRepository)
        {
            _dependenteRepository = dependenteRepository;
            _clienteRepository = clienteRepository;
        }

        public void Create(Dependente entity)
        {
            #region Verificar se o cliente existe no banco de dados

            if (_clienteRepository.GetById(entity.IdCliente.Value) == null)
                throw new ArgumentException("O Cliente não foi encontrado, verifique o ID informado.");

            #endregion

            #region Gerando os dados automáticos do cliente

            entity.IdDependente = Guid.NewGuid();
            entity.DataHoraCadastro = DateTime.Now;
            entity.DataHoraUltimaAtualizacao = DateTime.Now;

            #endregion

            #region Cadastrando o dependente

            _dependenteRepository.Create(entity);

            #endregion
        }

        public void Update(Dependente entity)
        {
            #region O Dependente deve existir no banco de dados

            var dependente = _dependenteRepository.GetById(entity.IdDependente.Value);
            if (dependente == null)
                throw new ArgumentException($"O Dependente não foi encontrado, verifique o ID informado.");

            #endregion

            #region Verificar se o cliente existe no banco de dados

            if (_clienteRepository.GetById(entity.IdCliente.Value) == null)
                throw new ArgumentException("O Cliente não foi encontrado, verifique o ID informado.");

            #endregion

            #region Gerando os dados automáticos do cliente

            entity.DataHoraUltimaAtualizacao = DateTime.Now;
            entity.DataHoraCadastro = dependente.DataHoraCadastro;

            #endregion

            #region Atualizando o dependente

            _dependenteRepository.Update(entity);

            #endregion
        }

        public void Delete(Guid id)
        {
            #region O Dependente deve existir no banco de dados

            var dependente = _dependenteRepository.GetById(id);
            if (dependente == null)
                throw new ArgumentException($"O Dependente não foi encontrado, verifique o ID informado.");

            #endregion

            #region Excluindo o dependente

            _dependenteRepository.Delete(dependente);

            #endregion
        }

        public List<Dependente> GetAll()
        {
            return _dependenteRepository.GetAll();
        }

        public Dependente GetById(Guid id)
        {
            #region O Dependente deve existir no banco de dados

            var dependente = _dependenteRepository.GetById(id);
            if (dependente == null)
                throw new ArgumentException($"O Dependente não foi encontrado, verifique o ID informado.");

            #endregion

            return dependente;
        }
    }
}



