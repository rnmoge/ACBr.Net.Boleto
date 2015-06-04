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

using System.ComponentModel;
using ACBr.Net.Core;
using ACBr.Net.Core.Generics;

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
        readonly ACBrBoleto parent;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TituloCollection"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        internal TituloCollection(ACBrBoleto parent)
        {
            this.parent = parent;
        }

        #endregion Constructor

        #region Funções

        /// <summary>
        /// Adds the new.
        /// </summary>
        /// <returns>Titulo.</returns>
        public Titulo AddNew()
        {
            var t = new Titulo(parent);
            List.Add(t);
            return t;
        }

        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.Int32.</returns>
        public int IndexOf(Titulo titulo)
        {
            return List.IndexOf(titulo);
        }

        #endregion Funções
    }
}
