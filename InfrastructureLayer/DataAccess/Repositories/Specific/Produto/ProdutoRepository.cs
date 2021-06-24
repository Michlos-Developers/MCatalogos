using CommonComponents;

using DomainLayer.Models.Produtos;

using ServiceLayer.Services.ProdutoServices;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.Emit;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Produto
{
    public class ProdutoRepository : IProdutoRepository
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
            ComfirmDelete
        }

        public ProdutoRepository()
        {

        }

        public ProdutoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ProdutoModel Add(IProdutoModel produto)
        {
            int idReturned = 0;
            ProdutoModel model = new ProdutoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "INSERT INTO Produtos " +
                           "(Referencia, Descricao, ValorCatalogo, ValorCatalogo2, Pagina, MargemVendedora, MargemDistribuidor, Ativo, CatalogoId, " +
                           "CampanhaId, TipoProdutoId, TamanhoId) " +
                           "OUTPUT INSERTED.ProdutoId " +
                           "VALUES " +
                           "(@Referencia, @Descricao, @ValorCatalogo, @ValorCatalogo2, @Pagina, @MargemVendedora, @MargemDistribuidor, @Ativo, " +
                           "@CatalogoId, @CampanhaId, @TamanhoId)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Referencia", produto.Referencia);
                        cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                        cmd.Parameters.AddWithValue("@ValorCatalogo", produto.ValorCatalogo);
                        cmd.Parameters.AddWithValue("@ValorCatalogo2", produto.ValorCatalogo2);
                        cmd.Parameters.AddWithValue("@Pagina", produto.Pagina);
                        cmd.Parameters.AddWithValue("@MargemVendedora", produto.MargemVendedora);
                        cmd.Parameters.AddWithValue("@MargemDistribuidor", produto.MargemDistribuidor);
                        cmd.Parameters.AddWithValue("@Ativo", produto.Ativo);
                        cmd.Parameters.AddWithValue("@CatalogoId", produto.CatalogoId);
                        cmd.Parameters.AddWithValue("@CampanhaId", produto.CampanhaId);
                        cmd.Parameters.AddWithValue("@TamanhoId", produto.TamanhoId);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registar um novo Produto",
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

        public void Delete(IProdutoModel produto)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "DELETE FROM Produtos WHERE ProdutoId = @ProdutoId";


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@ProdutoId", produto.ProdutoId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível apagar o registro do Produto",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<ProdutoModel> GetAll()
        {
            List<ProdutoModel> modelList = new List<ProdutoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT ProdutoId, Referencia, Descricao, ValorCatalogo, ValorCatalogo2, Pagina, MargemVendedora, MargemDistribuidor, " +
                           "Ativo, CatalogoId, CampanhaId, TamanhoId" +
                           "FROM Produtos";

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
                                ProdutoModel model = new ProdutoModel();
                                model.ProdutoId = int.Parse(reader["ProdutoId"].ToString());
                                model.Referencia = reader["Referencia"].ToString();
                                model.Descricao = reader["Descricao"].ToString();
                                model.ValorCatalogo = float.Parse(reader["ValorCatalogo"].ToString());
                                model.ValorCatalogo2 = float.Parse(reader["ValorCatalogo2"].ToString());
                                model.Pagina = int.Parse(reader["Pagina"].ToString());
                                model.MargemVendedora = float.Parse(reader["MargemVendedora"].ToString());
                                model.MargemDistribuidor = float.Parse(reader["MargemDistribuidor"].ToString());
                                model.Ativo = bool.Parse(reader["Ativo"].ToString());
                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());
                                model.CampanhaId = int.Parse(reader["CampanhaId"].ToString());
                                model.TamanhoId = reader["TamanhoId"] != null ? int.Parse(reader["TamanhoId"].ToString()) : 0;

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível carrega a Lista de Produto",
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

        public IEnumerable<ProdutoModel> GetAllByCampanhaId(int campanhaId)
        {
            List<ProdutoModel> modelList = new List<ProdutoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT ProdutoId, Referencia, Descricao, ValorCatalogo, ValorCatalogo2, Pagina, MargemVendedora, MargemDistribuidor, " +
                           "Ativo, CatalogoId, CampanhaId, TamanhoId" +
                           "FROM Produtos " +
                           "WHERE CampanhaId = @CampanhaId";


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@CampanhaId", campanhaId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProdutoModel model = new ProdutoModel();
                                model.ProdutoId = int.Parse(reader["ProdutoId"].ToString());
                                model.Referencia = reader["Referencia"].ToString();
                                model.Descricao = reader["Descricao"].ToString();
                                model.ValorCatalogo = float.Parse(reader["ValorCatalogo"].ToString());
                                model.ValorCatalogo2 = float.Parse(reader["ValorCatalogo2"].ToString());
                                model.Pagina = int.Parse(reader["Pagina"].ToString());
                                model.MargemVendedora = float.Parse(reader["MargemVendedora"].ToString());
                                model.MargemDistribuidor = float.Parse(reader["MargemDistribuidor"].ToString());
                                model.Ativo = bool.Parse(reader["Ativo"].ToString());
                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());
                                model.CampanhaId = int.Parse(reader["CampanhaId"].ToString());
                                model.TamanhoId = reader["TamanhoId"] != null ? int.Parse(reader["TamanhoId"].ToString()) : 0;

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a Lista de Produto por Campanha",
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

        
        public IEnumerable<ProdutoModel> GetAllByCatalogoId(int catalogoId)
        {
            List<ProdutoModel> modelList = new List<ProdutoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT ProdutoId, Referencia, Descricao, ValorCatalogo, ValorCatalogo2, Pagina, MargemVendedora, MargemDistribuidor, " +
                           "Ativo, CatalogoId, CampanhaId, TamanhoId " +
                           "FROM Produtos " +
                           "WHERE CatalogoId = @CatalogoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@CatalogoId", catalogoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProdutoModel model = new ProdutoModel();
                                model.ProdutoId = int.Parse(reader["ProdutoId"].ToString());
                                model.Referencia = reader["Referencia"].ToString();
                                model.Descricao = reader["Descricao"].ToString();
                                model.ValorCatalogo = float.Parse(reader["ValorCatalogo"].ToString());
                                model.ValorCatalogo2 = float.Parse(reader["ValorCatalogo2"].ToString());
                                model.Pagina = int.Parse(reader["Pagina"].ToString());
                                model.MargemVendedora = float.Parse(reader["MargemVendedora"].ToString());
                                model.MargemDistribuidor = float.Parse(reader["MargemDistribuidor"].ToString());
                                model.Ativo = bool.Parse(reader["Ativo"].ToString());
                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());
                                model.CampanhaId = int.Parse(reader["CampanhaId"].ToString());
                                model.TamanhoId = reader["TamanhoId"] != null ? int.Parse(reader["TamanhoId"].ToString()) : 0;

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a Lista de Produto por Catalogo",
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

        public ProdutoModel GetByCampanhaIdAndReference(int CampanhaId, string Reference)
        {
            ProdutoModel model = new ProdutoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT ProdutoId, Referencia, Descricao, ValorCatalogo, ValorCatalogo2, Pagina, MargemVendedora, MargemDistribuidor, " + "Ativo, CatalogoId, CampanhaId, TamanhoId, " +
                           "FROM Produtos " +
                           "WHERE CampanhaId = @CampanhaId AND Referencia = @Referencia";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@CampanhaId", CampanhaId));
                        cmd.Parameters.Add(new SqlParameter("@Referencia", Reference));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.ProdutoId = int.Parse(reader["ProdutoId"].ToString());
                                model.Referencia = reader["Referencia"].ToString();
                                model.Descricao = reader["Descricao"].ToString();
                                model.ValorCatalogo = float.Parse(reader["ValorCatalogo"].ToString());
                                model.ValorCatalogo2 = float.Parse(reader["ValorCatalogo2"].ToString());
                                model.Pagina = int.Parse(reader["Pagina"].ToString());
                                model.MargemVendedora = float.Parse(reader["MargemVendedora"].ToString());
                                model.MargemDistribuidor = float.Parse(reader["MargemDistribuidor"].ToString());
                                model.Ativo = bool.Parse(reader["Ativo"].ToString());
                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());
                                model.CampanhaId = int.Parse(reader["CampanhaId"].ToString());
                                model.TamanhoId = reader["TamanhoId"] != null ? int.Parse(reader["TamanhoId"].ToString()) : 0;

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Produto pela Referência e pala Campanha",
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

        public ProdutoModel GetByReference(string Reference)
        {
            ProdutoModel model = new ProdutoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT ProdutoId, Referencia, Descricao, ValorCatalogo, ValorCatalogo2, Pagina, MargemVendedora, MargemDistribuidor, " + "Ativo, CatalogoId, CampanhaId, TamanhoId " +
                           "FROM Produtos " +
                           "WHERE Referencia = @Referencia";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Referencia", Reference));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.ProdutoId = int.Parse(reader["ProdutoId"].ToString());
                                model.Referencia = reader["Referencia"].ToString();
                                model.Descricao = reader["Descricao"].ToString();
                                model.ValorCatalogo = float.Parse(reader["ValorCatalogo"].ToString());
                                model.ValorCatalogo2 = float.Parse(reader["ValorCatalogo2"].ToString());
                                model.Pagina = int.Parse(reader["Pagina"].ToString());
                                model.MargemVendedora = float.Parse(reader["MargemVendedora"].ToString());
                                model.MargemDistribuidor = float.Parse(reader["MargemDistribuidor"].ToString());
                                model.Ativo = bool.Parse(reader["Ativo"].ToString());
                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());
                                model.CampanhaId = int.Parse(reader["CampanhaId"].ToString());
                                model.TamanhoId = reader["TamanhoId"] != null ? int.Parse(reader["TamanhoId"].ToString()) : 0;

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Produto pela Referência",
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

        public void Update(IProdutoModel produto)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE Produtos SET " +
                           "(Referencia = @Referencia, Descricao = @Descricao, ValorCatalogo = @ValorCatalogo, ValorCatalogo2 = @ValorCatalogo2, Pagina = @Pagina, " +
                           "MargemVendedora = @MargemVendedora, MargemDistribuidor = @MargemDistribuidor, Ativo = @Ativo, " +
                           "CatalogoId = @CatalogoId, CampanhaId = @CampanhaId, TamanhoId = @TamanhoId) " +
                           "WHERE ProdutoId = @ProdutoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@ProdutoId", produto.ProdutoId);
                        cmd.Parameters.AddWithValue("@Referencia", produto.Referencia);
                        cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                        cmd.Parameters.AddWithValue("@ValorCatalogo", produto.ValorCatalogo);
                        cmd.Parameters.AddWithValue("@ValorCatalogo2", produto.ValorCatalogo2);
                        cmd.Parameters.AddWithValue("@Pagina", produto.Pagina);
                        cmd.Parameters.AddWithValue("@MargemVendedora", produto.MargemVendedora);
                        cmd.Parameters.AddWithValue("@MargemDistribuidor", produto.MargemDistribuidor);
                        cmd.Parameters.AddWithValue("@Ativo", produto.Ativo);
                        cmd.Parameters.AddWithValue("@CatalogoId", produto.CatalogoId);
                        cmd.Parameters.AddWithValue("@CampanhaId", produto.CampanhaId);
                        cmd.Parameters.AddWithValue("@TamanhoId", produto.TamanhoId);

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível apagar o registro do Produto Selecionado",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public ProdutoModel GetById(int ProdutoId)
        {
            ProdutoModel model = new ProdutoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT ProdutoId, Referencia, Descricao, ValorCatalogo, ValorCatalogo2, Pagina, MargemVendedora, MargemDistribuidor, " +
                           "Ativo, CatalogoId, CampanhaId, TamanhoId " +
                           "FROM Produtos " +
                           "WHERE ProdutoId = @ProdutoId";


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@ProdutoId", ProdutoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.ProdutoId = int.Parse(reader["ProdutoId"].ToString());
                                model.Referencia = reader["Referencia"].ToString();
                                model.Descricao = reader["Descricao"].ToString();
                                model.ValorCatalogo = float.Parse(reader["ValorCatalogo"].ToString());
                                model.ValorCatalogo2 = float.Parse(reader["ValorCatalogo2"].ToString());
                                model.Pagina = int.Parse(reader["Pagina"].ToString());
                                model.MargemVendedora = float.Parse(reader["MargemVendedora"].ToString());
                                model.MargemDistribuidor = float.Parse(reader["MargemDistribuidor"].ToString());
                                model.Ativo = bool.Parse(reader["Ativo"].ToString());
                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());
                                model.CampanhaId = int.Parse(reader["CampanhaId"].ToString());
                                model.TamanhoId = reader["TamanhoId"] != null ? int.Parse(reader["TamanhoId"].ToString()) : 0;

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o produto pelo Id",
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
    }
}
