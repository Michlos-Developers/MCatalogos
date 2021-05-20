using CommonComponents;

using DomainLayer.Models.Catalogos;
using DomainLayer.Models.Fornecedores;

using ServiceLayer.Services.CatalogoServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo
{
    public class CatalogoRepository : ICatalogoRepository
    {
        private string _connectionString;

        enum TypeOfExistanceCheck
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

        public CatalogoRepository()
        {

        }

        public CatalogoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CatalogoModel Add(ICatalogoModel catalogoModel)
        {
            int idReturned = 0;
            CatalogoModel model = new CatalogoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "INSERTO INTO Catalogos " +
                           "(Nome, MargemPadraoVendedora, MargemPadraoDistribuidor, Ativo, FornecedorId) " +
                           "output INSERTED.CatalogoId " +
                           "VALUES (@Nome, @MargemPadraoVendedora, @MargemPadraoDistribuidor, @Ativo, @FornecedorId) ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {

                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Nome", catalogoModel.Nome);
                        cmd.Parameters.AddWithValue("@MargemPadraoVendedora", catalogoModel.MargemPadraoVendedora);
                        cmd.Parameters.AddWithValue("@MargemPadraoDistribuidor", catalogoModel.MargemPadraoDistribuidor);
                        cmd.Parameters.AddWithValue("@Ativo", catalogoModel.Ativo);
                        cmd.Parameters.AddWithValue("@FornecedorId", catalogoModel.FornecedorId);

                        try
                        {
                            idReturned = (int)cmd.ExecuteScalar();
                        }
                        catch (SqlException e)
                        {
                            dataAccessStatus.setValues("Error", false, e.Message, "Falha ao executar o comando Add para Catálogo", e.HelpLink,
                                e.ErrorCode, e.StackTrace);
                            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                        }

                        //CONFIRMAÇÃO DE INSERÇÃO DE DADOS
                        try
                        {

                        }
                        catch (DataAccessException e)
                        {
                            e.DataAccessStatusInfo.Status = "Error";
                            e.DataAccessStatusInfo.OperationSucceeded = false;
                            e.DataAccessStatusInfo.CustomMessage = "Falha ao buscar Catálogo no DataBase após a inserção.";
                            e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                            e.DataAccessStatusInfo.StackTrace = e.StackTrace;


                            throw e;
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Falha ao tentar inserir um Novo Catálogo", e.HelpLink, e.ErrorCode,
                        e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                model = GetById(idReturned);
                return model;

            }
        }


        public void Delete(ICatalogoModel catalogoModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "DELETE FROM Catalogos WHERE CatalogoId = @CatalogoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@CatalogoId", catalogoModel.CatalogoId);

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "FAlha ao tentar delatar Catálogo", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<ICatalogoModel> GetAll()
        {
            List<CatalogoModel> modelList = new List<CatalogoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            string query = "SELECT * FROM Catalogos";

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
                                CatalogoModel model = new CatalogoModel();

                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());
                                model.Nome = reader["Nome"].ToString();
                                model.MargemPadraoVendedora = float.Parse(reader["MargemPadraoVendedora"].ToString());
                                model.MargemPadraoDistribuidor = float.Parse(reader["MargemPadraoDistribuidor"].ToString());
                                model.Ativo = bool.Parse(reader["Ativo"].ToString());
                                model.FornecedorId = int.Parse(reader["FornecedorId"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível gerar a lista de Catálogos do DataBase", e.HelpLink,
                        e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus) ;
                }
                finally
                {
                    connection.Close();
                }
            }
            return modelList;
        }

        public IEnumerable<ICatalogoModel> GetByFornecedorId(int fornecedorId)
        {
            List<CatalogoModel> modelList = new List<CatalogoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM Catalogos WHERE FornecedorId = @FornecedorId";

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
                                CatalogoModel model = new CatalogoModel();

                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());
                                model.Nome = reader["Nome"].ToString();
                                model.MargemPadraoVendedora = float.Parse(reader["MargemPadraoVendedora"].ToString());
                                model.MargemPadraoDistribuidor = float.Parse(reader["MargemPadraoDistribuidor"].ToString());
                                model.Ativo = bool.Parse(reader["Ativo"].ToString());
                                model.FornecedorId = int.Parse(reader["FornecedorId"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível gerar a lista de catálogos.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                return modelList;
            }
        }

        public CatalogoModel GetById(int id)
        {
            CatalogoModel model = new CatalogoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT CatalogoId, Nome, MargemPadraoVendedora, MargemPadraoDistribuidor, Ativo, FornecedorId " +
                           "FROM Catalogos " +
                           "WHERE CatalogoId = @CatalogoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@CatalogoId", id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());
                                model.Nome = reader["Nome"].ToString();
                                model.MargemPadraoVendedora = float.Parse(reader["MargemPadraoVendedora"].ToString());
                                model.MargemPadraoDistribuidor = float.Parse(reader["MargemPadraoDistribuidor"].ToString());
                                model.Ativo = bool.Parse(reader["Ativo"].ToString());
                                model.FornecedorId = int.Parse(reader["FornecedorId"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível buscar o Catálogo no DataBase.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return model;
        }

        public void Update(ICatalogoModel catalogoModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE Catalogos " +
                           "SET Nome = @Nome, MargemPadraoVendedora = @MargemPadraoVendedora, MargemPadraoDistribuidor = @MargemPadraoDistribuidor " +
                           "Ativo = @Ativo, FornecedorId = FornecedorId " +
                           "WHERE CatalogoId = @CatalogoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@CatalogoId", catalogoModel.CatalogoId);
                        cmd.Parameters.AddWithValue("@Nome", catalogoModel.Nome);
                        cmd.Parameters.AddWithValue("@MargemPadraoVendedora", catalogoModel.MargemPadraoVendedora);
                        cmd.Parameters.AddWithValue("@MargemPadraoDistribuidor", catalogoModel.MargemPadraoDistribuidor);
                        cmd.Parameters.AddWithValue("@Ativo", catalogoModel.Ativo);
                        cmd.Parameters.AddWithValue("@FornecedorId", catalogoModel.FornecedorId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível atualizar o Catálogo.", e.HelpLink, e.ErrorCode, e.StackTrace);
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
