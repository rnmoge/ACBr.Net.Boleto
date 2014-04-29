// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 03-22-2014
//
// Last Modified By : RFTD
// Last Modified On : 03-22-2014
// ***********************************************************************
// <copyright file="TipoOcorrencia.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The Boleto namespace.
/// </summary>
namespace ACBr.Net.Boleto
{
    /// <summary>
    /// Enum TipoOcorrencia
    /// </summary>
    public enum TipoOcorrencia
    {
        //Ocorrências para arquivo remessa
        /// <summary>
        /// The remessa registrar
        /// </summary>
        RemessaRegistrar,
        /// <summary>
        /// The remessa baixar
        /// </summary>
        RemessaBaixar,
        /// <summary>
        /// The remessa debitar em conta
        /// </summary>
        RemessaDebitarEmConta,
        /// <summary>
        /// The remessa conceder abatimento
        /// </summary>
        RemessaConcederAbatimento,
        /// <summary>
        /// The remessa cancelar abatimento
        /// </summary>
        RemessaCancelarAbatimento,
        /// <summary>
        /// The remessa conceder desconto
        /// </summary>
        RemessaConcederDesconto,
        /// <summary>
        /// The remessa cancelar desconto
        /// </summary>
        RemessaCancelarDesconto,
        /// <summary>
        /// The remessa alterar vencimento
        /// </summary>
        RemessaAlterarVencimento,
        /// <summary>
        /// The remessa protestar
        /// </summary>
        RemessaProtestar,
        /// <summary>
        /// The remessa sustar protesto
        /// </summary>
        RemessaSustarProtesto,
        /// <summary>
        /// The remessa cancelar instrucao protesto baixa
        /// </summary>
        RemessaCancelarInstrucaoProtestoBaixa,
        /// <summary>
        /// The remessa cancelar instrucao protesto
        /// </summary>
        RemessaCancelarInstrucaoProtesto,
        /// <summary>
        /// The remessa dispensar juros
        /// </summary>
        RemessaDispensarJuros,
        /// <summary>
        /// The remessa alterar nome endereco sacado
        /// </summary>
        RemessaAlterarNomeEnderecoSacado,
        /// <summary>
        /// The remessa alterar numero controle
        /// </summary>
        RemessaAlterarNumeroControle,
        /// <summary>
        /// The remessa outras ocorrencias
        /// </summary>
        RemessaOutrasOcorrencias,
        /// <summary>
        /// The remessa alterar controle participante
        /// </summary>
        RemessaAlterarControleParticipante,
        /// <summary>
        /// The remessa alterar seu numero
        /// </summary>
        RemessaAlterarSeuNumero,
        /// <summary>
        /// The remessa transf cessao credito identifier prod10
        /// </summary>
        RemessaTransfCessaoCreditoIDProd10,
        /// <summary>
        /// The remessa transferencia carteira
        /// </summary>
        RemessaTransferenciaCarteira,
        /// <summary>
        /// The remessa dev transferencia carteira
        /// </summary>
        RemessaDevTransferenciaCarteira,
        /// <summary>
        /// The remessa desagendar debito automatico
        /// </summary>
        RemessaDesagendarDebitoAutomatico,
        /// <summary>
        /// The remessa acertar rateio credito
        /// </summary>
        RemessaAcertarRateioCredito,
        /// <summary>
        /// The remessa cancelar rateio credito
        /// </summary>
        RemessaCancelarRateioCredito,
        /// <summary>
        /// The remessa alterar uso empresa
        /// </summary>
        RemessaAlterarUsoEmpresa,
        /// <summary>
        /// The remessa nao protestar
        /// </summary>
        RemessaNaoProtestar,
        /// <summary>
        /// The remessa protesto fins falimentares
        /// </summary>
        RemessaProtestoFinsFalimentares,
        /// <summary>
        /// The remessa baixapor pagto direto cedente
        /// </summary>
        RemessaBaixaporPagtoDiretoCedente,
        /// <summary>
        /// The remessa cancelar instrucao
        /// </summary>
        RemessaCancelarInstrucao,
        /// <summary>
        /// The remessa alterar venc sustar protesto
        /// </summary>
        RemessaAlterarVencSustarProtesto,
        /// <summary>
        /// The remessa cedente discorda sacado
        /// </summary>
        RemessaCedenteDiscordaSacado,
        /// <summary>
        /// The remessa cedente solicita dispensa juros
        /// </summary>
        RemessaCedenteSolicitaDispensaJuros,
        /// <summary>
        /// The remessa outras alteracoes
        /// </summary>
        RemessaOutrasAlteracoes,
        /// <summary>
        /// The remessa alterar modalidade
        /// </summary>
        RemessaAlterarModalidade,
        /// <summary>
        /// The remessa alterar exclusivo cliente
        /// </summary>
        RemessaAlterarExclusivoCliente,
        /// <summary>
        /// The remessa nao cobrar juros mora
        /// </summary>
        RemessaNaoCobrarJurosMora,
        /// <summary>
        /// The remessa cobrar juros mora
        /// </summary>
        RemessaCobrarJurosMora,
        /// <summary>
        /// The remessa alterar valor titulo
        /// </summary>
        RemessaAlterarValorTitulo,

