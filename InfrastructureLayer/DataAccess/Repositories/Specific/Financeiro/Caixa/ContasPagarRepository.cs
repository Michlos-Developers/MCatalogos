using CommonComponents;

using DomainLayer.Models.Financeiro.Caixa.ContasPagar;
using DomainLayer.Models.Financeiro.Caixa.Enums;
using DomainLayer.Models.TitulosPagar;

using ServiceLayer.Services.FinanceiroServices.CaixaServices.ContasPagar;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Financeiro.Caixa
{
    public class ContasPagarRepository : IContasPagarRepository
    {
        private string _connectionString;
        public ContasPagarRepository()
        {

        }

        public ContasPagarRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ContasPagarModel Add(IContasPagarModel contasPagar)
        {
            int idReturned = 0;
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "INSERT INTO ContasPagar " +
                           " (ProvisionamentoId, OrigemId, TipoMovimentacaoId, ValorPago) " +
                           " OUTPUT INSERTED.ContasPagarId " +
                           " VALUES " +
                           " (@ProvisionamentoId, @OrigemId, @TipoMovimentacaoId, @ValorPago) ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@ProvisionamentoId", contasPagar.ProvisionamentoId);
                        cmd.Parameters.AddWithValue("@OrigemId", contasPagar.OrigemId);
                        cmd.Parameters.AddWithValue("@TipoMovimentacaoId", contasPagar.TipoMovimentacao);
                        cmd.Parameters.AddWithValue("@ValorPago", contasPagar.ValorPago);

                        idReturned = (int)cmd.ExecuteScalar();

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registrar o ContasPagar", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                ContasPagarModel returnedModel = new ContasPagarModel();
                returnedModel = GetById(idReturned);
                return returnedModel;
            }
        }

        public void CancelaRegistro(IContasPagarModel contasPagar)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " UPDATE ContasPagar SET" +
                           " Cancelado = @Cancelado " +
                           " WHERE ContasPagarId = @ContasPagarId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@ContasPagarId", contasPagar.ContasPagarId);
                        cmd.Parameters.AddWithValue("@Cancelado", contasPagar.Cancelado);

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível cancelar o registro de ContasPagar", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<ContasPagarModel> GetAllByData(DateTime dataRegistro)
        {
            List<ContasPagarModel> modelList = new List<ContasPagarModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT " +
                           " ContasPagarId, DataRegistro, ProvisionamentoId, OrigemId, TipoMovimentacaoId, ValorPago, Cancelado " +
                           " WHERE DataRegistro = @DataRegistro ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.Add(new SqlParameter("@DataRegistro", dataRegistro));


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContasPagarModel model = new ContasPagarModel();

                                model.ContasPagarId = int.Parse(reader["ContasPagarId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ProvisionamentoId = int.Parse(reader["ProvisionamentoId"].ToString());
                                model.OrigemId = int.Parse(reader["OrigemId"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.ValorPago = double.Parse(reader["ValorPago"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar lista de ContasPagar por Data", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public IEnumerable<ContasPagarModel> GetAllByMonthAndYear(int month, int year)
        {
            List<ContasPagarModel> modelList = new List<ContasPagarModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT " +
                           " ContasPagarId, DataRegistro, ProvisionamentoId, OrigemId, TipoMovimentacaoId, ValorPago, Cancelado " +
                           " WHERE MONTH(DataRegistro) = @Month" +
                           " AND YEAR(DataRegsitro) = @Year";

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
                                ContasPagarModel model = new ContasPagarModel();

                                model.ContasPagarId = int.Parse(reader["ContasPagarId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ProvisionamentoId = int.Parse(reader["ProvisionamentoId"].ToString());
                                model.OrigemId = int.Parse(reader["OrigemId"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.ValorPago = double.Parse(reader["ValorPago"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar lista de ContasPagar por Data", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public IEnumerable<ContasPagarModel> GetAllByOrigem(ParcelaTituloPagar origem)
        {
            List<ContasPagarModel> modelList = new List<ContasPagarModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT " +
                           " ContasPagarId, DataRegistro, ProvisionamentoId, OrigemId, TipoMovimentacaoId, ValorPago, Cancelado " +
                           " WHERE OrigemId = @OrigemId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@OrigemId", origem.ParcelaId);


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ContasPagarModel model = new ContasPagarModel();

                                model.ContasPagarId = int.Parse(reader["ContasPagarId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ProvisionamentoId = int.Parse(reader["ProvisionamentoId"].ToString());
                                model.OrigemId = int.Parse(reader["OrigemId"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.ValorPago = double.Parse(reader["ValorPago"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar lista de ContasPagar por Data", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public ContasPagarModel GetById(int contasPagarId)
        {
            ContasPagarModel model = new ContasPagarModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT " +
                           " ContasPagarId, DataRegistro, ProvisionamentoId, OrigemId, TipoMovimentacaoId, ValorPago, Cancelado " +
                           " WHERE ContasPagarId = @ContasPagarId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.Add(new SqlParameter("@ContasPagarId", contasPagarId));


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                model.ContasPagarId = int.Parse(reader["ContasPagarId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ProvisionamentoId = int.Parse(reader["ProvisionamentoId"].ToString());
                                model.OrigemId = int.Parse(reader["OrigemId"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.ValorPago = double.Parse(reader["ValorPago"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar lista de ContasPagar por Data", e.HelpLink, e.ErrorCode, e.StackTrace);
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
