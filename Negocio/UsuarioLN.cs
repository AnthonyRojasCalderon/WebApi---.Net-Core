using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio
{
    public class UsuarioLN
    {
        #region Metodos
        /// <summary>
        /// Metodo que agrega un articulo
        /// </summary>
        /// <param name="U_usuario">Entidad de tipo articulo</param>
        /// <returns>Entidad de tipo resultado</returns>
        public static Resultado AgregarUsuario(Usuarios U_usuario)
        {
            Acceso objAcceso = new Acceso();
            Resultado objResultado = new Resultado
            {
                MensajeUsuario = "Usuario agregado correctamente",
                ResultadoOperacion = true
            };
            //Consulto a la base de datos los registros sobre usuarios
            List<Usuarios> lstUsuarios = objAcceso.ConsultarUsuarios();
            var v_encontrado = lstUsuarios.Where(x => x.ID.Equals(U_usuario.ID)).FirstOrDefault();

            if (v_encontrado == null)//Si no se encuentra el ID se puede ingresar el usuario como nuevo
            {
                if (!objAcceso.AgregarUsuario(U_usuario))//En caso de que la insercion de error
                {
                    objResultado = new Resultado
                    {
                        MensajeUsuario = "Error al ingresar usuario",
                        ResultadoOperacion = false
                    };
                }
            }
            else
            {
                objResultado = new Resultado
                {
                    MensajeUsuario = "Usuario existe en la base de datos",
                    ResultadoOperacion = false
                };
            }
            return objResultado;
        }

        /// <summary>
        /// Metodo que elimina un usuario
        /// </summary>
        /// <param name="U_usuario">Entidad de tipo usuario</param>
        /// <returns>Entidad de tipo resultado</returns>
        public static Resultado EliminarUsuario(Usuarios U_usuario)
        {
            Acceso objAcceso = new Acceso();
            Resultado objResultado = new Resultado
            {
                MensajeUsuario = "Usuario borrado correctamente",
                ResultadoOperacion = true
            };

            //Consulto la base de datos con los registros de usuarios
            List<Usuarios> lstUsuarios = objAcceso.ConsultarUsuarios();
            var v_encontrado = lstUsuarios.Where(x => x.ID.Equals(U_usuario.ID)).FirstOrDefault();

            if (v_encontrado != null)//Quiere decir que existe dentro de la lista, por tanto, se puede eliminar
            {
                if (!objAcceso.EliminarUsuario(U_usuario))
                {
                    objResultado = new Resultado
                    {
                        MensajeUsuario = "Error al eliminar el usuario",
                        ResultadoOperacion = false
                    };
                }
            }
            else
            {
                objResultado = new Resultado
                {
                    MensajeUsuario = "No se puede eliminar, el usuario no existe",
                    ResultadoOperacion = false
                };
            }
            return objResultado;
        }

        /// <summary>
        /// Metodo que modifica un usuario
        /// </summary>
        /// <param name="U_usuario">Entidad de tipo usuario</param>
        /// <returns>Entidad de tipo resultado</returns>
        public static Resultado ModificarUsuario(Usuarios U_usuario)
        {
            Acceso objAcceso = new Acceso();
            Resultado objResultado = new Resultado
            {
                MensajeUsuario = "Usuario modificado correctamente",
                ResultadoOperacion = true
            };

            //Consulto la base de datos con los registros de usuarios
            List<Usuarios> lstUsuarios = objAcceso.ConsultarUsuarios();
            var v_encontrado = lstUsuarios.Where(x => x.ID.Equals(U_usuario.ID)).FirstOrDefault();

            if (v_encontrado != null)//Quiere decir que existe dentro de la lista, por tanto, se puede eliminar
            {
                if (!objAcceso.ModificarUsuario(U_usuario))
                {
                    objResultado = new Resultado
                    {
                        MensajeUsuario = "Error al modificar el usuario",
                        ResultadoOperacion = false
                    };
                }
            }
            else
            {
                objResultado = new Resultado
                {
                    MensajeUsuario = "No se puede modificar, el usuario no existe",
                    ResultadoOperacion = false
                };
            }
            return objResultado;
        }

        /// <summary>
        /// Metodo para obtener o listar los usuarios registrados
        /// </summary>
        /// <returns></returns>
        public static List<Usuarios> ConsultarUsuarios()
        {
            Acceso objAcceso = new Acceso();
            return objAcceso.ConsultarUsuarios();
        }
        #endregion
    }
}
