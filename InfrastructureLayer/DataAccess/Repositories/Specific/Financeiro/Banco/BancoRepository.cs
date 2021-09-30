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
                    dataAccessStatus.setValues("Error", false, e.Message, $"Não foi possível Remover o Banco {banco.NomeBanco} do Sistema.", e.HelpLink, e.ErrorCode, e.StackTrace);
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
