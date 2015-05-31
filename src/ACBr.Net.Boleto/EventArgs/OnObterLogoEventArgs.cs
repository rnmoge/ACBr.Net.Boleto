// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 04-17-2014
//
// Last Modified By : RFTD
// Last Modified On : 04-17-2014
// ***********************************************************************
// <copyright file="OnObterLogoEventArgs.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Drawing;

namespace ACBr.Net.Boleto.EventArgs
{
    /// <summary>
    /// Class OnObterLogoEventArgs.
    /// </summary>
    public class OnObterLogoEventArgs : System.EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnObterLogoEventArgs"/> class.
        /// </summary>
        /// <param name="banco">The banco.</param>
        public OnObterLogoEventArgs(int banco)
        {
            NumeroBanco = banco;
        }

        /// <summary>
        /// Gets or sets the logo.
        /// </summary>
        /// <value>The logo.</value>
        public Image Logo { get; set; }
        /// <summary>
        /// Gets the numero banco.
        /// </summary>
        /// <value>The numero banco.</value>
        public int NumeroBanco { get; private set; }
    }
}
