using KWICSystem.Models;
using KWICSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace KWICSystem.Controllers
{
    public class HomeController : Controller
    {
        Stopwatch stopWatch = new Stopwatch();
        private IPipeline<IContext> _pipelineManager;
        private IContextStorage _contextStorage;
        private IFilterFactory _filterFactory;
        
        public HomeController(IPipeline<IContext> pipelineManager, 
                                IContextStorage contextStorage,
                                IFilterFactory filterFactory)
        {
            this._pipelineManager = pipelineManager;
            this._contextStorage = contextStorage;
            this._filterFactory = filterFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Filter()
        {
            return View(new DataSourceViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Filter(DataSource dataSource)
        {
            DataSourceViewModel model = new DataSourceViewModel();
            Context context = new Context();

            if (dataSource == null || string.IsNullOrEmpty(dataSource.Body))
            {
                return RedirectToAction("Filter");
            } 


            // Convert textarea data into list of strings
            context.SetBody(new List<string>(
                dataSource.Body.Split(
                    new string[] { "\r\n" },
                    StringSplitOptions.RemoveEmptyEntries
                )
            ));

            this._contextStorage.SetContext(context);

            this._pipelineManager.Register(this._filterFactory.GetFilter("CircularShiftFilter"))
                                 .Register(this._filterFactory.GetFilter("AlphabetizerFilter"))
                                 .Register(this._filterFactory.GetFilter("NoiseWordFilter"));
               
  

            stopWatch.Start();
            model.ContextBody = this._pipelineManager.PerformOperation(this._contextStorage.GetContext())
                                    .GetBody();
            stopWatch.Stop();
            model.Time = stopWatch.Elapsed.TotalMilliseconds;


            model.Body = string.Join("\n", model.ContextBody.ToArray());
            return View("Filter", model);
        }
    }
}
