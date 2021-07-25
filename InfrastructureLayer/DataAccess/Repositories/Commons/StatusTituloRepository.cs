using CommonComponents;

using DomainLayer.Models.CommonModels.Enums;

using ServiceLayer.CommonServices;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfrastructureLayer.DataAccess.Repositories.Commons
{
    public class StatusTituloRepository : IStatusTitulosRepository
    {
        private string _connectionString;

        public StatusTituloRepository()
        {

        }

        public StatusTituloRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<IStatusTitulosModel> GetAll()
        {
            List<StatusTitulosModel> modelList = new List<StatusTitulosModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM StatusTitulos";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StatusTitulosModel model = new StatusTitulosModel();

                                model.StatusId = int.Parse(reader["StatusId"].ToString());
                                model.Descricao = reader["Descricao"].ToString();

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Status de Peididos", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

            return modelList;
        }

        public StatusTitulosModel GetById(int statusId)
        {
            StatusTitulosModel model = new StatusTitulosModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM StatusTitulos WHERE StatusId = @StatusId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@StatusId", statusId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.StatusId = int.Parse(reader["StatusId"].ToString());
                                model.Descricao = reader["Descricao"].ToString();

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar Status pelo Id", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

            return model;
        }

        public StatusTitulosModel GetByStatus(string status)
        {
            StatusTitulosModel model = new StatusTitulosModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM StatusTitulos WHERE Descricao = @Descricao";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Descricao", status));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.StatusId = int.Parse(reader["StatusId"].ToString());
                                model.Descricao = reader["Descricao"].ToString();

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar Status pela Descricao.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

            return model;
        }

        public StatusTitulosModel GetByStatusEnum(StatusTitulosModel.StatusTitulo status)
        {
            StatusTitulosModel model = new StatusTitulosModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM StatusTitulos WHERE Descricao = @Descricao";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        //TODO: VER COMO VAI SER UTILIZANDO O ENUM DO MODEL
                        //QUERO O VALOR DADO PARA O ENUM E NÃO O INT DELE
                        cmd.Parameters.Add(new SqlParameter("@Descricao", status.ToString()));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.StatusId = int.Parse(reader["StatusId"].ToString());
                                model.Descricao = reader["Descricao"].ToString();

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar Status pela Descricao.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

            return model;
        }
    }
}
