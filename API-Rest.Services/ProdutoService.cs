using API_Rest.Dapper;
using API_Rest.Domain;
using API_Rest.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API_Rest.Service
{
    public class ProdutoService : IProdutoService
    {
        protected readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void Insert(Produto produto)
        {
            _produtoRepository.Insert(produto);
        }
        public void Delete(int id)
        {
            _produtoRepository.Delete(id);
        }

        public Task<IEnumerable<Produto>> GetAll()
        {
            return _produtoRepository.GetAllAsync();
        }

        public Task<Produto> GetById(int id)
        {
            return _produtoRepository.GetByIdAsync(id);
        }

        public Task<Produto> GetByNome(string nome)
        {
            return _produtoRepository.GetByNomeAsync(nome);
        }

        public void Update(Produto produto)
        {
            _produtoRepository.Update(produto);
        }
    }
}


