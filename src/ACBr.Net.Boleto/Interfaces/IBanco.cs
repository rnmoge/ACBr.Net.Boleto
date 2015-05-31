// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 04-14-2014
//
// Last Modified By : RFTD
// Last Modified On : 04-29-2014
// ***********************************************************************
// <copyright file="IBanco.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using ACBr.Net.Boleto.Bancos;
using ACBr.Net.Boleto.Enums;
using ACBr.Net.Core;

namespace ACBr.Net.Boleto.Interfaces
{
    /// <summary>
    /// Interface IBanco
    /// </summary>
    public interface IBanco
    {
        #region Propriedades

        /// <summary>
        /// Gets the banco.
        /// </summary>
        /// <value>The banco.</value>
        Banco Banco { get; }
        /// <summary>
        /// Gets the modulo.
        /// </summary>
        /// <value>The modulo.</value>
        CalcDigito Modulo { get; }
        /// <summary>
        /// Gets the nome.
        /// </summary>
        /// <value>The nome.</value>
        string Nome { get; }
        /// <summary>
        /// Gets the tamanho agencia.
        /// </summary>
        /// <value>The tamanho agencia.</value>
        int TamanhoAgencia { get; }
        /// <summary>
        /// Gets the tamanho conta.
        /// </summary>
        /// <value>The tamanho conta.</value>
        int TamanhoConta { get; }
        /// <summary>
        /// Gets the tamanho carteira.
        /// </summary>
        /// <value>The tamanho carteira.</value>
        int TamanhoCarteira { get; }
        /// <summary>
        /// Gets the numero.
        /// </summary>
        /// <value>The numero.</value>
        int Numero { get; }
        /// <summary>
        /// Gets the digito.
        /// </summary>
        /// <value>The digito.</value>
        int Digito { get; }
        /// <summary>
        /// Gets the tamanho maximo nosso number.
        /// </summary>
        /// <value>The tamanho maximo nosso number.</value>
        int TamanhoMaximoNossoNum { get; }
        /// <summary>
        /// Gets the tipo cobranca.
        /// </summary>
        /// <value>The tipo cobranca.</value>
        TipoCobranca TipoCobranca { get; }
        /// <summary>
        /// Gets the orientacoes banco.
        /// </summary>
        /// <value>The orientacoes banco.</value>
        List<string> OrientacoesBanco { get; }
		/// <summary>
		/// Gets the codigos mora aceitos.
		/// </summary>
		/// <value>The codigos mora aceitos.</value>
		string CodigosMoraAceitos { get; }
		/// <summary>
		/// Gets the codigos mora aceitos.
		/// </summary>
		/// <value>The codigos mora aceitos.</value>
		string CodigosGeracaoAceitos { get; }

        #endregion Propriedades

        #region Methods

