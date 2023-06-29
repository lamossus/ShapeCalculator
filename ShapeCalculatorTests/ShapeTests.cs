using ShapeCalculator;

namespace ShapeCalculatorTests
{
    [TestClass]
    public class ShapeTests
    {
        [TestMethod]
        public void ValidCircleArea()
        {
            var radius = 5;
            var expectedArea = 78.5398163397;
            var circle = new Circle(radius);

            var area = circle.CalculateArea();

            Assert.AreEqual(expectedArea, area, 0.001d);
        }

        [TestMethod]
        public void InvalidCircle()
        {
            double radius = -1;

            Assert.ThrowsException<InvalidShapeException>(() => new Circle(radius));
        }

        [TestMethod]
        public void SetInvalidRadius()
        {
            var circle = new Circle(1);

            Assert.ThrowsException<InvalidShapeException>(() => circle.Radius = 0);
        }

        [TestMethod]
        public void ValidTriangleArea()
        {
            var expectedArea = 14.524;
            var triangle = new Triangle(5, 12, 8);

            var area = triangle.CalculateArea();

            Assert.AreEqual(expectedArea, area, 0.001d);
        }

        [TestMethod]
        public void InvalidSidesLengthTriangle()
        {
            var sides = new double[2] { 2, 4 };

            var e = Assert.ThrowsException<InvalidShapeException>(() => new Triangle(sides));
            Assert.AreEqual("Triangle must have 3 sides. 2 sides given.", e.Message);
        }

        [TestMethod]
        public void InvalidSideTriangle()
        {
            var sides = new double[3] { 1, -2, 4 };

            var e = Assert.ThrowsException<InvalidShapeException>(() => new Triangle(sides));
            Assert.AreEqual("Triangle sides must be greater than 0. -2 given.", e.Message);
        }

        [TestMethod]
        public void InvalidTriangle()
        {
            var sides = new double[3] { 1, 2, 5 };

            var e = Assert.ThrowsException<InvalidShapeException>(() => new Triangle(sides));
            Assert.AreEqual("Valid triangle must have sum of two sides greater than a third sum. 1 + 2 is less than or equal to 5", e.Message);
        }

        [TestMethod]
        public void RightTriangle()
        {
            var rightTriangle = new Triangle(3, 4, 5);
            var notRightTriangle = new Triangle(4, 4, 5);

            Assert.AreEqual(rightTriangle.IsRight(), true);
            Assert.AreEqual(notRightTriangle.IsRight(), false);
        }

        [TestMethod]
        public void SetInvalidSides()
        {
            var triangle = new Triangle(3, 4, 5);

            Assert.ThrowsException<InvalidShapeException>(() => triangle.A = -1);
            Assert.ThrowsException<InvalidShapeException>(() => triangle.B = 10);
            Assert.ThrowsException<InvalidShapeException>(() => triangle.C = 0);
            Assert.ThrowsException<InvalidShapeException>(() => triangle.Sides = new double[2] { 1, 4 });
        }

        [TestMethod]
        public void CompileTimeUnknownArea()
        {
            IShape triangle = new Triangle(5, 12, 8);
            var expectedTriangleArea = 14.524;
            IShape circle = new Circle(5);
            var expectedCircleArea = 78.5398163397;

            Assert.AreEqual(triangle.CalculateArea(), expectedTriangleArea, 0.001d);
            Assert.AreEqual(circle.CalculateArea(), expectedCircleArea, 0.01d);
        }
    }
}