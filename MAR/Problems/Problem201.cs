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
using MAR.Shared;
using MAR.Trees;

namespace MAR.Problems
{
    /// <summary>
    /// Problema 1: Escribir un algoritmo recursivo de coste lineal en el cardinal 
    /// del árbol que compruebe si un árbol binario está equilibrado en altura.
    /// </summary>
    public static class Problem201
    {
        /// <summary>
        /// Entrada principal para ejecutar el problema.
        /// </summary>
        public static void Execute()
        {
            Console.WriteLine("|============|");
            Console.WriteLine("| Problema 1 |");
            Console.WriteLine("|============|\n");

            Console.WriteLine("<< Añadir secuencia de valores >>\n");

            var victim1 = new BinaryTree<int>();
            var victim2 = new BinaryTree<int>();
            victim1.Add(new int[] { 7, 3, 1, 6, 2, 4, 8, 5, 9, 10 });
            victim2.Add(new int[] { 5, 3, 2, 1, 4, 7, 6, 9, 8, 10 });

            Console.WriteLine("<< Datos finales del árbol >>\n");

            showTree("Primer árbol", victim1);
            showTree("Segundo árbol", victim2);
        }

        /// <summary>
        /// Muestra y comprueba un árbol binario ordenado.
        /// </summary>
        private static void showTree<T>(string name, BinaryTree<T> victim) where T : IComparable<T>
        {
            string msg = Util.ToString(victim.IsBalanced);
            Console.WriteLine(name + ":\n" + victim + "\n");
            Console.WriteLine("¿Está balanceado? " + msg + "\n");
        }
    }
}
