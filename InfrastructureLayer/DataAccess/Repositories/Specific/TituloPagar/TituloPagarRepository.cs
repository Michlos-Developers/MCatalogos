using CommonComponents;

using DomainLayer.Models.CommonModels.Enums;
using DomainLayer.Models.TitulosPagar;

using InfrastructureLayer.DataAccess.Repositories.Commons;

using ServiceLayer.CommonServices;
using ServiceLayer.Services.TitulosPagarServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.TituloPagar
{
    public class TituloPagarRepository : ITituloPagarRepository
    {
        private string _connectionString;

        public TituloPagarRepository()
        {

        }

        public TituloPagarRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TituloPagarModel Add(ITituloPagarModel tituloPagar)
        {
            int idReturned = 0;
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " INSERT INTO TitulosPagar " +
                            " (FornecedorId, StatusTituloId, DataVencimento , ValorTitulo , Parcelado , ValorParcela , QtdParcelas , CodigoBarras ) " +
                            " OUTPUT INSERTED.TituloId " +
                            " VALUES " +
                            " (@FornecedorId, @StatusTituloId, @DataVencimento , @ValorTitulo , @Parcelado , @ValorParcela , @QtdParcelas , @CodigoBarras ) ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@FornecedorId", tituloPagar.FornecedorId);
                        cmd.Parameters.AddWithValue("@StatusIdutloId", tituloPagar.StatusTitulo);
                        cmd.Parameters.AddWithValue("@DataVencimento", tituloPagar.DataVencimento);
                        cmd.Parameters.AddWithValue("@ValorTitulo", tituloPagar.DataVencimento);
                        cmd.Parameters.AddWithValue("@Parcelado", tituloPagar.DataVencimento);
                        cmd.Parameters.AddWithValue("@ValorParcela", tituloPagar.DataVencimento);
                        cmd.Parameters.AddWithValue("@QtdParcelas", tituloPagar.DataVencimento);
                        cmd.Parameters.AddWithValue("@CodigoBarras", tituloPagar.DataVencimento);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar o Título a Pagar", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

            if (tituloPagar.ValorAdicional != 0)
            { //VERIFICAR SE TEM VALOR NULL PARA MUDAR O IF
                AdicionarValorAdicional(tituloPagar.ValorAdicional, tituloPagar);
            }
            TituloPagarModel returnedTitulo = new TituloPagarModel();
            returnedTitulo = GetById(idReturned);

            return returnedTitulo;

        }

        public void AdicionarValorAdicional(double valorAdicional, ITituloPagarModel tituloPagar)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query =  " UPDATE TitulosPagar " +
                            " SET ValorAdicional = @ValorAdicional " +
                            " WHERE TituloId = @TituloId ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@TituloId", tituloPagar.TituloId);
                        cmd.Parameters.AddWithValue("@ValorAdicional", tituloPagar.ValorAdicional);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível atualizar Valor Adicional do Título a Pagar", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<TituloPagarModel> GetAll()
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            List<TituloPagarModel> modelList = new List<TituloPagarModel>();
            StatusTitulosServices _statusServices = new StatusTitulosServices(new StatusTituloRepository(_connectionString));
            string query = " SELECT * FROM TitulosPagar ";

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
                                TituloPagarModel model = new TituloPagarModel();

                                model.TituloId = int.Parse(reader["TituloId"].ToString());
                                model.FornecedorId = int.Parse(reader["FornecedorId"].ToString());
                                StatusTitulosModel.StatusTitulo status = (StatusTitulosModel.StatusTitulo) _statusServices.GetById(int.Parse(reader["StatusId"].ToString())).ToString()
                                model.StatusTitulo = StatusTituloRepository statusTitulosModel

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível atualizar Valor Adicional do Título a Pagar", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<TituloPagarModel> GetAllByFornecedorId(int fornecedorId)
        {
            throw new NotImplementedException();
        }

        public TituloPagarModel GetById(int tituloId)
        {
            throw new NotImplementedException();
        }

        public void Liquidar(ITituloPagarModel tituloPagar)
        {
            throw new NotImplementedException();
        }

        public void SetStatusTitulo(StatusTitulosModel.StatusTitulo status, ITituloPagarModel tituloPagar)
        {
            throw new NotImplementedException();
        }
    }
}
