using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Height
        {
            get { return height; }
            private set
            {
                ThrowIfSideIsInvalid(value, nameof(Height));
                height = value;
            }
        }


        public double Width
        {
            get { return width; }
            private set
            {
                ThrowIfSideIsInvalid(value, nameof(Width));
                width = value;
            }
        }


        public double Length
        {
            get { return length; }
            private set
            {
                ThrowIfSideIsInvalid(value, nameof(Length));
                length = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
        }

        public double LateralSurfaceArea()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }

        public double Volume()
        {
            return Length * Height * Width;
        }
        private void ThrowIfSideIsInvalid(double value, string side)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{side} cannot be zero or negative.");
            }
        }
    }
}
