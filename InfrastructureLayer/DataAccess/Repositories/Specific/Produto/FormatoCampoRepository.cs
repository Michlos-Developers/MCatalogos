using CommonComponents;

using DomainLayer.Models.Produtos;

using ServiceLayer.Services.ProdutoServices;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Produto
{
    public class FormatoCampoRepository : IFormatoCampoRepository
    {
        private string _connectionString;

        enum TypeOfExistenceCheck
        {
            ExistInDb,
            NotExistInDb

        }

        enum RequestType
        {
            Read
        }

        public FormatoCampoRepository()
        {

        }

        public FormatoCampoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<IFormatoCampoModel> GetAll()
        {
            List<FormatoCampoModel> modelList = new List<FormatoCampoModel>();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM FormatosCampos";


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
                                FormatoCampoModel model = new FormatoCampoModel();
                                model.FormatoId = int.Parse(reader["FormatoId"].ToString());
                                model.Nome = reader["Nome"].ToString();
                                model.Formato = reader["Formato"].ToString();

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Não foi possível trazer a lista de Formatos de Campos", helpLink: e.HelpLink, errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
                return modelList;
            }
        }

        public FormatoCampoModel GetById(int formatoId)
        {
            FormatoCampoModel model = new FormatoCampoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool RecordFound = false;
            string query = "SELECT Nome, Formato FROM FormatosCampos WHERE FormatoId = @FormatoId";
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@FormatoId", formatoId));
                        
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            RecordFound = reader.HasRows;
                            while (reader.Read())
                            {
                                model.FormatoId = int.Parse(reader["FormatoId"].ToString());
                                model.Nome = reader["Nome"].ToString();
                                model.Formato = reader["Formato"].ToString();
                            }
                        }
                    }

                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Não foi possível recuperar o Formato do Campo no DataBase", helpLink: e.HelpLink, errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                if (!RecordFound)
                {
                    dataAccessStatus.setValues("Error", false, "", "Registro não encontrado. Não foi possível recuperar o FormatoCampoModel do DataBase",
                        "", 0, "");
                    throw new DataAccessException(dataAccessStatus);
                }

                return model;
            }
        }

        public FormatoCampoModel GetByNome(string nomeFormato)
        {
            FormatoCampoModel model = new FormatoCampoModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool recordFound = false;
            string query = "SELECT * FROM FormatosCampos WHERE Nome = @Nome";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Nome", nomeFormato));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            recordFound = reader.HasRows;

                            while (reader.Read())
                            {
                                model.FormatoId = int.Parse(reader["FormatoId"].ToString());
                                model.Nome = reader["Nome"].ToString();
                                model.Formato = reader["Formato"].ToString();

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: e.Message,
                        customMessage: "Não foi possível recuperar o FormatoCampoModel do DataBase", helpLink: e.HelpLink, errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                if (!recordFound)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: "",
                         customMessage: $"Registro não encontrado. Não foi possível recuperar o FormatoCampoModel do DataBase",
                         helpLink: "", errorCode: 0, stackTrace: "");
                    throw new DataAccessException(dataAccessStatus);
                }
                return model;
            }

        }
    }
}
