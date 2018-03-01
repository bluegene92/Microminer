using KWICSystem.Models;
using KWICSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace KWICSystem.Controllers
{
    public class HomeController : Controller
    {
        private IPipeline<IContext> _pipelineManager;
        public HomeController(IPipeline<IContext> pipelineManager)
        {
            this._pipelineManager = pipelineManager;
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
            Context context = new Context();

            if (dataSource == null || string.IsNullOrEmpty(dataSource.Body))
            {
                return RedirectToAction("Filter");
            } 


            // Convert textarea data into list of string
            context.SetContext(new List<string>(
                dataSource.Body.Split(
                    new string[] { "\r\n" },
                    StringSplitOptions.RemoveEmptyEntries
                )
            ));


            //_pipelineManager.Register(new AlphabetizerFilter(new SortByFirstChar()))
            //                  .Register(new CircularShiftFilter());

            _pipelineManager.Register(new CircularShiftFilter())
                            .Register(new AlphabetizerFilter(
                                new SortByAlphabet(
                                    new AlphabetComparer(
                                        new AlphabetDictionary())
                                    )
                                )
                            );

            model.ContextBody = _pipelineManager.PerformOperation(context)
                                                .GetBody();

            model.Body = string.Join("\n", model.ContextBody.ToArray());
            return View("Filter", model);
        }
    }
}