        /// <summary>
        /// Tipoes the ocorrencia to descricao.
        /// </summary>
        /// <param name="tipo">The tipo.</param>
        /// <returns>System.String.</returns>
        string TipoOcorrenciaToDescricao(TipoOcorrencia tipo);
        /// <summary>
        /// Cods the ocorrencia to tipo.
        /// </summary>
        /// <param name="codOcorrencia">The cod ocorrencia.</param>
        /// <returns>TipoOcorrencia.</returns>
        TipoOcorrencia CodOcorrenciaToTipo(int codOcorrencia);
        /// <summary>
        /// Tipoes the o correncia to cod.
        /// </summary>
        /// <param name="tipo">The tipo.</param>
        /// <returns>System.String.</returns>
        string TipoOCorrenciaToCod(TipoOcorrencia tipo);
        /// <summary>
        /// Cods the motivo rejeicao to descricao.
        /// </summary>
        /// <param name="tipo">The tipo.</param>
        /// <param name="codMotivo">The cod motivo.</param>
        /// <returns>System.String.</returns>
        string CodMotivoRejeicaoToDescricao(TipoOcorrencia tipo, int codMotivo);
        /// <summary>
        /// Calculars the digito verificador.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        string CalcularDigitoVerificador(Titulo titulo);
        /// <summary>
        /// Calculars the tam maximo nosso numero.
        /// </summary>
        /// <param name="carteira">The carteira.</param>
        /// <param name="nossoNumero">The nosso numero.</param>
        /// <returns>System.Int32.</returns>
        int CalcularTamMaximoNossoNumero(string carteira, string nossoNumero = "");
        /// <summary>
        /// Montars the campo codigo cedente.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        string MontarCampoCodigoCedente(Titulo titulo);
        /// <summary>
        /// Montars the campo nosso numero.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        string MontarCampoNossoNumero(Titulo titulo);
        /// <summary>
        /// Montars the codigo barras.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        string MontarCodigoBarras(Titulo titulo);
        /// <summary>
        /// Montars the linha digitavel.
        /// </summary>
        /// <param name="codigoBarras">The codigo barras.</param>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        string MontarLinhaDigitavel(string codigoBarras, Titulo titulo);
        /// <summary>
        /// Gerars the registro header400.
        /// </summary>
        /// <param name="numeroRemessa">The numero remessa.</param>
        /// <param name="aRemessa">A remessa.</param>
        void GerarRegistroHeader400(int numeroRemessa, List<string> aRemessa);
        /// <summary>
        /// Gerars the registro header240.
        /// </summary>
        /// <param name="numeroRemessa">The numero remessa.</param>
        /// <returns>System.String.</returns>
        string GerarRegistroHeader240(int numeroRemessa);
        /// <summary>
        /// Gerars the registro transacao400.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <param name="aRemessa">A remessa.</param>
        void GerarRegistroTransacao400(Titulo titulo, List<string> aRemessa);
        /// <summary>
        /// Gerars the registro transacao240.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        string GerarRegistroTransacao240(Titulo titulo);
        /// <summary>
        /// Gerars the registro trailler400.
        /// </summary>
        /// <param name="aRemessa">A remessa.</param>
        void GerarRegistroTrailler400(List<string> aRemessa);
        /// <summary>
        /// Gerars the registro trailler240.
        /// </summary>
        /// <param name="aRemessa">A remessa.</param>
        /// <returns>System.String.</returns>
        string GerarRegistroTrailler240(List<string> aRemessa);
		/// <summary>
		/// Gerars the registro headerDBT627.
		/// </summary>
		/// <param name="numeroRemessa">The numero remessa.</param>
		/// <returns>System.String.</returns>
		string GerarRegistroHeaderDBT627(int numeroRemessa);
		/// <summary>
		/// Gerars the registro transacaoDBT627.
		/// </summary>
		/// <param name="titulo">The titulo.</param>
		/// <returns>System.String.</returns>
		string GerarRegistroTransacaoDBT627(Titulo titulo);
		/// <summary>
		/// Gerars the registro traillerDBT627.
		/// </summary>
		/// <param name="aRemessa">A remessa.</param>
		/// <returns>System.String.</returns>
		string GerarRegistroTraillerDBT627(List<string> aRemessa);
        /// <summary>
        /// Lers the retorno400.
        /// </summary>
        /// <param name="aRetorno">A retorno.</param>
        void LerRetorno400(List<string> aRetorno);
        /// <summary>
        /// Lers the retorno240.
        /// </summary>
        /// <param name="aRetorno">A retorno.</param>
        void LerRetorno240(List<string> aRetorno);
		/// <summary>
		/// Lers the retornoDBT627.
		/// </summary>
		/// <param name="aRetorno">A retorno.</param>
		void LerRetornoDBT627(List<string> aRetorno);
        /// <summary>
        /// Calculars the nome arquivo remessa.
        /// </summary>
        /// <returns>System.String.</returns>
        string CalcularNomeArquivoRemessa();

        #endregion Methods
    }
}
