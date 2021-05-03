using CommonComponents;

using DomainLayer.Models.CommonModels.Enums;
using DomainLayer.Models.Vendedora;

using ServiceLayer.Services.TelefoneVendedoraServices;

using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora
{
    public class TelefoneVendedoraRepository : ITelefoneVendedoraRepository
    {
        private string _connectionString;
        enum TypeOfExistenceCheck
        {
            DoesExistInDB,
            DoesNotExisInDB
        }
        enum RequestType
        {
            Add,
            Update,
            Read,
            Delete,
            ConfonfirmAdd,
            ConfirmDelete
        }

        public TelefoneVendedoraRepository()
        {
        }

        public TelefoneVendedoraRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<ITelefoneVendedoraModel> GetAll()
        {
            List<TelefoneVendedoraModel> telefoneVendedoraModelList = new List<TelefoneVendedoraModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string sql = "SELECT * FROM TelefonesVendedoras ";

                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TelefoneVendedoraModel telefoneVendedoraModel = new TelefoneVendedoraModel();

                                telefoneVendedoraModel.TelefoneId = Int32.Parse(reader["TelefoneId"].ToString());
                                telefoneVendedoraModel.Numero = reader["Numero"].ToString();
                                telefoneVendedoraModel.TipoTelefoneId = Int32.Parse(reader["TipoTelefoneId"].ToString());
                                telefoneVendedoraModel.VendedoraId = Int32.Parse(reader["VendedoraId"].ToString());
                                telefoneVendedoraModel.Vendedora = new VendedoraModel { VendedoraId = Int32.Parse(reader["VendedoraId"].ToString()) };

                                telefoneVendedoraModelList.Add(telefoneVendedoraModel);
                            }
                        }
                        connection.Close();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unable to get TelefoneVendedora Model list from database", helpLink: e.HelpLink,
                                   errorCode: e.ErrorCode, stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                return telefoneVendedoraModelList;
            }

        }

        public IEnumerable<ITelefoneVendedoraModel> GetByVendedoraId(int vendedoraId)
        {
            List<TelefoneVendedoraModel> telefoneModelList = new List<TelefoneVendedoraModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool MatchingRecordFound = false;
            string sql = " SELECT * FROM TelefonesVendedoras " +
                          " WHERE VendedoraId = @VendedoraId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.CommandText = sql;
                            cmd.Prepare();
                            cmd.Parameters.Add(new SqlParameter("@VendedoraId", vendedoraId));
                            try
                            {
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    MatchingRecordFound = reader.HasRows;
                                    while (reader.Read())
                                    {
                                        TelefoneVendedoraModel telefoneModel = new TelefoneVendedoraModel();

                                        telefoneModel.TelefoneId = Int32.Parse(reader["TelefoneId"].ToString());
                                        telefoneModel.Numero = reader["Numero"].ToString();
                                        telefoneModel.TipoTelefoneId = Int32.Parse(reader["TipoTelefoneId"].ToString());
                                        telefoneModel.VendedoraId = Int32.Parse(reader["VendedoraId"].ToString());

                                        telefoneModelList.Add(telefoneModel);
                                    }
                                }
                                connection.Close();
                            }
                            catch (SqlException e)
                            {

                                dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unable to Read TelefoneVendedoraModel in DataBase", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                                throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                            }
                        }
                    }
                    catch (SqlException e)
                    {

                        dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unable to Execute Command in DataBase", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                        throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unable to open Connection with DataBase", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
            }
            return telefoneModelList;
        }

        public TelefoneVendedoraModel GetById(int telefoneId)
        {
            TelefoneVendedoraModel telefoneVendedoraModel = new TelefoneVendedoraModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            bool MatchingRecordFound = false;
            string sql = "SELECT TelefoneId, Numero, TipoTelefoneId, VendedoraId " +
                         " FROM TelefonesVendedoras " +
                         //" INNER JOIN TiposTelefones ON TelefonesVendedoras.TipoTelefoneId = TiposTelefones.TipoId " +
                         //" INNER JOIN Vendedoras ON TelefonesVendedoras.VendedoraId = Vendedoras.VendedoraId " +
                         " WHERE TelefonesVendedoras.TelefoneId = @TelefoneId ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.CommandText = sql;
                            cmd.Prepare();
                            cmd.Parameters.Add(new SqlParameter("@TelefoneId", telefoneId));

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                MatchingRecordFound = reader.HasRows;

                                while (reader.Read())
                                {
                                    telefoneVendedoraModel.TelefoneId = Int32.Parse(reader["TelefoneId"].ToString());
                                    telefoneVendedoraModel.Numero = reader["Numero"].ToString();
                                    telefoneVendedoraModel.TipoTelefoneId = Int32.Parse(reader["TipoTelefoneId"].ToString());
                                    telefoneVendedoraModel.VendedoraId = Int32.Parse(reader["VendedoraId"].ToString());
                                    telefoneVendedoraModel.Vendedora = new VendedoraModel { VendedoraId = (Int32.Parse(reader["VendedoraId"].ToString())) };
                                    telefoneVendedoraModel.TipoTelefone = new TipoTelefoneModel { TipoId = (Int32.Parse(reader["TipoTelefoneId"].ToString())) };

                                }
                            }
                            connection.Close();
                        }
                    }
                    catch (SqlException e)
                    {

                        dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unabel to get TelefoneVendedoraModel from DataBase", helpLink: e.HelpLink,
                                   errorCode: e.ErrorCode, stackTrace: e.StackTrace);
                        throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                    }
                    if (!MatchingRecordFound)
                    {
                        dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: "",
                        customMessage: $"Record not found. Unable to get TelefoneVendedoraModel for TelefoneID {telefoneId}. Id {telefoneId} " +
                        $"does not exist in the database",
                        helpLink: "", errorCode: 0, stackTrace: "");

                        throw new DataAccessException(dataAccessStatus);
                    }
                }
                catch (SqlException e)
                {

                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Can not Open Connextion from TelefoneModel in DataBase", helpLink: e.HelpLink,
                                   errorCode: e.ErrorCode, stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                return telefoneVendedoraModel;
            }
        }

        public void Add(ITelefoneVendedoraModel telefoneVendedoraModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    try
                    {
                        string sql =
                            "INSERT INTO TelefonesVendedoras (Numero, TipoTelefoneId, VendedoraId) " +
                            " VALUES (@Numero, @TipoTelefoneId, @VendedoraId) ";
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            try
                            {
                                RecordExistCheck(telefoneVendedoraModel, TypeOfExistenceCheck.DoesNotExisInDB, RequestType.Add);
                            }
                            catch (DataAccessException e)
                            {
                                e.DataAccessStatusInfo.CustomMessage = "TelefoneVendedora it is already in the database.";
                                e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                                e.DataAccessStatusInfo.StackTrace = e.StackTrace;
                                throw e;
                            }
                            //cmd.CommandText = sql;

                            cmd.Prepare();
                            cmd.Parameters.AddWithValue("@Numero", telefoneVendedoraModel.Numero);
                            cmd.Parameters.AddWithValue("@TipoTelefoneId", telefoneVendedoraModel.TipoTelefoneId);
                            cmd.Parameters.AddWithValue("@VendedoraId", telefoneVendedoraModel.VendedoraId);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (SqlException e)
                            {
                                dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unable to Execute Command to Add TelefoneVendedoraModel", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                                throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                            }

                            try //TO CONFIRM THE TELEFONEMODEL WAS ADDED TO THE DATABASE
                            {
                                RecordExistCheck(telefoneVendedoraModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.ConfonfirmAdd);
                            }
                            catch (DataAccessException e)
                            {
                                e.DataAccessStatusInfo.Status = "Error";
                                e.DataAccessStatusInfo.OperationSucceeded = false;
                                e.DataAccessStatusInfo.CustomMessage = "Failed to find TelefoneVendedora in database after add operation completed.";
                                e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                                e.DataAccessStatusInfo.StackTrace = e.StackTrace;

                                throw e;
                            }

                        }
                        connection.Close();
                    }
                    catch (SqlException e)
                    {
                        dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unable to Add TelefoneVendedora in DataBase", helpLink: e.HelpLink,
                                   errorCode: e.ErrorCode, stackTrace: e.StackTrace);
                        throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                    }
                }
                catch (SqlException e)
                {

                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Can not Open Connextion from TelefoneModel in DataBase", helpLink: e.HelpLink,
                                   errorCode: e.ErrorCode, stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }

            }
        }

        public void Update(ITelefoneVendedoraModel telefoneVendedoraModel)
        {
            int result = -1;
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string sql =
                        "UPDATE TelefonesVendedoras " +
                        " SET Numero = @Numero, TipoTelefoneId = @TipoTelefoneId " +
                        " WHERE TelefoneId = @TelefoneId AND VendedoraId = @VendedoraId";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        try
                        {
                            RecordExistCheck(telefoneVendedoraModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.Update);
                        }
                        catch (DataAccessException e)
                        {
                            e.DataAccessStatusInfo.CustomMessage = "TelefoneVendedoraModel is not exist in DataBase.";
                            e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                            e.DataAccessStatusInfo.StackTrace = e.StackTrace;
                            throw e;
                        }

                        //cmd.CommandText = sql;

                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@TelefoneId", telefoneVendedoraModel.TelefoneId);
                        cmd.Parameters.AddWithValue("@Numero", telefoneVendedoraModel.Numero);
                        cmd.Parameters.AddWithValue("@TipoTelefoneId", telefoneVendedoraModel.TipoTelefoneId);
                        cmd.Parameters.AddWithValue("@VendedoraId", telefoneVendedoraModel.VendedoraId);

                        try
                        {
                            result = cmd.ExecuteNonQuery();
                        }
                        catch (SqlException e)
                        {
                            dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unable to Execute Update TelefeoneVendedoraModel", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                        }
                    }
                    connection.Close();
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Can not open Connection with DataBase", helpLink: e.HelpLink,
                                   errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
            }
        }

        public void Delete(ITelefoneVendedoraModel telefoneVendedoraModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string sql = "DELETE FROM TelefonesVendedoras WHERE TelefoneId = @TelefoneId";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        try
                        {
                            RecordExistCheck(telefoneVendedoraModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.Delete);
                        }
                        catch (DataAccessException e)
                        {
                            e.DataAccessStatusInfo.CustomMessage = "TelefoneModel not exist in the DataBase.";
                            e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                            e.DataAccessStatusInfo.StackTrace = e.StackTrace;
                            throw e;
                        }

                        //cmd.CommandText = sql;

                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@TelefoneId", telefoneVendedoraModel.TelefoneId);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlException e)
                        {
                            dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                     customMessage: "Fail to Execute Comand", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                        }

                        try //CONFIRM IF TELEFONEVENDEDORA WAS DELETED FROM THE DATABASE
                        {
                            RecordExistCheck(telefoneVendedoraModel, TypeOfExistenceCheck.DoesNotExisInDB, RequestType.ConfirmDelete);
                        }
                        catch (DataAccessException e)
                        {
                            e.DataAccessStatusInfo.Status = "Error";
                            e.DataAccessStatusInfo.OperationSucceeded = false;
                            e.DataAccessStatusInfo.CustomMessage = "Failed to delete TelefoneVendedora in database.";
                            e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                            e.DataAccessStatusInfo.StackTrace = e.StackTrace;

                            throw e;
                        }
                        connection.Close();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                    customMessage: "Can not to open Connection with DataBase", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
            }
        }

        private bool RecordExistCheck(ITelefoneVendedoraModel telefoneVendedoraModel, TypeOfExistenceCheck typeOfExistenceCheck, RequestType requestType)
        {
            Int32 countOfRecsFound = 0;
            bool RecordExistsCheckPassed = true;

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
                       customMessage: "Unable to test exist register. Colud not open the database connection", helpLink: e.HelpLink,
                       errorCode: e.ErrorCode, stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }

                string sql = "";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {


                    cmd.Prepare();

                    if ((requestType == RequestType.Add) || (requestType == RequestType.ConfonfirmAdd))
                    {
                        cmd.CommandText = "Select count(*) from TelefonesVendedoras where Numero=@Numero";
                        cmd.Parameters.AddWithValue("@Numero", telefoneVendedoraModel.Numero);

                    }
                    else if (requestType == RequestType.Update || (requestType == RequestType.ConfirmDelete) || (requestType == RequestType.Delete))
                    {
                        cmd.CommandText = "Select count(*) from TelefonesVendedoras where TelefoneId = @TelefoneId";
                        cmd.Parameters.AddWithValue("@TelefoneId", telefoneVendedoraModel.TelefoneId);
                    }

                    try
                    {
                        countOfRecsFound = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    }
                    catch (SqlException e)
                    {
                        string msg = e.Message;
                        throw;
                    }

                    if ((typeOfExistenceCheck == TypeOfExistenceCheck.DoesNotExisInDB) && (countOfRecsFound > 0))
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
