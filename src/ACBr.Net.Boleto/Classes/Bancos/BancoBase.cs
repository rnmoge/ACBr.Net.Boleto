using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
#region COM Interop Attributes

#if COM_INTEROP
using System.Runtime.InteropServices;
#endif


#endregion COM Interop Attributes
using ACBr.Net.Core;
using ACBr.Net.Boleto.Interfaces;

namespace ACBr.Net.Boleto
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
        /// Initializes a new instance of the <see cref="BancoBase"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        internal BancoBase(Banco parent)
        {
            this.Banco = parent;
            Modulo = new CalcDigito();
            TipoCobranca = TipoCobranca.Nenhum;
            OrientacoesBanco = new List<string>();
            Nome = "Nenhum";
            TamanhoAgencia = 0;
            TamanhoCarteira = 0;
            TamanhoConta = 0;
            TamanhoMaximoNossoNum = 0;
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

        #endregion Propriedades

        #region Methods

        /// <summary>
        /// Tipoes the ocorrencia to descricao.
        /// </summary>
        /// <param name="Tipo">The tipo.</param>
        /// <returns>System.String.</returns>
        public virtual string TipoOcorrenciaToDescricao(TipoOcorrencia Tipo)
        {
            return string.Empty;
        }

        /// <summary>
        /// Cods the ocorrencia to tipo.
        /// </summary>
        /// <param name="CodOcorrencia">The cod ocorrencia.</param>
        /// <returns>TipoOcorrencia.</returns>
        public virtual TipoOcorrencia CodOcorrenciaToTipo(int CodOcorrencia)
        {
            return TipoOcorrencia.RemessaRegistrar;
        }

        /// <summary>
        /// Tipoes the o correncia to cod.
        /// </summary>
        /// <param name="Tipo">The tipo.</param>
        /// <returns>System.String.</returns>
        public virtual string TipoOCorrenciaToCod(TipoOcorrencia Tipo)
        {
            return string.Empty;
        }

        /// <summary>
        /// Cods the motivo rejeicao to descricao.
        /// </summary>
        /// <param name="Tipo">The tipo.</param>
        /// <param name="CodMotivo">The cod motivo.</param>
        /// <returns>System.String.</returns>
        public virtual string CodMotivoRejeicaoToDescricao(TipoOcorrencia Tipo, int CodMotivo)
        {
            return string.Empty;
        }

        /// <summary>
        /// Calculars the digito verificador.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public virtual string CalcularDigitoVerificador(Titulo Titulo)
        {
            return string.Empty;
        }

        /// <summary>
        /// Calculars the tam maximo nosso numero.
        /// </summary>
        /// <param name="Carteira">The carteira.</param>
        /// <param name="NossoNumero">The nosso numero.</param>
        /// <returns>System.Int32.</returns>
        public virtual int CalcularTamMaximoNossoNumero(string Carteira, string NossoNumero = "")
        {
            return Banco.TamanhoMaximoNossoNum;
        }

        /// <summary>
        /// Montars the campo codigo cedente.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public virtual string MontarCampoCodigoCedente(Titulo Titulo)
        {
            return string.Empty;
        }

        /// <summary>
        /// Montars the campo nosso numero.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public virtual string MontarCampoNossoNumero(Titulo Titulo)
        {
            return Titulo.NossoNumero;
        }

        /// <summary>
        /// Montars the codigo barras.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public virtual string MontarCodigoBarras(Titulo Titulo)
        {
            return string.Empty;
        }

        /// <summary>
        /// Montars the linha digitavel.
        /// </summary>
        /// <param name="CodigoBarras">The codigo barras.</param>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public virtual string MontarLinhaDigitavel(string CodigoBarras, Titulo Titulo)
        {
            Modulo.FormulaDigito = CalcDigFormula.Modulo10;
            Modulo.MultiplicadorInicial = 1;
            Modulo.MultiplicadorFinal = 2;
            Modulo.MultiplicadorAtual = 2;
            
            //Campo 1(Código Banco,Tipo de Moeda,5 primeiro digitos do Campo Livre)
            Modulo.Documento = string.Format("{0}9{1}", CodigoBarras.Substring(0,3), CodigoBarras.Substring(19,5));
            Modulo.Calcular();
            
            var Campo1 = string.Format("{0}.{1}{2}", Modulo.Documento.Substring(0, 5), Modulo.Documento.Substring(5, 4), Modulo.DigitoFinal);
            
            //Campo 2(6ª a 15ª posições do campo Livre)
            Modulo.Documento = CodigoBarras.Substring( 24, 10);
            Modulo.Calcular();
            
            var Campo2 = string.Format("{0}.{1}{2}", Modulo.Documento.Substring(0, 5), Modulo.Documento.Substring( 5, 5), Modulo.DigitoFinal);
            
            //Campo 3 (16ª a 25ª posições do campo Livre)
            Modulo.Documento = CodigoBarras.Substring( 34, 10);
            Modulo.Calcular();

            var Campo3 = string.Format("{0}.{1}{2}", Modulo.Documento.Substring(0, 5), Modulo.Documento.Substring( 5, 5), Modulo.DigitoFinal);
            
            //Campo 4 (Digito Verificador Nosso Numero)
            var Campo4 = CodigoBarras.Substring( 4, 1);
            
            //Campo 5 (Fator de Vencimento e Valor do Documento)
            var Campo5 = CodigoBarras.Substring( 5, 14);

           return string.Format("{0} {1} {2} {3} {4}",  Campo1, Campo2, Campo3, Campo4, Campo5);
        }

        /// <summary>
        /// Gerars the registro header400.
        /// </summary>
        /// <param name="NumeroRemessa">The numero remessa.</param>
        /// <param name="ARemessa">A remessa.</param>
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public virtual void GerarRegistroHeader400(int NumeroRemessa, List<string> ARemessa)
        {
            throw new NotImplementedException("Esta função não esta implementada para este banco");
        }

        /// <summary>
        /// Gerars the registro header240.
        /// </summary>
        /// <param name="NumeroRemessa">The numero remessa.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public virtual string GerarRegistroHeader240(int NumeroRemessa)
        {
            throw new NotImplementedException("Esta função não esta implementada para este banco");
        }

        /// <summary>
        /// Gerars the registro transacao400.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <param name="ARemessa">A remessa.</param>
        public virtual void GerarRegistroTransacao400(Titulo Titulo, List<string> ARemessa)
        {
            
        }

        /// <summary>
        /// Gerars the registro transacao240.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public virtual string GerarRegistroTransacao240(Titulo Titulo)
        {
            return string.Empty;
        }

        /// <summary>
        /// Gerars the registro trailler400.
        /// </summary>
        /// <param name="ARemessa">A remessa.</param>
        public virtual void GerarRegistroTrailler400(List<string> ARemessa)
        {
            
        }

        /// <summary>
        /// Gerars the registro trailler240.
        /// </summary>
        /// <param name="ARemessa">A remessa.</param>
        /// <returns>System.String.</returns>
        public virtual string GerarRegistroTrailler240(List<string> ARemessa)
        {
            return string.Empty;
        }

        /// <summary>
        /// Lers the retorno400.
        /// </summary>
        /// <param name="ARetorno">A retorno.</param>
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public virtual void LerRetorno400(List<string> ARetorno)
        {
            throw new NotImplementedException("Esta função não esta implementada para este banco");
        }

        /// <summary>
        /// Lers the retorno240.
        /// </summary>
        /// <param name="ARetorno">A retorno.</param>
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public virtual void LerRetorno240(List<string> ARetorno)
        {
            throw new NotImplementedException("Esta função não esta implementada para este banco");
        }

        /// <summary>
        /// Calculars the nome arquivo remessa.
        /// </summary>
        /// <returns>System.String.</returns>
        public virtual string CalcularNomeArquivoRemessa()
        {
            int Sequencia = 0;
            
            if(string.IsNullOrEmpty(Banco.Parent.NomeArqRemessa))
            {
                var NomeFixo = string.Format(@"{0}\cb{1:ddMM}", Banco.Parent.DirArqRemessa, DateTime.Now);
                string NomeArq = string.Empty;
                do
                {
                    Sequencia++;
                    NomeArq = string.Format("{0}{1:00}.rem", NomeFixo, Sequencia);
                }
                while(File.Exists(NomeArq));
                return NomeArq;
            }
            else
             return string.Format(@"{0}\{1}",  Banco.Parent.DirArqRemessa, Banco.Parent.NomeArqRemessa);
        }

        /// <summary>
        /// Calculars the digito codigo barras.
        /// </summary>
        /// <param name="CodigoBarras">The codigo barras.</param>
        /// <returns>System.String.</returns>
        protected virtual string CalcularDigitoCodigoBarras(string CodigoBarras)
        {
            Modulo.CalculoPadrao();
            Modulo.Documento = CodigoBarras;
            Modulo.Calcular();

            if (Modulo.DigitoFinal == 0 || Modulo.DigitoFinal > 9)
                return "1";
            else
                return Modulo.DigitoFinal.ToString();
        }

		public string GerarRegistroHeaderDBT627(int NumeroRemessa)
		{
			var Retorno = new StringBuilder();
			Retorno.Append("A1");
			Retorno.Append(Banco.Parent.Cedente.Convenio.FillLeft(20));
            Retorno.Append(Banco.Parent.Cedente.Nome.FillLeft(20));
			Retorno.AppendFormat("{0:000}", Numero);
			Retorno.Append(Nome.FillRight(20));
			Retorno.AppendFormat("{0:yyyyMMdd}", DateTime.Now);
			Retorno.AppendFormat("{0:000000}", NumeroRemessa);
			Retorno.Append("05DEBITO AUTOMATICO");
			Retorno.Append("".FillRight(52));

			return Retorno.ToString().ToUpper();
		}

		public string GerarRegistroTransacaoDBT627(Titulo Titulo)
		{
			var Retorno = new StringBuilder();
			Retorno.Append("E");
			Retorno.Append(Titulo.NumeroDocumento.Trim().FillLeft(25));
			Retorno.Append(Banco.Parent.Cedente.Agencia.Trim().ZeroFill(4));
            Retorno.Append(Banco.Parent.Cedente.Conta.Trim().ZeroFill(14));
			Retorno.Append(Titulo.Vencimento.ToString("yyyyMMdd"));
			Retorno.Append(Titulo.ValorDocumento.ToRemessaString(15));
			Retorno.Append("03");
			Retorno.Append(Titulo.Sacado.NomeSacado.FillLeft(60));
			Retorno.Append(Titulo.Sacado.CNPJCPF.IsCNPJ() ? "1" : "2");
			Retorno.Append(Titulo.Sacado.CNPJCPF.OnlyNumbers().ZeroFill(15));
			Retorno.Append("".FillRight(4));
			Retorno.Append("0");

			return Retorno.ToString().ToUpper();
		}

		public string GerarRegistroTraillerDBT627(List<string> ARemessa)
		{
			decimal valortotal = 0;
			foreach (var titulo in Banco.Parent.ListadeBoletos)
				valortotal += titulo.ValorDocumento;

			var Retorno = new StringBuilder();            
			Retorno.AppendFormat("Z{0:000000}", ARemessa.Count + 1);
			Retorno.Append(valortotal.ToRemessaString(17));
			Retorno.Append("".FillRight(126));

			return Retorno.ToString().ToUpper();
		}

		/// <summary>
		/// Lers the retornoDBT627.
		/// </summary>
		/// <param name="ARetorno">A retorno.</param>
		/// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
		public virtual void LerRetornoDBT627(List<string> ARetorno)
		{
			Titulo titulo = null;
			foreach (var line in ARetorno)
			{
				if (line[0].IsIn('A', 'Z'))
					continue;

				if (line[0] == 'F')
					titulo = Banco.Parent.CriarTituloNaLista();

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