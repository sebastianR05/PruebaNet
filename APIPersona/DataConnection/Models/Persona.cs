using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnection.Models
{
    public class Persona
    {
        [Key]
        public int id_persona { get; set; }
        public string documento_identidad { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public DateTime fecha_nacimiento { get; set; }

        [ForeignKey("id_persona")]
        public ICollection<InformacionContacto> informacion_contacto { get; set; }
    }
}
