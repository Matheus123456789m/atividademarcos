using Aula2407.Data;
using Aula2407.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aula2407.Controllers
{
    public class ClienteController : Controller
    {
        private readonly AulaContexts _context;

        public ClienteController(AulaContexts context)
        {
            _context = context;
        }

        //buscar clientes
        public async Task<IActionResult> BuscarClientes()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        public async Task<IActionResult> DetalhesCliente(int id)
        {
            return View(await _context.Clientes.FindAsync(id));
        }

        //alterar cliente
        public async Task<IActionResult> AlterarCliente(int id)
        {
            return View(await _context.Clientes.FindAsync(id));
        }



        //cadastro de  cliente
        public async Task<IActionResult> CadastroCliente(int? id)
        {
            if (id == null) 
            {
                return View();
            }
            else
            {
                return View(await _context.Clientes.FindAsync(id));
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastroCliente(
            [Bind("Id,NomeCompleto,CPF,Email,TelefoneCelular,Endereço")]
            Cliente cliente)
        {
           if (!ModelState.IsValid) 
            {
                if (cliente.Id !=0)
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                else 
                {
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("BuscarClientes");
            }
            return View(cliente);
        }
    }
}
