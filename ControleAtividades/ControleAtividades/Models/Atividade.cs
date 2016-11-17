using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ControleAtividades.Models
{
    public class Atividade
    {
        public enum Status
        {
            [Display(Name="A Fazer")]
            AFazer = 0,
            [Display(Name = "Fazendo")]
            Fazendo = 1,
            [Display(Name = "Feito")]
            Feito = 2
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

        public String UsuarioID { get; set; }
        
        public List<KeyValuePair<int, string>> StatusLista { get; set; }

        public IEnumerable<SelectListItem> StatusSelect
        {
            get
            {
                var selectList = new SelectList(StatusLista, "Key", "Value");

                return selectList.OrderBy(x => x.Text);
            }
        }


        
    }
}