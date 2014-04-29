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

/// <summary>
/// The Boleto namespace.
/// </summary>
namespace ACBr.Net.Boleto
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
            int inicio = de - 1;
            return linha.Substring(inicio, ate - inicio);
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
            return int.Parse(ExtrairDaPosicao(linha, de, ate));
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
            return long.Parse(ExtrairDaPosicao(linha, de, ate));
        }

        /// <summary>
        /// Extrairs the data da posicao.
        /// </summary>
        /// <param name="linha">The linha.</param>
        /// <param name="de">The de.</param>
        /// <param name="ate">The ate.</param>
        /// <returns>DateTime.</returns>
        public static DateTime ExtrairDataDaPosicao(this string linha, int de, int ate)
        {
            string valor = ExtrairDaPosicao(linha, de, ate);
            return DateTime.ParseExact(valor, "ddMMyyyy", null);
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
            decimal ret = ExtrairInt32DaPosicao(linha, de, ate);
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
            var ret = ExtrairInt32OpcionalDaPosicao(linha, de, ate);
            if (ret.HasValue)
            {
                decimal retorno = ret.Value / 100;
                return retorno;
            }
            else
                return null;
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
            string valor = ExtrairDaPosicao(linha, de, ate);
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
        /// <returns>System.Nullable&lt;DateTime&gt;.</returns>
        public static DateTime? ExtrairDataOpcionalDaPosicao(this string linha, int de, int ate)
        {
            string valor = ExtrairDaPosicao(linha, de, ate);
            DateTime aux;
            if (DateTime.TryParseExact(valor, "ddMMyyyy", null, DateTimeStyles.None, out aux))
            {
                return aux;
            }
            return null;
        }
    }
}
