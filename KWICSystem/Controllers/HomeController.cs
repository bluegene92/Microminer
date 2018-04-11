using KWICSystem.Models;
using KWICSystem.Services;
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
        private IFilterFactory _filterFactory;
        private IDatabaseManager _databaseManager;
        private IMicrominer _microminer;
        public HomeController(IPipeline<IContext> pipelineManager, 
                                IFilterFactory filterFactory,
                                IDatabaseManager databaseManager,
                                IMicrominer microminer)
        {
            this._pipelineManager = pipelineManager;
            this._filterFactory = filterFactory;
            this._databaseManager = databaseManager;
            this._microminer = microminer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new SearchKeywordViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(SearchKeyword keywordsInput)
        {
            SearchKeywordViewModel model = new SearchKeywordViewModel();
            if (keywordsInput == null || string.IsNullOrEmpty(keywordsInput.Body))
            {
                return RedirectToAction("Index");
            }
            stopWatch.Start();
            List<string> outputResult = this._microminer.FindUrl(keywordsInput.Body);
            stopWatch.Stop();
            model.Time = stopWatch.Elapsed.TotalMilliseconds;
            model.ResultBody = string.Join("\n", outputResult.ToArray());
            return View("Index", model);
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
            IContext context = new Context();

            if (dataSource == null || string.IsNullOrEmpty(dataSource.Body))
            {
                return RedirectToAction("Filter");
            }

            // Store the original data
            _databaseManager.Add(new Source() { Body = dataSource.Body } );

            // Convert textarea data into list of strings
            context.SetBody(new List<string>(
                dataSource.Body.Split(
                    new string[] { "\r\n" },
                    StringSplitOptions.RemoveEmptyEntries
                )
            ));

            this._pipelineManager.Register(this._filterFactory.GetFilter("CircularShiftFilter"))
                                 .Register(this._filterFactory.GetFilter("AlphabetizerFilter"))
                                 .Register(this._filterFactory.GetFilter("NoiseWordFilter"));

            stopWatch.Start();
            model.ContextBody = this._pipelineManager.PerformOperation(context)
                                    .GetOutput();
            stopWatch.Stop();
            model.Time = stopWatch.Elapsed.TotalMilliseconds / 1000;

            // Store the kwic output in the database (from list to string)
            _databaseManager.AddKWIC(new KWICSource()
            {
                Body = String.Join("\r\n", model.ContextBody)
            });

            model.Body = string.Join("\n", model.ContextBody.ToArray());
            return View("Filter", model);
        }
    }
}
