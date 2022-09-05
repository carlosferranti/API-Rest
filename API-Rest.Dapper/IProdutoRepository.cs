using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using API_Rest.Domain;

namespace API_Rest.Dapper
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetAllAsync();
        Task<Produto> GetByIdAsync(int id);
        Task<Produto> GetByNomeAsync(string nome);
        void Insert(Produto produto);
        void Update(Produto produto);
        void Delete(int id);
    }
}
