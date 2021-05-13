using CommonComponents;

using DomainLayer.Models.CommonModels.Address;

using ServiceLayer.Services.CidadeServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.Commons
{
    public class CidadeRepository : ICidadeRepository
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

        public CidadeRepository()
        {

        }

        public CidadeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ICidadeModel> GetAll()
        {
            List<CidadeModel> cidadeModelsList = new List<CidadeModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT * FROM Cidades";
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CidadeModel cidadeModel = new CidadeModel();

                                cidadeModel.CidadeId = int.Parse(reader["CidadeId"].ToString());
                                cidadeModel.Nome = reader["Nome"].ToString();
                                cidadeModel.Uf = reader["Uf"].ToString();
                                cidadeModel.CodIbge = reader["CodIbge"].ToString();
                                cidadeModel.EstadoId = int.Parse(reader["EstadoId"].ToString());

                                cidadeModelsList.Add(cidadeModel);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Unable to get Cidade Model List from Database", helpLink: e.HelpLink, errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                return cidadeModelsList;
            }
        }

        public IEnumerable<ICidadeModel> GetAllByEstadoId(int estadoId)
        {
            List<CidadeModel> cidadeModelList = new List<CidadeModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            //bool MatchingRecordFound = false;
            string query = " SELECT * " +
                           " FROM Cidades " +
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
                            //MatchingRecordFound = reader.HasRows;

                            while (reader.Read())
                            {
                                CidadeModel cidadeModel = new CidadeModel();

                                cidadeModel.CidadeId = int.Parse(reader["CidadeId"].ToString());
                                cidadeModel.Nome = reader["Nome"].ToString();
                                cidadeModel.Uf = reader["Uf"].ToString();
                                cidadeModel.CodIbge = reader["CodIbge"].ToString();
                                cidadeModel.EstadoId = int.Parse(reader["EstadoId"].ToString());

                                cidadeModelList.Add(cidadeModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Unable to get Cidade Model from DataBase", helpLink: e.HelpLink, errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

               

                return cidadeModelList;
            }
        }

        public IEnumerable<ICidadeModel> GetAllByUf(string uf)
        {
            List<CidadeModel> cidadeModelList = new List<CidadeModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool MatchingRecordFound = false;
            string query = " SELECT CidadeId, Nome, Uf, CodIbge, EstadoId " +
                           " FROM Cidades " +
                           " WHERE Uf = @Uf";

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
                                CidadeModel cidadeModel = new CidadeModel();

                                cidadeModel.CidadeId = int.Parse(reader["CidadeId"].ToString());
                                cidadeModel.Nome = reader["Nome"].ToString();
                                cidadeModel.Uf = reader["Uf"].ToString();
                                cidadeModel.CodIbge = reader["CodIbge"].ToString();
                                cidadeModel.EstadoId = int.Parse(reader["EstadoId"].ToString());

                                cidadeModelList.Add(cidadeModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Unable to get Cidade Model from DataBase", helpLink: e.HelpLink, errorCode: e.ErrorCode,
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
                        customMessage: $"Record not found. Unable to get Cidade from Uf {uf}." +
                        $"{uf} does not exist in database.", helpLink: "", errorCode: 0, stackTrace: "");
                    throw new DataAccessException(dataAccessStatus);
                }

                return cidadeModelList;
            }
        }

        public CidadeModel GetById(int cidadeId)
        {
            CidadeModel cidadeModel = new CidadeModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool MatchingRecordFound = false;
            string query = " SELECT CidadeId, Nome, Uf, CodIbge, EstadoId " +
                           " FROM Cidades " +
                           " WHERE CidadeId = @CidadeId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@CidadeId", cidadeId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            MatchingRecordFound = reader.HasRows;

                            while (reader.Read())
                            {
                                cidadeModel.CidadeId = int.Parse(reader["CidadeId"].ToString());
                                cidadeModel.Nome = reader["Nome"].ToString();
                                cidadeModel.Uf = reader["Uf"].ToString();
                                cidadeModel.CodIbge = reader["CodIbge"].ToString();
                                cidadeModel.EstadoId = int.Parse(reader["EstadoId"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Unable to get Cidade Model from DataBase", helpLink: e.HelpLink, errorCode: e.ErrorCode,
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
                        customMessage: $"Record not found. Unable to get Cidade from CidadeId {cidadeId}." +
                        $"{cidadeId} does not exist in database.", helpLink: "", errorCode: 0, stackTrace: "");
                    throw new DataAccessException(dataAccessStatus);
                }

                return cidadeModel;
            }
        }

        public CidadeModel GetByNomeAndEstadoId(string nome, int estadoId)
        {
            CidadeModel cidadeModel = new CidadeModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool MatchingRecordFound = false;
            string query = "SELECT CidadeId, Nome, Uf, CodIbge, EstadoId " +
                " FROM Cidades " +
                " WHERE Nome = @Nome AND EstadoId = @EstadoId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Nome", nome));
                        cmd.Parameters.Add(new SqlParameter("@EstadoId", estadoId.ToString()));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            MatchingRecordFound = reader.HasRows;
                            while (reader.Read())
                            {
                                cidadeModel.CidadeId = int.Parse(reader["CidadeId"].ToString());
                                cidadeModel.Nome = reader["Nome"].ToString();
                                cidadeModel.Uf = reader["Uf"].ToString();
                                cidadeModel.CodIbge = reader["CodIbge"].ToString();
                                cidadeModel.EstadoId = int.Parse(reader["EstadoId"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Unable to get Cidade Model from DataBase", helpLink: e.HelpLink, errorCode: e.ErrorCode,
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
                        customMessage: $"Record not found. Unable to get Cidade from Nome {nome} and EstadoId {estadoId}." +
                        $"{nome} does not exist in database.", helpLink: "", errorCode: 0, stackTrace: "");
                    throw new DataAccessException(dataAccessStatus);
                }

                return cidadeModel;
            }
        }
        public CidadeModel GetByNome(string nome)
        {
            CidadeModel cidadeModel = new CidadeModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool MatchingRecordFound = false;
            string query = " SELECT CidadeId, Nome, Uf, CodIbge, EstadoId " +
                           " FROM Cidades " +
                           " WHERE Nome = @Nome";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Nome", nome));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            MatchingRecordFound = reader.HasRows;

                            while (reader.Read())
                            {
                                cidadeModel.CidadeId = int.Parse(reader["CidadeId"].ToString());
                                cidadeModel.Nome = reader["Nome"].ToString();
                                cidadeModel.Uf = reader["Uf"].ToString();
                                cidadeModel.CodIbge = reader["CodIbge"].ToString();
                                cidadeModel.EstadoId = int.Parse(reader["EstadoId"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Unable to get Cidade Model from DataBase", helpLink: e.HelpLink, errorCode: e.ErrorCode,
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
                        customMessage: $"Record not found. Unable to get Cidade from Nome {nome}." +
                        $"{nome} does not exist in database.", helpLink: "", errorCode: 0, stackTrace: "");
                    throw new DataAccessException(dataAccessStatus);
                }

                return cidadeModel;
            }
        }
    }
}
