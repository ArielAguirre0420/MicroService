using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.Queries.DTOs;
using Catalog.Service.Queries.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// Servicio para realizar las consultas
        /// </summary>
        private readonly IProductQueryService _productQueryService;

        /// <summary>
        /// Servicio que se usa para realizar el registro
        /// </summary>
        private readonly ILogger<ProductController> _logger;

        /// <summary>
        /// Dependencia para ejecutar peticiones
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor para inicializar las dependencias
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productQueryService"></param>
        /// <param name="mediator"></param>
        public ProductController(ILogger<ProductController> logger, IProductQueryService productQueryService, IMediator mediator)
        {
            _logger = logger;
            _productQueryService = productQueryService;
            _mediator = mediator;

        }

        /// <summary>
        /// Metodo para recuperar los productos existentes
        /// </summary>
        /// <param name="page">pagina solicitada</param>
        /// <param name="take">numero de resgistros por pagina</param>
        /// <param name="ids">identificador de los productos</param>
        /// <returns>Listado de productos</returns>
        [HttpGet]
        public async Task<DataCollection<ProductDto>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<int> products = null;

            if (!string.IsNullOrEmpty(ids))
            {
                products = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _productQueryService.GetAllAsync(page, take, products);
        }

        /// <summary>
        /// Metodo para recuperar la información de un producto
        /// </summary>
        /// <param name="id">Identificador del producto</param>
        /// <returns>Datos del producto</returns>
        [HttpGet("{id}")]
        public async Task<ProductDto> Get(int id)
        {
            return await _productQueryService.GetAsync(id);
        }

        /// <summary>
        /// End Point para crear Products
        /// </summary>
        /// <param name="command">Datos del producto</param>
        /// <returns>Retorna un Ok</returns>
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateCommand command)
        {
            await _mediator.Publish(command);

            return Ok();
        }
    }
}
