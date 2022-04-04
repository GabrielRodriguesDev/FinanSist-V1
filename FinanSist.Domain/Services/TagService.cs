using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Commands.Tag;
using FinanSist.Domain.Commands.Usuario;
using FinanSist.Domain.Entities;
using FinanSist.Domain.Interfaces.Infrastructure;
using FinanSist.Domain.Interfaces.Repositories;
using FinanSist.Domain.Interfaces.Services;

namespace FinanSist.Domain.Services
{
    public class TagService : ITagService
    {
        private ITagRepository _tagRepository;

        private IUnitOfWork _uow;

        public TagService(ITagRepository tagRepository, IUnitOfWork uow)
        {
            _tagRepository = tagRepository;
            _uow = uow;
        }
        public GenericCommandResult Create(CreateTagCommand createTagCommand)
        {
            createTagCommand.Validate();
            if (createTagCommand.Invalid)
            {
                return new GenericCommandResult(false, "Ops, algo deu errado!", createTagCommand.Notifications);
            }

            var tagdb = _tagRepository.ExistePorNome(createTagCommand.Nome);
            if (tagdb)
            {
                return new GenericCommandResult(false, "Desculpe, Tag já cadastrada.");
            }
            var tag = new Tag(createTagCommand);

            _uow.BeginTransaction();
            try
            {
                _tagRepository.Create(tag);
                _uow.Commit();
            }
            catch (System.Exception)
            {
                _uow.Rollback();
                throw;
            }
            return new GenericCommandResult(true, $"Tag {tag.Nome} cadastrada com sucesso.", new
            {
                Id = tag.Id,
                Nome = tag.Nome,
                Descricao = tag.Descricao,
                Ativo = tag.Ativo
            });
        }
        public GenericCommandResult Update(UpdateTagCommand updateTagCommand)
        {
            updateTagCommand.Validate();
            if (updateTagCommand.Invalid)
            {
                return new GenericCommandResult(false, "Ops, algo deu errado.", updateTagCommand.Notifications);
            }

            var tag = _tagRepository.Get(updateTagCommand!.Id!.Value);
            if (tag == null)
            {
                return new GenericCommandResult(false, "Desculpe, tag não foi localizada.");
            }
            if (tag.Nome != updateTagCommand.Nome)
            {
                var tagdb = _tagRepository.ExistePorNome(updateTagCommand.Nome);
                if (tagdb)
                {
                    return new GenericCommandResult(false, "Desculpe, Tag já cadastrada.");
                }
            }
            tag.Update(updateTagCommand);
            _uow.BeginTransaction();

            try
            {
                _tagRepository.Update(tag);
                _uow.Commit();
            }
            catch (System.Exception)
            {
                _uow.Rollback();
                throw;
            }
            return new GenericCommandResult(true, "Tag atualizado com sucesso.", new
            {
                Id = tag.Id,
                Nome = tag.Nome,
                Descricao = tag.Descricao,
                Ativo = tag.Ativo
            });
        }
        public GenericCommandResult Delete(Guid id)
        {
            var tagdb = _tagRepository.ExistePorId(id);
            if (!tagdb)
            {
                return new GenericCommandResult(false, "Desculpe, tag não foi localizada.");
            }

            _uow.BeginTransaction();
            try
            {
                _tagRepository.Delete(id);
                _uow.Commit();
            }
            catch (System.Exception)
            {
                _uow.Rollback();
                throw;
            }
            return new GenericCommandResult(true, "Tag removida com sucesso.");
        }
    }
}