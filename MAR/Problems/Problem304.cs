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

namespace MAR.Problems
{
    /// <summary>
    /// Problema 4: Diseñar un algoritmo que compruebe si un vector V [1..n]
    /// es un montículo de máximos y determinar su complejidad temporal.
    /// </summary>
    public static class Problem304
    {
        /// <summary>
        /// Entrada principal para ejecutar el problema.
        /// </summary>
        public static void Execute()
        {
            Console.WriteLine("|============|");
            Console.WriteLine("| Problema 4 |");
            Console.WriteLine("|============|\n");

            showAndCheckArray("V1", new int[] { 1, 8, 6, 5, 3, 7, 4 });
            showAndCheckArray("V2", new int[] { 8, 5, 7, 1, 3, 6, 4 });
        }

        /// <summary>
        /// Muestra y comprueba un array de números enteros.
        /// </summary>
        private static void showAndCheckArray(string name, int[] victims)
        {
            var result1 = IsMaxHeap(victims, victims.Length);
            var result2 = IsMaxHeap(victims, victims.Length, 0);
            Console.WriteLine(name + " = " + Util.ToString(victims));
            Console.WriteLine("¿Es un montículo de máximos?");
            Console.WriteLine("Método 1:" + Util.ToString(result1));
            Console.WriteLine("Método 2:" + Util.ToString(result2) + "\n");
        }

        /// <summary>
        /// Comprueba si un array es un montículo de máximos.
        /// </summary>
        /// <typeparam name="T">Tipo del array.</typeparam>
        /// <param name="values">Array para comprobar.</param>
        /// <param name="size">Tamaño ocupado dentro del array.</param>
        /// <returns>Si es un montículo de máximos o no.</returns>
        public static bool IsMaxHeap<T>(T[] values, int size) where T : IComparable<T>
        {
            // Recorremos los elementos del array siguientes a la raíz del
            // presunto montículo de máximos que vamos a analizar.
            for (int i = 1; i < size; i++)
            {
                // Obtenemos el índice del padre del nodo actual.
                int father = GetFatherIndex(i);
                // Si el valor del padre es menor al nodo actual, no estaremos
                // en un montículo de máximos, con lo que devolveremos falso y
                // terminaremos con el proceso de forma inmediata.
                if (values[father].CompareTo(values[i]) < 0)
                {
                    return false;
                }
            }
            // Si hemos llegado hasta aquí podemos estar en tres casos:
            // a) El array está vacío de elementos.
            // b) El array tiene un solo elemento.
            // c) Hemos recorrido los hijos de la raíz y todos han sido menores
            //    a sus respectivos nodos padres.
            // Con lo que estaremos en los tres casos ante un montículo de máximos.
            return true;
        }

        /// <summary>
        /// Obtiene el índice del nodo padre para un índice hijo dado.
        /// </summary>
        /// <param name="index">El índice del nodo hijo.</param>
        /// <returns>El índice del nodo padre.</returns>
        public static int GetFatherIndex(int index)
        {
            // Si el índice es menor que 1, o bien estamos buscando fuera
            // del rango o estamos intentando buscar un padre para la raíz.
            if (index < 1)
            {
                return 0;
            }
            // Si el índice es par estamos en una hoja derecha del montículo.
            else if (index % 2 == 0)
            {
                return (index - 2) / 2;
            }
            // Si el índice es impar estamos en una hoja izquierda del montículo.
            else
            {
                return (index - 1) / 2;
            }
        }

        /// <summary>
        /// Comprueba si un array es un montículo de máximos.
        /// </summary>
        /// <typeparam name="T">Tipo del array.</typeparam>
        /// <param name="values">Array para comprobar.</param>
        /// <param name="size">Tamaño ocupado dentro del array.</param>
        /// <param name="index">Índice actual a comprobar.</param>
        /// <returns>Si es un montículo de máximos o no.</returns>
        public static bool IsMaxHeap<T>(T[] values, int size, int index) where T : IComparable<T>
        {
            // Primero vamos a comprobar que el índice está dentro del rango ocupado del array.
            if (index < 0 || size <= index)
            {
                // La posición a comprobar está fuera del espacio ocupado dentro del array,
                // por lo que asumiremos que está ordenado como un montículo de máximos.
                return true;
            }
            else
            {
                // Si estamos dentro del espacio ocupado del array vamos primero
                // a calcular las posiciones de los nodos hijos.
                int left = 2 * index + 1;
                int right = 2 * index + 2;
                // Una vez calculados vamos a comprobar en cada hijo que dicho índice
                // no se sale del final del array ocupado, que el valor del hijo es
                // menor que el valor del nodo actual y que el nodo hijo a su vez es
                // un montículo de máximos.
                return (left  >= size || (values[index].CompareTo(values[left]) >= 0 &&
                                          IsMaxHeap(values, size, left))) &&
                       (right >= size || (values[index].CompareTo(values[right]) >= 0 &&
                                          IsMaxHeap(values, size, right)));
            }
        }
    }
}
