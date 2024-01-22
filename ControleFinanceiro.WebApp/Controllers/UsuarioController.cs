using Microsoft.AspNetCore.Mvc;
using ControleFinanceiro.Service.Interfaces;
using ControleFinanceiro.Service.ServiceEntity;
using ControleFinanceiro.Service.Services;
using Microsoft.AspNetCore.Http;

namespace ControleFinanceiro.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        protected readonly IServiceUsuario service;
        public UsuarioController(IServiceUsuario service)
        {
            this.service = service;
        }
    }