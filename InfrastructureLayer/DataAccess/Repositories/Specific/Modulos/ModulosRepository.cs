using CommonComponents;

using DomainLayer.Models.Modulos;

using ServiceLayer.Services.ModulosServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Modulos
{
    public class ModulosRepository : IModulosRepository
    {
        private string _connectionString;

        public ModulosRepository()
        {

        }
        public ModulosRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ModulosModel Disable(IModulosModel modulo)
        {
            ModulosModel model = new ModulosModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE Modulos SET Ativo = @Ativo WHERE ModuloId = @ModuloId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@ModuloId", modulo.ModuloId);
                        cmd.Parameters.Add(new SqlParameter("@ModuloId", false));

                        cmd.ExecuteNonQuery();
                        model = modulo as ModulosModel;
                        model.Ativo = false;
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível desabilitar o módulo", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return model;

            

            
        }

        public ModulosModel Enable(IModulosModel modulo)
        {
            ModulosModel model = new ModulosModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "UPDATE Modulos SET Ativo = @Ativo WHERE ModuloId = @ModuloId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@ModuloId", modulo.ModuloId);
                        cmd.Parameters.Add(new SqlParameter("@ModuloId", true));

                        cmd.ExecuteNonQuery();
                        model = modulo as ModulosModel;
                        model.Ativo = true;
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível habilitar o módulo", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return model;
        }

        public IEnumerable<IModulosModel> GetAll()
        {
            List<ModulosModel> modelList = new List<ModulosModel>();

            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = "SELECT * FROM Modulos";
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
                                ModulosModel model = new ModulosModel();

                                model.ModuloId = int.Parse(reader["ModuloId"].ToString());
                                model.Nome = reader["Nome"].ToString();
                                model.Ativo = bool.Parse(reader["Ativo"].ToString());
                                model.DataAtivacao = DateTime.Parse(reader["DataAtivacao"].ToString());

                                modelList.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar os dados dos Módulos", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

            return modelList;
        }
    }
}
