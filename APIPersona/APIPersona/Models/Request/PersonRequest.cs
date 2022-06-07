using DataTransferObject.Persona;
using System;
using System.Collections.Generic;

namespace APIPersona.Models.Request
{
    public class PersonRequest
    {
        public string documento_identidad { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public List<InformacionContactoDTO> info_contacto { get; set; }
    }
}
