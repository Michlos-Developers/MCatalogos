using CommonComponents;

using DomainLayer.Models.Produtos;
using DomainLayer.Models.Tamanho;

using ServiceLayer.Services.TamanhoServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Tamanho
{
    public class TamanhoRepository : ITamanhoRepository
    {
        private string _connectionString;

        enum TypeOfExistenceCheck
        {
            ExistInDb,
            NotExistInDb
        }

        enum RequestType
        {
            Add,
            Update,
            Read,
            Delete,
            ConfirmAdd,
            ConfirmDelete
        }
        public TamanhoRepository()
        {

        }

        public TamanhoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TamanhosModel Add(ITamanhosModel tamanho)
        {
            int idReturned = 0;

            TamanhosModel model = new TamanhosModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "INSERT INTO Tamanhos " +
                           "(Tamanho, FormatoId, ProdutoId) " +
                           "OUTPUT INSERTED.TamanhoId " +
                           "VALUES " +
                           "(@Tamanho, @FormatoId, @ProdutoId)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Tamanho", tamanho.Tamanho);
                        cmd.Parameters.AddWithValue("@FormatoId", tamanho.FormatoId);
                        cmd.Parameters.AddWithValue("@ProdutoId", tamanho.ProdutoId);


                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registar um novo Tamanho de Produto",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                model = GetById(idReturned);
                return model;
            }
        }

        public void Delete(ITamanhosModel tamanho)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "DELETE FROM Tamanhos WHERE TamanhoId = @TamanhoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@TamanhoId", tamanho.TamanhoId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível apagar o registro do Tamanho",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<TamanhosModel> GetAll()
        {
            List<TamanhosModel> modelList = new List<TamanhosModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT TamanhoId, Tamanho, FormatoId, ProdutoId FROM Tamanhos";

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
                                TamanhosModel model = new TamanhosModel();

                                model.TamanhoId = int.Parse(reader["TamanhoId"].ToString());
                                model.Tamanho = reader["Tamanho"].ToString();
                                model.FormatoId = int.Parse(reader["FormatoId"].ToString());
                                model.ProdutoId = int.Parse(reader["ProdutoId"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível carrega a Lista de Tamanhos",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public IEnumerable<TamanhosModel> GetByProdutoModel(ProdutoModel produtoModel)
        {
            List<TamanhosModel> modelList = new List<TamanhosModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT TamanhoId, Tamanho, FormatoId, ProdutoId FROM Tamanhos WHERE ProdutoId = @ProdutoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@ProdutoId", produtoModel.ProdutoId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TamanhosModel model = new TamanhosModel();
                                model.TamanhoId = int.Parse(reader["TamanhoId"].ToString());
                                model.Tamanho = reader["Tamanho"].ToString();
                                model.FormatoId = int.Parse(reader["FormatoId"].ToString());
                                model.ProdutoId = int.Parse(reader["ProdutoId"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Tamanho pelo Id",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public TamanhosModel GetById(int tamanhoId)
        {
            TamanhosModel model = new TamanhosModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT TamanhoId, Tamanho, FormatoId, ProdutoId FROM Tamanhos WHERE TamanhoId = @TamanhoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@TamanhoId", tamanhoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.TamanhoId = int.Parse(reader["TamanhoId"].ToString());
                                model.Tamanho = reader["Tamanho"].ToString();
                                model.FormatoId = int.Parse(reader["FormatoId"].ToString());
                                model.ProdutoId = int.Parse(reader["ProdutoId"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Tamanho pelo Id",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return model;
            }
        }

        public void Update(ITamanhosModel tamanho)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE Tamanhos SET " +
                           "Tamanho = @Tamanho, FormatoId = @FormatoId, ProdutoId = @ProdutoId " +
                           "WHERE TamanhoId = @TamanhoId ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@TamanhoId", tamanho.TamanhoId);
                        cmd.Parameters.AddWithValue("@Tamanho", tamanho.Tamanho);
                        cmd.Parameters.AddWithValue("@FormatoId", tamanho.FormatoId);
                        cmd.Parameters.AddWithValue("@ProdutoId", tamanho.ProdutoId);

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível Atualizar o registro do Tamanho Selecionado",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
