using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Commands.Categorias;
using FinanSist.Domain.Commands.Usuario;
using FinanSist.Domain.Entities;
using FinanSist.Domain.Interfaces.Infrastructure;
using FinanSist.Domain.Interfaces.Repositories;
using FinanSist.Domain.Interfaces.Services;

namespace FinanSist.Domain.Services
{
    public class CategoriaService : ICategoriaService
    {
        #region  Property
        private ICategoriaRepository _categoriaRespository;

        private IUnitOfWork _uow;
        #endregion

        #region  Constructor
        public CategoriaService(ICategoriaRepository categoriaRepository, IUnitOfWork uow)
        {
            _categoriaRespository = categoriaRepository;
            _uow = uow;
        }
        #endregion

        #region  Method
        public GenericCommandResult Create(CreateCategoriaCommand createCommand)
        {
            createCommand.Validate();
            if (createCommand.Invalid)
                return new GenericCommandResult(false, "Ops, algo deu errado!", createCommand.Notifications);
            var categoriadb = _categoriaRespository.ExistePorNomeETipo(createCommand.Nome, createCommand.Tipo);
            if (categoriadb)
                return new GenericCommandResult(false, "Desculpe, categoria já cadastrada no sistema.");
            var categoria = new Categoria(createCommand);
            _uow.BeginTransaction();
            try
            {
                _categoriaRespository.Create(categoria);
                _uow.Commit();
            }
            catch (System.Exception)
            {
                _uow.Rollback();
                throw;
            }
            return new GenericCommandResult(true, $"Categoria {categoria.Nome} salvo com sucesso!", new
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Tipo = categoria.Tipo
            });
        }
        public GenericCommandResult Update(UpdateCategoriaCommand updateCommand)
        {
            updateCommand.Validate();
            if (updateCommand.Invalid)
                return new GenericCommandResult(false, "Ops, algo deu errado!", updateCommand.Notifications);
            var categoria = _categoriaRespository.Get(updateCommand.Id!.Value);
            if (categoria == null)
            {
                return new GenericCommandResult(false, "Desculpe, categoria não foi localizada.");
            }
            categoria.Update(updateCommand);
            _uow.BeginTransaction();
            try
            {
                _categoriaRespository.Update(categoria);
                _uow.Commit();
            }
            catch (System.Exception)
            {
                _uow.Rollback();
                throw;
            }
            return new GenericCommandResult(true, "Categoria atualizada com sucesso!", new
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Tipo = categoria.Tipo
            });

        }
        public GenericCommandResult Delete(Guid id)
        {
            var categoriadb = _categoriaRespository.ExistePorId(id);
            if (!categoriadb)
            {
                return new GenericCommandResult(false, "Desculpe, categoria não foi localizada.");
            }
            _uow.BeginTransaction();
            try
            {
                _categoriaRespository.Delete(id);
                _uow.Commit();
            }
            catch (System.Exception)
            {
                _uow.Rollback();
                throw;
            }
            return new GenericCommandResult(true, "Categoria removida com sucesso!");
        }
        #endregion
    }
}