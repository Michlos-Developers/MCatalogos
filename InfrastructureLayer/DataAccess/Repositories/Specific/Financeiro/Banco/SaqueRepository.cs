using CommonComponents;

using DomainLayer.Models.Financeiro.Banco;
using DomainLayer.Models.Financeiro.Caixa.Enums;

using ServiceLayer.Services.FinanceiroServices.BancoServices.SaqueServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Financeiro.Banco
{
    public class SaqueRepository : ISaqueRepository
    {
        private string _connectionString;
        public SaqueRepository()
        {

        }

        public SaqueRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SaqueModel Add(ISaqueModel saqueModel)
        {
            int idReturned = 0;
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "INSERT INTO Saques " +
                           " (ContaId, TipoMovimentacaoId, ProvisionamentoId, ValorSaque)" +
                           " OUTPUT INSERTED.SaqueId" +
                           " VALUES" +
                           " (@ContaId, @TipoMovimentacaoId, @ProvisionamentoId, @ValorSaque) ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@ContaId", saqueModel.ContaId);
                        cmd.Parameters.AddWithValue("@TipoMovimentacaoId", saqueModel.TipoMovimentacao);
                        cmd.Parameters.AddWithValue("@ProvisionamentoId", saqueModel.ProvisionamentoId);
                        cmd.Parameters.AddWithValue("@ValorSaque", saqueModel.ValorSaque);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registrar Saque bancário", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

            SaqueModel returnedSaque = new SaqueModel();
            returnedSaque = GetById(idReturned);
            return returnedSaque;
        }

        public void CancelaRegistro(ISaqueModel saqueModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " UPDATE Saques SET " +
                           " Cancelado = @Cancelado" +
                           " WHERE" +
                           " SaqueId = @SaqueId ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.Add(new SqlParameter("@Cancelado", true));
                        cmd.Parameters.AddWithValue("@SaqueId", saqueModel.SaqueId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível Cancelar o registro do Saque", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<SaqueModel> GetAll()
        {
            List<SaqueModel> modelList = new List<SaqueModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT " +
                           " SaqueId, DataRegistro, ContaId, TipoMovimentacaoId, ProvisionamentoId, ValorSaque, Cancelado" +
                           " FROM Saques";

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
                                SaqueModel model = new SaqueModel();

                                model.SaqueId = int.Parse(reader["SaqueId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ContaId = int.Parse(reader["ContaId"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.ProvisionamentoId = int.Parse(reader["TipoMovimentacaoId"].ToString());
                                model.ValorSaque = double.Parse(reader["ValorSaque"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                                modelList.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista dos Saques registrados.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }

        }

        public IEnumerable<SaqueModel> GetAllByConta(ContaModel conta)
        {
            List<SaqueModel> modelList = new List<SaqueModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT " +
                           " SaqueId, DataRegistro, ContaId, TipoMovimentacaoId, ProvisionamentoId, ValorSaque, Cancelado" +
                           " FROM Saques " +
                           " WHERE ContaId = @ContaId";


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@ContaId", conta.ContaId);


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SaqueModel model = new SaqueModel();

                                model.SaqueId = int.Parse(reader["SaqueId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ContaId = int.Parse(reader["ContaId"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.ProvisionamentoId = int.Parse(reader["TipoMovimentacaoId"].ToString());
                                model.ValorSaque = double.Parse(reader["ValorSaque"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                                modelList.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista dos Saques registrados.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public IEnumerable<SaqueModel> GetAllByData(DateTime data)
        {
            List<SaqueModel> modelList = new List<SaqueModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT " +
                           " SaqueId, DataRegistro, ContaId, TipoMovimentacaoId, ProvisionamentoId, ValorSaque, Cancelado" +
                           " FROM Saques " +
                           " WHERE DataRegistro = @DataRegistro";


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.Add(new SqlParameter("@DataRegistro", data));


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SaqueModel model = new SaqueModel();

                                model.SaqueId = int.Parse(reader["SaqueId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ContaId = int.Parse(reader["ContaId"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.ProvisionamentoId = int.Parse(reader["TipoMovimentacaoId"].ToString());
                                model.ValorSaque = double.Parse(reader["ValorSaque"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                                modelList.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista dos Saques registrados.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public IEnumerable<SaqueModel> GetAllByDataAndConta(DateTime data, ContaModel conta)
        {
            List<SaqueModel> modelList = new List<SaqueModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT " +
                           " SaqueId, DataRegistro, ContaId, TipoMovimentacaoId, ProvisionamentoId, ValorSaque, Cancelado" +
                           " FROM Saques " +
                           " WHERE " +
                           " DataRegistro = @DataRegistro " +
                           " AND " +
                           " ContaId = @ContaId";


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@ContaId", conta.ContaId);
                        cmd.Parameters.Add(new SqlParameter("@DataRegistro", data));


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SaqueModel model = new SaqueModel();

                                model.SaqueId = int.Parse(reader["SaqueId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ContaId = int.Parse(reader["ContaId"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.ProvisionamentoId = int.Parse(reader["TipoMovimentacaoId"].ToString());
                                model.ValorSaque = double.Parse(reader["ValorSaque"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                                modelList.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista dos Saques registrados.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public IEnumerable<SaqueModel> GetAllByMonthAndYear(int month, int year)
        {
            List<SaqueModel> modelList = new List<SaqueModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT " +
                           " SaqueId, DataRegistro, ContaId, TipoMovimentacaoId, ProvisionamentoId, ValorSaque, Cancelado" +
                           " FROM Saques " +
                           " WHERE " +
                           " MONTH(DataRegistro) = @Month " +
                           " AND " +
                           " YEAR(DataRegistro) = @Year";


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.Add(new SqlParameter("@Month", month));
                        cmd.Parameters.Add(new SqlParameter("@Year", year));


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SaqueModel model = new SaqueModel();

                                model.SaqueId = int.Parse(reader["SaqueId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ContaId = int.Parse(reader["ContaId"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.ProvisionamentoId = int.Parse(reader["TipoMovimentacaoId"].ToString());
                                model.ValorSaque = double.Parse(reader["ValorSaque"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                                modelList.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista dos Saques registrados.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public IEnumerable<SaqueModel> GetAllByMonthYearConta(int month, int year, ContaModel conta)
        {
            List<SaqueModel> modelList = new List<SaqueModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT " +
                           " SaqueId, DataRegistro, ContaId, TipoMovimentacaoId, ProvisionamentoId, ValorSaque, Cancelado" +
                           " FROM Saques " +
                           " WHERE " +
                           " MONTH(DataRegistro) = @Month " +
                           " AND " +
                           " YEAR(DataRegistro) = @Year " +
                           " AND " +
                           " ContaId = @ContaId";


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.Add(new SqlParameter("@Month", month));
                        cmd.Parameters.Add(new SqlParameter("@Year", year));
                        cmd.Parameters.AddWithValue("@ContaId", conta.ContaId);


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SaqueModel model = new SaqueModel();

                                model.SaqueId = int.Parse(reader["SaqueId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ContaId = int.Parse(reader["ContaId"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.ProvisionamentoId = int.Parse(reader["TipoMovimentacaoId"].ToString());
                                model.ValorSaque = double.Parse(reader["ValorSaque"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                                modelList.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista dos Saques registrados.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public SaqueModel GetById(int saqueId)
        {
            SaqueModel model = new SaqueModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT " +
                           " SaqueId, DataRegistro, ContaId, TipoMovimentacaoId, ProvisionamentoId, ValorSaque, Cancelado" +
                           " FROM Saques " +
                           " WHERE " +
                           " SaqueId = @SaqueId";


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.Add(new SqlParameter("@SaqueId", saqueId));



                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                model.SaqueId = int.Parse(reader["SaqueId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ContaId = int.Parse(reader["ContaId"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.ProvisionamentoId = int.Parse(reader["TipoMovimentacaoId"].ToString());
                                model.ValorSaque = double.Parse(reader["ValorSaque"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());


                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista dos Saques registrados.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return model;
            }
        }
    }
}
