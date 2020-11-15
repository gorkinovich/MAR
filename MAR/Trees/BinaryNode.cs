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

namespace MAR.Trees
{
    /// <summary>
    /// Nodo de árbol binario ordenado.
    /// </summary>
    /// <typeparam name="T">El tipo del valor del nodo.</typeparam>
    public class BinaryNode<T> where T : IComparable<T>
    {
        //********************************************************************************
        // Constructores
        //********************************************************************************

        /// <summary>
        /// Construye un nuevo objeto.
        /// </summary>
        /// <param name="value">El valor del nodo.</param>
        public BinaryNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        /// <summary>
        /// Construye un nuevo objeto.
        /// </summary>
        /// <param name="value">El valor del nodo.</param>
        /// <param name="left">El nodo izquierdo del nodo.</param>
        /// <param name="right">El nodo derecho del nodo.</param>
        public BinaryNode(T value, BinaryNode<T> left, BinaryNode<T> right)
        {
            Value = value;
            SetChilds(left, right);
        }

        //********************************************************************************
        // Propiedades
        //********************************************************************************

        /// <summary>
        /// Devuelve el valor del nodo.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Cambia o devuelve el hijo izquierdo del nodo.
        /// </summary>
        public BinaryNode<T> Left { get; set; }

        /// <summary>
        /// Cambia o devuelve el hijo derecho del nodo.
        /// </summary>
        public BinaryNode<T> Right { get; set; }

        /// <summary>
        /// Devuelve si tiene un hijo izquierdo el nodo.
        /// </summary>
        public bool HasLeft { get => Left != null; }

        /// <summary>
        /// Devuelve si tiene un hijo derecho el nodo.
        /// </summary>
        public bool HasRight { get => Right != null; }

        /// <summary>
        /// Devuelve si tiene algún hijo el nodo.
        /// </summary>
        public bool HasChilds { get => HasLeft || HasRight; }

        //********************************************************************************
        // Métodos
        //********************************************************************************

        /// <summary>
        /// Actualiza los nodos hijos del nodo.
        /// </summary>
        /// <param name="left">El nodo izquierdo del nodo.</param>
        /// <param name="right">El nodo derecho del nodo.</param>
        public void SetChilds(BinaryNode<T> left, BinaryNode<T> right)
        {
            Left = left;
            Right = right;
        }

        /// <summary>
        /// Comprueba si el nodo es igual que un valor.
        /// </summary>
        /// <param name="value">El valor a comprobar.</param>
        /// <returns>Devuelve si es igual el nodo o no.</returns>
        public bool IsEqualThan(T value)
        {
            return Value.CompareTo(value) == 0;
        }

        /// <summary>
        /// Comprueba si el nodo es mayor que un valor.
        /// </summary>
        /// <param name="value">El valor a comprobar.</param>
        /// <returns>Devuelve si es mayor el nodo o no.</returns>
        public bool IsGreaterThan(T value)
        {
            return Value.CompareTo(value) > 0;
        }

        /// <summary>
        /// Comprueba si el nodo es menor que un valor.
        /// </summary>
        /// <param name="value">El valor a comprobar.</param>
        /// <returns>Devuelve si es menor el nodo o no.</returns>
        public bool IsLesserThan(T value)
        {
            return Value.CompareTo(value) < 0;
        }

        //********************************************************************************
        // Funciones: Añadir
        //********************************************************************************

        /// <summary>
        /// Añade un valor a un árbol ordenado.
        /// </summary>
        /// <param name="value">El valor a añadir.</param>
        /// <param name="node">El nodo donde añadir el valor.</param>
        /// <returns>El nodo con el valor añadido.</returns>
        public static BinaryNode<T> Add(T value, BinaryNode<T> node)
        {
            if (node == null)
            {
                // Si hemos llegado al final de la ruta devolvemos un nuevo
                // nodo con el valor que queremos añadir al árbol.
                return new BinaryNode<T>(value);
            }
            else
            {
                if (node.IsGreaterThan(value))
                {
                    // Cuando el valor a introducir es menor o igual que el
                    // valor del nodo actual, tenemos que añadir el nuevo
                    // valor en la rama izquierda.
                    node.Left = Add(value, node.Left);
                }
                else
                {
                    // Cuando el valor a introducir es mayor que el valor
                    // del nodo actual, tenemos que añadir el nuevo valor
                    // en la rama derecha.
                    node.Right = Add(value, node.Right);
                }
                return node;
            }
        }

