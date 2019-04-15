using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsuarioFBProjeto.Models;

namespace UsuarioFBProjeto.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepositorio _repositorio;

        public UsuarioController()
            :this(new UsuarioRepositorio())
        {

        }

        public UsuarioController(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ActionResult Details(int id)
        {
            UsuarioModel model = _repositorio.GetUsuarioPorID(id);
            return View(model);
        }

        public ActionResult Create()
        {
            return View(new UsuarioModel());
        }

        [HttpPost]
        public ActionResult Create(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio.InserirUsuario(usuario);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.ToString(), "Problemas ao salvar os dados...");
            }
            return View(usuario);
        }

        public ActionResult Edit(int id)
        {
            UsuarioModel model = _repositorio.GetUsuarioPorID(id);
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Edit(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio.AtualizarUsuario(usuario);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.ToString(), "Problemas ao salvar os dados...");
            }
            return View(usuario);
        }

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Problema ao deletar dados";
            }
            UsuarioModel usuario = _repositorio.GetUsuarioPorID(id);
            return View(usuario);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {                
                _repositorio.DeletarUsuario(id);
            }
            catch
            {
                return RedirectToAction("Delete", new System.Web.Routing.RouteValueDictionary { { "id", id }, { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var usuario = _repositorio.GetUsuario();
            return View(usuario);
        }
     }
}