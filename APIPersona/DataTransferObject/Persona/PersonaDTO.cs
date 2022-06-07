using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.Persona
{
    public class PersonaDTO
    {
        public int id_persona { get; set; }
        public string documento_identidad { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public List<InformacionContactoDTO> informacionContactoDTO { get; set; }
    }
}
