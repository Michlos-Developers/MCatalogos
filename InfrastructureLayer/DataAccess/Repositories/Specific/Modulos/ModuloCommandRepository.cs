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
    public class ModuloCommandRepository : IModuloCommandRepository
    {
        private string _connectionString;

        public ModuloCommandRepository()
        {

        }

        public ModuloCommandRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<IModuloCommandModel> GetAll()
        {
            List<ModuloCommandModel> modelList = new List<ModuloCommandModel>();

            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT CommandId, CommandName, Command, ModuloId " +
                            " FROM ModuloCommands ";
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
                                ModuloCommandModel model = new ModuloCommandModel();

                                model.CommandId = int.Parse(reader["CommandId"].ToString());
                                model.CommandName = reader["CommandName"].ToString();
                                model.Command = reader["Command"].ToString();
                                model.ModuloId = int.Parse(reader["ModuloId"].ToString());

                                modelList.Add(model);
                            }

                        }
                    }
                    
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Comandos do Módulo", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

            return modelList;
        }

        public IEnumerable<IModuloCommandModel> GetAllByModuloId(int moduloId)
        {
            List<ModuloCommandModel> modelList = new List<ModuloCommandModel>();

            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string query = " SELECT CommandId, CommandName, Command, ModuloId " +
                            " FROM ModuloCommands " +
                            " WHERE ModuloId = @ModuloId ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {

                    connection.Open();


                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            cmd.Prepare();
                            cmd.Parameters.Add(new SqlParameter("@ModuloId", moduloId));

                            while (reader.Read())
                            {
                                ModuloCommandModel model = new ModuloCommandModel();

                                model.CommandId = int.Parse(reader["CommandId"].ToString());
                                model.CommandName = reader["CommandName"].ToString();
                                model.Command = reader["Command"].ToString();
                                model.ModuloId = int.Parse(reader["ModuloId"].ToString());

                                modelList.Add(model);
                            }

                        }
                    }

                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Comandos do Módulo", e.HelpLink, e.ErrorCode, e.StackTrace);

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
