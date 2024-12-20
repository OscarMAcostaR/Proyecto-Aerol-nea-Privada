﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WingsAir_API.Models;

[Microsoft.EntityFrameworkCore.Index("codigo_avion", Name = "UQ__Aviones__E46E03C04704EB6A", IsUnique = true)]
public partial class Aviones
{
    [Key]
    public int id_avion { get; set; }

    [Required]
    [StringLength(10)]
    [Unicode(false)]
    public string codigo_avion { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string tipo_avion { get; set; }

    public int? horas_de_vuelo { get; set; }

    public int? capacidad_pasajeros { get; set; }

    [InverseProperty("id_avionNavigation")]
    public virtual ICollection<Vuelos> Vuelos { get; set; } = new List<Vuelos>();
}