using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudCadastroFuncionario.Context;
using CrudCadastroFuncionario.Models;
using CrudCadastroFuncionario.Interfaces;

namespace CrudCadastroFuncionario.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly IEnderecoRepository _endereco;
        private readonly IFuncionarioRepository _funcionario;

        public FuncionariosController(IEnderecoRepository endereco,
                                      IFuncionarioRepository funcionario)
        {
            _endereco = endereco;
            _funcionario = funcionario;
        }

        public async Task<IActionResult> Index()
        {
              return View(await _funcionario.ObterTodos());
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var funcionario = _funcionario.ObterFuncionarioEndereco(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                funcionario.Id = Guid.NewGuid();
                await _funcionario.Adicionar(funcionario);
                await _funcionario.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var funcionario = _funcionario.ObterFuncionarioEndereco(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        [HttpPost]
        public  IActionResult Edit(Guid id, Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                if (_funcionario.Buscar(x => x.Cpf == funcionario.Cpf && x.Id != funcionario.Id).Result.Any())
                {
                    return BadRequest("Já existe um funcionario com este documento infomado.");
                }
                try
                {
                     _funcionario.Atualizar(funcionario);
                     _endereco.Atualizar(funcionario.Endereco);
                     _funcionario.SaveChanges();
                    _endereco.SaveChanges();
                }
                catch (Exception Ex)
                {
                    if (!VerificaFuncionario(funcionario.Id))
                    {
                        return NotFound(Ex.Message);
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }

        public IActionResult Delete(Guid id)
        {
            var funcionario = _funcionario.ObterFuncionarioEndereco(id);
            var endereco = _endereco.ObterPorId(funcionario.Endereco.Id);
            if (funcionario != null)
            {
                _funcionario.Remover(id);
                _endereco.Remover(funcionario.Endereco.Id);
            }
           
            
            _funcionario.SaveChanges();
            _endereco.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool VerificaFuncionario(Guid id)
        {
          var funcionario = _funcionario.Buscar(x => x.Id == id);
          if(funcionario != null)
            {
                return true;
            }
            return false;
        }
    }
}
