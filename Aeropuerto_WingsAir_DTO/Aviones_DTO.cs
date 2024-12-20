using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeropuerto_WingsAir_DTO
{
    public class Aviones_DTO
    {
        [Key]
        public int id_avion { get; set; }

        [Required]
        [StringLength(10)]

        public string codigo_avion { get; set; }

        [StringLength(100)]

        public string tipo_avion { get; set; }

        public int? horas_de_vuelo { get; set; }

        public int? capacidad_pasajeros { get; set; }

    }
}