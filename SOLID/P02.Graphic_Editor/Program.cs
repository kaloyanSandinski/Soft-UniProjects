using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape square = new Square();
            GraphicEditor graphic = new GraphicEditor();
            graphic.DrawShape(square);
            IShape circle = new Circle();
            graphic.DrawShape(circle);
        }
    }
}
