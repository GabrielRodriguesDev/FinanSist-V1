using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Commands.Entidade;
using FinanSist.Domain.Commands.Usuario;
using FinanSist.Domain.Entities;
using FinanSist.Domain.Interfaces.Infrastructure;
using FinanSist.Domain.Interfaces.Repositories;
using FinanSist.Domain.Interfaces.Services;

namespace FinanSist.Domain.Services
{
    public class EntidadeService : IEntidadeService
    {
        #region  Property
        private IEntidadeRepository _entidadeRepository;

        private IUnitOfWork _uow;
        #endregion

        #region  Constructor
        public EntidadeService(IEntidadeRepository entidadeRepository, IUnitOfWork uow)
        {
            _entidadeRepository = entidadeRepository;
            _uow = uow;
        }
        #endregion

        #region  Method
        public GenericCommandResult Create(CreateEntidadeCommand createEntidadeCommand)
        {
            createEntidadeCommand.Validate();
            if (createEntidadeCommand.Invalid)
            {
                return new GenericCommandResult(false, "Ops! Algo deu errado!", createEntidadeCommand.Notifications);
            }

            var entidadedb = _entidadeRepository.ExistePorNome(createEntidadeCommand.Nome);

            if (entidadedb)
            {
                return new GenericCommandResult(false, "Desculpe, Entidade já cadastrada.");
            }

            var entidade = new Entidade(createEntidadeCommand);

            _uow.BeginTransaction();
            try
            {
                _entidadeRepository.Create(entidade);
                _uow.Commit();
            }
            catch (System.Exception)
            {
                _uow.Rollback();
                throw;
            }
            return new GenericCommandResult(true, $"Entidade {entidade.Nome} cadastrada com sucesso.", new
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Descricao = entidade.Descricao,
                Ativo = entidade.Ativo
            });
        }

        public GenericCommandResult Update(UpdateEntidadeCommand updateEntidadeCommand)
        {
            updateEntidadeCommand.Validate();
            if (updateEntidadeCommand.Invalid)
            {
                return new GenericCommandResult(false, "Ops, algo deu errado!", updateEntidadeCommand.Notifications);
            }

            var entidade = _entidadeRepository.Get(updateEntidadeCommand.Id!.Value);
            if (entidade == null)
            {
                return new GenericCommandResult(false, "Desculpe, entidade não foi localizada.");
            }

            entidade.Update(updateEntidadeCommand);
            _uow.BeginTransaction();
            try
            {
                _entidadeRepository.Update(entidade);
                _uow.Commit();
            }
            catch (System.Exception)
            {
                _uow.Rollback();
                throw;
            }
            return new GenericCommandResult(true, "Entidade atualizada com sucesso!", new
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Descricao = entidade.Descricao,
                Ativo = entidade.Ativo
            });
        }

        public GenericCommandResult Delete(Guid id)
        {
            var entidadedb = _entidadeRepository.ExistePorId(id);
            if (!entidadedb)
            {
                return new GenericCommandResult(false, "Desculpe, entidade não foi localizada.");
            }

            _uow.BeginTransaction();
            try
            {
                _entidadeRepository.Delete(id);
                _uow.Commit();
            }
            catch (System.Exception)
            {
                _uow.Rollback();
                throw;
            }
            return new GenericCommandResult(true, "Entidade removida com sucesso!");
        }
        #endregion
    }
}