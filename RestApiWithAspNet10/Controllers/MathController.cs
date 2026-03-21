using Microsoft.AspNetCore.Mvc;
using RestApiWithAspNet10.Controllers.Utils;
using System.Security.Cryptography;

namespace RestApiWithAspNet10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        private readonly ICalculoService _calculoService;
        public MathController(ICalculoService calculoService)
        {
            _calculoService = calculoService;
        }

        [HttpGet("sum/{fisrtNumber}/{secondNumber}/{operacao}")]
        public IActionResult Get(string fisrtNumber, string secondNumber, string operacao)
        {
            if (IsNumeric(fisrtNumber) && IsNumeric(secondNumber)) 
            {   
                switch (operacao.ToLower())
                {
                    case "sum":
                        return Ok(_calculoService.Sum(fisrtNumber, secondNumber));
                    case "subtraction":
                        return Ok(_calculoService.Subtraction(fisrtNumber, secondNumber));
                    case "multiplication":
                        return Ok(_calculoService.Multiplication(fisrtNumber, secondNumber));
                    case "division":
                        return Ok(_calculoService.Division(fisrtNumber, secondNumber));
                    case "average":
                        return Ok(_calculoService.Average(fisrtNumber, secondNumber));
                    case "squareroot":
                        return Ok(_calculoService.SquareRoot(fisrtNumber));
                }
            }
            return BadRequest("Invalid Input"); 
        }

        private bool IsNumeric(string strNumber)
        {
            decimal decimalValue;
            bool isNumber = decimal.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimalValue
                ); // BR 10,5 ou US 10.5
            return isNumber;
        }
    }
}