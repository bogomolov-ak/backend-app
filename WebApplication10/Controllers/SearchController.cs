using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlumsailTestCaseBackend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlumsailTestCaseBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ApplicationContext repository;

        public SearchController(ApplicationContext repository)
        {
            this.repository = repository;
        }
        // POST api/<SearchController>
        [HttpPost]
        public IEnumerable<Submition> Post(Dictionary<string, string> value)
        {

            Console.WriteLine(value["value"]);

            if (value?["value"] == null)
                return null;

            var items = repository.Submitions
                .Where(item => item.MyTextValue.Contains(value["value"]) ||
                                        item.EmailAddressValue.Contains(value["value"]) ||
                                        item.TextareaValue.Contains(value["value"]) ||
                                        item.SelectValue.Contains(value["value"]) ||
                                        item.DatepickerValue.Contains(value["value"]) ||
                                        item.RadioValue.Contains(value["value"]) ||
                                        item.CheckBoxesValue.Contains(value["value"])).ToList();

            items.ForEach(item => Console.WriteLine(item.Id));

            return items;
        }
    }
}
