using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEstoque.Dominio
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        [RegularExpression(@"[a-zA-Z]{5,15}", ErrorMessage = "Somente Letras e de 5 a 15 caracteres!")]
        [Required(ErrorMessage = "O nome do usuário é obrigatório")]
        public string NmUsuario { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha1 { get; set; }
        public string Senha2 { get; set; }
        public string Senha3 { get; set; }
        public DateTime DtCadastro { get; set; }
        public string ConfirmarSenha { get; set; }



    }
}
