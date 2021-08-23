using CommonComponents;

using DomainLayer.Models.Catalogos;

using Microsoft.Win32;

using ServiceLayer.Services.CatalogoServices;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Catalogo
{
    public class CatalogoRepository : ICatalogoRepository
    {
        private string _connectionString;

        enum TypeOfExistanceCheck
        {
            ExistInDb,
            NotExistInDb
        }

        enum RequestType
        {
            Add,
            Update,
            Read,
            Delete,
            ConfirmAdd,
            ConfirmDelete
        }

        public CatalogoRepository()
        {

        }

        public CatalogoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CatalogoModel Add(ICatalogoModel catalogoModel)
        {
            int idReturned = 0;
            CatalogoModel model = new CatalogoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = null;

            if (catalogoModel.VariacaoDeValor)
            {
                query = "INSERT INTO Catalogos " +
                        "(Nome, MargemPadraoVendedora, MargemPadraoDistribuidor, Ativo, TaxaProduto, ValorTaxaProduto, TaxaPedido, ValorTaxaPedido, VariacaoDeValor, TamanhoValorVariavel, NumeracaoValorVariavel, FornecedorId, ImportaProdutos) " +
                        "output INSERTED.CatalogoId " +
                        "VALUES (@Nome, @MargemPadraoVendedora, @MargemPadraoDistribuidor, @Ativo, @TaxaProduto, @ValorTaxaProduto, @TaxaPedido, @ValorTaxaPedido, @VariacaoDeValor, @TamanhoValorVariavel, @NumeracaoValorVariavel, @FornecedorId, @ImportaProdutos) ";
            }
            else
            {
                query = "INSERT INTO Catalogos " +
                        "(Nome,  MargemPadraoVendedora,  MargemPadraoDistribuidor,  Ativo,  FornecedorId, TaxaProduto,  ValorTaxaProduto,  TaxaPedido,  ValorTaxaPedido,  ImportaProdutos) " +
                        "output INSERTED.CatalogoId " +
                        "VALUES " +
                        "(@Nome, @MargemPadraoVendedora, @MargemPadraoDistribuidor, @Ativo, @FornecedorId, @TaxaProduto, @ValorTaxaProduto, @TaxaPedido, @ValorTaxaPedido,  @ImportaProdutos) ";
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {

                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Nome", catalogoModel.Nome);
                        cmd.Parameters.AddWithValue("@MargemPadraoVendedora", catalogoModel.MargemPadraoVendedora);
                        cmd.Parameters.AddWithValue("@MargemPadraoDistribuidor", catalogoModel.MargemPadraoDistribuidor);
                        cmd.Parameters.AddWithValue("@Ativo", catalogoModel.Ativo);
                        cmd.Parameters.AddWithValue("@TaxaProduto", catalogoModel.TaxaProduto);
                        cmd.Parameters.AddWithValue("@ValorTaxaProduto", catalogoModel.ValorTaxaProduto);
                        cmd.Parameters.AddWithValue("@TaxaPedido", catalogoModel.TaxaPedido);
                        cmd.Parameters.AddWithValue("@ValorTaxaPedido", catalogoModel.ValorTaxaPedido);
                        cmd.Parameters.AddWithValue("@FornecedorId", catalogoModel.FornecedorId);
                        cmd.Parameters.AddWithValue("@ImportaProdutos", catalogoModel.ImportaProdutos);

                        if (catalogoModel.VariacaoDeValor)
                        {
                            cmd.Parameters.AddWithValue("@VariacaoDeValor", catalogoModel.VariacaoDeValor);
                            cmd.Parameters.AddWithValue("@TamanhoValorVariavel", catalogoModel.TamanhoValorVariavel);
                            cmd.Parameters.AddWithValue("@NumeracaoValorVariavel", catalogoModel.NumeracaoValorVariavel);
                        }

                        try
                        {
                            idReturned = (int)cmd.ExecuteScalar();
                        }
                        catch (SqlException e)
                        {
                            dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível Adicionar um Novo Catálogo", e.HelpLink,
                                e.ErrorCode, e.StackTrace);
                            throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                        }

                        //CONFIRMAÇÃO DE INSERÇÃO DE DADOS
                        try
                        {

                        }
                        catch (DataAccessException e)
                        {
                            e.DataAccessStatusInfo.Status = "Error";
                            e.DataAccessStatusInfo.OperationSucceeded = false;
                            e.DataAccessStatusInfo.CustomMessage = "Falha ao buscar Catálogo no DataBase após a inserção.";
                            e.DataAccessStatusInfo.ExceptionMessage = e.Message;
                            e.DataAccessStatusInfo.StackTrace = e.StackTrace;


                            throw e;
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Falha ao tentar inserir um Novo Catálogo", e.HelpLink, e.ErrorCode,
                        e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                model = GetById(idReturned);
                return model;

            }
        }

        public void Delete(ICatalogoModel catalogoModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "DELETE FROM Catalogos WHERE CatalogoId = @CatalogoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@CatalogoId", catalogoModel.CatalogoId);

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "FAlha ao tentar delatar Catálogo", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<ICatalogoModel> GetAll()
        {
            List<CatalogoModel> modelList = new List<CatalogoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            string query = "SELECT * FROM Catalogos";

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
                                CatalogoModel model = new CatalogoModel();

                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());
                                model.Nome = reader["Nome"].ToString();
                                model.MargemPadraoVendedora = float.Parse(reader["MargemPadraoVendedora"].ToString());
                                model.MargemPadraoDistribuidor = float.Parse(reader["MargemPadraoDistribuidor"].ToString());
                                model.Ativo = bool.Parse(reader["Ativo"].ToString());
                                model.TaxaProduto = bool.Parse(reader["TaxaProduto"].ToString());
                                model.TaxaPedido = bool.Parse(reader["TaxaProduto"].ToString());
                                model.ValorTaxaPedido = float.Parse(reader["ValorTaxaPedido"].ToString());
                                model.ValorTaxaProduto = float.Parse(reader["ValorTaxaProduto"].ToString());
                                model.VariacaoDeValor = bool.Parse(reader["VariacaoDeValor"].ToString());
                                model.TamanhoValorVariavel = reader["TamanhoValorVariavel"].ToString();
                                model.NumeracaoValorVariavel = reader["NumeracaoValorVariavel"].ToString();
                                model.FornecedorId = int.Parse(reader["FornecedorId"].ToString());
                                model.ImportaProdutos = bool.Parse(reader["ImportaProdutos"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível gerar a lista de Catálogos do DataBase", e.HelpLink,
                        e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return modelList;
        }

        public IEnumerable<ICatalogoModel> GetByFornecedorId(int fornecedorId)
        {
            List<CatalogoModel> modelList = new List<CatalogoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM Catalogos WHERE FornecedorId = @FornecedorId";

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
                                CatalogoModel model = new CatalogoModel();

                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());
                                model.Nome = reader["Nome"].ToString();
                                model.MargemPadraoVendedora = float.Parse(reader["MargemPadraoVendedora"].ToString());
                                model.MargemPadraoDistribuidor = float.Parse(reader["MargemPadraoDistribuidor"].ToString());
                                model.Ativo = bool.Parse(reader["Ativo"].ToString());
                                model.TaxaProduto = bool.Parse(reader["TaxaProduto"].ToString());
                                model.TaxaPedido = bool.Parse(reader["TaxaPedido"].ToString());
                                model.ValorTaxaProduto = float.Parse(reader["ValorTaxaProduto"].ToString());
                                model.ValorTaxaPedido = float.Parse(reader["ValorTaxaPedido"].ToString());
                                model.VariacaoDeValor = bool.Parse(reader["VariacaoDeValor"].ToString());
                                model.TamanhoValorVariavel = reader["TamanhoValorVariavel"].ToString();
                                model.NumeracaoValorVariavel = reader["NumeracaoValorVariavel"].ToString();
                                model.FornecedorId = int.Parse(reader["FornecedorId"].ToString());
                                model.ImportaProdutos = bool.Parse(reader["ImportaProdutos"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível gerar a lista de catálogos.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                return modelList;
            }
        }

        public CatalogoModel GetById(int id)
        {
            CatalogoModel model = new CatalogoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT " +
                           "CatalogoId, " +
                           "Nome, " +
                           "MargemPadraoVendedora, " +
                           "MargemPadraoDistribuidor, " +
                           "Ativo, " +
                           "TaxaProduto, " +
                           "ValorTaxaProduto, " +
                           "TaxaPedido, " +
                           "ValorTaxaPedido, " +
                           "VariacaoDeValor, " +
                           "TamanhoValorVariavel, " +
                           "NumeracaoValorVariavel, " +
                           "FornecedorId, " +
                           "ImportaProdutos " +
                           "FROM Catalogos " +
                           "WHERE CatalogoId = @CatalogoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@CatalogoId", id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.CatalogoId = int.Parse(reader["CatalogoId"].ToString());
                                model.Nome = reader["Nome"].ToString();
                                model.MargemPadraoVendedora = float.Parse(reader["MargemPadraoVendedora"].ToString());
                                model.MargemPadraoDistribuidor = float.Parse(reader["MargemPadraoDistribuidor"].ToString());
                                model.Ativo = bool.Parse(reader["Ativo"].ToString());
                                model.TaxaProduto = bool.Parse(reader["TaxaProduto"].ToString());
                                model.TaxaPedido = bool.Parse(reader["TaxaPedido"].ToString());
                                model.ValorTaxaProduto = float.Parse(reader["ValorTaxaProduto"].ToString());
                                model.ValorTaxaPedido = float.Parse(reader["ValorTaxaPedido"].ToString());
                                model.VariacaoDeValor = bool.Parse(reader["VariacaoDeValor"].ToString());
                                model.TamanhoValorVariavel = reader["TamanhoValorVariavel"].ToString();
                                model.NumeracaoValorVariavel = reader["NumeracaoValorVariavel"].ToString();
                                model.FornecedorId = int.Parse(reader["FornecedorId"].ToString());
                                model.ImportaProdutos = bool.Parse(reader["ImportaProdutos"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível buscar o Catálogo no DataBase.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return model;
        }

        public void Update(ICatalogoModel catalogoModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE Catalogos " +
                           "SET " +
                           "Nome = @Nome, " +
                           "MargemPadraoVendedora = @MargemPadraoVendedora, " +
                           "MargemPadraoDistribuidor = @MargemPadraoDistribuidor, " +
                           "Ativo = @Ativo, " +
                           "TaxaPedido = @TaxaPedido, " +
                           "ValorTaxaPedido = @ValorTaxaPedido, " +
                           "TaxaProduto = @TaxaProduto, " +
                           "ValorTaxaProduto = @ValorTaxaProduto, " +
                           "VariacaoDeValor = @VariacaoDeValor, " +
                           "TamanhoValorVariavel = @TamanhoValorVariavel, " +
                           "NumeracaoValorVariavel = @NumeracaoValorVariavel, " +
                           "FornecedorId = @FornecedorId, " +
                           "ImportaProdutos = @ImportaProdutos " +
                           "WHERE CatalogoId = @CatalogoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@CatalogoId", catalogoModel.CatalogoId);
                        cmd.Parameters.AddWithValue("@Nome", catalogoModel.Nome);
                        cmd.Parameters.AddWithValue("@MargemPadraoVendedora", catalogoModel.MargemPadraoVendedora);
                        cmd.Parameters.AddWithValue("@MargemPadraoDistribuidor", catalogoModel.MargemPadraoDistribuidor);
                        cmd.Parameters.AddWithValue("@ValorTaxaPedido", catalogoModel.ValorTaxaPedido);
                        cmd.Parameters.AddWithValue("@ValorTaxaProduto", catalogoModel.ValorTaxaProduto);
                        cmd.Parameters.Add("@TaxaPedido", SqlDbType.Bit).Value = catalogoModel.TaxaPedido;
                        cmd.Parameters.Add("@TaxaProduto", SqlDbType.Bit).Value = catalogoModel.TaxaProduto;
                        cmd.Parameters.Add("@Ativo", SqlDbType.Bit).Value = catalogoModel.Ativo;
                        cmd.Parameters.Add("@VariacaoDeValor", SqlDbType.Bit).Value = catalogoModel.VariacaoDeValor;
                        cmd.Parameters.AddWithValue("@TamanhoValorVariavel", catalogoModel.TamanhoValorVariavel);
                        cmd.Parameters.AddWithValue("@NumeracaoValorVariavel", catalogoModel.NumeracaoValorVariavel);
                        cmd.Parameters.AddWithValue("@FornecedorId", catalogoModel.FornecedorId);
                        cmd.Parameters.AddWithValue("@ImportaProdutos", catalogoModel.ImportaProdutos);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível atualizar o Catálogo.", e.HelpLink, e.ErrorCode, e.StackTrace);
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
