using CommonComponents;

using DomainLayer.Models.Financeiro.Banco;
using DomainLayer.Models.Financeiro.Caixa.Enums;

using ServiceLayer.Services.FinanceiroServices.BancoServices;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Financeiro.Banco
{
    public class BancoRepository : IBancoRepository
    {
        private string _connectionString;

        public BancoRepository()
        {

        }

        public BancoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region SETTERS
        public BancoModel AddBanco(IBancoModel banco)
        {
            int idReturned = 0;
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " INSERT INTO Bancos" +
                           " (NumeroBanco, NomeBanco, NumeroConta, DvNumeroConta, NumeroAgencia, DvNumeroAgencia, SaldoAnterior, SaldoAtual)" +
                           " OUTPUT INSERTED.BancoId" +
                           " VALUES" +
                           " (@NumeroBanco, @NomeBanco, @NumeroConta, @DvNumeroConta, @NumeroAgencia, @DvNumeroAgencia, @SaldoAnterior, @SaldoAtual)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@NumeroBanco", banco.NumeroBanco);
                        cmd.Parameters.AddWithValue("@NomeBanco", banco.NomeBanco);
                        cmd.Parameters.AddWithValue("@NumeroConta", banco.NumeroConta);
                        cmd.Parameters.AddWithValue("@DvNumeroConta", banco.DvNumeroConta);
                        cmd.Parameters.AddWithValue("@NumeroAgencia", banco.NumeroAgencia);
                        cmd.Parameters.AddWithValue("@DvNumeroAgencia", banco.DvNumeroAgencia);
                        cmd.Parameters.AddWithValue("@SaldoAnterior", banco.SaldoAnterior);
                        cmd.Parameters.AddWithValue("@SaldoAtual", banco.SaldoAtual);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registrar o Banco no Sistema", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                BancoModel returnedBanco = new BancoModel();
                returnedBanco = GetById(idReturned);
                return returnedBanco;
            }

        }

        public BancoModel AtualizaSaldo(IBancoModel banco, double valorRegistro, TipoMovimentacao tipoMovimentacao)
        {

            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " UPDATE Bancos SET" +
                           " SaldoAnterior = @SaldoAnterior," +
                           " SaldoAtual = @SaldoAtual" +
                           " WHERE BancoId = @BancoId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@BancoId", banco.BancoId);
                        cmd.Parameters.AddWithValue("@SaldoAnterior", banco.SaldoAtual); //TRANSFERE O SALDO ATUAL PARA O SALDO ANTERIOR
                        if (tipoMovimentacao == TipoMovimentacao.DepositoBancario)
                        {
                            //SOMA VALOR AO SALDO ATUAL
                            cmd.Parameters.Add(new SqlParameter("@SaldoAtual", banco.SaldoAtual + valorRegistro));

                        }
                        else
                        {
                            //SUBTRAI VALOR DO SALDO ATUAL
                            cmd.Parameters.Add(new SqlParameter("@SaldoAtual", banco.SaldoAtual - valorRegistro));

                        }
                        cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, $"Não foi possível Atualizar o Saldo Bancário do Banco {banco.NomeBanco} da Conta {banco.NumeroConta}-{banco.DvNumeroConta}.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                banco = GetById(banco.BancoId);

                return banco as BancoModel;
            }




        }
        public void RemoveBanco(IBancoModel banco)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " UPDATE Bancos SET" +
                           " Cancelado = @Cancelado," +
                           " WHERE BancoId = @BancoId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@BancoId", banco.BancoId);
                        cmd.Parameters.Add(new SqlParameter("@Cancelado", false)); //TRANSFERE O SALDO ATUAL PARA O SALDO ANTERIOR
                        cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, $"Não foi possível Remover o Banco {banco.NomeBanco} da Conta {banco.NumeroConta}-{banco.DvNumeroConta} do Sistema.", e.HelpLink, e.ErrorCode, e.StackTrace);
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

        public IEnumerable<BancoModel> GetAll()
        {
            List<BancoModel> modelList = new List<BancoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            string query = "SELECT * FROM Bancos";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            BancoModel model = new BancoModel();

                            model.BancoId = int.Parse(reader["BancoId"].ToString());
                            model.NumeroBanco = int.Parse(reader["NumeroBanco"].ToString());
                            model.NomeBanco = reader["NomeBanco"].ToString();
                            model.NumeroConta = reader["NumeroConta"].ToString();
                            model.DvNumeroConta = reader["DvNumeroConta"].ToString();
                            model.NumeroAgencia = reader["NumeroAgencia"].ToString();
                            model.DvNumeroAgencia = string.IsNullOrEmpty(reader["DvNumeroAgencia"].ToString()) ? "-" : reader["DvNumeroAgencia"].ToString();
                            model.SaldoAnterior = double.Parse(reader["SaldoAnterior"].ToString());
                            model.SaldoAtual = double.Parse(reader["SaldoAtual"].ToString());
                            model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                            modelList.Add(model);

                        }

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Bancos registrados", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

            return modelList;
        }

        public BancoModel GetById(int bancoId)
        {
            BancoModel model = new BancoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            string query = "SELECT * FROM Bancos " +
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

                            model.BancoId = int.Parse(reader["BancoId"].ToString());
                            model.NumeroBanco = int.Parse(reader["NumeroBanco"].ToString());
                            model.NomeBanco = reader["NomeBanco"].ToString();
                            model.NumeroConta = reader["NumeroConta"].ToString();
                            model.DvNumeroConta = reader["DvNumeroConta"].ToString();
                            model.NumeroAgencia = reader["NumeroAgencia"].ToString();
                            model.DvNumeroAgencia = string.IsNullOrEmpty(reader["DvNumeroAgencia"].ToString()) ? "-" : reader["DvNumeroAgencia"].ToString();
                            model.SaldoAnterior = double.Parse(reader["SaldoAnterior"].ToString());
                            model.SaldoAtual = double.Parse(reader["SaldoAtual"].ToString());
                            model.Cancelado = bool.Parse(reader["Cancelado"].ToString());


                        }

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Bancos registrados", e.HelpLink, e.ErrorCode, e.StackTrace);
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
