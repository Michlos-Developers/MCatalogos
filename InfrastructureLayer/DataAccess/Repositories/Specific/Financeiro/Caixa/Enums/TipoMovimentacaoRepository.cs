using CommonComponents;

using DomainLayer.Models.Financeiro.Caixa.Enums;

using ServiceLayer.Services.FinanceiroServices;

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Financeiro.Caixa.Enums
{
    public class TipoMovimentacaoRepository : ITipoMovimentacaoRepository
    {
        private string _connectionString;

        public TipoMovimentacaoRepository()
        {

        }
        public TipoMovimentacaoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<TipoMovimentacaoModel> GetAll()
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT TipoId, TipoMovimentacao, TipoEnum " +
                           " FROM TipoMovimentacao ";

            List<TipoMovimentacaoModel> ListTipos = new List<TipoMovimentacaoModel>();
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
                                TipoMovimentacaoModel model = new TipoMovimentacaoModel();
                                model.TipoId = int.Parse(reader["TipoId"].ToString());
                                model.TipoMovimentacao = reader["TipoMovimentacao"].ToString();
                                model.Tipo = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoEnum"].ToString());

                                ListTipos.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Tipos de Movimentação", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return ListTipos;
        }

        public TipoMovimentacaoModel GetById(int tipoId)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT TipoId, TipoMovimentacao, TipoEnum " +
                           " FROM TipoMovimentacao " +
                           " WHERE TipoId = @TipoId";

            TipoMovimentacaoModel model = new TipoMovimentacaoModel();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@TipoId", tipoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.TipoId = int.Parse(reader["TipoId"].ToString());
                                model.TipoMovimentacao = reader["TipoMovimentacao"].ToString();
                                model.Tipo = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoEnum"].ToString());

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar Tipo de Movimentação pelo ID", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return model;
        }

        public TipoMovimentacaoModel GetByTipo(string tipo)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT TipoId, TipoMovimentacao, TipoEnum " +
                           " FROM TipoMovimentacao " +
                           " WHERE TipoMovimentacao = @TipoMovimentacao";

            TipoMovimentacaoModel model = new TipoMovimentacaoModel();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@TipoMovimentacao", tipo));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.TipoId = int.Parse(reader["TipoId"].ToString());
                                model.TipoMovimentacao = reader["TipoMovimentacao"].ToString();
                                model.Tipo = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoEnum"].ToString());

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar Tipo de Movimentação pela Descricao", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return model;
        }

        public TipoMovimentacaoModel GetByTipoEnum(TipoMovimentacao tipo)
        {
            TipoMovimentacaoModel model = new TipoMovimentacaoModel();
            
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT TipoId, TipoMovimentacao, TipoEnum " +
                           " FROM TipoMovimentacao " +
                           " WHERE TipoEnum = @TipoEnum";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@TipoEnum", tipo));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.TipoId = int.Parse(reader["TipoId"].ToString());
                                model.TipoMovimentacao = reader["TipoMovimentacao"].ToString();
                                model.Tipo = (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), reader["TipoEnum"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Tipo de Movimentação pelo Enum", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return model;

        }
    }
}
