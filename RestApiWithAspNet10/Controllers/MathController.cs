using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace RestApiWithAspNet10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {   
        [HttpGet("sum/{fisrtNumber}/{secondNumber}/{operacao}")]
        public IActionResult Get(string fisrtNumber, string secondNumber, string operacao)
        {
            if (IsNumeric(fisrtNumber) && IsNumeric(secondNumber)) 
            {   
                switch (operacao.ToLower())
                {
                    case "sum":
                        return Ok(Sum(fisrtNumber, secondNumber));
                    case "subtraction":
                        return Ok(Subtraction(fisrtNumber, secondNumber));
                    case "multiplication":
                        return Ok(Multiplication(fisrtNumber, secondNumber));
                    case "division":
                        return Ok(Division(fisrtNumber, secondNumber));
                    case "average":
                        return Ok(Average(fisrtNumber, secondNumber));
                    case "squareroot":
                        return Ok(SquareRoot(fisrtNumber));
                }
            }
            return BadRequest("Invalid Input"); 
        }

        public decimal Sum(string fisrtNumber, string secondNumber) 
        {
            var sum = ConvertToDecimal(fisrtNumber) + ConvertToDecimal(secondNumber);
            return sum;
        }
        public decimal Subtraction(string fisrtNumber, string secondNumber)
        {
            var subtraction = ConvertToDecimal(fisrtNumber) - ConvertToDecimal(secondNumber);
            return subtraction;
        }
        public decimal Multiplication(string fisrtNumber, string secondNumber)
        {
            var multiplication = ConvertToDecimal(fisrtNumber) * ConvertToDecimal(secondNumber);
            return multiplication;
        }
        public decimal Division(string fisrtNumber, string secondNumber)
        {
            var division = ConvertToDecimal(fisrtNumber) / ConvertToDecimal(secondNumber);
            return division;
        }
        public decimal Average(string fisrtNumber, string secondNumber)
        {
            var average = (ConvertToDecimal(fisrtNumber) + ConvertToDecimal(secondNumber)) / 2;
            return average;
        }
        public decimal SquareRoot(string firstNumber)
        {
            double number = Convert.ToDouble(firstNumber);
            double result = Math.Sqrt(number);
            return (decimal)result;
        }
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimalValue)
                ) 
            { 
                return decimalValue;
            }
            return 0;
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