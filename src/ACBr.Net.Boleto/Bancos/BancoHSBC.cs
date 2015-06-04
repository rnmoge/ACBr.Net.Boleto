// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 05-30-2014
//
// Last Modified By : RFTD
// Last Modified On : 06-14-2014
// ***********************************************************************
// <copyright file="BancoHSBC.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACBr.Net.Boleto.Enums;
using ACBr.Net.Boleto.Utils;
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
	[Guid("6E5BD577-1A64-41A7-BA76-8D9BF00777CE")]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

	#endregion COM Interop Attributes
	/// <summary>
	/// Classe BancoHSBC. Esta classe não pode ser herdada.
	/// </summary>
    public sealed class BancoHSBC : BancoBase
    {
        #region Fields
        #endregion Fields

        #region Constructor

		/// <summary>
		/// Inicializa uma nova instancia da classe <see cref="BancoHSBC" />.
		/// </summary>
		/// <param name="parent">Classe Banco.</param>
		internal BancoHSBC(Banco parent)
			: base(parent)
        {
            TipoCobranca = TipoCobranca.HSBC;
			Digito = 9;
			Nome = "HSBC";
			Numero = 399;
			TamanhoMaximoNossoNum = 16;
			TamanhoAgencia = 4;
			TamanhoConta = 7;
			TamanhoCarteira = 3;
        }

        #endregion Constructor

        #region Propriedades
        #endregion Propriedades

        #region Methods

		/// <summary>
		/// Informa a descrição do tipo de ocorrencia informado.
		/// </summary>
		/// <param name="tipo">Tipo de ocorrencia</param>
		/// <returns>Descrição da ocorrencia</returns>
        public override string TipoOcorrenciaToDescricao(TipoOcorrencia tipo)
        {
            var codOcorrencia = TipoOCorrenciaToCod(tipo).ToInt32();
            switch (codOcorrencia)
            {
				case 2: return "02-Entrada Confirmada";
				case 3: return "03-Entrada Rejeitada";
				case 6: return "06-Liquidação normal";
				case 9: return "09-Baixado Automaticamente via Arquivo";
				case 10: return "10-Baixado conforme instruções da Agência";
				case 11: return "11-Em Ser - Arquivo de Títulos pendentes";
				case 12: return "12-Abatimento Concedido";
				case 13: return "13-Abatimento Cancelado";
				case 14: return "14-Vencimento Alterado";
				case 15: return "15-Liquidação em Cartório";
				case 16: return "16-Titulo Pago em Cheque - Vinculado";
				case 17: return "17-Liquidação após baixa ou Título não registrado";
				case 18: return "18-Acerto de Depositária";
				case 19: return "19-Confirmação Recebimento Instrução de Protesto";
				case 20: return "20-Confirmação Recebimento Instrução Sustação de Protesto";
				case 21: return "21-Acerto do Controle do Participante";
				case 22: return "22-Titulo com Pagamento Cancelado";
				case 23: return "23-Entrada do Título em Cartório";
				case 24: return "24-Entrada rejeitada por CEP Irregular";
				case 27: return "27-Baixa Rejeitada";
				case 28: return "28-Débito de tarifas/custas";
				case 29: return "29-Ocorrências do Sacado";
				case 30: return "30-Alteração de Outros Dados Rejeitados";
				case 32: return "32-Instrução Rejeitada";
				case 33: return "33-Confirmação Pedido Alteração Outros Dados";
				case 34: return "34-Retirado de Cartório e Manutenção Carteira";
				case 35: return "35-Desagendamento do débito automático";
				case 40: return "40-Estorno de Pagamento";
				case 55: return "55-Sustado Judicial";
				case 68: return "68-Acerto dos dados do rateio de Crédito";
				case 69: return "69-Cancelamento dos dados do rateio";
                default: return string.Format("{0:00}-Outras Ocorrencias", codOcorrencia);
			}
        }

		/// <summary>
		/// Transforma um codigo de ocorrencia em um Tipo de ocorrencia.
		/// </summary>
		/// <param name="codOcorrencia">Codigo da ocorrencia.</param>
		/// <returns>Retorna um TipoOcorrencia.</returns>
        public override TipoOcorrencia CodOcorrenciaToTipo(int codOcorrencia)
        {
            switch (codOcorrencia)
            {
				case 2: return TipoOcorrencia.RetornoRegistroConfirmado;
				case 3: return TipoOcorrencia.RetornoRegistroRecusado;
				case 6: return TipoOcorrencia.RetornoLiquidado;
				case 9: return TipoOcorrencia.RetornoBaixadoViaArquivo;
				case 10: return TipoOcorrencia.RetornoBaixadoInstAgencia;
				case 11: return TipoOcorrencia.RetornoTituloEmSer;
				case 12: return TipoOcorrencia.RetornoAbatimentoConcedido;
				case 13: return TipoOcorrencia.RetornoAbatimentoCancelado;
				case 14: return TipoOcorrencia.RetornoVencimentoAlterado;
				case 15: return TipoOcorrencia.RetornoLiquidadoEmCartorio;
				case 16: return TipoOcorrencia.RetornoLiquidado;
				case 17: return TipoOcorrencia.RetornoLiquidadoAposBaixaOuNaoRegistro;
				case 18: return TipoOcorrencia.RetornoAcertoDepositaria;
				case 19: return TipoOcorrencia.RetornoRecebimentoInstrucaoProtestar;
				case 20: return TipoOcorrencia.RetornoRecebimentoInstrucaoSustarProtesto;
				case 21: return TipoOcorrencia.RetornoAcertoControleParticipante;
				case 22: return TipoOcorrencia.RetornoRecebimentoInstrucaoAlterarDados;
				case 23: return TipoOcorrencia.RetornoEncaminhadoACartorio;
				case 24: return TipoOcorrencia.RetornoEntradaRejeitaCEPIrregular;
				case 27: return TipoOcorrencia.RetornoBaixaRejeitada;
				case 28: return TipoOcorrencia.RetornoDebitoTarifas;
				case 29: return TipoOcorrencia.RetornoOcorrenciasDoSacado;
				case 30: return TipoOcorrencia.RetornoAlteracaoOutrosDadosRejeitada;
				case 32: return TipoOcorrencia.RetornoComandoRecusado;
				case 33: return TipoOcorrencia.RetornoRecebimentoInstrucaoAlterarDados;
				case 34: return TipoOcorrencia.RetornoRetiradoDeCartorio;
				case 35: return TipoOcorrencia.RetornoDesagendamentoDebitoAutomatico;
				case 99: return TipoOcorrencia.RetornoRegistroRecusado;
                default: return TipoOcorrencia.RetornoOutrasOcorrencias;
            }
        }

		/// <summary>
		/// Tipoes the o correncia to cod.
		/// </summary>
		/// <param name="tipo">The tipo.</param>
		/// <returns>System.String.</returns>
        public override string TipoOCorrenciaToCod(TipoOcorrencia tipo)
        {
            switch (tipo)
            {
				case TipoOcorrencia.RetornoRegistroConfirmado: return "02";
				case TipoOcorrencia.RetornoRegistroRecusado: return "03";
				case TipoOcorrencia.RetornoLiquidado: return "06";
				case TipoOcorrencia.RetornoBaixadoViaArquivo: return "09";
				case TipoOcorrencia.RetornoBaixadoInstAgencia: return "10";
				case TipoOcorrencia.RetornoTituloEmSer: return "11";
				case TipoOcorrencia.RetornoAbatimentoConcedido: return "12";
				case TipoOcorrencia.RetornoAbatimentoCancelado: return "13";
				case TipoOcorrencia.RetornoVencimentoAlterado: return "14";
				case TipoOcorrencia.RetornoLiquidadoEmCartorio: return "15";
				case TipoOcorrencia.RetornoTituloPagoEmCheque: return "16";
				case TipoOcorrencia.RetornoLiquidadoAposBaixaOuNaoRegistro: return "17";
				case TipoOcorrencia.RetornoAcertoDepositaria: return "18";
				case TipoOcorrencia.RetornoRecebimentoInstrucaoProtestar: return "19";
				case TipoOcorrencia.RetornoRecebimentoInstrucaoSustarProtesto: return "20";
				case TipoOcorrencia.RetornoAcertoControleParticipante: return "21";
				case TipoOcorrencia.RetornoRecebimentoInstrucaoAlterarDados: return "22";
				case TipoOcorrencia.RetornoEncaminhadoACartorio: return "23";
				case TipoOcorrencia.RetornoEntradaRejeitaCEPIrregular: return "24";
				case TipoOcorrencia.RetornoBaixaRejeitada: return "27";
				case TipoOcorrencia.RetornoDebitoTarifas: return "28";
				case TipoOcorrencia.RetornoOcorrenciasDoSacado: return "29";
				case TipoOcorrencia.RetornoAlteracaoOutrosDadosRejeitada: return "30";
				case TipoOcorrencia.RetornoComandoRecusado: return "32";
				case TipoOcorrencia.RetornoDesagendamentoDebitoAutomatico: return "35";
                default: return "02";
            }
        }

		/// <summary>
		/// Cods the motivo rejeicao to descricao.
		/// </summary>
		/// <param name="tipo">The tipo.</param>
		/// <param name="codMotivo">The cod motivo.</param>
		/// <returns>System.String.</returns>
        public override string CodMotivoRejeicaoToDescricao(TipoOcorrencia tipo, int codMotivo)
        {
            switch (tipo)
            {
				case TipoOcorrencia.RetornoRegistroConfirmado:
                    switch (codMotivo)
                    {
						case 0: return "00-Ocorrencia aceita";
						case 1: return "01-Codigo de banco inválido";
						case 4: return "04-Cod. movimentacao nao permitido p/ a carteira";
						case 15: return "15-Caracteristicas de Cobranca Imcompativeis";
						case 17: return "17-Data de vencimento anterior a data de emissão";
						case 21: return "21-Espécie do Título inválido";
						case 24: return "24-Data da emissão inválida";
						case 38: return "38-Prazo para protesto inválido";
						case 39: return "39-Pedido para protesto não permitido para título";
						case 43: return "43-Prazo para baixa e devolução inválido";
						case 45: return "45-Nome do Sacado inválido";
						case 46: return "46-Tipo/num. de inscrição do Sacado inválidos";
						case 47: return "47-Endereço do Sacado não informado";
						case 48: return "48-CEP invalido";
						case 50: return "50-CEP referente a Banco correspondente";
						case 53: return "53-Nº de inscrição do Sacador/avalista inválidos (CPF/CNPJ)";
						case 54: return "54-Sacador/avalista não informado";
						case 67: return "67-Débito automático agendado";
						case 68: return "68-Débito não agendado - erro nos dados de remessa";
						case 69: return "69-Débito não agendado - Sacado não consta no cadastro de autorizante";
						case 70: return "70-Débito não agendado - Cedente não autorizado pelo Sacado";
						case 71: return "71-Débito não agendado - Cedente não participa da modalidade de débito automático";
						case 72: return "72-Débito não agendado - Código de moeda diferente de R$";
						case 73: return "73-Débito não agendado - Data de vencimento inválida";
						case 75: return "75-Débito não agendado - Tipo do número de inscrição do sacado debitado inválido";
						case 86: return "86-Seu número do documento inválido";
						case 89: return "89-Email sacado nao enviado - Titulo com debito automatico";
						case 90: return "90-Email sacado nao enviado - Titulo com cobranca sem registro";
                        default: return string.Format("{0:00} - Outros Motivos", codMotivo);
                    }

				case TipoOcorrencia.RetornoRegistroRecusado:
					switch (codMotivo)
					{
						case 2: return "02-Codigo do registro detalhe invalido";
						case 3: return "03-Codigo da Ocorrencia Invalida";
						case 4: return "04-Codigo da Ocorrencia nao permitida para a carteira";
						case 5: return "05-Codigo de Ocorrencia nao numerico";
						case 7: return "Agencia\\Conta\\Digito invalido";
						case 8: return "Nosso numero invalido";
						case 9: return "Nosso numero duplicado";
						case 10: return "Carteira invalida";
						case 13: return "Idetificacao da emissao do boleto invalida";
						case 16: return "Data de vencimento invalida";
						case 18: return "Vencimento fora do prazo de operacao";
						case 20: return "Valor do titulo invalido";
						case 21: return "Especie do titulo invalida";
						case 22: return "Especie nao permitida para a carteira";
						case 24: return "Data de emissao invalida";
						case 28: return "Codigo de desconto invalido";
						case 38: return "Prazo para protesto invalido";
						case 44: return "Agencia cedente nao prevista";
						case 45: return "Nome cedente nao informado";
						case 46: return "Tipo/numero inscricao sacado invalido";
						case 47: return "Endereco sacado nao informado";
						case 48: return "CEP invalido";
						case 50: return "CEP irregular - Banco correspondente";
						case 63: return "Entrada para titulo ja cadastrado";
						case 65: return "Limite excedido";
						case 66: return "Numero autorizacao inexistente";
						case 68: return "Debito nao agendado - Erro nos dados da remessa";
						case 69: return "Debito nao agendado - Sacado nao consta no cadastro de autorizante";
						case 70: return "Debito nao agendado - Cedente nao autorizado pelo sacado";
						case 71: return "Debito nao agendado - Cedente nao participa de debito automatico";
						case 72: return "Debito nao agendado - Codigo de moeda diferente de R$";
						case 73: return "Debito nao agendado - Data de vencimento invalida";
						case 74: return "Debito nao agendado - Conforme seu pedido titulo nao registrado";
						case 75: return "Debito nao agendado - Tipo de numero de inscricao de debitado invalido";
						default: return string.Format("{0:00} - Outros Motivos", codMotivo);
					}

				case TipoOcorrencia.RetornoLiquidadoEmCartorio:
				case TipoOcorrencia.RetornoLiquidadoAposBaixaOuNaoRegistro:
				case TipoOcorrencia.RetornoLiquidado:
					switch (codMotivo)
					{
						case 0: return "00-Titulo pago com dinheiro";
						case 15: return "15-Titulo pago com cheque";
						case 42: return "42-Rateio nao efetuado";
						default: return string.Format("{0:00} - Outros Motivos", codMotivo);
					}

				case TipoOcorrencia.RetornoBaixadoViaArquivo:
					switch (codMotivo)
					{
						case 0: return "00-Ocorrencia aceita";
						case 10: return "10=Baixa comandada pelo cliente";
						default: return string.Format("{0:00} - Outros Motivos", codMotivo);
					}

				case TipoOcorrencia.RetornoBaixadoInstAgencia:
					switch (codMotivo)
					{
						case 0: return "00-Baixado conforme instrucoes na agencia";
						case 14: return "14-Titulo protestado";
						case 15: return "15-Titulo excluido";
						case 16: return "16-Titulo baixado pelo banco por decurso de prazo";
						case 20: return "20-Titulo baixado e transferido para desconto";
						default: return string.Format("{0:00} - Outros Motivos", codMotivo);
					}

				case TipoOcorrencia.RetornoEntradaRejeitaCEPIrregular:
					switch (codMotivo)
					{
						case 48: return "48-CEP invalido";
						default: return string.Format("{0:00} - Outros Motivos", codMotivo);
					}

				case TipoOcorrencia.RetornoBaixaRejeitada:
					switch (codMotivo)
					{
						case 4: return "04-Codigo de ocorrencia nao permitido para a carteira";
						case 07: return "07-Agencia\\Conta\\Digito invalidos";
						case 08: return "08-Nosso numero invalido";
						case 10: return "10-Carteira invalida";
						case 15: return "15-Carteira\\Agencia\\Conta\\NossoNumero invalidos";
						case 40: return "40-Titulo com ordem de protesto emitido";
						case 42: return "42-Codigo para baixa/devolucao via Telebradesco invalido";
						case 60: return "60-Movimento para titulo nao cadastrado";
						case 77: return "70-Transferencia para desconto nao permitido para a carteira";
						case 85: return "85-Titulo com pagamento vinculado";
						default: return string.Format("{0:00} - Outros Motivos", codMotivo);
					}

				case TipoOcorrencia.RetornoDebitoTarifas:
					switch (codMotivo)
					{
						case 2: return "02-Tarifa de permanência título cadastrado";
						case 03: return "03-Tarifa de sustação";
						case 04: return "04-Tarifa de protesto";
						case 05: return "05-Tarifa de outras instrucoes";
						case 06: return "06-Tarifa de outras ocorrências";
						case 08: return "08-Custas de protesto";
						case 12: return "12-Tarifa de registro";
						case 13: return "13-Tarifa titulo pago no Bradesco";
						case 14: return "14-Tarifa titulo pago compensacao";
						case 15: return "15-Tarifa título baixado não pago";
						case 16: return "16-Tarifa alteracao de vencimento";
						case 17: return "17-Tarifa concessão abatimento";
						case 18: return "18-Tarifa cancelamento de abatimento";
						case 19: return "19-Tarifa concessão desconto";
						case 20: return "20-Tarifa cancelamento desconto";
						case 21: return "21-Tarifa título pago cics";
						case 22: return "22-Tarifa título pago Internet";
						case 23: return "23-Tarifa título pago term. gerencial serviços";
						case 24: return "24-Tarifa título pago Pág-Contas";
						case 25: return "25-Tarifa título pago Fone Fácil";
						case 26: return "26-Tarifa título Déb. Postagem";
						case 27: return "27-Tarifa impressão de títulos pendentes";
						case 28: return "28-Tarifa título pago BDN";
						case 29: return "29-Tarifa título pago Term. Multi Funcao";
						case 30: return "30-Impressão de títulos baixados";
						case 31: return "31-Impressão de títulos pagos";
						case 32: return "32-Tarifa título pago Pagfor";
						case 33: return "33-Tarifa reg/pgto – guichê caixa";
						case 34: return "34-Tarifa título pago retaguarda";
						case 35: return "35-Tarifa título pago Subcentro";
						case 36: return "36-Tarifa título pago Cartao de Credito";
						case 37: return "37-Tarifa título pago Comp Eletrônica";
						case 38: return "38-Tarifa título Baix. Pg. Cartorio";
						case 39: return "39-Tarifa título baixado acerto BCO";
						case 40: return "40-Baixa registro em duplicidade";
						case 41: return "41-Tarifa título baixado decurso prazo";
						case 42: return "42-Tarifa título baixado Judicialmente";
						case 43: return "43-Tarifa título baixado via remessa";
						case 44: return "44-Tarifa título baixado rastreamento";
						case 45: return "45-Tarifa título baixado conf. Pedido";
						case 46: return "46-Tarifa título baixado protestado";
						case 47: return "47-Tarifa título baixado p/ devolucao";
						case 48: return "48-Tarifa título baixado franco pagto";
						case 49: return "49-Tarifa título baixado SUST/RET/CARTÓRIO";
						case 50: return "50-Tarifa título baixado SUS/SEM/REM/CARTÓRIO";
						case 51: return "51-Tarifa título transferido desconto";
						case 52: return "52-Cobrado baixa manual";
						case 53: return "53-Baixa por acerto cliente";
						case 54: return "54-Tarifa baixa por contabilidade";
						case 55: return "55-BIFAX";
						case 56: return "56-Consulta informações via internet";
						case 57: return "57-Arquivo retorno via internet";
						case 58: return "58-Tarifa emissão Papeleta";
						case 59: return "59-Tarifa fornec papeleta semi preenchida";
						case 60: return "60-Acondicionador de papeletas (RPB)S";
						case 61: return "61-Acond. De papelatas (RPB)s PERSONAL";
						case 62: return "62-Papeleta formulário branco";
						case 63: return "63-Formulário A4 serrilhado";
						case 64: return "64-Fornecimento de softwares transmiss";
						case 65: return "65-Fornecimento de softwares consulta";
						case 66: return "66-Fornecimento Micro Completo";
						case 67: return "67-Fornecimento MODEN";
						case 68: return "68-Fornecimento de máquina FAX";
						case 69: return "69-Fornecimento de maquinas oticas";
						case 70: return "70-Fornecimento de Impressoras";
						case 71: return "71-Reativação de título";
						case 72: return "72-Alteração de produto negociado";
						case 73: return "73-Tarifa emissao de contra recibo";
						case 74: return "74-Tarifa emissao 2ª via papeleta";
						case 75: return "75-Tarifa regravação arquivo retorno";
						case 76: return "76-Arq. Títulos a vencer mensal";
						case 77: return "77-Listagem auxiliar de crédito";
						case 78: return "78-Tarifa cadastro cartela instrução permanente";
						case 79: return "79-Canalização de Crédito";
						case 80: return "80-Cadastro de Mensagem Fixa";
						case 81: return "81-Tarifa reapresentação automática título";
						case 82: return "82-Tarifa registro título déb. Automático";
						case 83: return "83-Tarifa Rateio de Crédito";
						case 84: return "84-Emissão papeleta sem valor";
						case 85: return "85-Sem uso";
						case 86: return "86-Cadastro de reembolso de diferença";
						case 87: return "87-Relatório fluxo de pagto";
						case 88: return "88-Emissão Extrato mov. Carteira";
						case 89: return "89-Mensagem campo local de pagto";
						case 90: return "90-Cadastro Concessionária serv. Publ.";
						case 91: return "91-Classif. Extrato Conta Corrente";
						case 92: return "92-Contabilidade especial";
						case 93: return "93-Realimentação pagto";
						case 94: return "94-Repasse de Créditos";
						case 95: return "95-Tarifa reg. pagto Banco Postal";
						case 96: return "96-Tarifa reg. Pagto outras mídias";
						case 97: return "97-Tarifa Reg/Pagto – Net Empresa";
						case 98: return "98-Tarifa título pago vencido";
						case 99: return "99-TR Tít. Baixado por decurso prazo";
						case 100: return "100-Arquivo Retorno Antecipado";
						case 101: return "101-Arq retorno Hora/Hora";
						case 102: return "102-TR. Agendamento Déb Aut";
						case 103: return "103-TR. Tentativa cons Déb Aut";
						case 104: return "104-TR Crédito on-line";
						case 105: return "105-TR. Agendamento rat. Crédito";
						case 106: return "106-TR Emissão aviso rateio";
						case 107: return "107-Extrato de protesto";
						case 110: return "110-Tarifa reg/pagto Bradesco Expresso";
						default: return string.Format("{0:00} - Outros Motivos", codMotivo);
					}

				case TipoOcorrencia.RetornoOcorrenciasDoSacado:
					switch (codMotivo)
					{
						case 78: return "78-Sacado alega que faturamento e indevido";
						case 116: return "116-Sacado aceita/reconhece o faturamento";
						default: return string.Format("{0:00} - Outros Motivos", codMotivo);
					}

				case TipoOcorrencia.RetornoAlteracaoOutrosDadosRejeitada:
					switch (codMotivo)
					{
						case 1: return "01-Código do Banco inválido";
						case 4: return "04-Código de ocorrência não permitido para a carteira";
						case 5: return "05-Código da ocorrência não numérico";
						case 8: return "08-Nosso número inválido";
						case 15: return "15-Característica da cobrança incompatível";
						case 16: return "16-Data de vencimento inválido";
						case 17: return "17-Data de vencimento anterior a data de emissão";
						case 18: return "18-Vencimento fora do prazo de operação";
						case 24: return "24-Data de emissão Inválida";
						case 26: return "26-Código de juros de mora inválido";
						case 27: return "27-Valor/taxa de juros de mora inválido";
						case 28: return "28-Código de desconto inválido";
						case 29: return "29-Valor do desconto maior/igual ao valor do Título";
						case 30: return "30-Desconto a conceder não confere";
						case 31: return "31-Concessão de desconto já existente ( Desconto anterior )";
						case 32: return "32-Valor do IOF inválido";
						case 33: return "33-Valor do abatimento inválido";
						case 34: return "34-Valor do abatimento maior/igual ao valor do Título";
						case 38: return "38-Prazo para protesto inválido";
						case 39: return "39-Pedido de protesto não permitido para o Título";
						case 40: return "40-Título com ordem de protesto emitido";
						case 42: return "42-Código para baixa/devolução inválido";
						case 46: return "46-Tipo/número de inscrição do sacado inválidos";
						case 48: return "48-Cep Inválido";
						case 53: return "53-Tipo/Número de inscrição do sacador/avalista inválidos";
						case 54: return "54-Sacador/avalista não informado";
						case 57: return "57-Código da multa inválido";
						case 58: return "58-Data da multa inválida";
						case 60: return "60-Movimento para Título não cadastrado";
						case 79: return "79-Data de Juros de mora Inválida";
						case 80: return "80-Data do desconto inválida";
						case 85: return "85-Título com Pagamento Vinculado.";
						case 88: return "88-E-mail Sacado não lido no prazo 5 dias";
						case 91: return "91-E-mail sacado não recebido";
						default: return string.Format("{0:00} - Outros Motivos", codMotivo);
					}

				case TipoOcorrencia.RetornoComandoRecusado:
					switch (codMotivo)
					{
						case 1: return "01-Código do Banco inválido";
						case 02: return "02-Código do registro detalhe inválido";
						case 04: return "04-Código de ocorrência não permitido para a carteira";
						case 05: return "05-Código de ocorrência não numérico";
						case 07: return "07-Agência/Conta/dígito inválidos";
						case 08: return "08-Nosso número inválido";
						case 10: return "10-Carteira inválida";
						case 15: return "15-Características da cobrança incompatíveis";
						case 16: return "16-Data de vencimento inválida";
						case 17: return "17-Data de vencimento anterior a data de emissão";
						case 18: return "18-Vencimento fora do prazo de operação";
						case 20: return "20-Valor do título inválido";
						case 21: return "21-Espécie do Título inválida";
						case 22: return "22-Espécie não permitida para a carteira";
						case 24: return "24-Data de emissão inválida";
						case 28: return "28-Código de desconto via Telebradesco inválido";
						case 29: return "29-Valor do desconto maior/igual ao valor do Título";
						case 30: return "30-Desconto a conceder não confere";
						case 31: return "31-Concessão de desconto - Já existe desconto anterior";
						case 33: return "33-Valor do abatimento inválido";
						case 34: return "34-Valor do abatimento maior/igual ao valor do Título";
						case 36: return "36-Concessão abatimento - Já existe abatimento anterior";
						case 38: return "38-Prazo para protesto inválido";
						case 39: return "39-Pedido de protesto não permitido para o Título";
						case 40: return "40-Título com ordem de protesto emitido";
						case 41: return "41-Pedido cancelamento/sustação para Título sem instrução de protesto";
						case 42: return "42-Código para baixa/devolução inválido";
						case 45: return "45-Nome do Sacado não informado";
						case 46: return "46-Tipo/número de inscrição do Sacado inválidos";
						case 47: return "47-Endereço do Sacado não informado";
						case 48: return "48-CEP Inválido";
						case 50: return "50-CEP referente a um Banco correspondente";
						case 53: return "53-Tipo de inscrição do sacador avalista inválidos";
						case 60: return "60-Movimento para Título não cadastrado";
						case 85: return "85-Título com pagamento vinculado";
						case 86: return "86-Seu número inválido";
						case 94: return "94-Título Penhorado – Instrução Não Liberada pela Agência";
						default: return string.Format("{0:00} - Outros Motivos", codMotivo);
					}

				case TipoOcorrencia.RetornoDesagendamentoDebitoAutomatico:
					switch (codMotivo)
					{
						case 81: return "81-Tentativas esgotadas, baixado";
						case 82: return "82-Tentativas esgotadas, pendente";
						case 83: return "83-Cancelado pelo Sacado e Mantido Pendente, conforme negociação";
						case 84: return "84-Cancelado pelo sacado e baixado, conforme negociação";
						default: return string.Format("{0:00} - Outros Motivos", codMotivo);
					}

                default: return string.Format("{0:00} - Outros Motivos", codMotivo);
            }
        }

		/// <summary>
		/// Calculars the digito verificador.
		/// </summary>
		/// <param name="titulo">The titulo.</param>
		/// <returns>System.String.</returns>
        public override string CalcularDigitoVerificador(Titulo titulo)
        {
			var calcularDigito = new Func<string, string>(aNumero =>
			{
				Modulo.CalculoPadrao();
				Modulo.Documento = aNumero.Trim();
				Modulo.Calcular();

				return Modulo.DigitoFinal.ToString();
			});

			// numero base para o calculo do primeiro e segundo digitos
			var aNumeroDoc = titulo.NossoNumero.Right(13).ZeroFill(13);

			// Calculo do primeiro digito
			var aNumeroBase = aNumeroDoc;
			var aDigito = calcularDigito(aNumeroDoc);
			var aDigito1 = aDigito + "4";

			// calculo do segundo digito
			var vencimento = titulo.Vencimento.ToString("ddMMyy");
			var cedente = Banco.Parent.Cedente.CodigoCedente.ToDecimal();
			var numero  = (aNumeroBase + aDigito1).ToDecimal();
			
			aNumeroBase = numero + cedente + vencimento;
			var aDigito2  = calcularDigito(aNumeroBase);

			var ret = aDigito1 + aDigito2;

            return ret;
        }

		/// <summary>
		/// Calculars the tam maximo nosso numero.
		/// </summary>
		/// <param name="carteira">The carteira.</param>
		/// <param name="nossoNumero">The nosso numero.</param>
		/// <returns>System.Int32.</returns>
		/// <exception cref="ACBrException">HSBC requer que o Convênio do Cedente seja informado.
		/// or
		/// HSBC requer que a carteira seja informada antes do Nosso Número.</exception>
		/// <exception cref="ACBrException">HSBC requer que o Convênio do Cedente seja informado.
		/// or
		/// HSBC requer que a carteira seja informada antes do Nosso Número.</exception>
        public override int CalcularTamMaximoNossoNumero(string carteira, string nossoNumero = "")
        {
            var ret = TamanhoMaximoNossoNum;
			
			Guard.Against<ACBrException>(carteira.IsEmpty(), "Banco HSBC requer que a carteira seja informada antes do Nosso Número.");

			if (carteira.Trim() != "CSB" && carteira.Trim() != "1") 
				return ret;

			ret = 5;
			TamanhoMaximoNossoNum = 5;

			return ret;
		}

		/// <summary>
		/// Montars the campo codigo cedente.
		/// </summary>
		/// <param name="titulo">The titulo.</param>
		/// <returns>System.String.</returns>
        public override string MontarCampoCodigoCedente(Titulo titulo)
		{
			if (titulo.Carteira.Trim() == "CSB" || titulo.Carteira.Trim() == "1")
				return string.Format("{0}-{1}", titulo.Parent.Cedente.Agencia, titulo.Parent.Cedente.CodigoCedente);
			
			return titulo.Parent.Cedente.CodigoCedente;
		}

		/// <summary>
		/// Montars the campo nosso numero.
		/// </summary>
		/// <param name="titulo">The titulo.</param>
		/// <returns>System.String.</returns>
		public override string MontarCampoNossoNumero(Titulo titulo)
		{
			if (titulo.Carteira.Trim() == "CSB" || titulo.Carteira.Trim() == "1")
			{
				var wNossoNumero = titulo.NossoNumero.Length < 6 ?
					string.Format("{0}{1}", titulo.Parent.Cedente.Convenio.ZeroFill(5), 
					titulo.NossoNumero.Right(5)) : titulo.NossoNumero.Right(10);

				Modulo.CalculoPadrao();
				Modulo.MultiplicadorFinal = 7;
				Modulo.Documento = wNossoNumero;
				Modulo.Calcular();

				return wNossoNumero.Right(10) + Modulo.DigitoFinal;
			}
			
			return string.Format("{0}-{1}", titulo.NossoNumero, CalcularDigitoVerificador(titulo));
		}

		/// <summary>
		/// Montars the codigo barras.
		/// </summary>
		/// <param name="titulo">The titulo.</param>
		/// <returns>System.String.</returns>
		/// <exception cref="ACBrException">Carteira Inválida.\r\nUtilize \CSB\, \CNR\, \1\ ou \2\</exception>
        public override string MontarCodigoBarras(Titulo titulo)
        {
			var aCarteira = string.Empty;
            if (titulo.Carteira == "CSB")
				aCarteira = "1";
			else if(titulo.Carteira == "CNR")
				aCarteira = "2";
			else if (titulo.Carteira != "1" && titulo.Carteira != "2")
				throw new ACBrException("Carteira Inválida.\r\nUtilize \"CSB\", \"CNR\", \"1\" ou \"2\"") ;

			var aNossoNumero = MontarCampoNossoNumero(titulo);

			var parte1 = titulo.Parent.Banco.Numero + "9";
			string parte2;

			if (aCarteira == "1")
			{
				//CSB' Cobranca Registrada
				parte2 = string.Format("{0}{1}{2}{3}{4}00", titulo.Vencimento.CalcularFatorVencimento(),
				   titulo.ValorDocumento.ToDecimalString(10), aNossoNumero.ZeroFill(13).Right(11),       // precisa passar nosso numero + digito
				   titulo.Parent.Cedente.Agencia.ZeroFill(4), titulo.Parent.Cedente.Conta[1] == '0' ?
				   titulo.Parent.Cedente.Conta.OnlyNumbers().Right(6) + titulo.Parent.Cedente.ContaDigito :
				   titulo.Parent.Cedente.Conta.OnlyNumbers().ZeroFill(7));
			}
			else
			{
				//'CNR' Cobranca Nao Registrada
				parte2 = string.Format("{0}{1}{2}{3}{4}", titulo.Vencimento.CalcularFatorVencimento(),
				   titulo.ValorDocumento.ToDecimalString(10), titulo.Parent.Cedente.CodigoCedente.Trim().ZeroFill(7),
				   aNossoNumero.Right(13).ZeroFill(13), titulo.Vencimento.ToJulianDate());
			}

			parte2 += aCarteira;
			var digito = CalcularDigitoCodigoBarras(parte1 + parte2);

			return string.Format("{0}{1}{2}", parte1, digito, parte2);
		}

		/// <summary>
		/// Gerars the registro header400.
		/// </summary>
		/// <param name="numeroRemessa">The numero remessa.</param>
		/// <param name="aRemessa">A remessa.</param>
        public override void GerarRegistroHeader400(int numeroRemessa, List<string> aRemessa)
        {
            var aAgencia = Banco.Parent.Cedente.Agencia.OnlyNumbers().ZeroFill(4);
            var aConta  = Banco.Parent.Cedente.Conta.OnlyNumbers();
			aConta = (aConta + Banco.Parent.Cedente.ContaDigito).ZeroFill(11);

            var wLinha = new StringBuilder();
            wLinha.Append('0');                                             // ID do Registro
            wLinha.Append('1');                                             // ID do Arquivo( 1 - Remessa)
            wLinha.Append("REMESSA");                                       // Literal de Remessa
            wLinha.Append("01");                                            // Código do Tipo de Serviço
            wLinha.Append("COBRANCA".FillLeft(15));                         // Descrição do tipo de serviço
			wLinha.Append("0");										        // Zero
            wLinha.Append(aAgencia);                                        // Agencia cedente
            wLinha.Append("55");								            // Sub-Conta
            wLinha.Append(aConta);                                          // Conta Corrente 
            wLinha.Append("".FillLeft(2));                                  // Uso do banco
            wLinha.Append(Banco.Parent.Cedente.Nome.FillLeft(30));          // Nome da Empresa
            wLinha.Append("399");                                           // Número do Banco na compensação
            wLinha.Append("HSBC".FillLeft(15));                             // Nome do Banco por extenso
            wLinha.AppendFormat("{0:ddMMyy}",DateTime.Now);                 // Data de geração do arquivo
            wLinha.Append("01600");                                         // Densidade de gravação
            wLinha.Append("BPI");                                           // Literal  Densidade
            wLinha.Append("".FillLeft(2));                                  // Uso do banco
            wLinha.Append("LANCV08");                                       // Sigla Layout
            wLinha.Append("".FillLeft(277));                                // Uso do Banco
            wLinha.Append("000001");                                        // Nr. Sequencial do registro-informar 000001

            aRemessa.Add(wLinha.ToString().ToUpper());

        }

		/// <summary>
		/// Gerars the registro transacao400.
		/// </summary>
		/// <param name="titulo">The titulo.</param>
		/// <param name="aRemessa">A remessa.</param>
		public override void GerarRegistroTransacao400(Titulo titulo, List<string> aRemessa)
		{
			//Pegando Código da Ocorrencia
			string ocorrencia;
			switch (titulo.OcorrenciaOriginal.Tipo)
			{
				case TipoOcorrencia.RemessaBaixar:
					ocorrencia = "02"; //Pedido de Baixa
					break;

				case TipoOcorrencia.RemessaConcederAbatimento:
					ocorrencia = "04"; //Concessão de Abatimento
					break;

				case TipoOcorrencia.RemessaCancelarAbatimento:
					ocorrencia = "05"; //Cancelamento de Abatimento concedido}
					break;

				case TipoOcorrencia.RemessaAlterarVencimento:
					ocorrencia = "06"; //Alteração de vencimento
					break;

				case TipoOcorrencia.RemessaAlterarNumeroControle:
					ocorrencia = "08"; //Alteração de seu número
					break;

				case TipoOcorrencia.RemessaProtestar:
					ocorrencia = "09"; //Pedido de protesto
					break;

				case TipoOcorrencia.RemessaCancelarInstrucaoProtestoBaixa:
					ocorrencia = "18"; //Sustar protesto e baixar
					break;

				case TipoOcorrencia.RemessaCancelarInstrucaoProtesto:
					ocorrencia = "19"; //Alteração de nome e endereço do Sacado
					break;

				case TipoOcorrencia.RemessaOutrasOcorrencias:
					ocorrencia = "31"; //Alteração de Outros Dados
					break;

				default:
					ocorrencia = "01"; //Remessa
					break;
			}

			//Pegando Tipo de Boleto
			string tipoBoleto;
			switch (titulo.Parent.Cedente.ResponEmissao)
			{
				case ResponEmissao.CliEmite:
					tipoBoleto = " ";
					break;

				default:
					tipoBoleto = "S";
					break;
			}

			//Pegando o tipo de EspecieDoc
			string aEspecie;
			switch (titulo.EspecieDoc.Trim())
			{
				case "DP":
					aEspecie = "01";
					break;

				case "NP":
					aEspecie = "02";
					break;

				case "NS":
					aEspecie = "03";
					break;

				case "RC":
					aEspecie = "05";
					break;

				case "DS":
					aEspecie = "10";
					break;

				case "SD":
					aEspecie = "08";
					break;

				case "CE":
					aEspecie = "09";
					break;

				case "PD":
					aEspecie = "98";
					break;

				default:
					aEspecie = titulo.EspecieDoc;
					break;
			}

			//Pegando Tipo de Sacado}
			string aTipoSacado;
			switch (titulo.Sacado.Pessoa)
			{
				case Pessoa.Fisica:
					aTipoSacado = "01";
					break;

				case Pessoa.Juridica:
					aTipoSacado = "02";
					break;

				default:
					aTipoSacado = "99";
					break;
			}

			//Codigo desnecessario ?
			//var mensagemCedente = titulo.Mensagem.AsString();
			//if (mensagemCedente.Length > 60)
			//	mensagemCedente = mensagemCedente.Substring(1, 60);

			var contaDigito = titulo.Parent.Cedente.Conta.OnlyNumbers();
			contaDigito += titulo.Parent.Cedente.ContaDigito;
			contaDigito = contaDigito.ZeroFill(11);

			var diasprotesto = titulo.DataProtesto.HasValue ? string.Format("{0:00}", 
				titulo.DataProtesto.Value.Date.Subtract(titulo.Vencimento.Date).Days) : "  ";

			var wLinha = new StringBuilder();
			wLinha.Append('1');                                                            //ID Registro
			wLinha.Append("02");                                                           //Código de Inscrição
			wLinha.Append(titulo.Parent.Cedente.CNPJCPF.OnlyNumbers().ZeroFill(14));       //Número de inscrição do Cliente (CPF/CNPJ)
			wLinha.Append('0');                                                            //Zero
			wLinha.Append(titulo.Parent.Cedente.Agencia.OnlyNumbers().ZeroFill(4));        //Agencia cedente
			wLinha.Append("55");                                                           //Sub-Conta
			wLinha.Append(contaDigito);
			wLinha.Append("".FillLeft(2));                                                 //uso banco
			wLinha.Append(titulo.SeuNumero.FillLeft(25));                                  //Numero de Controle do Participante
			wLinha.Append(MontarCampoNossoNumero(titulo).OnlyNumbers());                   //Nosso Numero tam 10 + digito tam 1
			wLinha.Append(titulo.DataDesconto.HasValue ?
				titulo.DataDesconto.Value.ToString("ddMMyy") : "000000");                  //data limite para desconto (2)
			wLinha.Append(titulo.ValorDesconto.ToDecimalString(11));                       //valor desconto (2)
			wLinha.Append(titulo.DataDesconto.HasValue ?
						 titulo.DataDesconto.Value.ToString("ddMMyy") : "000000");         //data limite para desconto (3)
			wLinha.Append(titulo.ValorDesconto.ToDecimalString(11));                       //valor desconto (3)
			wLinha.Append('1');                                                            //1 - Cobrança Simples
			wLinha.Append(ocorrencia.ZeroFill(2));                                         //ocorrencia
			wLinha.Append(titulo.NumeroDocumento.FillLeft(10));                            //numero da duplicata
			wLinha.AppendFormat("{0:ddMMyy}", titulo.Vencimento);                          //vencimento
			wLinha.Append(titulo.ValorDocumento.ToDecimalString());                        //valor do titulo
			wLinha.Append("399");                                                          //banco cobrador
			wLinha.Append("00000");                                                        //Agência depositaria
			wLinha.Append(aEspecie.FillLeft(2) + 'N');                                     //Especie do documento + Idntificação(valor fixo N)
			wLinha.AppendFormat("{0:ddMMyy}", titulo.DataDocumento);                       //Data de Emissão
			wLinha.Append(titulo.Instrucao1.ZeroFill(2));                                  //instrução 1
			wLinha.Append(titulo.Instrucao2.ZeroFill(2));                                  //instrução 2
			wLinha.Append(titulo.ValorMoraJuros.ToDecimalString());                        //Juros de Mora
			wLinha.Append(titulo.DataDesconto.HasValue ?
				titulo.DataDesconto.Value.ToString("ddMMyy") : "000000");                 //data limite para desconto  //ADICIONEI ZERO ESTAVA E BRANCO ALFEU
			wLinha.Append(titulo.ValorDesconto.ToDecimalString());                         //valor do desconto
			wLinha.Append(titulo.ValorIOF.ToDecimalString());							   //Valor do  IOF
			wLinha.Append(titulo.ValorAbatimento.ToDecimalString());					   //valor do abatimento
			wLinha.Append(aTipoSacado);                                                    //codigo de inscrição do sacado
			wLinha.Append(titulo.Sacado.CNPJCPF.OnlyNumbers().ZeroFill(14));               //numero de inscrição do sacado
			wLinha.Append(titulo.Sacado.NomeSacado.FillLeft(40));                          //nome sacado
			wLinha.Append((titulo.Sacado.Logradouro + titulo.Sacado.Numero +
					   titulo.Sacado.Complemento).FillLeft(38));                           //endereço sacado
			wLinha.Append("".FillLeft(2));			                                       //Instrução de  não recebimento do bloqueto
			wLinha.Append(titulo.Sacado.Bairro.FillLeft(12));                              //bairro sacado
			wLinha.Append(titulo.Sacado.CEP.OnlyNumbers().ZeroFill(8));                    //cep do sacado
			wLinha.Append(titulo.Sacado.Cidade.FillLeft(15));                              //cidade do sacado
			wLinha.Append(titulo.Sacado.UF.FillLeft(2));                                   //uf do sacado
			wLinha.Append(titulo.Sacado.Avalista.FillLeft(39));                            //nome do sacado
			wLinha.Append(tipoBoleto);                                                     //Tipo de Bloqueto
			wLinha.Append(diasprotesto);                                                   //nro de dias para protesto
			wLinha.Append("9");                                                            //Tipo Moeda
			wLinha.AppendFormat("{0:000000}", aRemessa.Count + 1);

			aRemessa.Add(wLinha.ToString().ToUpper());
		}

		/// <summary>
		/// Gerars the registro trailler400.
		/// </summary>
		/// <param name="aRemessa">A remessa.</param>
        public override void GerarRegistroTrailler400(List<string> aRemessa)
        {
            var wLinha = new StringBuilder();
            wLinha.Append('9');
            wLinha.Append("".FillRight(393));                       // ID Registro
            wLinha.AppendFormat("{0:000000}", aRemessa.Count + 1);  // Contador de Registros
            
            aRemessa.Add(wLinha.ToString().ToUpper());
        }

		/// <summary>
		/// Lers the retorno400.
		/// </summary>
		/// <param name="aRetorno">A retorno.</param>
		/// <exception cref="ACBrException">@Agencia\Conta do arquivo inválido</exception>
		/// <exception cref="ACBrException">@Agencia\Conta do arquivo inválido</exception>
        public override void LerRetorno400(List<string> aRetorno)
        {
			Guard.Against<ACBrException>(aRetorno[0].ExtrairInt32DaPosicao(77, 79) != Numero,
				"{0} não é um arquivo de retorno do {1}", Banco.Parent.NomeArqRetorno, Nome);

			var rCedente = aRetorno[0].ExtrairDaPosicao(47, 76);
			var rCodigoCedente = aRetorno[0].ExtrairInt32DaPosicao(109, 118);
			var rAgencia = aRetorno[0].ExtrairDaPosicao(28, 31);
			var rConta = aRetorno[0].ExtrairDaPosicao(38, 43);
			var rDigitoConta  = aRetorno[0].ExtrairDaPosicao(44);

			var cnr = aRetorno[0].ExtrairDaPosicao(12, 26) == "COBRANCA CNR";
			
			Banco.Parent.NumeroArquivo = aRetorno[0].ExtrairInt32DaPosicao(389, 393);
			Banco.Parent.DataArquivo = aRetorno[0].ExtrairDataDaPosicao(95, 100, "ddMMyy");

			if (!cnr)
				Banco.Parent.DataCreditoLanc = aRetorno[0].ExtrairDataDaPosicao(120, 125, "ddMMyy");

			string rCNPJCPF;
			switch (aRetorno[1].ExtrairInt32DaPosicao(2, 3))
			{
				case 11:
					rCNPJCPF = aRetorno[1].ExtrairDaPosicao(7, 17);
					break;

				case 14:
					rCNPJCPF = aRetorno[1].ExtrairDaPosicao(4, 17);
					break;

				default:
					rCNPJCPF = string.Empty;
					break;
			}

			if (!rCNPJCPF.IsEmpty())
			{
				Guard.Against<ACBrException>(
					Banco.Parent.LeCedenteRetorno && rCNPJCPF != Banco.Parent.Cedente.CNPJCPF.OnlyNumbers(),
					"CNPJ\\CPF do arquivo inválido");
			}

			Guard.Against<ACBrException>(
				!Banco.Parent.LeCedenteRetorno && rCodigoCedente != Banco.Parent.Cedente.CodigoCedente.OnlyNumbers().ToInt32(),
				"Cedente do arquivo inválido{0}Informado = {1}{0}Esperado = {2}", Environment.NewLine,
				Banco.Parent.Cedente.CodigoCedente.OnlyNumbers(), rCodigoCedente);

			Guard.Against<ACBrException>(
				!Banco.Parent.LeCedenteRetorno && rAgencia != Banco.Parent.Cedente.Agencia.OnlyNumbers(),
				"Agencia do arquivo inválido{0}Informado = {1}{0}Esperado = {2}", Environment.NewLine,
				Banco.Parent.Cedente.Agencia.OnlyNumbers(), rAgencia);

			Guard.Against<ACBrException>(
				!Banco.Parent.LeCedenteRetorno && rConta != Banco.Parent.Cedente.Conta.OnlyNumbers(),
				"Conta do arquivo inválido{0}Informado = {1}{0}Esperado = {2}", Environment.NewLine,
				Banco.Parent.Cedente.Conta.OnlyNumbers(), rConta);

			if (Banco.Parent.LeCedenteRetorno)
			{
				Banco.Parent.Cedente.Nome = rCedente;
				if (!cnr)
					Banco.Parent.Cedente.CNPJCPF = rCNPJCPF;
				
				Banco.Parent.Cedente.Agencia = rAgencia;
				Banco.Parent.Cedente.AgenciaDigito = "";
				Banco.Parent.Cedente.Conta = rConta;
				Banco.Parent.Cedente.ContaDigito = rDigitoConta;
				switch (aRetorno[1].ExtrairInt32DaPosicao(2, 3))
				{
					case 11:
						Banco.Parent.Cedente.TipoInscricao = PessoaCedente.Fisica;
						break;

					default:
						Banco.Parent.Cedente.TipoInscricao = PessoaCedente.Juridica;
						break;
				}
			}

			Banco.Parent.ListadeBoletos.Clear();
			for (var i = 1; i < aRetorno.Count - 2; i++)
			{
				var linha = aRetorno[i];
				if (linha.ExtrairDaPosicao(1, 1) != "1")
					continue;

				var titulo = Banco.Parent.CriarTituloNaLista();
				titulo.SeuNumero = cnr ? linha.ExtrairDaPosicao(117, 122) : linha.ExtrairDaPosicao(38, 62);

				titulo.NumeroDocumento = linha.ExtrairDaPosicao(117, 126);

				var codOcorrencia = linha.ExtrairInt32OpcionalDaPosicao(109, 110).HasValue ?
					                 linha.ExtrairInt32DaPosicao(109, 110) : 0;

				titulo.OcorrenciaOriginal.Tipo = CodOcorrenciaToTipo(codOcorrencia);

				if (codOcorrencia == 19)
				{
					var motivoLinha = linha.ExtrairDaPosicao(295);
					if (motivoLinha == "A")
					{
						titulo.MotivoRejeicaoComando.Add(motivoLinha);
						titulo.DescricaoMotivoRejeicaoComando.Add("A - Aceito");
					}
					else
					{
						titulo.MotivoRejeicaoComando.Add(motivoLinha);
						titulo.DescricaoMotivoRejeicaoComando.Add("D - Desprezado");
					}
				}
				else
				{
					var ocorrencia = titulo.OcorrenciaOriginal.Tipo;
					var motivoLinha = 319;
					for (var j = 0; j < 4; j++)
					{
						var codMotivo = linha.ExtrairInt32OpcionalDaPosicao(motivoLinha, motivoLinha + 1).HasValue ?
										linha.ExtrairInt32DaPosicao(motivoLinha, motivoLinha + 1) : 0;

						//Somente estas ocorrencias possuem motivos 00
						if (j == 0 && codOcorrencia.IsIn(2, 6, 9, 10, 15, 17))
						{
							titulo.MotivoRejeicaoComando.Add(codMotivo.ToString());
							titulo.DescricaoMotivoRejeicaoComando.Add(CodMotivoRejeicaoToDescricao(ocorrencia, codMotivo));
						}
						else
						{
							//Apos o 1º motivo os 00 significam que não existe mais motivo
							if (codMotivo == 0)
							{
								titulo.MotivoRejeicaoComando.Add("00");
								titulo.DescricaoMotivoRejeicaoComando.Add("Sem Motivo");
							}
							else
							{
								titulo.MotivoRejeicaoComando.Add(codMotivo.ToString());
								titulo.DescricaoMotivoRejeicaoComando.Add(CodMotivoRejeicaoToDescricao(ocorrencia, codMotivo));
							}
						}

						//Incrementa a coluna dos motivos
						motivoLinha += 2;
					}
				}

				titulo.DataOcorrencia = linha.ExtrairDataDaPosicao(111, 116, "ddMMyy");
				titulo.Vencimento = linha.ExtrairDataDaPosicao(147, 152, "ddMMyy");
				if (cnr)
					titulo.DataCredito = linha.ExtrairDataDaPosicao(83, 88, "ddMMyy");

				titulo.ValorDocumento = linha.ExtrairDecimalDaPosicao(153, 165);
				titulo.ValorDespesaCobranca = linha.ExtrairDecimalDaPosicao(176, 188);
				titulo.ValorAbatimento = linha.ExtrairDecimalDaPosicao(228, 240);
				titulo.ValorDesconto = linha.ExtrairDecimalDaPosicao(241, 253);
				titulo.ValorRecebido = linha.ExtrairDecimalDaPosicao(254, 266);
				titulo.ValorMoraJuros = linha.ExtrairDecimalDaPosicao(267, 279);

				titulo.Carteira = linha.ExtrairDaPosicao(108);

				titulo.NossoNumero = cnr ? linha.ExtrairDaPosicao(63, 75) : 
					                       linha.ExtrairDaPosicao(127, 137);
			}
        }

        #endregion Methods
    }
}