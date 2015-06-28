// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 05-31-2015
//
// Last Modified By : RFTD
// Last Modified On : 05-31-2015
// ***********************************************************************
// <copyright file="Class1.cs" company="">
// Esta biblioteca é software livre; você pode redistribuí-la e/ou modificá-la
// sob os termos da Licença Pública Geral Menor do GNU conforme publicada pela
// Free Software Foundation; tanto a versão 2.1 da Licença, ou (a seu critério)
// qualquer versão posterior.
//
// Esta biblioteca é distribuída na expectativa de que seja útil, porém, SEM
// NENHUMA GARANTIA; nem mesmo a garantia implícita de COMERCIABILIDADE OU
// ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA. Consulte a Licença Pública Geral Menor
// do GNU para mais detalhes. (Arquivo LICENÇA.TXT ou LICENSE.TXT)
//
// Você deve ter recebido uma cópia da Licença Pública Geral Menor do GNU junto
// com esta biblioteca; se não, escreva para a Free Software Foundation, Inc.,
// no endereço 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.
// Você também pode obter uma copia da licença em:
// http://www.opensource.org/licenses/lgpl-license.php
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using ACBr.Net.Boleto.Enums;
using ACBr.Net.Core.Exceptions;
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
	[Guid("41D9AAD6-C953-4935-A15F-9C5A36E8163C")]
	[ComSourceInterfaces(typeof(IACBrBoletoFCEvents))]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

	#endregion COM Interop Attributes
	/// <summary>
	/// Classe BancoSicredi. Está classe não pode ser herdada.
	/// </summary>
	public sealed class BancoSicredi : BancoBase
	{
		#region Constructors

		/// <summary>
		/// Inicializa uma nova instancia da classe <see cref="BancoDoBrasil" />.
		/// </summary>
		/// <param name="parent">Classe Banco.</param>
		internal BancoSicredi(Banco parent)
			: base(parent)
        {
            TipoCobranca = TipoCobranca.Sicred;
            Digito = 10;
			Nome = "Sicredi";
            Numero = 748;
            TamanhoMaximoNossoNum = 8;
            TamanhoConta = 5;
            TamanhoAgencia = 4;
            TamanhoCarteira = 1;
			CodigosMoraAceitos = "AB";
			CodigosGeracaoAceitos = "23456789";
        }

		#endregion Constructors
		
		#region Methods

		public override string TipoOcorrenciaToDescricao(TipoOcorrencia tipo)
		{
			var codOcorrencia = TipoOCorrenciaToCod(tipo).ToInt32();
			switch (Banco.Parent.LayoutRemessa)
			{
				case LayoutRemessa.CNAB240:
					switch (codOcorrencia)
					{
						case 02: return "02-Entrada confirmada";
						case 03: return "03-Entrada rejeitada";
						case 06: return "06-Liquidação";
						case 07: return "07-Confirmação do recebimento da instrução de desconto";
						case 08: return "08-Confirmação do recebimento do cancelamento do desconto";
						case 09: return "09-Baixa";
						case 12: return "12-Confirmação do recebimento da instrução de abatimento";
						case 13: return "13-Confirmação do recebimento do cancelamento do abatimento";
						case 14: return "14-Confirmação do recebimento da instrução de alteração de vencimento";
						case 17: return "17-Liquidação após baixa ou liquidação de título não registrado";
						case 19: return "19-Confirmação de recebimento de instrução de protesto";
						case 20: return "20-Confirmação de recebimento de instrução de sustação/cancelamento de protesto";
						case 23: return "23-Remessa a cartótio (Aponte em cartório)";
						case 24: return "24-Retirada de cartório e manutenção em carteira";
						case 25: return "25-Protestado e baixado (Baixa por ter sido protestado)";
						case 26: return "26-Instrução rejeitada";
						case 28: return "28-Débito de tarifas/custas";
						case 30: return "30-Alteração de dados rejeitada";
						case 36: return "36-Baixa rejeitada";
						default: return string.Format("{0:00}-Outras Ocorrencias", codOcorrencia);
					}
					
				case LayoutRemessa.CNAB400:
					switch (codOcorrencia)
					{
						case 02: return "02-Entrada confirmada";
						case 03: return "03-Entrada rejeitada";
						case 06: return "06-Liquidação normal";
						case 09: return "09-Baixado automaticamente via arquivo";
						case 10: return "10-Baixado conforme instruções da agência";
						case 12: return "12-Abatimento concedido";
						case 13: return "13-Abatimento cancelado";
						case 14: return "14-Vencimento alterado";
						case 15: return "15-Liquidação em cartório";
						case 17: return "17-Liquidação após baixa ou título não registrado";
						case 19: return "19-Confirmação recebimento instrução de protesto";
						case 20: return "20-Confirmação recebimento instrução sustação de protesto";
						case 23: return "23-Entrada do título em cartório";
						case 24: return "24-Entrada rejeitada por CEP irregular";
						case 27: return "27-Baixa rejeitada";
						case 28: return "28-Débito de tarifas/custas";
						case 29: return "29-Ocorrências do sacado";
						case 30: return "30-Alteração de Outros Dados Rejeitados";
						case 32: return "32-Instrução Rejeitada";
						case 33: return "33-Confirmação Pedido Alteração Outros Dados";
						case 34: return "34-Retirado de Cartório e Manutenção Carteira";
						case 35: return "35-Desagendamento do débito automático";
						default: return string.Format("{0:00}-Outras Ocorrencias", codOcorrencia);
					}

				default: return string.Format("{0:00}-Outras Ocorrencias", codOcorrencia);
			}
		}

		public override string TipoOCorrenciaToCod(TipoOcorrencia tipo)
		{
			switch (Banco.Parent.LayoutRemessa)
			{
				case LayoutRemessa.CNAB240:
					switch (tipo)
					{
						case TipoOcorrencia.RetornoRegistroConfirmado: return "02";
						case TipoOcorrencia.RetornoRegistroRecusado: return "03";
						case TipoOcorrencia.RetornoLiquidado: return "06";
						case TipoOcorrencia.RetornoRecebimentoInstrucaoConcederDesconto: return "07";
						case TipoOcorrencia.RetornoRecebimentoInstrucaoCancelarDesconto: return "08";
						case TipoOcorrencia.RetornoBaixado: return "09";
						case TipoOcorrencia.RetornoRecebimentoInstrucaoConcederAbatimento: return "12";
						case TipoOcorrencia.RetornoRecebimentoInstrucaoCancelarAbatimento: return "13";
						case TipoOcorrencia.RetornoRecebimentoInstrucaoAlterarVencimento: return "14";
						case TipoOcorrencia.RetornoLiquidadoAposBaixaOuNaoRegistro: return "17";
						case TipoOcorrencia.RetornoRecebimentoInstrucaoProtestar: return "19";
						case TipoOcorrencia.RetornoRecebimentoInstrucaoSustarProtesto: return "20";
						case TipoOcorrencia.RetornoEntradaEmCartorio: return "23";
						case TipoOcorrencia.RetornoRetiradoDeCartorio: return "24";
						case TipoOcorrencia.RetornoBaixaPorProtesto: return "25";
						case TipoOcorrencia.RetornoInstrucaoRejeitada: return "26";
						case TipoOcorrencia.RetornoDebitoTarifas: return "28";
						case TipoOcorrencia.RetornoAlteracaoDadosRejeitados: return "30";
						case TipoOcorrencia.RetornoBaixaRejeitada: return "36";
						default: return "00";
					}

				case LayoutRemessa.CNAB400:
					switch (tipo)
					{
						case TipoOcorrencia.RetornoRegistroConfirmado: return "02";
						case TipoOcorrencia.RetornoRegistroRecusado: return "03";
						case TipoOcorrencia.RetornoLiquidado: return "06";
						case TipoOcorrencia.RetornoBaixadoViaArquivo: return "09";
						case TipoOcorrencia.RetornoBaixadoInstAgencia: return "10";
						case TipoOcorrencia.RetornoAbatimentoConcedido: return "12";
						case TipoOcorrencia.RetornoAbatimentoCancelado: return "13";
						case TipoOcorrencia.RetornoVencimentoAlterado: return "14";
						case TipoOcorrencia.RetornoLiquidadoEmCartorio: return "15";
						case TipoOcorrencia.RetornoLiquidadoAposBaixaOuNaoRegistro: return "17";
						case TipoOcorrencia.RetornoRecebimentoInstrucaoProtestar: return "19";
						case TipoOcorrencia.RetornoRecebimentoInstrucaoSustarProtesto: return "20";
						case TipoOcorrencia.RetornoEntradaEmCartorio: return "23";
						case TipoOcorrencia.RetornoEntradaRejeitaCEPIrregular: return "24";
						case TipoOcorrencia.RetornoBaixaRejeitada: return "27";
						case TipoOcorrencia.RetornoDebitoTarifas: return "28";
						case TipoOcorrencia.RetornoAlteracaoDadosRejeitados: return "30";
						case TipoOcorrencia.RetornoInstrucaoRejeitada: return "32";
						case TipoOcorrencia.RetornoRetiradoDeCartorio: return "34";
						default: return "00";
					}

				default: return "00";
			}
		}

		#endregion Methods
	}
}