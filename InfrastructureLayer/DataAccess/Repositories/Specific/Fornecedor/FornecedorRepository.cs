using CommonComponents;

using DomainLayer.Models.Fornecedores;

using ServiceLayer.Services.FornecedorServices;

using System.Collections.Generic;
using System.Data.Entity.Core.Common;
using System.Data.SqlClient;
using System.Linq;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Fornecedor
{
    public class FornecedorRepository : IFornecedorRepository
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
            ConfirmDelete
        }

        public FornecedorRepository()
        {

        }

        public FornecedorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }



        public FornecedorModel Add(IFornecedorModel fornecedorModel)
        {
            int idReturned = 0;
            FornecedorModel fornecedorReturned = new FornecedorModel();

            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            string query = "INSERT INTO Fornecedores " +
                "(NomeFantasia, RazaoSocial, Cnpj, InscricaoEstadual, Email, WebSite, ContatoPrincipal, Logradouro, Numero, Complemento, Cep, UfId, CidadeId, BairroId, Ativo) " +
                "output INSERTED.FornecedorId " +
                "VALUES " +
                "(@NomeFantasia, @RazaoSocial, @Cnpj, @InscricaoEstadual, @Email, @WebSite, @ContatoPrincipal, @Logradouro, @Numero, @Complemento, @Cep, @UfId, @CidadeId, @BairroId, @Ativo) ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        try
                        {
                            RecordExistsCheck(fornecedorModel, TypeOfExistenceCheck.NotExistInDb, RequestType.Add);
                        }
                        catch (DataAccessException ex)
                        {
                            ex.DataAccessStatusInfo.CustomMessage = "Fornecedor model não pode ser adicionado. Ele já existe no DataBase";
                            ex.DataAccessStatusInfo.ExceptionMessage = ex.Message;
                            ex.DataAccessStatusInfo.StackTrace = ex.StackTrace;
                            throw ex;
                        }

                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@NomeFantasia", fornecedorModel.NomeFantasia);
                        cmd.Parameters.AddWithValue("@RazaoSocial", fornecedorModel.RazaoSocial);
                        cmd.Parameters.AddWithValue("@Cnpj", fornecedorModel.Cnpj);
                        cmd.Parameters.AddWithValue("@InscricaoEstadual", fornecedorModel.InscricaoEstadual);
                        cmd.Parameters.AddWithValue("@Email", fornecedorModel.Email);
                        cmd.Parameters.AddWithValue("@WebSite", fornecedorModel.WebSite);
                        cmd.Parameters.AddWithValue("@ContatoPrincipal", fornecedorModel.ContatoPrincipal);
                        cmd.Parameters.AddWithValue("@Logradouro", fornecedorModel.Logradouro);
                        cmd.Parameters.AddWithValue("@Numero", fornecedorModel.Numero);
                        cmd.Parameters.AddWithValue("@Complemento", fornecedorModel.Complemento);
                        cmd.Parameters.AddWithValue("@Cep", fornecedorModel.Cep);
                        cmd.Parameters.AddWithValue("@UfId", fornecedorModel.UfId);
                        cmd.Parameters.AddWithValue("@CidadeId", fornecedorModel.CidadeId);
                        cmd.Parameters.AddWithValue("@BairroId", fornecedorModel.BairroId);
                        cmd.Parameters.AddWithValue("@Ativo", fornecedorModel.Ativo);

                        try
                        {
                            idReturned = (int)cmd.ExecuteScalar();
                        }
                        catch (SqlException e)
                        {
                            dataAccessStatus.setValues("Error", false, e.Message, "Falha no AddFornecedorModel", e.HelpLink, e.ErrorCode, e.StackTrace);

                            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                        }

                        //CONFIRMAÇÃO DE INSERÇÃO DE DADOS
                        try
                        {
                            RecordExistsCheck(fornecedorModel, TypeOfExistenceCheck.ExistInDb, RequestType.ConfirmAdd);
                        }
                        catch (DataAccessException ex)
                        {
                            ex.DataAccessStatusInfo.Status = "Error";
                            ex.DataAccessStatusInfo.OperationSucceeded = false;
                            ex.DataAccessStatusInfo.CustomMessage = "Falha ao buscar Fornecedor Registrado após operação de AddFornecedor";
                            ex.DataAccessStatusInfo.ExceptionMessage = ex.Message;
                            ex.DataAccessStatusInfo.StackTrace = ex.StackTrace;

                            throw ex;
                        }
                    }

                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar registro. FornecedorAdd",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                fornecedorReturned = GetById(idReturned);
                return fornecedorReturned;
            }
        }

        public void Delete(IFornecedorModel fornecedorModel)
        {
            string query = "DELETE FROM Fornecedores WHERE FornecedorId = @FornecedorId";

            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        try
                        {
                            RecordExistsCheck(fornecedorModel, TypeOfExistenceCheck.ExistInDb, RequestType.Delete);
                        }
                        catch (DataAccessException ex)
                        {
                            ex.DataAccessStatusInfo.CustomMessage = "FornecedorModel não foi deletado pois não existe no DataBase.";
                            ex.DataAccessStatusInfo.ExceptionMessage = ex.Message;
                            ex.DataAccessStatusInfo.StackTrace = ex.StackTrace;
                            throw ex;
                        }

                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@FornecedorId", fornecedorModel.FornecedorId);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlException e)
                        {
                            dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                    customMessage: "Erro", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                        }

                        //CONFIRMA SE FOI DELETADO
                        try
                        {
                            RecordExistsCheck(fornecedorModel, TypeOfExistenceCheck.NotExistInDb, RequestType.ConfirmDelete);
                        }
                        catch (DataAccessException ex)
                        {
                            ex.DataAccessStatusInfo.Status = "Error";
                            ex.DataAccessStatusInfo.OperationSucceeded = false;
                            ex.DataAccessStatusInfo.CustomMessage = "Falha ao tentar deletar FornecedorModel no DataBase.";
                            ex.DataAccessStatusInfo.ExceptionMessage = ex.Message;
                            ex.DataAccessStatusInfo.StackTrace = ex.StackTrace;

                            throw ex;
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Falha ao tentar Deletar FornecedorModel", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IFornecedorModel> GetAll()
        {
            List<FornecedorModel> modelList = new List<FornecedorModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            string query = "SELECT * FROM Fornecedores";

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
                                FornecedorModel model = new FornecedorModel();

                                model.FornecedorId = int.Parse(reader["FornecedorId"].ToString());
                                model.NomeFantasia = reader["NomeFantasia"].ToString();
                                model.RazaoSocial = reader["RazaoSocial"].ToString();
                                model.Cnpj = reader["Cnpj"].ToString();
                                model.InscricaoEstadual = reader["InscricaoEstadual"].ToString();
                                model.Email = reader["Email"].ToString();
                                model.WebSite = reader["WebSite"].ToString();
                                model.ContatoPrincipal = reader["ContatoPrincipal"].ToString();
                                model.Logradouro = reader["Logradouro"].ToString();
                                model.Numero = reader["Numero"].ToString();
                                model.Complemento = reader["Complemento"].ToString();
                                model.Cep = reader["Cep"].ToString();
                                model.UfId = int.Parse(reader["UfId"].ToString());
                                model.CidadeId = int.Parse(reader["CidadeId"].ToString());
                                model.BairroId = int.Parse(reader["BairroId"].ToString());
                                model.Ativo = bool.Parse(reader["Ativo"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {

                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                    customMessage: "Não foi possível buscar ModelList de Fornecedores no DataBase", helpLink: e.HelpLink,
                                    errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                return modelList;
            }
        }

        public FornecedorModel GetById(int fornecedorId)
        {
            FornecedorModel model = new FornecedorModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            bool recordFound = false;

            string query = "SELECT FornecedorId, NomeFantasia, RazaoSocial, Cnpj, InscricaoEstadual, Email, WebSite, ContatoPrincipal, Logradouro, Numero, Complemento, Cep, UfId, CidadeId, BairroId, Ativo " +
                           "FROM  Fornecedores WHERE FornecedorId = @FornecedorId ";


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
                            recordFound = reader.HasRows;
                            while (reader.Read())
                            {
                                model.FornecedorId = int.Parse(reader["FornecedorId"].ToString());
                                model.NomeFantasia = reader["NomeFantasia"].ToString();
                                model.RazaoSocial = reader["RazaoSocial"].ToString();
                                model.Cnpj = reader["Cnpj"].ToString();
                                model.InscricaoEstadual = reader["InscricaoEstadual"].ToString();
                                model.Email = reader["Email"].ToString();
                                model.WebSite = reader["WebSite"].ToString();
                                model.ContatoPrincipal = reader["ContatoPrincipal"].ToString();
                                model.Logradouro = reader["Logradouro"].ToString();
                                model.Numero = reader["Numero"].ToString();
                                model.Complemento = reader["Complemento"] != null ? reader["Complemento"].ToString() : "";
                                model.Cep = reader["Cep"].ToString();
                                model.UfId = int.Parse(reader["UfId"].ToString());
                                model.CidadeId = int.Parse(reader["CidadeId"].ToString());
                                model.BairroId = int.Parse(reader["BairroId"].ToString());
                                model.Ativo = bool.Parse(reader["Ativo"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                    customMessage: "Não foi possível buscar Lista de Fornecedores no DataBase", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                if (!recordFound)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: "",
                         customMessage: $"Registro não encontrado., Não foi possível encontrar Fornecedor {fornecedorId}. Id {fornecedorId} " +
                         $"não existe no DataBase",
                         helpLink: "", errorCode: 0, stackTrace: "");

                    throw new DataAccessException(dataAccessStatus);
                }

                return model;
            }
        }

        public FornecedorModel GetByNomeFantasia(string nomeFantasia)
        {
            FornecedorModel model = new FornecedorModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            bool recordFound = false;
            string query = "SELECT FornecedorId, NomeFantasia, RazaoSocial, Cnpj, InscricaoEstadual, Email, WebSite, ContatoPrincipal, Logradouro, Numero, Complemento, Cep, UfId, CidadeId, BairroId, Ativo " +
                           "FROM  Fornecedores WHERE NomeFantasia = @NomeFantasia ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@NomeFantasia", nomeFantasia));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            recordFound = reader.HasRows;
                            while (reader.Read())
                            {
                                model.FornecedorId = int.Parse(reader["FornecedorId"].ToString());
                                model.NomeFantasia = reader["NomeFantasia"].ToString();
                                model.RazaoSocial = reader["RazaoSocial"].ToString();
                                model.Cnpj = reader["Cnpj"].ToString();
                                model.InscricaoEstadual = reader["InscricaoEstadual"].ToString();
                                model.Email = reader["Email"].ToString();
                                model.WebSite = reader["WebSite"].ToString();
                                model.ContatoPrincipal = reader["ContatoPrincipal"].ToString();
                                model.Logradouro = reader["Logradouro"].ToString();
                                model.Numero = reader["Numero"].ToString();
                                model.Complemento = reader["Complemento"].ToString();
                                model.Cep = reader["Cep"].ToString();
                                model.UfId = int.Parse(reader["UfId"].ToString());
                                model.CidadeId = int.Parse(reader["CidadeId"].ToString());
                                model.BairroId = int.Parse(reader["BairroId"].ToString());
                                model.Ativo = bool.Parse(reader["Ativo"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível buscar o Fornecedor pelo Nome", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                if (!recordFound)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: "",
                          customMessage: $"Registro não encontrado., Não foi possível encontrar Fornecedor {nomeFantasia}. Id {nomeFantasia} " +
                          $"não existe no DataBase",
                          helpLink: "", errorCode: 0, stackTrace: "");

                    throw new DataAccessException(dataAccessStatus);
                }
                return model;
            }

        }

        public void Update(IFornecedorModel fornecedorModel)
        {
            int result = -1;
            string query = "UPDATE Fornecedores " +
                           "SET " +
                           "NomeFantasia = @NomeFantasia, " +
                           "RazaoSocial = @RazaoSocial, " +
                           "Cnpj = @Cnpj, " +
                           "InscricaoEstadual = @InscricaoEstadual, " +
                           "Email = @Email, " +
                           "WebSite = @WebSite, " +
                           "ContatoPrincipal = @ContatoPrincipal, " +
                           "Logradouro = @Logradouro, " +
                           "Numero = @Numero, " +
                           "Complemento = @Complemento, " +
                           "Cep = @Cep, " +
                           "UfId = @UfId, " +
                           "CidadeId = @CidadeId, " +
                           "BairroId = @BairroId, " +
                           "Ativo = @Ativo " +
                           "WHERE FornecedorId = @FornecedorId";

            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        try
                        {
                            RecordExistsCheck(fornecedorModel, TypeOfExistenceCheck.ExistInDb, RequestType.Update);
                        }
                        catch (DataAccessException ex)
                        {
                            ex.DataAccessStatusInfo.CustomMessage = "FornededorModel não pôde ser atualiza pois não existe no DabaBase.";
                            ex.DataAccessStatusInfo.ExceptionMessage = ex.Message;
                            ex.DataAccessStatusInfo.StackTrace = ex.StackTrace;
                            throw ex;
                        }

                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@FornecedorId", fornecedorModel.FornecedorId);
                        cmd.Parameters.AddWithValue("@NomeFantasia", fornecedorModel.NomeFantasia);
                        cmd.Parameters.AddWithValue("@RazaoSocial", fornecedorModel.RazaoSocial);
                        cmd.Parameters.AddWithValue("@Cnpj", fornecedorModel.Cnpj);
                        cmd.Parameters.AddWithValue("@InscricaoEstadual", fornecedorModel.InscricaoEstadual);
                        cmd.Parameters.AddWithValue("@Email", fornecedorModel.Email);
                        cmd.Parameters.AddWithValue("@WebSite", fornecedorModel.WebSite);
                        cmd.Parameters.AddWithValue("@ContatoPrincipal", fornecedorModel.ContatoPrincipal);
                        cmd.Parameters.AddWithValue("@Logradouro", fornecedorModel.Logradouro);
                        cmd.Parameters.AddWithValue("@Numero", fornecedorModel.Numero);
                        cmd.Parameters.AddWithValue("@Complemento", fornecedorModel.Complemento);
                        cmd.Parameters.AddWithValue("@Cep", fornecedorModel.Cep);
                        cmd.Parameters.AddWithValue("@UfId", fornecedorModel.UfId);
                        cmd.Parameters.AddWithValue("@CidadeId", fornecedorModel.CidadeId);
                        cmd.Parameters.AddWithValue("@BairroId", fornecedorModel.BairroId);
                        cmd.Parameters.AddWithValue("@Ativo", fornecedorModel.Ativo);

                        try
                        {
                            result = cmd.ExecuteNonQuery();
                        }
                        catch (SqlException e)
                        {

                            dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                       customMessage: "Impossível atualizar registro do Fornecedor", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                        }

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Não foi possível atualizar o Fornecedor.", helpLink: e.HelpLink,
                                   errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        private bool RecordExistsCheck(IFornecedorModel fornecedorModel, TypeOfExistenceCheck typeOfExistenceCheck, RequestType requestType)
        {
            int countOfRecsFound = 0;
            bool RecExistsCheckPassed = true;
            string query = "";

            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        if ((requestType == RequestType.Add) || (requestType == RequestType.ConfirmAdd))
                        {
                            cmd.CommandText = "SELECT COUNT(*) FROM Fornecedores WHERE Cnpj = @Cnpj";
                            cmd.Parameters.AddWithValue("@Cnpj", fornecedorModel.Cnpj);
                        }
                        else if ((requestType == RequestType.Update) || (requestType == RequestType.ConfirmDelete) || (requestType == RequestType.Delete))
                        {
                            cmd.CommandText = "SELECT COUNT(*) FROM Fornecedores WHERE FornecedorId = @FornecedorId";
                            cmd.Parameters.AddWithValue("@FornecedorId", fornecedorModel.FornecedorId);
                        }

                        countOfRecsFound = int.Parse(cmd.ExecuteScalar().ToString());

                        if ((typeOfExistenceCheck == TypeOfExistenceCheck.NotExistInDb) && (countOfRecsFound > 0))
                        {
                            dataAccessStatus.Status = "Error";
                            RecExistsCheckPassed = false;

                            throw new DataAccessException(dataAccessStatus);
                        }
                        else if ((typeOfExistenceCheck == TypeOfExistenceCheck.ExistInDb) && (countOfRecsFound == 0))
                        {
                            dataAccessStatus.Status = "Erro";
                            RecExistsCheckPassed = false;
                            throw new DataAccessException(dataAccessStatus);
                        }
                    }

                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Falha ao buscar registro. RecordExistCheck",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                return RecExistsCheckPassed;
            }
        }
    }
}
