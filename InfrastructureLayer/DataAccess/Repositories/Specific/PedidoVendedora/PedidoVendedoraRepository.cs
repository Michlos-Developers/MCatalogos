using CommonComponents;

using DomainLayer.Models.PedidosVendedoras;
using DomainLayer.Models.Vendedora;

using ServiceLayer.Services.PedidosVendedorasServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
                "(VendedoraId) " +
                "VALUES " +
                "(@VendedoraId)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@VendedoraId", pedido.VendedoraId);
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

        public void Cancelar(IPedidosVendedorasModel pedido)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE PedidosVendedoras SET Cancelado = TRUE, DataCancelamento = @DataCancelamento WHERE PedidoId = @PedidoId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@PedidoId", pedido.PedidoId);
                        cmd.Parameters.AddWithValue("@DataCancelamento", pedido.DataCancelamento);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível Cancelar o Pedido da Vendedora.\nPedidoVendedoraReposiotryCancelar",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Conferir(IPedidosVendedorasModel pedido)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE PedidosVendedoras SET Conferido = TRUE, DataConferencia = @DataConferencia WHERE PedidoId = @PedidoId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@PedidoId", pedido.PedidoId);
                        cmd.Parameters.AddWithValue("@DataConferencia", pedido.DataConferencia);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível Conferir o Pedido da Vendedora.\nPedidoVendedoraReposiotryCancelar",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Despachar(IPedidosVendedorasModel pedido)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE PedidosVendedoras SET Despachado = TRUE, DataDespacho = @DataDespacho WHERE PedidoId = @PedidoId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@PedidoId", pedido.PedidoId);
                        cmd.Parameters.AddWithValue("@DataDespacho", pedido.DataDespacho);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível Despachar o Pedido da Vendedora.\nPedidoVendedoraReposiotryCancelar",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Entregar(IPedidosVendedorasModel pedido)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE PedidosVendedoras SET Entregue = TRUE, DataEntrega = @DataEntrega WHERE PedidoId = @PedidoId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@PedidoId", pedido.PedidoId);
                        cmd.Parameters.AddWithValue("@DataEntrega", pedido.DataEntrega);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível Conferir o Pedido da Vendedora.\nPedidoVendedoraReposiotryCancelar",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Enviar(IPedidosVendedorasModel pedido)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE PedidosVendedoras SET Enviado = TRUE, DataEnvio = @DataEnvio WHERE PedidoId = @PedidoId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@PedidoId", pedido.PedidoId);
                        cmd.Parameters.AddWithValue("@DataEnvio", pedido.DataEnvio);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível registrar o Envio do Pedido da Vendedora.\nPedidoVendedoraReposiotryCancelar",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        
        public void Separar(IPedidosVendedorasModel pedido)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE PedidosVendedoras SET Separado = TRUE, DataSeparacao = @DataSeparacao WHERE PedidoId = @PedidoId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@PedidoId", pedido.PedidoId);
                        cmd.Parameters.AddWithValue("@DataSeparacao", pedido.DataEnvio);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível registrar o Envio do Pedido da Vendedora.\nPedidoVendedoraReposiotryCancelar",
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
                                model.DataEnvio = reader["DataEnvio"] != null ? DateTime.Parse(reader["DataEnvio"].ToString()) : DateTime.Parse("");
                                model.DataSeparacao = reader["DataSeparacao"] != null ? DateTime.Parse(reader["DataSeparacao"].ToString()) : DateTime.Parse("");
                                model.DataConferencia = reader["DataConferencia"] != null ? DateTime.Parse(reader["DataConferencia"].ToString()) : DateTime.Parse("");
                                model.DataDespacho = reader["DataDespacho"] != null ? DateTime.Parse(reader["DataDespacho"].ToString()) : DateTime.Parse("");
                                model.DataCancelamento = reader["DataCancelamento"] != null ? DateTime.Parse(reader["DataCancelamento"].ToString()) : DateTime.Parse("");
                                model.DataEntrega = reader["DataEntrega"] != null ? DateTime.Parse(reader["DataEntrega"].ToString()) : DateTime.Parse("");
                                model.ValotTotalPedido = reader["ValotTotalPedido"] != null ? double.Parse(reader["ValotTotalPedido"].ToString()) : 0;
                                model.ValorLucroVendedora = reader["ValorLucroVendedora"] != null ? double.Parse(reader["ValorLucroVendedora"].ToString()) : 0;
                                model.ValorLucroDistribuidor = reader["ValorLucroDistribuidor"] != null ? double.Parse(reader["ValorLucroDistribuidor"].ToString()) : 0;
                                model.Enviado = bool.Parse(reader["Enviado"].ToString());
                                model.Separado = bool.Parse(reader["Separado"].ToString());
                                model.Conferido = bool.Parse(reader["Conferido"].ToString());
                                model.Despachado = bool.Parse(reader["Despachado"].ToString());
                                model.Entregue = bool.Parse(reader["Entregue"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

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
                                model.DataEnvio = reader["DataEnvio"] != null ? DateTime.Parse(reader["DataEnvio"].ToString()) : DateTime.Parse("");
                                model.DataSeparacao = reader["DataSeparacao"] != null ? DateTime.Parse(reader["DataSeparacao"].ToString()) : DateTime.Parse("");
                                model.DataConferencia = reader["DataConferencia"] != null ? DateTime.Parse(reader["DataConferencia"].ToString()) : DateTime.Parse("");
                                model.DataDespacho = reader["DataDespacho"] != null ? DateTime.Parse(reader["DataDespacho"].ToString()) : DateTime.Parse("");
                                model.DataCancelamento = reader["DataCancelamento"] != null ? DateTime.Parse(reader["DataCancelamento"].ToString()) : DateTime.Parse("");
                                model.DataEntrega = reader["DataEntrega"] != null ? DateTime.Parse(reader["DataEntrega"].ToString()) : DateTime.Parse("");
                                model.ValotTotalPedido = reader["ValotTotalPedido"] != null ? double.Parse(reader["ValotTotalPedido"].ToString()) : 0;
                                model.ValorLucroVendedora = reader["ValorLucroVendedora"] != null ? double.Parse(reader["ValorLucroVendedora"].ToString()) : 0;
                                model.ValorLucroDistribuidor = reader["ValorLucroDistribuidor"] != null ? double.Parse(reader["ValorLucroDistribuidor"].ToString()) : 0;
                                model.Enviado = bool.Parse(reader["Enviado"].ToString());
                                model.Separado = bool.Parse(reader["Separado"].ToString());
                                model.Conferido = bool.Parse(reader["Conferido"].ToString());
                                model.Despachado = bool.Parse(reader["Despachado"].ToString());
                                model.Entregue = bool.Parse(reader["Entregue"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

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
                                model.DataEnvio = reader["DataEnvio"] != null ? DateTime.Parse(reader["DataEnvio"].ToString()) : DateTime.Parse("");
                                model.DataSeparacao = reader["DataSeparacao"] != null ? DateTime.Parse(reader["DataSeparacao"].ToString()) : DateTime.Parse("");
                                model.DataConferencia = reader["DataConferencia"] != null ? DateTime.Parse(reader["DataConferencia"].ToString()) : DateTime.Parse("");
                                model.DataDespacho = reader["DataDespacho"] != null ? DateTime.Parse(reader["DataDespacho"].ToString()) : DateTime.Parse("");
                                model.DataCancelamento = reader["DataCancelamento"] != null ? DateTime.Parse(reader["DataCancelamento"].ToString()) : DateTime.Parse("");
                                model.DataEntrega = reader["DataEntrega"] != null ? DateTime.Parse(reader["DataEntrega"].ToString()) : DateTime.Parse("");
                                model.ValotTotalPedido = reader["ValotTotalPedido"] != null ? double.Parse(reader["ValotTotalPedido"].ToString()) : 0;
                                model.ValorLucroVendedora = reader["ValorLucroVendedora"] != null ? double.Parse(reader["ValorLucroVendedora"].ToString()) : 0;
                                model.ValorLucroDistribuidor = reader["ValorLucroDistribuidor"] != null ? double.Parse(reader["ValorLucroDistribuidor"].ToString()) : 0;
                                model.Enviado = bool.Parse(reader["Enviado"].ToString());
                                model.Separado = bool.Parse(reader["Separado"].ToString());
                                model.Conferido = bool.Parse(reader["Conferido"].ToString());
                                model.Despachado = bool.Parse(reader["Despachado"].ToString());
                                model.Entregue = bool.Parse(reader["Entregue"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

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
                                model.DataEnvio = reader["DataEnvio"] != null ? DateTime.Parse(reader["DataEnvio"].ToString()) : DateTime.Parse("");
                                model.DataSeparacao = reader["DataSeparacao"] != null ? DateTime.Parse(reader["DataSeparacao"].ToString()) : DateTime.Parse("");
                                model.DataConferencia = reader["DataConferencia"] != null ? DateTime.Parse(reader["DataConferencia"].ToString()) : DateTime.Parse("");
                                model.DataDespacho = reader["DataDespacho"] != null ? DateTime.Parse(reader["DataDespacho"].ToString()) : DateTime.Parse("");
                                model.DataCancelamento = reader["DataCancelamento"] != null ? DateTime.Parse(reader["DataCancelamento"].ToString()) : DateTime.Parse("");
                                model.DataEntrega = reader["DataEntrega"] != null ? DateTime.Parse(reader["DataEntrega"].ToString()) : DateTime.Parse("");
                                model.ValotTotalPedido = reader["ValotTotalPedido"] != null ? double.Parse(reader["ValotTotalPedido"].ToString()) : 0;
                                model.ValorLucroVendedora = reader["ValorLucroVendedora"] != null ? double.Parse(reader["ValorLucroVendedora"].ToString()) : 0;
                                model.ValorLucroDistribuidor = reader["ValorLucroDistribuidor"] != null ? double.Parse(reader["ValorLucroDistribuidor"].ToString()) : 0;
                                model.Enviado = bool.Parse(reader["Enviado"].ToString());
                                model.Separado = bool.Parse(reader["Separado"].ToString());
                                model.Conferido = bool.Parse(reader["Conferido"].ToString());
                                model.Despachado = bool.Parse(reader["Despachado"].ToString());
                                model.Entregue = bool.Parse(reader["Entregue"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

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
                                model.DataEnvio = reader["DataEnvio"] != null ? DateTime.Parse(reader["DataEnvio"].ToString()) : DateTime.Parse("");
                                model.DataSeparacao = reader["DataSeparacao"] != null ? DateTime.Parse(reader["DataSeparacao"].ToString()) : DateTime.Parse("");
                                model.DataConferencia = reader["DataConferencia"] != null ? DateTime.Parse(reader["DataConferencia"].ToString()) : DateTime.Parse("");
                                model.DataDespacho = reader["DataDespacho"] != null ? DateTime.Parse(reader["DataDespacho"].ToString()) : DateTime.Parse("");
                                model.DataCancelamento = reader["DataCancelamento"] != null ? DateTime.Parse(reader["DataCancelamento"].ToString()) : DateTime.Parse("");
                                model.DataEntrega = reader["DataEntrega"] != null ? DateTime.Parse(reader["DataEntrega"].ToString()) : DateTime.Parse("");
                                model.ValotTotalPedido = reader["ValotTotalPedido"] != null ? double.Parse(reader["ValotTotalPedido"].ToString()) : 0;
                                model.ValorLucroVendedora = reader["ValorLucroVendedora"] != null ? double.Parse(reader["ValorLucroVendedora"].ToString()) : 0;
                                model.ValorLucroDistribuidor = reader["ValorLucroDistribuidor"] != null ? double.Parse(reader["ValorLucroDistribuidor"].ToString()) : 0;
                                model.Enviado = bool.Parse(reader["Enviado"].ToString());
                                model.Separado = bool.Parse(reader["Separado"].ToString());
                                model.Conferido = bool.Parse(reader["Conferido"].ToString());
                                model.Despachado = bool.Parse(reader["Despachado"].ToString());
                                model.Entregue = bool.Parse(reader["Entregue"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

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
                                model.DataEnvio = reader["DataEnvio"] != null ? DateTime.Parse(reader["DataEnvio"].ToString()) : DateTime.Parse("");
                                model.DataSeparacao = reader["DataSeparacao"] != null ? DateTime.Parse(reader["DataSeparacao"].ToString()) : DateTime.Parse("");
                                model.DataConferencia = reader["DataConferencia"] != null ? DateTime.Parse(reader["DataConferencia"].ToString()) : DateTime.Parse("");
                                model.DataDespacho = reader["DataDespacho"] != null ? DateTime.Parse(reader["DataDespacho"].ToString()) : DateTime.Parse("");
                                model.DataCancelamento = reader["DataCancelamento"] != null ? DateTime.Parse(reader["DataCancelamento"].ToString()) : DateTime.Parse("");
                                model.DataEntrega = reader["DataEntrega"] != null ? DateTime.Parse(reader["DataEntrega"].ToString()) : DateTime.Parse("");
                                model.ValotTotalPedido = reader["ValotTotalPedido"] != null ? double.Parse(reader["ValotTotalPedido"].ToString()) : 0;
                                model.ValorLucroVendedora = reader["ValorLucroVendedora"] != null ? double.Parse(reader["ValorLucroVendedora"].ToString()) : 0;
                                model.ValorLucroDistribuidor = reader["ValorLucroDistribuidor"] != null ? double.Parse(reader["ValorLucroDistribuidor"].ToString()) : 0;
                                model.Enviado = bool.Parse(reader["Enviado"].ToString());
                                model.Separado = bool.Parse(reader["Separado"].ToString());
                                model.Conferido = bool.Parse(reader["Conferido"].ToString());
                                model.Despachado = bool.Parse(reader["Despachado"].ToString());
                                model.Entregue = bool.Parse(reader["Entregue"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

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
                                model.DataEnvio = reader["DataEnvio"] != null ? DateTime.Parse(reader["DataEnvio"].ToString()) : DateTime.Parse("");
                                model.DataSeparacao = reader["DataSeparacao"] != null ? DateTime.Parse(reader["DataSeparacao"].ToString()) : DateTime.Parse("");
                                model.DataConferencia = reader["DataConferencia"] != null ? DateTime.Parse(reader["DataConferencia"].ToString()) : DateTime.Parse("");
                                model.DataDespacho = reader["DataDespacho"] != null ? DateTime.Parse(reader["DataDespacho"].ToString()) : DateTime.Parse("");
                                model.DataCancelamento = reader["DataCancelamento"] != null ? DateTime.Parse(reader["DataCancelamento"].ToString()) : DateTime.Parse("");
                                model.DataEntrega = reader["DataEntrega"] != null ? DateTime.Parse(reader["DataEntrega"].ToString()) : DateTime.Parse("");
                                model.ValotTotalPedido = reader["ValotTotalPedido"] != null ? double.Parse(reader["ValotTotalPedido"].ToString()) : 0;
                                model.ValorLucroVendedora = reader["ValorLucroVendedora"] != null ? double.Parse(reader["ValorLucroVendedora"].ToString()) : 0;
                                model.ValorLucroDistribuidor = reader["ValorLucroDistribuidor"] != null ? double.Parse(reader["ValorLucroDistribuidor"].ToString()) : 0;
                                model.Enviado = bool.Parse(reader["Enviado"].ToString());
                                model.Separado = bool.Parse(reader["Separado"].ToString());
                                model.Conferido = bool.Parse(reader["Conferido"].ToString());
                                model.Despachado = bool.Parse(reader["Despachado"].ToString());
                                model.Entregue = bool.Parse(reader["Entregue"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

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
                                model.DataEnvio = reader["DataEnvio"] != null ? DateTime.Parse(reader["DataEnvio"].ToString()) : DateTime.Parse("");
                                model.DataSeparacao = reader["DataSeparacao"] != null ? DateTime.Parse(reader["DataSeparacao"].ToString()) : DateTime.Parse("");
                                model.DataConferencia = reader["DataConferencia"] != null ? DateTime.Parse(reader["DataConferencia"].ToString()) : DateTime.Parse("");
                                model.DataDespacho = reader["DataDespacho"] != null ? DateTime.Parse(reader["DataDespacho"].ToString()) : DateTime.Parse("");
                                model.DataCancelamento = reader["DataCancelamento"] != null ? DateTime.Parse(reader["DataCancelamento"].ToString()) : DateTime.Parse("");
                                model.DataEntrega = reader["DataEntrega"] != null ? DateTime.Parse(reader["DataEntrega"].ToString()) : DateTime.Parse("");
                                model.ValotTotalPedido = reader["ValotTotalPedido"] != null ? double.Parse(reader["ValotTotalPedido"].ToString()) : 0;
                                model.ValorLucroVendedora = reader["ValorLucroVendedora"] != null ? double.Parse(reader["ValorLucroVendedora"].ToString()) : 0;
                                model.ValorLucroDistribuidor = reader["ValorLucroDistribuidor"] != null ? double.Parse(reader["ValorLucroDistribuidor"].ToString()) : 0;
                                model.Enviado = bool.Parse(reader["Enviado"].ToString());
                                model.Separado = bool.Parse(reader["Separado"].ToString());
                                model.Conferido = bool.Parse(reader["Conferido"].ToString());
                                model.Despachado = bool.Parse(reader["Despachado"].ToString());
                                model.Entregue = bool.Parse(reader["Entregue"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());

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
                                model.DataEnvio = reader["DataEnvio"] != null ? DateTime.Parse(reader["DataEnvio"].ToString()) : DateTime.Parse("");
                                model.DataSeparacao = reader["DataSeparacao"] != null ? DateTime.Parse(reader["DataSeparacao"].ToString()) : DateTime.Parse("");
                                model.DataConferencia = reader["DataConferencia"] != null ? DateTime.Parse(reader["DataConferencia"].ToString()) : DateTime.Parse("");
                                model.DataDespacho = reader["DataDespacho"] != null ? DateTime.Parse(reader["DataDespacho"].ToString()) : DateTime.Parse("");
                                model.DataCancelamento = reader["DataCancelamento"] != null ? DateTime.Parse(reader["DataCancelamento"].ToString()) : DateTime.Parse("");
                                model.DataEntrega = reader["DataEntrega"] != null ? DateTime.Parse(reader["DataEntrega"].ToString()) : DateTime.Parse("");
                                model.ValotTotalPedido = reader["ValotTotalPedido"] != null ? double.Parse(reader["ValotTotalPedido"].ToString()) : 0;
                                model.ValorLucroVendedora = reader["ValorLucroVendedora"] != null ? double.Parse(reader["ValorLucroVendedora"].ToString()) : 0;
                                model.ValorLucroDistribuidor = reader["ValorLucroDistribuidor"] != null ? double.Parse(reader["ValorLucroDistribuidor"].ToString()) : 0;
                                model.Enviado = bool.Parse(reader["Enviado"].ToString());
                                model.Separado = bool.Parse(reader["Separado"].ToString());
                                model.Conferido = bool.Parse(reader["Conferido"].ToString());
                                model.Despachado = bool.Parse(reader["Despachado"].ToString());
                                model.Entregue = bool.Parse(reader["Entregue"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());
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
                                model.DataEnvio = reader["DataEnvio"] != null ? DateTime.Parse(reader["DataEnvio"].ToString()) : DateTime.Parse("");
                                model.DataSeparacao = reader["DataSeparacao"] != null ? DateTime.Parse(reader["DataSeparacao"].ToString()) : DateTime.Parse("");
                                model.DataConferencia = reader["DataConferencia"] != null ? DateTime.Parse(reader["DataConferencia"].ToString()) : DateTime.Parse("");
                                model.DataDespacho = reader["DataDespacho"] != null ? DateTime.Parse(reader["DataDespacho"].ToString()) : DateTime.Parse("");
                                model.DataCancelamento = reader["DataCancelamento"] != null ? DateTime.Parse(reader["DataCancelamento"].ToString()) : DateTime.Parse("");
                                model.DataEntrega = reader["DataEntrega"] != null ? DateTime.Parse(reader["DataEntrega"].ToString()) : DateTime.Parse("");
                                model.ValotTotalPedido = reader["ValotTotalPedido"] != null ? double.Parse(reader["ValotTotalPedido"].ToString()) : 0;
                                model.ValorLucroVendedora = reader["ValorLucroVendedora"] != null ? double.Parse(reader["ValorLucroVendedora"].ToString()) : 0;
                                model.ValorLucroDistribuidor = reader["ValorLucroDistribuidor"] != null ? double.Parse(reader["ValorLucroDistribuidor"].ToString()) : 0;
                                model.Enviado = bool.Parse(reader["Enviado"].ToString());
                                model.Separado = bool.Parse(reader["Separado"].ToString());
                                model.Conferido = bool.Parse(reader["Conferido"].ToString());
                                model.Despachado = bool.Parse(reader["Despachado"].ToString());
                                model.Entregue = bool.Parse(reader["Entregue"].ToString());
                                model.Cancelado = bool.Parse(reader["Cancelado"].ToString());
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


        public void SomarLucroDistribuidor(IPedidosVendedorasModel pedido)
        {
            throw new NotImplementedException();
        }

        public void SomarLucroVendedora(IPedidosVendedorasModel pedido)
        {
            throw new NotImplementedException();
        }

        public void SomarTotalPedido(IPedidosVendedorasModel pedido)
        {
            throw new NotImplementedException();
        }


    }
}
