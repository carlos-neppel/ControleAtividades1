using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleAtividades.Models
{
    public class Atividade
    {
        public enum Status
        {
            [Display(Name="A Fazer")]
            AFazer,
            Fazendo,
            Feito
        }

        public int AtividadeID { get; set; }

        [Required, Display(Name="Título")]
        public String Titulo { get; set; }

        [Display(Name="Descrição")]
        public String Descricao { get; set; }
        
        [Required]
        public int Prioridade { get; set; }

        [Required, Display(Name="Status")]
        public Status StatusAtividade { get; set; }

    }
}