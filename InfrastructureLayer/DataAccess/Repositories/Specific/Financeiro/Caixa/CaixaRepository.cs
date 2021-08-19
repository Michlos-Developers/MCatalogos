using CommonComponents;

using DomainLayer.Models.Financeiro.Caixa;
using DomainLayer.Models.Financeiro.Caixa.Enums;

using ServiceLayer.Services.FinanceiroServices.CaixaServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Financeiro.Caixa
{
    public class CaixaRepository : ICaixaRepository
    {
        private string _connectionString;
        public CaixaRepository()
        {

        }

        public CaixaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region SETTERS
        public CaixaModel AddValue(ICaixaModel caixa)
        {
            int idReturned = 0;
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " INSERT INTO Caixa " +
                           " (SaldoAnterior, SaldoAtual, TipoMovimentacaoId, ValorRegistro, OrigemId) " +
                           " OUTPUT INSERTED.CaixaId " +
                           " VALUES " +
                           " (@SaldoAnterior, @SaldoAtual, @TipoMovimentacaoId, @ValorRegistro, @OrigemId) ";


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@SaldoAnterior", caixa.SaldoAnterior);
                        cmd.Parameters.AddWithValue("@SaldoAtual", caixa.SaldoAtual);
                        cmd.Parameters.AddWithValue("@TipoMovimentacaoId", caixa.TipoMovimentacao);
                        cmd.Parameters.AddWithValue("@ValorRegistro", caixa.ValorRegistro);
                        cmd.Parameters.AddWithValue("@OrigemId", caixa.OrigemId);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registrar valor no caixa", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                CaixaModel returnedCaixa = new CaixaModel();
                returnedCaixa = GetById(idReturned);

                return returnedCaixa;
            }
        }


        public CaixaModel RemoveValue(ICaixaModel caixa)
        {
            CaixaModel returnedModel = new CaixaModel();
            int idReturned = 0;
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " INSERT INTO Caixa " +
                           " (SaldoAnterior, SaldoAtual, TipoMovimentacaoId, ValorRegistro, DestinoId) " +
                           " OUTPUT INSERTED.CaixaId " +
                           " VALUES " +
                           " (@SaldoAnterior, @SaldoAtual, @TipoMovimentacaoId, @ValorRegistro, @DestinoId) ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@SaldoAnterior", caixa.SaldoAnterior);
                        cmd.Parameters.AddWithValue("@SaldoAtual", caixa.SaldoAtual);
                        cmd.Parameters.AddWithValue("@TipoMovimentacaoId", caixa.TipoMovimentacao);
                        cmd.Parameters.AddWithValue("@ValorRegistro", caixa.ValorRegistro);
                        cmd.Parameters.AddWithValue("@DestinoId", caixa.DestinoId);

                        idReturned = (int)cmd.ExecuteScalar();

                    }

                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registrar valor de saída do caixa", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            returnedModel = GetById(idReturned);
            return returnedModel;


        }

        public void CancelaRegistro(ICaixaModel caixa)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE Caixa SET" +
                            "Cancelado = @Cancelado" +
                            "WHERE CaixaId = @CaixaId ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@CaixaId", caixa.CaixaId);
                        cmd.Parameters.Add(new SqlParameter("@Cancelado", true));
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível Cancelar registro no Caixa", e.HelpLink, e.ErrorCode, e.StackTrace);
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
        public CaixaModel GetById(int caixaId)
        {
            CaixaModel model = new CaixaModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT CaixaId, DataRegistro, SaldoAnterior, SaldoAtual, TipoMovimentacaoId, ValorRegistro, OrigemId, DestinoId " +
                           " FROM Caixa " +
                           " WHERE CaixaId = @CaixaId ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@CaixaId", caixaId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.CaixaId = int.Parse(reader["CaixaId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.SaldoAnterior = double.Parse(reader["SaldoAnterior"].ToString());
                                model.SaldoAtual = double.Parse(reader["SaldoAtual"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.ValorRegistro = double.Parse(reader["ValorRegistro"].ToString());
                                model.OrigemId = string.IsNullOrEmpty(reader["OrigemId"].ToString()) ? 0 : int.Parse(reader["OrigemId"].ToString());
                                model.DestinoId = string.IsNullOrEmpty(reader["DestinoId"].ToString()) ? 0 : int.Parse(reader["DestinoId"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Caixa pelo Id", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return model;
            }
        }
        public IEnumerable<CaixaModel> GetAll()
        {
            List<CaixaModel> modelList = new List<CaixaModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT CaixaId, DataRegistro, SaldoAnterior, SaldoAtual, TipoMovimentacaoId, ValorRegistro, OrigemId, DestinoId " +
                           " FROM Caixa ";

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
                                CaixaModel model = new CaixaModel();
                                model.CaixaId = int.Parse(reader["CaixaId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.SaldoAnterior = double.Parse(reader["SaldoAnterior"].ToString());
                                model.SaldoAtual = double.Parse(reader["SaldoAtual"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.ValorRegistro = double.Parse(reader["ValorRegistro"].ToString());
                                model.OrigemId = string.IsNullOrEmpty(reader["OrigemId"].ToString()) ? 0 : int.Parse(reader["OrigemId"].ToString());
                                model.DestinoId = string.IsNullOrEmpty(reader["DestinoId"].ToString()) ? 0 : int.Parse(reader["DestinoId"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de movimentos do Caixa", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public IEnumerable<CaixaModel> GetAllByMonthAndYear(int month, int year)
        {
            List<CaixaModel> modelList = new List<CaixaModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT CaixaId, DataRegistro, SaldoAnterior, SaldoAtual, TipoMovimentacaoId, ValorRegistro OrigemId, DestinoId " +
                           " FROM Caixa " +
                           " WHERE MONTH(DataRegistro) = @Month AND YEAR(DataRegistro) = @Year ";
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
                                CaixaModel model = new CaixaModel();
                                model.CaixaId = int.Parse(reader["CaixaId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.SaldoAnterior = double.Parse(reader["SaldoAnterior"].ToString());
                                model.SaldoAtual = double.Parse(reader["SaldoAtual"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.ValorRegistro = double.Parse(reader["ValorRegistro"].ToString());
                                model.OrigemId = string.IsNullOrEmpty(reader["OrigemId"].ToString()) ? 0 : int.Parse(reader["OrigemId"].ToString());
                                model.DestinoId = string.IsNullOrEmpty(reader["DestinoId"].ToString()) ? 0 : int.Parse(reader["DestinoId"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Caixa pelo Id", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public CaixaModel GetLast()
        {
            CaixaModel model = new CaixaModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT TOP 1 CaixaId, DataRegistro, SaldoAnterior, SaldoAtual, TipoMovimentacaoId, ValorRegistro, OrigemId, DestinoId " +
                           " FROM Caixa " +
                           " WHERE CANCELADO = 0 " +
                           " ORDER BY CaixaId DESC";

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
                                model.CaixaId = int.Parse(reader["CaixaId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.SaldoAnterior = double.Parse(reader["SaldoAnterior"].ToString());
                                model.SaldoAtual = double.Parse(reader["SaldoAtual"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.ValorRegistro = double.Parse(reader["ValorRegistro"].ToString());
                                model.OrigemId = string.IsNullOrEmpty(reader["OrigemId"].ToString()) ? 0 : int.Parse(reader["OrigemId"].ToString());
                                model.DestinoId = string.IsNullOrEmpty(reader["DestinoId"].ToString()) ? 0 : int.Parse(reader["DestinoId"].ToString());

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de movimentos do Caixa", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return model;
            }
        }

        public double GetSaldo()
        {
            CaixaModel model = GetLast();
            return model.SaldoAtual;
        }

        #endregion

    }
}
