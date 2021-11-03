using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Entidades
{
    public class Usuarios
    {

        #region Propiedades
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        [BsonElement("NomUsuario")]
        public string NomUsuario { get; set; }
        [BsonElement("Password")]
        public string Password { get; set; }
        [BsonElement("Estado")]
        public bool Estado { get; set; }
        [BsonElement("FechaCreacion")]
        public DateTime FechaCreacion { get; set; }
        #endregion

        #region Constructor
        public Usuarios()
        {
            ID = string.Empty;
            NomUsuario = string.Empty;
            Password = string.Empty;
            Estado = false;
            FechaCreacion = DateTime.MinValue;
        }
        #endregion
    }
}
