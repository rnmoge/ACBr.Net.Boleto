// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 03-27-2014
//
// Last Modified By : RFTD
// Last Modified On : 04-28-2014
// ***********************************************************************
// <copyright file="Titulo.cs" company="ACBr.Net">
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
	[Guid("81373F85-F74F-441C-847F-80D11DBA3440")]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes
    /// <summary>
    /// Class Titulo. This class cannot be inherited.
    /// </summary>
    public sealed class Titulo
    {
        #region Fields

        /// <summary>
        /// The carteira
        /// </summary>
        public string carteira;
        /// <summary>
        /// The parcela
        /// </summary>
        public int parcela;
        /// <summary>
        /// The totalparcelas
        /// </summary>
        public int totalparcelas;
        /// <summary>
        /// The nossonumero
        /// </summary>
        public string nossonumero;
		/// <summary>
		/// The codigomora
		/// </summary>
		public char codigomora;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Titulo" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        internal Titulo(ACBrBoleto parent)
        {
            Parent = parent;
            OcorrenciaOriginal = new Ocorrencia();
            Aceite = AceiteTitulo.Nao;
            Mensagem = new List<string>();
            Sacado = new Sacado();
            parcela = 1;
            totalparcelas = 1;
            MotivoRejeicaoComando = new List<string>();
            DescricaoMotivoRejeicaoComando = new List<string>();
            EspecieDoc = "DM";
            LocalPagamento = string.Format("Pagar preferencialmente nas agencias do {0}", Parent.Banco.Nome);
            NumeroDocumento = string.Empty;
            SeuNumero = string.Empty;
            Vencimento = DateTime.Now;
            DataProcessamento = DateTime.Now;
            nossonumero = string.Empty;
            UsoBanco = string.Empty;
            carteira = string.Empty;
            CarteiraEnvio = CarteiraEnvio.Cedente;
            EspecieMod = string.Empty;            
            ValorDocumento = 0;
            ValorDespesaCobranca = 0;
            ValorAbatimento = 0;
            ValorDesconto = 0;
            ValorMoraJuros = 0;
            ValorIOF = 0;
            ValorOutrasDespesas = 0;
            ValorOutrosCreditos = 0;
            ValorRecebido = 0;
            ValorDescontoAntDia = 0;
            Referencia = string.Empty;
            Versao = string.Empty;
            codigomora = '2';
        }

        #endregion Constructor

        #region Propriedades

        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public ACBrBoleto Parent { get; private set; }
        /// <summary>
        /// Gets or sets the local pagamento.
        /// </summary>
        /// <value>The local pagamento.</value>
        public string LocalPagamento { get; set; }
        /// <summary>
        /// Gets or sets the vencimento.
        /// </summary>
        /// <value>The vencimento.</value>
        public DateTime Vencimento { get; set; }
        /// <summary>
        /// Gets or sets the data documento.
        /// </summary>
        /// <value>The data documento.</value>
        public DateTime DataDocumento { get; set; }
        /// <summary>
        /// Gets or sets the numero documento.
        /// </summary>
        /// <value>The numero documento.</value>
        public string NumeroDocumento { get; set; }
        /// <summary>
        /// Gets or sets the especie document.
        /// </summary>
        /// <value>The especie document.</value>
        public string EspecieDoc { get; set; }
        /// <summary>
        /// Gets or sets the aceite.
        /// </summary>
        /// <value>The aceite.</value>
        public AceiteTitulo Aceite { get; set; }
        /// <summary>
        /// Gets or sets the data processamento.
        /// </summary>
        /// <value>The data processamento.</value>
        public DateTime DataProcessamento { get; set; }
        /// <summary>
        /// Gets or sets the nosso numero.
        /// </summary>
        /// <value>The nosso numero.</value>
        /// <exception cref="ACBrException"></exception>
        public string NossoNumero 
        { 
            get
            {
                return nossonumero;
            }
            set
            {
                int tamanho;
                if (Parent.Banco.TamanhoMaximoNossoNum > 0)
                    tamanho = Parent.Banco.TamanhoMaximoNossoNum;
                else
                    tamanho = Parent.Banco.CalcularTamMaximoNossoNumero(Carteira, value);

                if (value.Trim().Length > tamanho)
                    throw new ACBrException(string.Format("Tamanho Máximo do Nosso Número é: {0}", tamanho));

                nossonumero = value.ZeroFill(tamanho);
            }
        }
        /// <summary>
        /// Gets or sets the uso banco.
        /// </summary>
        /// <value>The uso banco.</value>
        public string UsoBanco { get; set; }
        /// <summary>
        /// Gets or sets the carteira.
        /// </summary>
        /// <value>The carteira.</value>
        public string Carteira
        { 
            get
            {
                return carteira;
            }
            set
            {
                if (carteira == value)
                    return;

                var aCarteira = value.ToInt32();
                if (aCarteira < 1)
                    return;

                carteira = value.ZeroFill(Parent.Banco.TamanhoCarteira);
            }
        }
        /// <summary>
        /// Gets or sets the carteira envio.
        /// </summary>
        /// <value>The carteira envio.</value>
        public CarteiraEnvio CarteiraEnvio { get; set; }
        /// <summary>
        /// Gets or sets the especie mod.
        /// </summary>
        /// <value>The especie mod.</value>
        public string EspecieMod { get; set; }
        /// <summary>
        /// Gets or sets the valor documento.
        /// </summary>
        /// <value>The valor documento.</value>
        public decimal ValorDocumento
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            get;

            #region COM_INTEROP

#if COM_INTEROP
			[param: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            set;
        }
        /// <summary>
        /// Gets the mensagem.
        /// </summary>
        /// <value>The mensagem.</value>
        public List<string> Mensagem { get; private set; }
        /// <summary>
        /// Gets or sets the instrucao1.
        /// </summary>
        /// <value>The instrucao1.</value>
        public string Instrucao1 { get; set; }
        /// <summary>
        /// Gets or sets the instrucao2.
        /// </summary>
        /// <value>The instrucao2.</value>
        public string Instrucao2 { get; set; }
        /// <summary>
        /// Gets or sets the instrucao3.
        /// </summary>
        /// <value>The instrucao3.</value>
        public string Instrucao3 { get; set; }
        /// <summary>
        /// Gets the sacado.
        /// </summary>
        /// <value>The sacado.</value>
        public Sacado Sacado { get; private set; }
        /// <summary>
        /// Gets or sets the parcela.
        /// </summary>
        /// <value>The parcela.</value>
        /// <exception cref="ACBrException">Numero da Parcela Atual deve ser menor que o Total de Parcelas do Carnê</exception>
        public int Parcela
        { 
            get
            {
                return parcela;
            }
            set
            {
                if (value > TotalParcelas && Parent.BoletoPrinter != null && Parent.BoletoPrinter.Layout == LayoutBoleto.Carne)
                    throw new ACBrException("Numero da Parcela Atual deve ser menor que o Total de Parcelas do Carnê");

                parcela = value;
            }
        }
        /// <summary>
        /// Gets or sets the total parcelas.
        /// </summary>
        /// <value>The total parcelas.</value>
        /// <exception cref="ACBrException">Numero da Parcela Atual deve ser menor ou igual o Total de Parcelas do Carnê</exception>
        public int TotalParcelas
        { 
            get
            {
                return totalparcelas;
            }
            set
            {
                if (value < Parcela && Parent.BoletoPrinter != null && Parent.BoletoPrinter.Layout == LayoutBoleto.Carne)
                    throw new ACBrException("Numero da Parcela Atual deve ser menor ou igual o Total de Parcelas do Carnê");

                totalparcelas = value;
            }
        }
        /// <summary>
        /// Gets or sets the ocorrencia original.
        /// </summary>
        /// <value>The ocorrencia original.</value>
        public Ocorrencia OcorrenciaOriginal { get; set; }
        /// <summary>
        /// Gets the motivo rejeicao comando.
        /// </summary>
        /// <value>The motivo rejeicao comando.</value>
        public List<string> MotivoRejeicaoComando { get; private set; }
        /// <summary>
        /// Gets the descricao motivo rejeicao comando.
        /// </summary>
        /// <value>The descricao motivo rejeicao comando.</value>
        public List<string> DescricaoMotivoRejeicaoComando { get; private set; }
        /// <summary>
        /// Gets or sets the data ocorrencia.
        /// </summary>
        /// <value>The data ocorrencia.</value>
        public DateTime DataOcorrencia { get; set; }
        /// <summary>
        /// Gets or sets the data credito.
        /// </summary>
        /// <value>The data credito.</value>
        public DateTime DataCredito { get; set; }
        /// <summary>
        /// Gets or sets the data abatimento.
        /// </summary>
        /// <value>The data abatimento.</value>
        public DateTime DataAbatimento { get; set; }
        /// <summary>
        /// Gets or sets the data desconto.
        /// </summary>
        /// <value>The data desconto.</value>
        public DateTime? DataDesconto { get; set; }
        /// <summary>
        /// Gets or sets the data mora juros.
        /// </summary>
        /// <value>The data mora juros.</value>
        public DateTime? DataMoraJuros { get; set; }
        /// <summary>
        /// Gets or sets the data protesto.
        /// </summary>
        /// <value>The data protesto.</value>
        public DateTime? DataProtesto { get; set; }
        /// <summary>
        /// Gets or sets the data baixa.
        /// </summary>
        /// <value>The data baixa.</value>
        public DateTime DataBaixa { get; set; }
        /// <summary>
        /// Gets or sets the valor despesa cobranca.
        /// </summary>
        /// <value>The valor despesa cobranca.</value>
        public decimal ValorDespesaCobranca
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            get;

            #region COM_INTEROP

#if COM_INTEROP
			[param: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            set;
        }
        /// <summary>
        /// Gets or sets the valor abatimento.
        /// </summary>
        /// <value>The valor abatimento.</value>
        public decimal ValorAbatimento
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            get;

            #region COM_INTEROP

#if COM_INTEROP
			[param: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            set;
        }
        /// <summary>
        /// Gets or sets the valor desconto.
        /// </summary>
        /// <value>The valor desconto.</value>
        public decimal ValorDesconto
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            get;

            #region COM_INTEROP

#if COM_INTEROP
			[param: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            set;
        }
        /// <summary>
        /// Gets or sets the valor mora juros.
        /// </summary>
        /// <value>The valor mora juros.</value>
        public decimal ValorMoraJuros
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            get;

            #region COM_INTEROP

#if COM_INTEROP
			[param: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            set;
        }
        /// <summary>
        /// Gets or sets the valor iof.
        /// </summary>
        /// <value>The valor iof.</value>
        public decimal ValorIOF
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            get;

            #region COM_INTEROP

#if COM_INTEROP
			[param: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            set;
        }
        /// <summary>
        /// Gets or sets the valor outras despesas.
        /// </summary>
        /// <value>The valor outras despesas.</value>
        public decimal ValorOutrasDespesas
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            get;

            #region COM_INTEROP

#if COM_INTEROP
			[param: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            set;
        }
        /// <summary>
        /// Gets or sets the valor outros creditos.
        /// </summary>
        /// <value>The valor outros creditos.</value>
        public decimal ValorOutrosCreditos
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            get;

            #region COM_INTEROP

#if COM_INTEROP
			[param: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            set;
        }
        /// <summary>
        /// Gets or sets the valor recebido.
        /// </summary>
        /// <value>The valor recebido.</value>
        public decimal ValorRecebido
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            get;

            #region COM_INTEROP

#if COM_INTEROP
			[param: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            set;
        }
        /// <summary>
        /// Gets or sets the referencia.
        /// </summary>
        /// <value>The referencia.</value>
        public string Referencia { get; set; }
        /// <summary>
        /// Gets or sets the versao.
        /// </summary>
        /// <value>The versao.</value>
        public string Versao { get; set; }
        /// <summary>
        /// Gets or sets the seu numero.
        /// </summary>
        /// <value>The seu numero.</value>
        public string SeuNumero { get; set; }
        /// <summary>
        /// Gets or sets the percentual multa.
        /// </summary>
        /// <value>The percentual multa.</value>
        public decimal PercentualMulta
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            get;

            #region COM_INTEROP

#if COM_INTEROP
			[param: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            set;
        }
        /// <summary>
        /// Gets or sets the valor desconto ant dia.
        /// </summary>
        /// <value>The valor desconto ant dia.</value>
        public decimal ValorDescontoAntDia
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            get;

            #region COM_INTEROP

#if COM_INTEROP
			[param: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            set;
        }
        /// <summary>
        /// Gets or sets the texto livre.
        /// </summary>
        /// <value>The texto livre.</value>
        public string TextoLivre { get; set; }
        /// <summary>
        /// Gets or sets the codigo mora.
        /// </summary>
        /// <value>The codigo mora.</value>
        public char CodigoMora 
		{
			get
			{
				return codigomora;
			}
			set
			{
				if (value == codigomora)
					return;

				if(!Parent.Banco.CodigosMoraAceitos.Contains(value))
					throw new ACBrException("Código de Mora/Juros informado não é permitido para este banco!");

				codigomora = value;
			}
		}
        /// <summary>
        /// Gets or sets the tipo dias protesto.
        /// </summary>
        /// <value>The tipo dias protesto.</value>
        public TipoDiasIntrucao TipoDiasProtesto { get; set; }
        /// <summary>
        /// Gets or sets the tipo impressao.
        /// </summary>
        /// <value>The tipo impressao.</value>
        public TipoImpressao TipoImpressao { get; set; }
        /// <summary>
        /// Gets the linha digitada.
        /// </summary>
        /// <value>The linha digitada.</value>
        public string LinhaDigitada { get; internal set; }

        #endregion Propriedades
    }
}