using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEstoque.Dominio
{
    public class Embalagem
    {
        public int IdEmbalagem { get; set; }
        [Required( ErrorMessage = "O Nome da embalagem é obrigatório. ")]
        public string NmEmbalagem { get; set; }
        [Required(ErrorMessage = "A qtd da unidade é obrigatória. ")]
        public int QtdUnidade { get; set; }

        public string DsEmbalagem { get; set; }


    }
}
