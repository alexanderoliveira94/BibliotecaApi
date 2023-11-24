using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibliotecaApi.Models
{
    public class Usuario
    {
        [Key]
        [JsonIgnore]
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; } = string.Empty;
        
        [JsonIgnore]
        public DateTime DataRegistro { get; set; } = DateTime.Now; 

    }
}