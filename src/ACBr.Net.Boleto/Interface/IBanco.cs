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
using System;
using System.Linq;
using System.Collections.Generic;
using ACBr.Net.Core;

/// <summary>
/// ACBr.Net.Boleto.Interfaces namespace.
/// </summary>
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

        #endregion Propriedades

        #region Methods

        /// <summary>
        /// Tipoes the ocorrencia to descricao.
        /// </summary>
        /// <param name="Tipo">The tipo.</param>
        /// <returns>System.String.</returns>
        string TipoOcorrenciaToDescricao(TipoOcorrencia Tipo);
        /// <summary>
        /// Cods the ocorrencia to tipo.
        /// </summary>
        /// <param name="CodOcorrencia">The cod ocorrencia.</param>
        /// <returns>TipoOcorrencia.</returns>
        TipoOcorrencia CodOcorrenciaToTipo(int CodOcorrencia);
        /// <summary>
        /// Tipoes the o correncia to cod.
        /// </summary>
        /// <param name="Tipo">The tipo.</param>
        /// <returns>System.String.</returns>
        string TipoOCorrenciaToCod(TipoOcorrencia Tipo);
        /// <summary>
        /// Cods the motivo rejeicao to descricao.
        /// </summary>
        /// <param name="Tipo">The tipo.</param>
        /// <param name="CodMotivo">The cod motivo.</param>
        /// <returns>System.String.</returns>
        string CodMotivoRejeicaoToDescricao(TipoOcorrencia Tipo, int CodMotivo);
        /// <summary>
        /// Calculars the digito verificador.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        string CalcularDigitoVerificador(Titulo Titulo);
        /// <summary>
        /// Calculars the tam maximo nosso numero.
        /// </summary>
        /// <param name="Carteira">The carteira.</param>
        /// <param name="NossoNumero">The nosso numero.</param>
        /// <returns>System.Int32.</returns>
        int CalcularTamMaximoNossoNumero(string Carteira, string NossoNumero = "");
        /// <summary>
        /// Montars the campo codigo cedente.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        string MontarCampoCodigoCedente(Titulo Titulo);
        /// <summary>
        /// Montars the campo nosso numero.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        string MontarCampoNossoNumero(Titulo Titulo);
        /// <summary>
        /// Montars the codigo barras.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        string MontarCodigoBarras(Titulo Titulo);
        /// <summary>
        /// Montars the linha digitavel.
        /// </summary>
        /// <param name="CodigoBarras">The codigo barras.</param>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        string MontarLinhaDigitavel(string CodigoBarras, Titulo Titulo);
        /// <summary>
        /// Gerars the registro header400.
        /// </summary>
        /// <param name="NumeroRemessa">The numero remessa.</param>
        /// <param name="ARemessa">A remessa.</param>
        void GerarRegistroHeader400(int NumeroRemessa, List<string> ARemessa);
        /// <summary>
        /// Gerars the registro header240.
        /// </summary>
        /// <param name="NumeroRemessa">The numero remessa.</param>
        /// <returns>System.String.</returns>
        string GerarRegistroHeader240(int NumeroRemessa);
        /// <summary>
        /// Gerars the registro transacao400.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <param name="ARemessa">A remessa.</param>
        void GerarRegistroTransacao400(Titulo Titulo, List<string> ARemessa);
        /// <summary>
        /// Gerars the registro transacao240.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        string GerarRegistroTransacao240(Titulo Titulo);
        /// <summary>
        /// Gerars the registro trailler400.
        /// </summary>
        /// <param name="ARemessa">A remessa.</param>
        void GerarRegistroTrailler400(List<string> ARemessa);
        /// <summary>
        /// Gerars the registro trailler240.
        /// </summary>
        /// <param name="ARemessa">A remessa.</param>
        /// <returns>System.String.</returns>
        string GerarRegistroTrailler240(List<string> ARemessa);
		/// <summary>
		/// Gerars the registro headerDBT627.
		/// </summary>
		/// <param name="NumeroRemessa">The numero remessa.</param>
		/// <returns>System.String.</returns>
		string GerarRegistroHeaderDBT627(int NumeroRemessa);
		/// <summary>
		/// Gerars the registro transacaoDBT627.
		/// </summary>
		/// <param name="Titulo">The titulo.</param>
		/// <returns>System.String.</returns>
		string GerarRegistroTransacaoDBT627(Titulo Titulo);
		/// <summary>
		/// Gerars the registro traillerDBT627.
		/// </summary>
		/// <param name="ARemessa">A remessa.</param>
		/// <returns>System.String.</returns>
		string GerarRegistroTraillerDBT627(List<string> ARemessa);
        /// <summary>
        /// Lers the retorno400.
        /// </summary>
        /// <param name="ARetorno">A retorno.</param>
        void LerRetorno400(List<string> ARetorno);
        /// <summary>
        /// Lers the retorno240.
        /// </summary>
        /// <param name="ARetorno">A retorno.</param>
        void LerRetorno240(List<string> ARetorno);
		/// <summary>
		/// Lers the retornoDBT627.
		/// </summary>
		/// <param name="ARetorno">A retorno.</param>
		void LerRetornoDBT627(List<string> ARetorno);
        /// <summary>
        /// Calculars the nome arquivo remessa.
        /// </summary>
        /// <returns>System.String.</returns>
        string CalcularNomeArquivoRemessa();

        #endregion Methods
    }
}
