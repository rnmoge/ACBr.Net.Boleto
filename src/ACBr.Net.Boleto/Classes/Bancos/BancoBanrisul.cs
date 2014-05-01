// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 04-21-2014
//
// Last Modified By : RFTD
// Last Modified On : 04-29-2014
// ***********************************************************************
// <copyright file="BancoBanrisul.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Linq;
using System.Text;
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
	[Guid("468A3233-787C-446E-A016-3098141B8D35")]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes
    /// <summary>
    /// Classe BancoBanrisul. This class cannot be inherited.
    /// </summary>
    public sealed class BancoBanrisul : BancoBase
    {
        #region Fields

        decimal aTotal;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Inicializa uma nova instancia da classe <see cref="BancoBanrisul" />.
        /// </summary>
        /// <param name="parent">Classe Banco.</param>
        internal BancoBanrisul(Banco parent)
            : base(parent)
        {
            TipoCobranca = TipoCobranca.Banrisul;
            Digito = 8;
            Nome = "Banrisul";
            Numero = 41;
            TamanhoMaximoNossoNum = 8;
            TamanhoAgencia = 4;
            TamanhoConta = 7;
            TamanhoCarteira = 1;
            OrientacoesBanco.Clear();
            OrientacoesBanco.Add("SAC       BANRISUL - 0800 646 1515");
            OrientacoesBanco.Add("OUVIDORIA BANRISUL - 0800 644 2200");  
        }

        #endregion Constructor

        #region Propriedades
        #endregion Propriedades

        #region Methods

        /// <summary>
        /// Retorna a descrição do TipoOcorrencia.
        /// </summary>
        /// <param name="Tipo">The tipo.</param>
        /// <returns>System.String.</returns>
        public override string TipoOcorrenciaToDescricao(TipoOcorrencia Tipo)
        {
            var CodOcorrencia = (int)Tipo;
            switch (Banco.Parent.LayoutRemessa)
            {
                case LayoutRemessa.CNAB240:
                    switch (CodOcorrencia)
                    {
                        case 2: return "02-Entrada confirmada";
                        case 3: return "03-Entrada rejeitada";
                        case 4: return "04-Baixa de título liquidado por edital";
                        case 6: return "06-Liquidação normal";
                        case 7: return "07-Liquidação parcial";
                        case 8: return "08-Baixa por pagamento, liquidação de saldo";
                        case 9: return "09-Devolução automática";
                        case 10: return "10-Baixado conforme instruções da agência";
                        case 11: return "11-Arquivo levantamento";
                        case 12: return "12-Abatimento concedido";
                        case 13: return "13-Abatimento cancelado";
                        case 14: return "14-Vencimento alterado";
                        case 15: return "15-Liquidação em cartório";
                        case 16: return "16-Alteração de dados";
                        case 18: return "18-Alteração de instruções";
                        case 19: return "19-Confirmação recebimento instrução de protesto";
                        case 20: return "20-Confirmação recebimento instrução sustação de protesto";
                        case 21: return "21-Aguardando autorização para protesto por edital";
                        case 22: return "22-Protesto sustado por alteração de vencimento e prazo de cartório";
                        case 23: return "23-Entrada do título em cartório";
                        case 25: return "25-Devolução, liquidado anteriormente";
                        case 26: return "26-Devolvido pelo cartório, erro de informação";
                        case 30: return "30-Cobrança a creditar(liquidação em trânsito)";
                        case 31: return "31-Título em trânsito pago em cartório";
                        case 32: return "32-Reembolso e tranferência Desconto e Vendou ou carteira em garantia";
                        case 33: return "33-Reembolso e devolução Desconto e Vendor";
                        case 34: return "34-Reembolso não efetuado por falta de saldo";
                        case 40: return "40-Baixa de títulos protestados";
                        case 41: return "41-Despesa de aponte";
                        case 42: return "42-Alteração de título";
                        case 43: return "43-Relação de títulos";
                        case 44: return "44-Manutenção mensal";
                        case 45: return "45-Sustação de cartório e envio de título a cartório";
                        case 46: return "46-Fornecimento de formulário pré-impresso";
                        case 47: return "47-Confirmação de entrada - Pagador DDA";
                        case 68: return "68-Acerto de dados do rateio de crédito";
                        case 69: return "69-Cancelamento dos dados do rateio";
                        default: return "00-Outras ocorrências";
                    }

                case LayoutRemessa.CNAB400:
                    switch (CodOcorrencia)
                    {
                        case 2: return "02-Entrada confirmada";
                        case 3: return "03-Entrada rejeitada";
                        case 4: return "04-Baixa de título liquidado por edital";
                        case 6: return "06-Liquidação normal";
                        case 7: return "07-Liquidação parcial";
                        case 8: return "08-Baixa por pagamento, liquidação de saldo";
                        case 9: return "09-Devolução automática";
                        case 10: return "10-Baixado conforme instruções da agência";
                        case 11: return "11-Arquivo levantamento";
                        case 12: return "12-Abatimento concedido";
                        case 13: return "13-Abatimento cancelado";
                        case 14: return "14-Vencimento alterado";
                        case 15: return "15-Liquidação em cartório";
                        case 16: return "16-Alteração de dados";
                        case 18: return "18-Alteração de instruções";
                        case 19: return "19-Confirmação recebimento instrução de protesto";
                        case 20: return "20-Confirmação recebimento instrução sustação de protesto";
                        case 21: return "21-Aguardando autorização para protesto por edital";
                        case 22: return "22-Protesto sustado por alteração de vencimento e prazo de cartório";
                        case 23: return "23-Entrada do título em cartório";
                        case 25: return "25-Devolução, liquidado anteriormente";
                        case 26: return "26-Devolvido pelo cartório, erro de informação";
                        case 30: return "30-Cobrança a creditar(liquidação em trânsito)";
                        case 31: return "31-Título em trânsito pago em cartório";
                        case 32: return "32-Reembolso e tranferência Desconto e Vendou ou carteira em garantia";
                        case 33: return "33-Reembolso e devolução Desconto e Vendor";
                        case 34: return "34-Reembolso não efetuado por falta de saldo";
                        case 40: return "40-Baixa de títulos protestados";
                        case 41: return "41-Despesa de aponte";
                        case 42: return "42-Alteração de título";
                        case 43: return "43-Relação de títulos";
                        case 44: return "44-Manutenção mensal";
                        case 45: return "45-Sustação de cartório e envio de título a cartório";
                        case 46: return "46-Fornecimento de formulário pré-impresso";
                        case 47: return "47-Confirmação de entrada - Pagador DDA";
                        case 68: return "68-Acerto de dados do rateio de crédito";
                        case 69: return "69-Cancelamento dos dados do rateio"; 
                        default: return "00-Outras ocorrências";
                    }

                default: return "00-Outras ocorrências";
            }
        }

        /// <summary>
        /// Codigo de ocorrencia para TipoOcorrencia.
        /// </summary>
        /// <param name="CodOcorrencia">Codigo.</param>
        /// <returns>TipoOcorrencia.</returns>
        public override TipoOcorrencia CodOcorrenciaToTipo(int CodOcorrencia)
        {
            switch (Banco.Parent.LayoutRemessa)
            {
                case LayoutRemessa.CNAB240:
                    switch(CodOcorrencia)
                    {
                        case 2: return TipoOcorrencia.RetornoRegistroConfirmado;
                        case 3: return TipoOcorrencia.RetornoRegistroRecusado;
                        case 6: return TipoOcorrencia.RetornoLiquidado;
                        case 7: return TipoOcorrencia.RetornoLiquidadoParcialmente;  //Liquidação Parcial
                        case 9: return TipoOcorrencia.RetornoBaixado;
                        case 11: return TipoOcorrencia.RetornoTituloEmSer;
                        case 12: return TipoOcorrencia.RetornoRecebimentoInstrucaoConcederAbatimento;
                        case 13: return TipoOcorrencia.RetornoRecebimentoInstrucaoCancelarAbatimento;
                        case 14: return TipoOcorrencia.RetornoRecebimentoInstrucaoAlterarVencimento;
                        case 17: return TipoOcorrencia.RetornoLiquidadoAposBaixaOuNaoRegistro;
                        case 19: return TipoOcorrencia.RetornoRecebimentoInstrucaoProtestar;
                        case 20: return TipoOcorrencia.RetornoRecebimentoInstrucaoSustarProtesto;
                        case 23: return TipoOcorrencia.RetornoEncaminhadoACartorio;
                        case 25: return TipoOcorrencia.RetornoBaixaPorProtesto;
                        case 26: return TipoOcorrencia.RetornoInstrucaoRejeitada;
                        case 28: return TipoOcorrencia.RetornoDebitoTarifas;
                        case 30: return TipoOcorrencia.RetornoAlteracaoDadosRejeitados;
                        default: return TipoOcorrencia.RetornoOutrasOcorrencias;
                    }

                case LayoutRemessa.CNAB400:
                    switch (CodOcorrencia)
                    {
                        case 2: return TipoOcorrencia.RetornoRegistroConfirmado;
                        case 3: return TipoOcorrencia.RetornoRegistroRecusado;
                        case 6: return TipoOcorrencia.RetornoLiquidado;
                        case 7: return TipoOcorrencia.RetornoLiquidadoParcialmente;
                        case 8: return TipoOcorrencia.RetornoBaixadoViaArquivo;
                        case 10: return TipoOcorrencia.RetornoBaixadoInstAgencia;
                        case 12: return TipoOcorrencia.RetornoAbatimentoConcedido;
                        case 13: return TipoOcorrencia.RetornoAbatimentoCancelado;
                        case 14: return TipoOcorrencia.RetornoVencimentoAlterado;
                        case 15: return TipoOcorrencia.RetornoLiquidadoEmCartorio;
                        case 19: return TipoOcorrencia.RetornoRecebimentoInstrucaoProtestar;
                        case 20: return TipoOcorrencia.RetornoRecebimentoInstrucaoSustarProtesto;
                        case 23: return TipoOcorrencia.RetornoEntradaEmCartorio;
                        default: return TipoOcorrencia.RetornoOutrasOcorrencias;
                    }

                default: return TipoOcorrencia.RetornoOutrasOcorrencias;
            }
        }

        /// <summary>
        /// TipoOcorrencia para codigo.
        /// </summary>
        /// <param name="Tipo">The tipo.</param>
        /// <returns>System.String.</returns>
        public override string TipoOCorrenciaToCod(TipoOcorrencia Tipo)
        {
            switch (Banco.Parent.LayoutRemessa)
            {
                //Conferir com manual pois foi baseado no CNAB400
                case LayoutRemessa.CNAB240:
                    switch (Tipo)
                    {
                        case TipoOcorrencia.RetornoRegistroConfirmado: return "02";
                        case TipoOcorrencia.RetornoRegistroRecusado: return "03";
                        case TipoOcorrencia.RetornoLiquidado: return "06";
                        case TipoOcorrencia.RetornoLiquidadoParcialmente: return "07";
                        case TipoOcorrencia.RetornoBaixadoInstAgencia: return "10";
                        case TipoOcorrencia.RetornoAbatimentoConcedido: return "12";
                        case TipoOcorrencia.RetornoAbatimentoCancelado: return "13";
                        case TipoOcorrencia.RetornoVencimentoAlterado: return "14";
                        case TipoOcorrencia.RetornoLiquidadoEmCartorio: return "15";
                        case TipoOcorrencia.RetornoRecebimentoInstrucaoProtestar: return "19";
                        case TipoOcorrencia.RetornoRecebimentoInstrucaoSustarProtesto: return "20";
                        case TipoOcorrencia.RetornoEntradaEmCartorio: return "23";  
                        default: return "00";
                    }

                case LayoutRemessa.CNAB400:
                    switch (Tipo)
                    {
                        case TipoOcorrencia.RetornoRegistroConfirmado: return "02";
                        case TipoOcorrencia.RetornoRegistroRecusado: return "03";
                        case TipoOcorrencia.RetornoLiquidado: return "06";
                        case TipoOcorrencia.RetornoLiquidadoParcialmente: return "07";
                        case TipoOcorrencia.RetornoBaixadoInstAgencia: return "10";
                        case TipoOcorrencia.RetornoAbatimentoConcedido: return "12";
                        case TipoOcorrencia.RetornoAbatimentoCancelado: return "13";
                        case TipoOcorrencia.RetornoVencimentoAlterado: return "14";
                        case TipoOcorrencia.RetornoLiquidadoEmCartorio: return "15";
                        case TipoOcorrencia.RetornoRecebimentoInstrucaoProtestar: return "19";
                        case TipoOcorrencia.RetornoRecebimentoInstrucaoSustarProtesto: return "20";
                        case TipoOcorrencia.RetornoEntradaEmCartorio: return "23";  
                        default: return "00";
                    }

                default: return "00";
            }
        }

        /// <summary>
        /// Cods the motivo rejeicao to descricao.
        /// </summary>
        /// <param name="Tipo">The tipo.</param>
        /// <param name="CodMotivo">The cod motivo.</param>
        /// <returns>System.String.</returns>
        public static string CodMotivoRejeicaoToDescricao(TipoOcorrencia Tipo, string CodMotivo)
        {
            switch (Tipo)
            {
                case TipoOcorrencia.RetornoRegistroConfirmado:
                    if (CodMotivo == "A4")
                        return "Sacado DDA";
                    else
                        return string.Format("{0:00} - Outros Motivos", CodMotivo);

                case TipoOcorrencia.RetornoLiquidado:
                case TipoOcorrencia.RetornoLiquidadoAposBaixaOuNaoRegistro:
                    switch (CodMotivo.ToInt32())
                    {
                        case 1: return "Por saldo - Reservado";
                        case 2: return "Por conta (parcial)";
                        case 3: return "No próprio banco";
                        case 4: return "Compensação Eletrônica";
                        case 5: return "Compensação Convencional";
                        case 6: return "Por meio Eletrônico";
                        case 7: return "Reservado";
                        case 8: return "Em Cartório";
                        default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoBaixado:
                    switch(CodMotivo.ToInt32(0))
                    {
                        case 0:
                            if (CodMotivo == "AA")
                                return "Baixa por pagamento";
                            else
                                return "00 - Outros Motivos";
                        case 9: return "Comandado Banco";
                        case 10: return "Comandado cliente Arquivo";
                        case 11: return "Comandado cliente On-Line";
                        case 12: return "Decurso prazo - cliente";
  
                        default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoTituloEmSer:
                    switch(CodMotivo.ToInt32())
                    {
                        case 70: return "Título não selecionado por erro no CNPJ/CPF ou endereço";
                        case 76: return "Banco aguarda cópia autenticada do documento";
                        case 77: return "Título selecionado falta seu número";
                        case 78: return "Título rejeitado pelo cartório por estar irregular";
                        case 79: return "Título não selecionado - praça não atendida";
                        case 80: return "Cartório aguarda autorização para protestar por edital";
                        case 90: return "Protesto sustado por solicitação do cedente";
                        case 91: return "Protesto sustado por alteração no vencimento";
                        case 92: return "Aponte cobrado de título sustado";
                        case 93: return "Protesto sustado por alteração no prazo do protesto";
                        case 95: return "Entidade Pública";
                        case 97: return "Título em cartório";
                        default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoDebitoTarifas: 
                    switch(CodMotivo.ToInt32(0))
                    {
                        case 0:
                            if (CodMotivo == "AA")
                                return "Tarifa de formulário Pré-Impresso";
                            else
                                return "00 - Outros Motivos";
                        case 1: return "Tarifa de extrato de posição";
                        case 2: return "Tarifa de manutenção de título vencido";
                        case 3: return "Tarifa de sustação e envio para cartório";
                        case 4: return "Tarifa de protesto";
                        case 5: return "Tarifa de outras instruções";
                        case 6: return "Tarifa de outras ocorrências(Registro/Liquidação)";
                        case 7: return "Tarifa de envio de duplicata ao sacado";
                        case 8: return "Custas de protesto";
                        case 9: return "Custas de Sustação de Protesto";
                        case 10: return "Custas do cartório distribuidor";
                        case 11: return "Reservado"; 
                        default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
                    }


                default: return string.Format("{0:00} - Outros Motivos", CodMotivo);
            }
        }

        /// <summary>
        /// Montars the campo codigo cedente.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string MontarCampoCodigoCedente(Titulo Titulo)
        {
            return string.Format("{0}-{1}/{2}.{3}.{4}", Titulo.Parent.Cedente.Agencia.Substring(0, 4),
                Titulo.Parent.Cedente.AgenciaDigito, Titulo.Parent.Cedente.CodigoCedente.Substring(0, 6),
                Titulo.Parent.Cedente.CodigoCedente.Substring( 6, 1), 
                Titulo.Parent.Cedente.CodigoCedente.Substring( 7, 2));
        }

        /// <summary>
        /// Montars the campo nosso numero.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string MontarCampoNossoNumero(Titulo Titulo)
        {
            var ret = Titulo.NossoNumero.PadRight(8, '0');
            return string.Format("{0}.{1}", ret, CalculaDigitosChaveASBACE(ret));
        }

        /// <summary>
        /// Montars the codigo barras.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string MontarCodigoBarras(Titulo Titulo)
        {
            string Modalidade;
            if(Titulo.Parent.Cedente.ResponEmissao == ResponEmissao.CliEmite)
                Modalidade = "2";
            else
                Modalidade = "1";

            var CampoLivre = string.Format("{0}1{1}{2}{3}40", Modalidade, Titulo.Parent.Cedente.Agencia.PadRight( 4, '0').Trim(),
                        Titulo.Parent.Cedente.CodigoCedente.OnlyNumbers().PadRight(7, '0'), Titulo.NossoNumero.PadRight(8, '0'));

            CampoLivre += CalculaDigitosChaveASBACE(CampoLivre);
            var CodigoBarras = string.Format("{0:000}9{1}{2}{3}", Numero, Titulo.Vencimento.CalcularFatorVencimento(),
                        Titulo.ValorDocumento.ToRemessaString(10), CampoLivre);

            var DigitoCodBarras = CalcularDigitoCodigoBarras(CodigoBarras);

            if (DigitoCodBarras.ToInt32() == 0 || DigitoCodBarras.ToInt32() > 9)
                DigitoCodBarras = "1";

            return CodigoBarras.Insert(4, DigitoCodBarras);
        }

        /// <summary>
        /// Calculas the digitos chave asbace.
        /// </summary>
        /// <param name="ChaveASBACESemDigito">The chave asbace sem digito.</param>
        /// <returns>System.String.</returns>
        private static string CalculaDigitosChaveASBACE(string ChaveASBACESemDigito)
        {
            //Calcula o primeiro dígito.
            //O cálculo é parecido com o da rotina Modulo10. Porém, não faz diferença o
            //número de dígitos de cada subproduto.
            //Se o resultado da operação for 0 (ZERO) o dígito será 0 (ZERO). Caso contrário,
            //o dígito será igual a 10 - Resultado.    
            Func<string, int> CalcularDigito1 = (ChaveASBACE) =>
            {
                var Soma = 0;
                var Peso = 2;
                var tamanho = ChaveASBACE.Length - 1;
                for (int i = 0; i < tamanho; i++)
                {
                    var Auxiliar = ChaveASBACE[tamanho - i].ToInt32() * Peso;
                    if (Auxiliar > 9)
                        Auxiliar -= 9;
                    Soma += Auxiliar;
                    if (Peso == 1)
                        Peso = 2;
                    else
                        Peso = 1;
                }
                var Digito = Soma % 10;
                if (Digito == 0)
                    return Digito;
                else
                    return 10 - Digito;
            };

            Func<string, int, int> CalcularDigito2 = null;
            CalcularDigito2 = (ChaveASBACE, Digito) =>
            {
                var cDigito = new CalcDigito();
                cDigito.CalculoPadrao();
                cDigito.MultiplicadorFinal = 7;
                cDigito.Documento = String.Format("{0}{1}", ChaveASBACE, Digito);
                cDigito.Calcular();
                int dig2 = cDigito.DigitoFinal;

                //Se dígito2 = 1, deve-se incrementar o dígito1 e recalcular o dígito2}
                if (dig2 == 1)
                {
                    Digito++;
                    //Se, após incrementar o dígito1, ele ficar maior que 9, deve-se substituí-lo por 0
                    if (Digito > 9)
                        Digito = 0;

                    dig2 = CalcularDigito2(ChaveASBACESemDigito, Digito);
                }
                else
                    if (dig2 > 1)
                        dig2 = 11 - dig2;
                return dig2;
            };

            var Digito1 = CalcularDigito1(ChaveASBACESemDigito);
            var Digito2 = CalcularDigito2(ChaveASBACESemDigito, Digito1);

            return string.Format("{0}{1}", Digito1, Digito2);
        }

        /// <summary>
        /// Gerar registro header do arquivo CNAB400.
        /// </summary>
        /// <param name="NumeroRemessa">Numero da remessa.</param>
        /// <param name="ARemessa">A remessa.</param>
        public override void GerarRegistroHeader400(int NumeroRemessa, List<string> ARemessa)
        {
            aTotal = 0;
            var cd = Banco.Parent.Cedente.CodigoCedente.OnlyNumbers();
            var wLinha = new StringBuilder();
            wLinha.Append('0');                                                     // ID do Registro
            wLinha.Append('1');                                                     // ID do Arquivo( 1 - Remessa)
            wLinha.Append("REMESSA");                                               // Literal de Remessa
            wLinha.Append("".PadRight(17));                                         // Brancos
            wLinha.Append(Banco.Parent.Cedente.Agencia.Trim().PadRight(4, '0'));
            wLinha.Append(cd.PadRight(9, '0'));                                     // Código Agencia + Cedente AAAACCCCCCCCC
            wLinha.Append("".PadRight(7));                                          // Brancos
            wLinha.Append(Banco.Parent.Cedente.Nome.PadRight(30));                  // Nome da empresa Cedente
            wLinha.Append("041BANRISUL".PadLeft(11));                               // Código e Nome do Banco Constante(041Banrisul)
            wLinha.Append("".PadRight(7));                                          // Brancos
            wLinha.AppendFormat("{0:ddmmyy}", DateTime.Now);                        // Data de gravação do arquivo
            wLinha.Append("".PadRight(9));                                          // Brancos
            wLinha.Append("".PadRight(4));                                          // Código do serviço - Somente para carteiras R, S e X
            wLinha.Append(' ');                                                     // Brancos
            wLinha.Append("".PadRight(1));                                          // Tipo de processamento - Somente para carteiras R, S e X
            wLinha.Append(' ');                                                     // Brancos
            wLinha.Append("".PadRight(10));                                         // Código do cliente no Office Banking - Somente para carteiras R, S e X
            wLinha.Append("".PadRight(268));                                        // Brancos
            wLinha.AppendFormat("{0:000000}", 1);                                   // Constante (000001)

            ARemessa.Add(wLinha.ToString().ToUpper());
        }        

        /// <summary>
        /// Gerars the registro transacao400.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <param name="ARemessa">A remessa.</param>
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public override void GerarRegistroTransacao400(Titulo Titulo, List<string> ARemessa)
        {
            //Pegando Código da Ocorrencia
            string Ocorrencia;
            switch (Titulo.OcorrenciaOriginal.Tipo)
            {
                case TipoOcorrencia.RemessaBaixar: Ocorrencia = "02"; break; //Pedido de Baixa
                case TipoOcorrencia.RemessaConcederAbatimento: Ocorrencia = "04"; break;//Concessão de Abatimento
                case TipoOcorrencia.RemessaCancelarAbatimento: Ocorrencia = "05"; break;//Cancelamento de Abatimento concedido
                case TipoOcorrencia.RemessaAlterarVencimento: Ocorrencia = "06"; break;//Alteração de vencimento
                case TipoOcorrencia.RemessaProtestar: Ocorrencia = "09"; break;//Pedido de protesto
                case TipoOcorrencia.RemessaSustarProtesto: Ocorrencia = "10"; break;//Sustação de protesto
                default: Ocorrencia = "01"; break;
            }

            //Pegando o tipo de boleto
            string TipoBoleto;
            switch (Titulo.Parent.Cedente.ResponEmissao)
            {
                case ResponEmissao.BancoReemite: TipoBoleto = "04"; break; //Cobrança Direta
                default: TipoBoleto = "08"; break; //Cobrança credenciada Banrisul
            }

            //Pegando o Aceite do Titulo }
            string TipoAceite = string.Empty;
            switch (Titulo.Aceite)
            {
                case AceiteTitulo.Sim: TipoAceite = "A"; break;
                case AceiteTitulo.Nao: TipoAceite = "N"; break;
            }

            //Pegando Tipo de Sacado
            string TipoSacado;
            switch (Titulo.Sacado.Pessoa)
            {
                case Pessoa.Fisica:
                    TipoSacado = "01";
                    break;

                case Pessoa.Juridica:
                    TipoSacado = "02";
                    break;

                default:
                    TipoSacado = "99";
                    break;
            }

            //Pegando Tipo de Cobrança - Tipo de Carteira
            string TipoCobranca;
            switch (Titulo.Parent.Cedente.CaracTitulo)
            {
                case CaracTitulo.Vendor:
                    TipoCobranca = "F";
                    break;

                case CaracTitulo.Vinculada:
                    TipoCobranca = "C";
                    break;

                default:
                    TipoCobranca = "1";
                    break;
            }

            if (string.IsNullOrEmpty(Titulo.CodigoMora))
                Titulo.CodigoMora = "0";      //0-Valor Diario, 1-Taxa Mensal

            //Instruções
            //Se tiver protesto
            if (Titulo.DataProtesto.HasValue && Titulo.DataProtesto.Value > Titulo.Vencimento)
            {
                if (string.IsNullOrEmpty(Titulo.Instrucao1.Trim()))
                    Titulo.Instrucao1 = "09"; //Protestar caso não pago em NN dias após vencimento.
            }
            else
                Titulo.Instrucao3 = "23"; //Não Protestar

            if(Titulo.PercentualMulta > 0)
                if (string.IsNullOrEmpty(Titulo.Instrucao2.Trim()))
                    Titulo.Instrucao2 = "18"; //Apos NN dias vencimento com percentual multa

            var cd = Titulo.Parent.Cedente.CodigoCedente.OnlyNumbers();
            var wLinha = new StringBuilder();
            wLinha.Append('1');                                                                      // ID Registro(1-Constante)
            wLinha.Append("".PadRight(16));                                                          // Brancos
            wLinha.Append((Titulo.Parent.Cedente.Agencia.Substring(0, 4) + cd).PadRight(13, '0'));   // Codigo da Agencia e Cedente AAAACCCCCCCCC
            wLinha.Append("".PadRight(7));                                                           // Brancos
            wLinha.Append("".PadRight(25));                                                          // Identificação do título para o cedente (usado no arquivo de retorno)
            wLinha.Append(Titulo.NossoNumero.PadLeft(8, '0'));
            wLinha.Append(CalculaDigitosChaveASBACE(Titulo.NossoNumero));                            // Nosso Número
            wLinha.Append("".PadRight(32));                                                          // Mensagem no bloqueto
            wLinha.Append("".PadRight(3));                                                           // Brancos
            wLinha.Append(TipoCobranca);                                                             // Tipo de Carteira (Simples, Vinculada, Descontada, Vendor)
            wLinha.Append(Ocorrencia);                                                               // Código de ocorrência
            wLinha.Append(Titulo.NumeroDocumento.PadLeft(10));                                       // Seu Número
            wLinha.AppendFormat("{0:ddmmyy}", Titulo.Vencimento);                                    // Data de vencimento do título
            wLinha.Append(Titulo.ValorDocumento.ToRemessaString());                                  // Valor do título
            wLinha.Append("041");                                                                    // Constante (041)
            wLinha.Append("".PadRight(5));                                                           // Brancos
            wLinha.Append(TipoBoleto);                                                               // Tipo de Documento (04-Cobrança Direta, 06-Cobrança Escritural, 08-Cobrança credenciada Banrisul, 09-Títulos de terceiros)
            wLinha.Append(TipoAceite);                                                               // Código de aceite (A, N)
            wLinha.AppendFormat("{0:ddmmyy}", Titulo.DataDocumento);                                 // Data de Emissão do título
            wLinha.Append(Titulo.Instrucao1.Trim().PadRight(2));                                     // 1ª Instrução
            wLinha.Append(Titulo.Instrucao2.Trim().PadRight(2));                                     // 2ª Instrução
            wLinha.Append(Titulo.CodigoMora.Trim().PadRight(1));                                     // Código de mora (0=Valor diário; 1=Taxa Mensal)
            wLinha.Append(Titulo.ValorMoraJuros.ToRemessaString(12));                                // Valor ao dia ou Taxa Mensal de juros
            
            wLinha.Append(Titulo.DataDesconto.HasValue ?
                string.Format("{0:ddmmyy}", Titulo.DataDesconto) : "000000");                       // Data para concessão de desconto

            wLinha.Append(Titulo.ValorDesconto.ToRemessaString());                                  // Valor do desconto a ser concedido
            wLinha.Append(Titulo.ValorIOF.ToRemessaString());                                       // Valor IOF (para carteira "X" é: taxa juros + IOF + zeros)
            wLinha.Append(Titulo.ValorAbatimento.ToRemessaString());                                // Valor do abatimento
            wLinha.Append(TipoSacado);                                                              // Tipo do Sacado (01-CPF, 02-CNPJ, 03-Outros)
            wLinha.Append(Titulo.Sacado.CNPJCPF.OnlyNumbers().PadRight(14, '0'));                   // Número da inscrição do Sacado (CPF, CNPJ)
            wLinha.Append(Titulo.Sacado.NomeSacado.PadLeft(35));                                    // Nome do Sacado
            wLinha.Append("".PadRight(5));                                                          // Brancos
            wLinha.Append((Titulo.Sacado.Logradouro+' '+
                    Titulo.Sacado.Numero+' '+
                    Titulo.Sacado.Complemento).PadLeft(40));                                        // Endereço Sacado
            wLinha.Append("".PadRight(7));                                                          // Brancos
            wLinha.Append(Math.Round(Titulo.PercentualMulta * 10).ToString().ZeroFill(3));          // Taxa de multa após o Vencimento -- estava '000' é apenas uma casa decimal
            wLinha.Append("00");                                                                    // Nº dias para multa após o vencimento (00 considera-se Após Vencimento)
            wLinha.Append(Titulo.Sacado.CEP.OnlyNumbers().PadLeft(8, '0'));                         // CEP
            wLinha.Append(Titulo.Sacado.Cidade.PadLeft(15));                                        // Cidade do Sacado
            wLinha.Append(Titulo.Sacado.UF.PadLeft(2));                                             // UF do Sacado
            wLinha.Append("0000");                                                                  // Taxa ao dia para pagamento antecipado
            wLinha.Append("".PadRight(1));                                                          // Brancos
            wLinha.Append("0000000000000");                                                         // Valor para cálculo de desconto
            wLinha.Append(Titulo.DataProtesto.HasValue && Titulo.DataProtesto > Titulo.Vencimento ?
                      (Titulo.DataProtesto.Value - Titulo.Vencimento).Days.ToString().PadRight(2, '0')
                      : "00");                                                                      // Dias para protesto/devolução automática
             wLinha.Append("".PadRight(23));                                                        // Brancos
             wLinha.AppendFormat("{0:000000}", ARemessa.Count + 1);  

            aTotal += Titulo.ValorDocumento;
            ARemessa.Add(wLinha.ToString().ToUpper()); 
        }

        /// <summary>
        /// Gerar registro trailler CNAB400.
        /// </summary>
        /// <param name="ARemessa">A remessa.</param>
        public override void GerarRegistroTrailler400(List<string> ARemessa)
        {
            var wLinha = new StringBuilder();
            wLinha.Append('9');                                   // Constante (9)
            wLinha.Append("".PadRight(26));                       // Brancos
            wLinha.Append(aTotal.ToRemessaString());              // Total Somatório dos valores dos títulos
            wLinha.Append("".PadRight(354));                      // Brancos
            wLinha.AppendFormat("{0:000000}", ARemessa.Count + 1);  // Número sequencial do Registro

            ARemessa.Add(wLinha.ToString().ToUpper());
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
        /// Gerars the registro transacao240.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public override string GerarRegistroTransacao240(Titulo Titulo)
        {
            throw new NotImplementedException("Esta função não esta implementada para este banco");
        }        

        /// <summary>
        /// Gerars the registro trailler240.
        /// </summary>
        /// <param name="ARemessa">A remessa.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException">Esta função não esta implementada para este banco</exception>
        public override string GerarRegistroTrailler240(List<string> ARemessa)
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

        #endregion Methods
    }
}
