using CommonComponents;

using DomainLayer.Models.TitulosReceber;

using ServiceLayer.Services.HistoricoTituloReceberServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.TituloReceber
{
    public class HistoricoTituloReceberRepository : IHistoricoTituloReceberRepository
    {
        private string _connectionString;
        public HistoricoTituloReceberRepository()
        {

        }

        public HistoricoTituloReceberRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IHistoricoTituloReceberModel Add(IHistoricoTituloReceberModel historico)
        {
            int idReturned = 0;
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " INSERT INTO HIstoricosTitulosReceber " +
                           " (TituloId, DataRegistro, ValorRegistrado, Descricao)" +
                           " OUTPUT INSERTED.HIstoricoId " +
                           " VALUES" +
                           " (@TituloId, @DataRegistro, @ValorRegistrado, @Descricao) ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@TituloId", historico.TituloId);
                        cmd.Parameters.AddWithValue("@DataRegistro", historico.DataRegistro);
                        cmd.Parameters.AddWithValue("@ValorRegistrado", historico.ValorRegistrado);
                        cmd.Parameters.AddWithValue("@Descricao", historico.Descricao);

                        idReturned = (int)cmd.ExecuteScalar();


                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registrar o histórico do Título", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

            }
            historico.HistoricoId = idReturned;
            return historico;
        }

        public IEnumerable<IHistoricoTituloReceberModel> GetAllByTitulo(ITituloReceberModel titulo)
        {
            List<HistoricoTituloReceberModel> modelList = new List<HistoricoTituloReceberModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT * FROM HistoricosTitulosReceber WHERE TituloId = @TituloId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@TituloId", titulo.TituloId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            HistoricoTituloReceberModel model = new HistoricoTituloReceberModel();
                            model.HistoricoId = int.Parse(reader["HistoricoId"].ToString());
                            model.TituloId = int.Parse(reader["TituloId"].ToString());
                            model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                            model.ValorRegistrado = double.Parse(reader["ValorRegistrado"].ToString());
                            model.Descricao = reader["Descricao"].ToString();

                            modelList.Add(model);
                        }

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de históricos do título", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

            }
            return modelList;
        }

        public IHistoricoTituloReceberModel GetById(int historicoId)
        {
            HistoricoTituloReceberModel model = new HistoricoTituloReceberModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT * FROM HistoricosTitulosReceber WHERE HistoricoId = @HistoricoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@HIstoricoId", historicoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            model.HistoricoId = int.Parse(reader["HistoricoId"].ToString());
                            model.TituloId = int.Parse(reader["TituloId"].ToString());
                            model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                            model.ValorRegistrado = double.Parse(reader["ValorRegistrado"].ToString());
                            model.Descricao = reader["Descricao"].ToString();

                            
                        }

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Histórico pelo Id", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

            }
            return model;
        }
    }
}
