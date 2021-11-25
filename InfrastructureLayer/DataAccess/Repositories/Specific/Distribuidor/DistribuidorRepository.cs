using CommonComponents;

using DomainLayer.Models.Distribuidor;

using ServiceLayer.Services.DistribuidorServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Distribuidor
{
    public class DistribuidorRepository : IDistribuidorRepository
    {
        private string _connectionString;
        enum TypeOfExistenceCheck
        {
            ExistIndb,
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

        public DistribuidorRepository()
        {

        }

        public DistribuidorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DistribuidorModel Add(IDistribuidorModel distribuidorModel)
        {
            int idReturned = 0;
            DistribuidorModel distribuidorReturned = new DistribuidorModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            string query = "INSERT INTO Distribuidor " +
                "(NomeFantasia, RazaoSocial, Cnpj, InscricaoEstadual, Email, WebSite, NomeResponsavel, DiaVencimento, DiaEmissaoPromissoria, TelefoneContato, " +
                "Logradouro, Numero, Complemento, Cep, UfId, CidadeId, BairroId) " +
                "OUTPUT INSERTED.DistribuidorId " +
                "VALUES " +
                "(@NomeFantasia, @RazaoSocial, @Cnpj, @InscricaoEstadual, @Email, @WebSite, @NomeResponsavel, @DiaVencimento, @DiaEmissaoPromissoria, @TelefoneContato, @Logradouro, @Numero, @Complemento, @Cep, @UfId, @CidadeId, @BairroId)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@NomeFantasia", distribuidorModel.NomeFantasia);
                        cmd.Parameters.AddWithValue("@RazaoSocial", distribuidorModel.RazaoSocial);
                        cmd.Parameters.AddWithValue("@Cnpj", distribuidorModel.Cnpj);
                        cmd.Parameters.AddWithValue("@InscricaoEstadual", distribuidorModel.InscricaoEstadual);
                        cmd.Parameters.AddWithValue("@Email", distribuidorModel.Email);
                        cmd.Parameters.AddWithValue("@WebSite", distribuidorModel.WebSite);
                        cmd.Parameters.AddWithValue("@NomeResponsavel", distribuidorModel.NomeResponsavel);
                        cmd.Parameters.AddWithValue("@DiaVencimento", distribuidorModel.DiaVencimento);
                        cmd.Parameters.AddWithValue("@DiaEmissaoPromissoria", distribuidorModel.DiaEmissaoPromissoria);
                        cmd.Parameters.AddWithValue("@TelefoneContato", distribuidorModel.TelefoneContato);
                        cmd.Parameters.AddWithValue("@Logradouro", distribuidorModel.Logradouro);
                        cmd.Parameters.AddWithValue("@Numero", distribuidorModel.Numero);
                        cmd.Parameters.AddWithValue("@Complemento", distribuidorModel.Complemento);
                        cmd.Parameters.AddWithValue("@Cep", distribuidorModel.Cep);
                        cmd.Parameters.AddWithValue("@UfId", distribuidorModel.UfId);
                        cmd.Parameters.AddWithValue("@CidadeId", distribuidorModel.CidadeId);
                        cmd.Parameters.AddWithValue("@BairroId", distribuidorModel.BairroId);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar registro. DistribuidorAdd",
                        e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);

                }
                finally
                {
                    connection.Close();
                }

                distribuidorReturned = GetModel();
                return distribuidorReturned;
            }
        }

        public DistribuidorModel GetModel()
        {

            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            DistribuidorModel model = new DistribuidorModel();
            string query = "SELECT TOP 1 * FROM Distribuidor";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        //cmd.Parameters.Add(new SqlParameter("@DistibuidorId", id));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.DistribuidorId = int.Parse(reader["DistribuidorId"].ToString());
                                model.NomeFantasia = reader["NomeFantasia"].ToString();
                                model.RazaoSocial = reader["RazaoSocial"].ToString();
                                model.Cnpj = reader["Cnpj"].ToString();
                                model.InscricaoEstadual = reader["InscricaoEstadual"] != null ? reader["InscricaoEstadual"].ToString() : string.Empty;
                                model.Email = reader["Email"] != null ? reader["Email"].ToString() : string.Empty;
                                model.WebSite = reader["WebSite"] != null ? reader["WebSite"].ToString() : string.Empty;
                                model.NomeResponsavel = reader["NomeResponsavel"].ToString();
                                model.DiaVencimento = int.Parse(reader["DiaVencimento"].ToString());
                                model.DiaEmissaoPromissoria = int.Parse(reader["DiaEmissaoPromissoria"].ToString());
                                model.TelefoneContato = reader["TelefoneContato"].ToString();
                                model.Logradouro = reader["Logradouro"].ToString();
                                model.Numero = reader["Numero"].ToString();
                                model.Complemento = reader["Complemento"] != null ? reader["Complemento"].ToString() : string.Empty;
                                model.Cep = reader["Cep"].ToString();
                                model.UfId = int.Parse(reader["UfId"].ToString());
                                model.CidadeId = int.Parse(reader["CidadeId"].ToString());
                                model.BairroId = int.Parse(reader["BairroId"].ToString());
                            }
                        }

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar os dados do Distribuidor", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                return model;
            }
        }

        public void Update(IDistribuidorModel distribuidorModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE Distribuidor " +
                           "SET NomeFantasia = @NomeFantasia, RazaoSocial = @RazaoSocial, Cnpj = @Cnpj, " +
                           "InscricaoEstadual = @InscricaoEstadual, Email = @Email, WebSite = @WebSite, " +
                           "NomeResponsavel = @NomeResponsavel, DiaVencimento = @DiaVencimento, " +
                           "DiaEmissaoPromissoria = @DiaEmissaoPromissoria, TelefoneContato = @TelefoneContato, " +
                           "Logradouro = @Logradouro, Numero = @Numero, Complemento = @Complemento, Cep = @Cep, " +
                           "UfId = @UfId, CidadeId = @CidadeId, BairroId = @BairroId " +
                           "WHERE DistribuidorId = @DistribuidorId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@DistribuidorId", distribuidorModel.DistribuidorId);
                        cmd.Parameters.AddWithValue("@NomeFantasia", distribuidorModel.NomeFantasia);
                        cmd.Parameters.AddWithValue("@RazaoSocial", distribuidorModel.RazaoSocial);
                        cmd.Parameters.AddWithValue("@Cnpj", distribuidorModel.Cnpj);
                        cmd.Parameters.AddWithValue("@InscricaoEstadual", distribuidorModel.InscricaoEstadual);
                        cmd.Parameters.AddWithValue("@Email", distribuidorModel.Email);
                        cmd.Parameters.AddWithValue("@WebSite", distribuidorModel.WebSite);
                        cmd.Parameters.AddWithValue("@NomeResponsavel", distribuidorModel.NomeResponsavel);
                        cmd.Parameters.AddWithValue("@DiaVencimento", distribuidorModel.DiaVencimento);
                        cmd.Parameters.AddWithValue("@DiaEmissaoPromissoria", distribuidorModel.DiaEmissaoPromissoria);
                        cmd.Parameters.AddWithValue("@TelefoneContato", distribuidorModel.TelefoneContato);
                        cmd.Parameters.AddWithValue("@Logradouro", distribuidorModel.Logradouro);
                        cmd.Parameters.AddWithValue("@Numero", distribuidorModel.Numero);
                        cmd.Parameters.AddWithValue("@Complemento", distribuidorModel.Complemento);
                        cmd.Parameters.AddWithValue("@Cep", distribuidorModel.Cep);
                        cmd.Parameters.AddWithValue("@UfId", distribuidorModel.UfId);
                        cmd.Parameters.AddWithValue("@CidadeId", distribuidorModel.CidadeId);
                        cmd.Parameters.AddWithValue("@BairroId", distribuidorModel.BairroId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível atualizar os dados do Distribuidor", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                    throw;
                }
            }
        }
    }
}