using KWICSystem.Models;
using KWICSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace KWICSystem.Controllers
{
    public class HomeController : Controller
    {
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
            } else
            {
                context.SetOfText = new List<string>(
                    dataSource.Body.Split(
                        new string[] { "\r\n" },
                        StringSplitOptions.RemoveEmptyEntries
                    )
                );

                PipelineBuilder pipelineBuilder = new PipelineBuilder();

                pipelineBuilder.Register(new CircularShiftFilter())
                    .Register(new AlphabetizerFilter());

                // Reverse Filters
                //pump.Register(new AlphabetizerFilter())
                //    .Register(new CircularShiftFilter());

                IContext result = pipelineBuilder.PerformOperation(context);

                model.SetOfText = result.GetContext();
                model.Body = string.Join("\n", model.SetOfText.ToArray());
            }
            return View("Filter", model);
        }
    }
}
