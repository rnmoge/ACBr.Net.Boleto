// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 04-06-2014
//
// Last Modified By : RFTD
// Last Modified On : 04-22-2014
// ***********************************************************************
// <copyright file="Cedente.cs" company="ACBr.Net">
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
    [Guid("06611F80-D938-4D30-A51F-2F6C44E99CC8")]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes
    /// <summary>
    /// Class Cedente. This class cannot be inherited.
    /// </summary>
    [TypeConverter(typeof(ACBrExpandableObjectConverter))]
    public sealed class Cedente
    {
        #region Fields

        /// <summary>
        /// The CPFCNPJ
        /// </summary>
        private string cpfcnpj;
        /// <summary>
        /// The conta
        /// </summary>
        private string conta;
        /// <summary>
        /// The agencia
        /// </summary>
        private string agencia;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Cedente"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        internal Cedente(ACBrBoleto parent)
        {
            this.Parent = parent;
            TipoDocumento = TipoDocumento.Tradicional;
            ResponEmissao = ResponEmissao.CliEmite;
            CaracTitulo = CaracTitulo.Simples;
            TipoInscricao = PessoaCedente.Fisica;
            Nome = string.Empty;
            CodigoCedente = string.Empty;
            CodigoTransmissao = string.Empty;
            agencia = string.Empty;
            AgenciaDigito = string.Empty;
            conta = string.Empty;
            ContaDigito = string.Empty;
            Modalidade = string.Empty;
            Convenio = string.Empty;
            cpfcnpj = string.Empty;
            Logradouro = string.Empty;
            NumeroRes = string.Empty;
            Complemento = string.Empty;
            Bairro = string.Empty;
            Cidade = string.Empty;
            UF = string.Empty;
            CEP = string.Empty;
            Telefone = string.Empty;
        }

        #endregion Constructor

        #region Propriedades

        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <value>The parent.</value>
        [Browsable(false)]
        public ACBrBoleto Parent { get; private set; }

        /// <summary>
        /// Gets or sets the nome.
        /// </summary>
        /// <value>The nome.</value>
        public string Nome { get; set; }

        /// <summary>
        /// Gets or sets the codigo cedente.
        /// </summary>
        /// <value>The codigo cedente.</value>
        public string CodigoCedente { get; set; }

        /// <summary>
        /// Gets or sets the codigo transmissao.
        /// </summary>
        /// <value>The codigo transmissao.</value>
        public string CodigoTransmissao { get; set; }

        /// <summary>
        /// Gets or sets the agencia.
        /// </summary>
        /// <value>The agencia.</value>
        public string Agencia
        {
            get
            {
                return agencia;
            }
            set
            {
                if (agencia == value || agencia.ToInt32() == 0)
                    return;

                agencia = value.ZeroFill(Parent.Banco.TamanhoAgencia);
            }
        }

        /// <summary>
        /// Gets or sets the agencia digito.
        /// </summary>
        /// <value>The agencia digito.</value>
        public string AgenciaDigito { get; set; }

        /// <summary>
        /// Gets or sets the conta.
        /// </summary>
        /// <value>The conta.</value>
        public string Conta 
        { 
            get
            {
                return conta;
            }
            set
            {
                if (conta == value || conta.ToInt32() == 0) 
                    return;

                conta = value.ZeroFill(Parent.Banco.TamanhoConta);
            }
        }

        /// <summary>
        /// Gets or sets the conta digito.
        /// </summary>
        /// <value>The conta digito.</value>
        public string ContaDigito { get; set; }

        /// <summary>
        /// Gets or sets the modalidade.
        /// </summary>
        /// <value>The modalidade.</value>
        public string Modalidade { get; set; }

        /// <summary>
        /// Gets or sets the convenio.
        /// </summary>
        /// <value>The convenio.</value>
        public string Convenio { get; set; }

        /// <summary>
        /// Gets or sets the tipo documento.
        /// </summary>
        /// <value>The tipo documento.</value>
        public TipoDocumento TipoDocumento { get; set; }

        /// <summary>
        /// Gets or sets the respon emissao.
        /// </summary>
        /// <value>The respon emissao.</value>
        public ResponEmissao ResponEmissao { get; set; }

        /// <summary>
        /// Gets or sets the carac titulo.
        /// </summary>
        /// <value>The carac titulo.</value>
        public CaracTitulo CaracTitulo { get; set; }

        /// <summary>
        /// Gets or sets the CNPJCPF.
        /// </summary>
        /// <value>The CNPJCPF.</value>
        /// <exception cref="ACBrException">@CPF\CNPJ Invalido</exception>
        public string CNPJCPF 
        { 
            get
            {
                return cpfcnpj;
            }
            set
            {
                if(!string.IsNullOrEmpty(value.Trim()) && !value.IsCPFOrCNPJ())
                    throw new ACBrException(@"CPF\CNPJ Invalido");

                cpfcnpj = value;
            }
        }

        /// <summary>
        /// Gets or sets the tipo inscricao.
        /// </summary>
        /// <value>The tipo inscricao.</value>
        public PessoaCedente TipoInscricao  { get; set; }

        /// <summary>
        /// Gets or sets the logradouro.
        /// </summary>
        /// <value>The logradouro.</value>
        public string Logradouro { get; set; }

        /// <summary>
        /// Gets or sets the numero resource.
        /// </summary>
        /// <value>The numero resource.</value>
        public string NumeroRes { get; set; }

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
        /// Gets or sets the telefone.
        /// </summary>
        /// <value>The telefone.</value>
        public string Telefone { get; set; }

        #endregion Propriedades
    }
}
