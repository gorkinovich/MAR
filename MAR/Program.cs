//******************************************************************************************
// Copyright (c) 2020-2021 Gorka Suárez García
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
//******************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using MAR.Problems;

namespace MAR
{
    class Program
    {
        /// <summary>
        /// Entrada principal a la ejecución de las hojas de problemas.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Métodos algorítmicos en resolución de problemas");
            Console.WriteLine("===============================================\n");

            //TODO: Check this function...
            var sequence = new int[] { 2 };
            var victims = new Action[] {
                () => {
                    chapter2(new int[] { 1 });
                }, // Enumerable.Range(1, 22)
                () => {
                    chapter3(new int[] { 1 });
                }, // Enumerable.Range(1, 25)
                () => {
                    chapter4(new int[] { });
                }, // Enumerable.Range(1, 1)
                () => {
                    chapter5(new int[] { });
                }, // Enumerable.Range(1, 1)
                () => {
                    chapter6(new int[] { });
                } // Enumerable.Range(1, 1)
            };
            execute(sequence, victims);
        }

        /// <summary>
        /// Ejercicios de árboles de búsqueda avanzados.
        /// </summary>
        private static void chapter2(IEnumerable<int> sequence)
        {
            Console.WriteLine("Ejercicios de árboles de búsqueda avanzados");
            Console.WriteLine("-------------------------------------------\n");

            var problems = new Action[] {
                Problem201.Execute//, Problem202.Execute, Problem203.Execute,
                //Problem204.Execute, Problem205.Execute, Problem206.Execute,
                //Problem207.Execute, Problem208.Execute, Problem209.Execute,
                //Problem210.Execute, Problem211.Execute, Problem212.Execute,
                //Problem213.Execute, Problem214.Execute, Problem215.Execute,
                //Problem216.Execute, Problem217.Execute, Problem218.Execute,
                //Problem219.Execute, Problem220.Execute, Problem221.Execute,
                //Problem222.Execute
            };
            execute(sequence, problems);
        }

        /// <summary>
        /// Ejercicios de colas con prioridad y montículos.
        /// </summary>
        private static void chapter3(IEnumerable<int> sequence)
        {
            Console.WriteLine("Ejercicios de colas con prioridad y montículos");
            Console.WriteLine("----------------------------------------------\n");

            var problems = new Action[] {
                //TODO: Check this array...
                Problem304.Execute
            };
            execute(sequence, problems);
        }

        /// <summary>
        /// Ejercicios de grafos.
        /// </summary>
        private static void chapter4(IEnumerable<int> sequence)
        {
            Console.WriteLine("Ejercicios de grafos");
            Console.WriteLine("--------------------\n");

            var problems = new Action[] {
                //TODO: Check this array...
            };
            execute(sequence, problems);
        }

        /// <summary>
        /// Ejercicios de estructuras de partición.
        /// </summary>
        private static void chapter5(IEnumerable<int> sequence)
        {
            Console.WriteLine("Ejercicios de estructuras de partición");
            Console.WriteLine("--------------------------------------\n");

            var problems = new Action[] {
                //TODO: Check this array...
            };
            execute(sequence, problems);
        }

        /// <summary>
        /// Ejercicios de algoritmos voraces.
        /// </summary>
        private static void chapter6(IEnumerable<int> sequence)
        {
            Console.WriteLine("Ejercicios de algoritmos voraces");
            Console.WriteLine("--------------------------------\n");

            var problems = new Action[] {
                //TODO: Check this array...
            };
            execute(sequence, problems);
        }

        /// <summary>
        /// Ejecuta una secuencia de problemas.
        /// </summary>
        private static void execute(IEnumerable<int> sequence, Action[] problems)
        {
            foreach (var index in sequence)
            {
                if (0 < index && index <= problems.Length)
                {
                    problems[index - 1]();
                }
            }
        }
    }
}
