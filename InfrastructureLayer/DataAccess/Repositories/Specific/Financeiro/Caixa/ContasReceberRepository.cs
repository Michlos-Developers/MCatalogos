using CommonComponents;

using DomainLayer.Models.Financeiro.Caixa.ContasReceber;
using DomainLayer.Models.Financeiro.Caixa.Enums;
using DomainLayer.Models.TitulosReceber;

using ServiceLayer.Services.FinanceiroServices.CaixaServices.ContasReceber;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Financeiro.Caixa
{
    public class ContasReceberRepository : IContasReceberRepository
    {
        private string _connectionString;
        public ContasReceberRepository()
        {

        }

        public ContasReceberRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ContasReceberModel Add(ContasReceberModel contasReceber)
        {
            int idReturned = 0;
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " INSERT INTO ContasReceber " +
                           " (CaixaId, OrigemId, TipoMovimentacaoId, ValorRecebido)" +
                           " OUTPUT INSERTED.ContasReceberId" +
                           " VALUES" +
                           " (@CaixaId, @OrigemId, @TipoMovimentacaoId, @ValorRecebido)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@CaixaId", contasReceber.CaixaId);
                        cmd.Parameters.AddWithValue("@OrigemId", contasReceber.OrigemId);
                        cmd.Parameters.AddWithValue("@TipoMovimentacaoId", contasReceber.TipoMovimentacao);
                        cmd.Parameters.AddWithValue("@ValorRecebido", contasReceber.ValorRecebido);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registrar o Conta Recbida no Caixa", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            ContasReceberModel returnedModel = new ContasReceberModel();
            returnedModel = GetById(idReturned);
            return returnedModel;
        }

        public void CancelaRegistro(ContasReceberModel contasReceber)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " UPDATE ContasReber SET " +
                           " Cancelado = @Cancelado " +
                           " WHERE " +
                           " ContasReceberId = @ContasReceberId ";



            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@ContasReceberId", contasReceber.ContasReceberId);
                        cmd.Parameters.AddWithValue("@Cancelado", contasReceber.Cancelado);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível cancelar o registro de Conta Recebida do Caixa", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<ContasReceberModel> GetAll()
        {
            List<ContasReceberModel> modelList = new List<ContasReceberModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT " +
                           " ContasReceberId, DataRegistro, CaixaId, OrigemId, TipoMovimentacaoId, ValorRecebido, Cancelado " +
                           " FROM ContasReceber ";



            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            ContasReceberModel model = new ContasReceberModel();

                            model.ContasReceberId = int.Parse(reader["ContasReceberId"].ToString());
                            model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                            model.CaixaId = int.Parse(reader["CaixaId"].ToString());
                            model.OrigemId = int.Parse(reader["OrigemId"].ToString());
                            model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TimpoMovimentacaoId"].ToString());
                            model.ValorRecebido = double.Parse(reader["ValorRecebido"].ToString());
                            model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                            modelList.Add(model);
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de ContasRecebidas", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public IEnumerable<ContasReceberModel> GetAllByData(DateTime dataRegistro)
        {
            List<ContasReceberModel> modelList = new List<ContasReceberModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT " +
                           " ContasReceberId, DataRegistro, CaixaId, OrigemId, TipoMovimentacaoId, ValorRecebido, Cancelado " +
                           " FROM ContasReceber " +
                           " WHERE DataRegistro = @DataRegistro";



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
                            ContasReceberModel model = new ContasReceberModel();

                            model.ContasReceberId = int.Parse(reader["ContasReceberId"].ToString());
                            model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                            model.CaixaId = int.Parse(reader["CaixaId"].ToString());
                            model.OrigemId = int.Parse(reader["OrigemId"].ToString());
                            model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TimpoMovimentacaoId"].ToString());
                            model.ValorRecebido = double.Parse(reader["ValorRecebido"].ToString());
                            model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                            modelList.Add(model);
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de ContasRecebidas por Data", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public IEnumerable<ContasReceberModel> GetAllByMonthAndYear(int month, int year)
        {
            List<ContasReceberModel> modelList = new List<ContasReceberModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT " +
                           " ContasReceberId, DataRegistro, CaixaId, OrigemId, TipoMovimentacaoId, ValorRecebido, Cancelado " +
                           " FROM ContasReceber " +
                           " WHERE MONTH(DataRegistro) = @Month" +
                           " AND YEAR(DataRegistro) = @Year";



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
                            ContasReceberModel model = new ContasReceberModel();

                            model.ContasReceberId = int.Parse(reader["ContasReceberId"].ToString());
                            model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                            model.CaixaId = int.Parse(reader["CaixaId"].ToString());
                            model.OrigemId = int.Parse(reader["OrigemId"].ToString());
                            model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TimpoMovimentacaoId"].ToString());
                            model.ValorRecebido = double.Parse(reader["ValorRecebido"].ToString());
                            model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                            modelList.Add(model);
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de ContasRecebidas pelo mês e ano selecionados", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public IEnumerable<ContasReceberModel> GetAllByOrigem(TituloReceberModel origem)
        {
            List<ContasReceberModel> modelList = new List<ContasReceberModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT " +
                           " ContasReceberId, DataRegistro, CaixaId, OrigemId, TipoMovimentacaoId, ValorRecebido, Cancelado " +
                           " FROM ContasReceber " +
                           " WHERE OrigemId = @OrigemId";



            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@OrigemId", origem.TituloId);


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            ContasReceberModel model = new ContasReceberModel();

                            model.ContasReceberId = int.Parse(reader["ContasReceberId"].ToString());
                            model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                            model.CaixaId = int.Parse(reader["CaixaId"].ToString());
                            model.OrigemId = int.Parse(reader["OrigemId"].ToString());
                            model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TimpoMovimentacaoId"].ToString());
                            model.ValorRecebido = double.Parse(reader["ValorRecebido"].ToString());
                            model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                            modelList.Add(model);
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de ContasRecebidas pela Origem", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }
        }

        public ContasReceberModel GetById(int contasReceberId)
        {
            ContasReceberModel model = new ContasReceberModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT " +
                           " ContasReceberId, DataRegistro, CaixaId, OrigemId, TipoMovimentacaoId, ValorRecebido, Cancelado " +
                           " FROM ContasReceber " +
                           " WHERE ContasReceberId = @ContasReceberId";



            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.Add(new SqlParameter("@ContasReceberId", contasReceberId));


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            model.ContasReceberId = int.Parse(reader["ContasReceberId"].ToString());
                            model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                            model.CaixaId = int.Parse(reader["CaixaId"].ToString());
                            model.OrigemId = int.Parse(reader["OrigemId"].ToString());
                            model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TimpoMovimentacaoId"].ToString());
                            model.ValorRecebido = double.Parse(reader["ValorRecebido"].ToString());
                            model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de ContasRecebidas pela Origem", e.HelpLink, e.ErrorCode, e.StackTrace);
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
