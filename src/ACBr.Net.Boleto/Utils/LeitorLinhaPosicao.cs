// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 04-18-2014
//
// Last Modified By : RFTD
// Last Modified On : 04-22-2014
// ***********************************************************************
// <copyright file="LeitorLinhaPosicao.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Globalization;

namespace ACBr.Net.Boleto.Utils
{
    /// <summary>
    /// Class LeitorLinhaPosicao.
    /// </summary>
    internal static class LeitorLinhaPosicao
    {
        /// <summary>
        /// Extrairs the da posicao.
        /// </summary>
        /// <param name="linha">The linha.</param>
        /// <param name="de">The de.</param>
        /// <param name="ate">The ate.</param>
        /// <returns>System.String.</returns>
        public static string ExtrairDaPosicao(this string linha, int de, int ate)
        {
            var inicio = de - 1;
            return linha.Substring(inicio, ate - inicio);
        }

		public static string ExtrairDaPosicao(this string linha, int de)
		{
			return linha.ExtrairDaPosicao(de, de);
		}

        /// <summary>
        /// Extrairs the int32 da posicao.
        /// </summary>
        /// <param name="linha">The linha.</param>
        /// <param name="de">The de.</param>
        /// <param name="ate">The ate.</param>
        /// <returns>System.Int32.</returns>
        public static int ExtrairInt32DaPosicao(this string linha, int de, int ate)
        {
			return int.Parse(linha.ExtrairDaPosicao(de, ate));
        }

        /// <summary>
        /// Extrairs the int64 da posicao.
        /// </summary>
        /// <param name="linha">The linha.</param>
        /// <param name="de">The de.</param>
        /// <param name="ate">The ate.</param>
        /// <returns>System.Int64.</returns>
        public static long ExtrairInt64DaPosicao(this string linha, int de, int ate)
        {
			return long.Parse(linha.ExtrairDaPosicao(de, ate));
        }

		/// <summary>
		/// Extrairs the data da posicao.
		/// </summary>
		/// <param name="linha">The linha.</param>
		/// <param name="de">The de.</param>
		/// <param name="ate">The ate.</param>
		/// <param name="format">The format.</param>
		/// <returns>DateTime.</returns>
		public static DateTime ExtrairDataDaPosicao(this string linha, int de, int ate, string format = "ddMMyyyy")
        {
			var valor = linha.ExtrairDaPosicao(de, ate);
            return DateTime.ParseExact(valor, format, null);
        }

        /// <summary>
        /// Extrairs the decimal da posicao.
        /// </summary>
        /// <param name="linha">The linha.</param>
        /// <param name="de">The de.</param>
        /// <param name="ate">The ate.</param>
        /// <returns>System.Decimal.</returns>
        public static decimal ExtrairDecimalDaPosicao(this string linha, int de, int ate)
        {
            decimal ret = linha.ExtrairInt32DaPosicao(de, ate);
            ret = ret / 100;
            return ret;
        }

        /// <summary>
        /// Extrairs the decimal opcional da posicao.
        /// </summary>
        /// <param name="linha">The linha.</param>
        /// <param name="de">The de.</param>
        /// <param name="ate">The ate.</param>
        /// <returns>System.Nullable&lt;System.Decimal&gt;.</returns>
        public static decimal? ExtrairDecimalOpcionalDaPosicao(this string linha, int de, int ate)
        {
			var ret = linha.ExtrairInt32OpcionalDaPosicao(de, ate);
	        if (!ret.HasValue) 
				return null;

	        decimal retorno = ret.Value / 100;
	        return retorno;
        }

        /// <summary>
        /// Extrairs the int32 opcional da posicao.
        /// </summary>
        /// <param name="linha">The linha.</param>
        /// <param name="de">The de.</param>
        /// <param name="ate">The ate.</param>
        /// <returns>System.Nullable&lt;System.Int32&gt;.</returns>
        public static int? ExtrairInt32OpcionalDaPosicao(this string linha, int de, int ate)
        {
			var valor = linha.ExtrairDaPosicao(de, ate);
            int aux;
            if (int.TryParse(valor, out aux))
            {
                return aux;
            }
            return null;
        }

		/// <summary>
		/// Extrairs the data opcional da posicao.
		/// </summary>
		/// <param name="linha">The linha.</param>
		/// <param name="de">The de.</param>
		/// <param name="ate">The ate.</param>
		/// <param name="format">The format.</param>
		/// <returns>System.Nullable&lt;DateTime&gt;.</returns>
		public static DateTime? ExtrairDataOpcionalDaPosicao(this string linha, int de, int ate, string format = "ddMMyyyy")
        {
			var valor = linha.ExtrairDaPosicao(de, ate);
            DateTime aux;
            if (DateTime.TryParseExact(valor, format, null, DateTimeStyles.None, out aux))
            {
                return aux;
            }
            return null;
        }
    }
}
