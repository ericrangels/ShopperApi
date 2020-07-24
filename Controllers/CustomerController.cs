using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopperApi.Models;
using ShopperApi.Services;

namespace ShopperApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomer customerRepository;

        public CustomerController(ICustomer _customerRepository)
        {
            customerRepository = _customerRepository;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get(string sort, string filter, int? page)
        {
            int pageNumber = page ?? 1;

            return customerRepository.GetCustomers(sort, filter, pageNumber);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = customerRepository.GetCustomer(id);

            if (customer == null)
            {
                return NotFound("No Found!");
            }

            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            customerRepository.AddCustomer(customer);

            return StatusCode(StatusCodes.Status201Created);


        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.id)
            {
                return BadRequest();
            }

            try
            {
                customerRepository.UpdCustomer(customer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound("No record found!");
            }

            return StatusCode(StatusCodes.Status200OK);

        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            customerRepository.DelCustomer(id);

            return Ok("Deleted!");
        }
    }

}
