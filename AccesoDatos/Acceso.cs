using Entidades;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace AccesoDatos
{
    public class Acceso
    {

        #region Atributos

        //Se asigna la cadena de conexion con MongoDb 
        private readonly string strConexion = @"mongodb://localhost:27017";
        //Objetos que se utilizaran para realizar la conexion al mongo y a la base de datos
        private MongoClient InstanciaMongoDB;
        private IMongoDatabase BaseDatos;
        //Nombre de la base de datos
        private const string NombreBD = "Ejemplo";
        #endregion

        #region Constructor

        public Acceso()
        {
            try
            {
                ObtenerConexion();
            }
            catch (MongoException exM)
            {

                throw exM;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (InstanciaMongoDB != null)
                    InstanciaMongoDB = null;
                if (BaseDatos != null)
                    BaseDatos = null;
            }
        }

        #endregion

        #region Metodos

        #region Privados
        /// <summary>
        /// Metodo para verificar la conexion de base de datos en mongodb
        /// </summary>
        /// <returns></returns>
        private bool ObtenerConexion()
        {
            bool ConexionStatus = false;
            try
            {
                //Inicializar los atributos para conexion
                InstanciaMongoDB = new MongoClient(strConexion);

                //Obtener la informacion de la base de datos
                BaseDatos = InstanciaMongoDB.GetDatabase(NombreBD);

                //Verifica conexion positiva
                ConexionStatus = BaseDatos.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);
            }
            catch (MongoException exM)
            {

                throw exM;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ConexionStatus;
        }

        #endregion

        #region Publicos

        /// <summary>
        /// Metodo para agregar usuarios
        /// </summary>
        /// <param name="U_usuario">Entidad de tipo usuarios</param>
        /// <returns>TRUE = CORRECTO || FALSE = ERROR</returns>
        public bool AgregarUsuario(Usuarios U_usuario)
        {
            try
            {
                ObtenerConexion();
                var V_Collection = BaseDatos.GetCollection<Usuarios>("Usuarios");
                V_Collection.InsertOne(U_usuario);
            }
            catch (MongoException exM)
            {
                throw exM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (InstanciaMongoDB != null)
                    InstanciaMongoDB = null;
                if (BaseDatos != null)
                    BaseDatos = null;
            }

            return true;
        }

        /// <summary>
        /// Metodo para modificar usuario
        /// </summary>
        /// <param name="U_usuario">Entidad de tipo usuario</param>
        /// <returns>TRUE = CORRECTO || FALSE = ERROR</returns>
        public bool ModificarUsuario(Usuarios U_usuario)
        {

            try
            {
                ObtenerConexion();
                var V_Collection = BaseDatos.GetCollection<Usuarios>("Usuarios");
                V_Collection.ReplaceOne(u => u.ID.Equals(U_usuario.ID), U_usuario);
            }
            catch (MongoException exM)
            {
                throw exM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (InstanciaMongoDB != null)
                    InstanciaMongoDB = null;
                if (BaseDatos != null)
                    BaseDatos = null;
            }

            return true;
        }

        /// <summary>
        /// Metodo para eliminar usuarios
        /// </summary>
        /// <param name="U_usuario">Entidad de tipo usuario</param>
        /// <returns>TRUE = CORRECTO || FALSE = ERROR</returns>
        public bool EliminarUsuario(Usuarios U_usuario)
        {
            try
            {
                ObtenerConexion();
                var V_Collection = BaseDatos.GetCollection<Usuarios>("Usuarios");
                V_Collection.DeleteOne(u => u.ID.Equals(U_usuario.ID));
            }
            catch (MongoException exM)
            {
                throw exM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (InstanciaMongoDB != null)
                    InstanciaMongoDB = null;
                if (BaseDatos != null)
                    BaseDatos = null;
            }

            return true;
        }

        /// <summary>
        /// Metodo para listar usuarios
        /// </summary>
        /// <returns></returns>
        public List<Usuarios> ConsultarUsuarios()
        {

            List<Usuarios> V_Usuarios = new List<Usuarios>();
            try
            {
                ObtenerConexion();
                var V_Collection = BaseDatos.GetCollection<Usuarios>("Usuarios");
                V_Usuarios = V_Collection.Find(u => true).ToList();
            }
            catch (MongoException exM)
            {
                throw exM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (InstanciaMongoDB != null)
                    InstanciaMongoDB = null;
                if (BaseDatos != null)
                    BaseDatos = null;
            }
            return V_Usuarios;
        }

        #endregion

        #endregion
    }
}
