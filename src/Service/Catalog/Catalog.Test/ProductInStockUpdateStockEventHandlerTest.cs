using Catalog.Service.EventHandlers;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Test.Config;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading;
using static Catalog.Common.Enums;

namespace Catalog.Test
{
    [TestClass]
    public class ProductInStockUpdateStockEventHandlerTest
    {
        private ILogger<ProductInStockUpdateStockEventHandler> GetLogger
        {
            get
            {
                return new Mock<ILogger<ProductInStockUpdateStockEventHandler>>()
                    .Object;
            }
        }

        [TestMethod]
        public void TryToSubstractStockWhenProductHasStock()
        {
            var context = ApplicationDbContextInMemory.Get();

            var productInStockId = 1;
            var productId = 1;

            context.Stocks.Add(new Domian.ProductInStock
            {
                ProducInStockId = productInStockId,
                ProductId = productId,
                Stock = 1
            });

            context.SaveChanges();

            var handler = new ProductInStockUpdateStockEventHandler(context, GetLogger);

            handler.Handle(new ProductInStockUpdateStockCommand {
                Items = new List<ProductInStockUpdateItem>()
                {
                    new ProductInStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 1,
                        Action = ProductInStockAction.Substract
                    }
                }
            }, new CancellationToken()).Wait();

        }
    }
}