        //Ocorrências para arquivo retorno}
        /// <summary>
        /// The retorno registro confirmado
        /// </summary>
        RetornoRegistroConfirmado,
        /// <summary>
        /// The retorno transferencia carteira
        /// </summary>
        RetornoTransferenciaCarteira,
        /// <summary>
        /// The retorno transferencia carteira entrada
        /// </summary>
        RetornoTransferenciaCarteiraEntrada,
        /// <summary>
        /// The retorno transferencia carteira baixa
        /// </summary>
        RetornoTransferenciaCarteiraBaixa,
        /// <summary>
        /// The retorno transferencia cedente
        /// </summary>
        RetornoTransferenciaCedente,
        /// <summary>
        /// The retorno registro recusado
        /// </summary>
        RetornoRegistroRecusado,
        /// <summary>
        /// The retorno comando recusado
        /// </summary>
        RetornoComandoRecusado,
        /// <summary>
        /// The retorno liquidado
        /// </summary>
        RetornoLiquidado,
        /// <summary>
        /// The retorno liquidado em cartorio
        /// </summary>
        RetornoLiquidadoEmCartorio,
        /// <summary>
        /// The retorno liquidado parcialmente
        /// </summary>
        RetornoLiquidadoParcialmente,
        /// <summary>
        /// The retorno liquidado saldo restante
        /// </summary>
        RetornoLiquidadoSaldoRestante,
        /// <summary>
        /// The retorno liquidado sem registro
        /// </summary>
        RetornoLiquidadoSemRegistro,
        /// <summary>
        /// The retorno liquidado por conta
        /// </summary>
        RetornoLiquidadoPorConta,
        /// <summary>
        /// The retorno liquidado apos baixa ou nao registro
        /// </summary>
        RetornoLiquidadoAposBaixaOuNaoRegistro,
        /// <summary>
        /// The retorno baixa rejeitada
        /// </summary>
        RetornoBaixaRejeitada,
        /// <summary>
        /// The retorno baixa solicitada
        /// </summary>
        RetornoBaixaSolicitada,
        /// <summary>
        /// The retorno baixado
        /// </summary>
        RetornoBaixado,
        /// <summary>
        /// The retorno baixa automatica
        /// </summary>
        RetornoBaixaAutomatica,
        /// <summary>
        /// The retorno baixado via arquivo
        /// </summary>
        RetornoBaixadoViaArquivo,
        /// <summary>
        /// The retorno baixado inst agencia
        /// </summary>
        RetornoBaixadoInstAgencia,
        /// <summary>
        /// The retorno baixado por devolucao
        /// </summary>
        RetornoBaixadoPorDevolucao,
        /// <summary>
        /// The retorno baixado franco pagamento
        /// </summary>
        RetornoBaixadoFrancoPagamento,
        /// <summary>
        /// The retorno baixa por protesto
        /// </summary>
        RetornoBaixaPorProtesto,
        /// <summary>
        /// The retorno baixa simples
        /// </summary>
        RetornoBaixaSimples,
        /// <summary>
        /// The retorno baixa por ter sido liquidado
        /// </summary>
        RetornoBaixaPorTerSidoLiquidado,
        /// <summary>
        /// The retorno baixa ou liquidacao estornada
        /// </summary>
        RetornoBaixaOuLiquidacaoEstornada,
        /// <summary>
        /// The retorno baixa transferencia para desconto
        /// </summary>
        RetornoBaixaTransferenciaParaDesconto,
        /// <summary>
        /// The retorno baixa credito cc atraves sispag
        /// </summary>
        RetornoBaixaCreditoCCAtravesSispag,
        /// <summary>
        /// The retorno baixa credito cc atraves sispag sem titulo corresp
        /// </summary>
        RetornoBaixaCreditoCCAtravesSispagSemTituloCorresp,
        /// <summary>
        /// The retorno titulo em ser
        /// </summary>
        RetornoTituloEmSer,
        /// <summary>
        /// The retorno titulo nao existe
        /// </summary>
        RetornoTituloNaoExiste,
        /// <summary>
        /// The retorno titulo pago em cheque
        /// </summary>
        RetornoTituloPagoEmCheque,
        /// <summary>
        /// The retorno titulo pagamento cancelado
        /// </summary>
        RetornoTituloPagamentoCancelado,
        /// <summary>
        /// The retorno titulo ja baixado
        /// </summary>
        RetornoTituloJaBaixado,
        /// <summary>
        /// The retorno titulo sustado judicialmente
        /// </summary>
        RetornoTituloSustadoJudicialmente,
        /// <summary>
        /// The retorno recebimento instrucao baixar
        /// </summary>
        RetornoRecebimentoInstrucaoBaixar,
        /// <summary>
        /// The retorno recebimento instrucao conceder abatimento
        /// </summary>
        RetornoRecebimentoInstrucaoConcederAbatimento,
        /// <summary>
        /// The retorno recebimento instrucao cancelar abatimento
        /// </summary>
        RetornoRecebimentoInstrucaoCancelarAbatimento,
        /// <summary>
        /// The retorno recebimento instrucao conceder desconto
        /// </summary>
        RetornoRecebimentoInstrucaoConcederDesconto,
        /// <summary>
        /// The retorno recebimento instrucao cancelar desconto
        /// </summary>
        RetornoRecebimentoInstrucaoCancelarDesconto,
        /// <summary>
        /// The retorno recebimento instrucao alterar dados
        /// </summary>
        RetornoRecebimentoInstrucaoAlterarDados,
        /// <summary>
        /// The retorno recebimento instrucao alterar vencimento
        /// </summary>
        RetornoRecebimentoInstrucaoAlterarVencimento,
        /// <summary>
        /// The retorno recebimento instrucao protestar
        /// </summary>
        RetornoRecebimentoInstrucaoProtestar,
        /// <summary>
        /// The retorno recebimento instrucao sustar protesto
        /// </summary>
        RetornoRecebimentoInstrucaoSustarProtesto,
        /// <summary>
        /// The retorno recebimento instrucao nao protestar
        /// </summary>
        RetornoRecebimentoInstrucaoNaoProtestar,
        /// <summary>
        /// The retorno recebimento instrucao alterar nome sacado
        /// </summary>
        RetornoRecebimentoInstrucaoAlterarNomeSacado,
        /// <summary>
        /// The retorno recebimento instrucao alterar endereco sacado
        /// </summary>
        RetornoRecebimentoInstrucaoAlterarEnderecoSacado,
        /// <summary>
        /// The retorno recebimento instrucao alterar tipo cobranca
        /// </summary>
        RetornoRecebimentoInstrucaoAlterarTipoCobranca,
        /// <summary>
        /// The retorno recebimento instrucao alterar valor titulo
        /// </summary>
        RetornoRecebimentoInstrucaoAlterarValorTitulo,
        /// <summary>
        /// The retorno recebimento instrucao alterar juros
        /// </summary>
        RetornoRecebimentoInstrucaoAlterarJuros,
        /// <summary>
        /// The retorno recebimento instrucao dispensar juros
        /// </summary>
        RetornoRecebimentoInstrucaoDispensarJuros,
        /// <summary>
        /// The retorno abatimento concedido
        /// </summary>
        RetornoAbatimentoConcedido,
        /// <summary>
        /// The retorno abatimento cancelado
        /// </summary>
        RetornoAbatimentoCancelado,
        /// <summary>
        /// The retorno desconto concedido
        /// </summary>
        RetornoDescontoConcedido,
        /// <summary>
        /// The retorno desconto cancelado
        /// </summary>
        RetornoDescontoCancelado,
        /// <summary>
        /// The retorno dados alterados
        /// </summary>
        RetornoDadosAlterados,
        /// <summary>
        /// The retorno vencimento alterado
        /// </summary>
        RetornoVencimentoAlterado,
        /// <summary>
        /// The retorno alteracao dados nova entrada
        /// </summary>
        RetornoAlteracaoDadosNovaEntrada,
        /// <summary>
        /// The retorno alteracao dados baixa
        /// </summary>
        RetornoAlteracaoDadosBaixa,
        /// <summary>
        /// The retorno alteracao dados rejeitados
        /// </summary>
        RetornoAlteracaoDadosRejeitados,
        /// <summary>
        /// The retorno alteracao outros dados rejeitada
        /// </summary>
        RetornoAlteracaoOutrosDadosRejeitada,
        /// <summary>
        /// The retorno alteracao uso cedente
        /// </summary>
        RetornoAlteracaoUsoCedente,
        /// <summary>
        /// The retorno alteracao data emissao
        /// </summary>
        RetornoAlteracaoDataEmissao,
        /// <summary>
        /// The retorno alteracao especie
        /// </summary>
        RetornoAlteracaoEspecie,
        /// <summary>
        /// The retorno alteracao seu numero
        /// </summary>
        RetornoAlteracaoSeuNumero,
        /// <summary>
        /// The retorno protestado
        /// </summary>
        RetornoProtestado,
        /// <summary>
        /// The retorno protesto sustado
        /// </summary>
        RetornoProtestoSustado,
        /// <summary>
        /// The retorno protesto ou sustacao estornado
        /// </summary>
        RetornoProtestoOuSustacaoEstornado,
        /// <summary>
        /// The retorno instrucao protesto rejeitada sustada ou pendente
        /// </summary>
        RetornoInstrucaoProtestoRejeitadaSustadaOuPendente,
        /// <summary>
        /// The retorno instrucao rejeitada
        /// </summary>
        RetornoInstrucaoRejeitada,
        /// <summary>
        /// The retorno instrucao cancelada
        /// </summary>
        RetornoInstrucaoCancelada,
        /// <summary>
        /// The retorno debito em conta
        /// </summary>
        RetornoDebitoEmConta,
        /// <summary>
        /// The retorno debito direto autorizado
        /// </summary>
        RetornoDebitoDiretoAutorizado,
        /// <summary>
        /// The retorno debito direto nao autorizado
        /// </summary>
        RetornoDebitoDiretoNaoAutorizado,
        /// <summary>
        /// The retorno nome sacado alterado
        /// </summary>
        RetornoNomeSacadoAlterado,
        /// <summary>
        /// The retorno endereco sacado alterado
        /// </summary>
        RetornoEnderecoSacadoAlterado,
        /// <summary>
        /// The retorno encaminhado a cartorio
        /// </summary>
        RetornoEncaminhadoACartorio,
        /// <summary>
        /// The retorno entrada em cartorio
        /// </summary>
        RetornoEntradaEmCartorio,
        /// <summary>
        /// The retorno retirado de cartorio
        /// </summary>
        RetornoRetiradoDeCartorio,
        /// <summary>
        /// The retorno juros dispensados
        /// </summary>
        RetornoJurosDispensados,
        /// <summary>
        /// The retorno despesas protesto
        /// </summary>
        RetornoDespesasProtesto,
        /// <summary>
        /// The retorno despesas sustacao protesto
        /// </summary>
        RetornoDespesasSustacaoProtesto,
        /// <summary>
        /// The retorno custas sustacao
        /// </summary>
        RetornoCustasSustacao,
        /// <summary>
        /// The retorno custas protesto
        /// </summary>
        RetornoCustasProtesto,
        /// <summary>
        /// The retorno custas cartorio distribuidor
        /// </summary>
        RetornoCustasCartorioDistribuidor,
        /// <summary>
        /// The retorno custas edital
        /// </summary>
        RetornoCustasEdital,
        /// <summary>
        /// The retorno custas sustacao judicial
        /// </summary>
        RetornoCustasSustacaoJudicial,
        /// <summary>
        /// The retorno custas irregularidade
        /// </summary>
        RetornoCustasIrregularidade,
        /// <summary>
        /// The retorno acerto depositaria
        /// </summary>
        RetornoAcertoDepositaria,
        /// <summary>
        /// The retorno acerto controle participante
        /// </summary>
        RetornoAcertoControleParticipante,
        /// <summary>
        /// The retorno acerto dados rateio credito
        /// </summary>
        RetornoAcertoDadosRateioCredito,
        /// <summary>
        /// The retorno entrada rejeita cep irregular
        /// </summary>
        RetornoEntradaRejeitaCEPIrregular,
        /// <summary>
        /// The retorno entrada confirmada rateio credito
        /// </summary>
        RetornoEntradaConfirmadaRateioCredito,
        /// <summary>
        /// The retorno entrada registrada aguardando avaliacao
        /// </summary>
        RetornoEntradaRegistradaAguardandoAvaliacao,
        /// <summary>
        /// The retorno entrada rejeitada carne
        /// </summary>
        RetornoEntradaRejeitadaCarne,
        /// <summary>
        /// The retorno entrada bordero manual
        /// </summary>
        RetornoEntradaBorderoManual,
        /// <summary>
        /// The retorno desagendamento debito automatico
        /// </summary>
        RetornoDesagendamentoDebitoAutomatico,
        /// <summary>
        /// The retorno estorno pagamento
        /// </summary>
        RetornoEstornoPagamento,
        /// <summary>
        /// The retorno sustado judicial
        /// </summary>
        RetornoSustadoJudicial,
        /// <summary>
        /// The retorno manutencao titulo vencido
        /// </summary>
        RetornoManutencaoTituloVencido,
        /// <summary>
        /// The retorno tipo cobranca alterado
        /// </summary>
        RetornoTipoCobrancaAlterado,
        /// <summary>
        /// The retorno cancelamento dados rateio
        /// </summary>
        RetornoCancelamentoDadosRateio,
        /// <summary>
        /// The retorno outras ocorrencias
        /// </summary>
        RetornoOutrasOcorrencias,
        /// <summary>
        /// The retorno ocorrencias do sacado
        /// </summary>
        RetornoOcorrenciasDoSacado,
        /// <summary>
        /// The retorno cobranca contratual
        /// </summary>
        RetornoCobrancaContratual,
        /// <summary>
        /// The retorno tarifa extrato posicao
        /// </summary>
        RetornoTarifaExtratoPosicao,
        /// <summary>
        /// The retorno tarifa de relacao das liquidacoes
        /// </summary>
        RetornoTarifaDeRelacaoDasLiquidacoes,
        /// <summary>
        /// The retorno tarifa de manutencao de titulos vencidos
        /// </summary>
        RetornoTarifaDeManutencaoDeTitulosVencidos,
        /// <summary>
        /// The retorno tarifa emissao boleto envio duplicata
        /// </summary>
        RetornoTarifaEmissaoBoletoEnvioDuplicata,
        /// <summary>
        /// The retorno tarifa instrucao
        /// </summary>
        RetornoTarifaInstrucao,
        /// <summary>
        /// The retorno tarifa ocorrencias
        /// </summary>
        RetornoTarifaOcorrencias,
        /// <summary>
        /// The retorno tarifa aviso cobranca
        /// </summary>
        RetornoTarifaAvisoCobranca,
        /// <summary>
        /// The retorno tarifa mensal emissao boleto envio duplicata
        /// </summary>
        RetornoTarifaMensalEmissaoBoletoEnvioDuplicata,
        /// <summary>
        /// The retorno tarifa mensal reference entradas bancos corresp carteira
        /// </summary>
        RetornoTarifaMensalRefEntradasBancosCorrespCarteira,
        /// <summary>
        /// The retorno tarifa mensal baixas carteira
        /// </summary>
        RetornoTarifaMensalBaixasCarteira,
        /// <summary>
        /// The retorno tarifa mensal baixas bancos corresp carteira
        /// </summary>
        RetornoTarifaMensalBaixasBancosCorrespCarteira,
        /// <summary>
        /// The retorno tarifa mensal liquidacoes carteira
        /// </summary>
        RetornoTarifaMensalLiquidacoesCarteira,
        /// <summary>
        /// The retorno tarifa mensal liquidacoes bancos corresp carteira
        /// </summary>
        RetornoTarifaMensalLiquidacoesBancosCorrespCarteira,
        /// <summary>
        /// The retorno tarifa emissao aviso movimentacao titulos
        /// </summary>
        RetornoTarifaEmissaoAvisoMovimentacaoTitulos,
        /// <summary>
        /// The retorno debito tarifas
        /// </summary>
        RetornoDebitoTarifas,
        /// <summary>
        /// The retorno debito custas antecipadas
        /// </summary>
        RetornoDebitoCustasAntecipadas,
        /// <summary>
        /// The retorno debito mensal tarifas extrado posicao
        /// </summary>
        RetornoDebitoMensalTarifasExtradoPosicao,
        /// <summary>
        /// The retorno debito mensal tarifas outras instrucoes
        /// </summary>
        RetornoDebitoMensalTarifasOutrasInstrucoes,
        /// <summary>
        /// The retorno debito mensal tarifas manutencao titulos vencidos
        /// </summary>
        RetornoDebitoMensalTarifasManutencaoTitulosVencidos,
        /// <summary>
        /// The retorno debito mensal tarifas outras ocorrencias
        /// </summary>
        RetornoDebitoMensalTarifasOutrasOcorrencias,
        /// <summary>
        /// The retorno debito mensal tarifas protestos
        /// </summary>
        RetornoDebitoMensalTarifasProtestos,
        /// <summary>
        /// The retorno debito mensal tarifas sustacao protestos
        /// </summary>
        RetornoDebitoMensalTarifasSustacaoProtestos,
        /// <summary>
        /// The retorno debito mensal tarifa aviso movimentacao titulos
        /// </summary>
        RetornoDebitoMensalTarifaAvisoMovimentacaoTitulos,
        /// <summary>
        /// The retorno cheque devolvido
        /// </summary>
        RetornoChequeDevolvido,
        /// <summary>
        /// The retorno cheque compensado
        /// </summary>
        RetornoChequeCompensado,
        /// <summary>
        /// The retorno confirmacao entrada cobranca simples
        /// </summary>
        RetornoConfirmacaoEntradaCobrancaSimples,
        /// <summary>
        /// The retorno alegacao do sacado
        /// </summary>
        RetornoAlegacaoDoSacado,
        /// <summary>
        /// The retorno despesa cartorio
        /// </summary>
        RetornoDespesaCartorio,
        /// <summary>
        /// The retorno equalizacao vendor
        /// </summary>
        RetornoEqualizacaoVendor
    }
}
