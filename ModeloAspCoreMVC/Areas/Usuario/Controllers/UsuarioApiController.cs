using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModeloAspCoreMVC.Areas.Usuario.Models.DTO;
using ModeloAspCoreMVC.Areas.Usuario.Models.Insert;
using ModeloAspCoreMVC.Compartilhado;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModeloAspCoreMVC.Areas.Usuario.Controllers
{
    [ApiController]
    public class UsuarioApiController:Controller
    {
        IHttpContextAccessor contexto;

        public UsuarioApiController(IHttpContextAccessor contexto)
        {
            this.contexto = contexto;
        }
        [HttpPost("/login")]
        public string login([FromBody] UsuarioInsert usuario)
        {
            UsuarioDTO user = new UsuarioDTO();
            user.Nome = usuario.Login;
            user.TipoUsuario = UsuarioDTO.Tipo.Usuario;

            Autorizacao.Autorizar(contexto, user);

            Dictionary<string,List<string>> users = BancoUtil.executarQuery("select * from usuario");
            
            return "Usuario/Perfil";
        }
        
    }
}
