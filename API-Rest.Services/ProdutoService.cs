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
        public void AddProdutos(Produto produto)
        {
            _produtoRepository.AddProdutos(produto);
        }

        public void DeleteProduto(int id)
        {
            _produtoRepository.DeleteProduto(id);
        }

        public Task<IEnumerable<Produto>> GetAllProduto()
        {
            return _produtoRepository.GetAllProdutoAsync();
        }

        public Task<Produto> GetProdutoById(int id)
        {
            return _produtoRepository.GetProdutoByIdAsync(id);
        }

        public Task<Produto> GetProdutoByNome(string nome)
        {
            return _produtoRepository.GetProdutoByNomeAsync(nome);
        }

        public void UpdateProduto(Produto produto)
        {
            _produtoRepository.UpdateProduto(produto);
        }
    }
}
