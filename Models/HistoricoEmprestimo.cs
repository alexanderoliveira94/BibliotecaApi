using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibliotecaApi.Models
{
    public class HistoricoEmprestimo
    {
        [Key]
        [JsonIgnore]
        public int IdUsuario { get; set; }
        public List<HistoricoEmprestimo> ?ListaDeEmprestimo { get; set; }
    }
}