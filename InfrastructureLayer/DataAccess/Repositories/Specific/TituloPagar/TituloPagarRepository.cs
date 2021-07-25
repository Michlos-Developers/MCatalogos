using CommonComponents;

using DomainLayer.Models.CommonModels.Enums;
using DomainLayer.Models.TitulosPagar;

using ServiceLayer.Services.TitulosPagarServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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

        #region SETTERS
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
                        cmd.Parameters.AddWithValue("@StatusIdutloId", tituloPagar.StatusTitulo); //VERIFICAR SE VAI DAR ERRO
                        cmd.Parameters.AddWithValue("@DataVencimento", tituloPagar.DataVencimento);
                        cmd.Parameters.AddWithValue("@ValorTitulo", tituloPagar.ValorTitulo);
                        cmd.Parameters.AddWithValue("@Parcelado", tituloPagar.Parcelado);
                        cmd.Parameters.AddWithValue("@ValorParcela", tituloPagar.ValorParcela);
                        cmd.Parameters.AddWithValue("@QtdParcelas", tituloPagar.QtdParcelas);
                        cmd.Parameters.AddWithValue("@CodigoBarras", tituloPagar.CodigoBarras);

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
                AddValorAdicional(tituloPagar.ValorAdicional, tituloPagar);
            }
            TituloPagarModel returnedTitulo = new TituloPagarModel();
            returnedTitulo = GetById(idReturned);

            return returnedTitulo;

        }
        
        public void AddValorAdicional(double valorAdicional, ITituloPagarModel tituloPagar)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " UPDATE TitulosPagar " +
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

        public void Liquidar(ITituloPagarModel tituloPagar)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " UPDATE TitulosPagar SET " +
                            " ValorAdicional = @ValorAdicional " +
                            " ValorPago = @ValorPago " +
                            " StatusTituloId = @StatusTituloId " +
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
                        cmd.Parameters.AddWithValue("@ValorPago", tituloPagar.ValorPago);
                        cmd.Parameters.AddWithValue("@StatusTituloId", tituloPagar.StatusTitulo); //VER SE VAI DAR ERRO

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

        public void SetStatusTitulo(StatusTitulo status, ITituloPagarModel tituloPagar)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " UPDATE TitulosPagar SET " +
                            " StatusTituloId = @StatusTituloId " +
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
                        cmd.Parameters.AddWithValue("@StatusTituloId", status);  //VER SE VAI DAR ERRO

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
        #endregion

        #region GETTERS

        public IEnumerable<TituloPagarModel> GetAll()
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            List<TituloPagarModel> modelList = new List<TituloPagarModel>();
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
                                model.StatusTitulo = (StatusTitulo)Enum.Parse(typeof(StatusTitulo), reader["StatusTitulo"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.DataVencimento = DateTime.Parse(reader["DataVencimento"].ToString());
                                model.ValorTitulo = double.Parse(reader["ValorTitulo"].ToString());
                                model.ValorAdicional = string.IsNullOrEmpty(reader["ValorAdicional"].ToString()) ? 0 : double.Parse(reader["ValorAdicional"].ToString());
                                model.Parcelado = bool.Parse(reader["Parcelado"].ToString());
                                model.ValorParcela = string.IsNullOrEmpty(reader["ValorParcela"].ToString()) ? 0 : double.Parse(reader["ValorParcela"].ToString());
                                model.QtdParcelas = int.Parse(reader["QtdParcelas"].ToString());
                                model.ValorPago = string.IsNullOrEmpty(reader["ValorPago"].ToString()) ? 0 : double.Parse(reader["ValorPago"].ToString());
                                model.CodigoBarras = string.IsNullOrEmpty(reader["CodigoBarras"].ToString()) ? string.Empty : reader["CodigoBarras"].ToString();

                                modelList.Add(model);

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
            return modelList;
        }

        public IEnumerable<TituloPagarModel> GetAllByFornecedorId(int fornecedorId)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            List<TituloPagarModel> modelList = new List<TituloPagarModel>();
            string query = " SELECT * FROM TitulosPagar WHERE ForencedorId = @FornecedorId ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@FornecedorId", fornecedorId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                TituloPagarModel model = new TituloPagarModel();

                                model.TituloId = int.Parse(reader["TituloId"].ToString());
                                model.FornecedorId = int.Parse(reader["FornecedorId"].ToString());
                                model.StatusTitulo = (StatusTitulo)Enum.Parse(typeof(StatusTitulo), reader["StatusTitulo"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.DataVencimento = DateTime.Parse(reader["DataVencimento"].ToString());
                                model.ValorTitulo = double.Parse(reader["ValorTitulo"].ToString());
                                model.ValorAdicional = string.IsNullOrEmpty(reader["ValorAdicional"].ToString()) ? 0 : double.Parse(reader["ValorAdicional"].ToString());
                                model.Parcelado = bool.Parse(reader["Parcelado"].ToString());
                                model.ValorParcela = string.IsNullOrEmpty(reader["ValorParcela"].ToString()) ? 0 : double.Parse(reader["ValorParcela"].ToString());
                                model.QtdParcelas = int.Parse(reader["QtdParcelas"].ToString());
                                model.ValorPago = string.IsNullOrEmpty(reader["ValorPago"].ToString()) ? 0 : double.Parse(reader["ValorPago"].ToString());
                                model.CodigoBarras = string.IsNullOrEmpty(reader["CodigoBarras"].ToString()) ? string.Empty : reader["CodigoBarras"].ToString();

                                modelList.Add(model);

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
            return modelList;
        }

        public TituloPagarModel GetById(int tituloId)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            TituloPagarModel model = new TituloPagarModel();
            string query = " SELECT * FROM TitulosPagar WHERE TituloId = @TituloId ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@TituloId", tituloId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                model.TituloId = int.Parse(reader["TituloId"].ToString());
                                model.FornecedorId = int.Parse(reader["FornecedorId"].ToString());
                                model.StatusTitulo = (StatusTitulo)Enum.Parse(typeof(StatusTitulo), reader["StatusTitulo"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.DataVencimento = DateTime.Parse(reader["DataVencimento"].ToString());
                                model.ValorTitulo = double.Parse(reader["ValorTitulo"].ToString());
                                model.ValorAdicional = string.IsNullOrEmpty(reader["ValorAdicional"].ToString()) ? 0 : double.Parse(reader["ValorAdicional"].ToString());
                                model.Parcelado = bool.Parse(reader["Parcelado"].ToString());
                                model.ValorParcela = string.IsNullOrEmpty(reader["ValorParcela"].ToString()) ? 0 : double.Parse(reader["ValorParcela"].ToString());
                                model.QtdParcelas = int.Parse(reader["QtdParcelas"].ToString());
                                model.ValorPago = string.IsNullOrEmpty(reader["ValorPago"].ToString()) ? 0 : double.Parse(reader["ValorPago"].ToString());
                                model.CodigoBarras = string.IsNullOrEmpty(reader["CodigoBarras"].ToString()) ? string.Empty : reader["CodigoBarras"].ToString();


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
            return model;
        }

        #endregion
    }
}
