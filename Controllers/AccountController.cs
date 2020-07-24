using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopperApi.Data;
using ShopperApi.Models;
using ShopperApi.Services;

namespace ShopperApi.Controllers
{
    [ApiVersion ("1.0")]
    [Route("api/v{version:apiVersion}/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccount accountRepository;

        public AccountController(IAccount _accountRepository)
        {
            accountRepository = _accountRepository;
        }

        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<Account> Get(string sort, string filter, int? page)
        {
            int pageNumber = page ?? 1;

            return accountRepository.GetAccounts(sort, filter, pageNumber);
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var account = accountRepository.GetAccount(id);

            if (account == null)
            {
                return NotFound("No Found!");
            }

            return Ok(account);
        }

        // POST api/<AccountController>
        [HttpPost]
        public IActionResult Post([FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            accountRepository.AddAccount(account);

            return StatusCode(StatusCodes.Status201Created);


        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != account.id)
            {
                return BadRequest();
            }

            try
            {
                accountRepository.UpdAccount(account);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound("No record found!");
            }

            return StatusCode(StatusCodes.Status200OK);

        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            accountRepository.DelAccount(id);
            
            return Ok("Deleted!");
        }
    }
}
