using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeCalculator
{
    public class Circle : IShape
    {
        private double _radius;

        public double Radius
        {
            get => _radius;
            set
            {
                try
                {
                    ValidateCircle(value);
                    _radius = value;
                }
                catch
                {
                    throw;
                }
            }
        }

        public Circle(double radius)
        {
            ValidateCircle(radius);
            _radius = radius;
        }

        private void ValidateCircle(double radius)
        {
            if (radius <= 0)
                throw new InvalidShapeException($"Radius of circle must be greater than 0. {radius} radius given.");
        }

        public double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }
    }
}
