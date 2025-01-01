using P02.Graphic_Editor.Contracts;
using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape circle = new Circle();
            IShape square = new Square();
            IShape rectangle = new Rectangle();

            GraphicEditor editor = new();

            Console.WriteLine(editor.DrawShape(circle));
            Console.WriteLine(editor.DrawShape(square));
            Console.WriteLine(editor.DrawShape(rectangle));
        }
    }
}
