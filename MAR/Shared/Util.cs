﻿//******************************************************************************************
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

namespace MAR.Shared
{
    public static class Util
    {
        /// <summary>
        /// Convierte un booleano en una cadena de texto.
        /// </summary>
        public static string ToString(bool victim)
        {
            return victim ? "Sí" : "No";
        }

        /// <summary>
        /// Convierte una secuencia en una cadena de texto.
        /// </summary>
        public static string ToString<T>(IEnumerable<T> victims)
        {
            var body = victims
                .Select(x => x.ToString())
                .Aggregate((accum, current) => accum + ", " + current);
            return "{ " + body + " }";
        }
    }
}
