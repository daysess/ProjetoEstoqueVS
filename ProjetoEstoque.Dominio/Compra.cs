using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEstoque.Dominio
{
    public class Compra
    {
        public int IdCompra { get; set; }

        [Required(ErrorMessage = "O Produto é obrigatório.")]
        public int IdProduto { get; set; }

        public string NmProduto { get; set; }
        public string DsProduto { get; set; }

        [Required(ErrorMessage = "A Embalagem é obrigatória.")]
        public int IdEmbalagemCompra { get; set; }
        public string NmEmbalagemCompra { get; set; }

        [Required(ErrorMessage = "A Embalagem é obrigatória.")]
        public int IdEmbalagemEstoque { get; set; }
        public string NmEmbalagemEstoque { get; set; }

        [Required(ErrorMessage = "A Qtd Unitária da compra é obrigatória.")]
        [Range(1, 9999, ErrorMessage = "A quantidade deve ser maior que 0!")]
        public int QtdUnidadeCompra { get; set; }

        public double VlUnidadeCompra { get; set; }
        public double VlTotalCompra { get; set; }
        public double VlBaseLucro { get; set; }
        
        [Required(ErrorMessage = "Informe a Data da compra")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtCompra { get; set; }

        [Required(ErrorMessage = "Informe a Data de cadastro")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtValidade { get; set; }

        public DateTime DtCadastro { get; set; }
        public int IdUsuario { get; set; }
               

    }
}
