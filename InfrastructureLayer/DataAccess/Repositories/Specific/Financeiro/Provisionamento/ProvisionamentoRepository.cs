using CommonComponents;

using DomainLayer.Models.Financeiro.Caixa.Enums;
using DomainLayer.Models.Financeiro.Provisionamento;

using ServiceLayer.Services.FinanceiroServices.ProvisionamentoServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Financeiro.Provisionamento
{
    public class ProvisionamentoRepository : IProvisionamentoRepository
    {
        private string _connectionString;
        public ProvisionamentoRepository()
        {

        }

        public ProvisionamentoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region SETTERS

        public ProvisionamentoModel AddValue(IProvisionamentoModel provisionamento)
        {
            int idReturned = 0;
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " INSERT INTO Provisionamento " +
                           " (SaldoAnterior, SaldoAtual, ValorProvisionado, TipoMovimentacaoId, OrigemId) " +
                           " OUTPUT INSERTED.ProvisionamentoId" +
                           " VALUES" +
                           " (@SaldoAnterior, @SaldoAtual, @ValorProvisionado, @TipoMovimentacaoId, @OrigemId) ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@SaldoAnterior", provisionamento.SaldoAnterior);
                        cmd.Parameters.AddWithValue("@SaldoAtual", provisionamento.SaldoAtual);
                        cmd.Parameters.AddWithValue("@ValorProvisionado", provisionamento.ValorProvisionado);
                        cmd.Parameters.AddWithValue("@TipoMovimentacaoId", provisionamento.TipoMovimentacao);
                        cmd.Parameters.AddWithValue("@OrigemId", provisionamento.OrigemId);
                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registrar o Provisionamento de Valor", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            ProvisionamentoModel returnedProvisionamento = new ProvisionamentoModel();
            returnedProvisionamento = GetById(idReturned);
            return returnedProvisionamento;
        }
        public void RemoveValue(IProvisionamentoModel provisionamento)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " INSERT INTO Provisionamento " +
                           " (SaldoAnterior, SaldoAtual, ValorProvisionado, TipoMovimentacaoId, DestinoId) " +
                           " VALUES" +
                           " (@SaldoAnterior, @SaldoAtual, @ValorProvisionado, @TipoMovimentacaoId, @DestinoId) ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@SaldoAnterior", provisionamento.SaldoAnterior);
                        cmd.Parameters.AddWithValue("@SaldoAtual", provisionamento.SaldoAtual);
                        cmd.Parameters.AddWithValue("@ValorProvisionado", provisionamento.ValorProvisionado);
                        cmd.Parameters.AddWithValue("@TipoMovimentacaoId", provisionamento.TipoMovimentacao);
                        cmd.Parameters.AddWithValue("@DestinoId", provisionamento.DestinoId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registrar o Deprovisionamento de Valor", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void CancelaRegistro(IProvisionamentoModel provisionamento)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " UPDATE Provisionamento SET " +
                           " Cancelado = @Cancelado " +
                           " WHERE" +
                           " ProvisionamentoId = @ProvisionamentoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@ProvisionamentoId", provisionamento.ProvisionamentoId);
                        cmd.Parameters.AddWithValue("@Cancelado", true);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível Cancelar o registro do Provisionamento de Valor", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        #endregion

        #region GETTERS

        public IEnumerable<ProvisionamentoModel> GetAll()
        {
            List<ProvisionamentoModel> modelList = new List<ProvisionamentoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT * FROM Provisionamento";

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
                                ProvisionamentoModel model = new ProvisionamentoModel();
                                model.ProvisionamentoId = int.Parse(reader["ProvisionamentoId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.SaldoAnterior = double.Parse(reader["SaldoAnterior"].ToString());
                                model.SaldoAtual = double.Parse(reader["SaldoAtual"].ToString());
                                model.ValorProvisionado = double.Parse(reader["ValorProvisionado"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.OrigemId = string.IsNullOrEmpty(reader["OrigemId"].ToString()) ? 0 : int.Parse(reader["OrigemId"].ToString());
                                model.DestinoId = string.IsNullOrEmpty(reader["DestinoId"].ToString()) ? 0 : int.Parse(reader["DestinoId"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista dos Provisionamentos registrados.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public IEnumerable<ProvisionamentoModel> GetAllByData(DateTime date)
        {
            List<ProvisionamentoModel> modelList = new List<ProvisionamentoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT * FROM Provisionamento " +
                           " WHERE DataRegistro = @DataRegistro";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@DataRegistro", date));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProvisionamentoModel model = new ProvisionamentoModel();
                                model.ProvisionamentoId = int.Parse(reader["ProvisionamentoId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.SaldoAnterior = double.Parse(reader["SaldoAnterior"].ToString());
                                model.SaldoAtual = double.Parse(reader["SaldoAtual"].ToString());
                                model.ValorProvisionado = double.Parse(reader["ValorProvisionado"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.OrigemId = string.IsNullOrEmpty(reader["OrigemId"].ToString()) ? 0 : int.Parse(reader["OrigemId"].ToString());
                                model.DestinoId = string.IsNullOrEmpty(reader["DestinoId"].ToString()) ? 0 : int.Parse(reader["DestinoId"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista dos Provisionamentos registrados.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public IEnumerable<ProvisionamentoModel> GetAllByMonthAndYear(int month, int year)
        {
            List<ProvisionamentoModel> modelList = new List<ProvisionamentoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT * FROM Provisionamento " +
                           " WHERE MONTH(DataRegistro) = @Month AND YEAR(DataRegistro) = @Year";

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
                                ProvisionamentoModel model = new ProvisionamentoModel();
                                model.ProvisionamentoId = int.Parse(reader["ProvisionamentoId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.SaldoAnterior = double.Parse(reader["SaldoAnterior"].ToString());
                                model.SaldoAtual = double.Parse(reader["SaldoAtual"].ToString());
                                model.ValorProvisionado = double.Parse(reader["ValorProvisionado"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.OrigemId = string.IsNullOrEmpty(reader["OrigemId"].ToString()) ? 0 : int.Parse(reader["OrigemId"].ToString());
                                model.DestinoId = string.IsNullOrEmpty(reader["DestinoId"].ToString()) ? 0 : int.Parse(reader["DestinoId"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista dos Provisionamentos registrados.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public ProvisionamentoModel GetById(int provisionamentoId)
        {
            ProvisionamentoModel model = new ProvisionamentoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT * FROM Provisionamento " +
                           " WHERE ProvisionamentoId = @ProvisionamentoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@ProvisionamentoId", provisionamentoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.ProvisionamentoId = int.Parse(reader["ProvisionamentoId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.SaldoAnterior = double.Parse(reader["SaldoAnterior"].ToString());
                                model.SaldoAtual = double.Parse(reader["SaldoAtual"].ToString());
                                model.ValorProvisionado = double.Parse(reader["ValorProvisionado"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.OrigemId = string.IsNullOrEmpty(reader["OrigemId"].ToString()) ? 0 : int.Parse(reader["OrigemId"].ToString());
                                model.DestinoId = string.IsNullOrEmpty(reader["DestinoId"].ToString()) ? 0 : int.Parse(reader["DestinoId"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Provisionamento pelo ID.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return model;
            }
        }

        #endregion

    }
}
