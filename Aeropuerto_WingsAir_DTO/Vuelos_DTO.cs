using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeropuerto_WingsAir_DTO
{
    public class Vuelos_DTO
    {
        [Key]
        public int id_vuelo { get; set; }

        [Required]
        [StringLength(15)]

        public string codigo_vuelo { get; set; }

        public int? id_origen { get; set; }

        public int? id_destino { get; set; }

        public int? id_piloto { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime fecha_hora { get; set; }

        [StringLength(20)]

        public string estatus { get; set; }

        public int? horas_vuelo { get; set; }

        public int? id_avion { get; set; }

    }
}
