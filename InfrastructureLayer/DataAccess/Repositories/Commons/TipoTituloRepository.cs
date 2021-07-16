using CommonComponents;

using DomainLayer.Models.CommonModels.Enums;

using ServiceLayer.Services.TipoTituloServices;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfrastructureLayer.DataAccess.Repositories.Commons
{
    public class TipoTituloRepository : ITipoTituloRepository
    {
        private string _connectionString;

        public TipoTituloRepository()
        {

        }

        public TipoTituloRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ITipoTituloModel> GetAll()
        {
            List<TipoTituloModel> modelList = new List<TipoTituloModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM TiposTitulos";

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
                                TipoTituloModel model = new TipoTituloModel();
                                model.TipoId = int.Parse(reader["TipoId"].ToString());
                                model.TipoTitulo = reader["TipoTitulo"].ToString();

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível carragar a lista de Tipos de Títulos",
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

        public TipoTituloModel GetById(int tipoTituloId)
        {
            TipoTituloModel model = new TipoTituloModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM TiposTitulos WHERE TipoId = @TipoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@TipoId", tipoTituloId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.TipoId = int.Parse(reader["TipoId"].ToString());
                                model.TipoTitulo = reader["TipoTitulo"].ToString();

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Tipo do Título",
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

        public TipoTituloModel GetByTipo(string tipoTitulo)
        {
            TipoTituloModel model = new TipoTituloModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM TiposTitulos WHERE TipoTitulo = @TipoTitulo";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@TipoTitulo", tipoTitulo));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.TipoId = int.Parse(reader["TipoId"].ToString());
                                model.TipoTitulo = reader["TipoTitulo"].ToString();

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Tipo do Título",
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
