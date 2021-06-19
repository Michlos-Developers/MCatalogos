using CommonComponents;

using DomainLayer.Models.Vendedora;

using ServiceLayer.Services.RotaServices;
using ServiceLayer.Services.VendedoraServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora
{
    public class VendedoraRepository : IVendedoraRepository
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
        public VendedoraRepository()
        {
        }
        public VendedoraRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<IVendedoraModel> GetAll()
        {
            List<VendedoraModel> vendedoraModelsList = new List<VendedoraModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            using (SqlConnection SqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    string sql = "SELECT * FROM Vendedoras ";

                    SqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, SqlConnection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VendedoraModel vendedoraModel = new VendedoraModel();

                                vendedoraModel.VendedoraId = Int32.Parse(reader["VendedoraId"].ToString());
                                vendedoraModel.Nome = reader["Nome"].ToString();
                                vendedoraModel.Cpf = reader["Cpf"].ToString();
                                vendedoraModel.Rg = reader["Rg"].ToString();
                                vendedoraModel.RgEmissor = reader["RgEmissor"].ToString();
                                vendedoraModel.DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString());
                                vendedoraModel.Email = reader["Email"].ToString();
                                vendedoraModel.NomePai = reader["NomePai"].ToString();
                                vendedoraModel.NomeMae = reader["NomeMae"].ToString();
                                vendedoraModel.NomeConjuge = reader["NomeConjuge"].ToString();
                                vendedoraModel.Logradouro = reader["Logradouro"].ToString();
                                vendedoraModel.Numero = reader["Numero"].ToString();
                                vendedoraModel.Complemento = reader["Complemento"].ToString();
                                vendedoraModel.Cep = reader["Cep"].ToString();
                                vendedoraModel.UfRgId = Int32.Parse(reader["UfRgId"].ToString());
                                vendedoraModel.EstadoCivilId = Int32.Parse(reader["EstadoCivilId"].ToString());
                                //vendedoraModel.RotaId = Int32.Parse(reader["RotaId"].ToString());
                                //vendedoraModel.Rota = new RotaModel { RotaId = Int32.Parse(reader["RotaId"].ToString()) };
                                vendedoraModel.EstadoId = Int32.Parse(reader["EstadoId"].ToString());
                                vendedoraModel.CidadeId = Int32.Parse(reader["CidadeId"].ToString());
                                vendedoraModel.BairroId = Int32.Parse(reader["BairroId"].ToString());
                                vendedoraModel.RotaLetraId = int.Parse(reader["RotaLetraId"].ToString());

                                vendedoraModelsList.Add(vendedoraModel);
                            }
                        }
                        SqlConnection.Close();
                    }

                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unable to get Vendedora Model list from database", helpLink: e.HelpLink,
                                   errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                return vendedoraModelsList;
            }
        }
        public VendedoraModel GetById(int vendedoraId)
        {
            VendedoraModel vendedoraModel = new VendedoraModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool MatchingRecordFound = false;
            string sql = " SELECT * " +
                         " FROM Vendedoras " +
                         " WHERE VendedoraId = @VendedoraId";
            using (SqlConnection SqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, SqlConnection))
                    {
                        //cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@VendedoraId", vendedoraId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            MatchingRecordFound = reader.HasRows;
                            while (reader.Read())
                            {
                                vendedoraModel.VendedoraId = Int32.Parse(reader["VendedoraId"].ToString());
                                vendedoraModel.Nome = reader["Nome"].ToString();
                                vendedoraModel.Cpf = reader["Cpf"].ToString();
                                vendedoraModel.Rg = reader["Rg"].ToString();
                                vendedoraModel.RgEmissor = reader["RgEmissor"].ToString();
                                vendedoraModel.DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString());
                                vendedoraModel.Email = reader["Email"].ToString();
                                vendedoraModel.NomePai = reader["NomePai"].ToString();
                                vendedoraModel.NomeMae = reader["NomeMae"].ToString();
                                vendedoraModel.NomeConjuge = reader["NomeConjuge"].ToString();
                                vendedoraModel.Logradouro = reader["Logradouro"].ToString();
                                vendedoraModel.Numero = reader["Numero"].ToString();
                                vendedoraModel.Complemento = reader["Complemento"].ToString();
                                vendedoraModel.Cep = reader["Cep"].ToString();
                                vendedoraModel.UfRgId = Int32.Parse(reader["UfRgId"].ToString());
                                vendedoraModel.EstadoCivilId = Int32.Parse(reader["EstadoCivilId"].ToString());
                                vendedoraModel.EstadoId = Int32.Parse(reader["EstadoId"].ToString());
                                vendedoraModel.CidadeId = Int32.Parse(reader["CidadeId"].ToString());
                                vendedoraModel.BairroId = Int32.Parse(reader["BairroId"].ToString());
                                vendedoraModel.RotaLetraId = int.Parse(reader["RotaLetraId"].ToString());

                            }
                        }
                    }
                    SqlConnection.Close();
                }
                catch (SqlException e)
                {

                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unable to get Vendedora Model list from database", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);

                }

                if (!MatchingRecordFound)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: "",
                        customMessage: $"Record not found., Unable to get Vendedora MOdel for Vendedora ID {vendedoraId}. Id {vendedoraId} " +
                        $"does not exist in the database",
                        helpLink: "", errorCode: 0, stackTrace: "");

                    throw new DataAccessException(dataAccessStatus);

                }
                return vendedoraModel;
            }
        }
        public VendedoraModel Add(IVendedoraModel vendedoraModel)
        {
            int idReturned = 0;
            VendedoraModel vendedoraReturn = new VendedoraModel();

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
                                   customMessage: "Unable to add VendedoraModel. Could not open a database connection", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }

                string sql =
                    "INSERT INTO Vendedoras (Nome, Cpf, Rg, RgEmissor, DataNascimento, Email, NomePai, NomeMae, NomeConjuge, Logradouro, Numero, Complemento, " +
                    "Cep, UfRgId, EstadoCivilId, EstadoId, CidadeId, BairroId, RotaLetraId ) " +
                    " output INSERTED.VendedoraId " +
                    "VALUES (@Nome, @Cpf, @Rg, @RgEmissor, @DataNascimento, @Email, @NomePai, @NomeMae, @NomeConjuge, @Logradouro, @Numero, @Complemento, " +
                    "@Cep, @UfRgId, @EstadoCivilId, @EstadoId, @CidadeId, @BairroId, @RotaLetraId) ";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    try
                    {
                        RecordExistsCheck(vendedoraModel, TypeOfExistenceCheck.DoesNotExistInDB, RequestType.Add);
                    }
                    catch (DataAccessException ex)
                    {
                        ex.DataAccessStatusInfo.CustomMessage = "Vendedora model could not be added becouse it is already in the database.";
                        ex.DataAccessStatusInfo.ExceptionMessage = ex.Message;
                        ex.DataAccessStatusInfo.StackTrace = ex.StackTrace;
                        throw ex;
                    }


                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Nome", vendedoraModel.Nome);
                    cmd.Parameters.AddWithValue("@Cpf", vendedoraModel.Cpf);
                    cmd.Parameters.AddWithValue("@Rg", vendedoraModel.Rg);
                    cmd.Parameters.AddWithValue("@RgEmissor", vendedoraModel.RgEmissor);
                    cmd.Parameters.AddWithValue("@DataNascimento", vendedoraModel.DataNascimento);
                    cmd.Parameters.AddWithValue("@Email", vendedoraModel.Email);
                    cmd.Parameters.AddWithValue("@NomePai", vendedoraModel.NomePai);
                    cmd.Parameters.AddWithValue("@NomeMae", vendedoraModel.NomeMae);
                    cmd.Parameters.AddWithValue("@NomeConjuge", vendedoraModel.NomeConjuge);
                    cmd.Parameters.AddWithValue("@Logradouro", vendedoraModel.Logradouro);
                    cmd.Parameters.AddWithValue("@Numero", vendedoraModel.Numero);
                    cmd.Parameters.AddWithValue("@Complemento", vendedoraModel.Complemento);
                    cmd.Parameters.AddWithValue("@Cep", vendedoraModel.Cep);
                    cmd.Parameters.AddWithValue("@UfRgId", vendedoraModel.UfRgId);
                    cmd.Parameters.AddWithValue("@EstadoCivilId", vendedoraModel.EstadoCivilId);
                    cmd.Parameters.AddWithValue("@EstadoId", vendedoraModel.EstadoId);
                    cmd.Parameters.AddWithValue("@CidadeId", vendedoraModel.CidadeId);
                    cmd.Parameters.AddWithValue("@BairroId", vendedoraModel.BairroId);
                    cmd.Parameters.AddWithValue("@RotaLetraId", vendedoraModel.RotaLetraId);



                    try
                    {
                        idReturned = (int)cmd.ExecuteScalar();
                    }
                    catch (SqlException e)
                    {
                        dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unable to Add VendedoraModel", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                        throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                    }

                    try //Confirm the Vendedora Model was added to the database
                    {
                        RecordExistsCheck(vendedoraModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.ConfirmAdd);
                    }
                    catch (DataAccessException ex)
                    {
                        ex.DataAccessStatusInfo.Status = "Error";
                        ex.DataAccessStatusInfo.OperationSucceeded = false;
                        ex.DataAccessStatusInfo.CustomMessage = "Failed to find vendedora model in database after add operation completed.";
                        ex.DataAccessStatusInfo.ExceptionMessage = ex.Message;
                        ex.DataAccessStatusInfo.StackTrace = ex.StackTrace;

                        throw ex;
                    }
                    connection.Close();
                }
            }

            vendedoraReturn = GetById(idReturned);

            return vendedoraReturn;
        }
        public void Update(IVendedoraModel vendedoraModel)
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
                                   customMessage: "Unable to update Vendedora Model. Could not open a database connection", helpLink: e.HelpLink,
                                   errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }

                string sql =
                    "UPDATE Vendedoras " +
                    "SET Nome = @Nome, Cpf = @Cpf, Rg = @Rg, RgEmissor = @RgEmissor, DataNascimento = @DataNascimento, " +
                    " Email = @Email, NomePai = @NomePai, NomeMae = @NomeMae, NomeConjuge = @NomeConjuge, Logradouro = @Logradouro, " +
                    " Numero = @Numero, Complemento = @Complemento, Cep = @Cep, UfRgId = @UfRgId, EstadoCivilId = @EstadoCivilId, " +
                    " EstadoId = @EstadoId, CidadeId = @CidadeId, BairroId = @BairroId, RotaLetraId = @RotaLetraId" +
                    " WHERE VendedoraId = @VendedoraId";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    try
                    {
                        RecordExistsCheck(vendedoraModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.Update);
                    }
                    catch (DataAccessException ex)
                    {
                        ex.DataAccessStatusInfo.CustomMessage = "Vendedora Model could not be updated becouse it is not in the database.";
                        ex.DataAccessStatusInfo.ExceptionMessage = ex.Message;
                        ex.DataAccessStatusInfo.StackTrace = ex.StackTrace;
                        throw ex;
                    }

                    //cmd.CommandText = updateSql;

                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@VendedoraId", vendedoraModel.VendedoraId);
                    cmd.Parameters.AddWithValue("@Nome", vendedoraModel.Nome);
                    cmd.Parameters.AddWithValue("@Cpf", vendedoraModel.Cpf);
                    cmd.Parameters.AddWithValue("@Rg", vendedoraModel.Rg);
                    cmd.Parameters.AddWithValue("@RgEmissor", vendedoraModel.RgEmissor);
                    cmd.Parameters.AddWithValue("@DataNascimento", vendedoraModel.DataNascimento);
                    cmd.Parameters.AddWithValue("@Email", vendedoraModel.Email);
                    cmd.Parameters.AddWithValue("@NomePai", vendedoraModel.NomePai);
                    cmd.Parameters.AddWithValue("@NomeMae", vendedoraModel.NomeMae);
                    cmd.Parameters.AddWithValue("@NomeConjuge", vendedoraModel.NomeConjuge);
                    cmd.Parameters.AddWithValue("@Logradouro", vendedoraModel.Logradouro);
                    cmd.Parameters.AddWithValue("@Numero", vendedoraModel.Numero);
                    cmd.Parameters.AddWithValue("@Complemento", vendedoraModel.Complemento);
                    cmd.Parameters.AddWithValue("@Cep", vendedoraModel.Cep);
                    cmd.Parameters.AddWithValue("@UfRgId", vendedoraModel.UfRgId);
                    cmd.Parameters.AddWithValue("@EstadoCivilId", vendedoraModel.EstadoCivilId);
                    cmd.Parameters.AddWithValue("@EstadoId", vendedoraModel.EstadoId);
                    cmd.Parameters.AddWithValue("@CidadeId", vendedoraModel.CidadeId);
                    cmd.Parameters.AddWithValue("@BairroId", vendedoraModel.BairroId);
                    cmd.Parameters.AddWithValue("@RotaLetraId", vendedoraModel.RotaLetraId);
                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                        dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unable to Execute update Vendedora Model", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                        throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                    }

                }
                connection.Close();
            }
        }
        public void Delete(IVendedoraModel vendedoraModel)
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
                                    customMessage: "Unable to Delete VendedoraModel. Could not open a database connection", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }

                string sql = "DELETE FROM Vendedoras WHERE VendedoraId = @VendedoraId";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    try
                    {
                        RecordExistsCheck(vendedoraModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.Delete);
                    }
                    catch (DataAccessException ex)
                    {
                        ex.DataAccessStatusInfo.CustomMessage = "Vendedora model could not be deleted becouse it could not be found int the database.";
                        ex.DataAccessStatusInfo.ExceptionMessage = ex.Message;
                        ex.DataAccessStatusInfo.StackTrace = ex.StackTrace;
                        throw ex;
                    }

                    //cmd.CommandText = sqlDeleteText;

                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@VendedoraId", vendedoraModel.VendedoraId);

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

                    try //Confirm the Vendedora Model was deleted from the database
                    {
                        RecordExistsCheck(vendedoraModel, TypeOfExistenceCheck.DoesNotExistInDB, RequestType.ConfirmDelete);
                    }
                    catch (DataAccessException ex)
                    {

                        ex.DataAccessStatusInfo.Status = "Error";
                        ex.DataAccessStatusInfo.OperationSucceeded = false;
                        ex.DataAccessStatusInfo.CustomMessage = "Failed to delete Vendedora Model in database.";
                        ex.DataAccessStatusInfo.ExceptionMessage = ex.Message;
                        ex.DataAccessStatusInfo.StackTrace = ex.StackTrace;

                        throw ex;
                    }
                    connection.Close();
                }
            }
        }
        private bool RecordExistsCheck(IVendedoraModel vendedoraModel, TypeOfExistenceCheck typeOfExistenceCheck, RequestType requestType)
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

                    if ((requestType == RequestType.Add) || (requestType == RequestType.ConfirmAdd))
                    {
                        cmd.CommandText = "Select count(*) from Vendedoras where Cpf=@Cpf";
                        cmd.Parameters.AddWithValue("@Cpf", vendedoraModel.Cpf);

                    }
                    else if (requestType == RequestType.Update || (requestType == RequestType.ConfirmDelete) || (requestType == RequestType.Delete))
                    {
                        cmd.CommandText = "Select count(*) from Vendedoras where VendedoraId = @VendedoraId";
                        cmd.Parameters.AddWithValue("@VendedoraId", vendedoraModel.VendedoraId);
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
                }
                connection.Close();
                return RecordExistsCheckPassed;
            }
        }

        public VendedoraModel GetByCpf(string cpf)
        {
            VendedoraModel model = new VendedoraModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            bool redordFound = false;

            string query = "SELECT * " +
                            "FROM Vendedoras " +
                            "WHERE Cpf = @Cpf";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Cpf", cpf));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            redordFound = reader.HasRows;
                            while (reader.Read())
                            {
                                model.VendedoraId = Int32.Parse(reader["VendedoraId"].ToString());
                                model.Nome = reader["Nome"].ToString();
                                model.Cpf = reader["Cpf"].ToString();
                                model.Rg = reader["Rg"].ToString();
                                model.RgEmissor = reader["RgEmissor"].ToString();
                                model.DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString());
                                model.Email = reader["Email"].ToString();
                                model.NomePai = reader["NomePai"].ToString();
                                model.NomeMae = reader["NomeMae"].ToString();
                                model.NomeConjuge = reader["NomeConjuge"].ToString();
                                model.Logradouro = reader["Logradouro"].ToString();
                                model.Numero = reader["Numero"].ToString();
                                model.Complemento = reader["Complemento"].ToString();
                                model.Cep = reader["Cep"].ToString();
                                model.UfRgId = Int32.Parse(reader["UfRgId"].ToString());
                                model.EstadoCivilId = Int32.Parse(reader["EstadoCivilId"].ToString());
                                model.EstadoId = Int32.Parse(reader["EstadoId"].ToString());
                                model.CidadeId = Int32.Parse(reader["CidadeId"].ToString());
                                model.BairroId = Int32.Parse(reader["BairroId"].ToString());
                                model.RotaLetraId = int.Parse(reader["RotaLetraId"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível buscar os dados da vendedora GETBYCPF",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return model;
            }
        }

        public void AlteraRotaLetra(int vendedoraId, int rotaLetraId)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE Vendedoras " +
                           "SET RotaLetraId = @RotaLetraId " +
                           "WHERE VendedoraId = @VendedoraId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@VendedoraId", vendedoraId));
                        cmd.Parameters.Add(new SqlParameter("@RotaLetraId", rotaLetraId));
                        
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Não foi possível alterar a Letra da Rota da Vendedora.", helpLink: e.HelpLink,
                                   errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        
    }
}
