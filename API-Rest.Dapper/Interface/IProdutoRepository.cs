using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using API_Rest.Domain;

namespace API_Rest.Dapper
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetAllProdutoAsync();
        Task<Produto> GetProdutoByIdAsysnc(int id);
        Task<Produto> GetProdutoByNomeAsysnc(string nome);
        void AddProdutos(Produto produto);
        void UpdateProduto(Produto produto);
        void DeleteProduto(int id);
    }
}
