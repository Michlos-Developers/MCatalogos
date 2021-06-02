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
using DomainLayer.Models.CommonModels.Address;
using System.Data.Entity.SqlServer;
using System.Threading;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Vendedora
{
    public class RotaRepository : IRotaRepository
    {
        private string _connectionString;
        DataAccessStatus dataAccessStatus = new DataAccessStatus();
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
                                rotaModel.RotaLetraId = int.Parse(reader["RotaLetraId"].ToString());
                                rotaModel.VendedoraId = int.Parse(reader["VendedoraId"].ToString());

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
                    " INSERT INTO Rotas (Numero, VendedoraId, RotaLetraId) " +
                    " VALUES (@Numero, @VendedoraId, @RotaLetraId)";

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


                    cmd.Parameters.AddWithValue("@VendedoraId", rotaModel.VendedoraId);
                    cmd.Parameters.AddWithValue("@RotaLetraId", rotaModel.RotaLetraId);

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

                string sql = "UPDATE Rotas SET Numero = @Numero, VendedoraId = @VendedoraId, RotaLetraId = @RotaLetraId WHERE RotaId = @RotaId";


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
                    cmd.Parameters.AddWithValue("@RotaLetraId", rotaModel.RotaLetraId);
                    cmd.Parameters.AddWithValue("@VendedoraId", rotaModel.VendedoraId);

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
        public RotaModel GetById(int rotaId)
        {
            RotaModel rotaModel = new RotaModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool MatchingRecordFound = false;
            string sql = "SELECT RotaId, Numero, VendedoraId, RotaLetraId " +
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
                        cmd.Parameters.Add(new SqlParameter("@RotaId", rotaId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            MatchingRecordFound = reader.HasRows;

                            while (reader.Read())
                            {
                                rotaModel.RotaId = Int32.Parse(reader["RotaId"].ToString());
                                rotaModel.RotaLetraId = int.Parse(reader["RotaLetraId"].ToString());
                                rotaModel.VendedoraId = Int32.Parse(reader["VendedoraId"].ToString());

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
        public RotaModel GetByNumeroAndLetraId(int numero, int letraId)
        {
            RotaModel model = new RotaModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            bool recordFound = false;

            string query = "SELECT RotaId, Numero, VendedoraId, RotaLetraId " +
                           " FROM Rotas " +
                           " WHERE Numero = @Numero AND RotaLetraId = @RotaLetraId ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Numero", numero));
                        cmd.Parameters.Add(new SqlParameter("@RotaLetraId", letraId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            recordFound = reader.HasRows;

                            while (reader.Read())
                            {
                                model.RotaId = int.Parse(reader["RotaId"].ToString());
                                model.VendedoraId = int.Parse(reader["VendedoraId"].ToString());
                                model.RotaLetraId = int.Parse(reader["RotaLetraId"].ToString());

                                model.Numero = int.Parse(reader["Numero"].ToString());
                            }
                        }

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message,
                        "Não foi possível buscar a Rota do DataBase. GetByNumeroAndLetraId",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return model;
        }
        public IEnumerable<IRotaModel> GetAllByLetraId(int letraId)
        {
            List<RotaModel> modelList = new List<RotaModel>();

            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            string query = "SELECT * FROM Rotas WHERE RotaLetraId = @RotaLetraId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("RotaLetraId", letraId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RotaModel model = new RotaModel();
                                model.RotaId = int.Parse(reader["RotaId"].ToString());
                                model.VendedoraId = int.Parse(reader["VendedoraId"].ToString());
                                model.RotaLetraId = int.Parse(reader["RotaLetraId"].ToString());

                                model.Numero = int.Parse(reader["Numero"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message,
                        "Não foi possível a busca pelas Rotas. GetAllByLetraId", e.HelpLink,
                        e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                return modelList;
            }
        }
        public RotaModel GetByVendedoraId(int vendedoraId)
        {
            RotaModel model = new RotaModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            bool recordFound = false;

            string query = "SELECT RotaId, Numero, VendedoraId, RotaLetraId " +
                           " FROM Rotas " +
                           " WHERE VendedoraId = @VendedoraId ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@VendedoraId", vendedoraId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            recordFound = reader.HasRows;
                            while (reader.Read())
                            {
                                model.RotaId = int.Parse(reader["RotaId"].ToString());
                                model.VendedoraId = int.Parse(reader["VendedoraId"].ToString());
                                model.RotaLetraId = int.Parse(reader["RotaLetraId"].ToString());
                                model.Numero = int.Parse(reader["Numero"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message,
                        "Não foi possível recuperar a rota da vendeddora. GetByVendedoraId",
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
        public RotaModel GetLastNumero(int rotaLetraId)
        {
            RotaModel model = new RotaModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();


            string query = "SELECT TOP 1 * FROM Rotas WHERE RotaLetraId = @RotaLetraId ORDER BY Numero DESC";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@RotaLetraId", rotaLetraId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    model.RotaId = int.Parse(reader["RotaId"].ToString());
                                    model.VendedoraId = int.Parse(reader["VendedoraId"].ToString());
                                    model.RotaLetraId = int.Parse(reader["RotaLetraId"].ToString());

                                    model.Numero = int.Parse(reader["Numero"].ToString());
                                }

                            }

                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, $"Falha ao buscar o último número da RotaLetra {rotaLetraId}",
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

        public void RefatoraRotas(IRotaModel rotaInicial, int vendedoraQueEntra, List<RotaModel> rotaList, IRotaModel rotaAtual)
        {

            int totalRotasAPercorrer = rotaList.Count(); //lista de rotas com a letra selecionada.
            int vendedoraEntrante = vendedoraQueEntra;
            int vendedoraSainte = 0;

            try
            {
                if (rotaInicial.Numero < rotaAtual.Numero)
                {
                    for (int i = rotaInicial.Numero; i <= rotaAtual.Numero; i++)
                    {

                        RotaModel proximaRota = GetByNumeroAndLetraId(i, rotaInicial.RotaLetraId);
                        if (proximaRota.VendedoraId != vendedoraQueEntra)
                        {
                            vendedoraSainte = proximaRota.VendedoraId; //guarda para colocar na próxima rota
                        }
                        else
                        {
                            vendedoraSainte = GetByNumeroAndLetraId(i + 1, rotaInicial.RotaLetraId).VendedoraId;
                        }
                        proximaRota.VendedoraId = vendedoraEntrante; //recebe vendedora entrante na rota
                        Update(proximaRota); //atualiza a rota com a vendedora entrante
                        vendedoraEntrante = vendedoraSainte; //vendedoraentrante passa a ser a vendedora da rota alterada.

                    }
                }
                else
                {
                    for (int i = rotaInicial.Numero; i >= rotaAtual.Numero; i--)
                    {
                        RotaModel proximaRota = GetByNumeroAndLetraId(i, rotaInicial.RotaLetraId);
                        if (proximaRota.VendedoraId != vendedoraQueEntra)
                        {
                            vendedoraSainte = proximaRota.VendedoraId; //guarda para colocar na próxima rota
                        }
                        else
                        {
                            vendedoraSainte = GetByNumeroAndLetraId(i + -1, rotaInicial.RotaLetraId).VendedoraId;
                        }
                        proximaRota.VendedoraId = vendedoraEntrante; //recebe vendedora entrante na rota
                        Update(proximaRota); //atualiza a rota com a vendedora entrante
                        vendedoraEntrante = vendedoraSainte;
                    } 
                }

            }
            catch (DataAccessException e)
            {
                dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível refatorar as rotas.", e.HelpLink, 0, e.StackTrace);
                throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
            }



        }

        private bool RecordExistsCheck(IRotaModel rotaModel, TypeOfExistenceCheck typeOfExistenceCheck, RequestType requestType)
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
                        cmd.CommandText = "SELECT COUNT(*) FROM Rotas WHERE Numero=@Numero AND RotaLetraId = @RotaLetraId";
                        cmd.Parameters.AddWithValue("@RotaLetraId", rotaModel.RotaLetraId);
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

        public void AlteraLetraId(int rotaId, int rotaLetraId)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE Rotas SET RotaLetraId = @RotaLetraId WHERE RotaId = @RotaId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@RotaLetraId", rotaLetraId));
                        cmd.Parameters.Add(new SqlParameter("@RotaId", rotaId));

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, $"Não foi possível alterar a Letra da Rota",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
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
