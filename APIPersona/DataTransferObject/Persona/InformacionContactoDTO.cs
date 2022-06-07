using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.Persona
{
    public class InformacionContactoDTO
    {
        public int id_info_contacto { get; set; }
        public int id_persona { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public string direccion_residencia { get; set; }
    }
}
