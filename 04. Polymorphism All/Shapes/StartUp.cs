using Shapes.Models;
using Shapes.Models.Interfaces;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IShape rect = new Rectangle(10, 20);
            Console.WriteLine(rect.CalculateArea());
            Console.WriteLine(rect.CalculatePerimeter());
            Console.WriteLine(rect.Draw());

            IShape circle = new Circle(10.4);
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.Draw());
        }
    }
}
