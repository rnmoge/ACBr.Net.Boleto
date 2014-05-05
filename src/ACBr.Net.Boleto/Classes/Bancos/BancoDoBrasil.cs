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
	[Guid("618EBC46-7D78-4F60-823F-8C2E88DBB2A8")]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes
    /// <summary>
    /// Classe BancoDoBrasil. Esta classe não pode ser herdada.
    /// </summary>
    public sealed class BancoDoBrasil : BancoBase
    {
        #region Fields
        #endregion Fields

        #region Constructor

        /// <summary>
        /// Inicializa uma nova instancia da classe <see cref="BancoDoBrasil" />.
        /// </summary>
        /// <param name="parent">Classe Banco.</param>
        internal BancoDoBrasil(Banco parent):base(parent)
        {
            TipoCobranca = TipoCobranca.BancoDoBrasil;
            Digito = 9;
            Nome = "Banco do Brasil";
            Numero = 1;
            TamanhoMaximoNossoNum = 0;
            TamanhoConta = 12;
            TamanhoAgencia = 4;
            TamanhoCarteira = 2;
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
            var CodOcorrencia = TipoOCorrenciaToCod(Tipo);
            switch (CodOcorrencia)
            {
                case "02": return "02-Confirmação de Entrada de Título";
                case "03": return "03-Comando recusado";
                case "05": return "05-Liquidado sem registro";
                case "06": return "06-Liquidação Normal";
                case "07": return "07-Liquidação por Conta";
                case "08": return "08-Liquidação por Saldo";
                case "09": return "09-Baixa de Título";
                case "10": return "10-Baixa Solicitada";
                case "11": return "11-Titulos em Ser";
                case "12": return "12-Abatimento Concedido";
                case "13": return "13-Abatimento Cancelado";
                case "14": return "14-Alteração de Vencimento do Titulo";
                case "15": return "15-Liquidação em Cartório";
                case "16": return "16-Confirmação de alteração de juros de mora";
                case "19": return "19-Confirmação de recebimento de instruções para protesto";
                case "20": return "20-Débito em Conta";
                case "21": return "21-Alteração do Nome do Sacado";
                case "22": return "22-Alteração do Endereço do Sacado";
                case "23": return "23-Indicação de encaminhamento a cartório";
                case "24": return "24-Sustar Protesto";
                case "25": return "25-Dispensar Juros";
                case "26": return "26-Alteração do número do título dado pelo Cedente (Seu número) - 10 e 15 posições";
                case "28": return "28-Manutenção de titulo vencido";
                case "31": return "31-Conceder desconto";
                case "32": return "32-Não conceder desconto";
                case "33": return "33-Retificar desconto";
                case "34": return "34-Alterar data para desconto";
                case "35": return "35-Cobrar multa";
                case "36": return "36-Dispensar multa";
                case "37": return "37-Dispensar indexador";
                case "38": return "38-Dispensar prazo limite para recebimento";
                case "39": return "39-Alterar prazo limite para recebimento";
                case "41": return "41-Alteração do número do controle do participante (25 posições)";
                case "42": return "42-Alteração do número do documento do sacado (CNPJ/CPF)";
                case "44": return "44-Título pago com cheque devolvido";
                case "46": return "46-Título pago com cheque, aguardando compensação";
                case "72": return "72-Alteração de tipo de cobrança";
                case "96": return "96-Despesas de Protesto";
                case "97": return "97-Despesas de Sustação de Protesto";
                case "98": return "98-Débito de Custas Antecipadas";
                default: return string.Empty;
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
                case 9: return TipoOcorrencia.RetornoBaixado;
                case 10: return TipoOcorrencia.RetornoBaixadoInstAgencia;
                case 11: return TipoOcorrencia.RetornoTituloEmSer;
                case 12: return TipoOcorrencia.RetornoRecebimentoInstrucaoConcederAbatimento;
                case 13: return TipoOcorrencia.RetornoRecebimentoInstrucaoCancelarAbatimento;
                case 14: return TipoOcorrencia.RetornoRecebimentoInstrucaoAlterarVencimento;
                case 15: return TipoOcorrencia.RetornoLiquidadoEmCartorio;
                case 17: return TipoOcorrencia.RetornoLiquidadoSemRegistro;
                case 19: return TipoOcorrencia.RetornoRecebimentoInstrucaoProtestar;
                case 20: return TipoOcorrencia.RetornoRecebimentoInstrucaoSustarProtesto;
                case 22: return TipoOcorrencia.RetornoEnderecoSacadoAlterado;
                case 23: return TipoOcorrencia.RetornoEncaminhadoACartorio;
                case 24: return TipoOcorrencia.RetornoRetiradoDeCartorio;
                case 25: return TipoOcorrencia.RetornoProtestado;
                case 26: return TipoOcorrencia.RetornoInstrucaoRejeitada;
                case 27: return TipoOcorrencia.RetornoRecebimentoInstrucaoAlterarDados;
                case 28: return TipoOcorrencia.RetornoDebitoTarifas;
                case 29: return TipoOcorrencia.RetornoOcorrenciasDoSacado;
                case 30: return TipoOcorrencia.RetornoAlteracaoDadosRejeitados;
                case 36: return TipoOcorrencia.RetornoRecebimentoInstrucaoConcederDesconto;
                case 37: return TipoOcorrencia.RetornoRecebimentoInstrucaoCancelarDesconto;
                case 43: return TipoOcorrencia.RetornoProtestoOuSustacaoEstornado;
                case 44: return TipoOcorrencia.RetornoBaixaOuLiquidacaoEstornada;
                case 45: return TipoOcorrencia.RetornoDadosAlterados;
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
                case TipoOcorrencia.RetornoComandoRecusado: return "03";
                case TipoOcorrencia.RetornoLiquidado: return "06";
                case TipoOcorrencia.RetornoBaixado: return "09";
                case TipoOcorrencia.RetornoBaixadoInstAgencia: return "10";
                case TipoOcorrencia.RetornoTituloEmSer: return "11";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoConcederAbatimento: return "12";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoCancelarAbatimento: return "13";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoAlterarVencimento: return "14";
                case TipoOcorrencia.RetornoLiquidadoEmCartorio: return "15";
                case TipoOcorrencia.RetornoLiquidadoSemRegistro: return "17";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoProtestar: return "19";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoSustarProtesto: return "20";
                case TipoOcorrencia.RetornoAcertoControleParticipante: return "21";
                case TipoOcorrencia.RetornoEnderecoSacadoAlterado: return "22";
                case TipoOcorrencia.RetornoEncaminhadoACartorio: return "23";
                case TipoOcorrencia.RetornoRetiradoDeCartorio: return "24";
                case TipoOcorrencia.RetornoProtestado: return "25";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoAlterarDados: return "27";
                case TipoOcorrencia.RetornoDebitoTarifas: return "28";
                case TipoOcorrencia.RetornoOcorrenciasDoSacado: return "29";
                case TipoOcorrencia.RetornoAlteracaoDadosRejeitados: return "30";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoConcederDesconto: return "36";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoCancelarDesconto: return "37";
                case TipoOcorrencia.RetornoProtestoOuSustacaoEstornado: return "43";
                case TipoOcorrencia.RetornoBaixaOuLiquidacaoEstornada: return "44";
                case TipoOcorrencia.RetornoDadosAlterados: return "45";
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
                    switch (CodMotivo)
                    {
                        case 1: return "01-Identificação inválida";
                        case 2: return "02-Variação da carteira inválida";
                        case 3: return "03-Valor dos juros por um dia inválido";
                        case 4: return "04-Valor do desconto inválido";
                        case 5: return "05-Espécie de título inválida para carteira";
                        case 6: return "06-Espécie de valor variável inválido";
                        case 7: return "07-Prefixo da agência usuária inválido";
                        case 8: return "08-Valor do título/apólice inválido";
                        case 9: return "09-Data de vencimento inválida";
                        case 10: return "10-Fora do prazo";
                        case 11: return "11-Inexistência de margem para desconto";
                        case 12: return "12-O Banco não tem agência na praça do sacado";
                        case 13: return "13-Razões cadastrais";
                        case 14: return "14-Sacado interligado com o sacador";
                        case 15: return "15-Título sacado contra orgão do Poder Público";
                        case 16: return "16-Título preenchido de forma irregular";
                        case 17: return "17-Título rasurado";
                        case 18: return "18-Endereço do sacado não localizado ou incompleto";
                        case 19: return "19-Código do cedente inválido";
                        case 20: return "20-Nome/endereco do cliente não informado /ECT/";
                        case 21: return "21-Carteira inválida";
                        case 22: return "22Quantidade de valor variável inválida";
                        case 23: return "23-Faixa nosso número excedida";
                        case 24: return "24-Valor do abatimento inválido";
                        case 25: return "25-Novo número do título dado pelo cedente inválido";
                        case 26: return "26-Valor do IOF de seguro inválido";
                        case 27: return "27-Nome do sacado/cedente inválido ou não informado";
                        case 28: return "28-Data do novo vencimento inválida";
                        case 29: return "29-Endereco não informado";
                        case 30: return "30-Registro de título já liquidado";
                        case 31: return "31-Numero do bordero inválido";
                        case 32: return "32-Nome da pessoa autorizada inválido";
                        case 33: return "33-Nosso número já existente";
                        case 34: return "34-Numero da prestação do contrato inválido";
                        case 35: return "35-Percentual de desconto inválido";
                        case 36: return "36-Dias para fichamento de protesto inválido";
                        case 37: return "37-Data de emissão do título inválida";
                        case 38: return "38-Data do vencimento anterior a data da emissão do título";
                        case 39: return "39-Comando de alteração indevido para a carteira";
                        case 40: return "40-Tipo de moeda inválido";
                        case 41: return "41-Abatimento não permitido";
                        case 42: return "42-CEP do sacado inválido /ECT/";
                        case 43: return "43-Codigo de unidade variavel incompativel com a data emissão do título";
                        case 44: return "44-Dados para debito ao sacado inválidos";
                        case 45: return "45-Carteira";
                        case 46: return "46-Convenio encerrado";
                        case 47: return "47-Título tem valor diverso do informado";
                        case 48: return "48-Motivo de baixa inválido para a carteira";
                        case 49: return "49-Abatimento a cancelar não consta do título";
                        case 50: return "50-Comando incompativel com a carteira";
                        case 51: return "51-Codigo do convenente inválido";
                        case 52: return "52-Abatimento igual ou maior que o valor do título";
                        case 53: return "53-Título já se encontra situação pretendida";
                        case 54: return "54-Título fora do prazo admitido para a conta 1";
                        case 55: return "55-Novo vencimento fora dos limites da carteira";
                        case 56: return "56-Título não pertence ao convenente";
                        case 57: return "57-Variação incompativel com a carteira";
                        case 58: return "58-Impossivel a transferencia para a carteira indicada";
                        case 59: return "59-Título vencido em transferencia para a carteira 51";
                        case 60: return "60-Título com prazo superior a 179 dias em transferencia para carteira 51";
                        case 61: return "61-Título já foi fichado para protesto";
                        case 62: return "62-Alteração da situação de debito inválida para o codigo de responsabilidade";
                        case 63: return "63-DV do nosso número inválido";
                        case 64: return "64-Título não passivel de debito/baixa - situação anormal";
                        case 65: return "65-Título com ordem de não protestar-não pode ser encaminhado a cartorio";
                        case 67: return "66-Título/carne rejeitado";
                        case 80: return "80-Nosso número inválido";
                        case 81: return "81-Data para concessão do desconto inválida";
                        case 82: return "82-CEP do sacado inválido";
                        case 83: return "83-Carteira/variação não localizada no cedente";
                        case 84: return "84-Título não localizado na existencia";
                        case 99: return "99-Outros motivos";
                        default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoLiquidado:
                    switch (CodMotivo)
                    {
                        case 1: return "01-Liquidação normal";
                        case 2: return "02-Liquidação parcial";
                        case 3: return "03-Liquidação por saldo";
                        case 4: return "04-Liquidação com cheque a compensar";
                        case 5: return "05-Liquidação de título sem registro (carteira 7 tipo 4)";
                        case 7: return "07-Liquidação na apresentação";
                        case 9: return "09-Liquidação em cartório";
                        default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoRegistroConfirmado:
                    switch (CodMotivo)
                    {
                        case 0: return "00-Por meio magnético";
                        case 11: return "11-Por via convencional";
                        case 16: return "16-Por alteração do código do cedente";
                        case 17: return "17-Por alteração da variação";
                        case 18: return "18-Por alteração de carteira";
                        default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoBaixado:
                case TipoOcorrencia.RetornoBaixadoInstAgencia:
                    switch (CodMotivo)
                    {
                        case 0: return "00-Solicitada pelo cliente";
                        case 15: return "15-Protestado";
                        case 18: return "18-Por alteração de carteira";
                        case 19: return "19-Débito automático";
                        case 31: return "31-Liquidado anteriormente";
                        case 32: return "32-Habilitado em processo";
                        case 33: return "33-Incobrável por nosso intermédio";
                        case 34: return "34-Transferido para créditos em liquidação";
                        case 46: return "46-Por alteração da variação";
                        case 47: return "47-Por alteração da variação";
                        case 51: return "51-Acerto";
                        case 90: return "90-Baixa automática";
                        default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
                    }

                default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
            }
        }

        /// <summary>
        /// Formata o campo nosso numero a partir do boleto informado
        /// </summary>
        /// <param name="titulo">boleto.</param>
        /// <returns>Nosso Numero.</returns>
        private string FormataNossoNumero(Titulo titulo)
        {
            var AConvenio = titulo.Parent.Cedente.Convenio;
            var ANossoNumero = titulo.NossoNumero.OnlyNumbers();
            var wNossoNumero = titulo.NossoNumero.OnlyNumbers();
            var wTamNossoNum = CalcularTamMaximoNossoNumero(titulo.Carteira, wNossoNumero);

            if ((titulo.Carteira == "16" || titulo.Carteira == "18") && AConvenio.Length == 6 && wTamNossoNum == 17)
                ANossoNumero = ANossoNumero.FillRight(17, '0');
            else if (titulo.Carteira == "18" && AConvenio.Length == 7 && wTamNossoNum == 11)
                ANossoNumero = ANossoNumero.FillRight(11, '0');
            else if (AConvenio.Length <= 4)
                ANossoNumero = AConvenio.FillRight(4, '0') + ANossoNumero.FillRight(7, '0');
            else if (AConvenio.Length > 4 && AConvenio.Length <= 6)
                ANossoNumero = AConvenio.FillRight(6, '0') + ANossoNumero.FillRight(5, '0');
            else if (AConvenio.Length == 7 && titulo.Carteira == "11")
                ANossoNumero = "0".FillRight(7, '0') + ANossoNumero.FillRight(10, '0');
            else if (AConvenio.Length == 7 && titulo.Carteira != "11")
                ANossoNumero = AConvenio.FillRight(7, '0') + ANossoNumero.FillRight(10, '0');

            return ANossoNumero;
        }

        /// <summary>
        /// Calculars the digito verificador.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string CalcularDigitoVerificador(Titulo Titulo)
        {
            string ret = "0";

            Modulo.CalculoPadrao();
            Modulo.MultiplicadorFinal = 2;
            Modulo.MultiplicadorInicial = 9;
            Modulo.Documento = FormataNossoNumero(Titulo);
            Modulo.Calcular();

            if (Modulo.ModuloFinal >= 10)
                ret = "X";
            else
                ret = Modulo.ModuloFinal.ToString();

            return ret;
        }

        /// <summary>
        /// Calculars the tam maximo nosso numero.
        /// </summary>
        /// <param name="Carteira">The carteira.</param>
        /// <param name="NossoNumero">The nosso numero.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="ACBrException">Banco do Brasil requer que o Convênio do Cedente seja informado.
        /// or
        /// Banco do Brasil requer que a carteira seja informada antes do Nosso Número.</exception>
        public override int CalcularTamMaximoNossoNumero(string Carteira, string NossoNumero = "")
        {
            int ret = 10;

            if (string.IsNullOrEmpty(Banco.Parent.Cedente.Convenio))
                throw new ACBrException("Banco do Brasil requer que o Convênio do Cedente seja informado.");

            if (string.IsNullOrEmpty(Carteira))
                throw new ACBrException("Banco do Brasil requer que a carteira seja informada antes do Nosso Número.");

            var wCarteira = Carteira.Trim();
            var wTamConvenio = Banco.Parent.Cedente.Convenio.Trim().Length;

            if (wTamConvenio == 6 && (wCarteira == "16" || wCarteira == "18"))
                ret = 17;
            else if (wTamConvenio <= 4)
                ret = 7;
            else if (wTamConvenio > 4 && wTamConvenio <= 6)
                ret = 5;
            else if (wTamConvenio == 7)
                ret = 10;

            return ret;
        }

        /// <summary>
        /// Montars the campo codigo cedente.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string MontarCampoCodigoCedente(Titulo Titulo)
        {
            return string.Format("{0}-{1}/{2}-{3}", Titulo.Parent.Cedente.Agencia,
                Titulo.Parent.Cedente.AgenciaDigito, Titulo.Parent.Cedente.Conta.ZeroFill(8),
                Titulo.Parent.Cedente.ContaDigito);
        }

        /// <summary>
        /// Montars the campo nosso numero.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string MontarCampoNossoNumero(Titulo Titulo)
        {
            var ANossoNumero = FormataNossoNumero(Titulo);
            var wTamConvenio = Banco.Parent.Cedente.Convenio.Trim().Length;
            var wTamNossoNum = CalcularTamMaximoNossoNumero(Titulo.Carteira, Titulo.NossoNumero.OnlyNumbers());

            if (wTamConvenio == 7 || (wTamConvenio == 6 && wTamNossoNum == 17))
                return ANossoNumero;
            else
                return string.Format("{0}-{1}", ANossoNumero, CalcularDigitoVerificador(Titulo));
        }

        /// <summary>
        /// Montars the codigo barras.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string MontarCodigoBarras(Titulo Titulo)
        {
            var AConvenio = Titulo.Parent.Cedente.Convenio.Trim();
            var ANossoNumero = FormataNossoNumero(Titulo);
            var wTamNossNum = CalcularTamMaximoNossoNumero(Titulo.Carteira, Titulo.NossoNumero.OnlyNumbers());
            var CodigoBarras = string.Empty;

            //Codigo de Barras
            var FatorVencimento = Titulo.Vencimento.CalcularFatorVencimento();
            if ((Titulo.Carteira == "18" || Titulo.Carteira == "16") && AConvenio.Length == 6 && wTamNossNum == 17)
            {
                CodigoBarras = string.Format("{0:000}9{1}{2}{3}{4}21", Banco.Numero, FatorVencimento, Titulo.ValorDocumento.ToRemessaString(10),
                    AConvenio, ANossoNumero);
            }
            else
            {
                CodigoBarras = string.Format("{0:000}9{1}{2}{3}{4}{5}{6}{7}", Banco.Numero, FatorVencimento, Titulo.ValorDocumento.ToRemessaString(10),
                    AConvenio.Length == 7 ? "000000" : "", ANossoNumero, AConvenio.Length < 7 ? Titulo.Parent.Cedente.Agencia.FillRight(4, '0') : "",
                    AConvenio.Length < 7 ? Titulo.Parent.Cedente.Conta.OnlyNumbers().ZeroFill(8) : "", Titulo.Carteira);
            }

            var DigitoCodBarras = CalcularDigitoCodigoBarras(CodigoBarras);                        
            return CodigoBarras.Insert(4, DigitoCodBarras);
        }

        /// <summary>
        /// Gerars the registro header400.
        /// </summary>
        /// <param name="NumeroRemessa">The numero remessa.</param>
        /// <param name="ARemessa">A remessa.</param>
        public override void GerarRegistroHeader400(int NumeroRemessa, List<string> ARemessa)
        {
             
            var TamConvenioMaior6 = Banco.Parent.Cedente.Convenio.Trim().Length > 6;
            var aAgencia = Banco.Parent.Cedente.Agencia.OnlyNumbers().ZeroFill(4);
            var aConta  = Banco.Parent.Cedente.Conta.OnlyNumbers().ZeroFill(8);

            var wLinha = new StringBuilder();
            wLinha.Append('0');                                             // ID do Registro
            wLinha.Append('1');                                             // ID do Arquivo( 1 - Remessa)
            wLinha.Append("REMESSA");                                       // Literal de Remessa
            wLinha.Append("01");                                            // Código do Tipo de Serviço
            wLinha.Append("COBRANCA".FillLeft(15));                          // Descrição do tipo de serviço
            wLinha.Append(aAgencia);                                        // Prefixo da agência/ onde esta cadastrado o convenente lider do cedente
            wLinha.Append(Banco.Parent.Cedente.AgenciaDigito.FillLeft(1));   // DV-prefixo da agencia
            wLinha.Append(aConta);                                          // Codigo do cedente/nr. da conta corrente que está cadastro o convenio lider do cedente
            wLinha.Append(Banco.Parent.Cedente.ContaDigito.FillLeft(1));     // DV-código do cedente

            
            if(TamConvenioMaior6)
              wLinha.Append("000000");                                         // Complemento
            else
                wLinha.Append(Banco.Parent.Cedente.Convenio.FillRight(6,'0'));  //Convenio;
            
            wLinha.Append(Banco.Parent.Cedente.Nome.RemoveCE().FillLeft(30));    // Nome da Empresa
            wLinha.AppendFormat("{0:000}", Numero);                             // Código do Banco
            wLinha.Append("BANCO DO BRASIL".FillLeft(15));                       // Nome do Banco(BANCO DO BRASIL)
            wLinha.AppendFormat("{0:ddMMyy}", DateTime.Now);                    // Data de geração do arquivo
            wLinha.AppendFormat("{0:0000000}", NumeroRemessa);                  // Numero Remessa
            
            if(TamConvenioMaior6)
            {
                wLinha.Append("".FillRight(22));                                        // Nr. Sequencial de Remessa + brancos
                wLinha.Append(Banco.Parent.Cedente.Convenio.Trim().FillRight(7,'0'));  //Nr. Convenio
                wLinha.Append("".FillRight(258));                                      //Brancos
            }
            else
            {
               wLinha.Append("".FillRight(287));
            }
            
            wLinha.AppendFormat("{0:000000", 1);                               // Nr. Sequencial do registro-informar 000001

            ARemessa.Add(wLinha.ToString().ToUpper());

        }

        /// <summary>
        /// Gerars the registro transacao400.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <param name="ARemessa">A remessa.</param>
        public override void GerarRegistroTransacao400(Titulo Titulo, List<string> ARemessa)
        {
            var wCarteira = Titulo.Carteira.ToInt32();
            string ANossoNumero;
            string ADigitoNossoNumero;
            if ((wCarteira == 11 || wCarteira == 31 || wCarteira == 51) ||
                ((wCarteira == 12 || wCarteira == 15 || wCarteira == 17) &&
                Titulo.Parent.Cedente.ResponEmissao != ResponEmissao.CliEmite))
            {
               ANossoNumero = "00000000000000000000";
               ADigitoNossoNumero = string.Empty;
            }
            else
            {
               ANossoNumero = FormataNossoNumero(Titulo);
               ADigitoNossoNumero = CalcularDigitoVerificador(Titulo);
            }
            
            var TamConvenioMaior6 = Titulo.Parent.Cedente.Convenio.Trim().Length > 6;
            var aAgencia = Titulo.Parent.Cedente.Agencia.OnlyNumbers().ZeroFill(4);
            var aConta = Titulo.Parent.Cedente.Conta.OnlyNumbers().ZeroFill(8);
            var aModalidade = Titulo.Parent.Cedente.Modalidade.Trim().ZeroFill(3);
            
            //Pegando Código da Ocorrencia}
            string ATipoOcorrencia;
            switch(Titulo.OcorrenciaOriginal.Tipo)
            {
                case TipoOcorrencia.RemessaBaixar:
                    ATipoOcorrencia = "02"; //Pedido de Baixa
                    break;
                    
                case TipoOcorrencia.RemessaConcederAbatimento:
                    ATipoOcorrencia = "04"; //Concessão de Abatimento
                    break;
                
                case TipoOcorrencia.RemessaCancelarAbatimento:
                    ATipoOcorrencia = "05"; //Cancelamento de Abatimento concedido}
                    break;
                    
                case TipoOcorrencia.RemessaAlterarVencimento: 
                    ATipoOcorrencia = "06"; //Alteração de vencimento
                    break;
                
                case TipoOcorrencia.RemessaAlterarControleParticipante: 
                    ATipoOcorrencia = "07"; //Alteração do número de controle do participante
                    break;
                
                case TipoOcorrencia.RemessaAlterarNumeroControle:
                    ATipoOcorrencia = "08"; //Alteração de seu número
                    break;
                    
                case TipoOcorrencia.RemessaProtestar: 
                    ATipoOcorrencia = "09"; //Pedido de protesto
                    break;
                
                case TipoOcorrencia.RemessaCancelarInstrucaoProtestoBaixa: 
                    ATipoOcorrencia = "10"; //Sustar protesto e baixar
                    break;
                    
                case TipoOcorrencia.RemessaCancelarInstrucaoProtesto: 
                    ATipoOcorrencia = "10"; //Sustar protesto e manter na carteira
                    break;
                
                case TipoOcorrencia.RemessaDispensarJuros:
                    ATipoOcorrencia = "11"; //Instrução para dispensar juros
                    break;
                    
                case TipoOcorrencia.RemessaAlterarNomeEnderecoSacado:
                    ATipoOcorrencia = "12"; //Alteração de nome e endereço do Sacado
                    break;

                case TipoOcorrencia.RemessaConcederDesconto:
                    ATipoOcorrencia = "31"; //Conceder desconto
                    break;
                    
                case TipoOcorrencia.RemessaCancelarDesconto:
                    ATipoOcorrencia = "32"; //Não conceder desconto
                    break;
                    
                case TipoOcorrencia.RemessaAlterarModalidade:
                    ATipoOcorrencia = "40";
                    break;

                default:
                    ATipoOcorrencia = "01"; //Remessa
                    break;
            }
            
            //Pegando o Aceite do Titulo
            string ATipoAceite;
            switch (Titulo.Aceite)
            {
                case AceiteTitulo.Sim:
                    ATipoAceite = "A";
                    break;

                default:
                    ATipoAceite = "N";
                    break;
            }

            //Pegando o tipo de EspecieDoc
            string ATipoEspecieDoc = string.Empty;            
            if (Titulo.EspecieDoc == "DM")
                ATipoEspecieDoc = "01";
            else if (Titulo.EspecieDoc == "RC")
                ATipoEspecieDoc = "05";
            else if (Titulo.EspecieDoc == "NP")
                ATipoEspecieDoc = "02";
            else if (Titulo.EspecieDoc == "NS")
                ATipoEspecieDoc = "03";
            else if (Titulo.EspecieDoc == "ND")
                ATipoEspecieDoc = "13";
            else if (Titulo.EspecieDoc == "DS")
                ATipoEspecieDoc = "12";
            else if (Titulo.EspecieDoc == "LC")
                ATipoEspecieDoc = "08";
            
            //Pegando Tipo de Cobrança
            string aTipoCobranca;
            switch(Titulo.Carteira.ToInt32())
            {
                case 11:
                case 17:
                switch(Titulo.Parent.Cedente.CaracTitulo)
                {
                    case CaracTitulo.Simples:
                        aTipoCobranca ="     ";
                        break;
                        
                    case CaracTitulo.Descontada:
                        aTipoCobranca = "04DSC";
                        break;
                    
                    case CaracTitulo.Vendor:
                        aTipoCobranca = "08VDR";
                        break;
                    
                    case CaracTitulo.Vinculada: 
                        aTipoCobranca = "02VIN";
                        break;
                    
                    default:
                        aTipoCobranca ="     ";
                        break;
                }
                break;
                
                default:
                    aTipoCobranca ="     ";
                    break;
            }
            
            string AInstrucao = string.Empty;
            string DiasProtesto = "  ";
            if (Titulo.DataProtesto.HasValue && Titulo.DataProtesto > Titulo.Vencimento)
            {
                switch((int)(Titulo.DataProtesto.Value - Titulo.Vencimento).TotalDays)
                {
                    case 3: // Protestar no 3º dia util após vencimento
                        if (string.IsNullOrEmpty(Titulo.Instrucao1.Trim()) ||
                            Titulo.Instrucao1 == "03")
                            AInstrucao = string.Format("03{0}", Titulo.Instrucao2.FillRight(2,'0'));
                            break;
               
                    case 4: // Protestar no 3º dia util após vencimento
                        if (string.IsNullOrEmpty(Titulo.Instrucao1.Trim()) ||
                            Titulo.Instrucao1 == "04")
                            AInstrucao = string.Format("04{0}", Titulo.Instrucao2.FillRight(2,'0'));
                            break;
                    
                    case 5: // Protestar no 3º dia util após vencimento
                        if (string.IsNullOrEmpty(Titulo.Instrucao1.Trim()) ||
                            Titulo.Instrucao1 == "05")
                            AInstrucao = string.Format("05{0}", Titulo.Instrucao2.FillRight(2,'0'));
                            break;
                    
                    default: // Protestar no 3º dia util após vencimento
                        if (string.IsNullOrEmpty(Titulo.Instrucao1.Trim()) ||
                            Titulo.Instrucao1 == "06")
                            AInstrucao = string.Format("06{0}", Titulo.Instrucao2.FillRight(2,'0'));
                            break;
                }
            }
            else
            {
                Titulo.Instrucao1 = "07"; //Não Protestar
                AInstrucao = string.Format("{0}{1}", Titulo.Instrucao1.Trim().FillRight(2,'0'), 
                    Titulo.Instrucao2.Trim().FillRight(2,'0'));
                DiasProtesto = "  ";
            }
            
            var aDataDesconto = "000000";
            if(Titulo.ValorDesconto > 0)
            {
                if(Titulo.DataDesconto > new DateTime(2000,01,01))
                    aDataDesconto = string.Format("{0:ddMMyy}", Titulo.DataDesconto);
                else
                    aDataDesconto = "777777";
            }
            
            //Pegando Tipo de Sacado}
            string ATipoSacado;
            switch(Titulo.Sacado.Pessoa)
            {
                case Pessoa.Fisica:
                   ATipoSacado = "01";
                    break;
                    
                case Pessoa.Juridica:
                    ATipoSacado = "02";
                    break;
                
                default:
                    ATipoSacado = "00";
                    break;
            }
            
            
            //Pegando Tipo de Cedente}
            string ATipoCendente = string.Empty;
            switch(Titulo.Parent.Cedente.TipoInscricao)
            {
                case PessoaCedente.Fisica:
                    ATipoCendente = "01";
                    break;
                
                case PessoaCedente.Juridica:
                    ATipoCendente = "02";
                    break;
            }
            
            var AMensagem = string.Empty;
            if(Titulo.Mensagem.Count > 0)
                AMensagem = Titulo.Mensagem[0];
            
            var wLinha = new StringBuilder();
            
            if(TamConvenioMaior6)
                wLinha.Append('7');                                                        // ID Registro
            else
                wLinha.Append('1');                                                        // ID Registro
            
            wLinha.Append(ATipoCendente);                                                  // Tipo de inscrição da empresa 01-CPF / 02-CNPJ
            wLinha.Append(Titulo.Parent.Cedente.CNPJCPF.OnlyNumbers().FillRight(14,'0'));  //Inscrição da empresa
            wLinha.Append(aAgencia);                                                       // Prefixo da agencia
            wLinha.Append(Titulo.Parent.Cedente.AgenciaDigito.FillLeft(1));                 // DV-prefixo da agencia
            wLinha.Append(aConta);                                                         // Código do cendete/nr. conta corrente da empresa
            wLinha.Append(Titulo.Parent.Cedente.ContaDigito.FillLeft(1));                   // DV-código do cedente

            if(TamConvenioMaior6)
                wLinha.Append(Titulo.Parent.Cedente.Convenio.Trim().FillRight(7));          // Número do convenio
            else
                wLinha.Append(Titulo.Parent.Cedente.Convenio.Trim().FillRight(6));          // Número do convenio
            
            wLinha.Append(Titulo.SeuNumero.FillLeft(25));                                   // Numero de Controle do Participante
            
            if(TamConvenioMaior6)
                wLinha.Append(ANossoNumero.FillRight(17, '0'));                             // Nosso numero
            else
                wLinha.Append(ANossoNumero.FillRight(11) + ADigitoNossoNumero);

            
            wLinha.Append("0000" + "".FillRight(7) + aModalidade);                          // Zeros + Brancos + Prefixo do titulo + Variação da carteira

            if(TamConvenioMaior6)
                wLinha.Append("".ZeroFill(7));                                             // Zero + Zeros + Zero + Zeros
            else
                wLinha.Append("".ZeroFill(13));
            
            wLinha.Append(aTipoCobranca);                                                  // Tipo de cobrança - 11, 17 (04DSC, 08VDR, 02VIN, BRANCOS) 12,31,51 (BRANCOS)
            wLinha.Append(Titulo.Carteira);                                                // Carteira
            wLinha.Append(ATipoOcorrencia);                                                // Ocorrência "Comando"
            wLinha.Append(Titulo.NumeroDocumento.FillLeft(10));                             // Seu Numero - Nr. titulo dado pelo cedente
            wLinha.AppendFormat("{0:ddMMyy}", Titulo.Vencimento);                          // Data de vencimento
            wLinha.Append(Titulo.ValorDocumento.ToRemessaString());                        // Valor do titulo
            wLinha.Append("0010000 ");                                                     // Numero do Banco - 001 + Prefixo da agencia cobradora + DV-pref. agencia cobradora
            wLinha.Append(ATipoEspecieDoc.FillRight(2, '0') + ATipoAceite);                 // Especie de titulo + Aceite
            wLinha.AppendFormat("{0:ddMMyy}", Titulo.DataDocumento);                       // Data de Emissão
            wLinha.Append(AInstrucao);                                                     // 1ª e 2ª instrução codificada
            wLinha.Append(Titulo.ValorMoraJuros.ToRemessaString());                        // Juros de mora por dia
            wLinha.Append(aDataDesconto);                                                  // Data limite para concessao de desconto
            wLinha.Append(Titulo.ValorDesconto.ToRemessaString());                         // Valor do desconto
            wLinha.Append(Titulo.ValorIOF.ToRemessaString());                              // Valor do IOF
            wLinha.Append(Titulo.ValorAbatimento.ToRemessaString());                       // Valor do abatimento permitido
            wLinha.Append(ATipoSacado);
            wLinha.Append(Titulo.Sacado.CNPJCPF.OnlyNumbers().FillRight(14,'0'));           // Tipo de inscricao do sacado + CNPJ ou CPF do sacado
            wLinha.Append(Titulo.Sacado.NomeSacado.RemoveCE().FillLeft(37) + "   ");        // Nome do sacado + Brancos
            wLinha.Append(string.Format("{0}, {1} {2}", Titulo.Sacado.Logradouro.Trim(),
                       Titulo.Sacado.Numero.Trim(), Titulo.Sacado.Bairro.Trim())
                       .FillLeft(52));                                                      // Endereço do sacado
            wLinha.Append(Titulo.Sacado.CEP.OnlyNumbers().FillRight(8));                    // CEP do endereço do sacado
            wLinha.Append(Titulo.Sacado.Cidade.Trim().FillLeft(15));                        // Cidade do sacado
            wLinha.Append(Titulo.Sacado.UF.FillLeft(2));                                    // UF da cidade do sacado
            wLinha.Append(AMensagem.FillLeft(40));                                          // Observações
            wLinha.Append(DiasProtesto.FillRight(2,'0') + ' ');                             // Número de dias para protesto + Branco
            wLinha.AppendFormat("{0:000000}", ARemessa.Count + 1);

            
            wLinha.Append(Environment.NewLine);
            wLinha.Append('5');                                                           //Tipo Registro
            wLinha.Append("99");                                                          //Tipo de Serviço (Cobrança de Multa)
            wLinha.Append(Titulo.PercentualMulta > 0 ?  '2' : '9');                       //Cod. Multa 2- Percentual 9-Sem Multa
            wLinha.Append(Titulo.PercentualMulta > 0 ?
                string.Format("{0:ddMMyy}", Titulo.DataMoraJuros) :
                "000000");                                                                //Data Multa
            wLinha.Append(Titulo.PercentualMulta.ToRemessaString(12));                    //Perc. Multa
            wLinha.Append("".FillRight(372));                                              //Brancos
            wLinha.AppendFormat("{0:000000}", ARemessa.Count + 2);
            
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
            wLinha.Append("".FillRight(393));                        // ID Registro
            wLinha.AppendFormat("{0:000000}", ARemessa.Count + 1);  // Contador de Registros
            
            ARemessa.Add(wLinha.ToString().ToUpper());
        }

        /// <summary>
        /// Lers the retorno400.
        /// </summary>
        /// <param name="ARetorno">A retorno.</param>
        /// <exception cref="ACBrException">@Agencia\Conta do arquivo inválido</exception>
        public override void LerRetorno400(List<string> ARetorno)
        {            
            if(ARetorno[0].ExtrairInt32DaPosicao(77,79) != Numero)
                throw new ACBrException(string.Format("{0} não é um arquivo de retorno do {1}",
                                                       Banco.Parent.NomeArqRetorno, Nome));

            TamanhoMaximoNossoNum = 20;
            var rCedente = ARetorno[0].ExtrairDaPosicao(47, 76);
            var rAgencia = ARetorno[0].ExtrairDaPosicao(27, 30).Trim();
            var rDigitoAgencia = ARetorno[0].ExtrairDaPosicao(31, 31);
            var rConta = ARetorno[0].ExtrairDaPosicao(32, 39).Trim();
            var rDigitoConta = ARetorno[0].ExtrairDaPosicao(40, 40).Trim();
            var rCodigoCedente = ARetorno[0].ExtrairDaPosicao(150, 156);
            
            Banco.Parent.NumeroArquivo = ARetorno[0].ExtrairInt32DaPosicao(101, 107);
            Banco.Parent.DataArquivo = ARetorno[0].ExtrairDataDaPosicao(95, 100);
            
            if (!Banco.Parent.LeCedenteRetorno  && (rAgencia != Banco.Parent.Cedente.Agencia.OnlyNumbers() ||
                rConta != Banco.Parent.Cedente.Conta.OnlyNumbers()))
                throw new ACBrException(@"Agencia\Conta do arquivo inválido");
            
            Banco.Parent.Cedente.Nome = rCedente;
            Banco.Parent.Cedente.Agencia = rAgencia;
            Banco.Parent.Cedente.AgenciaDigito = rDigitoAgencia;
            Banco.Parent.Cedente.Conta = rConta;
            Banco.Parent.Cedente.ContaDigito = rDigitoConta;
            Banco.Parent.Cedente.CodigoCedente = rCodigoCedente;
            Banco.Parent.ListadeBoletos.Clear();
            
            TamanhoMaximoNossoNum = 20;
            Titulo Titulo;
            for (int ContLinha = 1; ContLinha < ARetorno.Count - 1; ContLinha++)
            {
                var Linha = ARetorno[ContLinha];

                if (Linha.ExtrairDaPosicao(1, 1) != "7" && Linha.ExtrairDaPosicao(1, 1) != "1")
                    continue;

                Titulo = Banco.Parent.CriarTituloNaLista();

                Titulo.SeuNumero = Linha.ExtrairDaPosicao(39, 64);
                Titulo.NumeroDocumento = Linha.ExtrairDaPosicao(117, 126);
                Titulo.OcorrenciaOriginal.Tipo = CodOcorrenciaToTipo(Linha.ExtrairInt32DaPosicao(109, 110));

                var CodOcorrencia = Linha.ExtrairDaPosicao(109, 110) == "00" ? 0 : Linha.ExtrairInt32DaPosicao(109, 110);
                int MotivoLinha;
                int CodMotivo;
                if (CodOcorrencia >= 2 && CodOcorrencia <= 10)
                {
                    MotivoLinha = 87;
                    CodMotivo = Linha.ExtrairDaPosicao(MotivoLinha, MotivoLinha + 1) == "00" ? 0 :
                        Linha.ExtrairInt32DaPosicao(MotivoLinha, MotivoLinha + 1);
                    Titulo.MotivoRejeicaoComando.Add(Linha.ExtrairDaPosicao(87, 88));
                    Titulo.DescricaoMotivoRejeicaoComando.Add(CodMotivoRejeicaoToDescricao(Titulo.OcorrenciaOriginal.Tipo, CodMotivo));
                }

                Titulo.DataOcorrencia = Linha.ExtrairDataDaPosicao(111, 116);
                Titulo.Vencimento = Linha.ExtrairDataDaPosicao(147, 152);

                Titulo.ValorDocumento = Linha.ExtrairDecimalDaPosicao(153, 165);
                Titulo.ValorIOF = Linha.ExtrairDecimalDaPosicao( 215, 227);
                Titulo.ValorAbatimento = Linha.ExtrairDecimalDaPosicao( 228, 240);
                Titulo.ValorDesconto = Linha.ExtrairDecimalDaPosicao(241, 253);
                Titulo.ValorRecebido = Linha.ExtrairDecimalDaPosicao( 254, 266);
                Titulo.ValorMoraJuros = Linha.ExtrairDecimalDaPosicao( 267, 279);
                Titulo.ValorOutrosCreditos = Linha.ExtrairDecimalDaPosicao( 280, 292);
                Titulo.NossoNumero = Linha.ExtrairDaPosicao( 64, 80);
                Titulo.Carteira = Linha.ExtrairDaPosicao( 92, 94);
                Titulo.ValorDespesaCobranca = Linha.ExtrairDecimalDaPosicao( 182, 188); 
                Titulo.ValorOutrasDespesas = Linha.ExtrairDecimalDaPosicao( 189, 201);

                var tempdata = Linha.ExtrairDataOpcionalDaPosicao(176, 181);
                if (tempdata.HasValue)
                    Titulo.DataCredito = tempdata.Value;
            }

            TamanhoMaximoNossoNum = 10;
        }

        /// <summary>
        /// Gerars the registro header240.
        /// </summary>
        /// <param name="NumeroRemessa">The numero remessa.</param>
        /// <returns>System.String.</returns>
        public override string GerarRegistroHeader240(int NumeroRemessa)
        {
            string ATipoInscricao;
            switch (Banco.Parent.Cedente.TipoInscricao)
            {
                case PessoaCedente.Fisica:
                    ATipoInscricao = "1";
                    break;

                case PessoaCedente.Juridica:
                    ATipoInscricao = "2";
                    break;

                default:
                    ATipoInscricao = "1";
                    break;
            }

            var CNPJCIC = Banco.Parent.Cedente.CNPJCPF.OnlyNumbers();
            var aAgencia = Banco.Parent.Cedente.Agencia.OnlyNumbers().ZeroFill(5);
            var aConta = Banco.Parent.Cedente.Conta.OnlyNumbers().ZeroFill(12);
            var aModalidade = Banco.Parent.Cedente.Modalidade.Trim().ZeroFill(3);

            var Result = new StringBuilder();
            Result.AppendFormat("{0:000}", Banco.Numero);                                    //1 a 3 - Código do banco
            Result.Append("0000");                                                           //4 a 7 - Lote de serviço
            Result.Append("0");                                                              //8 - Tipo de registro - Registro header de arquivo
            Result.Append("".FillLeft(9));                                                    //9 a 17 Uso exclusivo FEBRABAN/CNAB
            Result.Append(ATipoInscricao);                                                   //18 - Tipo de inscrição do cedente
            Result.Append(CNPJCIC.FillRight(14, '0'));                                        //19 a 32 -Número de inscrição do cedente
            Result.Append(Banco.Parent.Cedente.Convenio.FillRight(9, '0') + "0014");          //33 a 45 - Código do convênio no banco [ Alterado conforme instruções da CSO Brasília ] 27-07-09
            Result.Append(Banco.Parent.ListadeBoletos[0].Carteira);                          //46 a 47 - Carteira
            Result.Append(aModalidade + "  ");                                               //48 a 52 - Variacao Carteira
            Result.Append(aAgencia);                                                         //53 a 57 - Código da agência do cedente
            Result.Append(Banco.Parent.Cedente.AgenciaDigito.FillLeft(1, '0'));               //58 - Dígito da agência do cedente
            Result.Append(aConta);                                                           //59 a 70 - Número da conta do cedente
            Result.Append(Banco.Parent.Cedente.ContaDigito.FillLeft(1, '0'));                 //71 - Dígito da conta do cedente
            Result.Append(" ");                                                              //72 - Dígito verificador da agência / conta
            Result.Append(Banco.Parent.Cedente.Nome.RemoveCE().FillLeft(30).ToUpper());       //73 a 102 - Nome do cedente
            Result.Append("BANCO DO BRASIL".FillLeft(30));                                    //103 a 132 - Nome do banco
            Result.Append("".FillLeft(10));                                                   //133 a 142 - Uso exclusivo FEBRABAN/CNAB
            Result.Append('1');                                                              //143 - Código de Remessa (1) / Retorno (2)
            Result.AppendFormat("{0:ddMMyyyy}", DateTime.Now);                               //144 a 151 - Data do de geração do arquivo
            Result.AppendFormat("{0:hhmmss}", DateTime.Now);                                 //152 a 157 - Hora de geração do arquivo
            Result.Append(NumeroRemessa.ToString().FillRight(6, '0'));                        //158 a 163 - Número seqüencial do arquivo
            Result.Append("030");                                                            //164 a 166 - Número da versão do layout do arquivo
            Result.Append("".FillLeft(5, '0'));                                               //167 a 171 - Densidade de gravação do arquivo (BPI)
            Result.Append("".FillLeft(20));                                                   //172 a 191 - Uso reservado do banco
            Result.Append("".FillLeft(20, '0'));                                              //192 a 211 - Uso reservado da empresa
            Result.Append("".FillLeft(11));                                                   //212 a 222 - 11 brancos
            Result.Append("CSP");                                                            //223 a 225 - 'CSP'
            Result.Append("".FillLeft(3, '0'));                                               //226 a 228 - Uso exclusivo de Vans
            Result.Append("".FillLeft(2));                                                    //229 a 230 - Tipo de servico
            Result.Append("".FillLeft(10));                                                   //231 a 240 - titulo em carteira de cobranca

            // GERAR REGISTRO HEADER DO LOTE }
            Result.Append(Environment.NewLine);
            Result.AppendFormat("{0:000}", Banco.Numero);                                    //1 a 3 - Código do banco
            Result.Append("0001");                                                           //4 a 7 - Lote de serviço
            Result.Append('1');                                                              //8 - Tipo de registro - Registro header de arquivo
            Result.Append('R');                                                              //9 - Tipo de operação: R (Remessa) ou T (Retorno)
            Result.Append("01");                                                             //10 a 11 - Tipo de serviço: 01 (Cobrança)
            Result.Append("00");                                                             //12 a 13 - Forma de lançamento: preencher com ZEROS no caso de cobrança
            Result.Append("020");                                                            //14 a 16 - Número da versão do layout do lote
            Result.Append(" ");                                                              //17 - Uso exclusivo FEBRABAN/CNAB
            Result.Append(ATipoInscricao);                                                   //18 - Tipo de inscrição do cedente
            Result.Append(CNPJCIC.FillRight(15, '0'));                                        //19 a 32 -Número de inscrição do cedente
            Result.Append(Banco.Parent.Cedente.Convenio.FillRight(9, '0') + "0014");           //33 a 45 - Código do convênio no banco [ Alterado conforme instruções da CSO Brasília ] 27-07-09
            Result.Append(Banco.Parent.ListadeBoletos[0].Carteira);                          //46 a 47 - Carteira
            Result.Append(aModalidade + "  ");                                               //48 a 52 - Variacao Carteira
            Result.Append(aAgencia);                                                         //53 a 57 - Código da agência do cedente
            Result.Append(Banco.Parent.Cedente.AgenciaDigito.FillLeft(1, '0'));              //58 - Dígito da agência do cedente
            Result.Append(aConta);                                                           //59 a 70 - Número da conta do cedente
            Result.Append(Banco.Parent.Cedente.ContaDigito.FillLeft(1, '0'));                 //71 - Dígito da conta do cedente
            Result.Append(" ");                                                              //72 - Dígito verificador da agência / conta
            Result.Append(Banco.Parent.Cedente.Nome.FillLeft(30));                            //73 a 102 - Nome do cedente
            Result.Append("".FillLeft(40));                                                   //104 a 143 - Mensagem 1 para todos os boletos do lote
            Result.Append("".FillLeft(40));                                                   //144 a 183 - Mensagem 2 para todos os boletos do lote
            Result.Append(NumeroRemessa.ToString().FillRight(8, '0'));                        //184 a 191 - Número do arquivo
            Result.AppendFormat("{0:ddMMyyyy}", DateTime.Now);                               //192 a 199 - Data de geração do arquivo
            Result.Append("".FillLeft(8, '0'));                                               //200 a 207 - Data do crédito - Só para arquivo retorno
            Result.Append("".FillLeft(33));                                                   //208 a 240 - Uso exclusivo FEBRABAN/CNAB  

            return Result.ToString();
        }

        /// <summary>
        /// Gerars the registro transacao240.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string GerarRegistroTransacao240(Titulo Titulo)
        {
            var ANossoNumero = FormataNossoNumero(Titulo);
            var wTamConvenio = Banco.Parent.Cedente.Convenio.Length;
            var wTamNossoNum = CalcularTamMaximoNossoNumero(Titulo.Carteira, Titulo.NossoNumero);
            string aDV;

            if ((wTamConvenio == 7 || wTamConvenio == 6) && wTamNossoNum == 17)
                aDV = string.Empty;
            else
                aDV = CalcularDigitoVerificador(Titulo);

            if (ANossoNumero == "0")
            {
                ANossoNumero = string.Empty;
                aDV = string.Empty;
            }

            var aAgencia = Titulo.Parent.Cedente.Agencia.OnlyNumbers().ZeroFill(5);
            var aConta = Titulo.Parent.Cedente.Conta.OnlyNumbers().ZeroFill(12);

            //SEGMENTO P
            //Pegando o Tipo de Ocorrencia

            string ATipoOcorrencia = string.Empty;
            switch (Titulo.OcorrenciaOriginal.Tipo)
            {
                case TipoOcorrencia.RemessaBaixar:
                    ATipoOcorrencia = "02";
                    break;

                case TipoOcorrencia.RemessaConcederAbatimento:
                    ATipoOcorrencia = "04";
                    break;

                case TipoOcorrencia.RemessaCancelarAbatimento:
                    ATipoOcorrencia = "05";
                    break;

                case TipoOcorrencia.RemessaAlterarVencimento:
                    ATipoOcorrencia = "06";
                    break;

                case TipoOcorrencia.RemessaConcederDesconto:
                    ATipoOcorrencia = "07";
                    break;

                case TipoOcorrencia.RemessaCancelarDesconto:
                    ATipoOcorrencia = "08";
                    break;

                case TipoOcorrencia.RemessaProtestar:
                    ATipoOcorrencia = "09";
                    break;

                case TipoOcorrencia.RemessaCancelarInstrucaoProtesto:
                    ATipoOcorrencia = "10";
                    break;

                case TipoOcorrencia.RemessaAlterarNomeEnderecoSacado:
                    ATipoOcorrencia = "12";
                    break;

                case TipoOcorrencia.RemessaDispensarJuros:
                    ATipoOcorrencia = "31";
                    break;

                default:
                    ATipoOcorrencia = "01";
                    break;
            }

            //Pegando o tipo de EspecieDoc
            string ATipoEspecieDoc = string.Empty;
            if (Titulo.EspecieDoc == "DM")
                ATipoEspecieDoc = "02";
            else if (Titulo.EspecieDoc == "RC")
                ATipoEspecieDoc = "17";
            else if (Titulo.EspecieDoc == "NP")
                ATipoEspecieDoc = "12";
            else if (Titulo.EspecieDoc == "NS")
                ATipoEspecieDoc = "16";
            else if (Titulo.EspecieDoc == "ND")
                ATipoEspecieDoc = "19";
            else if (Titulo.EspecieDoc == "DS")
                ATipoEspecieDoc = "04";

            //Pegando o Aceite do Titulo
            string ATipoAceite;
            switch (Titulo.Aceite)
            {
                case AceiteTitulo.Sim:
                    ATipoAceite = "A";
                    break;

                default:
                    ATipoAceite = "N";
                    break;
            }

            //Pegando Tipo de Boleto
            //Quem emite e quem distribui o boleto?
            string ATipoBoleto = string.Empty;
            switch (Titulo.Parent.Cedente.ResponEmissao)
            {
                case ResponEmissao.CliEmite:
                    ATipoBoleto = "22";
                    break;

                case ResponEmissao.BancoEmite:
                    ATipoBoleto = "11";
                    break;

                case ResponEmissao.BancoReemite:
                    ATipoBoleto = "41";
                    break;

                case ResponEmissao.BancoNaoReemite:
                    ATipoBoleto = "52";
                    break;
            }
                        
            string ACaracTitulo = string.Empty;
            switch (Titulo.Parent.Cedente.CaracTitulo)
            {
                case CaracTitulo.Simples:
                    ACaracTitulo = "1";
                    break;

                case CaracTitulo.Vinculada:
                    ACaracTitulo = "2";
                    break;

                case CaracTitulo.Caucionada:
                    ACaracTitulo = "3";
                    break;

                case CaracTitulo.Descontada:
                    ACaracTitulo = "4";
                    break;

                case CaracTitulo.Vendor:
                    ACaracTitulo = "5";
                    break;
            }

            var wCarteira = Titulo.Carteira.ToInt32();
            string wTipoCarteira;

            if ((wCarteira == 11 || wCarteira == 12 || wCarteira == 17) && ACaracTitulo == "1")
                wTipoCarteira = "1";
            else if (((wCarteira == 11 || wCarteira == 17) && (ACaracTitulo == "2" || ACaracTitulo == "3")) || wCarteira == 31)
                wTipoCarteira = ACaracTitulo;
            else if (((wCarteira == 11 || wCarteira == 17) && ACaracTitulo == "4") || wCarteira == 51)
                wTipoCarteira = ACaracTitulo;
            else
                wTipoCarteira = "7";

            //Mora Juros
            string ADataMoraJuros;
            if (Titulo.ValorMoraJuros > 0)
            {
                if (Titulo.DataMoraJuros.HasValue && Titulo.DataMoraJuros > DateTime.Now)
                    ADataMoraJuros = string.Format("{0:ddMMyyyy}", Titulo.DataMoraJuros);
                else
                    ADataMoraJuros = "".FillLeft(8, '0');
            }
            else
                ADataMoraJuros = "".FillLeft(8, '0');

            //Descontos
            string ADataDesconto;
            if (Titulo.ValorDesconto > 0)
            {
                if (Titulo.DataDesconto.HasValue && Titulo.DataDesconto > DateTime.Now)
                    ADataDesconto = string.Format("{0:ddMMyyyy}", Titulo.DataDesconto);
                else
                    ADataDesconto = "".FillLeft(8, '0');
            }
            else
                ADataDesconto = "".FillLeft(8, '0');

            //SEGMENTO P
            var Result = new StringBuilder();
            Result.AppendFormat("{0:000}", Banco.Numero);                                                 //1 a 3 - Código do banco
            Result.Append("0001");                                                                        //4 a 7 - Lote de serviço
            Result.Append("3");                                                                           //8 - Tipo do registro: Registro detalhe
            Result.AppendFormat("{0:00000}", (3 * Titulo.Parent.ListadeBoletos.IndexOf(Titulo) + 1));     //9 a 13 - Número seqüencial do registro no lote - Cada título tem 2 registros (P e Q)
            Result.Append("P");                                                                           //14 - Código do segmento do registro detalhe
            Result.Append(" ");                                                                           //15 - Uso exclusivo FEBRABAN/CNAB: Branco
            Result.Append(ATipoOcorrencia);                                                               //16 a 17 - Código de movimento
            Result.Append(aAgencia);                                                                      //18 a 22 - Agência mantenedora da conta
            Result.Append(Titulo.Parent.Cedente.AgenciaDigito.FillLeft(1, '0'));                           //23 -Dígito verificador da agência
            Result.Append(aConta);                                                                        //24 a 35 - Número da conta corrente
            Result.Append(Titulo.Parent.Cedente.ContaDigito.FillLeft(1, '0'));                             //36 - Dígito verificador da conta
            Result.Append(" ");                                                                           //37 - Dígito verificador da agência / conta
            Result.Append(ANossoNumero + aDV.FillLeft(20));                                                //38 a 57 - Nosso número - identificação do título no banco
            Result.Append(wTipoCarteira);                                                                 //58 - Cobrança Simples
            Result.Append('1');                                                                           //59 - Forma de cadastramento do título no banco: com cadastramento
            Result.Append(((int)Titulo.Parent.Cedente.TipoDocumento).ToString());                         //60 - Tipo de documento: Tradicional
            Result.Append(ATipoBoleto);                                                                   //61 a 62 - Quem emite e quem distribui o boleto?
            Result.Append(Titulo.NumeroDocumento.FillLeft(15));                                            //63 a 77 - Número que identifica o título na empresa [ Alterado conforme instruções da CSO Brasília ] {27-07-09}
            Result.AppendFormat("{0:ddMMyyyy}", Titulo.Vencimento);                                       //78 a 85 - Data de vencimento do título
            Result.Append(Titulo.ValorDocumento.ToRemessaString(15));                                     //86 a 100 - Valor nominal do título
            Result.Append("000000");                                                                      //101 a 106 - Agência cobradora + Digito. Se ficar em branco, a caixa determina automaticamente pelo CEP do sacado
            Result.Append(ATipoEspecieDoc.FillLeft(2));                                                    //107 a 108 - Espécie do documento
            Result.Append(ATipoAceite);                                                                   //109 - Identificação de título Aceito / Não aceito
            Result.AppendFormat("{0:ddMMyyyy}", Titulo.DataDocumento);                                    //110 a 117 - Data da emissão do documento
            Result.Append(Titulo.ValorMoraJuros > 0 ? '1' : '3');                                         //118 - Código de juros de mora: Valor por dia
            Result.Append(ADataMoraJuros);                                                                //119 a 126 - Data a partir da qual serão cobrados juros
            Result.Append(Titulo.ValorMoraJuros > 0 ? Titulo.ValorMoraJuros.ToRemessaString(15) :
                                                        "0".ZeroFill(15));                                //127 a 141 - Valor de juros de mora por dia
            Result.Append(Titulo.ValorDesconto > 0 ?
                Titulo.DataDesconto > DateTime.Now ? '1' : '3' : '0');                                    //142 - Código de desconto: 1 - Valor fixo até a data informada 4-Desconto por dia de antecipacao 0 - Sem desconto
            Result.Append(Titulo.ValorDesconto > 0 ?
                Titulo.DataDesconto > DateTime.Now ? ADataDesconto : "00000000" : "00000000");            //143 a 150 - Data do desconto
            Result.Append(Titulo.ValorDesconto > 0 ? Titulo.ValorDesconto.ToRemessaString(15) : 
                                                        "0".ZeroFill(15));                                //151 a 165 - Valor do desconto por dia
            Result.Append(Titulo.ValorIOF.ToRemessaString(15));                                           //166 a 180 - Valor do IOF a ser recolhido
            Result.Append(Titulo.ValorAbatimento.ToRemessaString(15));                                    //181 a 195 - Valor do abatimento
            Result.Append(Titulo.SeuNumero.FillLeft(25));                                                  //196 a 220 - Identificação do título na empresa

            Result.Append(Titulo.DataProtesto.HasValue && Titulo.DataProtesto > Titulo.Vencimento ?
                (Titulo.DataProtesto.Value - Titulo.Vencimento).TotalDays > 5 ? '1' : '2' : '3');         //221 - Código de protesto: Protestar em XX dias corridos

            Result.Append(Titulo.DataProtesto.HasValue && Titulo.DataProtesto > Titulo.Vencimento ?
                (Titulo.Vencimento - Titulo.DataProtesto.Value).TotalDays.ToString().FillLeft(2, '0')
                : "00");                                                                                  //222 a 223 - Prazo para protesto (em dias corridos)

            Result.Append("0");                                                                           //224 - Campo não tratado pelo BB [ Alterado conforme instruções da CSO Brasília ] {27-07-09}
            Result.Append("000");                                                                         //225 a 227 - Campo não tratado pelo BB [ Alterado conforme instruções da CSO Brasília ] {27-07-09}
            Result.Append("09");                                                                          //228 a 229 - Código da moeda: Real
            Result.Append("".FillLeft(10, '0'));                                                           //230 a 239 - Uso exclusivo FEBRABAN/CNAB
            Result.Append(" ");                                                                           //240 - Uso exclusivo FEBRABAN/CNAB

            //SEGMENTO Q
            Result.Append(Environment.NewLine);
            Result.AppendFormat("{0:000}", Banco.Numero);                                                 //1 a 3 - Código do banco
            Result.Append("0001");                                                                        //Número do lote
            Result.Append("3");                                                                           //Tipo do registro: Registro detalhe
            Result.AppendFormat("{0:00000}", (3 * Titulo.Parent.ListadeBoletos.IndexOf(Titulo) + 1));     //9 a 13 - Número seqüencial do registro no lote - Cada título tem 2 registros (P e Q)
            Result.Append("Q");                                                                           //Código do segmento do registro detalhe
            Result.Append(" ");                                                                           //Uso exclusivo FEBRABAN/CNAB: Branco
            Result.Append(ATipoOcorrencia);                                                               //Tipo Ocorrencia

            //Dados do sacado
            Result.Append(Titulo.Sacado.Pessoa == Pessoa.Juridica ? '2' : '1');                           //Tipo inscricao
            Result.Append(Titulo.Sacado.CNPJCPF.OnlyNumbers().FillLeft(15, '0'));
            Result.Append(Titulo.Sacado.NomeSacado.RemoveCE().FillLeft(40));
            Result.Append((string.Format("{0} {1} {2}", Titulo.Sacado.Logradouro.RemoveCE(),
                Titulo.Sacado.Numero, Titulo.Sacado.Complemento.RemoveCE())).FillLeft(40));
            Result.Append(Titulo.Sacado.Bairro.RemoveCE().FillLeft(15));
            Result.Append(Titulo.Sacado.CEP.OnlyNumbers().FillRight(8, '0'));
            Result.Append(Titulo.Sacado.Cidade.RemoveCE().FillLeft(15));
            Result.Append(Titulo.Sacado.UF.FillLeft(2));

            //Dados do sacador/avalista
            Result.Append('0');                                                                           //Tipo de inscrição: Não informado
            Result.Append("".FillLeft(15, '0'));                                                           //Número de inscrição
            Result.Append("".FillLeft(40));                                                                //Nome do sacador/avalista
            Result.Append("".FillLeft(3, '0'));                                                            //Uso exclusivo FEBRABAN/CNAB
            Result.Append("".FillLeft(20));                                                                //Uso exclusivo FEBRABAN/CNAB
            Result.Append("".FillLeft(8));                                                                 //Uso exclusivo FEBRABAN/CNAB

            //SEGMENTO R
            Result.Append(Environment.NewLine);
            Result.AppendFormat("{0:000}", Banco.Numero);                                                 //1 a 3 - Código do banco
            Result.Append("0001");                                                                        //Número do lote
            Result.Append("3");                                                                           //Tipo do registro: Registro detalhe
            Result.AppendFormat("{0:00000}", (3 * Titulo.Parent.ListadeBoletos.IndexOf(Titulo) + 1));     //9 a 13 - Número seqüencial do registro no lote - Cada título tem 2 registros (P e Q)
            Result.Append('R');                                                                           // 14 - 14 Código do segmento do registro detalhe
            Result.Append(" ");                                                                           // 15 - 15 Uso exclusivo FEBRABAN/CNAB: Branco
            Result.Append(ATipoOcorrencia);                                                               // 16 - 17 Tipo Ocorrencia
            Result.Append("".FillRight(48, '0'));                                                          // 18 - 65 Brancos (Não definido pelo FEBRAN)
            Result.Append(Titulo.PercentualMulta > 0 ? '2' : '0');                                        // 66 - 66 1-Cobrar Multa / 0-Não cobrar multa
            Result.Append(Titulo.PercentualMulta > 0 ?
                string.Format("{0:ddMMyyyy}", Titulo.DataMoraJuros) : "00000000");                        // 67 - 74 Se cobrar informe a data para iniciar a cobrança ou informe zeros se não cobrar

            Result.Append(Titulo.PercentualMulta > 0 ? Titulo.PercentualMulta.ToRemessaString(15) :
                    "".FillLeft(15, '0'));                                                                 // 75 - 89 Percentual de multa. Informar zeros se não cobrar

            Result.Append("".FillLeft(110));                                                               // 90 - 199
            Result.Append("".FillLeft(8, '0'));                                                            // 200 - 207
            Result.Append("".FillRight(33));                                                               // 208 - 240 Brancos (Não definido pelo FEBRAN)

            return Result.ToString();
        }

        /// <summary>
        /// Gerars the registro trailler240.
        /// </summary>
        /// <param name="ARemessa">A remessa.</param>
        /// <returns>System.String.</returns>
        public override string GerarRegistroTrailler240(List<string> ARemessa)
        {
            //REGISTRO TRAILER DO LOTE}
            var Result = new StringBuilder();
            Result.AppendFormat("{0:000}", Banco.Numero);                               //Código do banco
            Result.Append("0001");                                                      //Número do lote
            Result.Append('5');                                                         //Tipo do registro: Registro trailer do lote
            Result.Append("".FillLeft(9));                                               //Uso exclusivo FEBRABAN/CNAB
            Result.AppendFormat("{0:000000}", (3 * ARemessa.Count - 1));                //Quantidade de Registro da Remessa
            Result.Append("".FillLeft(6, '0'));                                          //Quantidade títulos em cobrança
            Result.Append("".FillLeft(17, '0'));                                         //Valor dos títulos em carteiras}
            Result.Append("".FillLeft(6, '0'));                                          //Quantidade títulos em cobrança
            Result.Append("".FillLeft(17, '0'));                                         //Valor dos títulos em carteiras}
            Result.Append("".FillLeft(6, '0'));                                          //Quantidade títulos em cobrança
            Result.Append("".FillLeft(17, '0'));                                         //Valor dos títulos em carteiras}
            Result.Append("".FillLeft(6, '0'));                                          //Quantidade títulos em cobrança
            Result.Append("".FillLeft(17, '0'));                                         //Valor dos títulos em carteiras}
            Result.Append("".FillLeft(8));                                               //Uso exclusivo FEBRABAN/CNAB}
            Result.Append("".FillLeft(117));

            //ERAR REGISTRO TRAILER DO ARQUIVO}
            Result.Append(Environment.NewLine);
            Result.AppendFormat("{0:000}", Banco.Numero);                               //Código do banco
            Result.Append("9999");                                                      //Lote de serviço
            Result.Append('9');                                                         //Tipo do registro: Registro trailer do arquivo
            Result.Append("".FillLeft(9));                                               //Uso exclusivo FEBRABAN/CNAB}
            Result.Append("000001");                                                    //Quantidade de lotes do arquivo}
            Result.AppendFormat("{0:000000}", ((ARemessa.Count - 1) * 3) + 4);          //Quantidade de registros do arquivo, inclusive este registro que está sendo criado agora}
            Result.Append("".FillLeft(6));                                               //Uso exclusivo FEBRABAN/CNAB}
            Result.Append("".FillLeft(205));                                             //Uso exclusivo FEBRABAN/CNAB}      

            return Result.ToString();
        }

        /// <summary>
        /// Lers the retorno240.
        /// </summary>
        /// <param name="ARetorno">A retorno.</param>
        /// <exception cref="ACBrException">@CNPJ\CPF do arquivo inválido</exception>
        public override void LerRetorno240(List<string> ARetorno)
        {
            if(ARetorno[0].ExtrairInt32DaPosicao(1, 3) != Numero)
                throw new ACBrException(string.Format("{0} não é um arquivo de retorno do {1}'", 
                    Banco.Parent.NomeArqRetorno, Nome));
            
            Banco.Parent.DataArquivo = ARetorno[0].ExtrairDataDaPosicao(146, 152);
            Banco.Parent.NumeroArquivo = ARetorno[0].ExtrairInt32DaPosicao(158, 163);
            
            var rCedente = ARetorno[0].ExtrairDaPosicao(73, 102).Trim();
            var rCNPJCPF = ARetorno[0].ExtrairDaPosicao(19, 32).OnlyNumbers();
            
            if (!Banco.Parent.LeCedenteRetorno && rCNPJCPF != Banco.Parent.Cedente.CNPJCPF.OnlyNumbers())
                throw new ACBrException(@"CNPJ\CPF do arquivo inválido");
            
            Banco.Parent.Cedente.Nome = rCedente;
            Banco.Parent.Cedente.CNPJCPF = rCNPJCPF;
            
            switch(ARetorno[0].ExtrairInt32DaPosicao(18, 18))
            {
                case 1:
                    Banco.Parent.Cedente.TipoInscricao = PessoaCedente.Fisica;
                    break;

                default:
                    Banco.Parent.Cedente.TipoInscricao = PessoaCedente.Juridica;
                    break;
            }
            
            Banco.Parent.ListadeBoletos.Clear();
            
            TamanhoMaximoNossoNum = 20;
            Titulo titulo = null;

            for(int ContLinha = 1; ContLinha < ARetorno.Count - 1; ContLinha++)
            {
               var Linha = ARetorno[ContLinha];
                
                 // verifica se o registro (linha) é um registro detalhe (segmento J)
                if(Linha.ExtrairInt32DaPosicao(8, 8) != 3)
                    continue;
                
                // se for segmento T cria um novo titulo                
                if(Linha.ExtrairDaPosicao(14, 14) == "T")
                {
                    titulo = Banco.Parent.CriarTituloNaLista();

                    if (Linha.ExtrairDaPosicao(133, 133) == "1")
                        titulo.Sacado.Pessoa = Pessoa.Fisica;
                    else if (Linha.ExtrairDaPosicao(133, 133) == "2")
                        titulo.Sacado.Pessoa = Pessoa.Juridica;
                    else
                        titulo.Sacado.Pessoa = Pessoa.Outras;

                    switch (titulo.Sacado.Pessoa)
                    {
                        case Pessoa.Fisica:
                            titulo.Sacado.CNPJCPF = Linha.ExtrairDaPosicao(137, 148);
                            break;

                        case Pessoa.Juridica:
                            titulo.Sacado.CNPJCPF = Linha.ExtrairDaPosicao(135, 148);
                            break;

                        default:
                            titulo.Sacado.CNPJCPF = Linha.ExtrairDaPosicao(134, 148);
                            break;
                    }

                    titulo.Sacado.NomeSacado = Linha.ExtrairDaPosicao(149, 188).Trim();

                    titulo.SeuNumero = Linha.ExtrairDaPosicao(106, 130);
                    titulo.NumeroDocumento = Linha.ExtrairDaPosicao(59, 73);
                    titulo.Carteira = Linha.ExtrairDaPosicao(58, 58);
                    
                    var dt = Linha.ExtrairDataOpcionalDaPosicao(74, 81);
                    if(dt.HasValue)
                        titulo.Vencimento = dt.Value;

                    titulo.ValorDocumento = Linha.ExtrairDecimalDaPosicao(82, 96);
                    titulo.NossoNumero = Linha.ExtrairDaPosicao(38, 57);
                    titulo.ValorDespesaCobranca = Linha.ExtrairDecimalDaPosicao(199, 213);                    
                    titulo.OcorrenciaOriginal.Tipo = CodOcorrenciaToTipo(Linha.ExtrairInt32DaPosicao(16, 17));
                    
                    var IdxMotivo = 214;                    
                    while (IdxMotivo < 223)
                    {
                        if(string.IsNullOrEmpty(Linha.ExtrairDaPosicao(IdxMotivo, IdxMotivo+1)))
                        {
                            titulo.MotivoRejeicaoComando.Add(Linha.ExtrairDaPosicao(IdxMotivo, IdxMotivo+1));
                            titulo.DescricaoMotivoRejeicaoComando.Add(
                                CodMotivoRejeicaoToDescricao(titulo.OcorrenciaOriginal.Tipo, 
                                Linha.ExtrairInt32DaPosicao(IdxMotivo, IdxMotivo+1)));
                        }
                        IdxMotivo += 2;
                    }
                }
                else
                { 
                    // segmento U
                    titulo.ValorIOF = Linha.ExtrairDecimalDaPosicao(63, 77);
                    titulo.ValorAbatimento = Linha.ExtrairDecimalDaPosicao(48, 62);
                    titulo.ValorDesconto = Linha.ExtrairDecimalDaPosicao(33, 47);
                    titulo.ValorMoraJuros = Linha.ExtrairDecimalDaPosicao(18, 32);
                    titulo.ValorOutrosCreditos = Linha.ExtrairDecimalDaPosicao(123, 137);
                    titulo.ValorRecebido = Linha.ExtrairDecimalDaPosicao(78, 92);
                    titulo.ValorOutrasDespesas = Linha.ExtrairDecimalDaPosicao(108, 113); 
                    
                    var TempData = Linha.ExtrairDataOpcionalDaPosicao(138, 145);
                    if(TempData.HasValue)
                        titulo.DataOcorrencia = TempData.Value;

                    TempData = Linha.ExtrairDataOpcionalDaPosicao(146, 153);
                    if(TempData.HasValue)
                        titulo.DataCredito = TempData.Value;
                }
            }
            
            TamanhoMaximoNossoNum = 10;
        }

        #endregion Methods
    }
}