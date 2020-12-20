using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Atv02.Models;

namespace Atv02.Controllers
{
    public class ContatoController : Controller
    {
        // ------   Listar contato ------
        public IActionResult Listar()
        {
            if (HttpContext.Session.GetInt32("idUsuario") == null)
                return RedirectToAction("login", "Usuario");

            ContatoRepository ur = new ContatoRepository();
            List<Contato> contato = ur.Contato();
            return View(contato);
        }

        // ------   Detalhes do contato ------
        public IActionResult Detalhes(int id)
        {
            if (HttpContext.Session.GetInt32("idUsuario") == null)
                return RedirectToAction("login", "Usuario");

            ContatoRepository ur = new ContatoRepository();
            Contato user = ur.RetornoContato(id);

            return View(user);
        }

        // ------   Excluir contato ------
        public IActionResult Excluir(int id, Contato contato)
        {
            if (HttpContext.Session.GetInt32("idUsuario") == null)
                return RedirectToAction("Login");

            ContatoRepository ur = new ContatoRepository();
            Contato user = ur.RetornoContato(id);

            return View(user);
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            ContatoRepository ur = new ContatoRepository();
            ur.Excluir(id);

            return RedirectToAction("Listar");
       }        
    }
}