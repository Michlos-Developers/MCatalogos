using CommonComponents;

using DomainLayer.Models.CommonModels.Enums;

using ServiceLayer.CommonServices;

using System;
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

        public IEnumerable<StatusTituloModel> GetAll()
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM StatusTitulos";

            List<StatusTituloModel> ListStatus = new List<StatusTituloModel>();

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
                                StatusTituloModel status = new StatusTituloModel();
                                status.StatusId = int.Parse(reader["StatusId"].ToString());
                                status.Descricao = reader["Descricao"].ToString();
                                status.Status = (StatusTitulo)Enum.Parse(typeof(StatusTitulo), reader["StatusEnum"].ToString());

                                ListStatus.Add(status);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar lista de Status", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return ListStatus;

        }

        public StatusTituloModel GetById(int statusId)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM StatusTitulos WHERE StatusId = @StatusId";

            StatusTituloModel statusModel = new StatusTituloModel();

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
                                statusModel.StatusId = int.Parse(reader["StatusId"].ToString());
                                statusModel.Descricao = reader["Descricao"].ToString();
                                statusModel.Status = (StatusTitulo)Enum.Parse(typeof(StatusTitulo), reader["StatusEnum"].ToString());

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar lista de Status", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return statusModel;
        }

        public StatusTituloModel GetByStatus(string status)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM StatusTitulos WHERE Descricao = @Descricao";

            StatusTituloModel statusModel = new StatusTituloModel();

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
                                statusModel.StatusId = int.Parse(reader["StatusId"].ToString());
                                statusModel.Descricao = reader["Descricao"].ToString();
                                statusModel.Status = (StatusTitulo)Enum.Parse(typeof(StatusTitulo), reader["StatusEnum"].ToString());

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar lista de Status", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return statusModel;
        }

        public StatusTituloModel GetByStatusEnum(StatusTitulo status)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM StatusTitulos WHERE StatusEnum = @StatusEnum";

            StatusTituloModel statusModel = new StatusTituloModel();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@StatusEnum", status));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                statusModel.StatusId = int.Parse(reader["StatusId"].ToString());
                                statusModel.Descricao = reader["Descricao"].ToString();
                                statusModel.Status = (StatusTitulo)Enum.Parse(typeof(StatusTitulo), reader["StatusEnum"].ToString());

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar lista de Status", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return statusModel;
        }
    }
}
