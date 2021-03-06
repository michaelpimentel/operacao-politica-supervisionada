﻿using OPS.Core;
using System.Web.Mvc;

namespace OPS.Controllers
{
    /// <summary>
    /// Create an ActionResult and PartialView for each angular partial view you want to attatch to a route in the angular app.js file.
    /// </summary>
    public class AppController : Controller
    {
        public ActionResult Load(string folder, string page)
        {
            string partialUrl;
            if (string.IsNullOrEmpty(page))
            {
                partialUrl = "_" + folder;
            }
            else
            {
                partialUrl = folder + "/_" + page;
            }

            string file = Server.MapPath("~/Views/App/" + partialUrl + ".html");
            if (System.IO.File.Exists(file))
            {
                return File(file, "text/html");
            }

            return File(Server.MapPath("~/Views/App/Erro/_404.html"), "text/html");

            //         ViewEngineResult result = ViewEngines.Engines.FindView(ControllerContext, partialUrl, null);
            //if (result.View != null)
            //{
            //	switch (partialUrl.ToLower())
            //	{
            //		case "auditoria/deputado-federal-lista":
            //			ViewBag.dtUltimaAtualizacao = Padrao.DeputadoFederalUltimaAtualizacao.ToString("dd/MM/yyyy HH:mm");
            //			break;
            //		case "auditoria/senador-lista":
            //			ViewBag.dtUltimaAtualizacao = Padrao.SenadorUltimaAtualizacao.ToString("dd/MM/yyyy HH:mm");
            //			break;
            //	}
            //	return PartialView(partialUrl);
            //}
            //else
            //{
            //	return PartialView("Erro/_404");
            //}
        }
    }
}