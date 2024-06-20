using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Variant_4
{

    public class Task2
    {
        public abstract class Figure
        {
            public abstract string Distinct();
            public abstract double Area();
            public override string ToString()
            {
                return $"Type = {GetType().Name}, subtype = {Distinct()}, площадь = {Area():F2}";
            }
        }

        public class Circle : Figure
        {
            private double radius1;
            private double radius2;

            public Circle(double radius1, double radius2)
            {
                this.radius1 = radius1;
                this.radius2 = radius2;
            }

            public override string Distinct()
            {
                if (radius1 == radius2)
                {
                    return "круг";
                }
                else
                {
                    return "эллипс";
                }
            }

            public override double Area()
            {
                return Math.PI * radius1 * radius2;
            }
        }

        public class Fourangle : Figure
        {
            private double side1;
            private double side2;

            public Fourangle(double side1, double side2)
            {
                this.side1 = side1;
                this.side2 = side2;
            }

            public override string Distinct()
            {
                if (side1 == side2)
                {
                    return "квадрат";
                }
                else
                {
                    return "прямоугольник";
                }
            }

            public override double Area()
            {
                return side1 * side2;
            }
        }

        public class Triangle : Figure
        {
            private int[] sides;

            public Triangle(int[] sides)
            {
                if (IsValidTriangle(sides))
                {
                    this.sides = sides;
                }
                else
                {
                    this.sides = new int[3];
                }
            }

            public int A => sides[0];
            public int B => sides[1];
            public int C => sides[2];

            private bool IsValidTriangle(int[] sides)
            {
                return sides[0] + sides[1] > sides[2] &&
                       sides[0] + sides[2] > sides[1] &&
                       sides[1] + sides[2] > sides[0];
            }

            public override string Distinct()
            {
                if (A == B && A == C && B == C)
                {
                    return "равносторонний";
                }
                else if (A == B || A == C || B == C)
                {
                    return "равнобедренный";
                }
                else
                {
                    return "разносторонний";
                }
            }

            public override double Area()
            {
                if (sides.Length == 0)
                {
                    return 0;
                }
                double p = (A + B + C) / 2.0;
                return Math.Round(Math.Sqrt(p * (p - A) * (p - B) * (p - C)), 2);
            }
        }

        private Figure[] figures;

        public Task2(Figure[] figures)
        {
            this.figures = figures;
        }

        public Figure[] Figures => figures;

        public void Sorting()
        {
            figures = SortFigures(figures, 0, figures.Length - 1);
        }

        private Figure[] SortFigures(Figure[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex].Area();

            while (i <= j)
            {
                while (array[i].Area() < pivot)
                {
                    i++;
                }

                while (array[j].Area() > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    Figure temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                SortFigures(array, leftIndex, j);

            if (i < rightIndex)
                SortFigures(array, i, rightIndex);

            return array;
        }

        public override string ToString()
        {
            string result = "";
            foreach (Figure figure in figures)
            {
                result += figure.ToString() + "\n";
            }
            return result;
        }
    }
}