// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 05-08-2014
//
// Last Modified By : RFTD
// Last Modified On : 05-23-2014
// ***********************************************************************
// <copyright file="BancoItau.cs" company="ACBr.Net">
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
	[Guid("2E675758-954A-45EE-981F-4C2662AF9CE1")]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes
    /// <summary>
    /// Classe BancoItau. Esta classe não pode ser herdada.
    /// </summary>
    public sealed class BancoItau : BancoBase
    {
        #region Fields
        #endregion Fields

        #region Constructor

        /// <summary>
        /// Inicializa uma nova instancia da classe <see cref="BancoItau" />.
        /// </summary>
        /// <param name="parent">Classe Banco.</param>
        internal BancoItau(Banco parent)
            : base(parent)
        {
            TipoCobranca = TipoCobranca.Itau;
            Digito = 7;
            Nome = "Banco Itau";
            Numero = 341;
            TamanhoMaximoNossoNum = 8;
            TamanhoAgencia = 4;
            TamanhoConta = 5;
            TamanhoCarteira = 3;  
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
        public override string TipoOcorrenciaToDescricao(TipoOcorrencia tipo)
        {
            var codOcorrencia = TipoOCorrenciaToCod(tipo).ToInt32();   
            switch(codOcorrencia)
            {
                case 2: return "02-Entrada Confirmada";
                case 3: return "03-Entrada Rejeitada";
				case 4: return "04-Alteração de Dados - Nova Entrada ou Alteração/Exclusão de Dados Acatada";
                case 5: return "05-Alteração de Dados - Baixa";
                case 6: return "06-Liquidação Normal";
                case 7: return "07-Liquidação Parcial - Cobrança Inteligente (B2b)";
                case 8: return "08-Liquidação Em Cartório";
                case 9: return "09-Baixa Simples";
                case 10: return "10-Baixa Por Ter Sido Liquidado";
                case 11: return "11-Em Ser";
                case 12: return "12-Abatimento Concedido";
                case 13: return "13-Abatimento Cancelado";
                case 14: return "14-Vencimento Alterado";
                case 15: return "15-Baixas Rejeitadas";
                case 16: return "16-Instruções Rejeitadas";
                case 17: return "17-Alteração de Dados Rejeitados";
                case 18: return "18-Cobrança Contratual - Instruções/Alterações Rejeitadas/Pendentes";
                case 19: return "19-Confirma Recebimento de Instrução de Protesto";
                case 20: return "20-Confirma Recebimento de Instrução de Sustação de Protesto /Tarifa";
                case 21: return "21-Confirma Recebimento de Instrução de Não Protestar";
                case 23: return "23-Título Enviado A Cartório/Tarifa";
                case 24: return "24-Instrução de Protesto Rejeitada / Sustada / Pendente";
                case 25: return "25-Alegações do Sacado";
                case 26: return "26-Tarifa de Aviso de Cobrança";
                case 27: return "27-Tarifa de Extrato Posição (B40x)";
                case 28: return "28-Tarifa de Relação das Liquidações";
                case 29: return "29-Tarifa de Manutenção de Títulos Vencidos";
                case 30: return "30-Débito Mensal de Tarifas (Para Entradas e Baixas)";
                case 32: return "32-Baixa por ter sido Protestado";
                case 33: return "33-Custas de Protesto";
                case 34: return "34-Custas de Sustação";
                case 35: return "35-Custas de Cartório Distribuidor";
                case 36: return "36-Custas de Edital";
                case 37: return "37-Tarifa de Emissão de Boleto/Tarifa de Envio de Duplicata";
                case 38: return "38-Tarifa de Instrução";
                case 39: return "39-Tarifa de Ocorrências";
                case 40: return "40-Tarifa Mensal de Emissão de Boleto/Tarifa Mensal de Envio De Duplicata";
                case 41: return "41-Débito Mensal de Tarifas - Extrato de Posição (B4ep/B4ox)";
                case 42: return "42-Débito Mensal de Tarifas - Outras Instruções";
                case 43: return "43-Débito Mensal de Tarifas - Manutenção de Títulos Vencidos";
                case 44: return "44-Débito Mensal de Tarifas - Outras Ocorrências";
                case 45: return "45-Débito Mensal de Tarifas - Protesto";
                case 46: return "46-Débito Mensal de Tarifas - Sustação de Protesto";
                case 47: return "47-Baixa com Transferência para Desconto";
                case 48: return "48-Custas de Sustação Judicial";
                case 51: return "51-Tarifa Mensal Ref a Entradas Bancos Correspondentes na Carteira";
                case 52: return "52-Tarifa Mensal Baixas na Carteira";
                case 53: return "53-Tarifa Mensal Baixas em Bancos Correspondentes na Carteira";
                case 54: return "54-Tarifa Mensal de Liquidações na Carteira";
                case 55: return "55-Tarifa Mensal de Liquidações em Bancos Correspondentes na Carteira";
                case 56: return "56-Custas de Irregularidade";
                case 57: return "57-Instrução Cancelada";
                case 59: return "59-Baixa por Crédito em C/C Através do Sispag";
                case 60: return "60-Entrada Rejeitada Carnê";
                case 61: return "61-Tarifa Emissão Aviso de Movimentação de Títulos (2154)";
                case 62: return "62-Débito Mensal de Tarifa - Aviso de Movimentação de Títulos (2154)";
                case 63: return "63-Título Sustado Judicialmente";
                case 64: return "64-Entrada Confirmada com Rateio de Crédito";
                case 69: return "69-Cheque Devolvido";
                case 71: return "71-Entrada Registrada, Aguardando Avaliação";
                case 72: return "72-Baixa por Crédito em C/C Através do Sispag sem Título Correspondente";
                case 73: return "73-Confirmação de Entrada na Cobrança Simples - Entrada não Aceita na Cobrança Contratual";
                case 76: return "76-Cheque Compensado";
                default: return string.Format("{0:00}-Outras Ocorrencias", codOcorrencia);
            }
        }

        /// <summary>
        /// Cods the ocorrencia to tipo.
        /// </summary>
        /// <param name="codOcorrencia">The cod ocorrencia.</param>
        /// <returns>TipoOcorrencia.</returns>
        public override TipoOcorrencia CodOcorrenciaToTipo(int codOcorrencia)
        {
            switch(codOcorrencia)
            {
                case 2: return TipoOcorrencia.RetornoRegistroConfirmado;
                case 3: return TipoOcorrencia.RetornoRegistroRecusado;
                case 4: return TipoOcorrencia.RetornoAlteracaoDadosNovaEntrada;
                case 5: return TipoOcorrencia.RetornoAlteracaoDadosBaixa;
                case 6: return TipoOcorrencia.RetornoLiquidado;
                case 7: return TipoOcorrencia.RetornoLiquidadoParcialmente;
                case 8: return TipoOcorrencia.RetornoLiquidadoEmCartorio;
                case 9: return TipoOcorrencia.RetornoBaixaSimples;
                case 10: return TipoOcorrencia.RetornoBaixaPorTerSidoLiquidado;
                case 11: return TipoOcorrencia.RetornoTituloEmSer;
                case 12: return TipoOcorrencia.RetornoAbatimentoConcedido;
                case 13: return TipoOcorrencia.RetornoAbatimentoCancelado;
                case 14: return TipoOcorrencia.RetornoVencimentoAlterado;
                case 15: return TipoOcorrencia.RetornoBaixaRejeitada;
                case 16: return TipoOcorrencia.RetornoInstrucaoRejeitada;
                case 17: return TipoOcorrencia.RetornoAlteracaoDadosRejeitados;
                case 18: return TipoOcorrencia.RetornoCobrancaContratual;
                case 19: return TipoOcorrencia.RetornoRecebimentoInstrucaoProtestar;
                case 20: return TipoOcorrencia.RetornoRecebimentoInstrucaoSustarProtesto;
                case 21: return TipoOcorrencia.RetornoRecebimentoInstrucaoNaoProtestar;
                case 23: return TipoOcorrencia.RetornoEncaminhadoACartorio;
                case 24: return TipoOcorrencia.RetornoInstrucaoProtestoRejeitadaSustadaOuPendente;
                case 25: return TipoOcorrencia.RetornoAlegacaoDoSacado;
                case 26: return TipoOcorrencia.RetornoTarifaAvisoCobranca;
                case 27: return TipoOcorrencia.RetornoTarifaExtratoPosicao;
                case 28: return TipoOcorrencia.RetornoTarifaDeRelacaoDasLiquidacoes;
                case 29: return TipoOcorrencia.RetornoTarifaDeManutencaoDeTitulosVencidos;
                case 30: return TipoOcorrencia.RetornoDebitoTarifas;
                case 32: return TipoOcorrencia.RetornoBaixaPorProtesto;
                case 33: return TipoOcorrencia.RetornoCustasProtesto;
                case 34: return TipoOcorrencia.RetornoCustasSustacao;
                case 35: return TipoOcorrencia.RetornoCustasCartorioDistribuidor;
                case 36: return TipoOcorrencia.RetornoCustasEdital;
                case 37: return TipoOcorrencia.RetornoTarifaEmissaoBoletoEnvioDuplicata;
                case 38: return TipoOcorrencia.RetornoTarifaInstrucao;
                case 39: return TipoOcorrencia.RetornoTarifaOcorrencias;
                case 40: return TipoOcorrencia.RetornoTarifaMensalEmissaoBoletoEnvioDuplicata;
                case 41: return TipoOcorrencia.RetornoDebitoMensalTarifasExtradoPosicao;
                case 42: return TipoOcorrencia.RetornoDebitoMensalTarifasOutrasInstrucoes;
                case 43: return TipoOcorrencia.RetornoDebitoMensalTarifasManutencaoTitulosVencidos;
                case 44: return TipoOcorrencia.RetornoDebitoMensalTarifasOutrasOcorrencias;
                case 45: return TipoOcorrencia.RetornoDebitoMensalTarifasProtestos;
                case 46: return TipoOcorrencia.RetornoDebitoMensalTarifasSustacaoProtestos;
                case 47: return TipoOcorrencia.RetornoBaixaTransferenciaParaDesconto;
                case 48: return TipoOcorrencia.RetornoCustasSustacaoJudicial;
                case 51: return TipoOcorrencia.RetornoTarifaMensalRefEntradasBancosCorrespCarteira;
                case 52: return TipoOcorrencia.RetornoTarifaMensalBaixasCarteira;
                case 53: return TipoOcorrencia.RetornoTarifaMensalBaixasBancosCorrespCarteira;
                case 54: return TipoOcorrencia.RetornoTarifaMensalLiquidacoesCarteira;
                case 55: return TipoOcorrencia.RetornoTarifaMensalLiquidacoesBancosCorrespCarteira;
                case 56: return TipoOcorrencia.RetornoCustasIrregularidade;
                case 57: return TipoOcorrencia.RetornoInstrucaoCancelada;
                case 59: return TipoOcorrencia.RetornoBaixaCreditoCCAtravesSispag;
                case 60: return TipoOcorrencia.RetornoEntradaRejeitadaCarne;
                case 61: return TipoOcorrencia.RetornoTarifaEmissaoAvisoMovimentacaoTitulos;
                case 62: return TipoOcorrencia.RetornoDebitoMensalTarifaAvisoMovimentacaoTitulos;
                case 63: return TipoOcorrencia.RetornoTituloSustadoJudicialmente;
                case 64: return TipoOcorrencia.RetornoEntradaConfirmadaRateioCredito;
                case 69: return TipoOcorrencia.RetornoChequeDevolvido;
                case 71: return TipoOcorrencia.RetornoEntradaRegistradaAguardandoAvaliacao;
                case 72: return TipoOcorrencia.RetornoBaixaCreditoCCAtravesSispagSemTituloCorresp;
                case 73: return TipoOcorrencia.RetornoConfirmacaoEntradaCobrancaSimples;
                case 76: return TipoOcorrencia.RetornoChequeCompensado; 
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
            switch(tipo)
            {
                case TipoOcorrencia.RetornoRegistroConfirmado: return "02";
                case TipoOcorrencia.RetornoRegistroRecusado: return "03";
                case TipoOcorrencia.RetornoAlteracaoDadosNovaEntrada: return "04";
                case TipoOcorrencia.RetornoAlteracaoDadosBaixa: return "05";
                case TipoOcorrencia.RetornoLiquidado: return "06";
                case TipoOcorrencia.RetornoLiquidadoParcialmente: return "07";
                case TipoOcorrencia.RetornoLiquidadoEmCartorio: return "08";
                case TipoOcorrencia.RetornoBaixaSimples: return "09";
                case TipoOcorrencia.RetornoBaixaPorTerSidoLiquidado: return "10";
                case TipoOcorrencia.RetornoTituloEmSer: return "11";
                case TipoOcorrencia.RetornoAbatimentoConcedido: return "12";
                case TipoOcorrencia.RetornoAbatimentoCancelado: return "13";
                case TipoOcorrencia.RetornoVencimentoAlterado: return "14";
                case TipoOcorrencia.RetornoBaixaRejeitada: return "15";
                case TipoOcorrencia.RetornoInstrucaoRejeitada: return "16";
                case TipoOcorrencia.RetornoAlteracaoDadosRejeitados: return "17";
                case TipoOcorrencia.RetornoCobrancaContratual: return "18";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoProtestar: return "19";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoSustarProtesto: return "20";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoNaoProtestar: return "21";
                case TipoOcorrencia.RetornoEncaminhadoACartorio: return "23";
                case TipoOcorrencia.RetornoInstrucaoProtestoRejeitadaSustadaOuPendente: return "24";
                case TipoOcorrencia.RetornoAlegacaoDoSacado: return "25";
                case TipoOcorrencia.RetornoTarifaAvisoCobranca: return "26";
                case TipoOcorrencia.RetornoTarifaExtratoPosicao: return "27";
                case TipoOcorrencia.RetornoTarifaDeRelacaoDasLiquidacoes: return "28";
                case TipoOcorrencia.RetornoTarifaDeManutencaoDeTitulosVencidos: return "29";
                case TipoOcorrencia.RetornoDebitoTarifas: return "30";
                case TipoOcorrencia.RetornoBaixaPorProtesto: return "32";
                case TipoOcorrencia.RetornoCustasProtesto: return "33";
                case TipoOcorrencia.RetornoCustasSustacao: return "34";
                case TipoOcorrencia.RetornoCustasCartorioDistribuidor: return "35";
                case TipoOcorrencia.RetornoCustasEdital: return "36";
                case TipoOcorrencia.RetornoTarifaEmissaoBoletoEnvioDuplicata: return "37";
                case TipoOcorrencia.RetornoTarifaInstrucao: return "38";
                case TipoOcorrencia.RetornoTarifaOcorrencias: return "39";
                case TipoOcorrencia.RetornoTarifaMensalEmissaoBoletoEnvioDuplicata: return "40";
                case TipoOcorrencia.RetornoDebitoMensalTarifasExtradoPosicao: return "41";
                case TipoOcorrencia.RetornoDebitoMensalTarifasOutrasInstrucoes: return "42";
                case TipoOcorrencia.RetornoDebitoMensalTarifasManutencaoTitulosVencidos: return "43";
                case TipoOcorrencia.RetornoDebitoMensalTarifasOutrasOcorrencias: return "44";
                case TipoOcorrencia.RetornoDebitoMensalTarifasProtestos: return "45";
                case TipoOcorrencia.RetornoDebitoMensalTarifasSustacaoProtestos: return "46";
                case TipoOcorrencia.RetornoBaixaTransferenciaParaDesconto: return "47";
                case TipoOcorrencia.RetornoCustasSustacaoJudicial: return "48";
                case TipoOcorrencia.RetornoTarifaMensalRefEntradasBancosCorrespCarteira: return "51";
                case TipoOcorrencia.RetornoTarifaMensalBaixasCarteira: return "52";
                case TipoOcorrencia.RetornoTarifaMensalBaixasBancosCorrespCarteira: return "53";
                case TipoOcorrencia.RetornoTarifaMensalLiquidacoesCarteira: return "54";
                case TipoOcorrencia.RetornoTarifaMensalLiquidacoesBancosCorrespCarteira: return "55";
                case TipoOcorrencia.RetornoCustasIrregularidade: return "56";
                case TipoOcorrencia.RetornoInstrucaoCancelada: return "57";
                case TipoOcorrencia.RetornoBaixaCreditoCCAtravesSispag: return "59";
                case TipoOcorrencia.RetornoEntradaRejeitadaCarne: return "60";
                case TipoOcorrencia.RetornoTarifaEmissaoAvisoMovimentacaoTitulos: return "61";
                case TipoOcorrencia.RetornoDebitoMensalTarifaAvisoMovimentacaoTitulos: return "62";
                case TipoOcorrencia.RetornoTituloSustadoJudicialmente: return "63";
                case TipoOcorrencia.RetornoEntradaConfirmadaRateioCredito: return "64";
                case TipoOcorrencia.RetornoChequeDevolvido: return "69";
                case TipoOcorrencia.RetornoEntradaRegistradaAguardandoAvaliacao: return "71";
                case TipoOcorrencia.RetornoBaixaCreditoCCAtravesSispagSemTituloCorresp: return "72";
                case TipoOcorrencia.RetornoConfirmacaoEntradaCobrancaSimples: return "73";
                case TipoOcorrencia.RetornoChequeCompensado: return "76";
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
                case TipoOcorrencia.RetornoRegistroRecusado:
                case TipoOcorrencia.RetornoEntradaRejeitadaCarne:
                    switch (codMotivo)
                    {
                        case 3: return "AG. COBRADORA -NÃO FOI POSSÍVEL ATRIBUIR A AGÊNCIA PELO CEP OU CEP INVÁLIDO";
                        case 4: return "ESTADO -SIGLA DO ESTADO INVÁLIDA";
                        case 5: return "DATA VENCIMENTO -PRAZO DA OPERAÇÃO MENOR QUE PRAZO MÍNIMO OU MAIOR QUE O MÁXIMO";
                        case 7: return "VALOR DO TÍTULO -VALOR DO TÍTULO MAIOR QUE 10.000.000,00";
                        case 8: return "NOME DO SACADO -NÃO INFORMADO OU DESLOCADO";
                        case 9: return "AGENCIA/CONTA -AGÊNCIA ENCERRADA";
                        case 10: return "LOGRADOURO -NÃO INFORMADO OU DESLOCADO";
                        case 11: return "CEP -CEP NÃO NUMÉRICO";
                        case 12: return "SACADOR / AVALISTA -NOME NÃO INFORMADO OU DESLOCADO (BANCOS CORRESPONDENTES)";
                        case 13: return "ESTADO/CEP -CEP INCOMPATÍVEL COM A SIGLA DO ESTADO";
                        case 14: return "NOSSO NÚMERO -NOSSO NÚMERO JÁ REGISTRADO NO CADASTRO DO BANCO OU FORA DA FAIXA";
                        case 15: return "NOSSO NÚMERO -NOSSO NÚMERO EM DUPLICIDADE NO MESMO MOVIMENTO";
                        case 18: return "DATA DE ENTRADA -DATA DE ENTRADA INVÁLIDA PARA OPERAR COM ESTA CARTEIRA";
                        case 19: return "OCORRÊNCIA -OCORRÊNCIA INVÁLIDA";
                        case 21: return "AG. COBRADORA - CARTEIRA NÃO ACEITA DEPOSITÁRIA CORRESPONDENTE/" +
                                         "ESTADO DA AGÊNCIA DIFERENTE DO ESTADO DO SACADO/" +
                                         "AG. COBRADORA NÃO CONSTA NO CADASTRO OU ENCERRANDO";
                        case 22: return "CARTEIRA -CARTEIRA NÃO PERMITIDA (NECESSÁRIO CADASTRAR FAIXA LIVRE)";
                        case 26: return "AGÊNCIA/CONTA -AGÊNCIA/CONTA NÃO LIBERADA PARA OPERAR COM COBRANÇA";
                        case 27: return "CNPJ INAPTO -CNPJ DO CEDENTE INAPTO";
                        case 29: return "CÓDIGO EMPRESA -CATEGORIA DA CONTA INVÁLIDA";
                        case 30: return "ENTRADA BLOQUEADA -ENTRADAS BLOQUEADAS, CONTA SUSPENSA EM COBRANÇA";
                        case 31: return "AGÊNCIA/CONTA -CONTA NÃO TEM PERMISSÃO PARA PROTESTAR (CONTATE SEU GERENTE)";
                        case 35: return "VALOR DO IOF -IOF MAIOR QUE 5%";
                        case 36: return "QTDADE DE MOEDA -QUANTIDADE DE MOEDA INCOMPATÍVEL COM VALOR DO TÍTULO";
                        case 37: return "CNPJ/CPF DO SACADO -NÃO NUMÉRICO OU IGUAL A ZEROS";
                        case 42: return "NOSSO NÚMERO -NOSSO NÚMERO FORA DE FAIXA";
                        case 52: return "AG. COBRADORA -EMPRESA NÃO ACEITA BANCO CORRESPONDENTE";
                        case 53: return "AG. COBRADORA -EMPRESA NÃO ACEITA BANCO CORRESPONDENTE - COBRANÇA MENSAGEM";
                        case 54: return "DATA DE VENCTO -BANCO CORRESPONDENTE - TÍTULO COM VENCIMENTO INFERIOR A 15 DIAS";
                        case 55: return "DEP/BCO CORRESP -CEP NÃO PERTENCE À DEPOSITÁRIA INFORMADA";
                        case 56: return "DT VENCTO/BCO CORRESP -VENCTO SUPERIOR A 180 DIAS DA DATA DE ENTRADA";
                        case 57: return "DATA DE VENCTO -CEP SÓ DEPOSITÁRIA BCO DO BRASIL COM VENCTO INFERIOR A 8 DIAS";
                        case 60: return "ABATIMENTO -VALOR DO ABATIMENTO INVÁLIDO";
                        case 61: return "JUROS DE MORA -JUROS DE MORA MAIOR QUE O PERMITIDO";
                        case 63: return "DESCONTO DE ANTECIPAÇÃO -VALOR DA IMPORTÂNCIA POR DIA DE DESCONTO (IDD) NÃO PERMITIDO";
                        case 64: return "DATA DE EMISSÃO -DATA DE EMISSÃO DO TÍTULO INVÁLIDA";
                        case 65: return "TAXA FINANCTO -TAXA INVÁLIDA (VENDOR)";
                        case 66: return "DATA DE VENCTO -INVALIDA/FORA DE PRAZO DE OPERAÇÃO (MÍNIMO OU MÁXIMO)";
                        case 67: return "VALOR/QTIDADE -VALOR DO TÍTULO/QUANTIDADE DE MOEDA INVÁLIDO";
                        case 68: return "CARTEIRA -CARTEIRA INVÁLIDA";
                        case 69: return "CARTEIRA -CARTEIRA INVÁLIDA PARA TÍTULOS COM RATEIO DE CRÉDITO";
                        case 70: return "AGÊNCIA/CONTA -CEDENTE NÃO CADASTRADO PARA FAZER RATEIO DE CRÉDITO";
                        case 78: return "AGÊNCIA/CONTA -DUPLICIDADE DE AGÊNCIA/CONTA BENEFICIÁRIA DO RATEIO DE CRÉDITO";
                        case 80: return "AGÊNCIA/CONTA -QUANTIDADE DE CONTAS BENEFICIÁRIAS DO RATEIO MAIOR DO QUE O PERMITIDO (MÁXIMO DE 30 CONTAS POR TÍTULO)";
                        case 81: return "AGÊNCIA/CONTA -CONTA PARA RATEIO DE CRÉDITO INVÁLIDA / NÃO PERTENCE AO ITAÚ";
                        case 82: return "DESCONTO/ABATI-MENTO -DESCONTO/ABATIMENTO NÃO PERMITIDO PARA TÍTULOS COM RATEIO DE CRÉDITO";
                        case 83: return "VALOR DO TÍTULO -VALOR DO TÍTULO MENOR QUE A SOMA DOS VALORES ESTIPULADOS PARA RATEIO";
                        case 84: return "AGÊNCIA/CONTA -AGÊNCIA/CONTA BENEFICIÁRIA DO RATEIO É A CENTRALIZADORA DE CRÉDITO DO CEDENTE";
                        case 85: return "AGÊNCIA/CONTA -AGÊNCIA/CONTA DO CEDENTE É CONTRATUAL / RATEIO DE CRÉDITO NÃO PERMITIDO";
                        case 86: return "TIPO DE VALOR -CÓDIGO DO TIPO DE VALOR INVÁLIDO / NÃO PREVISTO PARA TÍTULOS COM RATEIO DE CRÉDITO";
                        case 87: return "AGÊNCIA/CONTA -REGISTRO TIPO 4 SEM INFORMAÇÃO DE AGÊNCIAS/CONTAS BENEFICIÁRIAS DO RATEIO";
                        case 90: return "NRO DA LINHA -COBRANÇA MENSAGEM - NÚMERO DA LINHA DA MENSAGEM INVÁLIDO";
                        case 97: return "SEM MENSAGEM -COBRANÇA MENSAGEM SEM MENSAGEM (SÓ DE CAMPOS FIXOS), PORÉM COM REGISTRO DO TIPO 7 OU 8";
                        case 98: return "FLASH INVÁLIDO -REGISTRO MENSAGEM SEM FLASH CADASTRADO OU FLASH INFORMADO DIFERENTE DO CADASTRADO";
                        case 99: return "FLASH INVÁLIDO -CONTA DE COBRANÇA COM FLASH CADASTRADO E SEM REGISTRO DE MENSAGEM CORRESPONDENTE";
                        case 91: return "DAC -DAC AGÊNCIA / CONTA CORRENTE INVÁLIDO";
                        case 92: return "DAC -DAC AGÊNCIA/CONTA/CARTEIRA/NOSSO NÚMERO INVÁLIDO";
                        case 93: return "ESTADO -SIGLA ESTADO INVÁLIDA";
                        case 94: return "ESTADO -SIGLA ESTADA INCOMPATÍVEL COM CEP DO SACADO";
                        case 95: return "CEP -CEP DO SACADO NÃO NUMÉRICO OU INVÁLIDO";
                        case 96: return "ENDEREÇO -ENDEREÇO / NOME / CIDADE SACADO INVÁLIDO";
                        default: return string.Format("{0:00}-Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoAlteracaoDadosRejeitados:
                    switch (codMotivo)
                    {
                        case 2: return "AGÊNCIA COBRADORA INVÁLIDA OU COM O MESMO CONTEÚDO";
                        case 4: return "SIGLA DO ESTADO INVÁLIDA";
                        case 5: return "DATA DE VENCIMENTO INVÁLIDA OU COM O MESMO CONTEÚDO";
                        case 6: return "VALOR DO TÍTULO COM OUTRA ALTERAÇÃO SIMULTÂNEA";
                        case 8: return "NOME DO SACADO COM O MESMO CONTEÚDO";
                        case 9: return "AGÊNCIA/CONTA INCORRETA";
                        case 11: return "CEP INVÁLIDO";
                        case 13: return "SEU NÚMERO COM O MESMO CONTEÚDO";
                        case 16: return "ABATIMENTO/ALTERAÇÃO DO VALOR DO TÍTULO OU SOLICITAÇÃO DE BAIXA BLOQUEADA";
                        case 21: return "AGÊNCIA COBRADORA NÃO CONSTA NO CADASTRO DE DEPOSITÁRIA OU EM ENCERRAMENTO";
                        case 53: return "INSTRUÇÃO COM O MESMO CONTEÚDO";
                        case 54: return "DATA VENCIMENTO PARA BANCOS CORRESPONDENTES INFERIOR AO ACEITO PELO BANCO";
                        case 55: return "ALTERAÇÕES IGUAIS PARA O MESMO CONTROLE (AGÊNCIA/CONTA/CARTEIRA/NOSSO NÚMERO)";
                        case 56: return "CGC/CPF INVÁLIDO NÃO NUMÉRICO OU ZERADO";
                        case 57: return "PRAZO DE VENCIMENTO INFERIOR A 15 DIAS";
                        case 60: return "VALOR DE IOF - ALTERAÇÃO NÃO PERMITIDA PARA CARTEIRAS DE N.S. - MOEDA VARIÁVEL";
                        case 61: return "TÍTULO JÁ BAIXADO OU LIQUIDADO OU NÃO EXISTE TÍTULO CORRESPONDENTE NO SISTEMA";
                        case 66: return "ALTERAÇÃO NÃO PERMITIDA PARA CARTEIRAS DE NOTAS DE SEGUROS - MOEDA VARIÁVEL";
                        case 81: return "ALTERAÇÃO BLOQUEADA - TÍTULO COM PROTESTO";
                        default: return string.Format("{0:00}-Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoInstrucaoRejeitada:
                    switch (codMotivo)
                    {
                        case 1: return "INSTRUÇÃO/OCORRÊNCIA NÃO EXISTENTE";
                        case 6: return "NOSSO NÚMERO IGUAL A ZEROS";
                        case 9: return "CGC/CPF DO SACADOR/AVALISTA INVÁLIDO";
                        case 10: return "VALOR DO ABATIMENTO IGUAL OU MAIOR QUE O VALOR DO TÍTULO";
                        case 14: return "REGISTRO EM DUPLICIDADE";
                        case 15: return "CGC/CPF INFORMADO SEM NOME DO SACADOR/AVALISTA";
                        case 21: return "TÍTULO NÃO REGISTRADO NO SISTEMA";
                        case 22: return "TÍTULO BAIXADO OU LIQUIDADO";
                        case 23: return "INSTRUÇÃO NÃO ACEITA POR TER SIDO EMITIDO ÚLTIMO AVISO AO SACADO";
                        case 24: return "INSTRUÇÃO INCOMPATÍVEL - EXISTE INSTRUÇÃO DE PROTESTO PARA O TÍTULO";
                        case 25: return "INSTRUÇÃO INCOMPATÍVEL - NÃO EXISTE INSTRUÇÃO DE PROTESTO PARA O TÍTULO";
                        case 26: return "INSTRUÇÃO NÃO ACEITA POR TER SIDO EMITIDO ÚLTIMO AVISO AO SACADO";
                        case 27: return "INSTRUÇÃO NÃO ACEITA POR NÃO TER SIDO EMITIDA A ORDEM DE PROTESTO AO CARTÓRIO";
                        case 28: return "JÁ EXISTE UMA MESMA INSTRUÇÃO CADASTRADA ANTERIORMENTE PARA O TÍTULO";
                        case 29: return "VALOR LÍQUIDO + VALOR DO ABATIMENTO DIFERENTE DO VALOR DO TÍTULO REGISTRADO, OU VALOR" +
                                        "DO ABATIMENTO MAIOR QUE 90% DO VALOR DO TÍTULO";
                        case 30: return "EXISTE UMA INSTRUÇÃO DE NÃO PROTESTAR ATIVA PARA O TÍTULO";
                        case 31: return "EXISTE UMA OCORRÊNCIA DO SACADO QUE BLOQUEIA A INSTRUÇÃO";
                        case 32: return "DEPOSITÁRIA DO TÍTULO = 9999 OU CARTEIRA NÃO ACEITA PROTESTO";
                        case 33: return "ALTERAÇÃO DE VENCIMENTO IGUAL À REGISTRADA NO SISTEMA OU QUE TORNA O TÍTULO VENCIDO";
                        case 34: return "INSTRUÇÃO DE EMISSÃO DE AVISO DE COBRANÇA PARA TÍTULO VENCIDO ANTES DO VENCIMENTO";
                        case 35: return "SOLICITAÇÃO DE CANCELAMENTO DE INSTRUÇÃO INEXISTENTE";
                        case 36: return "TÍTULO SOFRENDO ALTERAÇÃO DE CONTROLE (AGÊNCIA/CONTA/CARTEIRA/NOSSO NÚMERO)";
                        case 37: return "INSTRUÇÃO NÃO PERMITIDA PARA A CARTEIRA";
                        default: return string.Format("{0:00}-Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoBaixaRejeitada:
                    switch (codMotivo)
                    {
                        case 1: return "CARTEIRA/Nº NÚMERO NÃO NUMÉRICO";
                        case 4: return "NOSSO NÚMERO EM DUPLICIDADE NUM MESMO MOVIMENTO";
                        case 5: return "SOLICITAÇÃO DE BAIXA PARA TÍTULO JÁ BAIXADO OU LIQUIDADO";
                        case 6: return "SOLICITAÇÃO DE BAIXA PARA TÍTULO NÃO REGISTRADO NO SISTEMA";
                        case 7: return "COBRANÇA PRAZO CURTO - SOLICITAÇÃO DE BAIXA P/ TÍTULO NÃO REGISTRADO NO SISTEMA";
                        case 8: return "SOLICITAÇÃO DE BAIXA PARA TÍTULO EM FLOATING";  
                        default: return string.Format("{0:00}-Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoCobrancaContratual:
                    switch (codMotivo)
                    {
                        case 16: return "ABATIMENTO/ALTERAÇÃO DO VALOR DO TÍTULO OU SOLICITAÇÃO DE BAIXA BLOQUEADOS";
                        case 40: return "NÃO APROVADA DEVIDO AO IMPACTO NA ELEGIBILIDADE DE GARANTIAS";
                        case 41: return "AUTOMATICAMENTE REJEITADA";
                        case 42: return "CONFIRMA RECEBIMENTO DE INSTRUÇÃO – PENDENTE DE ANÁLISE";  
                        default: return string.Format("{0:00}-Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoAlegacaoDoSacado:
                    switch (codMotivo)
                    {
                        case 1313: return "SOLICITA A PRORROGAÇÃO DO VENCIMENTO PARA";
                        case 1321: return "SOLICITA A DISPENSA DOS JUROS DE MORA";
                        case 1339: return "NÃO RECEBEU A MERCADORIA";
                        case 1347: return "A MERCADORIA CHEGOU ATRASADA";
                        case 1354: return "A MERCADORIA CHEGOU AVARIADA";
                        case 1362: return "A MERCADORIA CHEGOU INCOMPLETA";
                        case 1370: return "A MERCADORIA NÃO CONFERE COM O PEDIDO";
                        case 1388: return "A MERCADORIA ESTÁ À DISPOSIÇÃO";
                        case 1396: return "DEVOLVEU A MERCADORIA";
                        case 1404: return "NÃO RECEBEU A FATURA";
                        case 1412: return "A FATURA ESTÁ EM DESACORDO COM A NOTA FISCAL";
                        case 1420: return "O PEDIDO DE COMPRA FOI CANCELADO";
                        case 1438: return "A DUPLICATA FOI CANCELADA";
                        case 1446: return "QUE NADA DEVE OU COMPROU";
                        case 1453: return "QUE MANTÉM ENTENDIMENTOS COM O SACADOR";
                        case 1461: return "QUE PAGARÁ O TÍTULO EM:";
                        case 1479: return "QUE PAGOU O TÍTULO DIRETAMENTE AO CEDENTE EM:";
                        case 1487: return "QUE PAGARÁ O TÍTULO DIRETAMENTE AO CEDENTE EM:";
                        case 1495: return "QUE O VENCIMENTO CORRETO É:";
                        case 1503: return "QUE TEM DESCONTO OU ABATIMENTO DE:";
                        case 1719: return "SACADO NÃO FOI LOCALIZADO; CONFIRMAR ENDEREÇO";
                        case 1727: return "SACADO ESTÁ EM REGIME DE CONCORDATA";
                        case 1735: return "SACADO ESTÁ EM REGIME DE FALÊNCIA";
                        case 1750: return "SACADO SE RECUSA A PAGAR JUROS BANCÁRIOS";
                        case 1768: return "SACADO SE RECUSA A PAGAR COMISSÃO DE PERMANÊNCIA";
                        case 1776: return "NÃO FOI POSSÍVEL A ENTREGA DO BLOQUETO AO SACADO";
                        case 1784: return "BLOQUETO NÃO ENTREGUE, MUDOU-SE/DESCONHECIDO";
                        case 1792: return "BLOQUETO NÃO ENTREGUE, CEP ERRADO/INCOMPLETO";
                        case 1800: return "BLOQUETO NÃO ENTREGUE, NÚMERO NÃO EXISTE/ENDEREÇO INCOMPLETO";
                        case 1818: return "BLOQUETO NÃO RETIRADO PELO SACADO. REENVIADO PELO CORREIO";
                        case 1826: return "ENDEREÇO DE E-MAIL INVÁLIDO. BLOQUETO ENVIADO PELO CORREIO";  
                        default: return string.Format("{0:00}-Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoInstrucaoProtestoRejeitadaSustadaOuPendente:
                    switch (codMotivo)
                    {
                        case 1610: return "DOCUMENTAÇÃO SOLICITADA AO CEDENTE";
                        case 3111: return "SUSTAÇÃO SOLICITADA AG. CEDENTE";
                        case 3228: return "ATOS DA CORREGEDORIA ESTADUAL";
                        case 3244: return "PROTESTO SUSTADO / CEDENTE NÃO ENTREGOU A DOCUMENTAÇÃO";
                        case 3269: return "DATA DE EMISSÃO DO TÍTULO INVÁLIDA/IRREGULAR";
                        case 3301: return "CGC/CPF DO SACADO INVÁLIDO/INCORRETO";
                        case 3319: return "SACADOR/AVALISTA E PESSOA FÍSICA";
                        case 3327: return "CEP DO SACADO INCORRETO";
                        case 3335: return "DEPOSITÁRIA INCOMPATÍVEL COM CEP DO SACADO";
                        case 3343: return "CGC/CPF SACADOR INVALIDO/INCORRETO";
                        case 3350: return "ENDEREÇO DO SACADO INSUFICIENTE";
                        case 3368: return "PRAÇA PAGTO INCOMPATÍVEL COM ENDEREÇO";
                        case 3376: return "FALTA NÚMERO/ESPÉCIE DO TÍTULO";
                        case 3384: return "TÍTULO ACEITO S/ ASSINATURA DO SACADOR";
                        case 3392: return "TÍTULO ACEITO S/ ENDOSSO CEDENTE OU IRREGULAR";
                        case 3400: return "TÍTULO SEM LOCAL OU DATA DE EMISSÃO";
                        case 3418: return "TÍTULO ACEITO COM VALOR EXTENSO DIFERENTE DO NUMÉRICO";
                        case 3426: return "TÍTULO ACEITO DEFINIR ESPÉCIE DA DUPLICATA";
                        case 3434: return "DATA EMISSÃO POSTERIOR AO VENCIMENTO";
                        case 3442: return "TÍTULO ACEITO DOCUMENTO NÃO PROSTESTÁVEL";
                        case 3459: return "TÍTULO ACEITO EXTENSO VENCIMENTO IRREGULAR";
                        case 3467: return "TÍTULO ACEITO FALTA NOME FAVORECIDO";
                        case 3475: return "TÍTULO ACEITO FALTA PRAÇA DE PAGAMENTO";
                        case 3483: return "TÍTULO ACEITO FALTA CPF ASSINANTE CHEQUE"; 
                        default: return string.Format("{0:00}-Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoInstrucaoCancelada:
                    switch (codMotivo)
                    {
                        case 1156: return "NÃO PROTESTAR";
                        case 2261: return "DISPENSAR JUROS/COMISSÃO DE PERMANÊNCIA";
                        default: return string.Format("{0:00}-Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoChequeDevolvido:
                    switch (codMotivo)
                    {
                        case 11: return "CHEQUE SEM FUNDOS - PRIMEIRA APRESENTAÇÃO - PASSÍVEL DE REAPRESENTAÇÃO: SIM";
                        case 12: return "CHEQUE SEM FUNDOS - SEGUNDA APRESENTAÇÃO - PASSÍVEL DE REAPRESENTAÇÃO: NÃO ";
                        case 13: return "CONTA ENCERRADA - PASSÍVEL DE REAPRESENTAÇÃO: NÃO";
                        case 14: return "PRÁTICA ESPÚRIA - PASSÍVEL DE REAPRESENTAÇÃO: NÃO";
                        case 20: return "FOLHA DE CHEQUE CANCELADA POR SOLICITAÇÃO DO CORRENTISTA - PASSÍVEL DE REAPRESENTAÇÃO: NÃO";
                        case 21: return "CONTRA-ORDEM (OU REVOGAÇÃO) OU OPOSIÇÃO (OU SUSTAÇÃO) AO PAGAMENTO PELO EMITENTE OU PELO " +
                                        "PORTADOR - PASSÍVEL DE REAPRESENTAÇÃO: SIM";
                        case 22: return "DIVERGÊNCIA OU INSUFICIÊNCIA DE ASSINATURAb - PASSÍVEL DE REAPRESENTAÇÃO: SIM";
                        case 23: return "CHEQUES EMITIDOS POR ENTIDADES E ÓRGÃOS DA ADMINISTRAÇÃO PÚBLICA FEDERAL DIRETA E INDIRETA, " +
                                        "EM DESACORDO COM OS REQUISITOS CONSTANTES DO ARTIGO 74, § 2º, DO DECRETO-LEI Nº 200, DE 25.02.1967. - " +
                                        "PASSÍVEL DE REAPRESENTAÇÃO: SIM";
                        case 24: return "BLOQUEIO JUDICIAL OU DETERMINAÇÃO DO BANCO CENTRAL DO BRASIL - PASSÍVEL DE REAPRESENTAÇÃO: SIM";
                        case 25: return "CANCELAMENTO DE TALONÁRIO PELO BANCO SACADO - PASSÍVEL DE REAPRESENTAÇÃO: NÃO";
                        case 28: return "CONTRA-ORDEM (OU REVOGAÇÃO) OU OPOSIÇÃO (OU SUSTAÇÃO) AO PAGAMENTO OCASIONADA POR FURTO OU ROUBO - " +
                                        "PASSÍVEL DE REAPRESENTAÇÃO: NÃO";
                        case 29: return "CHEQUE BLOQUEADO POR FALTA DE CONFIRMAÇÃO DO RECEBIMENTO DO TALONÁRIO PELO CORRENTISTA - " +
                                        "PASSÍVEL DE REAPRESENTAÇÃO: SIM";
                        case 30: return "FURTO OU ROUBO DE MALOTES - PASSÍVEL DE REAPRESENTAÇÃO: NÃO";
                        case 31: return "ERRO FORMAL (SEM DATA DE EMISSÃO, COM O MÊS GRAFADO NUMERICAMENTE, AUSÊNCIA DE ASSINATURA, " +
                                        "NÃO-REGISTRO DO VALOR POR EXTENSO) - PASSÍVEL DE REAPRESENTAÇÃO: SIM";
                        case 32: return "AUSÊNCIA OU IRREGULARIDADE NA APLICAÇÃO DO CARIMBO DE COMPENSAÇÃO - PASSÍVEL DE REAPRESENTAÇÃO: SIM";
                        case 33: return "DIVERGÊNCIA DE ENDOSSO - PASSÍVEL DE REAPRESENTAÇÃO: SIM";
                        case 34: return "CHEQUE APRESENTADO POR ESTABELECIMENTO BANCÁRIO QUE NÃO O INDICADO NO CRUZAMENTO EM PRETO, SEM O " +
                                        "ENDOSSO-MANDATO - PASSÍVEL DE REAPRESENTAÇÃO: SIM";
                        case 35: return "CHEQUE FRAUDADO, EMITIDO SEM PRÉVIO CONTROLE OU RESPONSABILIDADE DO ESTABELECIMENTO BANCÁRIO " +
                                        "(\"CHEQUE UNIVERSAL\"), OU AINDA COM ADULTERAÇÃO DA PRAÇA SACADA - PASSÍVEL DE REAPRESENTAÇÃO: NÃO";
                        case 36: return "CHEQUE EMITIDO COM MAIS DE UM ENDOSSO - PASSÍVEL DE REAPRESENTAÇÃO: SIM";
                        case 40: return "MOEDA INVÁLIDA - PASSÍVEL DE REAPRESENTAÇÃO: NÃO";
                        case 41: return "CHEQUE APRESENTADO A BANCO QUE NÃO O SACADO - PASSÍVEL DE REAPRESENTAÇÃO: SIM";
                        case 42: return "CHEQUE NÃO-COMPENSÁVEL NA SESSÃO OU SISTEMA DE COMPENSAÇÃO EM QUE FOI APRESENTADO - " +
                                        "PASSÍVEL DE REAPRESENTAÇÃO: SIM";
                        case 43: return "CHEQUE, DEVOLVIDO ANTERIORMENTE PELOS MOTIVOS 21, 22, 23, 24, 31 OU 34, NÃO-PASSÍVEL " +
                                        "DE REAPRESENTAÇÃO EM VIRTUDE DE PERSISTIR O MOTIVO DA DEVOLUÇÃO - PASSÍVEL DE REAPRESENTAÇÃO: NÃO";
                        case 44: return "CHEQUE PRESCRITO - PASSÍVEL DE REAPRESENTAÇÃO: NÃO";
                        case 45: return "CHEQUE EMITIDO POR ENTIDADE OBRIGADA A REALIZAR MOVIMENTAÇÃO E UTILIZAÇÃO DE RECURSOS FINANCEIROS " +
                                        "DO TESOURO NACIONAL MEDIANTE ORDEM BANCÁRIA - PASSÍVEL DE REAPRESENTAÇÃO: NÃO";
                        case 48: return "CHEQUE DE VALOR SUPERIOR AO ESTABELECIDO, EMITIDO SEM A IDENTIFICAÇÃO DO BENEFICIÁRIO, DEVENDO SER " +
                                        "DEVOLVIDO A QUALQUER TEMPO - PASSÍVEL DE REAPRESENTAÇÃO: SIM";
                        case 49: return "REMESSA NULA, CARACTERIZADA PELA REAPRESENTAÇÃO DE CHEQUE DEVOLVIDO PELOS MOTIVOS 12, 13, 14, 20, " +
                                        "25, 28, 30, 35, 43, 44 E 45, PODENDO A SUA DEVOLUÇÃO OCORRER A QUALQUER TEMPO - PASSÍVEL DE REAPRESENTAÇÃO: NÃO";
                        default: return string.Format("{0:00}-Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoRegistroConfirmado:
                    switch (codMotivo)
                    {
                        case 1: return "CEP SEM ATENDIMENTO DE PROTESTO NO MOMENTO";
                        default: return string.Format("{0:00}-Outros Motivos", codMotivo);
                    }

                default: return string.Format("{0:00}-Outros Motivos", codMotivo);
            }
        }

        /// <summary>
        /// Calculars the digito verificador.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string CalcularDigitoVerificador(Titulo titulo)
        {
            string docto;
            if (titulo.Carteira.IsIn("116", "117", "119", "134", "135", "136", "104", "147",
                "105", "112", "212", "166", "113", "126", "131", "145", "150", "168"))
            {
                docto = string.Format("{0}{1}", titulo.Carteira, titulo.NossoNumero.FillRight(TamanhoMaximoNossoNum, '0'));
            }
            else
            {
                docto = String.Format("{0}{1}{2}{3}", titulo.Parent.Cedente.Agencia,
                    titulo.Parent.Cedente.Conta, titulo.Carteira, titulo.NossoNumero.FillRight(TamanhoMaximoNossoNum, '0'));
            }

            Modulo.MultiplicadorInicial = 1;
            Modulo.MultiplicadorFinal = 2;
            Modulo.MultiplicadorAtual = 2;
            Modulo.FormulaDigito = CalcDigFormula.Modulo10;
            Modulo.Documento = docto;
            Modulo.Calcular();
            return Modulo.DigitoFinal.ToString();
        }

        /// <summary>
        /// Montars the campo codigo cedente.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string MontarCampoCodigoCedente(Titulo titulo)
        {
            return string.Format(@"{0}/{1}-{2}", titulo.Parent.Cedente.Agencia,
                titulo.Parent.Cedente.Conta, titulo.Parent.Cedente.ContaDigito);
        }

        /// <summary>
        /// Montars the campo nosso numero.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string MontarCampoNossoNumero(Titulo titulo)
        {
            return string.Format(@"{0}/{1}-{2}", titulo.Carteira,
                titulo.NossoNumero.FillRight(TamanhoMaximoNossoNum, '0'), CalcularDigitoVerificador(titulo));
        }

        /// <summary>
        /// Monta o codigo de barras.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string MontarCodigoBarras(Titulo titulo)
        {
            var fatorVencimento = titulo.Vencimento.CalcularFatorVencimento();
            var aNossoNumero = String.Format("{0}{1}{2}", titulo.Carteira, titulo.NossoNumero.FillRight(8, '0'),
                CalcularDigitoVerificador(titulo));
            var aAgenciaCc = String.Format("{0}{1}{2}", titulo.Parent.Cedente.Agencia,
                titulo.Parent.Cedente.Conta, titulo.Parent.Cedente.ContaDigito); 

            var codigoBarras = string.Format("{0:000}9{1}{2}{3}{4}000", Numero, fatorVencimento,
                       titulo.ValorDocumento.ToDecimalString(10), aNossoNumero, aAgenciaCc);

            var digitoCodBarras = CalcularDigitoCodigoBarras(codigoBarras);
            return codigoBarras.Insert(4, digitoCodBarras);
        }

        /// <summary>
        /// Gerars the registro header400.
        /// </summary>
        /// <param name="numeroRemessa">The numero remessa.</param>
        /// <param name="aRemessa">A remessa.</param>
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
		public override void GerarRegistroHeader400(int numeroRemessa, List<string> aRemessa)
		{
			var cedente = Banco.Parent.Cedente;
			var wLinha = new StringBuilder();

			//GERAR REGISTRO-HEADER DO ARQUIVO
			wLinha.Append("0");                                   // 1 a 1     - IDENTIFICAÇÃO DO REGISTRO HEADER
			wLinha.Append("1");                                   // 2 a 2     - TIPO DE OPERAÇÃO - REMESSA
			wLinha.Append("REMESSA");                             // 3 a 9     - IDENTIFICAÇÃO POR EXTENSO DO MOVIMENTO
			wLinha.Append("01");                                  // 10 a 11   - IDENTIFICAÇÃO DO TIPO DE SERVIÇO
			wLinha.Append("COBRANCA".FillLeft(15));               // 12 a 26   - IDENTIFICAÇÃO POR EXTENSO DO TIPO DE SERVIÇO
			wLinha.Append(cedente.Agencia.ZeroFill(4));           // 27 a 30   - AGÊNCIA MANTENEDORA DA CONTA
			wLinha.Append("00");                                  // 31 a 32   - COMPLEMENTO DE REGISTRO
			wLinha.Append(cedente.Conta.ZeroFill(5));             // 33 a 37   - NÚMERO DA CONTA CORRENTE DA EMPRESA
			wLinha.Append(cedente.ContaDigito.ZeroFill(1));       // 38 a 38   - DÍGITO DE AUTO CONFERÊNCIA AG/CONTA EMPRESA
			wLinha.Append("".FillLeft(8));                        // 39 a 46   - COMPLEMENTO DO REGISTRO
			wLinha.Append(cedente.Nome.FillLeft(30));             // 47 a 76   - NOME POR EXTENSO DA "EMPRESA MÃE"
			wLinha.AppendFormat("{0:000}", Banco.Numero);         // 77 a 79   - Nº DO BANCO NA CÂMARA DE COMPENSAÇÃO
			wLinha.Append("BANCO ITAU SA".FillLeft(15));          // 80 a 94   - NOME POR EXTENSO DO BANCO COBRADOR
			wLinha.AppendFormat("{0:ddMMyy}", DateTime.Now);      // 95 a 100  - DATA DE GERAÇÃO DO ARQUIVO
			wLinha.Append("".FillLeft(294));                      // 101 a 394 - COMPLEMENTO DO REGISTRO
			wLinha.Append("1".ZeroFill(6));                       // 395 a 400 - NÚMERO SEQÜENCIAL DO REGISTRO NO ARQUIVO
			
			aRemessa.Add(wLinha.ToString().ToUpper());
		}

        /// <summary>
        /// Gera o registro header240.
        /// </summary>
        /// <param name="numeroRemessa">The numero remessa.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public override string GerarRegistroHeader240(int numeroRemessa)
        {
			string aTipoInscricao;
			switch (Banco.Parent.Cedente.TipoInscricao)
			{
				case PessoaCedente.Fisica: aTipoInscricao = "1"; break;
				default: aTipoInscricao = "2"; break;
			}

			var cedente = Banco.Parent.Cedente;
			var result = new StringBuilder();

			//GERAR REGISTRO-HEADER DO ARQUIVO
			result.AppendFormat("{0:000}", Banco.Numero);		//1 a 3 - Código do banco
			result.Append("0000");								//4 a 7 - Lote de serviço
			result.Append("0");									//8 - Tipo de registro - Registro header de arquivo
            result.Append("".FillLeft(9));						//9 a 17 Uso exclusivo FEBRABAN/CNAB
            result.Append(aTipoInscricao);						//18 - Tipo de inscrição do cedente
            result.Append(cedente.CNPJCPF.ZeroFill(14));		//19 a 32 -Número de inscrição do cedente
            result.Append("".FillLeft(20));						//33 a 52 - Brancos
            result.Append("0");									//53 - Zeros
            result.Append(cedente.Agencia.ZeroFill(4));			//54 a 57 - Código da agência do cedente
            result.Append(" ");									//58 - Brancos
            result.Append("0000000");							//59 a 65 - Zeros
            result.Append(cedente.Conta.ZeroFill(5));			//66 a 70 - Número da conta do cedente
            result.Append(" ");									//71 - Branco
            result.Append(cedente.ContaDigito.ZeroFill(1));		//72 - Dígito da conta do cedente
            result.Append(cedente.Nome.FillLeft(30));			//73 a 102 - Nome do cedente
            result.Append("BANCO ITAU SA".PadLeft(30));			//103 a 132 - Nome do banco
            result.Append("".FillLeft(10));						//133 A 142 - Brancos
            result.Append("1");                                 //143 - Código de Remessa (1) / Retorno (2)
            result.AppendFormat("{0:ddMMyyyy}", DateTime.Now);  //144 a 151 - Data do de geração do arquivo
            result.AppendFormat("{0:hhmmss}", DateTime.Now);    //152 a 157 - Hora de geração do arquivo
			result.Append("000000");                            //158 a 163 - Número sequencial do arquivo retorno
            result.Append("040");                               //164 a 166 - Número da versão do layout do arquivo
            result.Append("00000");                             //167 a 171 - Zeros
            result.Append("".FillLeft(54));                     //172 a 225 - 54 Brancos
            result.Append("000");                               //226 a 228 - zeros
            result.Append("".FillLeft(12));                     //229 a 240 - Brancos

			//GERAR REGISTRO HEADER DO LOTE
			result.Append(Environment.NewLine);
			result.AppendFormat("{0:000}", Banco.Numero);		//1 a 3 - Código do banco
            result.Append("0001");                              //4 a 7 - Lote de serviço
            result.Append("1");                                 //8 - Tipo de registro - Registro header de arquivo
            result.Append("R");                                 //9 - Tipo de operação: R (Remessa) ou T (Retorno)
            result.Append("01");                                //10 a 11 - Tipo de serviço: 01 (Cobrança)
            result.Append("00");                                //12 a 13 - Forma de lançamento: preencher com ZEROS no caso de cobrança
            result.Append("030");                               //14 a 16 - Número da versão do layout do lote
            result.Append(" ");                                 //17 - Uso exclusivo FEBRABAN/CNAB
            result.Append(aTipoInscricao);                      //18 - Tipo de inscrição do cedente
            result.Append(cedente.CNPJCPF.ZeroFill(15));        //19 a 33 -Número de inscrição do cedente
            result.Append("".FillLeft(20));                     //34 a 53 - Brancos
            result.Append("0");                                 //54 - Zeros
            result.Append(cedente.Agencia.ZeroFill(4));         //55 a 58 - Código da agência do cedente
            result.Append(" ");                                 //59
            result.Append("0000000");                           //60 a 66
            result.Append(cedente.Conta.ZeroFill(5));           //67 a 71 - Número da conta do cedente
            result.Append(" ");                                 //72
            result.Append(cedente.ContaDigito);                 //73 - Dígito verificador da agência / conta
			result.Append(cedente.Nome.FillLeft(30));           //74 a 103 - Nome do cedente
            result.Append("".FillLeft(80));                     //104 a 183 - Brancos
            result.Append("00000000");                          //184 a 191 - Número sequência do arquivo retorno.
            result.AppendFormat("{0:ddMMyyyy}", DateTime.Now);  //192 a 199 - Data de geração do arquivo
            result.Append("".ZeroFill(8));                      //200 a 207 - Data do crédito - Só para arquivo retorno
            result.Append("".FillLeft(33));                     //208 a 240 - Uso exclusivo FEBRABAN/CNAB

			return result.ToString().ToUpper();
        }

        /// <summary>
        /// Gerars the registro transacao400.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <param name="aRemessa">A remessa.</param>
        public override void GerarRegistroTransacao400(Titulo titulo, List<string> aRemessa)
        {
			var doMontaInstrucoes1 = new Func<string>(() =>
			{
				if (titulo.Mensagem.Count < 1)
					return string.Empty;

				var result = new StringBuilder();
				result.Append(Environment.NewLine); 
				result.Append("6");                                         // IDENTIFICAÇÃO DO REGISTRO
				result.Append("2");                                         // IDENTIFICAÇÃO DO LAYOUT PARA O REGISTRO
				result.Append(titulo.Mensagem[0].FillLeft(69));             // CONTEÚDO DA 1ª LINHA DE IMPRESSÃO DA ÁREA "INSTRUÇÕES” DO BOLETO
				
				if(titulo.Mensagem.Count >= 2)
					result.Append(titulo.Mensagem[1].FillLeft(69));         // CONTEÚDO DA 2ª LINHA DE IMPRESSÃO DA ÁREA "INSTRUÇÕES” DO BOLETO
				else
				    result.Append("".FillLeft(69));                         // CONTEÚDO DO RESTANTE DAS LINHAS
				
				if(titulo.Mensagem.Count >= 3)
					result.Append(titulo.Mensagem[2].FillLeft(69));         // CONTEÚDO DA 3ª LINHA DE IMPRESSÃO DA ÁREA "INSTRUÇÕES” DO BOLETO
				else
				    result.Append("".FillLeft(69));                         // CONTEÚDO DO RESTANTE DAS LINHAS
				
				if(titulo.Mensagem.Count >= 4)
					result.Append(titulo.Mensagem[3].FillLeft(69));         // CONTEÚDO DA 4ª LINHA DE IMPRESSÃO DA ÁREA "INSTRUÇÕES” DO BOLETO
				else
				    result.Append("".FillLeft(69));                         // CONTEÚDO DO RESTANTE DAS LINHAS
				
				if(titulo.Mensagem.Count >= 5)
					result.Append(titulo.Mensagem[4].FillLeft(69));         // CONTEÚDO DA 5ª LINHA DE IMPRESSÃO DA ÁREA "INSTRUÇÕES” DO BOLETO
				else
				    result.Append("".FillLeft(69));                         // CONTEÚDO DO RESTANTE DAS LINHAS

				result.Append("".FillLeft(47));                             // COMPLEMENTO DO REGISTRO
				result.AppendFormat("{0:000000}", aRemessa.Count + 2);      // Nº SEQÜENCIAL DO REGISTRO NO ARQUIVO

				return result.ToString().ToUpper();
			});

			//Pegando o Tipo de Ocorrencia
			string aTipoOcorrencia;
			switch (titulo.OcorrenciaOriginal.Tipo)
			{
				case TipoOcorrencia.RemessaBaixar: aTipoOcorrencia = "02"; break;
				case TipoOcorrencia.RemessaConcederAbatimento: aTipoOcorrencia = "04"; break;
				case TipoOcorrencia.RemessaCancelarAbatimento: aTipoOcorrencia = "05"; break;
				case TipoOcorrencia.RemessaAlterarVencimento: aTipoOcorrencia = "06"; break;
				case TipoOcorrencia.RemessaAlterarUsoEmpresa: aTipoOcorrencia = "07"; break;
				case TipoOcorrencia.RemessaAlterarSeuNumero: aTipoOcorrencia = "08"; break;
				case TipoOcorrencia.RemessaProtestar: aTipoOcorrencia = "09"; break;
				case TipoOcorrencia.RemessaNaoProtestar: aTipoOcorrencia = "10"; break;
				case TipoOcorrencia.RemessaProtestoFinsFalimentares: aTipoOcorrencia = "11"; break;
				case TipoOcorrencia.RemessaSustarProtesto: aTipoOcorrencia = "18"; break;
				case TipoOcorrencia.RemessaOutrasAlteracoes: aTipoOcorrencia = "31"; break;
				case TipoOcorrencia.RemessaBaixaporPagtoDiretoCedente: aTipoOcorrencia = "34"; break;
				case TipoOcorrencia.RemessaCancelarInstrucao: aTipoOcorrencia = "35"; break;
				case TipoOcorrencia.RemessaAlterarVencSustarProtesto: aTipoOcorrencia = "37"; break;
				case TipoOcorrencia.RemessaCedenteDiscordaSacado: aTipoOcorrencia = "38"; break;
				case TipoOcorrencia.RemessaCedenteSolicitaDispensaJuros: aTipoOcorrencia = "47"; break;
				default: aTipoOcorrencia = "01"; break;
			}

			//Pegando o Aceite do Titulo
			string aTipoAceite;
			switch (titulo.Aceite)
			{
				case AceiteTitulo.Nao: aTipoAceite = "N"; break;
				default: aTipoAceite = "A"; break;
			}

			//Pegando o tipo de EspecieDoc
			var aTipoEspecieDoc = string.Empty;
			if (titulo.EspecieDoc.Trim() == "DM")
				aTipoEspecieDoc = "01";
			else if (titulo.EspecieDoc.Trim() == "NP")
				aTipoEspecieDoc = "02";
			else if (titulo.EspecieDoc.Trim() == "NS")
				aTipoEspecieDoc = "03";
			else if (titulo.EspecieDoc.Trim() == "ME")
				aTipoEspecieDoc = "04";
			else if (titulo.EspecieDoc.Trim() == "RC")
				aTipoEspecieDoc = "05";
			else if (titulo.EspecieDoc.Trim() == "CT")
				aTipoEspecieDoc = "06";
			else if (titulo.EspecieDoc.Trim() == "CS")
				aTipoEspecieDoc = "07";
			else if (titulo.EspecieDoc.Trim() == "DS")
				aTipoEspecieDoc = "08";
			else if (titulo.EspecieDoc.Trim() == "LC")
				aTipoEspecieDoc = "09";
			else if (titulo.EspecieDoc.Trim() == "ND")
				aTipoEspecieDoc = "13";
			else if (titulo.EspecieDoc.Trim() == "DD")
				aTipoEspecieDoc = "15";
			else if (titulo.EspecieDoc.Trim() == "EC")
				aTipoEspecieDoc = "16";
			else if (titulo.EspecieDoc.Trim() == "PS")
				aTipoEspecieDoc = "17";
			else if (titulo.EspecieDoc.Trim() == "DV")
				aTipoEspecieDoc = "99";

			//Mora Juros
			string aDataMoraJuros;
			if (titulo.ValorMoraJuros > 0)
			{
				if (titulo.DataMoraJuros.HasValue)
					aDataMoraJuros = string.Format("{0:ddMMyyyy}", titulo.DataMoraJuros);
				else
					aDataMoraJuros = "".ZeroFill(8);
			}
			else
				aDataMoraJuros = "".ZeroFill(8);

			//Descontos
			string aDataDesconto;
			if (titulo.ValorDesconto > 0)
			{
				if (titulo.DataDesconto.HasValue)
					aDataDesconto = string.Format("{0:ddMMyyyy}", titulo.DataDesconto);
				else
					aDataDesconto = "".ZeroFill(8);
			}
			else
				aDataDesconto = "".ZeroFill(8);

			//Pegando Tipo Cendete
			string aTipoCedente;
			switch(titulo.Parent.Cedente.TipoInscricao)
			{
                case PessoaCedente.Fisica: aTipoCedente = "01"; break;
                default: aTipoCedente = "02"; break;
			}

			//Pegando Tipo de Sacado
			string aTipoSacado;
			switch (titulo.Sacado.Pessoa)
			{
				case Pessoa.Fisica: aTipoSacado = "01"; break;
				case Pessoa.Juridica: aTipoSacado = "02"; break;
				default: aTipoSacado = "99"; break;
			}

			//endereco
			var end = string.Format("{0} {1} {2}", titulo.Sacado.Logradouro, 
					titulo.Sacado.Numero, titulo.Sacado.Complemento).FillLeft(40);

			var wLinha = new StringBuilder();

			//Cobrança sem registro com opção de envio de arquivo remessa
			if (titulo.Carteira.Trim().IsIn("102", "103", "107", "172", "173", "196"))
			{
				var aNossoNumero = Banco.MontarCampoNossoNumero(titulo);		

				wLinha.Append("6");                                                               // 6 - FIXO
                wLinha.Append("1");                                                               // 1 - FIXO
                wLinha.Append(titulo.Parent.Cedente.Agencia.ZeroFill(4));                         // AGÊNCIA MANTENEDORA DA CONTA
                wLinha.Append("00");                                                              // COMPLEMENTO DE REGISTRO
                wLinha.Append(titulo.Parent.Cedente.Conta.ZeroFill(5));                           // NÚMERO DA CONTA CORRENTE DA EMPRESA
                wLinha.Append(titulo.Parent.Cedente.ContaDigito.ZeroFill(1));                     // DÍGITO DE AUTO CONFERÊNCIA AG/CONTA EMPRESA
                wLinha.Append(titulo.Carteira.Trim());                                            // NÚMERO DA CARTEIRA NO BANCO
                wLinha.Append(titulo.NossoNumero.ZeroFill(8));                                    // IDENTIFICAÇÃO DO TÍTULO NO BANCO
                wLinha.Append(aNossoNumero[aNossoNumero.Length-1]);					              // DAC DO NOSSO NÚMERO
                wLinha.Append("0");                                                               // 0 - R$
                wLinha.Append("R$".FillLeft(4));                                                  // LITERAL DE MOEDA
                wLinha.Append(titulo.ValorDocumento.ToDecimalString(13));                         // VALOR NOMINAL DO TÍTULO
                wLinha.Append(titulo.SeuNumero.FillLeft(10));                                     // IDENTIFICAÇÃO DO TÍTULO NA EMPRESA
                wLinha.AppendFormat("{0:ddMMyy}", titulo.Vencimento);                             // DATA DE VENCIMENTO DO TÍTULO
				wLinha.Append(aTipoEspecieDoc.ZeroFill(2));                                       // ESPÉCIE DO TÍTULO
				wLinha.Append(aTipoAceite);                                                       // IDENTIFICAÇÃO DE TITILO ACEITO OU NÃO ACEITO
                wLinha.AppendFormat("{0:ddMMyy}", titulo.DataDocumento);                          // DATA DE EMISSÃO
                   
				//Dados do sacado
                wLinha.Append(aTipoSacado);                                                       // IDENTIFICAÇÃO DO TIPO DE INSCRIÇÃO/SACADO
                wLinha.Append(titulo.Sacado.CNPJCPF.ZeroFill(15));                                // Nº DE INSCRIÇÃO DO SACADO  (CPF/CGC)
                wLinha.Append(titulo.Sacado.NomeSacado.FillLeft(30));                             // NOME DO SACADO
                wLinha.Append("".FillLeft(9));                                                    // BRANCOS(COMPLEMENTO DE REGISTRO)
                wLinha.Append(end);																  // RUA, NÚMERO E COMPLEMENTO DO SACADO
                wLinha.Append(titulo.Sacado.Bairro.FillLeft(12));                                 // BAIRRO DO SACADO
                wLinha.Append(titulo.Sacado.CEP.OnlyNumbers().ZeroFill(8));                       // CEP DO SACADO
                wLinha.Append(titulo.Sacado.Cidade.FillLeft(15));                                 // CIDADE DO SACADO
                wLinha.Append(titulo.Sacado.UF.FillLeft(2));                                      // UF DO SACADO
                  
				   //Dados do sacador/avalista}
                 wLinha.Append("".FillLeft(30));                                                  // NOME DO SACADOR/AVALISTA
                 wLinha.Append("".FillLeft(4));                                                   // COMPLEMENTO DO REGISTRO
                 wLinha.Append(titulo.LocalPagamento.FillLeft(55));                               // LOCAL PAGAMENTO
                 wLinha.Append("".FillLeft(51));                                                  // LOCAL PAGAMENTO 2
                 wLinha.Append("01");                                                             // IDENTIF. TIPO DE INSCRIÇÃO DO SACADOR/AVALISTA
                 wLinha.Append("".ZeroFill(15));                                                  // NÚMERO DE INSCRIÇÃO DO SACADOR/AVALISTA
                 wLinha.Append("".FillLeft(31));                                                  // COMPLEMENTO DO REGISTRO
                 wLinha.AppendFormat("{0:000000}", aRemessa.Count + 1);

				wLinha.Append(doMontaInstrucoes1());
			}
			else
			{
				//Carteira com registro
				wLinha.Append("1");                                                               // 1 a 1 - IDENTIFICAÇÃO DO REGISTRO TRANSAÇÃO
                wLinha.Append(aTipoCedente);                                                      // TIPO DE INSCRIÇÃO DA EMPRESA
				wLinha.Append(titulo.Parent.Cedente.CNPJCPF.OnlyNumbers().ZeroFill(14));          // Nº DE INSCRIÇÃO DA EMPRESA (CPF/CGC)
				wLinha.Append(titulo.Parent.Cedente.Agencia.OnlyNumbers().ZeroFill(4));           // AGÊNCIA MANTENEDORA DA CONTA
				wLinha.Append("00");                                                              // COMPLEMENTO DE REGISTRO
				wLinha.Append(titulo.Parent.Cedente.Conta.OnlyNumbers().ZeroFill(5));             // NÚMERO DA CONTA CORRENTE DA EMPRESA
				wLinha.Append(titulo.Parent.Cedente.ContaDigito.OnlyNumbers().ZeroFill(1));       // DÍGITO DE AUTO CONFERÊNCIA AG/CONTA EMPRESA
				wLinha.Append("".FillLeft(4));                                                    // COMPLEMENTO DE REGISTRO
				wLinha.Append("0000");                                                            // CÓD.INSTRUÇÃO/ALEGAÇÃO A SER CANCELADA
				wLinha.Append(titulo.SeuNumero.FillLeft(25));                                     // IDENTIFICAÇÃO DO TÍTULO NA EMPRESA
				wLinha.Append(titulo.NossoNumero.ZeroFill(8));                                    // IDENTIFICAÇÃO DO TÍTULO NO BANCO
				wLinha.Append("0000000000000");                                                   // QUANTIDADE DE MOEDA VARIÁVEL
				wLinha.Append(titulo.Carteira);                                                   // NÚMERO DA CARTEIRA NO BANCO
				wLinha.Append("".FillLeft(21));                                                   // IDENTIFICAÇÃO DA OPERAÇÃO NO BANCO
                wLinha.Append("I");                                                               // CÓDIGO DA CARTEIRA
                wLinha.Append(aTipoOcorrencia);                                                   // IDENTIFICAÇÃO DA OCORRÊNCIA
                wLinha.Append(titulo.NumeroDocumento.FillLeft(10));                               // Nº DO DOCUMENTO DE COBRANÇA (DUPL.,NP ETC.)
                wLinha.AppendFormat("{0:ddMMyy}", titulo.Vencimento);                             // DATA DE VENCIMENTO DO TÍTULO
                wLinha.Append(titulo.ValorDocumento.ToDecimalString());                           // VALOR NOMINAL DO TÍTULO
				wLinha.AppendFormat("{0:000}", Banco.Numero);                                     // Nº DO BANCO NA CÂMARA DE COMPENSAÇÃO
                wLinha.Append("00000");                                                           // AGÊNCIA ONDE O TÍTULO SERÁ COBRADO
                wLinha.Append(aTipoEspecieDoc.ZeroFill(2));                                       // ESPÉCIE DO TÍTULO
                wLinha.Append(aTipoAceite);                                                       // IDENTIFICAÇÃO DE TITILO ACEITO OU NÃO ACEITO
                wLinha.AppendFormat("{0:ddMMyy}", titulo.DataDocumento);                          // DATA DA EMISSÃO DO TÍTULO
                wLinha.Append(titulo.Instrucao1.Trim().ZeroFill(2));                              // 1ª INSTRUÇÃO
                wLinha.Append(titulo.Instrucao2.Trim().ZeroFill(2));                              // 2ª INSTRUÇÃO
                wLinha.Append(titulo.ValorMoraJuros.ToDecimalString());                           // VALOR DE MORA POR DIA DE ATRASO
                wLinha.Append(aDataDesconto);                                                     // DATA LIMITE PARA CONCESSÃO DE DESCONTO
				wLinha.Append(titulo.ValorDesconto > 0 ? titulo.ValorDesconto.ToDecimalString() :
                         "".ZeroFill(13));                                                        // VALOR DO DESCONTO A SER CONCEDIDO
                wLinha.Append(titulo.ValorIOF.ToDecimalString());                                 // VALOR DO I.O.F. RECOLHIDO P/ NOTAS SEGURO
                wLinha.Append(titulo.ValorAbatimento.ToDecimalString());                          // VALOR DO ABATIMENTO A SER CONCEDIDO

                   //Dados do sacado
                wLinha.Append(aTipoSacado);                                                       // IDENTIFICAÇÃO DO TIPO DE INSCRIÇÃO/SACADO
                wLinha.Append(titulo.Sacado.CNPJCPF.OnlyNumbers().ZeroFill(14));                  // Nº DE INSCRIÇÃO DO SACADO  (CPF/CGC)
                wLinha.Append(titulo.Sacado.NomeSacado.FillLeft(30));                             // NOME DO SACADO
                wLinha.Append("".FillLeft(10));                                                   // BRANCOS(COMPLEMENTO DE REGISTRO)
                wLinha.Append(end);																  // RUA, NÚMERO E COMPLEMENTO DO SACADO
                wLinha.Append(titulo.Sacado.Bairro.FillLeft(12));                                 // BAIRRO DO SACADO
                wLinha.Append(titulo.Sacado.CEP.OnlyNumbers().ZeroFill(8));                       // CEP DO SACADO
                wLinha.Append(titulo.Sacado.Cidade.FillLeft(15));                                 // CIDADE DO SACADO
                wLinha.Append(titulo.Sacado.UF.FillLeft(2));                                      // UF DO SACADO

                   //Dados do sacador/avalista
                wLinha.Append("".FillLeft(30));                                                   // NOME DO SACADOR/AVALISTA
                wLinha.Append("".FillLeft(4));                                                    // COMPLEMENTO DO REGISTRO
                wLinha.Append(aDataMoraJuros);                                                    // DATA DE MORA
                wLinha.Append(titulo.DataProtesto.HasValue && titulo.DataProtesto > titulo.Vencimento ?
					titulo.DataProtesto.Value.Date.Subtract(titulo.Vencimento.Date).Days.ToString("00") :
				    "00");                                                                        // PRAZO
                wLinha.Append("".FillLeft(1));                                                    // BRANCOS
                wLinha.AppendFormat("{0:000000}", aRemessa.Count + 1);
			}

			aRemessa.Add(wLinha.ToString().ToUpper());

        }

        /// <summary>
        /// Gerars the registro transacao240.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.String.</returns>
		public override string GerarRegistroTransacao240(Titulo titulo)
		{
			//Pegando o Tipo de Ocorrencia
			string aTipoOcorrencia;
			switch (titulo.OcorrenciaOriginal.Tipo)
			{
				case TipoOcorrencia.RemessaBaixar: aTipoOcorrencia = "02"; break;
				case TipoOcorrencia.RemessaConcederAbatimento: aTipoOcorrencia = "04"; break;
				case TipoOcorrencia.RemessaCancelarAbatimento: aTipoOcorrencia = "05"; break;
				case TipoOcorrencia.RemessaAlterarVencimento: aTipoOcorrencia = "06"; break;
				case TipoOcorrencia.RemessaSustarProtesto: aTipoOcorrencia = "18"; break;
				case TipoOcorrencia.RemessaCancelarInstrucaoProtesto: aTipoOcorrencia = "10"; break;
				default: aTipoOcorrencia = "01"; break;
			}

			//Pegando o Aceite do Titulo
			string aTipoAceite;
			switch (titulo.Aceite)
			{
				case AceiteTitulo.Nao: aTipoAceite = "N"; break;
				default: aTipoAceite = "A"; break;
			}

			//Mora Juros
			string aDataMoraJuros;
			if (titulo.ValorMoraJuros > 0)
			{
				if (titulo.DataMoraJuros.HasValue)
					aDataMoraJuros = string.Format("{0:ddMMyyyy}", titulo.DataMoraJuros);
				else
					aDataMoraJuros = "".ZeroFill(8);
			}
			else
				aDataMoraJuros = "".ZeroFill(8);

			//Descontos
			string aDataDesconto;
			if (titulo.ValorDesconto > 0)
			{
				if (titulo.DataDesconto.HasValue)
					aDataDesconto = string.Format("{0:ddMMyyyy}", titulo.DataDesconto);
				else
					aDataDesconto = "".ZeroFill(8);
			}
			else
				aDataDesconto = "".ZeroFill(8);

			//Index boleto
			var aIndex = string.Format("{0:00000}", titulo.Parent.ListadeBoletos.IndexOf(titulo) + 1);

			//Data Protesto
			string aDataProtesto;
			if (titulo.DataProtesto.HasValue && titulo.DataProtesto > titulo.Vencimento)
				aDataProtesto = string.Format("{0:dd}", titulo.DataProtesto.Value.Date.Subtract(titulo.Vencimento.Date));
			else
				aDataProtesto = "00";

			var result = new StringBuilder();
			result.AppendFormat("{0:000}", Banco.Numero);						   //1 a 3 - Código do banco
			result.Append("0001");                                                 //4 a 7 - Lote de serviço
			result.Append("3");                                                    //8 - Tipo do registro: Registro detalhe
			result.Append(aIndex);												   //9 a 13 - Número seqüencial do registro no lote - Cada registro possui dois segmentos
			result.Append("P");                                                    //14 - Código do segmento do registro detalhe
			result.Append(" ");                                                    //15 - Uso exclusivo FEBRABAN/CNAB: Branco
			result.Append(aTipoOcorrencia);                                        //16 a 17 - Código de movimento
			result.Append("0");                                                    //18
			result.Append(titulo.Parent.Cedente.Agencia.ZeroFill(4));              //19 a 22 - Agência mantenedora da conta
			result.Append(" ");                                                    //23
			result.Append("0000000");                                              //24 a 30 - Complemento de Registro
			result.Append(titulo.Parent.Cedente.Conta.ZeroFill(5));				   //31 a 35 - Número da Conta Corrente
			result.Append(" ");                                                    //36
			result.Append(titulo.Parent.Cedente.ContaDigito);                      //37 - Dígito verificador da agência / conta
			result.Append(titulo.Carteira);                                        //38 a 40 - Carteira
			result.Append(titulo.NossoNumero.ZeroFill(8));                         //41 a 48 - Nosso número - identificação do título no banco
			result.Append(CalcularDigitoVerificador(titulo));                      //49 - Dígito verificador da agência / conta preencher somente em cobrança sem registro
			result.Append("".FillLeft(8));                                         //50 a 57 - Brancos
			result.Append("".ZeroFill(5));                                         //58 a 62 - Complemento
			result.Append(titulo.NumeroDocumento.FillLeft(10));                    //63 a 72 - Número que identifica o título na empresa [ Alterado conforme instruções da CSO Brasília ] {27-07-09}
			result.Append("".FillLeft(5));                                         //73 a 77 - Brancos
			result.AppendFormat("{0:ddMMyyyy}", titulo.Vencimento);                //78 a 85 - Data de vencimento do título
			result.Append(titulo.ValorDocumento.ToDecimalString(15));              //86 a 100 - Valor nominal do título
			result.Append("00000");                                                //101 a 105 - Agência cobradora. // Ficando com Zeros o Itaú definirá a agência cobradora pelo CEP do sacado
			result.Append(" ");                                                    //106 - Dígito da agência cobradora
			result.Append(titulo.EspecieDoc.FillLeft(2));                                                  // 107 a 108 - Espécie do documento
			result.Append(aTipoAceite);											   //109 - Identificação de título Aceito / Não aceito
			result.AppendFormat("{0:ddMMyyyy}", titulo.DataDocumento);             //110 a 117 - Data da emissão do documento
			result.Append("0");                                                    //118 - Zeros
			result.Append(aDataMoraJuros);                                         //119 a 126 - Data a partir da qual serão cobrados juros
			result.Append(titulo.ValorMoraJuros > 0 ?
				titulo.ValorMoraJuros.ToDecimalString(15) : "".ZeroFill(15));      //127 a 141 - Valor de juros de mora por dia
			result.Append("0");                                                    //142 - Zeros
			result.Append(aDataDesconto);                                          //143 a 150 - Data limite para desconto
			result.Append(titulo.ValorDesconto > 0 ?
				titulo.ValorDesconto.ToDecimalString(15) : "".ZeroFill(15));       //151 a 165 - Valor do desconto por dia
			result.Append(titulo.ValorIOF.ToDecimalString(15));                    //166 a 180 - Valor do IOF a ser recolhido
			result.Append(titulo.ValorAbatimento.ToDecimalString(15));             //181 a 195 - Valor do abatimento
			result.Append(titulo.SeuNumero.FillLeft(25));                          //196 a 220 - Identificação do título na empresa
			result.Append(titulo.DataProtesto.HasValue &&
				titulo.DataProtesto > titulo.Vencimento ? "1" : "3");			   //221 - Código de protesto: Protestar em XX dias corridos
			result.Append(aDataProtesto);										   //222 a 223 - Prazo para protesto (em dias corridos)
			result.Append("0");                                                    //224 - Código de Baixa
			result.Append("00");                                                   //225 A 226 - Dias para baixa
			result.Append("0000000000000 ");

			//SEGMENTO Q
			string aTipoInscricao;
			switch (titulo.Sacado.Pessoa)
			{
				case Pessoa.Fisica: aTipoInscricao = "1"; break;
				case Pessoa.Juridica: aTipoInscricao = "2"; break;
				default: aTipoInscricao = "9"; break;
			}

			//Endereco sacado
			var sEndereco = string.Format("{0} {1} {2}", titulo.Sacado.Logradouro,
				titulo.Sacado.Numero, titulo.Sacado.Complemento).FillLeft(40);

			result.Append(Environment.NewLine);
			result.AppendFormat("{0:000}", Banco.Numero);				    //1 a 3 - Código do banco
			result.Append("0001");                                          //Número do lote
            result.Append("3");                                             //Tipo do registro: Registro detalhe
            result.Append(aIndex);											//Número seqüencial do registro no lote - Cada registro possui dois segmentos
            result.Append("Q");                                             //Código do segmento do registro detalhe
            result.Append(" ");                                             //Uso exclusivo FEBRABAN/CNAB: Branco
            result.Append("01");                                            //16 a 17
            
		    //Dados do sacado}
            result.Append(aTipoInscricao);                                  //18 a 18 Tipo inscricao
            result.Append(titulo.Sacado.CNPJCPF.ZeroFill(15));              //19 a 33
            result.Append(titulo.Sacado.NomeSacado.FillLeft(30));           //34 a 63
            result.Append("".FillLeft(10));                                 //64 a 73
            result.Append(sEndereco);  // 74 a 113
            result.Append(titulo.Sacado.Bairro.FillLeft(15));               //114 a 128
            result.Append(titulo.Sacado.CEP.ZeroFill(8));                   //129 a 136
            result.Append(titulo.Sacado.Cidade.FillLeft(15));               //137 a 151
            result.Append(titulo.Sacado.UF.FillLeft(2));                    //152 a 153
            
			//Dados do sacador/avalista}
            result.Append("0");                                             //Tipo de inscrição: Não informado
            result.Append("".ZeroFill(15));                                 //Número de inscrição
            result.Append("".FillLeft(30));                                 //Nome do sacador/avalista
            result.Append("".FillLeft(10));                                 //Uso exclusivo FEBRABAN/CNAB
            result.Append("".ZeroFill(3));                                  //Uso exclusivo FEBRABAN/CNAB
            result.Append("".FillLeft(28));                                 //Uso exclusivo FEBRABAN/CNAB

			return result.ToString().ToUpper();
		}

        /// <summary>
        /// Gerars the registro trailler400.
        /// </summary>
        /// <param name="aRemessa">A remessa.</param>
        public override void GerarRegistroTrailler400(List<string> aRemessa)
        {
			var wLinha = new StringBuilder();
			wLinha.Append('9');
			wLinha.Append("".FillLeft(393));                         // TIPO DE REGISTRO
            wLinha.AppendFormat("{0:000000}", aRemessa.Count + 1);   // NÚMERO SEQÜENCIAL DO REGISTRO NO ARQUIVO
			aRemessa.Add(wLinha.ToString().ToUpper());
        }

        /// <summary>
        /// Gerars the registro trailler240.
        /// </summary>
        /// <param name="aRemessa">A remessa.</param>
        /// <returns>System.String.</returns>
        public override string GerarRegistroTrailler240(List<string> aRemessa)
        {
			var result = new StringBuilder();
            //REGISTRO TRAILER DO LOTE
			result.AppendFormat("{0:000}", Banco.Numero);        //Código do banco
            result.Append("0001");                               //Número do lote
            result.Append("5");                                  //Tipo do registro: Registro trailer do lote
            result.Append("".FillLeft(9));                       //Uso exclusivo FEBRABAN/CNAB
            result.AppendFormat("{0:000000}", aRemessa.Count);   //Quantidade de Registro da Remessa
            result.Append("".ZeroFill(6));                       //Quantidade de títulos em cobrança simples
            result.Append("".ZeroFill(17));                      //Valor dos títulos em cobrança simples
            result.Append("".ZeroFill(6));                       //Quantidade títulos em cobrança vinculada
            result.Append("".ZeroFill(17));                      //Valor dos títulos em cobrança vinculada
            result.Append("".ZeroFill(46));                      //Complemento
            result.Append("".FillLeft(8));                       //Referencia do aviso bancario
            result.Append("".FillLeft(117));

          //GERAR REGISTRO TRAILER DO ARQUIVO
    		result.Append(Environment.NewLine);
            result.AppendFormat("{0:000}", Banco.Numero);        //Código do banco
            result.Append("9999");                               //Lote de serviço
			result.Append("9");                                  //Tipo do registro: Registro trailer do arquivo
            result.Append("".FillLeft(9));                       //Uso exclusivo FEBRABAN/CNAB}
            result.Append("000001");                             //Quantidade de lotes do arquivo}
            result.AppendFormat("{0:000000}", aRemessa.Count);   //Quantidade de registros do arquivo, inclusive este registro que está sendo criado agora}
            result.Append("".ZeroFill(6));                       //Complemento
            result.Append("".FillLeft(205));

			return result.ToString().ToUpper();
        }

        /// <summary>
        /// Lers the retorno400.
        /// </summary>
        /// <param name="aRetorno">A retorno.</param>
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public override void LerRetorno400(List<string> aRetorno)
        {
			Guard.Against<ACBrException>(aRetorno[0].ExtrairInt32DaPosicao(77, 79) != Numero,
				"{0} não é um arquivo de retorno do {1}", Banco.Parent.NomeArqRetorno, Nome);

			var rCedente = aRetorno[0].ExtrairDaPosicao(47, 76);
			var rAgencia = aRetorno[0].ExtrairDaPosicao(27, 30).Trim();
			var rDigitoAgencia = aRetorno[0].ExtrairDaPosicao(31, 31);
			var rConta = aRetorno[0].ExtrairDaPosicao(32, 39).Trim();
			var rDigitoConta = aRetorno[0].ExtrairDaPosicao(40, 40).Trim();			

			Guard.Against<ACBrException>(
				!Banco.Parent.LeCedenteRetorno && (rAgencia != Banco.Parent.Cedente.Agencia.OnlyNumbers() ||
				rConta != Banco.Parent.Cedente.Conta.OnlyNumbers()),
				@"Agencia\Conta do arquivo inválido");

			Banco.Parent.NumeroArquivo = aRetorno[0].ExtrairInt32DaPosicao(109, 113);
			Banco.Parent.DataArquivo = aRetorno[0].ExtrairDataDaPosicao(95, 100, "ddMMyy");
            Banco.Parent.DataCreditoLanc = aRetorno[0].ExtrairDataDaPosicao(114, 119, "ddMMyy");

			Banco.Parent.Cedente.TipoInscricao = (PessoaCedente)aRetorno[1].ExtrairInt32DaPosicao(2, 3);

			switch (Banco.Parent.Cedente.TipoInscricao)
			{
				case PessoaCedente.Fisica:
					Banco.Parent.Cedente.CNPJCPF = aRetorno[1].ExtrairDaPosicao(7, 17);
					break;

				case PessoaCedente.Juridica:
					Banco.Parent.Cedente.CNPJCPF = aRetorno[1].ExtrairDaPosicao(4, 17);
					break;
			}

			Banco.Parent.Cedente.Nome = rCedente;
			Banco.Parent.Cedente.Agencia = rAgencia;
			Banco.Parent.Cedente.AgenciaDigito = rDigitoAgencia;
			Banco.Parent.Cedente.Conta = rConta;
			Banco.Parent.Cedente.ContaDigito = rDigitoConta;

			Banco.Parent.ListadeBoletos.Clear();
						
			Titulo titulo;
			for (var contLinha = 1; contLinha < aRetorno.Count - 1; contLinha++)
			{
				var linha = aRetorno[contLinha];

				if (linha.ExtrairDaPosicao(1, 1) != "7" && linha.ExtrairDaPosicao(1, 1) != "1")
					continue;

				titulo = Banco.Parent.CriarTituloNaLista();

				titulo.SeuNumero = linha.ExtrairDaPosicao(38, 62);
				titulo.NumeroDocumento = linha.ExtrairDaPosicao(117, 126);
				titulo.OcorrenciaOriginal.Tipo = CodOcorrenciaToTipo(linha.ExtrairInt32DaPosicao(109, 110));

				if (titulo.OcorrenciaOriginal.Tipo.IsIn(TipoOcorrencia.RetornoInstrucaoProtestoRejeitadaSustadaOuPendente,
					TipoOcorrencia.RetornoAlegacaoDoSacado, TipoOcorrencia.RetornoInstrucaoCancelada))
				{
					var motivoLinha = 302;
					var motivo = linha.ExtrairDaPosicao(motivoLinha, motivoLinha + 3).Trim();
					titulo.MotivoRejeicaoComando.Add(string.IsNullOrEmpty(motivo) ? "0000" : motivo);
					
					if(titulo.MotivoRejeicaoComando[0] != "0000")
					{
						var codOcorrencia = titulo.MotivoRejeicaoComando[0].ToInt32();
						var mdescricao = CodMotivoRejeicaoToDescricao(titulo.OcorrenciaOriginal.Tipo, codOcorrencia);
						titulo.DescricaoMotivoRejeicaoComando.Add(mdescricao);
					}
				}
				else
				{					
					var motivoLinha = 378;
					int codMotivo;
					for (var i = 0; i < 3; i++)
					{						
						titulo.MotivoRejeicaoComando.Add(linha.ExtrairDaPosicao(motivoLinha, motivoLinha + 1));
						if (titulo.MotivoRejeicaoComando[i] != "00")
						{
							codMotivo = titulo.MotivoRejeicaoComando[i].ToInt32();
							titulo.DescricaoMotivoRejeicaoComando.Add(CodMotivoRejeicaoToDescricao(titulo.OcorrenciaOriginal.Tipo, codMotivo));
						}
						motivoLinha += 2;
					}
				}

                titulo.DataOcorrencia = linha.ExtrairDataDaPosicao(111, 116, "ddMMyy");

				//Espécie do documento
				switch (linha.ExtrairDaPosicao(174, 175).Trim().ToInt32())
				{
					case 1: titulo.EspecieDoc = "DM"; break;
					case 2: titulo.EspecieDoc = "NP"; break;
					case 3: titulo.EspecieDoc = "NS"; break;
					case 4: titulo.EspecieDoc = "ME"; break;
					case 5: titulo.EspecieDoc = "RC"; break;
					case 6: titulo.EspecieDoc = "CT"; break;
					case 7: titulo.EspecieDoc = "CS"; break;
					case 8: titulo.EspecieDoc = "DS"; break;
					case 9: titulo.EspecieDoc = "LC"; break;
					case 13: titulo.EspecieDoc = "ND"; break;
					case 15: titulo.EspecieDoc = "DD"; break;
					case 16: titulo.EspecieDoc = "EC"; break;
					case 17: titulo.EspecieDoc = "PS"; break;
					default: titulo.EspecieDoc = "DV"; break;
				}

                titulo.Vencimento = linha.ExtrairDataDaPosicao(147, 152, "ddMMyy");

				titulo.ValorDocumento = linha.ExtrairDecimalDaPosicao(153, 165);
				titulo.ValorIOF = linha.ExtrairDecimalDaPosicao(215, 227);
				titulo.ValorAbatimento = linha.ExtrairDecimalDaPosicao(228, 240);
				titulo.ValorDesconto = linha.ExtrairDecimalDaPosicao(241, 253);
				titulo.ValorRecebido = linha.ExtrairDecimalDaPosicao(254, 266);
				titulo.ValorMoraJuros = linha.ExtrairDecimalDaPosicao(267, 279);
				titulo.ValorOutrosCreditos = linha.ExtrairDecimalDaPosicao(280, 292);
				titulo.NossoNumero = linha.ExtrairDaPosicao(64, 80);
				titulo.Carteira = linha.ExtrairDaPosicao(92, 94);
				titulo.ValorDespesaCobranca = linha.ExtrairDecimalDaPosicao(176, 188);

				titulo.NossoNumero = linha.ExtrairDaPosicao(63, 70);
				titulo.Carteira = linha.ExtrairDaPosicao(83, 85);
                titulo.DataCredito = linha.ExtrairDataOpcionalDaPosicao(296, 301, "ddMMyy");
                titulo.DataBaixa = linha.ExtrairDataOpcionalDaPosicao(111, 116, "ddMMyy");
			}
        }

        /// <summary>
        /// Lers the retorno240.
        /// </summary>
        /// <param name="aRetorno">A retorno.</param>
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public override void LerRetorno240(List<string> aRetorno)
        {
			Guard.Against<ACBrException>(aRetorno[0].ExtrairInt32DaPosicao(1, 3) != Numero,
				"{0} não é um arquivo de retorno do {1}'", Banco.Parent.NomeArqRetorno, Nome);

			Banco.Parent.DataArquivo = aRetorno[0].ExtrairDataDaPosicao(146, 152);
			Banco.Parent.NumeroArquivo = aRetorno[0].ExtrairInt32DaPosicao(158, 163);

			var rCedente = aRetorno[0].ExtrairDaPosicao(73, 102).Trim();
			var rCNPJCPF = aRetorno[0].ExtrairDaPosicao(19, 32).OnlyNumbers();

			Guard.Against<ACBrException>(
				!Banco.Parent.LeCedenteRetorno && rCNPJCPF != Banco.Parent.Cedente.CNPJCPF.OnlyNumbers(),
                @"CNPJ\CPF do arquivo inválido");

			Banco.Parent.Cedente.Nome = rCedente;
			Banco.Parent.Cedente.CNPJCPF = rCNPJCPF;

			switch (aRetorno[0].ExtrairInt32DaPosicao(18, 18))
			{
				case 1:
					Banco.Parent.Cedente.TipoInscricao = PessoaCedente.Fisica;
					break;

				default:
					Banco.Parent.Cedente.TipoInscricao = PessoaCedente.Juridica;
					break;
			}

			Banco.Parent.ListadeBoletos.Clear();

			Titulo titulo = null;

			for (var contLinha = 1; contLinha < aRetorno.Count - 1; contLinha++)
			{
				var linha = aRetorno[contLinha];

				// verifica se o registro (linha) é um registro detalhe (segmento J)
				if (linha.ExtrairInt32DaPosicao(8, 8) != 3)
					continue;

				// se for segmento T cria um novo titulo                
				if (linha.ExtrairDaPosicao(14, 14) == "T")
				{
					titulo = Banco.Parent.CriarTituloNaLista();

					titulo.SeuNumero = linha.ExtrairDaPosicao(59, 68);
					titulo.NumeroDocumento = linha.ExtrairDaPosicao(59, 68);
					titulo.Carteira = linha.ExtrairDaPosicao(38, 40);

					var dt = linha.ExtrairDataOpcionalDaPosicao(74, 81);
					if (dt.HasValue)
						titulo.Vencimento = dt.Value;

					titulo.ValorDocumento = linha.ExtrairDecimalDaPosicao(82, 96);
					titulo.NossoNumero = linha.ExtrairDaPosicao(41, 48);
					titulo.ValorDespesaCobranca = linha.ExtrairDecimalDaPosicao(199, 213);
					titulo.OcorrenciaOriginal.Tipo = CodOcorrenciaToTipo(linha.ExtrairInt32DaPosicao(16, 17));

					var idxMotivo = 214;
					while (idxMotivo < 221)
					{
						if (!string.IsNullOrEmpty(linha.ExtrairDaPosicao(idxMotivo, idxMotivo + 1)) || 
							!linha.ExtrairDaPosicao(idxMotivo, idxMotivo + 1).Equals("00"))
						{
							titulo.MotivoRejeicaoComando.Add(linha.ExtrairDaPosicao(idxMotivo, idxMotivo + 1));
							titulo.DescricaoMotivoRejeicaoComando.Add(
								CodMotivoRejeicaoToDescricao(titulo.OcorrenciaOriginal.Tipo,
								linha.ExtrairInt32DaPosicao(idxMotivo, idxMotivo + 1)));
						}
						idxMotivo += 2;
					}
				}
				else
				{
					// segmento U
					titulo.ValorIOF = linha.ExtrairDecimalDaPosicao(63, 77);
					titulo.ValorAbatimento = linha.ExtrairDecimalDaPosicao(48, 62);
					titulo.ValorDesconto = linha.ExtrairDecimalDaPosicao(33, 47);
					titulo.ValorMoraJuros = linha.ExtrairDecimalDaPosicao(18, 32);
					titulo.ValorOutrosCreditos = linha.ExtrairDecimalDaPosicao(123, 137);
					titulo.ValorRecebido = linha.ExtrairDecimalDaPosicao(78, 92);
					titulo.ValorOutrasDespesas = linha.ExtrairDecimalDaPosicao(108, 113);

					var tempData = linha.ExtrairDataOpcionalDaPosicao(138, 145);
					if (tempData.HasValue)
						titulo.DataOcorrencia = tempData.Value;

					tempData = linha.ExtrairDataOpcionalDaPosicao(146, 153);
					if (tempData.HasValue)
						titulo.DataCredito = tempData.Value;
				}
			}
        }

        #endregion Methods
    }
}