using CommonComponents;

using DomainLayer.Models.Financeiro.Banco;
using DomainLayer.Models.Financeiro.Caixa.Enums;

using ServiceLayer.Services.FinanceiroServices.BancoServices.DepositoServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Financeiro.conta
{
    public class DepositoRepository : IDepositoRepository
    {
        private string _connectionString;
        public DepositoRepository()
        {

        }

        public DepositoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region SETTERS

        public DepositoModel Add(IDepositoModel deposito)
        {
            int idReturned = 0;
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " INSERT INTO Depositos " +
                           " (ContaId, TipoMovimentacaoId, ProvisionamentoId, ValorDeposito)" +
                           " OUTPUT INSERTED.DepositoId" +
                           " VALUES" +
                           " (@ContaId, @TipoMovimentacaoId, @ProvisionamentoId, @ValorDeposito)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@ContaId", deposito.ContaId);
                        cmd.Parameters.AddWithValue("@TipoMovimentacaoId", deposito.TipoMovimentacao);
                        cmd.Parameters.AddWithValue("@ProvisionamentoId", deposito.ProvisionamentoId);
                        cmd.Parameters.AddWithValue("@ValorDeposito", deposito.ValorDeposito);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registrar o Depósito Bancário", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

            }
            DepositoModel returnedDeposito = new DepositoModel();
            returnedDeposito = GetById(idReturned);
            return returnedDeposito;
        }

        public void CancelaRegistro(IDepositoModel deposito)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " UPDATE Depositos SET " +
                           " Cancelado = @Cancelado" +
                           " WHERE DepositoId = @DepositoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@DepositoId", deposito.DepositoId);
                        cmd.Parameters.AddWithValue("@Cancelado", deposito.Cancelado);

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Depósito Bancário pelo ID", e.HelpLink, e.ErrorCode, e.StackTrace);
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

        public IEnumerable<DepositoModel> GetAll()
        {
            List<DepositoModel> modelList = new List<DepositoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT " +
                           " DepositoId, DataRegistro, ContaId, TipoMovimentacaoId, ProvisionamentoId, ValorDeposito, Cancelado" +
                           " FROM Depositos ";


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
                                DepositoModel model = new DepositoModel();

                                model.DepositoId = int.Parse(reader["DepositoId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ContaId = int.Parse(reader["ContaId"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                                modelList.Add(model);
                            }
                        }

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Depósitos Bancários", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;

            }
        }

        public IEnumerable<DepositoModel> GetAllByConta(ContaModel conta)
        {
            List<DepositoModel> modelList = new List<DepositoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT " +
                           " DepositoId, DataRegistro, ContaId, TipoMovimentacaoId, ProvisionamentoId, ValorDeposito, Cancelado" +
                           " FROM Depositos " +
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
                                DepositoModel model = new DepositoModel();

                                model.DepositoId = int.Parse(reader["DepositoId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ContaId = int.Parse(reader["ContaId"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                                modelList.Add(model);
                            }
                        }

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Depósitos Bancários pelo conta", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;

            }
        }

        public IEnumerable<DepositoModel> GetAllByData(DateTime data)
        {
            List<DepositoModel> modelList = new List<DepositoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT " +
                           " DepositoId, DataRegistro, ContaId, TipoMovimentacaoId, ProvisionamentoId, ValorDeposito, Cancelado" +
                           " FROM Depositos " +
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
                                DepositoModel model = new DepositoModel();

                                model.DepositoId = int.Parse(reader["DepositoId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ContaId = int.Parse(reader["ContaId"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                                modelList.Add(model);
                            }
                        }

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Depósitos Bancários por Data de Registro", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;

            }
        }

        public IEnumerable<DepositoModel> GetAllByDataAndConta(DateTime data, ContaModel conta)
        {
            List<DepositoModel> modelList = new List<DepositoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT " +
                           " DepositoId, DataRegistro, ContaId, TipoMovimentacaoId, ProvisionamentoId, ValorDeposito, Cancelado" +
                           " FROM Depositos " +
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
                                DepositoModel model = new DepositoModel();

                                model.DepositoId = int.Parse(reader["DepositoId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ContaId = int.Parse(reader["ContaId"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                                modelList.Add(model);
                            }
                        }

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Depósitos Bancários por Data de Registro", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;

            }
        }

        public IEnumerable<DepositoModel> GetAllByMonthAndYear(int month, int year)
        {
            List<DepositoModel> modelList = new List<DepositoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT " +
                           " DepositoId, DataRegistro, ContaId, TipoMovimentacaoId, ProvisionamentoId, ValorDeposito, Cancelado" +
                           " FROM Depositos " +
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
                                DepositoModel model = new DepositoModel();

                                model.DepositoId = int.Parse(reader["DepositoId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ContaId = int.Parse(reader["ContaId"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                                modelList.Add(model);
                            }
                        }

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Depósitos Bancários por Mes e Ano", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;

            }
        }

        public IEnumerable<DepositoModel> GetAllByMonthYearConta(int month, int year, ContaModel conta)
        {
            List<DepositoModel> modelList = new List<DepositoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT " +
                           " DepositoId, DataRegistro, ContaId, TipoMovimentacaoId, ProvisionamentoId, ValorDeposito, Cancelado" +
                           " FROM Depositos " +
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
                                DepositoModel model = new DepositoModel();

                                model.DepositoId = int.Parse(reader["DepositoId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ContaId = int.Parse(reader["ContaId"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                                modelList.Add(model);
                            }
                        }

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Depósitos Bancários por Mes e Ano do conta Especificado", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;

            }
        }


        public DepositoModel GetById(int depositoId)
        {
            DepositoModel model = new DepositoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT " +
                           " DepositoId, DataRegistro, ContaId, TipoMovimentacaoId, ProvisionamentoId, ValorDeposito, Cancelado" +
                           " FROM Depositos " +
                           " WHERE " +
                           " DepositoId = @DepositoId ";


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.Add(new SqlParameter("@DepositoId", depositoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                model.DepositoId = int.Parse(reader["DepositoId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ContaId = int.Parse(reader["ContaId"].ToString());
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                            }
                        }

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Depósitos Bancários por Mes e Ano do conta Especificado", e.HelpLink, e.ErrorCode, e.StackTrace);
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
