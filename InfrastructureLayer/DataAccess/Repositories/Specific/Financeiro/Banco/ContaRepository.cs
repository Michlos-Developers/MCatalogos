using CommonComponents;

using DomainLayer.Models.Financeiro.Banco;

using ServiceLayer.Services.FinanceiroServices.BancoServices.ContaServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Financeiro.Banco
{
    public class ContaRepository : IContaRepository
    {
        private string _connectionString;

        public ContaRepository()
        {

        }

        public ContaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region SETTERS

        public ContaModel AddConta(IContaModel conta)
        {
            int idReturned = 0;

            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " INSERT INTO Contas " +
                           " (BancoId, NumeroConta, DvNumeroConta, NumeroAgencia, DvNumeroAgencia, SaldoAnterior, SaldoAtual) " +
                           " OUTPUT INSERTED.ContaId " +
                           " VALUES " +
                           " (@BancoId, @NumeroConta, @DvNumeroConta, @NumeroAgencia, @DvNumeroAgencia, @SaldoAnterior, @SaldoAtual)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@BancoId", conta.BancoId);
                        cmd.Parameters.AddWithValue("@NumeroConta", conta.NumeroConta);
                        cmd.Parameters.AddWithValue("@DvNumeroConta", conta.DvNumeroConta);
                        cmd.Parameters.AddWithValue("@NumeroAgencia", conta.NumeroAgencia);
                        cmd.Parameters.AddWithValue("@DvNumeroAgencia", conta.DvNumeroAgencia);
                        cmd.Parameters.AddWithValue("@SaldoAnterio", conta.SaldoAnterior);
                        cmd.Parameters.AddWithValue("@SaldoAtual", conta.SaldoAtual);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registrar a Conta no sistema", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                ContaModel returnedConta = new ContaModel();
                returnedConta = GetById(idReturned);
                return returnedConta;
            }

        }
        public void RemoveConta(IContaModel conta)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " UPDATE Contas SET " +
                           " Cancelado = @Cancelado" +
                           " WHERE ContaId = @ContaId ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@ContaId", conta.ContaId);
                        cmd.Parameters.Add(new SqlParameter("@Cancelado", true));
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, $"Não foi possível remover a conta {conta.NumeroConta}/{conta.DvNumeroConta}", e.HelpLink, e.ErrorCode, e.StackTrace);

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
        public IEnumerable<ContaModel> GetAll()
        {
            List<ContaModel> modelList = new List<ContaModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM Contas";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            ContaModel model = new ContaModel();

                            model.BancoId = int.Parse(reader["BancoId"].ToString());
                            model.NumeroConta = reader["NumeroConta"].ToString();
                            model.DvNumeroConta = reader["DvNumeroConta"].ToString();
                            model.NumeroAgencia = reader["NumeroAgencia"].ToString();
                            model.DvNumeroAgencia = reader["DvNumeroAgencia"].ToString();
                            model.SaldoAnterior = double.Parse(reader["SaldoAnterior"].ToString());
                            model.SaldoAtual = double.Parse(reader["SaldoAtual"].ToString());
                            model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                            modelList.Add(model);
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de contas existentes no banco", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return modelList;
        }

        public IEnumerable<ContaModel> GetAllByBanco(int bancoId)
        {
            List<ContaModel> modelList = new List<ContaModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM Contas " +
                           " WHERE BancoId = @BancoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@BancoId", bancoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            ContaModel model = new ContaModel();

                            model.BancoId = int.Parse(reader["BancoId"].ToString());
                            model.NumeroConta = reader["NumeroConta"].ToString();
                            model.DvNumeroConta = reader["DvNumeroConta"].ToString();
                            model.NumeroAgencia = reader["NumeroAgencia"].ToString();
                            model.DvNumeroAgencia = reader["DvNumeroAgencia"].ToString();
                            model.SaldoAnterior = double.Parse(reader["SaldoAnterior"].ToString());
                            model.SaldoAtual = double.Parse(reader["SaldoAtual"].ToString());
                            model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                            modelList.Add(model);
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de contas existentes no banco", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return modelList;
        }

        public ContaModel GetById(int contaId)
        {
            ContaModel model = new ContaModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM Contas " +
                           " WHERE ContaId = @ContaId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@ContaId", contaId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            model.BancoId = int.Parse(reader["BancoId"].ToString());
                            model.NumeroConta = reader["NumeroConta"].ToString();
                            model.DvNumeroConta = reader["DvNumeroConta"].ToString();
                            model.NumeroAgencia = reader["NumeroAgencia"].ToString();
                            model.DvNumeroAgencia = reader["DvNumeroAgencia"].ToString();
                            model.SaldoAnterior = double.Parse(reader["SaldoAnterior"].ToString());
                            model.SaldoAtual = double.Parse(reader["SaldoAtual"].ToString());
                            model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível os dados da Conta Bancária selecionada", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return model;
        }

        #endregion

    }
}