        //********************************************************************************
        // Funciones: Quitar
        //********************************************************************************

        /// <summary>
        /// Quita un valor de un árbol ordenado.
        /// </summary>
        /// <param name="value">El valor a quitar.</param>
        /// <param name="node">El nodo del que quitar el valor.</param>
        /// <returns>El nodo con el valor quitado.</returns>
        public static BinaryNode<T> Remove(T value, BinaryNode<T> node)
        {
            if (node == null)
            {
                // Si hemos llegado al final de la ruta no habremos encontrado
                // ningún nodo con el valor que estamos buscando para borrar.
                return null;
            }
            else if (node.IsEqualThan(value))
            {
                // Cuando el valor es igual que el valor del nodo actual,
                // hemos encontrado el nodo que buscamos y lo borramos.
                if (node.HasLeft && node.HasRight)
                {
                    // Si el nodo encontrado tiene hijos, tomamos la rama
                    // derecha y se la insertamos a la rama izquierda para
                    // devolver el resultado de la inserción.
                    return insert(node.Right, node.Left);
                }
                else if (node.HasLeft)
                {
                    // Si sólo tiene la rama izquierda la devolvemos.
                    return node.Left;
                }
                else if (node.HasRight)
                {
                    // Si sólo tiene la rama derecha la devolvemos.
                    return node.Right;
                }
                else
                {
                    // Si no tiene ramas devolvemos nulo.
                    return null;
                }
            }
            else
            {
                if (node.IsGreaterThan(value))
                {
                    // Cuando el valor es menor que el valor del nodo actual,
                    // tenemos que seguir buscando en la rama izquierda.
                    node.Left = Remove(value, node.Left);
                }
                else if (node.IsLesserThan(value))
                {
                    // Cuando el valor es mayor que el valor del nodo actual,
                    // tenemos que seguir buscando en la rama derecha.
                    node.Right = Remove(value, node.Right);
                }
                return node;
            }
        }

        /// <summary>
        /// Inserta un nodo en un árbol ordenado.
        /// </summary>
        /// <param name="value">El nodo a insertar.</param>
        /// <param name="node">El nodo donde insertar el valor.</param>
        /// <returns>El nodo con el valor insertado.</returns>
        private static BinaryNode<T> insert(BinaryNode<T> value, BinaryNode<T> node)
        {
            if (value == null)
            {
                // Si tratamos de insertar un valor nulo salimos de la
                // inserción devolviendo el nodo inicial a modificar.
                return node;
            }
            else if (node == null)
            {
                // Si hemos llegado al final de la ruta devolvemos  el
                // valor que queremos añadir al árbol.
                return value;
            }
            else
            {
                if (node.IsEqualThan(value.Value))
                {
                    // En el caso de que el valor que estemos introduciendo sea
                    // igual en la comparación con el nodo actual, tendremos que
                    // partir por la mitad el valor para tomar su rama izquierda
                    // e introducirla en el lado izquierdo del nodo actual.
                    if (value.HasLeft)
                    {
                        node.Left = insert(value.Left, node.Left);
                        value.Left = null;
                    }
                    // El resto del valor a introducir lo introduciremos en
                    // la rama derecha del nodo actual.
                    node.Right = insert(value, node.Right);
                }
                else if (node.IsGreaterThan(value.Value))
                {
                    // Cuando el valor a introducir es menor en la comparación
                    // con el nodo actual, tenemos que añadir el nuevo valor
                    // en la rama izquierda.
                    node.Left = insert(value, node.Left);
                }
                else if (node.IsLesserThan(value.Value))
                {
                    // Cuando el valor a introducir es mayor en la comparación
                    // con el nodo actual, tenemos que añadir el nuevo valor
                    // en la rama derecha.
                    node.Right = insert(value, node.Right);
                }
                return node;
            }
        }

