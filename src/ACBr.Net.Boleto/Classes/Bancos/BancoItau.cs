// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 04-21-2014
//
// Last Modified By : RFTD
// Last Modified On : 04-24-2014
// ***********************************************************************
// <copyright file="BancoDoBrasil.cs" company="">
//     Copyright (c) . All rights reserved.
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
	[Guid("2E675758-954A-45EE-981F-4C2662AF9CE1")]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes
    /// <summary>
    /// Classe BancoDoBrasil. Esta classe não pode ser herdada.
    /// </summary>
    public sealed class BancoItau : BancoBase
    {
        #region Fields
        #endregion Fields

        #region Constructor

        /// <summary>
        /// Inicializa uma nova instancia da classe <see cref="BancoDoBrasil" />.
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
        /// <param name="Tipo">The tipo.</param>
        /// <returns>System.String.</returns>
        public override string TipoOcorrenciaToDescricao(TipoOcorrencia Tipo)
        {
            var CodOcorrencia = TipoOCorrenciaToCod(Tipo).ToInt32();   
            switch(CodOcorrencia)
            {
                case 2: return "02-Entrada Confirmada";
                case 3: return "03-Entrada Rejeitada";
                case 4: return "04-Alteração de Dados - Nova Entrada";
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
                default: return string.Format("{0:00}-Outras Ocorrencias", CodOcorrencia);
            }
        }

        /// <summary>
        /// Cods the ocorrencia to tipo.
        /// </summary>
        /// <param name="CodOcorrencia">The cod ocorrencia.</param>
        /// <returns>TipoOcorrencia.</returns>
        public override TipoOcorrencia CodOcorrenciaToTipo(int CodOcorrencia)
        {
            switch(CodOcorrencia)
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
        /// <param name="Tipo">The tipo.</param>
        /// <returns>System.String.</returns>
        public override string TipoOCorrenciaToCod(TipoOcorrencia Tipo)
        {
            switch(Tipo)
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
        /// <param name="Tipo">The tipo.</param>
        /// <param name="CodMotivo">The cod motivo.</param>
        /// <returns>System.String.</returns>
        public override string CodMotivoRejeicaoToDescricao(TipoOcorrencia Tipo, int CodMotivo)
        {
            switch (Tipo)
            {
                case TipoOcorrencia.RetornoRegistroRecusado:
                case TipoOcorrencia.RetornoEntradaRejeitadaCarne:
                    switch (CodMotivo)
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
                        default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoAlteracaoDadosRejeitados:
                    switch (CodMotivo)
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
                        default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoInstrucaoRejeitada:
                    switch (CodMotivo)
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
                        default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoBaixaRejeitada:
                    switch (CodMotivo)
                    {
                        case 1: return "CARTEIRA/Nº NÚMERO NÃO NUMÉRICO";
                        case 4: return "NOSSO NÚMERO EM DUPLICIDADE NUM MESMO MOVIMENTO";
                        case 5: return "SOLICITAÇÃO DE BAIXA PARA TÍTULO JÁ BAIXADO OU LIQUIDADO";
                        case 6: return "SOLICITAÇÃO DE BAIXA PARA TÍTULO NÃO REGISTRADO NO SISTEMA";
                        case 7: return "COBRANÇA PRAZO CURTO - SOLICITAÇÃO DE BAIXA P/ TÍTULO NÃO REGISTRADO NO SISTEMA";
                        case 8: return "SOLICITAÇÃO DE BAIXA PARA TÍTULO EM FLOATING";  
                        default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoCobrancaContratual:
                    switch (CodMotivo)
                    {
                        case 16: return "ABATIMENTO/ALTERAÇÃO DO VALOR DO TÍTULO OU SOLICITAÇÃO DE BAIXA BLOQUEADOS";
                        case 40: return "NÃO APROVADA DEVIDO AO IMPACTO NA ELEGIBILIDADE DE GARANTIAS";
                        case 41: return "AUTOMATICAMENTE REJEITADA";
                        case 42: return "CONFIRMA RECEBIMENTO DE INSTRUÇÃO – PENDENTE DE ANÁLISE";  
                        default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoAlegacaoDoSacado:
                    switch (CodMotivo)
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
                        default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoInstrucaoProtestoRejeitadaSustadaOuPendente:
                    switch (CodMotivo)
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
                        default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoInstrucaoCancelada:
                    switch (CodMotivo)
                    {
                        case 1156: return "NÃO PROTESTAR";
                        case 2261: return "DISPENSAR JUROS/COMISSÃO DE PERMANÊNCIA";
                        default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoChequeDevolvido:
                    switch (CodMotivo)
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
                        default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoRegistroConfirmado:
                    switch (CodMotivo)
                    {
                        case 1: return "CEP SEM ATENDIMENTO DE PROTESTO NO MOMENTO";
                        default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
                    }

                default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
            }
        }

        /// <summary>
        /// Calculars the digito verificador.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string CalcularDigitoVerificador(Titulo Titulo)
        {
            string Docto = string.Empty;

            if (Titulo.Carteira.IsIn("112", "212", "113", "114", "166", "115", "104", "147", "188", "108",
                "121", "180", "280", "126", "131", "145", "150", "168", "109", "110", "111", "121", "221", "175"))
            {
                Docto = string.Format("{0}{1}", Titulo.Carteira, Titulo.NossoNumero.FillRight(TamanhoMaximoNossoNum, '0'));
            }
            else
            {
                Docto = String.Format("{0}{1}{2}", Titulo.Parent.Cedente.Agencia,
                    Titulo.Parent.Cedente.Conta, Docto);
            }

            Modulo.MultiplicadorInicial = 1;
            Modulo.MultiplicadorFinal = 2;
            Modulo.MultiplicadorAtual = 2;
            Modulo.FormulaDigito = CalcDigFormula.Modulo10;
            Modulo.Documento = Docto;
            Modulo.Calcular();
            return Modulo.DigitoFinal.ToString();
        }

        /// <summary>
        /// Montars the campo codigo cedente.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string MontarCampoCodigoCedente(Titulo Titulo)
        {
            return string.Format(@"{0}/{1}-{2}", Titulo.Parent.Cedente.Agencia,
                Titulo.Parent.Cedente.Conta, Titulo.Parent.Cedente.ContaDigito);
        }

        /// <summary>
        /// Montars the campo nosso numero.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string MontarCampoNossoNumero(Titulo Titulo)
        {
            var NossoNr = Titulo.Carteira + Titulo.NossoNumero.FillRight(TamanhoMaximoNossoNum, '0');
            NossoNr.Insert(3, "/");
            NossoNr.Insert(12, "-");
            return NossoNr + CalcularDigitoVerificador(Titulo);
        }

        /// <summary>
        /// Monta o codigo de barras.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string MontarCodigoBarras(Titulo Titulo)
        {
            var FatorVencimento = Titulo.Vencimento.CalcularFatorVencimento();
            var ANossoNumero = String.Format("{0}{1}{2}", Titulo.Carteira, Titulo.NossoNumero.FillRight(8, '0'),
                CalcularDigitoVerificador(Titulo));
            var aAgenciaCC = String.Format("{0}{1}{2}", Titulo.Parent.Cedente.Agencia,
                Titulo.Parent.Cedente.Conta, Titulo.Parent.Cedente.ContaDigito); 

            var CodigoBarras = string.Format("{0:000}9{1}{2}{3}{4}000", Numero, FatorVencimento,
                       Titulo.ValorDocumento.ToRemessaString(10), ANossoNumero, aAgenciaCC);

            var DigitoCodBarras = CalcularDigitoCodigoBarras(CodigoBarras);
            return CodigoBarras.Insert(4, DigitoCodBarras);
        }

        /// <summary>
        /// Gerars the registro header400.
        /// </summary>
        /// <param name="NumeroRemessa">The numero remessa.</param>
        /// <param name="ARemessa">A remessa.</param>
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public override void GerarRegistroHeader400(int NumeroRemessa, List<string> ARemessa)
        {
            throw new NotImplementedException("Esta função não esta implementada para este banco");
        }

        /// <summary>
        /// Gerars the registro header240.
        /// </summary>
        /// <param name="NumeroRemessa">The numero remessa.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public override string GerarRegistroHeader240(int NumeroRemessa)
        {
            throw new NotImplementedException("Esta função não esta implementada para este banco");
        }

        /// <summary>
        /// Gerars the registro transacao400.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <param name="ARemessa">A remessa.</param>
        public override void GerarRegistroTransacao400(Titulo Titulo, List<string> ARemessa)
        {
            
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
        /// Gerars the registro trailler400.
        /// </summary>
        /// <param name="ARemessa">A remessa.</param>
        public override void GerarRegistroTrailler400(List<string> ARemessa)
        {
            
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
        /// Lers the retorno400.
        /// </summary>
        /// <param name="ARetorno">A retorno.</param>
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public override void LerRetorno400(List<string> ARetorno)
        {
            throw new NotImplementedException("Esta função não esta implementada para este banco");
        }

        /// <summary>
        /// Lers the retorno240.
        /// </summary>
        /// <param name="ARetorno">A retorno.</param>
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public override void LerRetorno240(List<string> ARetorno)
        {
            throw new NotImplementedException("Esta função não esta implementada para este banco");
        }

        /// <summary>
        /// Calculars the nome arquivo remessa.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string CalcularNomeArquivoRemessa()
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
        protected override string CalcularDigitoCodigoBarras(string CodigoBarras)
        {
            Modulo.CalculoPadrao();
            Modulo.Documento = CodigoBarras;
            Modulo.Calcular();

            if (Modulo.DigitoFinal == 0 || Modulo.DigitoFinal > 9)
                return "1";
            else
                return Modulo.DigitoFinal.ToString();
        }

        #endregion Methods
    }
}