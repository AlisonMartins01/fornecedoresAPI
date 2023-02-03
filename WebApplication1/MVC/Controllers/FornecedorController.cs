using Microsoft.AspNetCore.Mvc;
using WebApplication1.Base.Controller;
using WebApplication1.MVC.Model;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorController : ControllerBase
    {
             
        private readonly ILogger<FornecedorController> _logger;
        private readonly BaseController bd;

        public FornecedorController(ILogger<FornecedorController> logger, BaseController _bd)
        {
            _logger = logger;
            bd = _bd;
        }

        [HttpGet(Name = "GetFornecedores")]
        public IActionResult Get(int id)
        {
            var result = bd.CommandGetFornecedorById(id);

            if(result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpGet(Name = "GetFornecedores")]
        public IActionResult GetAll(FiltroFornecedores filtro)
        {
            var result = bd.CommandGetFornecedores(filtro);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        

        [HttpPost(Name = "PostFornecedor")]
        public IActionResult Post(Fornecedor fornecedor) 
        {
            var result = bd.CommandPostFornecedor(fornecedor);

            if (result == 0)
                return NotFound();

            return Ok(result);
        }

        [HttpPut(Name = "PutFornecedor")]
        public IActionResult Put(Fornecedor fornecedor)
        {
            var result = bd.CommandPutFornecedores(fornecedor);

            if (result == 0)
                return NotFound();

            return Ok(result);
        }

    }
}