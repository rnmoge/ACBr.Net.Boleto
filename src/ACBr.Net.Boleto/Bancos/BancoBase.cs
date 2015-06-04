// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 04-21-2014
//
// Last Modified By : RFTD
// Last Modified On : 05-30-2014
// ***********************************************************************
// <copyright file="BancoBase.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ACBr.Net.Boleto.Enums;
using ACBr.Net.Boleto.Interfaces;
using ACBr.Net.Boleto.Utils;
using ACBr.Net.Core;
using ACBr.Net.Core.Enum;
using ACBr.Net.Core.Extensions;

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
	[Guid("0FD37A79-35F6-4F06-B1CF-FE8710717C10")]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes
	/// <summary>
	/// Class BancoBase.
	/// </summary>
    public class BancoBase : IBanco
    {
        #region Fields
        #endregion Fields

        #region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="BancoBase" /> class.
		/// </summary>
		/// <param name="parent">The parent.</param>
        internal BancoBase(Banco parent)
        {
            Banco = parent;
            Modulo = new CalcDigito();
            TipoCobranca = TipoCobranca.Nenhum;
            OrientacoesBanco = new List<string>();
            Nome = "Nenhum";
            TamanhoAgencia = 0;
            TamanhoCarteira = 0;
            TamanhoConta = 0;
            TamanhoMaximoNossoNum = 0;
			CodigosMoraAceitos = "12";
			CodigosGeracaoAceitos = "0123456789";
        }

        #endregion Constructor

        #region Propriedades

		/// <summary>
		/// Gets or sets the banco.
		/// </summary>
		/// <value>The banco.</value>
        public Banco Banco { get; protected set; }
		/// <summary>
		/// Gets or sets the modulo.
		/// </summary>
		/// <value>The modulo.</value>
        public CalcDigito Modulo { get; protected set; }
		/// <summary>
		/// Gets or sets the nome.
		/// </summary>
		/// <value>The nome.</value>
        public string Nome { get; protected set; }
		/// <summary>
		/// Gets or sets the tamanho agencia.
		/// </summary>
		/// <value>The tamanho agencia.</value>
        public int TamanhoAgencia { get; protected set; }
		/// <summary>
		/// Gets or sets the tamanho conta.
		/// </summary>
		/// <value>The tamanho conta.</value>
        public int TamanhoConta { get; protected set; }
		/// <summary>
		/// Gets or sets the tamanho carteira.
		/// </summary>
		/// <value>The tamanho carteira.</value>
        public int TamanhoCarteira { get; protected set; }
		/// <summary>
		/// Gets or sets the numero.
		/// </summary>
		/// <value>The numero.</value>
        public int Numero { get; protected set; }
		/// <summary>
		/// Gets or sets the digito.
		/// </summary>
		/// <value>The digito.</value>
        public int Digito { get; protected set; }
		/// <summary>
		/// Gets or sets the tamanho maximo nosso number.
		/// </summary>
		/// <value>The tamanho maximo nosso number.</value>
        public int TamanhoMaximoNossoNum { get; protected set; }
		/// <summary>
		/// Gets or sets the tipo cobranca.
		/// </summary>
		/// <value>The tipo cobranca.</value>
        public TipoCobranca TipoCobranca { get; protected set; }
		/// <summary>
		/// Gets or sets the orientacoes banco.
		/// </summary>
		/// <value>The orientacoes banco.</value>
        public List<string> OrientacoesBanco { get; protected set; }
		/// <summary>
		/// Gets the codigos mora aceitos.
		/// </summary>
		/// <value>The codigos mora aceitos.</value>
		public string CodigosMoraAceitos { get; protected set; }
		/// <summary>
		/// Gets the codigos mora aceitos.
		/// </summary>
		/// <value>The codigos mora aceitos.</value>
		public string CodigosGeracaoAceitos { get; protected set; }

        #endregion Propriedades

        #region Methods

		/// <summary>
		/// Tipoes the ocorrencia to descricao.
		/// </summary>
		/// <param name="tipo">The tipo.</param>
		/// <returns>System.String.</returns>
        public virtual string TipoOcorrenciaToDescricao(TipoOcorrencia tipo)
        {
            return string.Empty;
        }

		/// <summary>
		/// Cods the ocorrencia to tipo.
		/// </summary>
		/// <param name="codOcorrencia">The cod ocorrencia.</param>
		/// <returns>TipoOcorrencia.</returns>
        public virtual TipoOcorrencia CodOcorrenciaToTipo(int codOcorrencia)
        {
            return TipoOcorrencia.RemessaRegistrar;
        }

		/// <summary>
		/// Tipoes the o correncia to cod.
		/// </summary>
		/// <param name="tipo">The tipo.</param>
		/// <returns>System.String.</returns>
        public virtual string TipoOCorrenciaToCod(TipoOcorrencia tipo)
        {
            return string.Empty;
        }

		/// <summary>
		/// Cods the motivo rejeicao to descricao.
		/// </summary>
		/// <param name="tipo">The tipo.</param>
		/// <param name="codMotivo">The cod motivo.</param>
		/// <returns>System.String.</returns>
        public virtual string CodMotivoRejeicaoToDescricao(TipoOcorrencia tipo, int codMotivo)
        {
            return string.Empty;
        }

		/// <summary>
		/// Calculars the digito verificador.
		/// </summary>
		/// <param name="titulo">The titulo.</param>
		/// <returns>System.String.</returns>
        public virtual string CalcularDigitoVerificador(Titulo titulo)
        {
            return string.Empty;
        }

		/// <summary>
		/// Calculars the tam maximo nosso numero.
		/// </summary>
		/// <param name="carteira">The carteira.</param>
		/// <param name="nossoNumero">The nosso numero.</param>
		/// <returns>System.Int32.</returns>
        public virtual int CalcularTamMaximoNossoNumero(string carteira, string nossoNumero = "")
        {
            return Banco.TamanhoMaximoNossoNum;
        }

		/// <summary>
		/// Montars the campo codigo cedente.
		/// </summary>
		/// <param name="titulo">The titulo.</param>
		/// <returns>System.String.</returns>
        public virtual string MontarCampoCodigoCedente(Titulo titulo)
        {
            return string.Empty;
        }

		/// <summary>
		/// Montars the campo nosso numero.
		/// </summary>
		/// <param name="titulo">The titulo.</param>
		/// <returns>System.String.</returns>
        public virtual string MontarCampoNossoNumero(Titulo titulo)
        {
            return titulo.NossoNumero;
        }

		/// <summary>
		/// Montars the codigo barras.
		/// </summary>
		/// <param name="titulo">The titulo.</param>
		/// <returns>System.String.</returns>
        public virtual string MontarCodigoBarras(Titulo titulo)
        {
            return string.Empty;
        }

		/// <summary>
		/// Montars the linha digitavel.
		/// </summary>
		/// <param name="codigoBarras">The codigo barras.</param>
		/// <param name="titulo">The titulo.</param>
		/// <returns>System.String.</returns>
        public virtual string MontarLinhaDigitavel(string codigoBarras, Titulo titulo)
        {
            Modulo.FormulaDigito = CalcDigFormula.Modulo10;
            Modulo.MultiplicadorInicial = 1;
            Modulo.MultiplicadorFinal = 2;
            Modulo.MultiplicadorAtual = 2;
            
            //Campo 1(Código Banco,Tipo de Moeda,5 primeiro digitos do Campo Livre)
            Modulo.Documento = string.Format("{0}9{1}", codigoBarras.Substring(0,3), codigoBarras.Substring(19,5));
            Modulo.Calcular();
            
            var campo1 = string.Format("{0}.{1}{2}", Modulo.Documento.Substring(0, 5), Modulo.Documento.Substring(5, 4), Modulo.DigitoFinal);
            
            //Campo 2(6ª a 15ª posições do campo Livre)
            Modulo.Documento = codigoBarras.Substring( 24, 10);
            Modulo.Calcular();
            
            var campo2 = string.Format("{0}.{1}{2}", Modulo.Documento.Substring(0, 5), Modulo.Documento.Substring( 5, 5), Modulo.DigitoFinal);
            
            //Campo 3 (16ª a 25ª posições do campo Livre)
            Modulo.Documento = codigoBarras.Substring( 34, 10);
            Modulo.Calcular();

            var campo3 = string.Format("{0}.{1}{2}", Modulo.Documento.Substring(0, 5), Modulo.Documento.Substring( 5, 5), Modulo.DigitoFinal);
            
            //Campo 4 (Digito Verificador Nosso Numero)
            var campo4 = codigoBarras.Substring( 4, 1);
            
            //Campo 5 (Fator de Vencimento e Valor do Documento)
            var campo5 = codigoBarras.Substring( 5, 14);

           return string.Format("{0} {1} {2} {3} {4}",  campo1, campo2, campo3, campo4, campo5);
        }

		/// <summary>
		/// Gerars the registro header400.
		/// </summary>
		/// <param name="numeroRemessa">The numero remessa.</param>
		/// <param name="aRemessa">A remessa.</param>
		/// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public virtual void GerarRegistroHeader400(int numeroRemessa, List<string> aRemessa)
        {
            throw new NotImplementedException("Esta função não esta implementada para este banco");
        }

		/// <summary>
		/// Gerars the registro header240.
		/// </summary>
		/// <param name="numeroRemessa">The numero remessa.</param>
		/// <returns>System.String.</returns>
		/// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public virtual string GerarRegistroHeader240(int numeroRemessa)
        {
            throw new NotImplementedException("Esta função não esta implementada para este banco");
        }

		/// <summary>
		/// Gerars the registro transacao400.
		/// </summary>
		/// <param name="titulo">The titulo.</param>
		/// <param name="aRemessa">A remessa.</param>
        public virtual void GerarRegistroTransacao400(Titulo titulo, List<string> aRemessa)
        {
			throw new NotImplementedException("Esta função não esta implementada para este banco");
        }

		/// <summary>
		/// Gerars the registro transacao240.
		/// </summary>
		/// <param name="titulo">The titulo.</param>
		/// <returns>System.String.</returns>
        public virtual string GerarRegistroTransacao240(Titulo titulo)
        {
			throw new NotImplementedException("Esta função não esta implementada para este banco");
        }

		/// <summary>
		/// Gerars the registro trailler400.
		/// </summary>
		/// <param name="aRemessa">A remessa.</param>
        public virtual void GerarRegistroTrailler400(List<string> aRemessa)
        {
			throw new NotImplementedException("Esta função não esta implementada para este banco");
        }

		/// <summary>
		/// Gerars the registro trailler240.
		/// </summary>
		/// <param name="aRemessa">A remessa.</param>
		/// <returns>System.String.</returns>
        public virtual string GerarRegistroTrailler240(List<string> aRemessa)
        {
			throw new NotImplementedException("Esta função não esta implementada para este banco");
        }

		/// <summary>
		/// Lers the retorno400.
		/// </summary>
		/// <param name="aRetorno">A retorno.</param>
		/// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public virtual void LerRetorno400(List<string> aRetorno)
        {
            throw new NotImplementedException("Esta função não esta implementada para este banco");
        }

		/// <summary>
		/// Lers the retorno240.
		/// </summary>
		/// <param name="aRetorno">A retorno.</param>
		/// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public virtual void LerRetorno240(List<string> aRetorno)
        {
            throw new NotImplementedException("Esta função não esta implementada para este banco");
        }

		/// <summary>
		/// Calculars the nome arquivo remessa.
		/// </summary>
		/// <returns>System.String.</returns>
        public virtual string CalcularNomeArquivoRemessa()
        {
            var sequencia = 0;

			if (!string.IsNullOrEmpty(Banco.Parent.NomeArqRemessa))
				return string.Format(@"{0}\{1}", Banco.Parent.DirArqRemessa, Banco.Parent.NomeArqRemessa);

			var nomeFixo = string.Format(@"{0}\cb{1:ddMM}", Banco.Parent.DirArqRemessa, DateTime.Now);
			string nomeArq;
			do
			{
				sequencia++;
				nomeArq = string.Format("{0}{1:00}.rem", nomeFixo, sequencia);
			}
			while(File.Exists(nomeArq));
			return nomeArq;
        }

		/// <summary>
		/// Calculars the digito codigo barras.
		/// </summary>
		/// <param name="codigoBarras">The codigo barras.</param>
		/// <returns>System.String.</returns>
        protected virtual string CalcularDigitoCodigoBarras(string codigoBarras)
        {
            Modulo.CalculoPadrao();
            Modulo.Documento = codigoBarras;
            Modulo.Calcular();

            if (Modulo.DigitoFinal == 0 || Modulo.DigitoFinal > 9)
                return "1";
			
			return Modulo.DigitoFinal.ToString();
        }

		/// <summary>
		/// Gerars the registro headerDBT627.
		/// </summary>
		/// <param name="numeroRemessa">The numero remessa.</param>
		/// <returns>System.String.</returns>
		public virtual string GerarRegistroHeaderDBT627(int numeroRemessa)
		{
			var retorno = new StringBuilder();
			retorno.Append("A1");
			retorno.Append(Banco.Parent.Cedente.Convenio.FillLeft(20));
            retorno.Append(Banco.Parent.Cedente.Nome.RemoveCe().FillLeft(20));
			retorno.AppendFormat("{0:000}", Numero);
			retorno.Append(Nome.RemoveCe().FillRight(20));
			retorno.AppendFormat("{0:yyyyMMdd}", DateTime.Now);
			retorno.AppendFormat("{0:000000}", numeroRemessa);
			retorno.Append("05DEBITO AUTOMATICO");
			retorno.Append("".FillRight(52));

			return retorno.ToString().ToUpper();
		}

		/// <summary>
		/// Gerars the registro transacaoDBT627.
		/// </summary>
		/// <param name="titulo">The titulo.</param>
		/// <returns>System.String.</returns>
		public virtual string GerarRegistroTransacaoDBT627(Titulo titulo)
		{
			var retorno = new StringBuilder();
			retorno.Append("E");
			retorno.Append(titulo.NumeroDocumento.Trim().FillLeft(25));
			retorno.Append(titulo.Sacado.Agencia.Trim().ZeroFill(4));
			retorno.Append(titulo.Sacado.Conta.Trim().ZeroFill(14));
			retorno.Append(titulo.Vencimento.ToString("yyyyMMdd"));
			retorno.Append(titulo.ValorDocumento.ToDecimalString(15));
			retorno.Append("03");
			retorno.Append(titulo.Sacado.NomeSacado.RemoveCe().FillLeft(60));
			retorno.Append(titulo.Sacado.CNPJCPF.IsCNPJ() ? "1" : "2");
			retorno.Append(titulo.Sacado.CNPJCPF.OnlyNumbers().ZeroFill(15));
			retorno.Append("".FillRight(4));
			retorno.Append("0");

			return retorno.ToString().ToUpper();
		}

		/// <summary>
		/// Gerars the registro traillerDBT627.
		/// </summary>
		/// <param name="aRemessa">A remessa.</param>
		/// <returns>System.String.</returns>
		public virtual string GerarRegistroTraillerDBT627(List<string> aRemessa)
		{
			var valortotal = Banco.Parent.ListadeBoletos.Sum(titulo => titulo.ValorDocumento);
			var retorno = new StringBuilder();            
			retorno.AppendFormat("Z{0:000000}", aRemessa.Count + 1);
			retorno.Append(valortotal.ToDecimalString(17));
			retorno.Append("".FillRight(126));

			return retorno.ToString().ToUpper();
		}

		/// <summary>
		/// Lers the retornoDBT627.
		/// </summary>
		/// <param name="aRetorno">A retorno.</param>
		public virtual void LerRetornoDBT627(List<string> aRetorno)
		{
			foreach (var line in aRetorno.Where(line => !line[0].IsIn('A', 'Z')))
			{
				Titulo titulo = null;
				if (line[0] == 'F')
					titulo = Banco.Parent.CriarTituloNaLista();

				if (titulo == null) 
					continue;

				titulo.Vencimento = line.ExtrairDataDaPosicao(45, 52);
				titulo.NumeroDocumento = line.ExtrairDaPosicao(2, 26);
				titulo.Sacado.NomeSacado = line.ExtrairDaPosicao(70, 139);
				titulo.MotivoRejeicaoComando.Add(line.ExtrairDaPosicao(68, 69));
				titulo.ValorDocumento = line.ExtrairDecimalDaPosicao(53, 67);
				titulo.Sacado.CNPJCPF = line.ExtrairDaPosicao(131, 145);
			}
		}

		#endregion Methods		
	}
}