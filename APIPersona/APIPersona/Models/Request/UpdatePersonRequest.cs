using DataTransferObject.Persona;
using System;
using System.Collections.Generic;

namespace APIPersona.Models.Request
{
    public class UpdatePersonRequest
    {
        public int id_persona { get; set; }
        public string documento_identidad { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public List<InformacionContactoDTO> info_contacto { get; set; }
    }
}
