using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FinanSist.Domain.Entities;
using FinanSist.Domain.Interfaces.Infrastructure;
using FinanSist.Domain.Interfaces.Repositories;
using FinanSist.Domain.Queries;
using FinanSist.Domain.Queries.Params;
using FinanSist.Domain.Queries.Result;
using FinanSist.Domain.Queries.Result.Grupo;

namespace FinanSist.Database.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(FinanSistContext context, IUnitOfWork uow) : base(context, uow)
        {
        }


        public bool ExistePorNomeETipo(string nome, int? tipo)
        {
            var result = _connection.Query(CategoriaQueries.ExistePorNomeETipo(), new { Nome = nome, Tipo = tipo }).FirstOrDefault();
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public CategoriaFormQueryResult? PesquisarForm(SearchFormParams searchFormParams)
        {
            return _connection.Query<CategoriaFormQueryResult>(BaseQueries.PesquisarForm(searchFormParams), searchFormParams).FirstOrDefault();
        }

        public IEnumerable<ListaCategoriaQueryResult> Pesquisar(SearchParams searchParams)
        {
            return _connection.Query<ListaCategoriaQueryResult>(BaseQueries.Pesquisar(searchParams), searchParams);
        }

    }
}