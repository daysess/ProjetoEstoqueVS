using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstoque.Dominio
{
    public class TipoMensagem
    {

        public string Success { get; set; }
        public string Error { get; set; }
        public string Warning { get; set; }
        public string Info { get; set; }

        public TipoMensagem()
        {
            Success = "alert-success";
            Error = "alert-danger";
            Warning = "alert-warning";
            Info = "alert-info";
        }

    }
}
