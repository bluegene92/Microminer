using KWICSystem.Models;
using KWICSystem.Services;
using KWICSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWICSystem.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SourceController : Controller
    {
        private IDatabaseManager _databaseManager;
        public SourceController(IDatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        public IActionResult Index()
        {
            return View("Index", new SearchKeywordViewModel());
        }

        // Get api/source
        [HttpGet]
        public IEnumerable<Source> Get()
        {
            return _databaseManager.GetAllSource();
        }

        // Get api/source/last
        [HttpGet]
        [Route("[action]")]
        public IActionResult Last()
        {
            return new ObjectResult(_databaseManager.GetLastSource());
        }

        // Get api/source/12
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new ObjectResult(_databaseManager.GetSource(id));
        }
    }
}
