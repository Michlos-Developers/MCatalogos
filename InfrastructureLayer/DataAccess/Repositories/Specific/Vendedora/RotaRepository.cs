using CommonComponents;

using DomainLayer.Models.Vendedora;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.RotaServices;

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora
{
    public class RotaRepository : IRotaRepository
    {
        private string _connectionString;
        enum TypeOfExistenceCheck
        {
            DoesExistInDB,
            DoesNotExistInDB
        }

        enum RequestType
        {
            Add,
            Update,
            Read,
            Delete,
            ConfirmAdd,
            ConfirmDelete
        }

        public RotaRepository()
        {

        }
        public RotaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<IRotaModel> GetAll()
        {
            List<RotaModel> rotaModelsList = new List<RotaModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string sql = "SELECT * FROM Rotas";
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RotaModel rotaModel = new RotaModel();

                                rotaModel.RotaId = Int32.Parse(reader["RotaId"].ToString());
                                rotaModel.Letra = reader["Letra"].ToString();
                                rotaModel.Numero = Int32.Parse(reader["Numero"].ToString());

                                rotaModelsList.Add(rotaModel);
                            }
                        }
                        connection.Close();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Unable to get Rota Model List from Database", helpLink: e.HelpLink, errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                return rotaModelsList;

            }
        }
        public RotaModel GetById(int rotaId)
        {
            RotaModel rotaModel = new RotaModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool MatchingRecordFound = false;
            string sql = "SELECT RotaId, Letra, Numero " +
                         " FROM Rotas " +
                         " WHERE RotaId = @RotaId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("RotaId", rotaId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            MatchingRecordFound = reader.HasRows;

                            while (reader.Read())
                            {
                                rotaModel.RotaId = Int32.Parse(reader["RotaId"].ToString());
                                rotaModel.Letra = reader["Letra"].ToString();
                                rotaModel.Numero = Int32.Parse(reader["Numero"].ToString());
                            }
                        }
                        connection.Close();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Unable to get Rota Model from DataBase", helpLink: e.HelpLink, errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }

                if (!MatchingRecordFound)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: "",
                        customMessage: $"Record not found. Unable to get Rota Model for RotaId {rotaId}. Id {rotaId} does not existe in database.",
                        helpLink: "", errorCode: 0, stackTrace: "");
                    throw new DataAccessException(dataAccessStatus);
                }
                return rotaModel;
            }
        }
        public void Add(IRotaModel rotaModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Unable to Add RotaModel. Could not open a database connection", helpLink: e.HelpLink,
                        errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }

                string sql =
                    " INSERT INTO Rotas (Letra, Numero) " +
                    " VALUES (@Letra, @Numero)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    try
                    {
                        RecordExistsCheck(rotaModel, TypeOfExistenceCheck.DoesNotExistInDB, RequestType.Add);
                    }
                    catch (DataAccessException e)
                    {
                        e.DataAccessStatusInfo.CustomMessage = "Rota Model could not be added becouse it is already in te DataBase.";
                        throw e;
                    }

                    //SqlParameter.Prepare(SqlCommand cmd);

                    cmd.Prepare();


                    cmd.Parameters.AddWithValue("@Letra", rotaModel.Letra);
                    cmd.Parameters.AddWithValue("@Numero", rotaModel.Numero);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                            customMessage: "Unable to Execute Add RotaModel", helpLink: e.HelpLink, errorCode: e.ErrorCode,
                            stackTrace: e.StackTrace);

                        throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                    }

                    try //Confirm the RotaModel was added to the database
                    {
                        RecordExistsCheck(rotaModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.ConfirmAdd);
                    }
                    catch (DataAccessException e)
                    {
                        e.DataAccessStatusInfo.Status = "Error";
                        e.DataAccessStatusInfo.OperationSucceeded = false;
                        e.DataAccessStatusInfo.CustomMessage = "Failed to find Rota Model in Database after AddOperation completed.";
                        e.DataAccessStatusInfo.StackTrace = e.StackTrace;
                        throw e;
                    }
                    connection.Close();
                }

            }
        }
        public void Update(IRotaModel rotaModel)
        {
            int result = -1;
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Unsble to update RotaModel. Colud not open the database connection", helpLink: e.HelpLink,
                        errorCode: e.ErrorCode, stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }

                string sql = "UPDATE Rotas SET Letra = @Letra, Numero = @Numero WHERE RotaId = @RotaId";


                try
                {
                    RecordExistsCheck(rotaModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.Update);
                }
                catch (DataAccessException e)
                {
                    e.DataAccessStatusInfo.CustomMessage = "Rota Model could not be updated becouse it is not in the database.";
                    e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                    e.DataAccessStatusInfo.StackTrace = e.StackTrace;

                    throw e;
                }

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    //cmd.CommandText = sql;

                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@RotaId", rotaModel.RotaId);
                    cmd.Parameters.AddWithValue("@Letra", rotaModel.Letra);
                    cmd.Parameters.AddWithValue("@Numero", rotaModel.Numero);

                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                            customMessage: "Unable to Execute Update RotaModel", helpLink: e.HelpLink, errorCode: e.ErrorCode,
                            stackTrace: e.StackTrace);

                        throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                    }
                }
                connection.Close();
            }
        }
        public void Delete(IRotaModel rotaModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Unable to Delete RotaModel. Coold not open the DataBase Connection", helpLink: e.HelpLink,
                        errorCode: e.ErrorCode, stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }

                string sql = "DELETE FROM Rotas WHERE RotaId = @RotaId";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    try
                    {
                        RecordExistsCheck(rotaModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.Delete);
                    }
                    catch (DataAccessException e)
                    {
                        e.DataAccessStatusInfo.CustomMessage = "Rota Model could not be Deleted. RotaModel is not found ind the DataBase.";
                        e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                        e.DataAccessStatusInfo.StackTrace = e.StackTrace;
                        throw e;
                    }

                    //cmd.CommandText = sql;

                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@RotaId", rotaModel.RotaId);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                    customMessage: "Uneble to Execute Delete", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);
                        throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                    }

                    try
                    {
                        RecordExistsCheck(rotaModel, TypeOfExistenceCheck.DoesNotExistInDB, RequestType.ConfirmDelete);
                    }
                    catch (DataAccessException e)
                    {
                        e.DataAccessStatusInfo.Status = "Error";
                        e.DataAccessStatusInfo.OperationSucceeded = false;
                        e.DataAccessStatusInfo.CustomMessage = "Failed to delete RotaModel in database.";
                        e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                        e.DataAccessStatusInfo.StackTrace = e.StackTrace;
                        throw e;
                    }
                    connection.Close();
                }
            }
        }
        private bool RecordExistsCheck(IRotaModel rotaModel, TypeOfExistenceCheck typeOfExistenceCheck,
            RequestType requestType)
        {
            Int32 countOfRecsFound = 0;

            DataAccessStatus dataAccess = new DataAccessStatus();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                try
                {
                    connection.Open();
                }
                catch (SqlException e)
                {
                    dataAccess.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                       customMessage: "Unable to test exist register. Colud not open the database connection", helpLink: e.HelpLink,
                       errorCode: e.ErrorCode, stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccess);
                }

                string sql = "";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    bool RecordExistsCheckPassed = true;

                    DataAccessStatus dataAccessStatus = new DataAccessStatus();

                    cmd.Prepare();

                    if ((requestType == RequestType.Add) || (requestType == RequestType.ConfirmAdd))
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM Rotas WHERE Numero=@Numero AND Letra = @Letra";
                        cmd.Parameters.AddWithValue("@Letra", rotaModel.Letra);
                        cmd.Parameters.AddWithValue("@Numero", rotaModel.Numero);
                    }
                    else if ((requestType == RequestType.Update) || (requestType == RequestType.ConfirmDelete) || (requestType == RequestType.Delete))
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM Rotas WHERE RotaId = @RotaId";
                        cmd.Parameters.AddWithValue("@RotaId", rotaModel.RotaId);
                    }

                    try
                    {
                        countOfRecsFound = int.Parse(cmd.ExecuteScalar().ToString());
                    }
                    catch (SqlException e)
                    {
                        string msg = e.Message;
                        throw;
                    }

                    if ((typeOfExistenceCheck == TypeOfExistenceCheck.DoesNotExistInDB) && (countOfRecsFound > 0))
                    {
                        dataAccessStatus.Status = "Error";
                        RecordExistsCheckPassed = false;
                        throw new DataAccessException(dataAccessStatus);
                    }
                    else if ((typeOfExistenceCheck == TypeOfExistenceCheck.DoesExistInDB) && (countOfRecsFound == 0))
                    {
                        dataAccessStatus.Status = "Error";
                        RecordExistsCheckPassed = false;
                        throw new DataAccessException(dataAccessStatus);
                    }
                    connection.Close();
                    return RecordExistsCheckPassed;
                }
        }




    }
}
}
