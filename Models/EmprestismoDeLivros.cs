using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibliotecaApi.Models
{
    public class EmprestismoDeLivros
    {
        [Key]
        [JsonIgnore]
        public int IdTransacao { get; set; }
        public int IdLivro { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public DateTime? DataDevolucaoRealizada  { get; set; }
    }
}