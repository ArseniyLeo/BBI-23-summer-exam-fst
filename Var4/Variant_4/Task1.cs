using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
namespace Variant_4
{
    public class Task1
    {
        public struct Triangle
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
            public int B => sides[1]; public int C => sides[2];
            private bool IsValidTriangle(int[] sides)
            {
                return sides[0] + sides[1] > sides[2] && sides[0] + sides[2] > sides[1] &&
                       sides[1] + sides[2] > sides[0];
            }
            public string Distinct()
            {
                if (A == B && B == C)
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

            public double Area()
            {
                if (sides.Length == 0)
                {
                    return 0;
                }
                double p = (A + B + C) / 2.0;
                return Math.Round(Math.Sqrt(p * (p - A) * (p - B) * (p - C)));
            }
            public override string ToString()
            {
                return $"Type = Треугольник, subtype = {Distinct()}, a = {A}, b = {B}, c = {C}, площадь = {Area():F2}";
            }
        }

        private Triangle[] triangles;
        public Task1(Triangle[] triangles)
        {
            this.triangles = triangles;
        }
        public Triangle[] Triangles => triangles;
        public void Sorting()
        {
            triangles = SortTriangles(triangles, 0, triangles.Length - 1);
        }
        private Triangle[] SortTriangles(Triangle[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex; var pivot = array[leftIndex].Area();
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
                    Triangle temp = array[i];
                    array[i] = array[j]; array[j] = temp;
                    i++; j--;
                }
            }
            if (leftIndex < j)
                SortTriangles(array, leftIndex, j);
            if (i < rightIndex) SortTriangles(array, i, rightIndex);
            return array;
        }
        public override string ToString()
        {
            string result = ""; foreach (Triangle triangle in triangles)
            {
                result += triangle.ToString() + "\n";
            }
            return result;
        }
    }
}