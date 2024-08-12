using Aula2407.Data;
using Aula2407.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aula2407.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly AulaContexts _context;
        

        public ProdutoController(AulaContexts context)
        {
            _context = context;
        }

        //buscar clientes
        public async Task<IActionResult> BuscarClientes()
        {
            return View(await _context.Produtos.ToListAsync());
        }

        //cadastro de cliente
        public IActionResult ProdutoCliente()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastroProdutos(
            [Bind("Id,Nome,Codigo,valor,lote" )]
            Produto Produto)
        {
            if (ModelState.IsValid)
            {
               _context.Add(Produto);
               await _context.SaveChangesAsync();
               return RedirectToAction("Index", "NossoApp");
            }
            return View(Produto);
        }



    }
}
