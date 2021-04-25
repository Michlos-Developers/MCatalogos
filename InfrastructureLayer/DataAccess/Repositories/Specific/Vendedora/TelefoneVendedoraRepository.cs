using CommonComponents;

using DomainLayer.Models.CommonModels.Enums;
using DomainLayer.Models.Vendedora;

using ServiceLayer.Services.TelefoneVendedoraServices;

using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.SQLite;
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

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    string sql = "SELECT * FROM TelefonesVendedoras ";

                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
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
                catch (SQLiteException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unable to get TelefoneVendedora Model list from database", helpLink: e.HelpLink,
                                   errorCode: e.ErrorCode, stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                return telefoneVendedoraModelList;
            }
            
        }
        public TelefoneVendedoraModel GetById(int telefoneId)
        {
            TelefoneVendedoraModel telefoneVendedoraModel = new TelefoneVendedoraModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            bool MatchingRecordFound = false;
            string sql = "SELECT TelefoneId, Numero, TipoTelefoneId, VendedoraId " +
                         " FROM TelefonesVendedoras " +
                         " INNER JOIN TiposTelefones ON TelefonesVendedoras.TipoTelefoneId = TiposTelefones.TipoId " +
                         " INNER JOIN Vendedoras ON TelefonesVendedoras.VendedoraId = Vendedoras.VendedoraId " +
                         " WHERE TelefonesVendedoras.TelefoneId = @TelefoneId ";

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                        {
                            cmd.CommandText = sql;
                            cmd.Prepare();
                            cmd.Parameters.Add(new SQLiteParameter("@TelefoneId", telefoneId));

                            using (SQLiteDataReader reader = cmd.ExecuteReader())
                            {
                                MatchingRecordFound = reader.HasRows;

                                while (reader.Read())
                                {
                                    telefoneVendedoraModel.TelefoneId = Int32.Parse(reader["TipoId"].ToString());
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
                    catch (SQLiteException e)
                    {

                        dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unabel to get TelefoneVendedoraMOdel from DataBase", helpLink: e.HelpLink,
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
                catch (SQLiteException e)
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
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    try
                    {
                        string sql =
                            "INERT INTO TelefonesVendedoras (Numero, TipoTelefoneId, VendedoraId) " +
                            " VALUES (@Numero, @TipoTelefoneId, @VendedoraId ";
                        using (SQLiteCommand cmd = new SQLiteCommand(connection))
                        {
                            try
                            {
                                RecordExistCheck(cmd, telefoneVendedoraModel, TypeOfExistenceCheck.DoesNotExisInDB, RequestType.Add);
                            }
                            catch (DataAccessException e)
                            {
                                e.DataAccessStatusInfo.CustomMessage = "TelefoneVendedora it is already in the database.";
                                e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                                e.DataAccessStatusInfo.StackTrace = e.StackTrace;
                                throw e;
                            }
                            cmd.CommandText = sql;

                            cmd.Prepare();
                            cmd.Parameters.AddWithValue("@Numero", telefoneVendedoraModel.Numero);
                            cmd.Parameters.AddWithValue("@TipoTelefoneId", telefoneVendedoraModel.TipoTelefoneId);
                            cmd.Parameters.AddWithValue("@VendedoraId", telefoneVendedoraModel.VendedoraId);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (SQLiteException e)
                            {
                                dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unable to Add TelefoneVendedoraModel", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                                throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                            }

                            try //TO CONFIRM THE TELEFONEMODEL WAS ADDED TO THE DATABASE
                            {
                                RecordExistCheck(cmd, telefoneVendedoraModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.ConfonfirmAdd);
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
                    catch (SQLiteException e)
                    {
                        dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unable to Add TelefoneVendedora in DataBase", helpLink: e.HelpLink,
                                   errorCode: e.ErrorCode, stackTrace: e.StackTrace);
                        throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                    }
                }
                catch (SQLiteException e)
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
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string sql =
                        "UPDATE TelefonesVendedoras " +
                        "SET Numero = @Numero, TipoTelefoneId= @TipoTelefoneId";

                    using (SQLiteCommand cmd = new SQLiteCommand (connection))
                    {
                        try
                        {
                            RecordExistCheck(cmd, telefoneVendedoraModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.Update);
                        }
                        catch (DataAccessException e)
                        {
                            e.DataAccessStatusInfo.CustomMessage = "TelefoneVendedoraModel is not exist in DataBase.";
                            e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                            e.DataAccessStatusInfo.StackTrace = e.StackTrace;
                            throw e;
                        }

                        cmd.CommandText = sql;

                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@TelefoneId", telefoneVendedoraModel.TelefoneId);
                        cmd.Parameters.AddWithValue("@Numero", telefoneVendedoraModel.Numero);
                        cmd.Parameters.AddWithValue("@TipoTelefoneId", telefoneVendedoraModel.TipoTelefoneId);

                        try
                        {
                            result = cmd.ExecuteNonQuery();
                        }
                        catch (SQLiteException e)
                        {
                            dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unable to Execute Update TelefeoneVendedoraModel", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                        }
                    }
                    connection.Close();
                }
                catch (SQLiteException e)
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
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string sql = "DELETE FROM TelefonesVendedoras WHERE TelefoneId = @TelefoneId";
                    using (SQLiteCommand cmd = new SQLiteCommand(connection))
                    {
                        try
                        {
                            RecordExistCheck(cmd, telefoneVendedoraModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.Delete);
                        }
                        catch (DataAccessException e)
                        {
                            e.DataAccessStatusInfo.CustomMessage = "TelefoneModel not exist in the DataBase.";
                            e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                            e.DataAccessStatusInfo.StackTrace = e.StackTrace;
                            throw e;
                        }

                        cmd.CommandText = sql;

                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@TelefoneId", telefoneVendedoraModel.TelefoneId);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SQLiteException e)
                        {
                            dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                     customMessage: "Fail to Execute Comand", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                        }

                        try //CONFIRM IF TELEFONEVENDEDORA WAS DELETED FROM THE DATABASE
                        {
                            RecordExistCheck(cmd, telefoneVendedoraModel, TypeOfExistenceCheck.DoesNotExisInDB, RequestType.ConfirmDelete);
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
                catch (SQLiteException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                    customMessage: "Can not to open Connection with DataBase", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
            }
        }
        private bool RecordExistCheck(SQLiteCommand cmd, ITelefoneVendedoraModel telefoneVendedoraModel, TypeOfExistenceCheck typeOfExistenceCheck, RequestType requestType)
        {
            Int32 countOfRecsFound = 0;
            bool RecordExistsCheckPassed = true;

            DataAccessStatus dataAccessStatus = new DataAccessStatus();

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
                countOfRecsFound = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SQLiteException e)
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
            return RecordExistsCheckPassed;
        }




    }
}
