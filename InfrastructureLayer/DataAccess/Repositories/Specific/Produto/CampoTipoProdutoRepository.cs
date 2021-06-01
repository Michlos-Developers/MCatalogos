using CommonComponents;

using DomainLayer.Models.Produtos;

using ServiceLayer.Services.ProdutoServices;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Produto
{
    public class CampoTipoProdutoRepository : ICampoTipoProdutoRepository
    {
        private string _connectionString;
        enum TypoOfExistenceCheck
        {
            ExistInDb,
            NotExistInDb,
        }

        enum RequestType
        {
            Add,
            Update,
            Read,
            Delete,
            ConformAdd,
            ConfirmDelete
        }

        public CampoTipoProdutoRepository()
        {

        }

        public CampoTipoProdutoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CampoTipoProdutoModel Add(ICampoTipoProdutoModel campo)
        {
            int idReturned = 0;
            CampoTipoProdutoModel model = new CampoTipoProdutoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "INSERT INTO CamposTiposProdutos " +
                           "(Nome, FormatoId, TipoProdutoId) " +
                           "OUTPU INSERTED.CampoTipoId " +
                           "VALUES (@Nome, @FromatoId, @TipoProdutoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Nome", campo.Nome);
                        cmd.Parameters.AddWithValue("@FormatoId", campo.FormatoId);
                        cmd.Parameters.AddWithValue("@TipoProdutoId", campo.TipoProdutoId);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registar um novo Campo para o Tipo de Produto.",
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

        public void Delete(ICampoTipoProdutoModel campo)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "DELETE FROM CamposTiposProdutos WHERE CampoTipoId = @CampoTipoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@CampoTipoId", campo.CampoTipoId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível apagar o registro de Campo do Tipo de Produto",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<CampoTipoProdutoModel> GetAll()
        {
            List<CampoTipoProdutoModel> modelList = new List<CampoTipoProdutoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM CamposTiposProdutos";

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
                                CampoTipoProdutoModel model = new CampoTipoProdutoModel();
                                model.CampoTipoId = int.Parse(reader["CampoTipoId"].ToString());
                                model.Nome = reader["Nome"].ToString();
                                model.FormatoId = int.Parse(reader["FormatoId"].ToString());
                                model.TipoProdutoId = int.Parse(reader["TipoProdutoId"].ToString());

                                modelList.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Campos do Tipo de Produto",
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

        public IEnumerable<CampoTipoProdutoModel> GetAllByFormatoId(int formatoCampoId)
        {
            List<CampoTipoProdutoModel> modelList = new List<CampoTipoProdutoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT CampoTipoId, Nome, FormatoId, TipoProdutoId FROM CamposTiposProdutos WHER FormatoId = @FormatoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@FormatoId", formatoCampoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CampoTipoProdutoModel model = new CampoTipoProdutoModel();
                                model.CampoTipoId = int.Parse(reader["CampoTipoId"].ToString());
                                model.Nome = reader["Nome"].ToString();
                                model.FormatoId = int.Parse(reader["FormatoId"].ToString());
                                model.TipoProdutoId = int.Parse(reader["TipoProdutoId"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recupera a lista de Campos pelo Formato indicado",
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

        public IEnumerable<CampoTipoProdutoModel> GetAllByTipoProdutoId(int tipoProdutoId)
        {
            List<CampoTipoProdutoModel> modelList = new List<CampoTipoProdutoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT CampoTipoId, Nome, FormatoId, TipoProdutoId FROM CamposTiposProdutos WHERE TipoProdutoId = @TipoProdutoId";

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
                            while (reader.Read())
                            {
                                CampoTipoProdutoModel model = new CampoTipoProdutoModel();
                                model.CampoTipoId = int.Parse(reader["CampoTipoId"].ToString());
                                model.Nome = reader["Nome"].ToString();
                                model.FormatoId = int.Parse(reader["FormatoId"].ToString());
                                model.TipoProdutoId = int.Parse(reader["TipoProdutoId"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a Lista de Campos pelo tipo de produto",
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

        public CampoTipoProdutoModel GetById(int campoTipoId)
        {
            CampoTipoProdutoModel model = new CampoTipoProdutoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT CampoTipoId, Nome, FormatoId, TipoProdutoId WHERE CampoTipoId = @CampoTipoId";

            bool recordFound = false;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@CampoTipoId", campoTipoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            recordFound = reader.HasRows;

                            while (reader.Read())
                            {
                                model.CampoTipoId = int.Parse(reader["CampoTipoId"].ToString());
                                model.Nome = reader["Nome"].ToString();
                                model.FormatoId = int.Parse(reader["FormatoId"].ToString());
                                model.TipoProdutoId = int.Parse(reader["TipoProdutoId"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, $"Não foi possível recuperar o Campo pelo Id {campoTipoId}.",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                if (!recordFound)
                {
                    dataAccessStatus.setValues("Error", false, "", "Registro não encontrado. Não foi possível recuperar o Campo do tipo pelo Id.",
                        "", 0, "");
                    throw new DataAccessException(dataAccessStatus);
                }

                return model;
            }

        }

        public CampoTipoProdutoModel GetByName(string campoName)
        {
            CampoTipoProdutoModel model = new CampoTipoProdutoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT CampoTipoId, Nome, FormatoId, TipoProdutoId WHERE Nome = @Nome ";
            bool recordFound = false;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Nome", campoName));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            recordFound = reader.HasRows;
                            while (reader.Read())
                            {
                                model.CampoTipoId = int.Parse(reader["CampoTipoId"].ToString());
                                model.Nome = reader["Nome"].ToString();
                                model.FormatoId = int.Parse(reader["FormatoId"].ToString());
                                model.TipoProdutoId = int.Parse(reader["TipoProdutoId"].ToString());
                            }

                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, $"Não foi possível recuperar o Campo pelo Nome {campoName}.",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                if (!recordFound)
                {
                    dataAccessStatus.setValues("Error", false, "", "Registro não encontrado. Não foi possível recuperar o Campo do pelo nome.",
                        "", 0, "");
                    throw new DataAccessException(dataAccessStatus);
                }

                return model;
            }
        }

        public CampoTipoProdutoModel GetByNameAndFormatoId(string campoName, int formatoId)
        {
            CampoTipoProdutoModel model = new CampoTipoProdutoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT CampoTipoId, Nome, FormatoId, TipoProdutoId WHERE Nome = @Nome AND FormatoId = @FormatoId";
            bool recordFound = false;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Nome", campoName));
                        cmd.Parameters.Add(new SqlParameter("@FormatoId", formatoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            recordFound = reader.HasRows;
                            while (reader.Read())
                            {
                                model.CampoTipoId = int.Parse(reader["CampoTipoId"].ToString());
                                model.Nome = reader["Nome"].ToString();
                                model.FormatoId = int.Parse(reader["FormatoId"].ToString());
                                model.TipoProdutoId = int.Parse(reader["TipoProdutoId"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, $"Não foi possível recuperar o Campo pelo Nome {campoName} e ID do Formato {formatoId}.",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                if (!recordFound)
                {
                    dataAccessStatus.setValues("Error", false, "", "Registro não encontrado. Não foi possível recuperar o Campo do pelo nome e Id do Formato.",
                        "", 0, "");
                    throw new DataAccessException(dataAccessStatus);
                }

                return model;
            }
        }

        public CampoTipoProdutoModel GetByNameAndTipoProdutoId(string campoName, int tipoProdutoId)
        {
            CampoTipoProdutoModel model = new CampoTipoProdutoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT CampoTipoId, Nome, FormatoId, TipoProdutoId WHERE Nome = @Nome AND TipoProdutoId = @TipoProdutoId";
            bool recordFound = false;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Nome", campoName));
                        cmd.Parameters.Add(new SqlParameter("@TipoProdutoId", tipoProdutoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            recordFound = reader.HasRows;
                            while (reader.Read())
                            {
                                model.CampoTipoId = int.Parse(reader["CampoTipoId"].ToString());
                                model.Nome = reader["Nome"].ToString();
                                model.FormatoId = int.Parse(reader["FormatoId"].ToString());
                                model.TipoProdutoId = int.Parse(reader["TipoProdutoId"].ToString());
                            }
                        }

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, $"Não foi possível recuperar o Campo pelo Nome {campoName} e ID do Tipo de Produto {tipoProdutoId}.",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                if (!recordFound)
                {
                    dataAccessStatus.setValues("Error", false, "", "Registro não encontrado. Não foi possível recuperar o Campo do pelo nome e Id do Tipo de Produto.",
                        "", 0, "");
                    throw new DataAccessException(dataAccessStatus);
                }

                return model;
            }
        }

        public void Update(ICampoTipoProdutoModel campo)
        {
            CampoTipoProdutoModel model = campo as CampoTipoProdutoModel;
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE CamposTiposProdutos SET " +
                           "Nome = @Nome, FormatoId = @FormatoId, TipoProdutoId = @TipoProdutoId " +
                           "WHERE CampoTipoId = @CampoTipoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@CampoTipoId", model.CampoTipoId);
                        cmd.Parameters.AddWithValue("@Nome", model.Nome);
                        cmd.Parameters.AddWithValue("@FormatoId", model.FormatoId);
                        cmd.Parameters.AddWithValue("@TipoProdutoId", model.TipoProdutoId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível atualizar os dados do Campo Selecionado",
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
