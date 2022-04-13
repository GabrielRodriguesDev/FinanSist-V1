using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Commands;
using FinanSist.Domain.Commands.DespesaTag;
using FinanSist.Domain.Entities;
using FinanSist.Domain.Interfaces.Infrastructure;
using FinanSist.Domain.Interfaces.Repositories;
using FinanSist.Domain.Interfaces.Services;

namespace FinanSist.Domain.Services
{
    public class DepesaTagService : IDespesaTagService
    {


        private IDespesaTagRepository _despesaTagRepository;
        private ITagRepository _tagRepository;
        private IUnitOfWork _uow;

        public DepesaTagService(IDespesaTagRepository depesaTagRepository, ITagRepository tagRepository, IUnitOfWork uow)
        {
            this._despesaTagRepository = depesaTagRepository;
            this._tagRepository = tagRepository;
            this._uow = uow;
        }
        public GenericCommandResult Create(GenericDepesaTagCommand createDepesaTagCommand)
        {
            createDepesaTagCommand.Validate();
            if (createDepesaTagCommand.Invalid) return new GenericCommandResult(true, "Ops, algo deu errado!", createDepesaTagCommand.Notifications);

            var tagdb = _tagRepository.RetornaCampo(createDepesaTagCommand.TagId, "Tag", "Nome");
            if (tagdb == null) return new GenericCommandResult(false, "Desculpe, tag não localizada");

            var depesatagdb = _despesaTagRepository.ExistePorIdDespesaTag(createDepesaTagCommand.DespesaId!.Value, createDepesaTagCommand.TagId!.Value);
            if (depesatagdb != null) return new GenericCommandResult(false, "Desculpe, tag já cadastrada.");

            DespesaTag despesaTag = new DespesaTag(createDepesaTagCommand);

            _despesaTagRepository.Create(despesaTag);

            return new GenericCommandResult(true, "Tag cadastrada com sucesso.", despesaTag);
        }

        public bool Delete(Guid despesaId)
        {
            _despesaTagRepository.DeleteDespesaTag(despesaId);

            var despesasTags = _despesaTagRepository.ExistePorDepesa(despesaId);

            if (!despesasTags)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}