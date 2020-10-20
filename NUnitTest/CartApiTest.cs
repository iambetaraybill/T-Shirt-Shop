using Cart_MS.Controllers;
using Cart_MS.DB;
using Cart_MS.DB.Entities;
using Cart_MS.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NUnitTest
{
   
    public class CartApiTest
    {
        List<Cart> cart;
     

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void GetCart_WhenCalled_GetById()
        {
            cart = new List<Cart>()
            {
                      new Cart{Id = 1, Product = 1, User =1, Name = "RedShirt" }

            };
            var mock = new Mock<ICartRepository>();
            mock.Setup(x => x.GetById(1)).Returns(cart[0]);
            var controller = new CartController(mock.Object);
            var actual = controller.Get(1);
            Assert.AreEqual(cart[0].Id, actual.Id);
            Assert.AreEqual(cart[0], actual);

        }
        [Test]
        public void GetCarts_WhenCalled_GetAll()
        {
            cart = new List<Cart>()
            {
                      new Cart{Id = 1, Product = 1, User =1, Name = "RedShirt" },
                      new Cart{Id = 2, Product = 1, User =3, Name = "RedShirt" },


            };
            var mock = new Mock<ICartRepository>();
            mock.Setup(x => x.GetAll()).Returns(cart);
            var controller = new CartController(mock.Object);
            var actual = controller.Get();
            Assert.AreEqual(2, actual.ToList().Count);

        }


       
    }
}