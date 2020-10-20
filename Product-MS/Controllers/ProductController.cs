using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using log4net.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_MS.DB;
using Product_MS.DB.Entities;
using Product_MS.Repository;

namespace Product_MS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly DatabaseContext db;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProductController));
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            _log4net.Info("Getting List OF Products!");
            var pros = _productRepository.GetAll(); 
            return pros;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            _log4net.Info("Getting List OF Products By Id!");
            var pros = _productRepository.GetById(id);
            return pros;
            
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product model)
        {
            try
            {
                //db.Products.Add(model);
                //db.SaveChanges();
                _productRepository.PostModel(model);
            _log4net.Info("Product Added To DB!");
                return StatusCode(StatusCodes.Status201Created,model);
            }
            catch(Exception ex) 
            {
            _log4net.Info("Product Not Added To DB!");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] Product model)
        //{
        //    try
        //    {
        //        var entity = db.Products.FirstOrDefault(e => e.ProductId == id);
        //        entity.Name = model.Name;
        //        entity.Color = model.Color;
        //        entity.Description = model.Description;
        //        db.SaveChanges();
        //    _log4net.Info("Product With Id Successfully Edited!");
        //        return Ok("Product Updated");

        //    }
        //    catch (Exception ex)
        //    {
        //    _log4net.Info("Product With Id Editting Failed!");
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex);
        //    }

        //}

        //// DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    try
        //    {
        //        var v = db.Products.Find(id);
        //    if (v == null)
        //    {
        //        return BadRequest("No Record found against this Product Id");
        //    }
        //    db.Remove(v);
        //    db.SaveChanges();
        //    _log4net.Info("Product With Id Deleted!");
        //    return Ok("Product Deleted");
        //    }
        //    catch (Exception ex)
        //    {
        //    _log4net.Info("Product With Id Deletion Failed!");
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex);
        //    }
        //}
    }
}
