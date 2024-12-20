
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeropuerto_WingsAir_DTO
{
    public class Pilotos_DTO
    {
        [Key]
        public int id_piloto { get; set; }

        [Required]
        [StringLength(10)]

        public string codigo_piloto { get; set; }

        [StringLength(255)]

        public string nombre_completo { get; set; }

        [StringLength(1)]

        public string sexo { get; set; }

        public int? horas_de_vuelo { get; set; }

    }
}
