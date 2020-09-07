using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using PlumsailTestCaseBackend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlumsailTestCaseBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationContext repository;
        public UsersController(ApplicationContext repository)
        {
            this.repository = repository;

            if (!repository.Users.Any())
            {
                repository.Users.Add(new User { Name = "Alex" });
                repository.Users.Add(new User { Name = "Olga" });
                repository.Users.Add(new User { Name = "Elena" });
                repository.Users.Add(new User { Name = "Roman" });
                repository.Users.Add(new User { Name = "Oleg" });
            }
        }
        // GET: api/<UsersController>
        [HttpGet]
        public async IAsyncEnumerable<string> Get()
        {
            await foreach (var user in repository.Users)
                yield return user.Name;
        }
    }
}
