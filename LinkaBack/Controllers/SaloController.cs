using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkaBack.DAL;
using LinkaBack.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkaBack.Controllers
{
    [Produces("application/json")]
    [Route("api/salo")]
    //[ApiController]
    public class SaloController : ControllerBase
    {
        private readonly EFDbContext _context;


        public SaloController(EFDbContext context)
        {
            _context = context;
        }
      
        [HttpGet("Products")]
        public IActionResult SS()
        {
            try
            {
                var model = new List<ProductViewModel>();
                var products = _context.Products.Select(x => x);
                foreach (var item in products)
                {
                    model.Add(new ProductViewModel
                    {
                        Id = item.Id,
                        Text = item.Text,
                        Title = item.Title,
                        Image = item.Image
                    });
                }

                return Ok(model);
            }
            catch
            {
                return BadRequest("Error");

            }
        }

        [HttpGet("product/{id}")]
        public IActionResult GetProduc(int id)
        {
            ProductViewModel model = _context.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Image = x.Image,
                Text = x.Text,
                Title = x.Title
            }).SingleOrDefault(x => x.Id == id);

            return Ok(model);
        }

        [HttpPost("AddProduct")]
        public IActionResult AddUser([FromBody] ProductViewModel addModel)
        {
            _context.Products.Add(new DAL.Entities.Product
            {
                Title = addModel.Title,
                Text = addModel.Text,
                Image = addModel.Image
            });
            _context.SaveChanges();
            return Ok();
        }


    }
}