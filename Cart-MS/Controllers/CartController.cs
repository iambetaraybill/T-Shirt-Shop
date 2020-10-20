using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cart_MS.DB;
using Cart_MS.DB.Entities;
using Cart_MS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cart_MS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CartController));
        private readonly ICartRepository _cartRepository;

        //private readonly Context _context;

        ////Context Context = new Context(op);
        //public CartController(Context context)
        //{

        //    _context = context;
        //}
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }


        [HttpGet]
        public IEnumerable<Cart> Get()
        {
            _log4net.Info("Get Cart Success");
            var carts = _cartRepository.GetAll();
            //return _context.Carts.ToList();
            return carts;
        }



        [HttpGet("{id}")]
        public Cart Get(int id)
        {
            _log4net.Info("Get Cart With Id Success");
            var cart = _cartRepository.GetById(id);
            //return _context.Carts.Find(id);
            return cart;

        }


        [HttpPost]
        public IActionResult Post([FromBody] Cart model)
        {
            try
            {
                //_context.Carts.Add(model);
                //_context.SaveChanges();
                var m = _cartRepository.Post(model);
                return StatusCode(StatusCodes.Status200OK, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
