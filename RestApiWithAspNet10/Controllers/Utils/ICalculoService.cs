namespace RestApiWithAspNet10.Controllers.Utils
{
    public interface ICalculoService
    {
        public decimal Sum(string fisrtNumber, string secondNumber);
        public decimal Subtraction(string fisrtNumber, string secondNumber);
        public decimal Multiplication(string fisrtNumber, string secondNumber);
        public decimal Division(string fisrtNumber, string secondNumber);
        public decimal Average(string fisrtNumber, string secondNumber);
        public decimal SquareRoot(string firstNumber);
       
    }
}
