using Microsoft.AspNetCore.Mvc;
using SistemaFacturacionMVC.Areas.Identity.Data;
using SistemaFacturacionMVC.Data;
using SistemaFacturacionMVC.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacionMVC.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AuthDbContext _context;

        public UsuariosController(AuthDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationUser> list = _context.Users;
            return View(list);
        }
    }
}
