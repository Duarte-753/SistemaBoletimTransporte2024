using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaBoletimTransporteDigital.Models;

namespace SistemaBoletimTransporteDigital.ViewComponents
{
    public class Menu : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");
            

            if (string.IsNullOrEmpty(sessaoUsuario)) return null; //se a sessao for nula ou vazia entao vou retornar nulo aqui não irei para view
            

            UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
           

            return View(usuario);
        }

    }
}
