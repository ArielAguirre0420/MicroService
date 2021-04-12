using Catalog.Domian;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Catalog.Common.Enums;

namespace Catalog.Service.EventHandlers
{
    public class ProductInStockUpdateStockEventHandler : INotificationHandler<ProductInStockUpdateStockCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public ProductInStockUpdateStockEventHandler(ApplicationDbContext context, ILogger<ProductInStockUpdateStockEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(ProductInStockUpdateStockCommand notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--- ProductInStockUpdateStockCommand started");

            var products = notification.Items.Select(x => x.ProductId);
            var stocks = await _context.Stocks.Where(x => products.Contains(x.ProductId)).ToListAsync();

            _logger.LogInformation("--- Retrive products from database");

            foreach (var item in notification.Items)
            {
                var entry = stocks.SingleOrDefault(x => x.ProductId == item.ProductId);

                if (item.Action == ProductInStockAction.Substract)
                {
                    if (entry == null || item.Stock > entry.Stock)
                    {
                        _logger.LogError($"Product {entry.ProductId} - doesn't have enough stock");
                        throw new Exception($"Product {entry.ProductId} - doesn't have enough stock");
                    }

                    entry.Stock -= item.Stock;
                    _logger.LogError($"Product {entry.ProductId} - its stock was substracted -  new stock {entry.Stock}");
                }
                else
                {
                    if (entry == null)
                    {
                        entry = new ProductInStock
                        {
                            ProductId = item.ProductId
                        };

                        await _context.AddAsync(entry);
                        _logger.LogInformation($"New stock record was created for {entry.ProductId} because didn't exists before");

                    }

                    entry.Stock += item.Stock;
                    _logger.LogInformation($"Product {entry.ProductId} - its stock was increased and new stock is {entry.Stock}");

                }
            }

            await _context.SaveChangesAsync();

            _logger.LogInformation("--- ProductInStockUpdateStockCommand ended");
        }

    }
}
