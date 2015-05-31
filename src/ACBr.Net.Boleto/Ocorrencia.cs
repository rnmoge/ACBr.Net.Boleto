// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 03-27-2014
//
// Last Modified By : RFTD
// Last Modified On : 03-27-2014
// ***********************************************************************
// <copyright file="Ocorrencia.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using ACBr.Net.Boleto.Enums;

#region COM Interop Attributes

#if COM_INTEROP
using System.Runtime.InteropServices;
#endif


#endregion COM Interop Attributes

namespace ACBr.Net.Boleto
{
    #region COM Interop Attributes

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("FB7DFDEE-A03F-44B3-832F-E80EFDE915BC")]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes
    /// <summary>
    /// Class Ocorrencia. This class cannot be inherited.
    /// </summary>
    public sealed class Ocorrencia
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Ocorrencia"/> class.
        /// </summary>
        internal Ocorrencia()
        {

        }

        #endregion Constructor

        #region Propriedade

        /// <summary>
        /// Gets or sets the tipo.
        /// </summary>
        /// <value>The tipo.</value>
        public TipoOcorrencia Tipo { get; set; }
        /// <summary>
        /// Gets the descricao.
        /// </summary>
        /// <value>The descricao.</value>
        public string Descricao { get; private set; }
        /// <summary>
        /// Gets the codigo banco.
        /// </summary>
        /// <value>The codigo banco.</value>
        public string CodigoBanco { get; private set; }

        #endregion Propriedade
    }
}