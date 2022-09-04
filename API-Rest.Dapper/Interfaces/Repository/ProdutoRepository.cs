using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using API_Rest.Domain;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace API_Rest.Dapper
{
    public class ProdutoRepository : IProdutoRepository
    {
        protected readonly IConfiguration _config;

        public ProdutoRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public void AddProdutos(Produto produto)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO produto
                                   (pro_nome
                                   ,pro_descricao                                 
                                   ,pro_valorpago
                                   ,pro_valorvenda
                                   ,pro_qtde    
                                   )
                             VALUES
                                   (@pro_nome 
                                   ,@pro_descricao                                  
                                   ,@pro_valorpago
                                   ,@pro_valorvenda
                                   ,@pro_qtde 
                                    )";
                    dbConnection.Execute(query);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
            
        public void DeleteProduto(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE FROM produto WHERE pro_id = @pro_id";
                    dbConnection.Execute(query, new { Id = id });
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<IEnumerable<Produto>> GetAllProdutoAsync()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT pro_nome, pro_descricao, pro_valorpago, pro_valorvenda, pro_qtde FROM produto";
                    return await dbConnection.QueryAsync<Produto>(query);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public Task<Produto> GetProdutoByIdAsysnc(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT pro_nome, pro_descricao, pro_valorpago, pro_valorvenda, pro_qtde FROM produto WHERE pro_id = @pro_id";
                    return dbConnection.QueryFirstOrDefaultAsync<Produto>(query, new { Id = id });
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<Produto> GetProdutoByNomeAsysnc(string nome)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT pro_nome, pro_descricao, pro_valorpago, pro_valorvenda, pro_qtde FROM produto WHERE pro_nome = @pro_nome";
                    return await dbConnection.QueryFirstOrDefaultAsync<Produto>(query, new { pro_nome = nome });
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public void UpdateProduto(Produto produto)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE produto SET pro_nome = @pro_nome, pro_descricao = @pro_descricao, pro_valorpago = @pro_valorpago, pro_valorvenda = @pro_valorvenda, pro_qtde = @pro_qtde FROM produto WHERE pro_nome = @pro_nome";
                    dbConnection.Execute (query, produto);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
