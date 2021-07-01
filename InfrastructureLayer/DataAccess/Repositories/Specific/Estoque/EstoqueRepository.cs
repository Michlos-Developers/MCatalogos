using CommonComponents;

using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Estoques;
using DomainLayer.Models.Produtos;

using ServiceLayer.Services.EstoqueServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Estoque
{
    public class EstoqueRepository : IEstoqueRepository
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
            ComfirmDelete
        }

        public EstoqueRepository()
        {

        }

        public EstoqueRepository(string connectionString)
        {
            _connectionString = connectionString;
        }



        public EstoqueModel Add(IEstoqueModel estoqueModel)
        {
            int idReturned = 0;
            EstoqueModel returnedEstoque = new EstoqueModel();

            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            string query = "INSERT INTO Estoques (CatalogoId, ProdutoId, CampanhaId, ValorCompra, ValorCampanhaAtual, Quantidade) " +
                           " OUTPUT INSERTED.EstoqueId " +
                           " VALUES (@CatalogoId, @ProdutoId, @CampanhaId, @ValorCompra, @ValorCampanhaAtual, @Quantidade)";


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        try
                        {
                            REcordExistCheck(estoqueModel, TypeOfExistenceCheck.NotExistInDb, RequestType.Add);

                            cmd.Prepare();
                            cmd.Parameters.AddWithValue("@CatalogoId", estoqueModel.CatalogoId);
                            cmd.Parameters.AddWithValue("@ProdutoId", estoqueModel.ProdutoId);
                            cmd.Parameters.AddWithValue("@CampanhaId", estoqueModel.CampanhaId);
                            cmd.Parameters.AddWithValue("@ValorCompra", estoqueModel.ValorCompra);
                            cmd.Parameters.AddWithValue("@ValorCampanhaAtual", estoqueModel.ValorCampanhaAtual);
                            cmd.Parameters.AddWithValue("@Quantidade", estoqueModel.Quantidade);

                            try
                            {
                                idReturned = (int)cmd.ExecuteScalar();
                            }
                            catch (SqlException e)
                            {
                                dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                           customMessage: "Não foi possível adicionar EstoqueModel", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                                throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                            }
                        }
                        catch (DataAccessException ex)
                        {
                            ex.DataAccessStatusInfo.CustomMessage = "Estoque não pode ser adicionar pois já existe esse produto no estoque.";
                            ex.DataAccessStatusInfo.ExceptionMessage = ex.Message;
                            ex.DataAccessStatusInfo.StackTrace = ex.StackTrace;
                            throw ex;
                        }


                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Falha no Sistema", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Não foi possível adicionar Estoque. Could not open a database connection", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            returnedEstoque = GetById(idReturned);
            return returnedEstoque;
        }

        public void Update(IEstoqueModel estoqueModel)
        {
            int result = -1;

            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            string query = "UPDATE Estoques " +
                           "SET CatalogoId = @CatalogoId, ProdutoId = @ProdutoId, CampanhaId = @CampanhaId, ValorCompra = @ValorCompra, " +
                           "ValorCampanhaAtual = @ValorCampanhaAtual, Quantidade = @Quantidade " +
                           "WHERE EstoqueId = @EstoqueId ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        try
                        {
                            REcordExistCheck(estoqueModel, TypeOfExistenceCheck.NotExistInDb, RequestType.Update);

                            cmd.Prepare();
                            cmd.Parameters.AddWithValue("@EstoqueId", estoqueModel.EstoqueId);
                            cmd.Parameters.AddWithValue("@CatalogoId", estoqueModel.CatalogoId);
                            cmd.Parameters.AddWithValue("@ProdutoId", estoqueModel.ProdutoId);
                            cmd.Parameters.AddWithValue("@CampanhaId", estoqueModel.CampanhaId);
                            cmd.Parameters.AddWithValue("@ValorCompra", estoqueModel.ValorCompra);
                            cmd.Parameters.AddWithValue("@ValorCampanhaAtual", estoqueModel.ValorCampanhaAtual);
                            cmd.Parameters.AddWithValue("@Quantidade", estoqueModel.Quantidade);

                            try
                            {
                                result = cmd.ExecuteNonQuery();
                            }
                            catch (SqlException e)
                            {

                                dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                           customMessage: "Unable to Execute update Estoque Model", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                                throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                            }
                        }
                        catch (DataAccessException ex)
                        {
                            ex.DataAccessStatusInfo.CustomMessage = "EstoqueModel could not be updated becouse it is not in the database.";
                            ex.DataAccessStatusInfo.ExceptionMessage = ex.Message;
                            ex.DataAccessStatusInfo.StackTrace = ex.StackTrace;
                            throw ex;
                        }


                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Não foi possível atualizar o Estoque. Could not open a database connection", helpLink: e.HelpLink,
                                   errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {

                    connection.Close();
                }


            }
        }

        public void Delete(IEstoqueModel estoqueModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "DELETE FROM Estoque WHERE EstoqueId = @EstoqueId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    if (estoqueModel.Quantidade > 0)
                    {
                        throw new Exception("Produto possui quantidade em estoque e não pode ser excluído");
                    }


                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        try
                        {
                            REcordExistCheck(estoqueModel, TypeOfExistenceCheck.ExistInDb, RequestType.Delete);

                            cmd.Prepare();
                            cmd.Parameters.AddWithValue("@EstoqueId", estoqueModel.EstoqueId);

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
                        }
                        catch (DataAccessException ex)
                        {
                            ex.DataAccessStatusInfo.CustomMessage = "Estoque model could not be deleted becouse it could not be found int the database.";
                            ex.DataAccessStatusInfo.ExceptionMessage = ex.Message;
                            ex.DataAccessStatusInfo.StackTrace = ex.StackTrace;
                            throw ex;
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                    customMessage: "Unable to Delete EstoqueModel. Could not open a database connection", helpLink: e.HelpLink, errorCode: e.ErrorCode, stackTrace: e.StackTrace);


                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IEstoqueModel> GetAll()
        {
            List<EstoqueModel> estoqueModelList = new List<EstoqueModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM Estoques";
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
                                EstoqueModel model = new EstoqueModel();

                                model.EstoqueId = int.Parse(reader["EstoqueId"].ToString());
                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());
                                model.CampanhaId = int.Parse(reader["CampanhaId"].ToString());
                                model.ProdutoId = int.Parse(reader["ProdutoId"].ToString());
                                model.ValorCompra = float.Parse(reader["ValorCompra"].ToString());
                                model.ValorCampanhaAtual = float.Parse(reader["ValorCampanhaAtual"].ToString());
                                model.Quantidade = int.Parse(reader["Quantidade"].ToString());

                                estoqueModelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unable to get Estoque Model list from database", helpLink: e.HelpLink,
                                   errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                return estoqueModelList;
            }
        }

        public IEnumerable<IEstoqueModel> GetAllByCatalogoCampanha(ICatalogoModel catalogoModel, ICampanhaModel campanhaModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            List<EstoqueModel> estoqueModelList = new List<EstoqueModel>();
            string query = "SELECT * FROM Estoques WHERE CatalogoId = @CatalogoId AND CampanhaId = @CampanhaId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@CatalogoId", catalogoModel.CatalogoId);
                        cmd.Parameters.AddWithValue("@CampanhaId", campanhaModel.CampanhaId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EstoqueModel model = new EstoqueModel();

                                model.EstoqueId = int.Parse(reader["EstoqueId"].ToString());
                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());
                                model.CampanhaId = int.Parse(reader["CampanhaId"].ToString());
                                model.ProdutoId = int.Parse(reader["ProdutoId"].ToString());
                                model.ValorCompra = float.Parse(reader["ValorCompra"].ToString());
                                model.ValorCampanhaAtual = float.Parse(reader["ValorCampanhaAtual"].ToString());
                                model.Quantidade = int.Parse(reader["Quantidade"].ToString());

                                estoqueModelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unable to get Estoque Model list from database", helpLink: e.HelpLink,
                                   errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return estoqueModelList;
            }
        }

        public IEnumerable<IEstoqueModel> GetAllByCatalogo(ICatalogoModel catalogoModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            List<EstoqueModel> estoqueModelList = new List<EstoqueModel>();
            string query = "SELECT * FROM Estoques WHERE CatalogoId = @CatalogoId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@CatalogoId", catalogoModel.CatalogoId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EstoqueModel model = new EstoqueModel();

                                model.EstoqueId = int.Parse(reader["EstoqueId"].ToString());
                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());
                                model.CampanhaId = int.Parse(reader["CampanhaId"].ToString());
                                model.ProdutoId = int.Parse(reader["ProdutoId"].ToString());
                                model.ValorCompra = float.Parse(reader["ValorCompra"].ToString());
                                model.ValorCampanhaAtual = float.Parse(reader["ValorCampanhaAtual"].ToString());
                                model.Quantidade = int.Parse(reader["Quantidade"].ToString());

                                estoqueModelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unable to get Estoque Model list from database", helpLink: e.HelpLink,
                                   errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return estoqueModelList;
            }
        }

        public EstoqueModel GetById(int estoqueId)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            EstoqueModel returnedEstoqueModel = new EstoqueModel();
            string query = "SELECT EstoqueId, CatalogoId, ProdutoId, CampanhaId, ValorCompra, ValorCampanhaAtual, Quantidade FROM Estoques " +
                           " WHERE EstoqueId = @EstoqueId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@EstoqueId", estoqueId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EstoqueModel model = new EstoqueModel();

                                model.EstoqueId = int.Parse(reader["EstoqueId"].ToString());
                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());
                                model.CampanhaId = int.Parse(reader["CampanhaId"].ToString());
                                model.ProdutoId = int.Parse(reader["ProdutoId"].ToString());
                                model.ValorCompra = float.Parse(reader["ValorCompra"].ToString());
                                model.ValorCampanhaAtual = float.Parse(reader["ValorCampanhaAtual"].ToString());
                                model.Quantidade = int.Parse(reader["Quantidade"].ToString());

                                returnedEstoqueModel = model;

                            }
                        }

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                                   customMessage: "Unable to get Estoque Model from database", helpLink: e.HelpLink,
                                   errorCode: e.ErrorCode, stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                return returnedEstoqueModel;
            }
        }

        public EstoqueModel GetByProduto(IProdutoModel produtoModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            EstoqueModel model = new EstoqueModel();
            string query = "SELECT EstoqueId, CatalogoId, ProdutoId, CampanhaId, ValorCompra, ValorCampanhaAtual, Quantidade " +
                            " FROM Estoques " +
                            " WHERE ProdutoId = @ProdutoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@ProdutoId", produtoModel.ProdutoId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.EstoqueId = int.Parse(reader["EstoqueId"].ToString());
                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());
                                model.CampanhaId = int.Parse(reader["CampanhaId"].ToString());
                                model.ProdutoId = int.Parse(reader["ProdutoId"].ToString());
                                model.ValorCompra = float.Parse(reader["ValorCompra"].ToString());
                                model.ValorCampanhaAtual = float.Parse(reader["ValorCampanhaAtual"].ToString());
                                model.Quantidade = int.Parse(reader["Quantidade"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Unable to get Estoque By Produto", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                return model;
            }
        }


        private bool REcordExistCheck(IEstoqueModel estoqueModel, TypeOfExistenceCheck typeOfExistenceCheck, RequestType requestType)
        {
            Int32 recordsFoundCount = 0;
            bool RecordExistsCheckPassed = true;
            string query = "";

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

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Prepare();

                    if ((requestType == RequestType.Add) || (requestType == RequestType.ConfirmAdd))
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM Estoques WHERE ProdutoId = @ProdutoId";
                        cmd.Parameters.AddWithValue("@ProdutoId", estoqueModel.ProdutoId);
                    }
                    else if ((requestType == RequestType.Update) || (requestType == RequestType.ComfirmDelete) || (requestType == RequestType.Delete))
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM Estoques WHERE EstoqueId = @EstoqueId";
                        cmd.Parameters.AddWithValue("@EstoqueId", estoqueModel.EstoqueId);
                    }

                    try
                    {
                        recordsFoundCount = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    }
                    catch (SqlException e)
                    {
                        string msg = e.Message;
                        throw;
                    }

                    if ((typeOfExistenceCheck == TypeOfExistenceCheck.NotExistInDb) && (recordsFoundCount > 0))
                    {
                        dataAccessStatus.Status = "Error";
                        RecordExistsCheckPassed = false;

                        throw new DataAccessException(dataAccessStatus);
                    }
                    else if ((typeOfExistenceCheck == TypeOfExistenceCheck.ExistInDb) && (recordsFoundCount == 0))
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
    }
}
