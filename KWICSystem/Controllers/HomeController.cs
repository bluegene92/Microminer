using KWICSystem.Models;
using KWICSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace KWICSystem.Controllers
{
    public class HomeController : Controller
    {
        private IPipeline<IContext> _PipelineManager;

        public HomeController(IPipeline<IContext> pipelineManager)
        {
            this._PipelineManager = pipelineManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Filter()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Filter(DataSource dataSource)
        {
            var model = new DataSourceViewModel();
            var context = new Context();

            if (dataSource == null 
                || string.IsNullOrEmpty(dataSource.Body))
            {
                return RedirectToAction("Filter");
            } 


            context.SetContext(new List<string>(
                dataSource.Body.Split(
                    new string[] { "\r\n" },
                    StringSplitOptions.RemoveEmptyEntries
                )
            ));


            _PipelineManager.Register(new CircularShiftFilter())
                            .Register(new AlphabetizerFilter(new SortByFirstChar()));

            model.ContextBody = _PipelineManager.PerformOperation(context)
                                                .GetBody();

            model.Body = string.Join("\n", model.ContextBody.ToArray());
            return View("Filter", model);
        }
    }
}