        //********************************************************************************
        // Funciones: Buscar
        //********************************************************************************

        /// <summary>
        /// Busca un valor dentro de un árbol ordenado.
        /// </summary>
        /// <param name="value">El valor a buscar.</param>
        /// <param name="node">El nodo donde buscar el valor.</param>
        /// <returns>El nodo encontrado o null si no se encuentra.</returns>
        public static BinaryNode<T> FindNode(T value, BinaryNode<T> node)
        {
            if (node == null)
            {
                // Si hemos llegado al final de la ruta no habremos encontrado
                // ningún nodo con el valor que estamos buscando.
                return null;
            }
            else if (node.IsEqualThan(value))
            {
                // Cuando el valor es igual que el valor del nodo actual,
                // hemos encontrado el nodo que buscamos y lo devolvemos.
                return node;
            }
            else if (node.IsGreaterThan(value))
            {
                // Cuando el valor es menor que el valor del nodo actual,
                // tenemos que seguir buscando en la rama izquierda.
                return FindNode(value, node.Left);
            }
            else
            {
                // Cuando el valor es mayor que el valor del nodo actual,
                // tenemos que seguir buscando en la rama derecha.
                return FindNode(value, node.Right);
            }
        }

        //********************************************************************************
        // Funciones: Propiedades
        //********************************************************************************

        /// <summary>
        /// Obtiene la altura del árbol.
        /// </summary>
        /// <param name="node">El nodo a inspeccionar.</param>
        /// <returns>Devuelve la altura del árbol.</returns>
        public static int GetHeight(BinaryNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                var left = GetHeight(node.Left);
                var right = GetHeight(node.Right);
                return 1 + Math.Max(left, right);
            }
        }

        /// <summary>
        /// Obtiene el valor máximo del árbol.
        /// </summary>
        /// <param name="node">El nodo a inspeccionar.</param>
        /// <returns>Devuelve el valor máximo del árbol.</returns>
        public static T GetMaximum(BinaryNode<T> node)
        {
            if (node == null)
            {
                return default(T);
            }
            else if (node.HasRight)
            {
                return GetMaximum(node.Right);
            }
            else
            {
                return node.Value;
            }
        }

        /// <summary>
        /// Obtiene el valor mínimo del árbol.
        /// </summary>
        /// <param name="node">El nodo a inspeccionar.</param>
        /// <returns>Devuelve el valor mínimo del árbol.</returns>
        public static T GetMinimum(BinaryNode<T> node)
        {
            if (node == null)
            {
                return default(T);
            }
            else if (node.HasLeft)
            {
                return GetMinimum(node.Left);
            }
            else
            {
                return node.Value;
            }
        }

        /// <summary>
        /// Comprueba si el árbol está balanceado.
        /// </summary>
        /// <param name="node">El nodo a inspeccionar.</param>
        /// <returns>Devuelve si el árbol está balanceado.</returns>
        public static bool IsBalanced(BinaryNode<T> node)
        {
            var result = isBalanced(node);
            return result.Item2;
        }

        /// <summary>
        /// Comprueba si el árbol está balanceado.
        /// </summary>
        /// <param name="node">El nodo a inspeccionar.</param>
        /// <returns>Devuelve si el árbol está balanceado.</returns>
        private static Tuple<int, bool> isBalanced(BinaryNode<T> node)
        {
            if (node == null)
            {
                return new Tuple<int, bool>(0, true);
            }
            else
            {
                const int MAX_UNBALANCED = 1;
                var left = isBalanced(node.Left);
                var right = isBalanced(node.Right);
                var height = 1 + Math.Max(left.Item1, right.Item1);
                var flag = left.Item2 && right.Item2 &&
                    Math.Abs(left.Item1 - right.Item1) <= MAX_UNBALANCED;
                return new Tuple<int, bool>(height, flag);
            }
        }
    }
}
