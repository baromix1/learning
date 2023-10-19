using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string GetProducts(){
            return "string of products todo";
        }

        [HttpGet("{id}")]
        public string GetProduct(int id){
            return "string of product todo";
        }
    }
}