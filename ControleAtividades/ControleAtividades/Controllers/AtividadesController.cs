using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControleAtividades.Models;

namespace ControleAtividades.Controllers
{
    [Authorize]
    public class AtividadesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Atividades/
        public ActionResult Index()
        {
            return View(db.Atividades.ToList());
        }

        // GET: /Atividades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atividade atividade = db.Atividades.Find(id);
            if (atividade == null)
            {
                return HttpNotFound();
            }
            return View(atividade);
        }

        // GET: /Atividades/Create
        public ActionResult Create()
        {
            var lista = Enum.GetValues(typeof(ControleAtividades.Models.Atividade.Status)).Cast<ControleAtividades.Models.Atividade.Status>().ToList();
            Dictionary<int, string> list = new Dictionary<int, string>();
            foreach (var item in Enum.GetNames(typeof(ControleAtividades.Models.Atividade.Status)))
            {
                int key = ((int)Enum.Parse(typeof(ControleAtividades.Models.Atividade.Status), item));

                    list.Add(key, Extensoes.EnumExtensoes.GetDisplayName((ControleAtividades.Models.Atividade.Status)key, typeof(ControleAtividades.Models.Atividade.Status)));
            }

            var atividade = new Atividade
            {
                StatusLista = list.ToList()
            };

            return View(atividade);            
        }

        // POST: /Atividades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AtividadeID,Titulo,Descricao,Prioridade,StatusAtividade")] Atividade atividade)
        {
            if (ModelState.IsValid)
            {
                db.Atividades.Add(atividade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(atividade);
        }

        // GET: /Atividades/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atividade atividade = db.Atividades.Find(id);

            var lista = Enum.GetValues(typeof(ControleAtividades.Models.Atividade.Status)).Cast<ControleAtividades.Models.Atividade.Status>().ToList();
            Dictionary<int, string> list = new Dictionary<int, string>();
            foreach (var item in Enum.GetNames(typeof(ControleAtividades.Models.Atividade.Status)))
            {
                int key = ((int)Enum.Parse(typeof(ControleAtividades.Models.Atividade.Status), item));

                list.Add(key, Extensoes.EnumExtensoes.GetDisplayName((ControleAtividades.Models.Atividade.Status)key, typeof(ControleAtividades.Models.Atividade.Status)));
            }

            atividade.StatusLista = list.ToList();
            if (atividade == null)
            {
                return HttpNotFound();
            }
            return View(atividade);
        }

        // POST: /Atividades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AtividadeID,Titulo,Descricao,Prioridade,StatusAtividade")] Atividade atividade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atividade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atividade);
        }

        // GET: /Atividades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atividade atividade = db.Atividades.Find(id);
            if (atividade == null)
            {
                return HttpNotFound();
            }
            return View(atividade);
        }

        // POST: /Atividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atividade atividade = db.Atividades.Find(id);
            db.Atividades.Remove(atividade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
