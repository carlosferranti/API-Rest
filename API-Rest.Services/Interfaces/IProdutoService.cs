using API_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API_Rest.Services
{
    interface IProdutoService
    {       
        Task<IEnumerable<Produto>> GetAllProduto();

        Task<Produto> GetProdutoById(int id);
        Task<Produto> GetProdutoByNome(string nome);              
        void AddProdutos(Produto produto);
        void UpdateProduto(Produto produto);
        void DeleteProduto(int id);
    }
}
