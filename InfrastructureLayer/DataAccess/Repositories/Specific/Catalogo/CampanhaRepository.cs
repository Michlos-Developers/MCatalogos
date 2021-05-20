using CommonComponents;

using DomainLayer.Models.Catalogos;

using ServiceLayer.Services.CatalogoServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo
{
    public class CampanhaRepository : ICampanhaRepository
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
        public CampanhaRepository()
        {

        }

        public CampanhaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CampanhaModel Add(ICampanhaModel campanhaModel)
        {
            int idReturned = 0;
            CampanhaModel model = new CampanhaModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "INSERTO INTO Campanhas " +
                           "(Nome, DataLancamento, DataEncerramento, Ativa, CatalogoId) " +
                           "output INSERTED.CampanhaId " +
                           "VALUES (@Nome, @DataLancamento, @DataEncerramento, @Ativa, @CatalogoId)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Nome", model.Nome);
                        cmd.Parameters.AddWithValue("@DataLancamento", model.DataLancamento);
                        cmd.Parameters.AddWithValue("@DataEncerramento", model.DataEncerramento);
                        cmd.Parameters.AddWithValue("@Ativa", model.Ativa);
                        cmd.Parameters.AddWithValue("@CatalogoId", model.CatalogoId);

                        idReturned = (int)cmd.ExecuteScalar();
                    }

                    
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Falha ao tentar inserir uma nova Campanha",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
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

        public void Delete(ICampanhaModel campanhaModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "DELETE FROM Campanhas WHERE CampanhaId = @CampanhaId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@CampanhaId", campanhaModel.CampanhaId);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Falha ao tentar apagar Campanha", e.HelpLink,
                        e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<ICampanhaModel> GetAll()
        {
            List<CampanhaModel> modelList = new List<CampanhaModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM Campanhas";

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
                                CampanhaModel model = new CampanhaModel();

                                model.CampanhaId = int.Parse(reader["CampanhaId"].ToString());
                                model.Nome = reader["Nome"].ToString();
                                model.DataLancamento = DateTime.Parse(reader["DataLancamento"].ToString());
                                model.DataEncerramento = DateTime.Parse(reader["DataEncerramento"].ToString());
                                model.Ativa = int.Parse(reader["Ativa"].ToString()) == 1 ? true : false;
                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível gerar a lista de Campanhas",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                return modelList;
            }
        }

        public IEnumerable<ICampanhaModel> GetByCatalogoId(int catalogoId)
        {
            List<CampanhaModel> modelList = new List<CampanhaModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM Campanhas " +
                           "WHERE CatalogoId = @CatalogoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@CatalogoId", catalogoId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            CampanhaModel model = new CampanhaModel();
                            model.CampanhaId = int.Parse(reader["CampanhaId"].ToString());
                            model.Nome = reader["Nome"].ToString();
                            model.DataLancamento = DateTime.Parse(reader["DataLancamento"].ToString());
                            model.DataEncerramento = DateTime.Parse(reader["DataEncerramento"].ToString());
                            model.Ativa = int.Parse(reader["Ativa"].ToString()) == 1 ? true : false;
                            model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());

                            modelList.Add(model);
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível gerar a Lista de Campanhas do Catalogo selecionado",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                return modelList;
            }

        }

        public CampanhaModel GetById(int campanhaId)
        {
            CampanhaModel model = new CampanhaModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT CampanhaId, Nome, DataLancamento, DataEncerramenot, Ativa, CatalogoId " +
                           "FROM Campanhas WHERE CampanhaId = @CampanhaId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@CampanhaId", campanhaId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            
                            while (reader.Read())
                            {
                                model.CampanhaId = int.Parse(reader["CampanhaId"].ToString());
                                model.Nome = reader["Nome"].ToString();
                                model.DataLancamento = DateTime.Parse(reader["DataLancamento"].ToString());
                                model.DataEncerramento = DateTime.Parse(reader["DataEncerramento"].ToString());
                                model.Ativa = int.Parse(reader["Ativa"].ToString()) == 1 ? true : false;
                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, $"Não foi possível buscar a Campanha pelo Id {campanhaId}",
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

        public void Update(ICampanhaModel campanhaModel)
        {
            //CampanhaModel model = new CampanhaModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE Campanhas SET " +
                           "Nome = @Nome, DataLancamento = @DataLancamento, DataEncerramento = @DataEncerramento, " +
                           "Ativa = @Ativa, CatalogoId = @CatalogoId " +
                           "WHERE CampanhaId = @CampanhaId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@CampanhaId", campanhaModel.CampanhaId);
                        cmd.Parameters.AddWithValue("@Nome", campanhaModel.Nome);
                        cmd.Parameters.AddWithValue("@DataLancamento", campanhaModel.DataLancamento);
                        cmd.Parameters.AddWithValue("@DataLancamento", campanhaModel.DataLancamento);
                        cmd.Parameters.AddWithValue("@DataEncerramento", campanhaModel.DataEncerramento);
                        cmd.Parameters.AddWithValue("@Ativa", campanhaModel.Ativa);
                        cmd.Parameters.AddWithValue("@CatalogoId", campanhaModel.CatalogoId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível atualizar os dados da Campanha selecionada",
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
