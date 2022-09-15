using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinanceweb_dotnet.Models
{
    public class TransacaoModel
    {
        public int? Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string Historico { get; set; }
        public string Tipo { get; set; }
        [Display(Name = "Plano de Contas")]
        public int IdPlanoConta { get; set; }
        public IEnumerable<SelectListItem> PlanoContas { get; set; }
    }
}
