using CommonComponents;

using DomainLayer.Models.CommonModels.Address;

using ServiceLayer.Services.EstadosServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.Commons
{
    public class EstadoRepository : IEstadosRepository
    {
        private string _connectionString;
        enum TypeOfExistenceCheck
        {
            DoesExistInDb,
            DoesNotExistInDb,
        }

        enum RequestType
        {
            Read
        }

        public EstadoRepository()
        {

        }

        public EstadoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<IEstadoModel> GetAll()
        {
            List<EstadoModel> estadoModelsList = new List<EstadoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT * FROM Estados ORDER BY Uf";
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EstadoModel estadoModel = new EstadoModel();

                                estadoModel.EstadoId = int.Parse(reader["EstadoId"].ToString());
                                estadoModel.Nome = reader["Nome"].ToString();
                                estadoModel.Uf = reader["Uf"].ToString();
                                estadoModel.CodIbge = reader["CodIbge"].ToString();

                                estadoModelsList.Add(estadoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Unable to get Rota Model List from Database", helpLink: e.HelpLink, errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                return estadoModelsList;
            }
        }

        public EstadoModel GetByUf(string uf)
        {
            EstadoModel estadoModel = new EstadoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool MatchingRecordFound = false;
            string query = " SELECT EstadoId, Nome, Uf, CodIbge " +
                           " FROM Estados " +
                           " WHERE Uf = @Uf ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Uf", uf));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            MatchingRecordFound = reader.HasRows;
                            while (reader.Read())
                            {
                                estadoModel.EstadoId = int.Parse(reader["EstadoId"].ToString());
                                estadoModel.Nome = reader["Nome"].ToString();
                                estadoModel.Uf = reader["Uf"].ToString();
                                estadoModel.CodIbge = reader["CodIbge"].ToString();
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Unable to get Rota Model from DataBase", helpLink: e.HelpLink, errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                if (!MatchingRecordFound)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: "",
                       customMessage: $"Record not found. Unable to get Estado for Uf{uf}." +
                       $"{uf} does not exist in database.", helpLink: "", errorCode: 0, stackTrace: "");
                    throw new DataAccessException(dataAccessStatus);
                }

                return estadoModel;
            }
        }

        public EstadoModel GetById(int estadoId)
        {
            EstadoModel estadoModel = new EstadoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool MatchingRecordFound = false;
            string query = " SELECT EstadoId, Nome, Uf, CodIbge " +
                           " FROM Estados " +
                           " WHERE EstadoId = @EstadoId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@EstadoId", estadoId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            MatchingRecordFound = reader.HasRows;
                            while (reader.Read())
                            {
                                estadoModel.EstadoId = int.Parse(reader["EstadoId"].ToString());
                                estadoModel.Nome = reader["Nome"].ToString();
                                estadoModel.Uf = reader["Uf"].ToString();
                                estadoModel.CodIbge = reader["CodIbge"].ToString();
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Unable to get Rota Model from DataBase", helpLink: e.HelpLink, errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                if (!MatchingRecordFound)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: "",
                       customMessage: $"Record not found. Unable to get Estado for Id{estadoId}." +
                       $"{estadoId} does not exist in database.", helpLink: "", errorCode: 0, stackTrace: "");
                    throw new DataAccessException(dataAccessStatus);
                }

                return estadoModel;
            }
        }
    }
}
