using CommonComponents;

using DomainLayer.Models.Formatos;

using ServiceLayer.Services.FormatoTamanhoServices;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Formato
{
    public class FormatoTamanhoRepository : IFormatoTamanhoRepository
    {
        private string _connectionString;

        public FormatoTamanhoRepository()
        {

        }

        public FormatoTamanhoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public FormatosTamanhosModel Add(IFormatosTamanhosModel formatosTamanhosModel)
        {
            int idReturned = 0;
            FormatosTamanhosModel model = new FormatosTamanhosModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "INSERT INTO FormatosTamanhos FormatoNome, Formato " +
                           "OUTPUT INSERTED.FormatoId " +
                           "VALUES @FormatoNome, @Formato";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@FormatoNome", formatosTamanhosModel.NomeFormato);
                        cmd.Parameters.AddWithValue("@Formato", formatosTamanhosModel.Formato);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registar um novo Formato",
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

        public void Delete(IFormatosTamanhosModel formatosTamanhosModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "DELETE FROM FormatosTamanhos WHERE FormatoId = @FormatoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@FormatoId", formatosTamanhosModel.FormatoId);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível apagar o registro do Formato",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<FormatosTamanhosModel> GetAll()
        {
            List<FormatosTamanhosModel> modelList = new List<FormatosTamanhosModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM FormatosTamanhos";
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
                                FormatosTamanhosModel model = new FormatosTamanhosModel();
                                model.FormatoId = int.Parse(reader["FormatoId"].ToString());
                                model.NomeFormato = reader["FormatoNome"].ToString();
                                model.Formato = reader["Formato"].ToString();
                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível carrega a Lista de Formatos",
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

        public FormatosTamanhosModel GetById(int formatoId)
        {
            FormatosTamanhosModel model = new FormatosTamanhosModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT FormatoId, FormatoNome, Formato FROM FormatosTamanhos WHERE FormatoId = @FormatoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@FormatoId", formatoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.FormatoId = int.Parse(reader["FormatoId"].ToString());
                                model.Formato = reader["Formato"].ToString();
                                model.NomeFormato = reader["FormatoNome"].ToString();
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Formato pelo ID",
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

        public void Update(IFormatosTamanhosModel formatosTamanhosModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE FormatosTamanhos SET (FormatoNome = @FormatoNome, Formato = @Formato) WHERE FormatoId = @FormatoId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@FormatoId", formatosTamanhosModel.FormatoId);
                        cmd.Parameters.AddWithValue("@FormatoNome", formatosTamanhosModel.NomeFormato);
                        cmd.Parameters.AddWithValue("@Formato", formatosTamanhosModel.Formato);
                        cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível Atualizar o Formato selecionado",
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
