﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WingsAir_API.Models;

public partial class Aeropuertos
{
    [Key]
    public int id_aeropuerto { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string nombre_aeropuerto { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string municipio { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string estado { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string pais { get; set; }

    [InverseProperty("id_destinoNavigation")]
    public virtual ICollection<Vuelos> Vuelosid_destinoNavigation { get; set; } = new List<Vuelos>();

    [InverseProperty("id_origenNavigation")]
    public virtual ICollection<Vuelos> Vuelosid_origenNavigation { get; set; } = new List<Vuelos>();
}