using CommonComponents;

using DomainLayer.Models.Estoques;
using DomainLayer.Models.Produtos;

using ServiceLayer.Services.EstoqueServices;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Estoque
{
    public class HistoricoEstoqueRepository : IHistoricoEstoqueRepository
    {
        private string _connectionString;
        enum TeypeRegister
        {
            Add,
            Remove,
            Delete
        }

        public HistoricoEstoqueRepository()
        {

        }

        public HistoricoEstoqueRepository(string connectionString)
        {
            _connectionString = connectionString;
        }



        public void Add(IHistoricoEstoqueModel historicoModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query =
                " INSERT INTO HistoricoEstoque (EstoqueId, ProdutoId, TypeRegister, Quantidade, ValorCompra, ValorSaida) " +
                " VALUES (@EstoqueId, @ProdutoId, @TypeRegister, @Quantidade, @ValorCompra, @ValorSaida)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@EstoqueId", historicoModel.EstoqueId);
                        cmd.Parameters.AddWithValue("@ProdutoId", historicoModel.ProdutoId);
                        cmd.Parameters.AddWithValue("@TypeRegister", historicoModel.TypeRegister);
                        cmd.Parameters.AddWithValue("@Quantidade", historicoModel.Quantidade);
                        cmd.Parameters.AddWithValue("@ValorCompra", historicoModel.ValorCompra);
                        cmd.Parameters.AddWithValue("@ValorSaida", historicoModel.ValorSaida);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlException e)
                        {
                            dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível executar a adição de registro no Histórico do Estoque", e.HelpLink, e.ErrorCode, e.StackTrace);
                            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                        }
                    }

                }
                catch (DataAccessException ex)
                {
                    ex.DataAccessStatusInfo.CustomMessage = "Histórico de Estoque não pôde ser adicionado.";
                    ex.DataAccessStatusInfo.ExceptionMessage = ex.Message;
                    ex.DataAccessStatusInfo.StackTrace = ex.StackTrace;
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IHistoricoEstoqueModel> GetAll()
        {
            List<HistoricoEstoqueModel> modelList = new List<HistoricoEstoqueModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query =
                "SELECT * FROM HistoricoEstoque";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                HistoricoEstoqueModel model = new HistoricoEstoqueModel();
                                model.HistoricoId = int.Parse(reader["HistoricoId"].ToString());
                                model.EstoqueId = int.Parse(reader["EstoqueId"].ToString());
                                model.ProdutoId = int.Parse(reader["ProdutoId"].ToString());
                                model.TypeRegister = reader["TypeRegister"].ToString();
                                model.Quantidade = int.Parse(reader["Quantidade"].ToString());
                                model.ValorCompra = float.Parse(reader["ValorCompra"].ToString());
                                model.ValorSaida = float.Parse(reader["ValorSaida"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (DataAccessException e)
                {
                    e.DataAccessStatusInfo.CustomMessage = "Não foi possível carregar a lista de Históricos de Estoque";
                    e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                    e.DataAccessStatusInfo.StackTrace = e.StackTrace;
                    throw e;
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public IEnumerable<IHistoricoEstoqueModel> GetAllByEstoqueId(int estoqueId)
        {
            List<HistoricoEstoqueModel> modelList = new List<HistoricoEstoqueModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query =
                "SELECT * FROM HistoricoEstoque " +
                " WHERE EstoqueId = @EstoqueId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@EstoqueId", estoqueId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                HistoricoEstoqueModel model = new HistoricoEstoqueModel();
                                model.HistoricoId = int.Parse(reader["HistoricoId"].ToString());
                                model.EstoqueId = int.Parse(reader["EstoqueId"].ToString());
                                model.ProdutoId = int.Parse(reader["ProdutoId"].ToString());
                                model.TypeRegister = reader["TypeRegister"].ToString();
                                model.Quantidade = int.Parse(reader["Quantidade"].ToString());
                                model.ValorCompra = float.Parse(reader["ValorCompra"].ToString());
                                model.ValorSaida = float.Parse(reader["ValorSaida"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (DataAccessException e)
                {
                    e.DataAccessStatusInfo.CustomMessage = "Não foi possível carregar a lista de Históricos de Estoque";
                    e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                    e.DataAccessStatusInfo.StackTrace = e.StackTrace;
                    throw e;
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public IEnumerable<IHistoricoEstoqueModel> GetAllByProduto(ProdutoModel produtoModel)
        {
            List<HistoricoEstoqueModel> modelList = new List<HistoricoEstoqueModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query =
                "SELECT * FROM HistoricoEstoque " +
                "WHERE ProdutoId = @ProdutoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            cmd.Prepare();
                            cmd.Parameters.AddWithValue("@ProdutoId", produtoModel.ProdutoId);

                            while (reader.Read())
                            {
                                HistoricoEstoqueModel model = new HistoricoEstoqueModel();
                                model.HistoricoId = int.Parse(reader["HistoricoId"].ToString());
                                model.EstoqueId = int.Parse(reader["EstoqueId"].ToString());
                                model.ProdutoId = int.Parse(reader["ProdutoId"].ToString());
                                model.TypeRegister = reader["TypeRegister"].ToString();
                                model.Quantidade = int.Parse(reader["Quantidade"].ToString());
                                model.ValorCompra = float.Parse(reader["ValorCompra"].ToString());
                                model.ValorSaida = float.Parse(reader["ValorSaida"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (DataAccessException e)
                {
                    e.DataAccessStatusInfo.CustomMessage = "Não foi possível carregar a lista de Históricos de Estoque";
                    e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                    e.DataAccessStatusInfo.StackTrace = e.StackTrace;
                    throw e;
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }
    }
}
