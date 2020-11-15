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

namespace MAR.Trees
{
    /// <summary>
    /// Árbol binario ordenado.
    /// </summary>
    /// <typeparam name="T">El tipo del valor del nodo.</typeparam>
    public class BinaryTree<T> where T : IComparable<T>
    {
        //********************************************************************************
        // Constructores
        //********************************************************************************

        /// <summary>
        /// Construye un nuevo objeto.
        /// </summary>
        public BinaryTree()
        {
            Root = null;
        }

        //********************************************************************************
        // Propiedades
        //********************************************************************************

        /// <summary>
        /// Devuelve el nodo raíz del árbol.
        /// </summary>
        public BinaryNode<T> Root { get; private set; }

        /// <summary>
        /// Devuelve la altura del árbol.
        /// </summary>
        public int Height { get => BinaryNode<T>.GetHeight(Root); }

        /// <summary>
        /// Devuelve el valor máximo del árbol.
        /// </summary>
        public T Maximum { get => BinaryNode<T>.GetMaximum(Root); }

        /// <summary>
        /// Devuelve el valor mínimo del árbol.
        /// </summary>
        public T Minimum { get => BinaryNode<T>.GetMinimum(Root); }

        /// <summary>
        /// Devuelve si el árbol está balanceado.
        /// </summary>
        public bool IsBalanced { get => BinaryNode<T>.IsBalanced(Root); }

        //********************************************************************************
        // Métodos
        //********************************************************************************

        /// <summary>
        /// Añade unos valores a un árbol ordenado.
        /// </summary>
        /// <param name="value">Los valores a añadir.</param>
        public void Add(IEnumerable<T> values)
        {
            foreach (var item in values)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Añade un valor a un árbol ordenado.
        /// </summary>
        /// <param name="value">El valor a añadir.</param>
        public void Add(T value)
        {
            Root = BinaryNode<T>.Add(value, Root);
        }

        /// <summary>
        /// Quita un valor de un árbol ordenado.
        /// </summary>
        /// <param name="value">El valor a quitar.</param>
        public void Remove(T value)
        {
            Root = BinaryNode<T>.Remove(value, Root);
        }

        /// <summary>
        /// Busca si existe un valor dentro de un árbol ordenado.
        /// </summary>
        /// <param name="value">El valor a buscar.</param>
        /// <returns>Devuelve si se ha encontrado el valor o no.</returns>
        public bool HasValue(T value)
        {
            return BinaryNode<T>.FindNode(value, Root) != null;
        }

        /// <summary>
        /// Busca un valor dentro de un árbol ordenado.
        /// </summary>
        /// <param name="value">El valor a buscar.</param>
        /// <returns>El nodo encontrado o null si no se encuentra.</returns>
        public BinaryNode<T> FindNode(T value)
        {
            return BinaryNode<T>.FindNode(value, Root);
        }

        //********************************************************************************
        // Métodos: ToString
        //********************************************************************************

        private const string TAB_LVL = "|-L-> ";
        private const string TAB_RVL = "|-R-> ";
        private const string TAB_IMR = "|     ";
        private const string TAB_OMR = "      ";

        /// <summary>
        /// Convierte el árbol en una cadena de texto.
        /// </summary>
        /// <returns>La representación del árbol en texto.</returns>
        public override string ToString()
        {
            return Root == null ? "[Empty Tree]" :
                Root.Value + "\n" +
                toString(TAB_LVL, TAB_IMR, Root.Left) +
                toString(TAB_RVL, TAB_OMR, Root.Right);
        }

        /// <summary>
        /// Convierte el árbol en una cadena de texto.
        /// </summary>
        /// <param name="arrow">La flecha a añadir.</param>
        /// <param name="margin">El margen a añadir.</param>
        /// <param name="node">El nodo a convertir.</param>
        /// <returns>La representación del árbol en texto.</returns>
        private string toString(string arrow, string margin, BinaryNode<T> node)
        {
            return node == null ? "" :
                arrow + node.Value + "\n" +
                toString(margin + TAB_LVL, margin + TAB_IMR, node.Left) +
                toString(margin + TAB_RVL, margin + TAB_OMR, node.Right);
        }
    }
}
