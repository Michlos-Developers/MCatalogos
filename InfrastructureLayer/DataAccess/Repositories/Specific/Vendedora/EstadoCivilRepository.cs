using CommonComponents;

using DomainLayer.Models.Vendedora;

using ServiceLayer.Services.EstadoCivilServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora
{
    public class EstadoCivilRepository : IEstadoCivilRepository
    {
        private string _connectionString;

        enum TypeOfExistenceCheck
        {
            DoesExistInDb,
            DoesNotExistInDb
        }

        enum RequestType
        {
            Read
        }

        public EstadoCivilRepository()
        {

        }

        public EstadoCivilRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<IEstadoCivilModel> GetAll()
        {
            List<EstadoCivilModel> estadoCivilModelsList = new List<EstadoCivilModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT * FROM EstadosCivis";
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EstadoCivilModel estadoCivilModel = new EstadoCivilModel();

                                estadoCivilModel.EstadoCivilId = int.Parse(reader["EstadoCivilId"].ToString());
                                estadoCivilModel.EstadoCivil = reader["EstadoCivil"].ToString();

                                estadoCivilModelsList.Add(estadoCivilModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Unable to get EstadoCivil Model List from Database", helpLink: e.HelpLink, errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                return estadoCivilModelsList;
            }
        }

        public EstadoCivilModel GetByEstadoCivil(string estadoCivil)
        {
            EstadoCivilModel estadoCivilModel = new EstadoCivilModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool MatchingRecordFound = false;
            string query = " SELECT EstadoCivilId, EstadoCivil " +
                           " FROM EstadosCivis " +
                           " WHERE EstadoCivil = @EstadoCivil";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        //cmd.CommandText = query;
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@EstadoCivil", estadoCivil));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            MatchingRecordFound = reader.HasRows;

                            while (reader.Read())
                            {
                                estadoCivilModel.EstadoCivilId = int.Parse(reader["EstadoCivilId"].ToString());
                                estadoCivilModel.EstadoCivil = reader["EstadoCivil"].ToString();
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
                        customMessage: $"Record not found. Unable to get EstadoCivil for EstadoCivil{estadoCivil}." +
                        $"{estadoCivil} does not exist in database.", helpLink: "", errorCode: 0, stackTrace: "");
                    throw new DataAccessException(dataAccessStatus);
                }

                return estadoCivilModel;
            }
        }

        public EstadoCivilModel GetById(int estadoCivilId)
        {
            EstadoCivilModel estadoCivilModel = new EstadoCivilModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool MatchingRecordFound = false;
            string query = " SELECT EstadoCivilId, EstadoCivil " +
                " FROM EstadosCivis " +
                " WHERE EstadoCivilId = @EstadoCivilId ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@EstadoCivilId", estadoCivilId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            MatchingRecordFound = reader.HasRows;

                            while (reader.Read())
                            {
                                estadoCivilModel.EstadoCivilId = int.Parse(reader["EstadoCivilId"].ToString());
                                estadoCivilModel.EstadoCivil = reader["EstadoCivil"].ToString();
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
                        customMessage: $"Record not found. Unable to get EstadoCivil for EstadoCivilId {estadoCivilId}." +
                        $"{estadoCivilId} does not exist in database.", helpLink: "", errorCode: 0, stackTrace: "");
                    throw new DataAccessException(dataAccessStatus);
                }

                return estadoCivilModel;
            }
        }
    }
}
