using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeropuerto_WingsAir_DTO
{
    public class VuelosPorEstatus_DTO
    {
        [Required]
        [StringLength(15)]

        public string codigo_vuelo { get; set; }

        [StringLength(100)]

        public string tipo_avion { get; set; }

        [StringLength(255)]

        public string piloto { get; set; }

        [StringLength(255)]

        public string origen { get; set; }

        [StringLength(255)]

        public string destino { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? fecha_hora { get; set; }

        [StringLength(20)]

        public string estatus { get; set; }
    }
}
