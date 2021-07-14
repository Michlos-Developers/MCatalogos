using CommonComponents;

using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Vendedora;

using ServiceLayer.Services.PedidosVendedorasServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Reflection.Emit;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.PedidoVendedora
{
    public class PedidoVendedoraRepository : IPedidosVendedorasRepository
    {
        private string _connectionString;

        public PedidoVendedoraRepository()
        {

        }

        public PedidoVendedoraRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IPedidosVendedorasModel Add(IPedidosVendedorasModel pedido)
        {
            int IdReturned = 0;
            PedidosVendedorasModel pedidoVendedora = new PedidosVendedorasModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "INSERT INTO PedidosVendedoras " +
                           "(VendedoraId, StatusPed) " +
                           "output INSERTED.PedidoId " +
                           "VALUES (@VendedoraId, @StatusPed)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@VendedoraId", pedido.VendedoraId);
                        cmd.Parameters.AddWithValue("@StatusPed", pedido.StatusPed);
                        IdReturned = (int)cmd.ExecuteScalar();
                    }

                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível adicionar o registro do Pedido da Vendedora.\nPedidoVendedoraReposiotryAdd",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

            }
            pedidoVendedora = (PedidosVendedorasModel)GetById(IdReturned);
            return pedidoVendedora;
            
        }

        public void SetStatus(int status, PedidosVendedorasModel pedido)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " UPDATE PedidodosVendedoras SET " +
                            " StatusPed = @StatusPed " +
                            " WHERE PedidoId = @PedidoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@PedidoId", pedido.PedidoId);
                        cmd.Parameters.Add(new SqlParameter("@Status", status));
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível atualizar o Status do Pedido",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }


        }
        public IEnumerable<IPedidosVendedorasModel> GetAll()
        {
            List<PedidosVendedorasModel> modelList = new List<PedidosVendedorasModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM PedidosVendedoras";
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
                                PedidosVendedorasModel model = new PedidosVendedorasModel();
                                model.PedidoId = int.Parse(reader["PedidoId"].ToString());
                                model.VendedoraId = int.Parse(reader["VendedoraId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());


                                model.ValorTotalPedido = string.IsNullOrEmpty(reader["ValorTotalPedido"].ToString()) ? 0.0 : double.Parse(reader["ValorTotalPedido"].ToString());
                                model.ValorLucroVendedora = string.IsNullOrEmpty(reader["ValorLucroVendedora"].ToString()) ? 0.0 : double.Parse(reader["ValorLucroVendedora"].ToString());
                                model.ValorLucroDistribuidor = string.IsNullOrEmpty(reader["ValorLucroDistribuidor"].ToString()) ? 0.0 : double.Parse(reader["ValorLucroDistribuidor"].ToString());
                                model.QtdCatalogos = string.IsNullOrEmpty(reader["QtdCatalogos"].ToString()) ? 0 : int.Parse(reader["QtdCatalogos"].ToString());
                                model.StatusPed = int.Parse(reader["StatusPed"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível recuperar Lista de Pedidos",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return modelList;
        }

        public IEnumerable<IPedidosVendedorasModel> GetAllByDataConferenciaIniFim(DateTime dataIni, DateTime dataFim)
        {
            List<PedidosVendedorasModel> modelList = new List<PedidosVendedorasModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM PedidosVendedoras WHERE DataConferencia >= @DataIni AND DataConferencia <= @DataFim";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@DataIni", dataIni));
                        cmd.Parameters.Add(new SqlParameter("@DataFim", dataFim));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PedidosVendedorasModel model = new PedidosVendedorasModel();
                                model.PedidoId = int.Parse(reader["PedidoId"].ToString());
                                model.VendedoraId = int.Parse(reader["VendedoraId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ValorTotalPedido = string.IsNullOrEmpty(reader["ValorTotalPedido"].ToString()) ? 0.0 : double.Parse(reader["ValorTotalPedido"].ToString());
                                model.ValorLucroVendedora = string.IsNullOrEmpty(reader["ValorLucroVendedora"].ToString()) ? 0.0 : double.Parse(reader["ValorLucroVendedora"].ToString());
                                model.ValorLucroDistribuidor = string.IsNullOrEmpty(reader["ValorLucroDistribuidor"].ToString()) ? 0.0 : double.Parse(reader["ValorLucroDistribuidor"].ToString());
                                model.QtdCatalogos = string.IsNullOrEmpty(reader["QtdCatalogos"].ToString()) ? 0 : int.Parse(reader["QtdCatalogos"].ToString());
                                model.StatusPed = int.Parse(reader["StatusPed"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível recuperar Lista de Pedidos",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return modelList;
        }

        public IEnumerable<IPedidosVendedorasModel> GetAllByDataDespachoIniFim(DateTime dataIni, DateTime dataFim)
        {
            List<PedidosVendedorasModel> modelList = new List<PedidosVendedorasModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM PedidosVendedoras WHERE DataDespacho >= @DataIni AND DataDespacho <= @DataFim";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@DataIni", dataIni));
                        cmd.Parameters.Add(new SqlParameter("@DataFim", dataFim));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PedidosVendedorasModel model = new PedidosVendedorasModel();
                                model.PedidoId = int.Parse(reader["PedidoId"].ToString());
                                model.VendedoraId = int.Parse(reader["VendedoraId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ValorTotalPedido = string.IsNullOrEmpty(reader["ValorTotalPedido"].ToString()) ? 0.0 : double.Parse(reader["ValorTotalPedido"].ToString());
                                model.ValorLucroVendedora = string.IsNullOrEmpty(reader["ValorLucroVendedora"].ToString()) ? 0.0 : double.Parse(reader["ValorLucroVendedora"].ToString());
                                model.ValorLucroDistribuidor = string.IsNullOrEmpty(reader["ValorLucroDistribuidor"].ToString()) ? 0.0 : double.Parse(reader["ValorLucroDistribuidor"].ToString());
                                model.QtdCatalogos = string.IsNullOrEmpty(reader["QtdCatalogos"].ToString()) ? 0 : int.Parse(reader["QtdCatalogos"].ToString());
                                model.StatusPed = int.Parse(reader["StatusPed"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível recuperar Lista de Pedidos",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return modelList;
        }

        public IEnumerable<IPedidosVendedorasModel> GetAllByDataEntregaIniFim(DateTime dataIni, DateTime dataFim)
        {
            List<PedidosVendedorasModel> modelList = new List<PedidosVendedorasModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM PedidosVendedoras WHERE DataEntrega >= @DataIni AND DataEntrega <= @DataFim";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@DataIni", dataIni));
                        cmd.Parameters.Add(new SqlParameter("@DataFim", dataFim));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PedidosVendedorasModel model = new PedidosVendedorasModel();
                                model.PedidoId = int.Parse(reader["PedidoId"].ToString());
                                model.VendedoraId = int.Parse(reader["VendedoraId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ValorTotalPedido = string.IsNullOrEmpty(reader["ValorTotalPedido"].ToString()) ? 0.0 : double.Parse(reader["ValorTotalPedido"].ToString());
                                model.ValorLucroVendedora = string.IsNullOrEmpty(reader["ValorLucroVendedora"].ToString()) ? 0.0 : double.Parse(reader["ValorLucroVendedora"].ToString());
                                model.ValorLucroDistribuidor = string.IsNullOrEmpty(reader["ValorLucroDistribuidor"].ToString()) ? 0.0 : double.Parse(reader["ValorLucroDistribuidor"].ToString());
                                model.QtdCatalogos = string.IsNullOrEmpty(reader["QtdCatalogos"].ToString()) ? 0 : int.Parse(reader["QtdCatalogos"].ToString());
                                model.StatusPed = int.Parse(reader["StatusPed"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível recuperar Lista de Pedidos",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return modelList;
        }

        public IEnumerable<IPedidosVendedorasModel> GetAllByDataEnvioIniFim(DateTime dataIni, DateTime dataFim)
        {
            List<PedidosVendedorasModel> modelList = new List<PedidosVendedorasModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM PedidosVendedoras WHERE DataEnvio >= @DataIni AND DataEnvio <= @DataFim";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@DataIni", dataIni));
                        cmd.Parameters.Add(new SqlParameter("@DataFim", dataFim));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PedidosVendedorasModel model = new PedidosVendedorasModel();
                                model.PedidoId = int.Parse(reader["PedidoId"].ToString());
                                model.VendedoraId = int.Parse(reader["VendedoraId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ValorTotalPedido = string.IsNullOrEmpty(reader["ValorTotalPedido"].ToString()) ? 0.0 : double.Parse(reader["ValorTotalPedido"].ToString());
                                model.ValorLucroVendedora = string.IsNullOrEmpty(reader["ValorLucroVendedora"].ToString()) ? 0.0 : double.Parse(reader["ValorLucroVendedora"].ToString());
                                model.ValorLucroDistribuidor = string.IsNullOrEmpty(reader["ValorLucroDistribuidor"].ToString()) ? 0.0 : double.Parse(reader["ValorLucroDistribuidor"].ToString());
                                model.QtdCatalogos = string.IsNullOrEmpty(reader["QtdCatalogos"].ToString()) ? 0 : int.Parse(reader["QtdCatalogos"].ToString());
                                model.StatusPed = int.Parse(reader["StatusPed"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível recuperar Lista de Pedidos",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return modelList;
        }

        public IEnumerable<IPedidosVendedorasModel> GetAllByDataRegistroIniFim(DateTime dataIni, DateTime dataFim)
        {
            List<PedidosVendedorasModel> modelList = new List<PedidosVendedorasModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM PedidosVendedoras WHERE DataRegistro >= @DataIni AND DataRegistro <= @DataFim";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@DataIni", dataIni));
                        cmd.Parameters.Add(new SqlParameter("@DataFim", dataFim));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PedidosVendedorasModel model = new PedidosVendedorasModel();
                                model.PedidoId = int.Parse(reader["PedidoId"].ToString());
                                model.VendedoraId = int.Parse(reader["VendedoraId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ValorTotalPedido = string.IsNullOrEmpty(reader["ValorTotalPedido"].ToString()) ? 0.0 : double.Parse(reader["ValorTotalPedido"].ToString());
                                model.ValorLucroVendedora = string.IsNullOrEmpty(reader["ValorLucroVendedora"].ToString()) ? 0.0 : double.Parse(reader["ValorLucroVendedora"].ToString());
                                model.ValorLucroDistribuidor = string.IsNullOrEmpty(reader["ValorLucroDistribuidor"].ToString()) ? 0.0 : double.Parse(reader["ValorLucroDistribuidor"].ToString());
                                model.QtdCatalogos = string.IsNullOrEmpty(reader["QtdCatalogos"].ToString()) ? 0 : int.Parse(reader["QtdCatalogos"].ToString());
                                model.StatusPed = int.Parse(reader["StatusPed"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível recuperar Lista de Pedidos",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return modelList;
        }

        public IEnumerable<IPedidosVendedorasModel> GetAllByDataSeparadoIniFim(DateTime dataIni, DateTime dataFim)
        {
            List<PedidosVendedorasModel> modelList = new List<PedidosVendedorasModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM PedidosVendedoras WHERE DataSeparacao >= @DataIni AND DataSeparacao <= @DataFim";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@DataIni", dataIni));
                        cmd.Parameters.Add(new SqlParameter("@DataFim", dataFim));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PedidosVendedorasModel model = new PedidosVendedorasModel();
                                model.PedidoId = int.Parse(reader["PedidoId"].ToString());
                                model.VendedoraId = int.Parse(reader["VendedoraId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ValorTotalPedido = string.IsNullOrEmpty(reader["ValorTotalPedido"].ToString()) ? 0.0 : double.Parse(reader["ValorTotalPedido"].ToString());
                                model.ValorLucroVendedora = string.IsNullOrEmpty(reader["ValorLucroVendedora"].ToString()) ? 0.0 : double.Parse(reader["ValorLucroVendedora"].ToString());
                                model.ValorLucroDistribuidor = string.IsNullOrEmpty(reader["ValorLucroDistribuidor"].ToString()) ? 0.0 : double.Parse(reader["ValorLucroDistribuidor"].ToString());
                                model.QtdCatalogos = string.IsNullOrEmpty(reader["QtdCatalogos"].ToString()) ? 0 : int.Parse(reader["QtdCatalogos"].ToString());
                                model.StatusPed = int.Parse(reader["StatusPed"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível recuperar Lista de Pedidos",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return modelList;
        }

        public IEnumerable<IPedidosVendedorasModel> GetAllByVendedora(IVendedoraModel vendedora)
        {
            List<PedidosVendedorasModel> modelList = new List<PedidosVendedorasModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM PedidosVendedoras WHERE VendedoraId = @VendedoraId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@VendedoraId", vendedora.VendedoraId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PedidosVendedorasModel model = new PedidosVendedorasModel();
                                model.PedidoId = int.Parse(reader["PedidoId"].ToString());
                                model.VendedoraId = int.Parse(reader["VendedoraId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ValorTotalPedido = string.IsNullOrEmpty(reader["ValorTotalPedido"].ToString()) ? 0.0 : double.Parse(reader["ValorTotalPedido"].ToString());
                                model.ValorLucroVendedora = string.IsNullOrEmpty(reader["ValorLucroVendedora"].ToString()) ? 0.0 : double.Parse(reader["ValorLucroVendedora"].ToString());
                                model.ValorLucroDistribuidor = string.IsNullOrEmpty(reader["ValorLucroDistribuidor"].ToString()) ? 0.0 : double.Parse(reader["ValorLucroDistribuidor"].ToString());
                                model.QtdCatalogos = string.IsNullOrEmpty(reader["QtdCatalogos"].ToString()) ? 0 : int.Parse(reader["QtdCatalogos"].ToString());
                                model.StatusPed = int.Parse(reader["StatusPed"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível recuperar Lista de Pedidos",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return modelList;
        }

        public IPedidosVendedorasModel GetById(int pedidoId)
        {
            PedidosVendedorasModel model = new PedidosVendedorasModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM PedidosVendedoras WHERE PedidoId = @PedidoId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@PedidoId", pedidoId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.PedidoId = int.Parse(reader["PedidoId"].ToString());
                                model.VendedoraId = int.Parse(reader["VendedoraId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ValorTotalPedido = string.IsNullOrEmpty(reader["ValorTotalPedido"].ToString()) ? 0.0 : double.Parse(reader["ValorTotalPedido"].ToString());
                                model.ValorLucroVendedora = string.IsNullOrEmpty(reader["ValorLucroVendedora"].ToString()) ? 0.0 : double.Parse(reader["ValorLucroVendedora"].ToString());
                                model.ValorLucroDistribuidor = string.IsNullOrEmpty(reader["ValorLucroDistribuidor"].ToString()) ? 0.0 : double.Parse(reader["ValorLucroDistribuidor"].ToString());
                                model.QtdCatalogos = string.IsNullOrEmpty(reader["QtdCatalogos"].ToString()) ? 0 : int.Parse(reader["QtdCatalogos"].ToString());
                                model.StatusPed = int.Parse(reader["StatusPed"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível recuperar Pedido",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }


            return model;
        }

        public IPedidosVendedorasModel GetByVendedoraMes(IVendedoraModel vendedora, DateTime dataMes)
        {
            PedidosVendedorasModel model = new PedidosVendedorasModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM PedidosVendedoras WHERE VendedoraId = @VendedoraId AND MONTH(DataRegistro) = @DataMes";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@VendedoraId", vendedora.VendedoraId);
                        cmd.Parameters.Add(new SqlParameter("@DataMes", dataMes));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.PedidoId = int.Parse(reader["PedidoId"].ToString());
                                model.VendedoraId = int.Parse(reader["VendedoraId"].ToString());
                                model.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                model.ValorTotalPedido = string.IsNullOrEmpty(reader["ValorTotalPedido"].ToString()) ? 0.0 : double.Parse(reader["ValorTotalPedido"].ToString());
                                model.ValorLucroVendedora = string.IsNullOrEmpty(reader["ValorLucroVendedora"].ToString()) ? 0.0 : double.Parse(reader["ValorLucroVendedora"].ToString());
                                model.ValorLucroDistribuidor = string.IsNullOrEmpty(reader["ValorLucroDistribuidor"].ToString()) ? 0.0 : double.Parse(reader["ValorLucroDistribuidor"].ToString());
                                model.QtdCatalogos = string.IsNullOrEmpty(reader["QtdCatalogos"].ToString()) ? 0 : int.Parse(reader["QtdCatalogos"].ToString());
                                model.StatusPed = int.Parse(reader["StatusPed"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível recuperar Pedido",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }


            return model;
        }

        public void AtualizaTotaisPedido(IPedidosVendedorasModel pedido)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query =  " UPDATE PedidosVendedoras SET " +
                            " ValorTotalPedido = @ValorTotalPedido, " +
                            " ValorLucroVendedora = @ValorLucroVendedora, " +
                            " ValorLucroDistribuidor = @ValorLucroDistribuidor, " +
                            " QtdCatalogos = @QtdCatalogos " +
                            " WHERE PedidoId = @PedidoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@ValorTotalPedido", pedido.ValorTotalPedido);
                        cmd.Parameters.AddWithValue("@ValorLucroVendedora", pedido.ValorLucroVendedora);
                        cmd.Parameters.AddWithValue("@ValorLucroDistribuidor", pedido.ValorLucroDistribuidor);
                        cmd.Parameters.AddWithValue("@QtdCatalogos", pedido.QtdCatalogos);
                        cmd.Parameters.AddWithValue("@PedidoId", pedido.PedidoId);

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível atualizar os dados do Pedido",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }


    }
}
