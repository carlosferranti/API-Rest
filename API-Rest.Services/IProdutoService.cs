using API_Rest.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API_Rest.Services
{
    public interface IProdutoService
    {       
        Task<IEnumerable<Produto>> GetAll();
        Task<Produto> GetById(int id);
        Task<Produto> GetByNome(string nome);              
        void Insert(Produto produto);
        void Add(Produto produto);
        void Update(Produto produto);
        void Delete(int id);
    }
}
