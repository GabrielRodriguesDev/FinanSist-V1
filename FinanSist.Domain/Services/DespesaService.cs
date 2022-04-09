using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Commands;
using FinanSist.Domain.Commands.Despesa;
using FinanSist.Domain.Entities;
using FinanSist.Domain.Interfaces.Infrastructure;
using FinanSist.Domain.Interfaces.Repositories;
using FinanSist.Domain.Interfaces.Services;

namespace FinanSist.Domain.Services
{
    public class DespesaService : IDespesaService
    {
        private IDespesaRepository _despesaRepository;

        private IUnitOfWork _uow;

        public DespesaService(IDespesaRepository despesaRepository, IUnitOfWork uow)
        {
            this._despesaRepository = despesaRepository;
            this._uow = uow;
        }

        public GenericCommandResult Create(CreateDespesaCommand createDespesaCommand)
        {
            createDespesaCommand.Validate();
            if (createDespesaCommand.Invalid) return new GenericCommandResult(false, "Ops, algo deu errado.", createDespesaCommand.Notifications);


            var entidadedb = _despesaRepository.RetornaCampo(createDespesaCommand.EntidadeId, "Entidade", "Nome");
            if (entidadedb == null) return new GenericCommandResult(false, "Desculpe, entidade não localizada");

            if (createDespesaCommand.CategoriaId != null)
            {
                var categoriadb = _despesaRepository.RetornaCampo(createDespesaCommand.CategoriaId, "Categoria", "Nome");
                if (categoriadb == null) return new GenericCommandResult(false, "Desculpe, categoria não localizada");
            }


            if (createDespesaCommand.TagId != null)
            {
                var tagdb = _despesaRepository.RetornaCampo(createDespesaCommand.TagId, "Tag", "Nome");
                if (tagdb == null) return new GenericCommandResult(false, "Desculpe, tag não localizada");
            }


            Despesa despesa = new Despesa(createDespesaCommand);

            _uow.BeginTransaction();
            try
            {
                _despesaRepository.Create(despesa);
                _uow.Commit();
            }
            catch (Exception)
            {
                _uow.Rollback();
                throw;
            }
            return new GenericCommandResult(true, "Despesa salva com sucesso!", new
            {
                Id = despesa.Id,
                Descricao = despesa.Descricao,
                DataPagamento = despesa.DataPagamento,
                DataPrevisao = despesa.DataPrevisao,
                EntidadeId = despesa.EntidadeId,
                CategoriaId = despesa.CategoriaId,
                TagId = despesa.TagId,
                Observacao = despesa.Observacao
            });
        }

        public GenericCommandResult Update(UpdateDespesaCommand updateDespesaCommand)
        {
            updateDespesaCommand.Validate();
            if (updateDespesaCommand.Invalid) return new GenericCommandResult(false, "Ops, algo deu errado.", updateDespesaCommand.Notifications);

            var despesa = _despesaRepository.Get(updateDespesaCommand.Id!.Value);
            if (despesa == null) return new GenericCommandResult(false, "Desculpe, despesa não localizada.");


            if (despesa.EntidadeId != updateDespesaCommand.EntidadeId)
            {
                var entidadedb = _despesaRepository.RetornaCampo(updateDespesaCommand.EntidadeId, "Entidade", "Nome");
                if (entidadedb == null) return new GenericCommandResult(false, "Desculpe, entidade não localizada");
            }
            if (despesa.CategoriaId != updateDespesaCommand.CategoriaId && updateDespesaCommand.CategoriaId != null)
            {
                var categoriadb = _despesaRepository.RetornaCampo(updateDespesaCommand.CategoriaId, "Categoria", "Nome");
                if (categoriadb == null) return new GenericCommandResult(false, "Desculpe, categoria não localizada");
            }

            if (despesa.TagId != updateDespesaCommand.TagId && updateDespesaCommand.TagId != null)
            {
                var tagdb = _despesaRepository.RetornaCampo(updateDespesaCommand.TagId, "Tag", "Nome");
                if (tagdb == null) return new GenericCommandResult(false, "Desculpe, tag não localizada");
            }

            despesa.Update(updateDespesaCommand);



            _uow.BeginTransaction();

            try
            {
                _despesaRepository.Update(despesa);
                _uow.Commit();
            }
            catch (System.Exception)
            {
                _uow.Rollback();
                throw;
            }
            return new GenericCommandResult(true, "Despesa atualizada com sucesso.", new
            {
                Id = despesa.Id,
                DataPagamento = despesa.DataPagamento,
                DataPrevisao = despesa.DataPrevisao,
                EntidadeId = despesa.EntidadeId,
                CategoriaId = despesa.CategoriaId,
                TagId = despesa.TagId,
                Observacao = despesa.Observacao
            });
        }

        public GenericCommandResult Delete(Guid id)
        {
            var despesadb = _despesaRepository.ExistePorId(id);
            if (!despesadb) return new GenericCommandResult(false, "Desculpe, despesa não localizada.");

            _uow.BeginTransaction();

            try
            {
                _despesaRepository.Delete(id);
                _uow.Commit();
            }
            catch (Exception)
            {
                _uow.Rollback();
                throw;
            }
            return new GenericCommandResult(true, "Despesa removida com sucesso");
        }
    }
}