﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductDetailsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("GetProductDetailsByProductId/{id}")]
        public async Task<IActionResult> GetProductDetailByProductIdDAsync(int id)
        {
            var values = await _productRepository.GetProductDetailByProductIdDAsync(id);
            return Ok(values);
        }
    }
}
