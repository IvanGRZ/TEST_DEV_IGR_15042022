﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Rest.Models
{
    public class Tb_PersonasFisicas
    {
        [Key] public int IdPersonaFisica { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? RFC { get; set; }

        public DateTime? FechaNacimiento { get; set; }
        public int? UsuarioAgrega { get; set; }
        public bool? Activo { get; set; }
    }
}