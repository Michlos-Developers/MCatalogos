using CommonComponents;

using DomainLayer.Models.Vendedora;

using ServiceLayer.Services.RotaServices;

using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora
{
    public class RotaLetraRepository : IRotaLetraRepository
    {
        private string _connectionString;
        enum TypeOfExstenceCheck
        {
            ExistInDB,
            NotExistInDB
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
        public RotaLetraRepository()
        {

        }

        public RotaLetraRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(IRotaLetraModel rotaLetraModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "INSERT INTO RotasLetras (RotaLetra) " +
                           "VALUES (@RotaLetra)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        try
                        {
                            RecordExistCheck(rotaLetraModel, TypeOfExstenceCheck.NotExistInDB, RequestType.Add);
                        }
                        catch (DataAccessException e)
                        {
                            e.DataAccessStatusInfo.CustomMessage = $"Rota {rotaLetraModel.RotaLetra.ToString()} já existe no Banco de Dados. Não pode ser duplicada.";
                            throw e;
                        }

                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@RotaLetra", rotaLetraModel.RotaLetra);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlException e)
                        {
                            dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                            customMessage: "Impossível exuctar commando Add de RotaLetra", helpLink: e.HelpLink, errorCode: e.ErrorCode,
                            stackTrace: e.StackTrace);

                            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                        }

                        //TO CONFIRM ROTALETRAMODEL WAS ADDED TO THE DATABASE
                        try
                        {
                            RecordExistCheck(rotaLetraModel, TypeOfExstenceCheck.ExistInDB, RequestType.ConfirmAdd);
                        }
                        catch (DataAccessException e)
                        {
                            e.DataAccessStatusInfo.Status = "Error";
                            e.DataAccessStatusInfo.OperationSucceeded = false;
                            e.DataAccessStatusInfo.CustomMessage = "Faklha ao tentar achar registro de RotaLetra no Banco de Daodos apoós a inserção.";
                            e.DataAccessStatusInfo.StackTrace = e.StackTrace;
                            throw e;
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Erro ao tentar inserir novo registro de RotaLetra no Banco de Dados", helpLink: e.HelpLink, errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public void Delete(IRotaLetraModel rotaLetraModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "DELETE FROM RotasLetras WHERE RotaLetraId = @RotaLetraId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        try
                        {
                            RecordExistCheck(rotaLetraModel, TypeOfExstenceCheck.ExistInDB, RequestType.Delete);
                        }
                        catch (DataAccessException e)
                        {
                            e.DataAccessStatusInfo.CustomMessage = "Rota Model could not be Deleted. RotaModel is not found ind the DataBase.";
                            e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                            e.DataAccessStatusInfo.StackTrace = e.StackTrace;
                            throw e;
                        }

                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@RotaLetraId", rotaLetraModel.RotaLetraId);
                        
                        cmd.ExecuteNonQuery();

                        try
                        {
                            RecordExistCheck(rotaLetraModel, TypeOfExstenceCheck.NotExistInDB, RequestType.ConfirmDelete);
                        }
                        catch (DataAccessException e)
                        {
                            e.DataAccessStatusInfo.Status = "Error";
                            e.DataAccessStatusInfo.OperationSucceeded = false;
                            e.DataAccessStatusInfo.CustomMessage = "Falha ao deletar RotaLetra do DataBase.";
                            e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                            e.DataAccessStatusInfo.StackTrace = e.StackTrace;
                            throw e;
                        }

                    }
                }
                catch (DataAccessException e)
                {                                           
                    e.DataAccessStatusInfo.CustomMessage = "RotaLetra não pôde ser apagada do Banco de Dados.";
                    e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                    e.DataAccessStatusInfo.StackTrace = e.StackTrace;
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
            
        }

        public IEnumerable<IRotaLetraModel> GetAll()
        {
            List<RotaLetraModel> rotaLetraModelList = new List<RotaLetraModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM RotasLetras";
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
                                RotaLetraModel rlm = new RotaLetraModel();
                                rlm.RotaLetraId = int.Parse(reader["RotaLetraId"].ToString());
                                rlm.RotaLetra = reader["RotaLetra"].ToString();

                                rotaLetraModelList.Add(rlm);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Não foi possível trazer a lista de Letras de Rotas do Banco de Dados.", helpLink: e.HelpLink, errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                return rotaLetraModelList;
            }
        }

        public RotaLetraModel GetById(int id)
        {
            RotaLetraModel rlm = new RotaLetraModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool RecordFound = false;
            string query = "SELECT * FROM  RotasLetras " +
                           " WHERE RotaLetraId = @RotaLetraId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@RotaLetraId", id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            RecordFound = reader.HasRows;
                            while (reader.Read())
                            {
                                rlm.RotaLetraId = int.Parse(reader["RotaLetraId"].ToString());
                                rlm.RotaLetra = reader["RotaLetra"].ToString();


                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Não foi possível buscar RotaLetra no DataBase", helpLink: e.HelpLink, errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                if (!RecordFound)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: "",
                        customMessage: $"Registro não encontrado. Não foi possível buscar a LetraId {id}. Id {id} não existe no DataBase.",
                        helpLink: "", errorCode: 0, stackTrace: "");
                    throw new DataAccessException(dataAccessStatus);
                }

                return rlm;
            }
        }

        public RotaLetraModel GetByLetra(string letra)
        {
            RotaLetraModel rlm = new RotaLetraModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool recordFound = false;
            string query = "SELECT * FROM RotasLetras WHERE RotaLetra = @RotaLetra";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@RotaLetra", letra));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            recordFound = reader.HasRows;
                            while (reader.Read())
                            {
                                rlm.RotaLetraId = int.Parse(reader["RotaLetraId"].ToString());
                                rlm.RotaLetra = reader["RotaLetra"].ToString();
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Não foi possível buscar o RotaLetra pela letra.", helpLink: e.HelpLink, errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                if (!recordFound)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: "",
                        customMessage: $"Registro não encontrado. Impossível encontrar a Rota de Letra {letra}. Letra {letra} não cadastrada no DataBase.",
                        helpLink: "", errorCode: 0, stackTrace: "");
                    throw new DataAccessException(dataAccessStatus);
                }
                return rlm;
            }
        }

        public void Update(IRotaLetraModel rotaLetraModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE RotasLetras SET RotaLetra = @RotaLetra WHERE RotaLetraId = @RotaLetraId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    try //Checa a existência do registro
                    {
                        RecordExistCheck(rotaLetraModel, TypeOfExstenceCheck.ExistInDB, RequestType.Update);
                    }
                    catch (DataAccessException e)
                    {
                        e.DataAccessStatusInfo.CustomMessage = "Rota não pôde ser atualizada pois não existe no banco de dados.";
                        e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                        e.DataAccessStatusInfo.StackTrace = e.StackTrace;

                        throw e;
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@RotaLetraId", rotaLetraModel.RotaLetraId);
                        cmd.Parameters.AddWithValue("@RotaLetra", rotaLetraModel.RotaLetra);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlException e)
                        {
                            dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                customMessage: "Não foi possível atualizar a rota", helpLink: e.HelpLink, errorCode: e.ErrorCode,
                                stackTrace: e.StackTrace);

                            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Não foi possível atualizar a Rota.", helpLink: e.HelpLink,
                        errorCode: e.ErrorCode, stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private bool RecordExistCheck(IRotaLetraModel rotaLetraModel, TypeOfExstenceCheck typeOfExstenceCheck, RequestType requestType)
        {
            int countOfRecsFound = 0;
            bool recordExistsCheckPassed = true;
            string query = "";
            DataAccessStatus dataAccess = new DataAccessStatus();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        
                        DataAccessStatus dataAccessStatus = new DataAccessStatus();

                        cmd.Prepare();

                        if ((requestType == RequestType.Add) || (requestType == RequestType.ConfirmAdd))
                        {
                            cmd.CommandText = "SELECT COUNT(*) FROM RotasLetras WHERE RotaLetra = @RotaLetra";
                            cmd.Parameters.AddWithValue("@RotaLetra", rotaLetraModel.RotaLetra);
                        }
                        else if ((requestType == RequestType.Update) || (requestType == RequestType.ConfirmDelete) || (requestType == RequestType.Delete))
                        {
                            cmd.CommandText = "SELECT COUNT(*) FROM RotasLetras WHERE RotaLetraId = @RotaLetraId";
                            cmd.Parameters.AddWithValue("@RotaLetraId", rotaLetraModel.RotaLetraId);
                        }

                        try
                        {
                            countOfRecsFound = int.Parse(cmd.ExecuteScalar().ToString());
                        }
                        catch (SqlException e)
                        {
                            string mesg = e.Message;
                            throw;
                        }

                        if ((typeOfExstenceCheck == TypeOfExstenceCheck.NotExistInDB) && (countOfRecsFound > 0))
                        {
                            dataAccessStatus.Status = "Error";
                            recordExistsCheckPassed = false;
                            throw new DataAccessException(dataAccessStatus);
                        }
                        else if ((typeOfExstenceCheck == TypeOfExstenceCheck.ExistInDB) && (countOfRecsFound == 0))
                        {
                            dataAccessStatus.Status = "Error";
                            recordExistsCheckPassed = false;
                            throw new DataAccessException(dataAccessStatus);
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccess.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Falha para teste de Existência de Registro.", helpLink: e.HelpLink,
                        errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccess);
                }
                finally
                {
                    connection.Close();
                }
                return recordExistsCheckPassed;
            }
        }
    }
}
