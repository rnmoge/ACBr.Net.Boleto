// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 04-06-2014
//
// Last Modified By : RFTD
// Last Modified On : 04-18-2014
// ***********************************************************************
// <copyright file="Sacado.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Collections.Generic;
#region COM Interop Attributes

#if COM_INTEROP
using System.Runtime.InteropServices;
#endif


#endregion COM Interop Attributes
using ACBr.Net.Core;

/// <summary>
/// The Boleto namespace.
/// </summary>
namespace ACBr.Net.Boleto
{
    #region COM Interop Attributes

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("74B4BD49-6F82-4D37-9D7A-58B746DD3ECF")]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes
    /// <summary>
    /// Class Sacado. This class cannot be inherited.
    /// </summary>
    public sealed class Sacado
    {
        #region Propriedades

        /// <summary>
        /// Gets or sets the pessoa.
        /// </summary>
        /// <value>The pessoa.</value>
        public Pessoa Pessoa { get; set; }
        /// <summary>
        /// Gets or sets the nome sacado.
        /// </summary>
        /// <value>The nome sacado.</value>
        public string NomeSacado { get; set; }
        /// <summary>
        /// Gets or sets the CNPJCPF.
        /// </summary>
        /// <value>The CNPJCPF.</value>
        public string CNPJCPF { get; set; }
        /// <summary>
        /// Gets or sets the avalista.
        /// </summary>
        /// <value>The avalista.</value>
        public string Avalista { get; set; }
        /// <summary>
        /// Gets or sets the logradouro.
        /// </summary>
        /// <value>The logradouro.</value>
        public string Logradouro { get; set; }
        /// <summary>
        /// Gets or sets the numero.
        /// </summary>
        /// <value>The numero.</value>
        public string Numero { get; set; }
        /// <summary>
        /// Gets or sets the complemento.
        /// </summary>
        /// <value>The complemento.</value>
        public string Complemento { get; set; }
        /// <summary>
        /// Gets or sets the bairro.
        /// </summary>
        /// <value>The bairro.</value>
        public string Bairro { get; set; }
        /// <summary>
        /// Gets or sets the cidade.
        /// </summary>
        /// <value>The cidade.</value>
        public string Cidade { get; set; }
        /// <summary>
        /// Gets or sets the uf.
        /// </summary>
        /// <value>The uf.</value>
        public string UF { get; set; }
        /// <summary>
        /// Gets or sets the cep.
        /// </summary>
        /// <value>The cep.</value>
        public string CEP { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the fone.
        /// </summary>
        /// <value>The fone.</value>
        public string Fone { get; set; }

        #endregion Propriedades
    }
}