using CommonComponents;

using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Produtos;

using ServiceLayer.Services.ProdutoServices;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Produto
{
    public class TipoProdutoRepository : ITipoProdutoRepository
    {
        private string _connectionString;

        enum TypeOfExistenceCheck
        {
            ExisteInDb,
            NotExistInDb,
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

        public TipoProdutoRepository()
        {

        }

        public TipoProdutoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TipoProdutoModel Add(ITipoProdutoModel tipoProduto)
        {
            int idReturned = 0;
            TipoProdutoModel model = new TipoProdutoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "INSERT INTO TiposProdutos " +
                           "(Descricao) " +
                           "OUTPUT INSERTED.TipoProdutoId " +
                           "VALUES (@Descricao, @CatalogoId)";


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Descricao", tipoProduto.Descricao);
                        cmd.Parameters.AddWithValue("@CatalogoId", tipoProduto.CatalogoId);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registar um novo Tipo de Produto",
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

        public void Delete(ITipoProdutoModel tipoProduto)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "DELETE FROM TiposProdutos WHERE TipoProdutoId = @TipoProdutoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@TipoProdutoId", tipoProduto.TipoProdutoId);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível apagar o registro de Tipo de Produto", 
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<TipoProdutoModel> GetAll()
        {
            List<TipoProdutoModel> modelList = new List<TipoProdutoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM TiposProdutos";

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
                                TipoProdutoModel model = new TipoProdutoModel();
                                model.TipoProdutoId = int.Parse(reader["TipoProdutoId"].ToString());
                                model.Descricao = reader["Descricao"].ToString();
                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Não foi possível recuperar a lista de Tipos de Produtos do DataBase", 
                        helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                return modelList;
            }
        }

        public TipoProdutoModel GetById(int tipoProdutoId)
        {
            TipoProdutoModel model = new TipoProdutoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT TipoProdutoId, Descricao FROM TiposProdutos WHERE TipoProdutoId = @TipoProdutoId";
            bool recordFound = false;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@TipoProdutoId", tipoProdutoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            recordFound = reader.HasRows;

                            while (reader.Read())
                            {
                                model.TipoProdutoId = int.Parse(reader["TipoProdutoId"].ToString());
                                model.Descricao = reader["Descricao"].ToString();
                            }
                        }

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: $"Não foi possível recuperar o Tipo de Produto do id {tipoProdutoId}", helpLink: e.HelpLink,
                        errorCode: e.ErrorCode, stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                if (!recordFound)
                {
                    dataAccessStatus.setValues("Error", false, "", $"Registro não encontrado. Não foi possível recuperar o Tipo de Produto pelo Id {tipoProdutoId}",
                        "", 0, "");
                    throw new DataAccessException(dataAccessStatus);
                }

                return model;
            }
        }

        public IEnumerable<TipoProdutoModel> GetByCatalogo(ICatalogoModel catalogo)
        {
            List<TipoProdutoModel> modelList = new List<TipoProdutoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool recordFound = false;

            string query = "SELECT TipoProdutoId, Descricao, CatalogoId FROM TiposProdutos WHERE CatalogoId = @CatalogoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@CatalogoId", catalogo.CatalogoId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            recordFound = reader.HasRows;
                            while (reader.Read())
                            {
                                TipoProdutoModel model = new TipoProdutoModel();
                                model.TipoProdutoId = int.Parse(reader["TipoProdutoId"].ToString());
                                model.Descricao = reader["Descricao"].ToString();
                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: $"Não foi possível recuperar lista de Tipos de Produtos por Catalogo", helpLink: e.HelpLink,
                        errorCode: e.ErrorCode, stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                if (!recordFound)
                {
                    dataAccessStatus.setValues("Error", false, "", "Registro não encontrado. Não foi possível recuperar o Tipo de Produto no DataBase",
                        "", 0, "");
                    throw new DataAccessException(dataAccessStatus);
                }

                return modelList;
            }
        }
        public TipoProdutoModel GetByDescricao(string descricao)
        {
            TipoProdutoModel model = new TipoProdutoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool recordFound = false;

            string query = "SELECT TipoProdutoId, Descricao, CatalogoId FROM TiposProdutos WHERE Descricao = @Descricao";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Descricao", descricao));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            recordFound = reader.HasRows;
                            while (reader.Read())
                            {
                                model.TipoProdutoId = int.Parse(reader["TipoProdutoId"].ToString());
                                model.Descricao = reader["Descricao"].ToString();
                                model.CatalogoId = int.Parse(reader["CatalogId"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: $"Não foi possível recuperar o Tipo de Produto pela Descrição {descricao}.", helpLink: e.HelpLink,
                        errorCode: e.ErrorCode, stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                if (!recordFound)
                {
                    dataAccessStatus.setValues("Error", false, "", "Registro não encontrado. Não foi possível recuperar o Tipo de Produto no DataBase",
                        "", 0, "");
                    throw new DataAccessException(dataAccessStatus);
                }

                return model;
            }
        }

        public void Update(ITipoProdutoModel tipoProduto)
        {
            TipoProdutoModel model = tipoProduto as TipoProdutoModel;

            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE TiposProdutos SET " +
                           "Descricao = @Descricao, CatalogoId = @CatalogoId " +
                           "WHERE TipoProdutoId = @TipoProdutoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@TipoProdutoId", model.TipoProdutoId);
                        cmd.Parameters.AddWithValue("@Descricao", model.Descricao);
                        cmd.Parameters.AddWithValue("@CatalogoId", model.CatalogoId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível atualizar os dados do Tipo de Produto selecionado",
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
