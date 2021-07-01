using CommonComponents;

using DomainLayer.Models.Fornecedores;

using ServiceLayer.Services.TelefoneFornecedorServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Fornecedor
{
    public class TelefoneFornecedorRepository : ITelefoneFornecedorRepository
    {
        private string _connectionString;
        enum TypeOfExistenceCheck
        {
            ExistInDb,
            NotExistInDb
        }

        enum RequestType
        {
            Add,
            Update,
            Read,
            Delete,
            ConfirmAdd,
            ConfirmDelele
        }

        public TelefoneFornecedorRepository()
        {

        }

        public TelefoneFornecedorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(ITelefoneFornecedorModel telelefoneFornecedorModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "INSERT INTO TelefonesFornecedores " +
                           "(Numero, Ramal, Contato, Departamento, TipoTelefoneId, FornecedorId) " +
                           "VALUES (@Numero, @Ramal, @Contato, @Departamento, @TipoTelefoneId, @FornecedorId)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        try
                        {
                            RecordExistCheck(telelefoneFornecedorModel, TypeOfExistenceCheck.NotExistInDb, RequestType.Add);
                        }
                        catch (DataAccessException e)
                        {
                            e.DataAccessStatusInfo.CustomMessage = "TelefoneFornecedor já existe no DataBase.";
                            e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                            e.DataAccessStatusInfo.StackTrace = e.StackTrace;
                            throw e;
                        }

                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Numero", telelefoneFornecedorModel.Numero);
                        cmd.Parameters.AddWithValue("@Ramal", telelefoneFornecedorModel.Ramal);
                        cmd.Parameters.AddWithValue("@Contato", telelefoneFornecedorModel.Contato);
                        cmd.Parameters.AddWithValue("@Departamento", telelefoneFornecedorModel.Departamento);
                        cmd.Parameters.AddWithValue("@TipoTelefoneId", telelefoneFornecedorModel.TipoTelefoneId);
                        cmd.Parameters.AddWithValue("@FornecedorId", telelefoneFornecedorModel.FornecedorId);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlException e)
                        {
                            dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                               customMessage: "Falha ao executar o comando Add para Telefone Fornecedor", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                        }

                        //CONFIRMAÇÃO DE INSERÇÃO DE DADOS
                        try
                        {
                            RecordExistCheck(telelefoneFornecedorModel, TypeOfExistenceCheck.ExistInDb, RequestType.ConfirmAdd);
                        }
                        catch (DataAccessException e)
                        {
                            e.DataAccessStatusInfo.Status = "Error";
                            e.DataAccessStatusInfo.OperationSucceeded = false;
                            e.DataAccessStatusInfo.CustomMessage = "Falha ao buscar Telefone Fornecedor no DataBase após a inserção.";
                            e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                            e.DataAccessStatusInfo.StackTrace = e.StackTrace;

                            throw e;
                        }
                    }
                }
                catch (SqlException e)
                {

                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Falha ao tentar inserrir novo telefone de fornecedor do DataBase", helpLink: e.HelpLink,
                                   errorCode: e.ErrorCode, stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Delete(ITelefoneFornecedorModel telelefoneFornecedorModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "DELETE FROM TelefonesFornecedores WHERE TelefoneId = @TelefoneId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        //VERIFICA SE O REGISTRO EXISTE
                        try
                        {
                            RecordExistCheck(telelefoneFornecedorModel, TypeOfExistenceCheck.ExistInDb, RequestType.Delete);
                        }
                        catch (DataAccessException e)
                        {
                            e.DataAccessStatusInfo.CustomMessage = "Telefone Fornecedor não encontrado no DataBase.";
                            e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                            e.DataAccessStatusInfo.StackTrace = e.StackTrace;
                            throw e;
                        }

                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@TelefoneId", telelefoneFornecedorModel.TelefoneId);

                        //EXECUTA COMANDO DA QUERY
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlException e)
                        {
                            dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                     customMessage: "Falha ao executar o comando Delete do Telefone Fornecedor", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                        }

                        //CONFIRMA EXCLUSÃO
                        try
                        {
                            RecordExistCheck(telelefoneFornecedorModel, TypeOfExistenceCheck.NotExistInDb, RequestType.ConfirmDelele);
                        }
                        catch (DataAccessException e)
                        {
                            e.DataAccessStatusInfo.Status = "Error";
                            e.DataAccessStatusInfo.OperationSucceeded = false;
                            e.DataAccessStatusInfo.CustomMessage = "Falha ao deletar Telefone Fornecedor no DataBase";
                            e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                            e.DataAccessStatusInfo.StackTrace = e.StackTrace;

                            throw e;
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                    customMessage: "Falha ao tentar deletar telefone do fornecedor", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<ITelefoneFornecedorModel> GetByFornecedorId(int fornecedorId)
        {
            List<TelefoneFornecedorModel> modelList = new List<TelefoneFornecedorModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            string query = "SELECT * FROM TelefonesFornecedores WHERE FornecedorId = @FornecedorId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@FornecedorId", fornecedorId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TelefoneFornecedorModel model = new TelefoneFornecedorModel();

                                model.TelefoneId = int.Parse(reader["TelefoneId"].ToString());
                                model.Numero = reader["Numero"].ToString();
                                model.Ramal = reader["Ramal"].ToString();
                                model.Contato = reader["Contato"].ToString();
                                model.Departamento = reader["Departamento"].ToString();
                                model.TipoTelefoneId = int.Parse(reader["TipoTelefoneId"].ToString());
                                model.FornecedorId = int.Parse(reader["FornecedorId"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Não foi possível gerata a lista de telefones do fornecedor do DataBase", helpLink: e.HelpLink,
                                   errorCode: e.ErrorCode, stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return modelList;
        }

        public TelefoneFornecedorModel GetById(int id)
        {
            TelefoneFornecedorModel model = new TelefoneFornecedorModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT TelefoneId, Numero, Ramal, Contato, Departamento, TipoTelefoneId, FornecedorId " +
                           "FROM TelefonesFornecedores " +
                           "WHERE TelefoneId = @TelefoneId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@TelefoneId", id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.TelefoneId = int.Parse(reader["TelefoneId"].ToString());
                                model.Numero = reader["Numero"].ToString();
                                model.Ramal = reader["Ramal"].ToString();
                                model.Contato = reader["Contato"].ToString();
                                model.Departamento = reader["Departamento"].ToString();
                                model.TipoTelefoneId = int.Parse(reader["TipoTelefoneId"].ToString());
                                model.FornecedorId = int.Parse(reader["FornecedorId"].ToString());

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Impossível buscar telefone do fornecedor do DataBase", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return model;
        }

        public void Update(ITelefoneFornecedorModel model)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE TelefonesFornecedores " +
                           "SET Numero = @Numero, Ramal = @Ramal, Contato = @Contato, Departamento = @Departamento, " +
                           "TipoTelefoneId = @TipoTelefoneId, FornecedorId = @FornecedorId " +
                           "WHERE TelefoneId = @TelefoneId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        try
                        {
                            RecordExistCheck(model, TypeOfExistenceCheck.ExistInDb, RequestType.Update);
                        }
                        catch (DataAccessException e)
                        {
                            e.DataAccessStatusInfo.CustomMessage = "Telefone do Fornecedor não existe no DataBase.";
                            e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                            e.DataAccessStatusInfo.StackTrace = e.StackTrace;
                            throw e;
                        }

                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@TelefoneId", model.TelefoneId);
                        cmd.Parameters.AddWithValue("@Numero", model.Numero);
                        cmd.Parameters.AddWithValue("@Ramal", model.Ramal);
                        cmd.Parameters.AddWithValue("@Contato", model.Contato);
                        cmd.Parameters.AddWithValue("@Departamento", model.Departamento);
                        cmd.Parameters.AddWithValue("@TipoTelefoneId", model.TipoTelefoneId);
                        cmd.Parameters.AddWithValue("@FornecedorId", model.FornecedorId);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlException e)
                        {
                            dataAccessStatus.setValues("Error", false, e.Message, "Falha ao tentar Atualizar registro.", e.HelpLink, e.ErrorCode, e.StackTrace);
                            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                        }

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Falha ao tentar atualizar registro do telefone do fornecedor.",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private bool RecordExistCheck(ITelefoneFornecedorModel telefoneFornecedorModel, TypeOfExistenceCheck typeOfExistenceCheck, RequestType requestType)
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
                       customMessage: "Impossível verificar registro. Falha ao tentar abrir o DataBase", helpLink: e.HelpLink,
                       errorCode: e.ErrorCode, stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }

                string sql = "";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {


                    cmd.Prepare();

                    if ((requestType == RequestType.Add) || (requestType == RequestType.ConfirmAdd))
                    {
                        cmd.CommandText = "Select count(*) from TelefonesFornecedores where Numero=@Numero";
                        cmd.Parameters.AddWithValue("@Numero", telefoneFornecedorModel.Numero);

                    }
                    else if (requestType == RequestType.Update || (requestType == RequestType.ConfirmDelele) || (requestType == RequestType.Delete))
                    {
                        cmd.CommandText = "Select count(*) from TelefonesFornecedores where TelefoneId = @TelefoneId";
                        cmd.Parameters.AddWithValue("@TelefoneId", telefoneFornecedorModel.TelefoneId);
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

                    if ((typeOfExistenceCheck == TypeOfExistenceCheck.NotExistInDb) && (countOfRecsFound > 0))
                    {
                        dataAccessStatus.Status = "Error";
                        RecordExistsCheckPassed = false;

                        throw new DataAccessException(dataAccessStatus);
                    }
                    else if ((typeOfExistenceCheck == TypeOfExistenceCheck.ExistInDb) && (countOfRecsFound == 0))
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
