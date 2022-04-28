using FinanSist.Domain.Commands;
using FinanSist.Domain.Commands.Despesa;
using FinanSist.Domain.Commands.DespesaTag;
using FinanSist.Domain.Entities;
using FinanSist.Domain.Interfaces.Helpers;
using FinanSist.Domain.Interfaces.Infrastructure;
using FinanSist.Domain.Interfaces.Repositories;
using FinanSist.Domain.Interfaces.Services;

namespace FinanSist.Domain.Services
{
    public class DespesaService : IDespesaService
    {
        private IDespesaRepository _despesaRepository;

        private ISequenciaHelper _sequenciaHelper;

        private IDespesaTagService _despesaTagService;

        private IUnitOfWork _uow;

        public DespesaService(IDespesaRepository despesaRepository, IDespesaTagService despesaTagService, IUnitOfWork uow, ISequenciaHelper sequenciaHelper)
        {
            this._despesaRepository = despesaRepository;
            this._despesaTagService = despesaTagService;
            this._uow = uow;
            this._sequenciaHelper = sequenciaHelper;
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

            Despesa despesa = new Despesa(createDespesaCommand);
            var codigoInterno = _sequenciaHelper.ProximoNumero(typeof(Despesa).Name);
            despesa.setCodigoInterno(codigoInterno);
            despesa.setDescricaoRepeticao(1);

            _uow.BeginTransaction();
            try
            {
                if (createDespesaCommand.TagId != null && createDespesaCommand.TagId.Count() > 0)
                {
                    foreach (var tagId in createDespesaCommand.TagId!)
                    {
                        GenericDepesaTagCommand createDepesaTagCommand = new GenericDepesaTagCommand(despesa.Id, tagId);
                        _despesaTagService.Create(createDepesaTagCommand);
                    }
                }

                _despesaRepository.Create(despesa);
                _uow.Commit();
                if (createDespesaCommand.Repetir)
                {
                    var resultDepesaRepetidas = this.CreateDepesasRepeticao(createDespesaCommand);
                    if (!resultDepesaRepetidas.Success)
                    {
                        return resultDepesaRepetidas;
                    }
                }
            }
            catch (Exception)
            {
                _uow.Rollback();
                throw;
            }
            return new GenericCommandResult(true, "Despesa salva com sucesso!", new
            {
                Id = despesa.Id,
                CodigoInterno = despesa.CodigoInterno,
                Descricao = despesa.Descricao,
                DataPagamento = despesa.DataPagamento,
                DataPrevisao = despesa.DataPrevisao,
                EntidadeId = despesa.EntidadeId,
                CategoriaId = despesa.CategoriaId,
                Tags = new { createDespesaCommand.TagId },
                Observacao = despesa.Observacao
            });
        }

        public GenericCommandResult CreateDepesasRepeticao(CreateDespesaCommand createDespesaCommand)
        {
            List<CreateDespesaCommand> createDespesaList = new List<CreateDespesaCommand>();
            createDespesaList.Add(createDespesaCommand);
            for (int i = 1; i < createDespesaCommand.QuantidadeRepeticao; i++)
            {
                CreateDespesaCommand createDespesaCommandTemp = createDespesaList.Last().DeepCopy();
                createDespesaList.Add(createDespesaCommandTemp);
            }
            try
            {
                int controladorData = 0;
                int controladorRepeticao = 1;
                _uow.BeginTransaction();
                foreach (var createDespesa in createDespesaList)
                {
                    if (createDespesaList.IndexOf(createDespesa) != 0)
                    {


                        Despesa despesa = new Despesa(createDespesa);

                        controladorData = controladorData + 1;
                        despesa.setDataDespesaRepeticao(controladorData);

                        controladorRepeticao = controladorRepeticao + 1;
                        despesa.setDescricaoRepeticao(controladorRepeticao);


                        var codigoInterno = _sequenciaHelper.ProximoNumeroCurrentTransaction(typeof(Despesa).Name);
                        despesa.setCodigoInterno(codigoInterno);

                        if (createDespesa.TagId != null && createDespesa.TagId.Count() > 0)
                        {
                            foreach (var tagId in createDespesa.TagId!)
                            {
                                GenericDepesaTagCommand createDepesaTagCommand = new GenericDepesaTagCommand(despesa.Id, tagId);
                                _despesaTagService.Create(createDepesaTagCommand);
                            }
                        }
                        _despesaRepository.Create(despesa);
                    }

                }
                _uow.Commit();
            }
            catch (Exception e)
            {
                _uow.Rollback();
                return new GenericCommandResult(false, $"Erro ao salvar registros repetidos. {e}");
            }
            return new GenericCommandResult(true, "Registros repetidos salvos com sucesso.");
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

            despesa.Update(updateDespesaCommand);
            _uow.BeginTransaction();

            try
            {

                if (updateDespesaCommand.TagId != null && updateDespesaCommand.TagId.Count() > 0)
                {
                    var despesaTags = _despesaTagService.Delete(despesa.Id);
                    if (despesaTags)
                    {
                        foreach (var tagId in updateDespesaCommand.TagId!)
                        {
                            GenericDepesaTagCommand updateDespesaTagCommand = new GenericDepesaTagCommand(despesa.Id, tagId);
                            var despesaTag = _despesaTagService.Create(updateDespesaTagCommand);
                            if (!despesaTag.Success)
                            {
                                return despesaTag;
                            }
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("Não foi possivel excluir as tags");
                    }
                }

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
                Tags = new { updateDespesaCommand.TagId },
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