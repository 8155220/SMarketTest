using Microsoft.EntityFrameworkCore;
using SMarketAPI.Controllers;
using SMarketAPI.Models;
using SMarketTestUnit.Models;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SMarketTestUnit
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var options = new DbContextOptionsBuilder<SMarketContext>()
                .UseInMemoryDatabase(databaseName: "TestDBMarket")
                .Options;

            using (var context = new SMarketContext(options))
            {
                UnitType unitType = new UnitType();
                unitType.Symbol = "KG";
                unitType.Description = "KiloGramo";

                var service = new UnitTypesController(context);
                IActionResult post = await service.PostUnitType(unitType);
            }

            using (var context = new SMarketContext(options))
            {
                List<UnitType> listUnitTypes = await context.UnitType.ToListAsync();
                int count = listUnitTypes.Count;
                Console.WriteLine("ValorCounte:"+ count);
                Assert.Equal(2, count);
                //Assert.AreEqual("http://sample.com", context.Blogs.Single().Url);
            }

            // Use a separate instance of the context to verify correct data was saved to database


        } [Fact]
        public async void Test2()
        {
            var options = new DbContextOptionsBuilder<SMarketContext>()
                .UseInMemoryDatabase(databaseName: "TestDBMarket")
                .Options;

            using (var context = new SMarketContext(options))
            {
                ProductType model = new ProductType();
                model.Name = "Gaseosas ";
                model.Description = " Bebidas con gas  ";

                var service = new ProductTypesController(context);
                IActionResult post = await service.PostProductType(model);
            }

            using (var context = new SMarketContext(options))
            {
                List<ProductType> listModel = await context.ProductType.ToListAsync();
                int count = listModel.Count;
                Console.WriteLine("ValorCounte:"+ count);
                Assert.Equal(2, count);
                //Assert.AreEqual("http://sample.com", context.Blogs.Single().Url);
            }

            // Use a separate instance of the context to verify correct data was saved to database


        }
        [Fact]
        public async void Test3()
        {
            var options = new DbContextOptionsBuilder<SMarketContext>()
                .UseInMemoryDatabase(databaseName: "TestDBMarket")
                .Options;

            using (var context = new SMarketContext(options))
            {
                Product model = new Product();
                model.Name = "SmartPhone ";
                model.Provider = " Samsung ";
                Product model2 = new Product();
                model2.Name = "Tv ";
                model2.Provider = " Samsung ";
                var service = new ProductsController(context);
                IActionResult post = await service.PostProduct(model);
                IActionResult post2 = await service.PostProduct(model2);
            }

            using (var context = new SMarketContext(options))
            {
                List<Product> listModel = await context.Products.ToListAsync();
                int count = listModel.Count;
                Console.WriteLine("ValorCounter:"+ count);
                Assert.Equal(2, count);
                //Assert.AreEqual("http://sample.com", context.Blogs.Single().Url);
            }

            // Use a separate instance of the context to verify correct data was saved to database


        }
    }
}
