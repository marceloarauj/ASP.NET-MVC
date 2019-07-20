using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModeloAspCoreMVC.Compartilhado
{
    public class GerenciadorSessao
    {
        public readonly IHttpContextAccessor contexto;
        private ISession sessao => contexto.HttpContext.Session;
        public GerenciadorSessao(IHttpContextAccessor contexto)
        {
            this.contexto = contexto;
        }

        public void Registro(string key, string value)
        {
            sessao.SetString(key, value);
        }
        public string obter(string key)
        {
            return sessao.GetString(key);
        }
    }
}
