using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ModeloAspCoreMVC.Areas.Usuario.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModeloAspCoreMVC.Compartilhado
{
    public class Autorizacao
    {
        public static void Autorizar(IHttpContextAccessor contexto,UsuarioDTO usuario)
        {
            contexto.HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usuario));  
        }
        public static bool EhAutorizado(IHttpContextAccessor contexto)
        {
            if(getUsuario(contexto) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ehAdmin(IHttpContextAccessor contexto)
        {
            if(getUsuario(contexto).TipoUsuario == UsuarioDTO.Tipo.Admin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static UsuarioDTO getUsuario(IHttpContextAccessor contexto)
        {
            if (contexto.HttpContext.Session.GetString("usuario") == null) {
                return null;
            }
            else {
                UsuarioDTO usuario = JsonConvert.DeserializeObject<UsuarioDTO>(contexto.HttpContext.Session.GetString("usuario"));
                return usuario;
            }
        }
    }
}
