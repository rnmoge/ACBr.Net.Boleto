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
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
#region COM Interop Attributes

#if COM_INTEROP
using System.Runtime.InteropServices;
#endif


#endregion COM Interop Attributes
using ACBr.Net.Core;

/// <summary>
/// ACBr.Net.Boleto namespace.
/// </summary>
namespace ACBr.Net.Boleto
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
		/// <param name="Tipo">Tipo de ocorrencia</param>
		/// <returns>Descrição da ocorrencia</returns>
        public override string TipoOcorrenciaToDescricao(TipoOcorrencia Tipo)
        {
            var CodOcorrencia = TipoOCorrenciaToCod(Tipo).ToInt32();
            switch (CodOcorrencia)
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
                default: return string.Format("{0:00}-Outras Ocorrencias", CodOcorrencia);
			}
        }

		/// <summary>
		/// Transforma um codigo de ocorrencia em um Tipo de ocorrencia.
		/// </summary>
		/// <param name="CodOcorrencia">Codigo da ocorrencia.</param>
		/// <returns>Retorna um TipoOcorrencia.</returns>
        public override TipoOcorrencia CodOcorrenciaToTipo(int CodOcorrencia)
        {
            switch (CodOcorrencia)
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
		/// <param name="Tipo">The tipo.</param>
		/// <returns>System.String.</returns>
        public override string TipoOCorrenciaToCod(TipoOcorrencia Tipo)
        {
            switch (Tipo)
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
		/// <param name="Tipo">The tipo.</param>
		/// <param name="CodMotivo">The cod motivo.</param>
		/// <returns>System.String.</returns>
        public override string CodMotivoRejeicaoToDescricao(TipoOcorrencia Tipo, int CodMotivo)
        {
            switch (Tipo)
            {
				case TipoOcorrencia.RetornoRegistroConfirmado:
                    switch (CodMotivo)
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
                        default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
                    }

				case TipoOcorrencia.RetornoRegistroRecusado:
					switch (CodMotivo)
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
						default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
					}

				case TipoOcorrencia.RetornoLiquidadoEmCartorio:
				case TipoOcorrencia.RetornoLiquidadoAposBaixaOuNaoRegistro:
				case TipoOcorrencia.RetornoLiquidado:
					switch (CodMotivo)
					{
						case 0: return "00-Titulo pago com dinheiro";
						case 15: return "15-Titulo pago com cheque";
						case 42: return "42-Rateio nao efetuado";
						default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
					}

				case TipoOcorrencia.RetornoBaixadoViaArquivo:
					switch (CodMotivo)
					{
						case 0: return "00-Ocorrencia aceita";
						case 10: return "10=Baixa comandada pelo cliente";
						default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
					}

				case TipoOcorrencia.RetornoBaixadoInstAgencia:
					switch (CodMotivo)
					{
						case 0: return "00-Baixado conforme instrucoes na agencia";
						case 14: return "14-Titulo protestado";
						case 15: return "15-Titulo excluido";
						case 16: return "16-Titulo baixado pelo banco por decurso de prazo";
						case 20: return "20-Titulo baixado e transferido para desconto";
						default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
					}

				case TipoOcorrencia.RetornoEntradaRejeitaCEPIrregular:
					switch (CodMotivo)
					{
						case 48: return "48-CEP invalido";
						default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
					}

				case TipoOcorrencia.RetornoBaixaRejeitada:
					switch (CodMotivo)
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
						default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
					}

				case TipoOcorrencia.RetornoDebitoTarifas:
					switch (CodMotivo)
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
						default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
					}

				case TipoOcorrencia.RetornoOcorrenciasDoSacado:
					switch (CodMotivo)
					{
						case 78: return "78-Sacado alega que faturamento e indevido";
						case 116: return "116-Sacado aceita/reconhece o faturamento";
						default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
					}

				case TipoOcorrencia.RetornoAlteracaoOutrosDadosRejeitada:
					switch (CodMotivo)
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
						default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
					}

				case TipoOcorrencia.RetornoComandoRecusado:
					switch (CodMotivo)
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
						default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
					}

				case TipoOcorrencia.RetornoDesagendamentoDebitoAutomatico:
					switch (CodMotivo)
					{
						case 81: return "81-Tentativas esgotadas, baixado";
						case 82: return "82-Tentativas esgotadas, pendente";
						case 83: return "83-Cancelado pelo Sacado e Mantido Pendente, conforme negociação";
						case 84: return "84-Cancelado pelo sacado e baixado, conforme negociação";
						default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
					}

                default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
            }
        }

		/// <summary>
		/// Calculars the digito verificador.
		/// </summary>
		/// <param name="Titulo">The titulo.</param>
		/// <returns>System.String.</returns>
        public override string CalcularDigitoVerificador(Titulo Titulo)
        {
			var CalcularDigito = new Func<string, string>((ANumero) =>
			{
				Modulo.CalculoPadrao();
				Modulo.Documento = ANumero.Trim();
				Modulo.Calcular();

				return Modulo.DigitoFinal.ToString();
			});

            string ret = "0";

            // numero base para o calculo do primeiro e segundo digitos
			var ANumeroDoc = Titulo.NossoNumero.Right(13).ZeroFill(13);

			// Calculo do primeiro digito
			var ANumeroBase = ANumeroDoc;
			var ADigito = CalcularDigito(ANumeroDoc);
			var ADigito1 = ADigito + "4";

			// calculo do segundo digito
			var Vencimento = Titulo.Vencimento.ToString("ddMMyy");
			var Cedente = Banco.Parent.Cedente.CodigoCedente.ToDecimal();
			var Numero  = (ANumeroBase + ADigito1).ToDecimal();
			
			ANumeroBase = Numero + Cedente + Vencimento;
			var ADigito2  = CalcularDigito(ANumeroBase);

			ret = ADigito1 + ADigito2;

            return ret;
        }

		/// <summary>
		/// Calculars the tam maximo nosso numero.
		/// </summary>
		/// <param name="Carteira">The carteira.</param>
		/// <param name="NossoNumero">The nosso numero.</param>
		/// <returns>System.Int32.</returns>
		/// <exception cref="ACBr.Net.Core.ACBrException">HSBC requer que o Convênio do Cedente seja informado.
		/// or
		/// HSBC requer que a carteira seja informada antes do Nosso Número.</exception>
		/// <exception cref="ACBrException">HSBC requer que o Convênio do Cedente seja informado.
		/// or
		/// HSBC requer que a carteira seja informada antes do Nosso Número.</exception>
        public override int CalcularTamMaximoNossoNumero(string Carteira, string NossoNumero = "")
        {
            var ret = TamanhoMaximoNossoNum;
			
			if (string.IsNullOrEmpty(Carteira.Trim()))
				throw new ACBrException("Banco HSBC requer que a carteira seja informada antes do Nosso Número.");
			
			if (Carteira.Trim() == "CSB" || Carteira.Trim() == "1")
			{
				ret = 5;
				TamanhoMaximoNossoNum = 5;
			}

			return ret;
		}

		/// <summary>
		/// Montars the campo codigo cedente.
		/// </summary>
		/// <param name="Titulo">The titulo.</param>
		/// <returns>System.String.</returns>
        public override string MontarCampoCodigoCedente(Titulo Titulo)
        {
			if (Titulo.Carteira.Trim() == "CSB" || Titulo.Carteira.Trim() == "1")
				return String.Format("{0}-{1}", Titulo.Parent.Cedente.Agencia, Titulo.Parent.Cedente.CodigoCedente);
			else
				return Titulo.Parent.Cedente.CodigoCedente;
		}

		/// <summary>
		/// Montars the campo nosso numero.
		/// </summary>
		/// <param name="Titulo">The titulo.</param>
		/// <returns>System.String.</returns>
		public override string MontarCampoNossoNumero(Titulo Titulo)
		{
			if (Titulo.Carteira.Trim() == "CSB" || Titulo.Carteira.Trim() == "1")
			{
				string wNossoNumero;
				if (Titulo.NossoNumero.Length < 6)
					wNossoNumero = String.Format("{0}{1}", Titulo.Parent.Cedente.Convenio.ZeroFill(5), Titulo.NossoNumero.Right(5));
				else
					wNossoNumero = Titulo.NossoNumero.Right(10);

				Modulo.CalculoPadrao();
				Modulo.MultiplicadorFinal = 7;
				Modulo.Documento = wNossoNumero;
				Modulo.Calcular();

				return wNossoNumero.Right(10) + Modulo.DigitoFinal;
			}
			else
				return String.Format("{0}-{1}", Titulo.NossoNumero, CalcularDigitoVerificador(Titulo));
		}

		/// <summary>
		/// Montars the codigo barras.
		/// </summary>
		/// <param name="Titulo">The titulo.</param>
		/// <returns>System.String.</returns>
		/// <exception cref="ACBr.Net.Core.ACBrException">Carteira Inválida.\r\nUtilize \CSB\, \CNR\, \1\ ou \2\</exception>
        public override string MontarCodigoBarras(Titulo Titulo)
        {
			string ACarteira = string.Empty;
            if (Titulo.Carteira == "CSB")
				ACarteira = "1";
			else if(Titulo.Carteira == "CNR")
				ACarteira = "2";
			else if (Titulo.Carteira != "1" && Titulo.Carteira != "2")
				throw new ACBrException("Carteira Inválida.\r\nUtilize \"CSB\", \"CNR\", \"1\" ou \"2\"") ;

			string ANossoNumero = MontarCampoNossoNumero(Titulo);

			string Parte1 = Titulo.Parent.Banco.Numero + "9";
			string Parte2;

			if (ACarteira == "1")
			{
				//CSB' Cobranca Registrada
				Parte2 = string.Format("{0}{1}{2}{3}{4}00", Titulo.Vencimento.CalcularFatorVencimento(),
				   Titulo.ValorDocumento.ToRemessaString(10), ANossoNumero.ZeroFill(13).Right(11),       // precisa passar nosso numero + digito
				   Titulo.Parent.Cedente.Agencia.ZeroFill(4), Titulo.Parent.Cedente.Conta[1] == '0' ?
				   Titulo.Parent.Cedente.Conta.OnlyNumbers().Right(6) + Titulo.Parent.Cedente.ContaDigito :
				   Titulo.Parent.Cedente.Conta.OnlyNumbers().ZeroFill(7));
			}
			else
			{
				//'CNR' Cobranca Nao Registrada
				Parte2 = string.Format("{0}{1}{2}{3}{4}", Titulo.Vencimento.CalcularFatorVencimento(),
				   Titulo.ValorDocumento.ToRemessaString(10), Titulo.Parent.Cedente.CodigoCedente.Trim().ZeroFill(7),
				   ANossoNumero.Right(13).ZeroFill(13), Titulo.Vencimento.ToJulianDate());
			}

			Parte2 += ACarteira;
			var digito = CalcularDigitoCodigoBarras(Parte1 + Parte2);

			return String.Format("{0}{1}{2}", Parte1, digito, Parte2);
		}

		/// <summary>
		/// Gerars the registro header400.
		/// </summary>
		/// <param name="NumeroRemessa">The numero remessa.</param>
		/// <param name="ARemessa">A remessa.</param>
        public override void GerarRegistroHeader400(int NumeroRemessa, List<string> ARemessa)
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

            ARemessa.Add(wLinha.ToString().ToUpper());

        }

		/// <summary>
		/// Gerars the registro transacao400.
		/// </summary>
		/// <param name="Titulo">The titulo.</param>
		/// <param name="ARemessa">A remessa.</param>
		public override void GerarRegistroTransacao400(Titulo Titulo, List<string> ARemessa)
		{
			//Pegando Código da Ocorrencia
			string Ocorrencia;
			switch (Titulo.OcorrenciaOriginal.Tipo)
			{
				case TipoOcorrencia.RemessaBaixar:
					Ocorrencia = "02"; //Pedido de Baixa
					break;

				case TipoOcorrencia.RemessaConcederAbatimento:
					Ocorrencia = "04"; //Concessão de Abatimento
					break;

				case TipoOcorrencia.RemessaCancelarAbatimento:
					Ocorrencia = "05"; //Cancelamento de Abatimento concedido}
					break;

				case TipoOcorrencia.RemessaAlterarVencimento:
					Ocorrencia = "06"; //Alteração de vencimento
					break;

				case TipoOcorrencia.RemessaAlterarNumeroControle:
					Ocorrencia = "08"; //Alteração de seu número
					break;

				case TipoOcorrencia.RemessaProtestar:
					Ocorrencia = "09"; //Pedido de protesto
					break;

				case TipoOcorrencia.RemessaCancelarInstrucaoProtestoBaixa:
					Ocorrencia = "18"; //Sustar protesto e baixar
					break;

				case TipoOcorrencia.RemessaCancelarInstrucaoProtesto:
					Ocorrencia = "19"; //Alteração de nome e endereço do Sacado
					break;

				case TipoOcorrencia.RemessaOutrasOcorrencias:
					Ocorrencia = "31"; //Alteração de Outros Dados
					break;

				default:
					Ocorrencia = "01"; //Remessa
					break;
			}

			//Pegando Tipo de Boleto
			string TipoBoleto;
			switch (Titulo.Parent.Cedente.ResponEmissao)
			{
				case ResponEmissao.CliEmite:
					TipoBoleto = " ";
					break;

				default:
					TipoBoleto = "S";
					break;
			}

			//Pegando o tipo de EspecieDoc
			string aEspecie = string.Empty;
			if (Titulo.EspecieDoc.Trim() == "DP")
				aEspecie = "01";
			else if (Titulo.EspecieDoc.Trim() == "NP")
				aEspecie = "02";
			else if (Titulo.EspecieDoc.Trim() == "NS")
				aEspecie = "03";
			else if (Titulo.EspecieDoc.Trim() == "RC")
				aEspecie = "05";
			else if (Titulo.EspecieDoc.Trim() == "DS")
				aEspecie = "10";
			else if (Titulo.EspecieDoc.Trim() == "SD")
				aEspecie = "08";
			else if (Titulo.EspecieDoc.Trim() == "CE")
				aEspecie = "09";
			else if (Titulo.EspecieDoc.Trim() == "PD")
				aEspecie = "98";
			else
				aEspecie = Titulo.EspecieDoc;

			//Pegando Tipo de Sacado}
			string ATipoSacado;
			switch (Titulo.Sacado.Pessoa)
			{
				case Pessoa.Fisica:
					ATipoSacado = "01";
					break;

				case Pessoa.Juridica:
					ATipoSacado = "02";
					break;

				default:
					ATipoSacado = "99";
					break;
			}

			var MensagemCedente = string.Empty;
			foreach (string msg in Titulo.Mensagem)
				MensagemCedente += msg;

			if (MensagemCedente.Length > 60)
				MensagemCedente = MensagemCedente.Substring(1, 60);

			string ContaDigito = Titulo.Parent.Cedente.Conta.OnlyNumbers();
			ContaDigito += Titulo.Parent.Cedente.ContaDigito;
			ContaDigito = ContaDigito.ZeroFill(11);

			string diasprotesto;
			if (Titulo.DataProtesto.HasValue)
				diasprotesto = string.Format("{0:00}", Titulo.DataProtesto.Value.Date.Subtract(Titulo.Vencimento.Date).Days);
			else
				diasprotesto = "  ";

			var wLinha = new StringBuilder();
			wLinha.Append('1');                                                            //ID Registro
			wLinha.Append("02");                                                           //Código de Inscrição
			wLinha.Append(Titulo.Parent.Cedente.CNPJCPF.OnlyNumbers().ZeroFill(14));       //Número de inscrição do Cliente (CPF/CNPJ)
			wLinha.Append('0');                                                            //Zero
			wLinha.Append(Titulo.Parent.Cedente.Agencia.OnlyNumbers().ZeroFill(4));        //Agencia cedente
			wLinha.Append("55");                                                           //Sub-Conta
			wLinha.Append(ContaDigito);
			wLinha.Append("".FillLeft(2));                                                 //uso banco
			wLinha.Append(Titulo.SeuNumero.FillLeft(25));                                  //Numero de Controle do Participante
			wLinha.Append(MontarCampoNossoNumero(Titulo).OnlyNumbers());                   //Nosso Numero tam 10 + digito tam 1
			wLinha.Append(Titulo.DataDesconto.HasValue ?
				Titulo.DataDesconto.Value.ToString("ddMMyy") : "000000");                  //data limite para desconto (2)
			wLinha.Append(Titulo.ValorDesconto.ToRemessaString(11));                       //valor desconto (2)
			wLinha.Append(Titulo.DataDesconto.HasValue ?
						 Titulo.DataDesconto.Value.ToString("ddMMyy") : "000000");         //data limite para desconto (3)
			wLinha.Append(Titulo.ValorDesconto.ToRemessaString(11));                       //valor desconto (3)
			wLinha.Append('1');                                                            //1 - Cobrança Simples
			wLinha.Append(Ocorrencia.ZeroFill(2));                                         //ocorrencia
			wLinha.Append(Titulo.NumeroDocumento.FillLeft(10));                            //numero da duplicata
			wLinha.AppendFormat("{0:ddMMyy}", Titulo.Vencimento);                          //vencimento
			wLinha.Append(Titulo.ValorDocumento.ToRemessaString());                        //valor do titulo
			wLinha.Append("399");                                                          //banco cobrador
			wLinha.Append("00000");                                                        //Agência depositaria
			wLinha.Append(aEspecie.FillLeft(2) + 'N');                                     //Especie do documento + Idntificação(valor fixo N)
			wLinha.AppendFormat("{0:ddMMyy}", Titulo.DataDocumento);                       //Data de Emissão
			wLinha.Append(Titulo.Instrucao1.ZeroFill(2));                                  //instrução 1
			wLinha.Append(Titulo.Instrucao2.ZeroFill(2));                                  //instrução 2
			wLinha.Append(Titulo.ValorMoraJuros.ToRemessaString());                        //Juros de Mora
			wLinha.Append(Titulo.DataDesconto.HasValue ?
				Titulo.DataDesconto.Value.ToString("ddMMyy") : "000000");                 //data limite para desconto  //ADICIONEI ZERO ESTAVA E BRANCO ALFEU
			wLinha.Append(Titulo.ValorDesconto.ToRemessaString());                         //valor do desconto
			wLinha.Append(Titulo.ValorIOF.ToRemessaString());							   //Valor do  IOF
			wLinha.Append(Titulo.ValorAbatimento.ToRemessaString());					   //valor do abatimento
			wLinha.Append(ATipoSacado);                                                    //codigo de inscrição do sacado
			wLinha.Append(Titulo.Sacado.CNPJCPF.OnlyNumbers().ZeroFill(14));               //numero de inscrição do sacado
			wLinha.Append(Titulo.Sacado.NomeSacado.FillLeft(40));                          //nome sacado
			wLinha.Append((Titulo.Sacado.Logradouro + Titulo.Sacado.Numero +
					   Titulo.Sacado.Complemento).FillLeft(38));                           //endereço sacado
			wLinha.Append("".FillLeft(2));			                                       //Instrução de  não recebimento do bloqueto
			wLinha.Append(Titulo.Sacado.Bairro.FillLeft(12));                              //bairro sacado
			wLinha.Append(Titulo.Sacado.CEP.OnlyNumbers().ZeroFill(8));                    //cep do sacado
			wLinha.Append(Titulo.Sacado.Cidade.FillLeft(15));                              //cidade do sacado
			wLinha.Append(Titulo.Sacado.UF.FillLeft(2));                                   //uf do sacado
			wLinha.Append(Titulo.Sacado.Avalista.FillLeft(39));                            //nome do sacado
			wLinha.Append(TipoBoleto);                                                     //Tipo de Bloqueto
			wLinha.Append(diasprotesto);                                                   //nro de dias para protesto
			wLinha.Append("9");                                                            //Tipo Moeda
			wLinha.AppendFormat("{0:000000}", ARemessa.Count + 1);

			ARemessa.Add(wLinha.ToString().ToUpper());
		}

		/// <summary>
		/// Gerars the registro trailler400.
		/// </summary>
		/// <param name="ARemessa">A remessa.</param>
        public override void GerarRegistroTrailler400(List<string> ARemessa)
        {
            var wLinha = new StringBuilder();
            wLinha.Append('9');
            wLinha.Append("".FillRight(393));                       // ID Registro
            wLinha.AppendFormat("{0:000000}", ARemessa.Count + 1);  // Contador de Registros
            
            ARemessa.Add(wLinha.ToString().ToUpper());
        }

		/// <summary>
		/// Lers the retorno400.
		/// </summary>
		/// <param name="ARetorno">A retorno.</param>
		/// <exception cref="ACBr.Net.Core.ACBrException">@Agencia\Conta do arquivo inválido</exception>
		/// <exception cref="ACBrException">@Agencia\Conta do arquivo inválido</exception>
        public override void LerRetorno400(List<string> ARetorno)
        {
			if (ARetorno[0].ExtrairInt32DaPosicao(77, 79) != Numero)
				throw new ACBrException(string.Format("{0} não é um arquivo de retorno do {1}",
													   Banco.Parent.NomeArqRetorno, Nome));
        }

		/// <summary>
		/// Gerars the registro header240.
		/// </summary>
		/// <param name="NumeroRemessa">The numero remessa.</param>
		/// <returns>System.String.</returns>
        public override string GerarRegistroHeader240(int NumeroRemessa)
        {
			return string.Empty;
        }

		/// <summary>
		/// Gerars the registro transacao240.
		/// </summary>
		/// <param name="Titulo">The titulo.</param>
		/// <returns>System.String.</returns>
        public override string GerarRegistroTransacao240(Titulo Titulo)
        {
			return string.Empty;
        }

		/// <summary>
		/// Gerars the registro trailler240.
		/// </summary>
		/// <param name="ARemessa">A remessa.</param>
		/// <returns>System.String.</returns>
        public override string GerarRegistroTrailler240(List<string> ARemessa)
        {
			return string.Empty;
        }

		/// <summary>
		/// Lers the retorno240.
		/// </summary>
		/// <param name="ARetorno">A retorno.</param>
		/// <exception cref="ACBr.Net.Core.ACBrException">@CNPJ\CPF do arquivo inválido</exception>
		/// <exception cref="ACBrException">@CNPJ\CPF do arquivo inválido</exception>
        public override void LerRetorno240(List<string> ARetorno)
        {
            if(ARetorno[0].ExtrairInt32DaPosicao(1, 3) != Numero)
                throw new ACBrException(string.Format("{0} não é um arquivo de retorno do {1}'", 
                    Banco.Parent.NomeArqRetorno, Nome));
            
            
        }

        #endregion Methods
    }
}