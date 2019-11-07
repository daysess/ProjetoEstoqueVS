using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstoque.Dominio
{
    public class Produto
    {

        public int IdProduto { get; set; }
        [Required(ErrorMessage = "Nome do Produto é obrigatório.")]
        public string NmProduto { get; set; }
        public string DsProduto { get; set; }

    }
}
