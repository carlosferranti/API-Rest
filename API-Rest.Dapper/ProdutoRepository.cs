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
        string colunas = @" pro_cod , 
                            pro_nome , 
                            pro_descricao ,
                            pro_foto ,
                            pro_valorpago ,
                            pro_valorvenda ,
                            pro_qtde ,
                            umed_cod ,
                            cat_cod ,
                            scat_cod ,                           
                            pro_data_criacao ,
                            pro_data_atualizacao ";

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

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = string.Format(@"SELECT {0} FROM produto", colunas);
                    return await dbConnection.QueryAsync<Produto>(query);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<Produto> GetByIdAsync(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = string.Format(@"SELECT {0} FROM produto WHERE pro_cod = @pro_cod", colunas);
                    return await dbConnection.QueryFirstOrDefaultAsync<Produto>(query, new { pro_cod = id });
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<Produto> GetByNomeAsync(string nome)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = string.Format(@"SELECT {0} FROM produto WHERE pro_nome = @pro_nome", colunas);
                    return await dbConnection.QueryFirstOrDefaultAsync<Produto>(query, new { pro_nome = nome });
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public void Delete(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE FROM produto WHERE pro_cod = @pro_cod";                    
                    dbConnection.Execute(query, new { pro_cod = id });
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public void Update(Produto produto)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE produto SET 
                                        pro_nome             = @pro_nome, 
                                        pro_descricao        = @pro_descricao, 
                                        pro_valorpago        = @pro_valorpago, 
                                        pro_valorvenda       = @pro_valorvenda, 
                                        pro_qtde             = @pro_qtde,                                        
                                        pro_data_criacao     = @pro_data_criacao,
                                        pro_data_atualizacao = @pro_data_atualizacao
                                     FROM produto 
                                     WHERE pro_nome     = @pro_nome";
                    dbConnection.Execute(query, produto);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public void Insert(Produto produto)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO produto
                                   (
                                     pro_nome
                                   , pro_descricao                                 
                                   , pro_valorpago
                                   , pro_valorvenda
                                   , pro_qtde  
                                   , pro_data_criacao 
                                   , pro_data_atualizacao
                                   )
                             VALUES
                                   (
                                    @pro_nome 
                                   ,@pro_descricao                                  
                                   ,@pro_valorpago
                                   ,@pro_valorvenda
                                   ,@pro_qtde                                    
                                   ,@pro_data_criacao 
                                   ,@pro_data_atualizacao
                                    )";

                    dbConnection.Execute(query, produto);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
