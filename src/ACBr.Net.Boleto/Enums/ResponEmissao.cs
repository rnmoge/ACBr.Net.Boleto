// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 03-22-2014
//
// Last Modified By : RFTD
// Last Modified On : 03-22-2014
// ***********************************************************************
// <copyright file="ResponEmissao.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace ACBr.Net.Boleto.Enums
{
    /// <summary>
    /// Enum ResponEmissao
    /// </summary>
    public enum ResponEmissao
    {
        /// <summary>
        /// The cli emite
        /// </summary>
        CliEmite,
        /// <summary>
        /// The banco emite
        /// </summary>
        BancoEmite,
        /// <summary>
        /// The banco reemite
        /// </summary>
        BancoReemite,
        /// <summary>
        /// The banco nao reemite
        /// </summary>
        BancoNaoReemite
    }
}
