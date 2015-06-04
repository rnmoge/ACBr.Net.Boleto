// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 04-06-2014
//
// Last Modified By : RFTD
// Last Modified On : 04-22-2014
// ***********************************************************************
// <copyright file="Banco.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.ComponentModel;
using ACBr.Net.Boleto.Enums;
using ACBr.Net.Boleto.Interfaces;
using ACBr.Net.Core;

#region COM Interop Attributes

#if COM_INTEROP
using System.Runtime.InteropServices;
#endif


#endregion COM Interop Attributes

namespace ACBr.Net.Boleto.Bancos
{
    #region COM Interop Attributes

#if COM_INTEROP

	[ComVisible(true)]
    [Guid("0AE2C4C9-AC2A-4C4D-A9F0-2F796D0AE0CA")]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes
    /// <summary>
    /// Class Banco. This class cannot be inherited.
    /// </summary>
    [TypeConverter(typeof(ACBrExpandableObjectConverter))]
    public sealed class Banco
    {
        #region Fields

        /// <summary>
        /// The cobranca
        /// </summary>
        private TipoCobranca cobranca;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Banco"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        internal Banco(ACBrBoleto parent)
        {
            Parent = parent;
            TipoCobranca = TipoCobranca.Nenhum;
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
        /// Gets the banco class.
        /// </summary>
        /// <value>The banco class.</value>
        [Browsable(false)]
        public IBanco BancoClass { get; private set; }

        /// <summary>
        /// Gets the nome.
        /// </summary>
        /// <value>The nome.</value>
        public string Nome
        {
            get {
	            return BancoClass == null ? "Nenhum" : BancoClass.Nome;
            }
        }

        /// <summary>
        /// Gets the tamanho agencia.
        /// </summary>
        /// <value>The tamanho agencia.</value>
        [Browsable(false)]
        public int TamanhoAgencia 
        { 
            get {
	            return BancoClass == null ? 0 : BancoClass.TamanhoAgencia;
            }
        }

        /// <summary>
        /// Gets the tamanho conta.
        /// </summary>
        /// <value>The tamanho conta.</value>
        [Browsable(false)]
        public int TamanhoConta
        {
            get {
	            return BancoClass == null ? 0 : BancoClass.TamanhoConta;
            }
        }

        /// <summary>
        /// Gets the tamanho carteira.
        /// </summary>
        /// <value>The tamanho carteira.</value>
        [Browsable(false)]
        public int TamanhoCarteira
        {
            get {
	            return BancoClass == null ? 0 : BancoClass.TamanhoCarteira;
            }
        }

        /// <summary>
        /// Gets the numero.
        /// </summary>
        /// <value>The numero.</value>
        [Browsable(false)]
        public int Numero
        { 
            get {
	            return BancoClass == null ? 0 : BancoClass.Numero;
            }
        }

        /// <summary>
        /// Gets the digito.
        /// </summary>
        /// <value>The digito.</value>
        [Browsable(false)]
        public int Digito
        {
            get {
	            return BancoClass == null ? 0 : BancoClass.Digito;
            }
        }

        /// <summary>
        /// Gets the tamanho maximo nosso number.
        /// </summary>
        /// <value>The tamanho maximo nosso number.</value>
        [Browsable(false)]
        public int TamanhoMaximoNossoNum
        {
            get {
	            return BancoClass == null ? 0 : BancoClass.TamanhoMaximoNossoNum;
            }
        }

        /// <summary>
        /// Gets or sets the tipo cobranca.
        /// </summary>
        /// <value>The tipo cobranca.</value>
        public TipoCobranca TipoCobranca 
        { 
            get
            {
                return cobranca;
            }
            set
            {
                if (cobranca == value)
                    return;

                BancoClass = null;
                switch(value)
                {
                    case TipoCobranca.Banrisul:
                        BancoClass = new BancoBanrisul(this);
                        break;

                    case TipoCobranca.Bradesco:
                        BancoClass = new BancoBradesco(this);
                        break;

                    case TipoCobranca.BancoDoBrasil:
                        BancoClass = new BancoDoBrasil(this);
                        break;

                    case TipoCobranca.Itau:
                        BancoClass = new BancoItau(this);
                        break;

					case TipoCobranca.HSBC:
						BancoClass = new BancoHSBC(this);
						break;
						
					case TipoCobranca.Sicred:
						BancoClass = new BancoSicredi(this);
						break;

                    default:
                        BancoClass = new BancoBase(this);
                        break;
                }

                cobranca = value;
            }
        }

        /// <summary>
        /// Gets the orientacoes banco.
        /// </summary>
        /// <value>The orientacoes banco.</value>
        public string[] OrientacoesBanco
        {
            get
            {
	            if (BancoClass == null)
                    return null;
	            return BancoClass.OrientacoesBanco.ToArray();
            }
        }

		/// <summary>
		/// Gets the codigos mora aceitos.
		/// </summary>
		/// <value>The codigos mora aceitos.</value>
		public string CodigosMoraAceitos
		{
			get {
				return BancoClass == null ? string.Empty : BancoClass.CodigosMoraAceitos;
			}
		}

		/// <summary>
		/// Gets the codigos geracao aceitos.
		/// </summary>
		/// <value>The codigos geracao aceitos.</value>
		public string CodigosGeracaoAceitos
		{
			get
			{
				return BancoClass == null ? string.Empty : BancoClass.CodigosGeracaoAceitos;
			}
		}

        #endregion Propriedades

        #region Methods

        /// <summary>
        /// Tipoes the ocorrencia to descricao.
        /// </summary>
        /// <param name="Tipo">The tipo.</param>
        /// <returns>System.String.</returns>
         public string TipoOcorrenciaToDescricao(TipoOcorrencia Tipo)
         {
             return BancoClass.TipoOcorrenciaToDescricao(Tipo);
         }

         /// <summary>
         /// Cods the ocorrencia to tipo.
         /// </summary>
         /// <param name="CodOcorrencia">The cod ocorrencia.</param>
         /// <returns>TipoOcorrencia.</returns>
        public TipoOcorrencia CodOcorrenciaToTipo(int CodOcorrencia)
        {
            return BancoClass.CodOcorrenciaToTipo(CodOcorrencia);
        }

        /// <summary>
        /// Tipoes the o correncia to cod.
        /// </summary>
        /// <param name="Tipo">The tipo.</param>
        /// <returns>System.String.</returns>
        public string TipoOCorrenciaToCod(TipoOcorrencia Tipo)
        {
            if (BancoClass == null)
                return string.Empty;

            return BancoClass.TipoOCorrenciaToCod(Tipo);
        }

        /// <summary>
        /// Cods the motivo rejeicao to descricao.
        /// </summary>
        /// <param name="Tipo">The tipo.</param>
        /// <param name="CodMotivo">The cod motivo.</param>
        /// <returns>System.String.</returns>
        public string CodMotivoRejeicaoToDescricao(TipoOcorrencia Tipo, int CodMotivo)
        {
            return BancoClass.CodMotivoRejeicaoToDescricao(Tipo, CodMotivo);
        }

        /// <summary>
        /// Calculars the digito verificador.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public string CalcularDigitoVerificador(Titulo Titulo)
        {
            return BancoClass.CalcularDigitoVerificador(Titulo);
        }

        /// <summary>
        /// Calculars the tam maximo nosso numero.
        /// </summary>
        /// <param name="Carteira">The carteira.</param>
        /// <param name="NossoNumero">The nosso numero.</param>
        /// <returns>System.Int32.</returns>
        public int CalcularTamMaximoNossoNumero(string Carteira, string NossoNumero = "")
        {
            return BancoClass.CalcularTamMaximoNossoNumero(Carteira, NossoNumero);
        }

        /// <summary>
        /// Montars the campo codigo cedente.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public string MontarCampoCodigoCedente(Titulo Titulo)
        {
            return BancoClass.MontarCampoCodigoCedente(Titulo);
        }

        /// <summary>
        /// Montars the campo nosso numero.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public string MontarCampoNossoNumero(Titulo Titulo)
        {
            return BancoClass.MontarCampoNossoNumero(Titulo);
        }

        /// <summary>
        /// Montars the codigo barras.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public string MontarCodigoBarras(Titulo Titulo)
        {
            return BancoClass.MontarCodigoBarras(Titulo);
        }

        /// <summary>
        /// Montars the linha digitavel.
        /// </summary>
        /// <param name="CodigoBarras">The codigo barras.</param>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public string MontarLinhaDigitavel(string CodigoBarras, Titulo Titulo)
        {
            return BancoClass.MontarLinhaDigitavel(CodigoBarras, Titulo);
        }

        /// <summary>
        /// Gerars the registro header400.
        /// </summary>
        /// <param name="NumeroRemessa">The numero remessa.</param>
        /// <param name="ARemessa">A remessa.</param>
        public void GerarRegistroHeader400(int NumeroRemessa, List<string> ARemessa)
        {
            BancoClass.GerarRegistroHeader400(NumeroRemessa, ARemessa);
        }

        /// <summary>
        /// Gerars the registro header240.
        /// </summary>
        /// <param name="NumeroRemessa">The numero remessa.</param>
        /// <returns>System.String.</returns>
        public string GerarRegistroHeader240(int NumeroRemessa)
        {
            return BancoClass.GerarRegistroHeader240(NumeroRemessa);
        }

		/// <summary>
		/// Gerars the registro headerDBT627.
		/// </summary>
		/// <param name="NumeroRemessa">The numero remessa.</param>
		/// <returns>System.String.</returns>
		public string GerarRegistroHeaderDBT627(int NumeroRemessa)
		{
			return BancoClass.GerarRegistroHeaderDBT627(NumeroRemessa);
		}

        /// <summary>
        /// Gerars the registro transacao400.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <param name="ARemessa">A remessa.</param>
        public void GerarRegistroTransacao400(Titulo Titulo, List<string> ARemessa)
        {
            BancoClass.GerarRegistroTransacao400(Titulo, ARemessa);
        }

        /// <summary>
        /// Gerars the registro transacao240.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public string GerarRegistroTransacao240(Titulo Titulo)
        {
            return BancoClass.GerarRegistroTransacao240(Titulo);
        }
		
		/// <summary>
        /// Gerars the registro transacao240.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
		public string GerarRegistroTransacaoDBT627(Titulo Titulo)
        {
			return BancoClass.GerarRegistroTransacaoDBT627(Titulo);
        }

        /// <summary>
        /// Gerars the registro trailler400.
        /// </summary>
        /// <param name="ARemessa">A remessa.</param>
        public void GerarRegistroTrailler400(List<string> ARemessa)
        {
            BancoClass.GerarRegistroTrailler400(ARemessa);
        }

        /// <summary>
        /// Gerars the registro trailler240.
        /// </summary>
        /// <param name="ARemessa">A remessa.</param>
        /// <returns>System.String.</returns>
        public string GerarRegistroTrailler240(List<string> ARemessa)
        {
            return BancoClass.GerarRegistroTrailler240(ARemessa);
        }
		
		/// <summary>
        /// Gerars the registro trailler240.
        /// </summary>
        /// <param name="ARemessa">A remessa.</param>
        /// <returns>System.String.</returns>
		public string GerarRegistroTraillerDBT627(List<string> ARemessa)
        {
			return BancoClass.GerarRegistroTraillerDBT627(ARemessa);
        }

        /// <summary>
        /// Lers the retorno400.
        /// </summary>
        /// <param name="ARetorno">A retorno.</param>
        public void LerRetorno400(List<string> ARetorno)
        {
            BancoClass.LerRetorno400(ARetorno);
        }

        /// <summary>
        /// Lers the retorno240.
        /// </summary>
        /// <param name="ARetorno">A retorno.</param>
        public void LerRetorno240(List<string> ARetorno)
        {
            BancoClass.LerRetorno240(ARetorno);
        }
		
		/// <summary>
        /// Lers the retorno240.
        /// </summary>
        /// <param name="ARetorno">A retorno.</param>
		public void LerRetornoDBT627(List<string> ARetorno)
        {
			BancoClass.LerRetornoDBT627(ARetorno);
        }
        /// <summary>
        /// Calculars the nome arquivo remessa.
        /// </summary>
        /// <returns>System.String.</returns>
        public string CalcularNomeArquivoRemessa()
        {
            return BancoClass.CalcularNomeArquivoRemessa();
        }

        #endregion Methods
    }
}