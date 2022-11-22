using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Herupu.DAL.Context;
using Herupu.DAO.Entidades;

namespace Herupu.Adminitrativo.Web.Controllers
{
    public class HistoricoAlunoController : Controller
    {
        private readonly DataBaseContext _context;

        public HistoricoAlunoController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: HistoricoAluno
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
