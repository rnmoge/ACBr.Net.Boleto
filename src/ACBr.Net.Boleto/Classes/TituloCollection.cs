// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 03-27-2014
//
// Last Modified By : RFTD
// Last Modified On : 04-23-2014
// ***********************************************************************
// <copyright file="TituloCollection.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.ComponentModel;
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
	[Guid("5E481317-09B3-460E-A75A-02E5887DAB2B")]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes
    /// <summary>
    /// Class TituloCollection. This class cannot be inherited.
    /// </summary>
    [TypeConverter(typeof(ACBrExpandableObjectConverter))]
    public sealed class TituloCollection : GenericCollection<Titulo>
    {
        #region Fields

        /// <summary>
        /// The parent
        /// </summary>
        ACBrBoleto Parent;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TituloCollection"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        internal TituloCollection(ACBrBoleto parent)
        {
            Parent = parent;
        }

        #endregion Constructor

        #region Funções

        /// <summary>
        /// Adds the new.
        /// </summary>
        /// <returns>Titulo.</returns>
        public Titulo AddNew()
        {
            var t = new Titulo(Parent);
            list.Add(t);
            return t;
        }

        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.Int32.</returns>
        public int IndexOf(Titulo titulo)
        {
            return list.IndexOf(titulo);
        }

        #endregion Funções
    }
}
