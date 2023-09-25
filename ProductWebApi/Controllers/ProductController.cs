using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductLib;
using ProductLib.Extensions;
using ProductLib.Models;

namespace ProductWebApi.Controllers;

[Route("api/ProductController")]
public class ProductController : Controller
{
    private readonly ProductExtensions _service;
    public ProductController(ProductExtensions service)
    {
        _service = service;
    }
    [HttpGet]
    public IActionResult GetProduct()
    {
        return Ok(_service.ReadAllProduct());
    }
    [HttpPost]
    public IActionResult CreateProduct([FromBody] ProductCreateReq req)
    {
        _service.CreateProduct(req);
        return Ok(req);
    }
    [HttpPut]
    public IActionResult UpdateProduct([FromBody] ProductUpdateReq req)
    {
        var data = _service.UpdateProduct(req);
        return Ok(data);
    }

    [HttpDelete]
    public IActionResult DeleteProduct([FromBody] ProductDeleteReq req)
    {
        var result = _service.DeleteProduct(req.Id!);
        return (result!) ? BadRequest("Cannot Delete") : Ok("Delete Successfully");
    }
}

