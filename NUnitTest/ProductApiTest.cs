using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Product_MS.Controllers;
using Product_MS.DB;
using Product_MS.DB.Entities;
using Product_MS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace NUnitTest
{
    class ProductApiTest
    {
        List<Product> pro;
        [SetUp]
        public void Setup()
        {

        }
        
        [Test]
        public void GetProduct_WhenCalled_GetById()
        {
            pro = new List<Product>()
            {
                      new Product{ProductId = 1,Name = "RedShirt", Color = "Red", Description = "Red Tshirt" }

            };
            var mock = new Mock<IProductRepository>();
            mock.Setup(x => x.GetById(1)).Returns(pro[0]);
            var controller = new ProductController(mock.Object);
            var actual = controller.Get(1);
            Assert.AreEqual(pro[0].ProductId, actual.ProductId);
            Assert.AreEqual(pro[0], actual);

        }


        [Test]
        public void GetProducts_WhenCalled_GetAll()
        {
            pro = new List<Product>()
            {
                      new Product{ProductId = 1,Name = "RedShirt", Color = "Red", Description = "Red Tshirt" },
                      new Product{ProductId = 2,Name = "BlueShirt", Color = "Blue", Description = "Blue Tshirt" },
                      new Product{ProductId = 3,Name = "GreenShirt", Color = "Green", Description = "Green Tshirt" },

            };
            var mock = new Mock<IProductRepository>();
            mock.Setup(x => x.GetAll()).Returns(pro);
            var controller = new ProductController(mock.Object);
            var actual = controller.Get();
            Assert.AreEqual(pro.Count, actual.ToList().Count);

        }


    }
}
