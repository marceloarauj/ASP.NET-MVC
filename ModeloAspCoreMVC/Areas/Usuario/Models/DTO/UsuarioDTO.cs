using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModeloAspCoreMVC.Areas.Usuario.Models.DTO
{
    public class UsuarioDTO
    {
        public string Nome { get; set; }
        public long Id { get; set; }
        public Tipo TipoUsuario { get; set; }
        public enum Tipo
        {
            Admin,Usuario
        }
    }
}
