using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PlumsailTestCaseBackend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlumsailTestCaseBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmitionsController : ControllerBase
    {
        private readonly ApplicationContext repository;

        public SubmitionsController(ApplicationContext repository)
        {
            this.repository = repository;
        }

        // POST api/<SubmitionsController>
        [HttpPost]
        public void Post(Dictionary<string, string> value)
        {
            foreach (var keyValuePair in value)
            {
                Console.WriteLine($"{keyValuePair.Key} : {keyValuePair.Value}");
            }

            repository.Submitions.Add(new Submition
            {
                MyTextValue = value["myTextValue"],
                EmailAddressValue = value["emailAddressValue"],
                TextareaValue = value["textareaValue"],
                SelectValue = value["selectValue"],
                DatepickerValue = value["datepickerValue"],
                RadioValue = value["radioValue"],
                CheckBoxesValue = value["checkBoxesValue"],
            });
            repository.SaveChanges();
        }
    }
}
