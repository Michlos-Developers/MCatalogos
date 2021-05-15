using CommonComponents;

using DomainLayer.Models.CommonModels.Enums;

using ServiceLayer.Services.TipoTelefoneServices;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfrastructureLayer.DataAccess.Repositories.Commons
{
    public class TipoTelefoneRepository : ITipoTelefoneRepository
    {
        private string _connectionString;
        enum TypeOfExistenceCheck
        {
            ExistInDb,
            NotExistInDb
        }

        enum RequestType
        {
            Read
        }

        public TipoTelefoneRepository()
        {

        }

        public TipoTelefoneRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ITipoTelefoneModel> GetAll()
        {
            List<TipoTelefoneModel> modelList = new List<TipoTelefoneModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM TiposTelefones";

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
                                TipoTelefoneModel model = new TipoTelefoneModel();

                                model.TipoId = int.Parse(reader["TipoId"].ToString());
                                model.TipoTelefone = reader["TipoTelefone"].ToString();

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Falha ao tentar carregar os tipos de telefones",
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

        public TipoTelefoneModel GetById(int tipoTelefoneId)
        {
            TipoTelefoneModel model = new TipoTelefoneModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT TipoId, TipoTelefone FROM TiposTelefones WHERE TipoId = @TipoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@TipoId", tipoTelefoneId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.TipoId = int.Parse(reader["TipoId"].ToString());
                                model.TipoTelefone = reader["TipoTelefone"].ToString();
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Falha ao tentar carregar o teipo de telfone por Id", e.HelpLink,
                        e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                return model;
            }
        }

        public TipoTelefoneModel GetByTipo(string tipoTelefone)
        {
            TipoTelefoneModel model = new TipoTelefoneModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT TipoId, TipoTelefone FROM TiposTelefones WHERE TipoTelefone = @TipoTelefone";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@TipoTelefone", tipoTelefone));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.TipoId = int.Parse(reader["TipoId"].ToString());
                                model.TipoTelefone = reader["TipoTelefone"].ToString();
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Falha ao tentar carregar tipo de tefone pelo Tipo",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                    throw;
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
