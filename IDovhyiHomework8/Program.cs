﻿using System;
using System.Collections.Generic;

namespace IDovhyiHomework8
{
    abstract class Shape : IComparable<Shape>
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }
        public Shape(string name)
        {
            this.name = name;
        }
        public abstract double Area();
        public abstract double Perimeter();
        public int CompareTo(Shape other)
        {
            if (this.Area() - other.Area() < 0) return -1;
            if (this.Area() - other.Area() > 0) return 1; else return 0;
        }
    }
    class Circle : Shape
    {
        double radius;
        public double Radius { get { return radius; } set { radius = value; } }
        public Circle(string name, double radius) : base(name)
        {
            this.radius = radius;
        }

        public override double Area()
        {
            return Math.PI * radius*radius;
        }
        public override double Perimeter()
        {
            return 2 * Math.PI * radius;
        }
    }
    class Square : Shape
    {
        double side;
        public double Side { get { return side; } set { side = value; } }
        public Square(string name, double side) : base(name)
        { 
            this.side = side;
        }
        public override double Area()
        {
            return side * side;
        }

        public override double Perimeter()
        {
            int sidesNumber = 4;
            return side*sidesNumber;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>(10);
            Console.Write("Enter the number of circles (0..10): ");
            int circlesNumer = int.Parse(Console.ReadLine());
            for (int i = 0; i < circlesNumer; i++)
            {
                Console.Write("Shape "+(i + 1)+" is a circle. Enter the radius: ");
                double radius = double.Parse(Console.ReadLine());
                shapes.Add(new Circle("circle", radius));
            }
            for (int i = circlesNumer; i < 10; i++)
            {
                Console.Write("Shape " + (i + 1) + " is a square. Enter the side: ");
                double side = double.Parse(Console.ReadLine());
                shapes.Add(new Square("square", side));
            }
            Console.WriteLine();

            Console.WriteLine("Shape:");
            foreach (Shape shape in shapes) Console.WriteLine($"{shape.Name} with area {shape.Area():0.00} and perimeter {shape.Perimeter():0.00}");
            Console.WriteLine();


            Shape shapeMaxP = shapes[0];
            foreach (Shape shape in shapes) if (shape.Perimeter() > shapeMaxP.Perimeter()) shapeMaxP = shape;
            Console.WriteLine($"Shape with the largest perimeter: {shapeMaxP.Name} with perimetr: {shapeMaxP.Perimeter():0.00}");
            Console.WriteLine();

            Console.WriteLine("Sort shapes by area:");
            shapes.Sort();
            foreach (Shape shape in shapes) Console.WriteLine($"{shape.Name} with area {shape.Area():0.00}");
        }
    }
}
// класи не ділив по файлам для зручності перевірки коду
