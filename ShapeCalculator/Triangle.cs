using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeCalculator
{
    public class Triangle : IShape
    {
        private double[] _sides = new double[3];

        public double[] Sides
        {
            get => _sides;
            set
            {
                try
                {
                    ValidateTriangle(value);
                    _sides = value;
                }
                catch
                {
                    throw;
                }
            }
        }
        public double A 
        {
            get => _sides[0];
            set
            {
                TrySetSide(0, value);
            }
        }
        public double B
        {
            get => _sides[1];
            set
            {
                TrySetSide(1, value);
            }
        }
        public double C
        {
            get => _sides[2];
            set
            {
                TrySetSide(2, value);
            }
        }

        public Triangle(double[] sides)
        {
            ValidateTriangle(sides);
            _sides = sides;
        }
        public Triangle(double a, double b, double c)
        {
            var sides = new double[3] {a, b, c};
            ValidateTriangle(sides);
            _sides = sides;
        }

        private void TrySetSide(int i, double value)
        {
            var newSides = (double[])_sides.Clone();
            newSides[i] = value;

            ValidateTriangle(newSides);
            _sides[i] = value;
        }

        private void ValidateTriangle(double[] sides)
        {
            if (sides.Length != 3)
                throw new InvalidShapeException($"Triangle must have 3 sides. {sides.Length} sides given.");

            for (var i = 0; i < 3; i++)
            {
                if (sides[i] <= 0)
                    throw new InvalidShapeException($"Triangle sides must be greater than 0. {sides[i]} given.");

                var otherSides = sides.Where((side, j) => j != i).ToArray();
                if (otherSides.Sum() <= sides[i])
                    throw new InvalidShapeException($"Valid triangle must have sum of two sides greater than a third sum. {otherSides[0]} + {otherSides[1]} is less than or equal to {sides[i]}");
            }
        }

        public double CalculateArea()
        {
            var p = (A + B + C) / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
        public bool IsRight()
        {
            if ((A * A == B * B + C * C) || (B * B == A * A + C * C) || (C * C == A * A + B * B))
                return true;
            return false;
        }
    }
}
