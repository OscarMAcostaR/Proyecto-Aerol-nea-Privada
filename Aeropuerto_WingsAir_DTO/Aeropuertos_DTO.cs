using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeropuerto_WingsAir_DTO
{
    public class Aeropuertos_DTO
    {
        [Key]
        public int id_aeropuerto { get; set; }

        [StringLength(255)]
        public string nombre_aeropuerto { get; set; }
        [StringLength(100)]
        public string municipio { get; set; }
        [StringLength(100)]
        public string estado { get; set; }
        [StringLength(100)]
        public string pais { get; set; }

    }
}
