using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CamposProject.Data;
using CamposProject.Entidades;

namespace CamposProject.Controllers
{
    public class VendasController : Controller
    {
        private readonly CamposDatabaseContext _context;

        public VendasController(CamposDatabaseContext context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index(string filtro = null)
        {
            var model = await _context.Vendas
                    .Include(v => v.Cliente)
                    .Include(v => v.Produto)
                    .Where(v => filtro == null || v.Produto.DscProduto.Contains(filtro) || v.Cliente.NmCliente.Contains(filtro))
                    .ToListAsync();

            return View(model);
        }
        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.IdVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "NmCliente");
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "DscProduto");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenda,IdCliente,IdProduto,QtdVenda,VlrUnitarioVenda,DthVenda,VlrTotalVenda")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                venda.VlrTotalVenda = venda.VlrUnitarioVenda * venda.QtdVenda;
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "NmCliente", venda.IdCliente);
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "DscProduto", venda.IdProduto);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "NmCliente", venda.IdCliente);
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "DscProduto", venda.IdProduto);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenda,IdCliente,IdProduto,QtdVenda,VlrUnitarioVenda,DthVenda,VlrTotalVenda")] Venda venda)
        {
            if (id != venda.IdVenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    venda.VlrTotalVenda = venda.VlrUnitarioVenda * venda.QtdVenda;
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.IdVenda))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "NmCliente", venda.IdCliente);
            ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "DscProduto", venda.IdProduto);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(m => m.IdVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Vendas.FindAsync(id);
            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Vendas.Any(e => e.IdVenda == id);
        }
    }
}
