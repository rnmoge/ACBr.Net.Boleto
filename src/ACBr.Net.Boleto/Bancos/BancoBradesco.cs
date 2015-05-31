// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 04-21-2014
//
// Last Modified By : RFTD
// Last Modified On : 04-28-2014
// ***********************************************************************
// <copyright file="Bradesco.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using ACBr.Net.Boleto.Enums;
using ACBr.Net.Boleto.Utils;
using ACBr.Net.Core.Enum;
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
	[Guid("7AD8EC33-F986-438D-A5CB-F32D3DDD8821")]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes
    /// <summary>
    /// Classe Bradesco. This class cannot be inherited.
    /// </summary>
    public sealed class BancoBradesco : BancoBase
    {
        #region Fields
        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BancoBase" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        internal BancoBradesco(Banco parent)
            : base(parent)
        {
            TipoCobranca = TipoCobranca.Bradesco;
            Nome = "Bradesco";
            Digito = 2;
            Numero = 237;
            TamanhoMaximoNossoNum = 11;
            TamanhoAgencia = 4;
            TamanhoConta = 7;
            TamanhoCarteira = 2;    
        }

        #endregion Constructor

        #region Propriedades
        #endregion Propriedades

        #region Methods

        /// <summary>
        /// Tipoes the ocorrencia to descricao.
        /// </summary>
        /// <param name="tipo">The tipo.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public override string TipoOcorrenciaToDescricao(TipoOcorrencia tipo)
        {
            switch ((int)tipo)
            {
                case 2:
                    return "02-Entrada Confirmada";

                case 3:
                    return "03-Entrada Rejeitada";

                case 6:
                    return "06-Liquidação normal";

                case 9:
                    return "09-Baixado Automaticamente via Arquivo";

                case 10: 
                    return "10-Baixado conforme instruções da Agência";

                case 11: 
                    return "11-Em Ser - Arquivo de Títulos pendentes";

                case 12: 
                    return "12-Abatimento Concedido";

                case 13:
                    return "13-Abatimento Cancelado";

                case 14: return "14-Vencimento Alterado";

                case 15: 
                    return "15-Liquidação em Cartório";

                case 16: 
                    return "16-Titulo Pago em Cheque - Vinculado";

                case 17:
                    return "17-Liquidação após baixa ou Título não registrado";

                case 18:
                    return "18-Acerto de Depositária";

                case 19:
                    return "19-Confirmação Recebimento Instrução de Protesto";

                case 20:
                    return "20-Confirmação Recebimento Instrução Sustação de Protesto";

                case 21:
                    return "21-Acerto do Controle do Participante";

                case 22:
                    return "22-Titulo com Pagamento Cancelado";

                case 23:
                    return "23-Entrada do Título em Cartório";

                case 24:
                    return "24-Entrada rejeitada por CEP Irregular";

                case 27:
                    return "27-Baixa Rejeitada";

                case 28: return "28-Débito de tarifas/custas";

                case 29:
                    return "29-Ocorrências do Sacado";

                case 30:
                    return "30-Alteração de Outros Dados Rejeitados";

                case 32:
                    return "32-Instrução Rejeitada";

                case 33:
                    return "33-Confirmação Pedido Alteração Outros Dados";

                case 34:
                    return "34-Retirado de Cartório e Manutenção Carteira";

                case 35:
                    return "35-Desagendamento do débito automático";

                case 40:
                    return "40-Estorno de Pagamento";

                case 55:
                    return "55-Sustado Judicial";

                case 68:
                    return "68-Acerto dos dados do rateio de Crédito";

                case 69:
                    return "69-Cancelamento dos dados do rateio";

                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Cods the ocorrencia to tipo.
        /// </summary>
        /// <param name="codOcorrencia">The cod ocorrencia.</param>
        /// <returns>TipoOcorrencia.</returns>
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
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
                case 16: return TipoOcorrencia.RetornoTituloPagoEmCheque;
                case 17: return TipoOcorrencia.RetornoLiquidadoAposBaixaOuNaoRegistro;
                case 18: return TipoOcorrencia.RetornoAcertoDepositaria;
                case 19: return TipoOcorrencia.RetornoRecebimentoInstrucaoProtestar;
                case 20: return TipoOcorrencia.RetornoRecebimentoInstrucaoSustarProtesto;
                case 21: return TipoOcorrencia.RetornoAcertoControleParticipante;
                case 22: return TipoOcorrencia.RetornoTituloPagamentoCancelado;
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
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
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
                case TipoOcorrencia.RetornoTituloPagamentoCancelado: return "22";
                case TipoOcorrencia.RetornoEncaminhadoACartorio: return "23";
                case TipoOcorrencia.RetornoEntradaRejeitaCEPIrregular: return "24";
                case TipoOcorrencia.RetornoBaixaRejeitada: return "27";
                case TipoOcorrencia.RetornoDebitoTarifas: return "28";
                case TipoOcorrencia.RetornoOcorrenciasDoSacado: return "29";
                case TipoOcorrencia.RetornoAlteracaoOutrosDadosRejeitada: return "30";
                case TipoOcorrencia.RetornoComandoRecusado: return "32";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoAlterarDados: return "33";
                case TipoOcorrencia.RetornoRetiradoDeCartorio: return "34";
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
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
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
                        case 09: return "Nosso numero duplicado";
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
                            case 10: return "10-Baixa comandada pelo cliente";
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

                case TipoOcorrencia.RetornoLiquidadoAposBaixaOuNaoRegistro:
                    switch (codMotivo)
                    {
                        case 0: return "00-Pago com dinheiro";
                        case 15: return "15-Pago com cheque";  
                        default: return string.Format("{0:00} - Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoLiquidadoEmCartorio:
                    switch (codMotivo)
                    {
                        case 0: return "00-Pago com dinheiro";
                        case 15: return "15-Pago com cheque";  
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
                        case 7: return "07-Agencia\\Conta\\Digito invalidos";
                        case 8: return "08-Nosso numero invalido";
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
                        case 3: return "03-Tarifa de sustação";
                        case 4: return "04-Tarifa de protesto";
                        case 5: return "05-Tarifa de outras instrucoes";
                        case 6: return "06-Tarifa de outras ocorrências";
                        case 8: return "08-Custas de protesto";
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
                        case 2: return "02-Código do registro detalhe inválido";
                        case 4: return "04-Código de ocorrência não permitido para a carteira";
                        case 5: return "05-Código de ocorrência não numérico";
                        case 7: return "07-Agência/Conta/dígito inválidos";
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
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public override string CalcularDigitoVerificador(Titulo titulo)
        {
            Modulo.CalculoPadrao();
            Modulo.MultiplicadorFinal = 7;
            Modulo.Documento = titulo.Carteira + titulo.NossoNumero;
            Modulo.Calcular();
            
            if(Modulo.ModuloFinal == 1)
                return "P";
	        return Modulo.DigitoFinal.ToString();
        }

        /// <summary>
        /// Montars the campo codigo cedente.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public override string MontarCampoCodigoCedente(Titulo titulo)
        {
            return String.Format("{0}-{1}/{2}-{3}", titulo.Parent.Cedente.Agencia, 
                titulo.Parent.Cedente.AgenciaDigito, titulo.Parent.Cedente.Conta, 
                titulo.Parent.Cedente.ContaDigito); 
        }

        /// <summary>
        /// Montar o campo nosso numero.
        /// </summary>
        /// <param name="titulo">Boleto</param>
        /// <returns>NossoNumero</returns>
        public override string MontarCampoNossoNumero(Titulo titulo)
        {
            return String.Format("{0}/{1}-{2}", titulo.Carteira, titulo.NossoNumero, CalcularDigitoVerificador(titulo));
        }

        /// <summary>
        /// Montar o codigo barras do boleto.
        /// </summary>
        /// <param name="titulo">Boleto.</param>
        /// <returns>Codigo de barras</returns>
        public override string MontarCodigoBarras(Titulo titulo)
        {
            var  fatorVencimento = titulo.Vencimento.CalcularFatorVencimento();
            var codigoBarras = string.Format("{0}9{1}{2}{3}{4}{5}{6}0", Numero, fatorVencimento, titulo.ValorDocumento.ToDecimalString(10),
                                titulo.Parent.Cedente.Agencia.OnlyNumbers().FillRight(TamanhoAgencia,'0'), titulo.Carteira, titulo.NossoNumero,
                                titulo.Parent.Cedente.Conta.Right(7).FillRight(7,'0'));
            
            var digitoCodBarras = CalcularDigitoCodigoBarras(codigoBarras);
            
            return codigoBarras.Insert(4, digitoCodBarras);
        }

        /// <summary>
        /// Montar a linha digitavel do boleto.
        /// </summary>
        /// <param name="codigoBarras">Codigo de barras.</param>
        /// <param name="titulo">Boleto.</param>
        /// <returns>Linha digitavel</returns>
        public override string MontarLinhaDigitavel(string codigoBarras, Titulo titulo)
        {
            Modulo.FormulaDigito = CalcDigFormula.Modulo10;
            Modulo.MultiplicadorInicial = 1;
            Modulo.MultiplicadorFinal = 2;
            Modulo.MultiplicadorAtual = 2;

            //Campo 1(Código Banco,Tipo de Moeda,5 primeiro digitos do Campo Livre)
            Modulo.Documento = string.Format("{0}9{1}", codigoBarras.Substring(1, 3), codigoBarras.Substring(19, 5));
            Modulo.Calcular();

            var campo1 = string.Format("{0}.{1}{2}", Modulo.Documento.Substring(0, 5), Modulo.Documento.Substring(5, 4), Modulo.DigitoFinal);

            //Campo 2(6ª a 15ª posições do campo Livre)
            Modulo.Documento = codigoBarras.Substring(24, 10);
            Modulo.Calcular();

            var campo2 = string.Format("{0}.{1}{2}", Modulo.Documento.Substring(0, 5), Modulo.Documento.Substring(5, 5), Modulo.DigitoFinal);

            //Campo 3 (16ª a 25ª posições do campo Livre)
            Modulo.Documento = codigoBarras.Substring(34, 10);
            Modulo.Calcular();

            var campo3 = string.Format("{0}.{1}{2}", Modulo.Documento.Substring(0, 5), Modulo.Documento.Substring(5, 5), Modulo.DigitoFinal);

            //Campo 4 (Digito Verificador Nosso Numero)
            var campo4 = codigoBarras.Substring(4, 1);

            //Campo 5 (Fator de Vencimento e Valor do Documento)
            var campo5 = codigoBarras.Substring(5, 14);

            return string.Format("{0} {1} {2} {3} {4}", campo1, campo2, campo3, campo4, campo5);
        }

        /// <summary>
        /// Gerars the registro header400.
        /// </summary>
        /// <param name="numeroRemessa">The numero remessa.</param>
        /// <param name="aRemessa">A remessa.</param>
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public override void GerarRegistroHeader400(int numeroRemessa, List<string> aRemessa)
        {
            var ced = Banco.Parent.Cedente;
            var wLinha = new StringBuilder();
            wLinha.Append('0');                                                      // ID do Registro
            wLinha.Append('1');                                                      // ID do Arquivo( 1 - Remessa)
            wLinha.Append("REMESSA");                                                // Literal de Remessa
            wLinha.Append("01");                                                     // Código do Tipo de Serviço
            wLinha.Append("COBRANCA".FillLeft(15));                                   // Descrição do tipo de serviço
            wLinha.Append(ced.CodigoCedente.FillRight(20, '0'));                      // Codigo da Empresa no Banco
            wLinha.Append(ced.Nome.RemoveCe().FillLeft(30));                          // Nome da Empresa
            wLinha.Append(Numero + "BRADESCO".FillLeft(15));                          // Código e Nome do Banco(237 - Bradesco)
            wLinha.AppendFormat("{0:ddMMyy}        MX", DateTime.Now);               // Data de geração do arquivo + brancos
            wLinha.AppendFormat("{0:0000000}{1}", numeroRemessa, "".FillRight(277));  // Nr. Sequencial de Remessa + brancos
            wLinha.AppendFormat("{0:000000}", 1);                                    // Nr. Sequencial de Remessa + brancos + Contador
            aRemessa.Add(wLinha.ToString().ToUpper());
        }

        /// <summary>
        /// Gerars the registro transacao400.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <param name="aRemessa">A remessa.</param>
        public override void GerarRegistroTransacao400(Titulo titulo, List<string> aRemessa)
        {
            string aCarteira = string.Empty;
            string aAgencia = string.Empty;
            string aConta = string.Empty;
            string digitoNossoNumero = string.Empty;

            var doMontaInstrucoes = new Func<string>(() =>
            {
                var result = new StringBuilder();
                result.Append("");

                //Primeira instrução vai no registro 1
                if (titulo.Mensagem.Count <= 1)
                    return string.Empty;

                result.Append(Environment.NewLine);
                result.Append('2');                                     // IDENTIFICAÇÃO DO LAYOUT PARA O REGISTRO
                result.Append(titulo.Mensagem[1].FillLeft(80));          // CONTEÚDO DA 1ª LINHA DE IMPRESSÃO DA ÁREA "INSTRUÇÕES” DO BOLETO

                if (titulo.Mensagem.Count == 3)
                    result.Append(titulo.Mensagem[2].FillLeft(80));      // CONTEÚDO DA 2ª LINHA DE IMPRESSÃO DA ÁREA "INSTRUÇÕES” DO BOLETO
                else
                    result.Append("".FillLeft(80));                      // CONTEÚDO DO RESTANTE DAS LINHAS

                if (titulo.Mensagem.Count == 4)
                    result.Append(titulo.Mensagem[3].FillLeft(80));      // CONTEÚDO DA 3ª LINHA DE IMPRESSÃO DA ÁREA "INSTRUÇÕES” DO BOLETO
                else
                    result.Append("".FillLeft(80));                      // CONTEÚDO DO RESTANTE DAS LINHAS

                if (titulo.Mensagem.Count == 5)
                    result.Append(titulo.Mensagem[4].FillLeft(80));      // CONTEÚDO DA 4ª LINHA DE IMPRESSÃO DA ÁREA "INSTRUÇÕES” DO BOLETO
                else
                    result.Append("".FillLeft(80));                      // CONTEÚDO DO RESTANTE DAS LINHAS


                result.Append("".FillRight(45));                         // COMPLEMENTO DO REGISTRO
                result.Append(aCarteira);
                result.Append(aAgencia);
                result.Append(aConta);
                result.Append(titulo.Parent.Cedente.ContaDigito);
                result.Append(titulo.NossoNumero);
                result.Append(digitoNossoNumero);
                result.AppendFormat("{0:000000}", aRemessa.Count + 2);
                return result.ToString();
            });

            digitoNossoNumero = CalcularDigitoVerificador(titulo);
            aAgencia = titulo.Parent.Cedente.Agencia.OnlyNumbers().ZeroFill(5);
            aConta = titulo.Parent.Cedente.Conta.OnlyNumbers().ZeroFill(7);
            aCarteira = titulo.Carteira.Trim().ZeroFill(3);

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
                    ocorrencia = "05"; //Cancelamento de Abatimento concedido
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
                    ocorrencia = "19"; //Sustar protesto e manter na carteira
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
                    tipoBoleto = "2";
                    break;

                default:
                    tipoBoleto = "1";
                    if (string.IsNullOrEmpty(titulo.NossoNumero))
                        digitoNossoNumero = "0";
                    break;
            }

            string aEspecie;
            switch (titulo.EspecieDoc.Trim())
            {
                case "DM":
                    aEspecie = "01";
                    break;

                case "NP":
                    aEspecie = "02";
                    break;

                case "NS":
                    aEspecie = "03";
                    break;

                case "CS":
                    aEspecie = "04";
                    break;

                case "ND":
                    aEspecie = "11";
                    break;

                case "DS":
                    aEspecie = "12";
                    break;

                case "OU":
                    aEspecie = "99";
                    break;

                default:
                    aEspecie = titulo.EspecieDoc;
                    break;
            }

            //Pegando campo Intruções
            string protesto;
            if (titulo.DataProtesto.HasValue && titulo.DataProtesto > titulo.Vencimento)
                protesto = "06" + (titulo.DataProtesto.Value - titulo.Vencimento).TotalDays.ToString().ZeroFill(2);
            else if (ocorrencia == "31")
                protesto = "9999";
            else
                protesto = titulo.Instrucao1.Trim().FillRight(2, '0') + titulo.Instrucao2.Trim().FillRight(2, '0');

            //Pegando Tipo de Sacado
            string tipoSacado;
            switch (titulo.Sacado.Pessoa)
            {
                case Pessoa.Fisica:
                    tipoSacado = "01";
                    break;

                case Pessoa.Juridica:
                    tipoSacado = "02";
                    break;

                default:
                    tipoSacado = "99";
                    break;
            }

            string mensagemCedente;
            if (titulo.Mensagem.Count > 0)
                mensagemCedente = titulo.Mensagem[0];
            else
                mensagemCedente = string.Empty;

            var wLinha = new StringBuilder();
            wLinha.Append('1');                                                       // ID Registro
            wLinha.Append("".ZeroFill(19));                                    // Dados p/ Débito Automático
            wLinha.Append('0' + aCarteira);
            wLinha.Append(aAgencia);
            wLinha.Append(aConta);
            wLinha.Append(titulo.Parent.Cedente.ContaDigito);
            wLinha.Append(titulo.SeuNumero.FillLeft(25) + "000");             // Numero de Controle do Participante
            wLinha.Append(titulo.PercentualMulta > 0 ? '2' : '0');          // Indica se exite Multa ou não
            wLinha.Append(titulo.PercentualMulta.ToDecimalString(4));          // Percentual de Multa formatado com 2 casas decimais
            wLinha.Append(titulo.NossoNumero + digitoNossoNumero);
            wLinha.Append(titulo.ValorDescontoAntDia.ToDecimalString(10));
            wLinha.AppendFormat("{0} {1}", tipoBoleto, "".FillRight(10));                              // Tipo Boleto(Quem emite) + Identificação se emite boleto para débito automático.                  
            wLinha.AppendFormat(" 2  {0}", ocorrencia);                             // Ind. Rateio de Credito + Aviso de Debito Aut.: 2=Não emite aviso + Ocorrência
            wLinha.Append(titulo.NumeroDocumento.FillLeft(10));
            wLinha.AppendFormat("{0:ddMMyy}", titulo.Vencimento);
            wLinha.Append(titulo.ValorDocumento.ToDecimalString());
            wLinha.AppendFormat("{0}{1}N", "".ZeroFill(8), aEspecie.FillLeft(2));     // Zeros + Especie do documento + Idntificação(valor fixo N)
            wLinha.AppendFormat("{0:ddMMyy}", titulo.DataDocumento);                 // Data de Emissão
            wLinha.Append(protesto);
            wLinha.Append(titulo.ValorMoraJuros.ToDecimalString());
            wLinha.Append(titulo.DataDesconto.HasValue && titulo.DataDesconto < new DateTime(2000, 01, 01) ?
                "000000" : string.Format("{0:ddMMyy}", titulo.DataDesconto.Value));
            wLinha.Append(titulo.ValorDesconto.ToDecimalString());
            wLinha.Append(titulo.ValorIOF.ToDecimalString());
            wLinha.Append(titulo.ValorAbatimento.ToDecimalString());
            wLinha.Append(tipoSacado + titulo.Sacado.CNPJCPF.OnlyNumbers().FillRight(14, '0'));
            wLinha.Append(titulo.Sacado.NomeSacado.FillLeft(40));
            wLinha.Append((titulo.Sacado.Logradouro + ' ' + titulo.Sacado.Numero + ' ' +
                    titulo.Sacado.Bairro + ' ' + titulo.Sacado.Cidade + ' ' +
                    titulo.Sacado.UF).FillLeft(40));
            wLinha.Append("".FillRight(12) + titulo.Sacado.CEP.FillLeft(8));
            wLinha.Append(mensagemCedente.FillLeft(60));


            wLinha.AppendFormat("{0:000000}", aRemessa.Count + 1); // Nº SEQÜENCIAL DO REGISTRO NO ARQUIVO
            wLinha.Append(doMontaInstrucoes());

            aRemessa.Add(wLinha.ToString().ToUpper());
        }

        /// <summary>
        /// Gera o registro trailler para o formato CNAB400.
        /// </summary>
        /// <param name="aRemessa">Dados da remessa</param>
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public override void GerarRegistroTrailler400(List<string> aRemessa)
        {
            var wLinha = new StringBuilder();
            wLinha.Append('9');
            wLinha.Append("".FillRight(393));                        // ID Registro
            wLinha.AppendFormat("{0:000000}", aRemessa.Count + 1);  // Contador de Registros
            aRemessa.Add(wLinha.ToString().ToUpper());
        }

        /// <summary>
        /// Ler retorno de arquivo CNAB400.
        /// </summary>
        /// <param name="aRetorno">Dados do retorno.</param>
        /// <exception cref="ACBrException">Código da Empresa do arquivo inválido
        /// or
        /// Agencia\\Conta do arquivo inválido</exception>
        public override void LerRetorno400(List<string> aRetorno)
        {
            if(aRetorno[0].ExtrairInt32DaPosicao(77,79) != Numero)
                throw new ACBrException(string.Format("{0} não é um arquivo de retorno do {1}",
                                                       Banco.Parent.NomeArqRetorno, Nome));
            
            var rCodEmpresa = aRetorno[0].ExtrairDaPosicao(27, 46).Trim();
            var rCedente = aRetorno[0].ExtrairDaPosicao(47, 76).Trim();
            var rAgencia = aRetorno[1].ExtrairDaPosicao( 25, 29).Trim();
            var rConta   = aRetorno[1].ExtrairDaPosicao( 30, 36).Trim();
            var rDigitoConta = aRetorno[1].ExtrairDaPosicao(37, 37);
            
            Banco.Parent.NumeroArquivo = aRetorno[0].ExtrairInt32DaPosicao(109, 113);            
            Banco.Parent.DataArquivo = aRetorno[0].ExtrairDataDaPosicao(95, 100);
            Banco.Parent.DataCreditoLanc = aRetorno[0].ExtrairDataDaPosicao(380, 385);
            
            string rCNPJCPF;
            switch(aRetorno[1].ExtrairInt32DaPosicao(2, 3))
            {
                case 11:
                    rCNPJCPF = aRetorno[1].ExtrairDaPosicao(4, 14);
                    break;

                case 14:
                    rCNPJCPF = aRetorno[1].ExtrairDaPosicao(4, 17);
                    break;

                default:
                    rCNPJCPF = aRetorno[1].ExtrairDaPosicao(4, 17);
                    break;
            }

            if(!Banco.Parent.LeCedenteRetorno)
            {
                if (rCodEmpresa != Banco.Parent.Cedente.CodigoCedente.FillRight(20, '0'))
                    throw new ACBrException("Código da Empresa do arquivo inválido");
                
                if (rAgencia != Banco.Parent.Cedente.Agencia.OnlyNumbers() ||
                    rConta != Banco.Parent.Cedente.Conta.FillRight(rConta.Length))
                    throw new ACBrException("Agencia\\Conta do arquivo inválido");
            }
            
            switch(aRetorno[1].ExtrairInt32DaPosicao(2, 3))
            {
                case 11:
                    Banco.Parent.Cedente.TipoInscricao = PessoaCedente.Fisica;
                    break;

                case 14:
                    Banco.Parent.Cedente.TipoInscricao = PessoaCedente.Juridica;
                    break;

                default:
                    Banco.Parent.Cedente.TipoInscricao = PessoaCedente.Juridica;
                    break;
            }
            
            if(Banco.Parent.LeCedenteRetorno)
            {
                Banco.Parent.Cedente.CNPJCPF = rCNPJCPF;
                Banco.Parent.Cedente.CodigoCedente = rCodEmpresa;
                Banco.Parent.Cedente.Nome = rCedente;
                Banco.Parent.Cedente.Agencia = rAgencia;
                Banco.Parent.Cedente.AgenciaDigito = "0";
                Banco.Parent.Cedente.Conta = rConta;
                Banco.Parent.Cedente.ContaDigito = rDigitoConta;
            }
            
            Banco.Parent.ListadeBoletos.Clear();
            string linha;
            Titulo titulo;
            for(int contLinha = 1; contLinha < aRetorno.Count - 1; contLinha++)
            {
                linha = aRetorno[contLinha];
                
                if (linha.ExtrairInt32DaPosicao(1,1) == 1)
                    continue;
                
                titulo = Banco.Parent.CriarTituloNaLista();

                
                titulo.SeuNumero = linha.ExtrairDaPosicao(38, 62);
                titulo.NumeroDocumento = linha.ExtrairDaPosicao(117, 126);
                titulo.OcorrenciaOriginal.Tipo = CodOcorrenciaToTipo(linha.ExtrairInt32DaPosicao(109, 110));
                
                var codOcorrencia = linha.ExtrairInt32DaPosicao(109,2);
                
                //-|Se a ocorrencia for igual a 19 - Confirmação de Receb. de Protesto
                //-|Verifica o motivo na posição 295 - A = Aceite , D = Desprezado
                if(codOcorrencia == 19)
                {
                    var codMotivo19 = linha.ExtrairDaPosicao(295, 295);
                    titulo.MotivoRejeicaoComando.Add(linha.ExtrairDaPosicao(295, 295).ZeroFill(2));
                    if(codMotivo19 == "A")
                        titulo.DescricaoMotivoRejeicaoComando.Add("A - Aceito");
                    else
                        titulo.DescricaoMotivoRejeicaoComando.Add("D - Desprezado");
                }
                else
                {
                    var motivoLinha = 319;
                    for(int i = 0; i < 4; i++)
                    {
                        var codMotivo =  linha.ExtrairInt32DaPosicao(motivoLinha, motivoLinha + 1);
                        
                        //Se for o primeiro motivo}
                        if (i == 0) 
                        {
                            //Somente estas ocorrencias possuem motivos 00}
                            if(codOcorrencia.IsIn( 2, 6, 9, 10, 15, 17))
                            {
                                titulo.MotivoRejeicaoComando.Add(linha.ExtrairDaPosicao(motivoLinha, motivoLinha + 1).ZeroFill(2));
                                titulo.DescricaoMotivoRejeicaoComando.Add(CodMotivoRejeicaoToDescricao(titulo.OcorrenciaOriginal.Tipo, codMotivo));
                            }
                            else
                            {
                                if(codMotivo == 0)
                                {
                                    titulo.MotivoRejeicaoComando.Add("00");
                                    titulo.DescricaoMotivoRejeicaoComando.Add("Sem Motivo");
                                }
                                else
                                {
                                    titulo.MotivoRejeicaoComando.Add(linha.ExtrairDaPosicao(motivoLinha, motivoLinha + 1).ZeroFill(2));
                                    titulo.DescricaoMotivoRejeicaoComando.Add(CodMotivoRejeicaoToDescricao(titulo.OcorrenciaOriginal.Tipo, codMotivo));
                                }
                            }
                        }
                        else
                        {
                            //Apos o 1º motivo os 00 significam que não existe mais motivo
                            if(codMotivo != 0)
                            {
                                titulo.MotivoRejeicaoComando.Add(linha.ExtrairDaPosicao(motivoLinha, motivoLinha + 1).ZeroFill(2));
                                titulo.DescricaoMotivoRejeicaoComando.Add(CodMotivoRejeicaoToDescricao(titulo.OcorrenciaOriginal.Tipo, codMotivo));
                            }
                        }

                        motivoLinha = motivoLinha + 2; //Incrementa a coluna dos motivos
                    }
                    
                    titulo.DataOcorrencia = linha.ExtrairDataDaPosicao(111, 116);
                    var temp = linha.ExtrairDataOpcionalDaPosicao(147, 152);
                    if(temp.HasValue)
                        titulo.Vencimento = temp.Value;

                    titulo.ValorDocumento = linha.ExtrairDecimalDaPosicao(153, 165);
                    titulo.ValorIOF = linha.ExtrairDecimalDaPosicao(215, 227);
                    titulo.ValorAbatimento = linha.ExtrairDecimalDaPosicao(228, 240);
                    titulo.ValorDesconto = linha.ExtrairDecimalDaPosicao(241, 253);
                    titulo.ValorRecebido = linha.ExtrairDecimalDaPosicao(254, 266);
                    titulo.ValorMoraJuros = linha.ExtrairDecimalDaPosicao(267, 279);
                    titulo.ValorOutrosCreditos = linha.ExtrairDecimalDaPosicao(280, 292);
                    titulo.NossoNumero = linha.ExtrairDaPosicao(71, 80);
                    titulo.Carteira = linha.ExtrairDaPosicao(22, 24);
                    titulo.ValorDespesaCobranca = linha.ExtrairDecimalDaPosicao(176, 188);
                    titulo.ValorOutrasDespesas = linha.ExtrairDecimalDaPosicao(189, 201);
                    
                    var temp2 = linha.ExtrairDataOpcionalDaPosicao(296, 301);
                    if (temp2.HasValue)
                        titulo.DataCredito = temp2.Value;
                }                                        
            }
        }

        #endregion Methods
    }    
}
