using CommonComponents;

using DomainLayer.Models.Financeiro.Caixa.Enums;
using DomainLayer.Models.Financeiro.Retirada;

using ServiceLayer.Services.FinanceiroServices.RetiradaServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Financeiro.RetiradaCaixa
{
    public class RetiradaCaixaRepository : IRetiradaCaixaRepository
    {
        private string _connectionString;
        public RetiradaCaixaRepository()
        {

        }

        public RetiradaCaixaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public RetiradaCaixaModel Add(IRetiradaCaixaModel retiradaCaixa)
        {
            int idReturned = 0;
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "INSERT INTO RetiradaCaixa " +
                           "(ValorRetirada, Justificativa, Autor, TipoMovimentacaoId, CaixaId) " +
                           "OUTPUT ISERTED.RetiradaId " +
                           "VALUES " +
                           "(@ValorRetirada, @Justificativa, @Autor, @TipoMovimentacaoId, @CaixaId) ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@ValorRetirada", retiradaCaixa.ValorRetirada);
                        cmd.Parameters.AddWithValue("@Justificativa", retiradaCaixa.Justificativa);
                        cmd.Parameters.AddWithValue("@Autor", retiradaCaixa.Autor);
                        cmd.Parameters.AddWithValue("@TipoMovimentacaoId", retiradaCaixa.TipoMovimentacao);
                        cmd.Parameters.AddWithValue("@CaixaId", retiradaCaixa.Caixa.CaixaId);

                        idReturned = (int)cmd.ExecuteScalar();

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar a Retirada do Caixa", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

            RetiradaCaixaModel returnedRetirada = new RetiradaCaixaModel();
            returnedRetirada = GetById(idReturned);

            return returnedRetirada;

        }

        public void CancelaRegistro(IRetiradaCaixaModel retiradaCaixa)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " UPDATE RetiradaCaixa SET " +
                           " Cancelado = @Cancelado " +
                           " WHERE RetiradaId = @RetiradaId ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@RetiradaId", retiradaCaixa.RetiradaId);
                        cmd.Parameters.Add(new SqlParameter("@Cancelado", true));
                        cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi cancelar a Retirada do Caixa", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<RetiradaCaixaModel> GetAll()
        {
            List<RetiradaCaixaModel> modelList = new List<RetiradaCaixaModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM RetiradaCaixa";

            using (SqlConnection connection = new SqlConnection())
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
                                RetiradaCaixaModel model = new RetiradaCaixaModel();

                                model.RetiradaId = int.Parse(reader["RetiradaId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ValorRetirada = double.Parse(reader["ValorRetirada"].ToString());
                                model.Justificativa = reader["Justificativa"].ToString();
                                model.Autor = reader["Autor"].ToString();
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.CaixaId = int.Parse(reader["CaixaId"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar registros de Retirada do Caixa", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return modelList;
            }

        }

        public RetiradaCaixaModel GetById(int retiradaId)
        {
            RetiradaCaixaModel model = new RetiradaCaixaModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM RetiradaCaixa WHERE RetiradaId = @RetiradaId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@RetiradaId", retiradaId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.RetiradaId = int.Parse(reader["RetiradaId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ValorRetirada = double.Parse(reader["ValorRetirada"].ToString());
                                model.Justificativa = reader["Justificativa"].ToString();
                                model.Autor = reader["Autor"].ToString();
                                model.TipoMovimentacao = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoMovimentacaoId"].ToString());
                                model.CaixaId = int.Parse(reader["CaixaId"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar Retirada pelo Id", e.HelpLink, e.ErrorCode, e.StackTrace);
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
