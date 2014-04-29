// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 03-27-2014
//
// Last Modified By : RFTD
// Last Modified On : 04-24-2014
// ***********************************************************************
// <copyright file="ACBrBoleto.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Drawing;
using System.Net.Mail;
using System.ComponentModel;
using System.Collections.Generic;
#region COM Interop Attributes

#if COM_INTEROP
using System.Runtime.InteropServices;
#endif

#endregion COM Interop Attributes
using ACBr.Net.Core;
using ACBr.Net.Boleto.Interfaces;

/// <summary>
/// ACBr.Net.Boleto namespace.
/// </summary>
namespace ACBr.Net.Boleto
{
    #region COM Interop

    /* NOTAS para COM INTEROP
	 * Há um modo de compilação com a diretiva COM_INTEROP que inseri atributos e código específico
	 * para a DLL ser exportada para COM (ActiveX)
	 *
	 * O modelo COM possui alguma limitações/diferenças em relação ao modelo .NET
	 * Inserir os #if COM_INTEROP para prover implementações distintas nas modificações necessárias para COM:
	 *
	 * - Inserir atributos ComVisible(true), Guid("xxx") e ClassInterface(ClassInterfaceType.AutoDual) em todas as classes envolvidas
	 *
	 * - Propriedades/métodos que usam "Decimal" devem incluir o atributo MarshalAs(UnmanagedType.Currency)
	 *   usar [return: ...] para retornos de métodos e propriedades ou [param: ...] para o set de propriedades
	 *
	 * - Métodos que recebem array como parâmetros devem fazer como "ref".
	 *   Propriedades só podem retornar arrays, nunca receber.
	 *
	 * - Overload não é permitido. Métodos com mesmos nomes devem ser renomeados.
	 *   É possível usar parâmetros default, simplificando a necessidade de Overload
	 *
	 * - Generic não deve ser usado. Todas as classes Generic devem ser re-escritas como classes específicas
	 *
	 * - Eventos precisam de uma Interface com as declarações dos métodos (eventos) com o atributo [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	 *   A classe que declara os eventos precisa do atributo [ComSourceInterfaces(typeof(INomeDaInterface))]
	 *   Nenhum delegate deverá ser Generic, precisam ser re-escritos.
	 *
	 *   OBS: Por padrão o modelo .Net recebe os eventos com a assinatura void(object sender, EventArgs e)
	 *   O modelo COM não precisa desses parâmetros. Assim o delegate EventHandler foi redefinido para uma assinatura void()
	 *   Outros EventArgs devem seguir a assitarua COM void(MyEventArg e) ao invés da assinatura .NET void(object sender, MyEventArgs e)
	 * */

#if COM_INTEROP

    #region IDispatch Interface

    #region Documentation

	/// <summary>
	/// Interface contendo os eventos publicados pelo componente COM
	/// </summary>

    #endregion Documentation

	[ComVisible(true)]
	[Guid("71E3E2D3-FCC2-486D-9BC0-42FC7F33F3D5")]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IACBrBoletoEvents
	{
		
    }

    #endregion IDispatch Interface

    #region Delegates

    #region Comments

	///os componentes COM não suportam Generics
	///Estas são implementações específicas de delegates que no .Net são representados como EventHandler<T>

    #endregion Comments	

    #endregion Delegates

#endif

    #endregion COM Interop

    #region COM Interop Attributes

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("B60FD2D3-8915-45CF-9C7F-9C9341C9B740")]
	[ComSourceInterfaces(typeof(IACBrBoletoEvents))]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes

    /// <summary>
    /// Class ACBrBoleto. This class cannot be inherited.
    /// </summary>
    [ToolboxBitmap(typeof(ACBrBoleto), @"ACBr.Net.Boleto.ico.bmp")]
    public sealed class ACBrBoleto : ACBrComponent
    {
        #region Field

        /// <summary>
        /// The boletofc
        /// </summary>
        private BoletoPrinterBase boletofc;

        #endregion Field

        #region Evento
        #endregion Evento

        #region Propriedades

        /// <summary>
        /// Dados do banco para emissão do boleto
        /// </summary>
        /// <value>The banco.</value>
        [Category("Dados"), Description("Dados do banco para emissão do boleto"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Banco Banco { get; private set; }

        /// <summary>
        /// Dados do cedente do boleto
        /// </summary>
        /// <value>The cedente.</value>
        [Category("Dados"), Description("Dados do cedente do boleto"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Cedente Cedente { get; private set; }

        /// <summary>
        /// Nome do arquivo de remessa
        /// </summary>
        /// <value>The nome arq remessa.</value>
        [DefaultValue("")]
        [Category("Remessa\\Retorno"), Description("Nome do arquivo de remessa")]
        public string NomeArqRemessa { get; set; }

        /// <summary>
        /// Diretorio do arquivo de remessa
        /// </summary>
        /// <value>The dir arq remessa.</value>
        [DefaultValue("")]
        [Category("Remessa\\Retorno"), Description("Diretorio do arquivo de remessa")]
        public string DirArqRemessa { get; set; }

        /// <summary>
        /// Nome do arquivo de retorno
        /// </summary>
        /// <value>The nome arq retorno.</value>
        [DefaultValue("")]
        [Category("Remessa\\Retorno"), Description("Nome do arquivo de retorno")]
        public string NomeArqRetorno { get; set; }

        /// <summary>
        /// Diretorio do arquivo de retorno"
        /// </summary>
        /// <value>The dir arq retorno.</value>
        [DefaultValue("")]
        [Category("Remessa\\Retorno"), Description("Diretorio do arquivo de retorno")]
        public string DirArqRetorno { get; set; }

        /// <summary>
        /// Numero do arquivo de retorno
        /// </summary>
        /// <value>The numero arquivo.</value>
        [DefaultValue(0)]
        [Category("Remessa\\Retorno"), Description("Numero do arquivo de retorno")]
        public int NumeroArquivo { get; set; }

        /// <summary>
        /// Data do arquivo de retorno//remessa
        /// </summary>
        /// <value>The data arquivo.</value>
        [Category("Remessa\\Retorno"), Description("Data do arquivo de retorno//remessa")]
        public DateTime DataArquivo { get; set; }

        /// <summary>
        /// Data de lançamento do arquivo de retorno//remessa
        /// </summary>
        /// <value>The data credito lanc.</value>
        [Category("Remessa\\Retorno"), Description("Data de lançamento do arquivo de retorno//remessa")]
        public DateTime DataCreditoLanc { get; set; }

        /// <summary>
        /// Ler os dados do cedente do arquivo de retorno
        /// </summary>
        /// <value><c>true</c> if [le cedente retorno]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [Category("Remessa\\Retorno"), Description("Ler os dados do cedente do arquivo de retorno")]
        public bool LeCedenteRetorno { get; set; }

        /// <summary>
        /// Layout da remessa para envio
        /// </summary>
        /// <value>The layout remessa.</value>
        [DefaultValue(LayoutRemessa.CNAB400)]
        [Category("Remessa\\Retorno"), Description("Layout da remessa para envio")]
        public LayoutRemessa LayoutRemessa { get; set; }

        /// <summary>
        /// Inserir mensagem padrão na hora de imprimir o boleto
        /// </summary>
        /// <value><c>true</c> if [imprimir mensagem padrao]; otherwise, <c>false</c>.</value>
        [Category("Impressão"), Description("Inserir mensagem padrão na hora de imprimir o boleto")]  
        public bool ImprimirMensagemPadrao { get; set; }

        /// <summary>
        /// Componente para impressão dos boletos
        /// </summary>
        /// <value>The boleto fc.</value>
        [Category("Impressão"), Description("Componente para impressão dos boletos")]        
        public IBoletoPrinter BoletoPrinter
        { 
            get
            {
                return boletofc;
            }
            set
            {
                if (boletofc != null && boletofc == value)
                    return;

                if (value is BoletoPrinterBase)
                {
                    if (boletofc != null)
                        boletofc.Dispose();

                    boletofc = (BoletoPrinterBase)value;
                    if (value != null)
                        boletofc.Boleto = this;
                }
            }
        }

        /// <summary>
        /// Lista de Boletos
        /// </summary>
        /// <value>The listade boletos.</value>
        [Browsable(false)]        
        public TituloCollection ListadeBoletos { get; private set; }

        #endregion Propriedades

        #region Funções

        /// <summary>
        /// Adiciona um novo titulo na lista de boletos.
        /// </summary>
        /// <returns>Retona o novo titulo adicionado na listadeBoletos</returns>
        public Titulo CriarTituloNaLista()
        {
            return ListadeBoletos.AddNew();
        }

        /// <summary>
        /// Imprimi os boletos.
        /// </summary>
        /// <exception cref="System.Exception">Nenhum componente \IBoletoFCClass\ associado
        /// or
        /// Banco não definido, impossivel listar boleto</exception>
        public void Imprimir()
        {
            if(BoletoPrinter == null)
                throw new Exception("Nenhum componente \"IBoletoFCClass\" associado") ;
            
            if(Banco.Numero == 0)
                throw new Exception("Banco não definido, impossivel listar boleto");

            ChecarDadosObrigatorios();
            BoletoPrinter.Imprimir();
        }

        /// <summary>
        /// Gera um arquivo PDF dos boletos.
        /// </summary>
        /// <exception cref="System.Exception">Nenhum componente \IBoletoFCClass\ associado
        /// or
        /// Banco não definido, impossivel listar boleto</exception>
        public void GerarPDF()
        {
            if (BoletoPrinter == null)
                throw new Exception("Nenhum componente \"IBoletoFCClass\" associado");

            if (Banco.Numero == 0)
                throw new Exception("Banco não definido, impossivel listar boleto");

            ChecarDadosObrigatorios();
            BoletoPrinter.GerarPDF();
        }

        /// <summary>
        /// Gera um arquivo HTML dos boletos.
        /// </summary>
        /// <exception cref="System.Exception">Nenhum componente \IBoletoFCClass\ associado
        /// or
        /// Banco não definido, impossivel listar boleto</exception>
        public void GerarHTML()
        {
            if (BoletoPrinter == null)
                throw new Exception("Nenhum componente \"IBoletoFCClass\" associado");

            if (Banco.Numero == 0)
                throw new Exception("Banco não definido, impossivel listar boleto");

            ChecarDadosObrigatorios();
            BoletoPrinter.GerarHTML();
        }

        /// <summary>
        /// Envia os boleto por email em PDF ou HTML.
        /// </summary>
        /// <param name="SmtpHost">Endereço do servidor SMTP.</param>
        /// <param name="SmtpPort">Porta do servidor SMTP.</param>
        /// <param name="SmtpUser">Usuario do servidor SMTP.</param>
        /// <param name="SmtpPasswd">Senha do servidor SMTP.</param>
        /// <param name="From">Email do remetente.</param>
        /// <param name="sTo">Email do destinatario.</param>
        /// <param name="Assunto">Assunto do email.</param>
        /// <param name="Mensagem">Mensagem do email.</param>
        /// <param name="SSL">Usar criptografia SSL na conexão ao servidor.</param>
        /// <param name="EnviaPDF">Enviar PDF.</param>
        /// <param name="CC">Endereços de email para CC.</param>
        /// <param name="Anexos">Anexos do email.</param>
        /// <param name="AguardarEnvio">Aguarda o envio dos emails.</param>
        /// <param name="NomeRemetente">Nome do remetente.</param>
        public void EnviarEmail(string SmtpHost, int SmtpPort, string SmtpUser, string SmtpPasswd, string From, string sTo,
                                string Assunto, string[] Mensagem, bool SSL, bool EnviaPDF = true, string[] CC = null,
                                string[] Anexos = null, bool AguardarEnvio = false, string NomeRemetente = "")
        {
            if (string.IsNullOrEmpty(From) || string.IsNullOrEmpty(sTo) ||
                string.IsNullOrEmpty(SmtpHost) || string.IsNullOrEmpty(SmtpUser) ||
                string.IsNullOrEmpty(SmtpPasswd) || string.IsNullOrEmpty(Assunto))
                return;
                        
            if (SmtpPort <= 0)
                SmtpPort = SSL ? 465 : 25;

            using (var smtpClient = new SmtpClient(SmtpHost, SmtpPort))
            {
                using (var message = new MailMessage())
                {
                    smtpClient.Credentials = new NetworkCredential(SmtpUser, SmtpPasswd);
                    smtpClient.EnableSsl = SSL;

                    if (CC.Length > 0)
                    {
                        foreach(var cc in CC)
                            message.CC.Add(cc);
                    }

                    message.Priority = MailPriority.High;                    

                    message.To.Add(sTo);
                    message.ReplyToList.Add(sTo);
                    message.From = !string.IsNullOrEmpty(NomeRemetente) ? new MailAddress(From, NomeRemetente) : new MailAddress(From);

                    if (Anexos.Length > 0)
                    {
                        foreach (var anexo in Anexos)
                        {
                            if (File.Exists(anexo))
                                continue;

                            var file = File.Open(anexo, FileMode.Open);
                            var fileName = Path.GetFileName(anexo);
                            message.Attachments.Add(new Attachment(file, fileName));
                        }
                    }

                    if (EnviaPDF)
                    {
                        if (string.IsNullOrEmpty(BoletoPrinter.NomeArquivo))
                            BoletoPrinter.NomeArquivo = "boleto.pdf";

                        GerarPDF();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(BoletoPrinter.NomeArquivo))
                            BoletoPrinter.NomeArquivo = "boleto.html";

                        GerarHTML();
                    }

                    var boleto = File.Open(BoletoPrinter.NomeArquivo, FileMode.Open);
                    var boletoName = Path.GetFileName(BoletoPrinter.NomeArquivo);
                    message.Attachments.Add(new Attachment(boleto, boletoName));

                    if (!string.IsNullOrEmpty(Assunto))
                    {
                        message.Subject = Assunto;
                    }

                    message.Body = Mensagem.AsString();
                    if (AguardarEnvio)
                        smtpClient.Send(message);
                    else
                        smtpClient.SendAsync(message, null);
                }
            }
        }

        /// <summary>
        /// Adicionar menssagens padrão ao titulo.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <param name="StringList">The string list.</param>
        public void AdicionarMensagensPadroes(Titulo Titulo, List<string> StringList)
        {
            if (!ImprimirMensagemPadrao)
                return;

            if (Titulo.DataProtesto.HasValue)
            {
                if (Titulo.TipoDiasProtesto == TipoDiasIntrucao.Corridos)
                    StringList.Add(string.Format("Protestar em {0} dias corridos após o vencimento", 
                        Titulo.Vencimento.Subtract(Titulo.DataProtesto.Value).TotalDays));
                else
                    StringList.Add(string.Format("Protestar no {0} dia útil após o vencimento", 
                        Titulo.Vencimento.Subtract(Titulo.DataProtesto.Value).TotalDays));
            }

            if (Titulo.ValorAbatimento > 0)
            {
                if (Titulo.DataAbatimento > DateTime.Now)
                    StringList.Add(string.Format("Conceder abatimento de {0:c} para pagamento ate {1:dd/MM/yyy}", 
                        Titulo.ValorAbatimento, Titulo.DataAbatimento));
                else
                    StringList.Add(string.Format("Conceder abatimento de {0:c} para pagamento ate {1:dd/MM/yyy}", 
                        Titulo.ValorAbatimento, Titulo.Vencimento));
            }

            if (Titulo.ValorDesconto > 0)
            {
                if (Titulo.DataDesconto > DateTime.Now)
                    StringList.Add(string.Format("Conceder desconto de {0:c} para pagamento até {1:dd/MM/yyyy}", 
                        Titulo.ValorDesconto, Titulo.DataDesconto));
                else
                    StringList.Add(string.Format("Conceder desconto de {0:c} por dia de antecipaçao", Titulo.ValorDesconto));
            }

            if (Titulo.ValorMoraJuros > 0)
            {
                if (Titulo.DataMoraJuros > DateTime.Now)
                    StringList.Add(string.Format("Cobrar juros de {0:c} por dia de atraso para pagamento a partir de {1:dd/MM/yyyy}", 
                        Titulo.ValorMoraJuros, Titulo.Vencimento == Titulo.DataMoraJuros ? Titulo.Vencimento.AddDays(1) : Titulo.DataMoraJuros));
                else
                    StringList.Add(string.Format("Cobrar juros de {0:c} por dia de atraso", Titulo.ValorMoraJuros));
            }

            if (Titulo.PercentualMulta > 0)
                StringList.Add(string.Format("Cobrar Multa de {0:c}  após o vencimento.", 
                    (Titulo.ValorDocumento * (1 + Titulo.PercentualMulta / 100) - Titulo.ValorDocumento)));
        }

        /// <summary>
        /// Gera o arquivo de remessa.
        /// </summary>
        /// <param name="NumeroRemessa">The numero remessa.</param>
        /// <returns>Retorna o local onde foi salvo o arquivo de remessa</returns>
        /// <exception cref="ACBrException">Lista de boletos está vazia</exception>
        public string GerarRemessa(int NumeroRemessa)
        {
            if (ListadeBoletos.Count < 1)
                throw new ACBrException("Lista de boletos está vazia");

            ChecarDadosObrigatorios();

            if(!Directory.Exists(DirArqRemessa))
                Directory.CreateDirectory(DirArqRemessa);

            string NomeArq;
            if (string.IsNullOrEmpty(NomeArqRemessa))
                NomeArq = Banco.CalcularNomeArquivoRemessa();
            else
                NomeArq = string.Format(@"{0}\{1}", DirArqRemessa, NomeArqRemessa);

            var Remessa = new List<string>();
            if (LayoutRemessa == LayoutRemessa.CNAB400)
            {
                Banco.GerarRegistroHeader400(NumeroRemessa, Remessa);
                foreach (var titulo in ListadeBoletos)
                    Banco.GerarRegistroTransacao400(titulo, Remessa);
                Banco.GerarRegistroTrailler400(Remessa);
            }
            else
            {
                Remessa.Add(Banco.GerarRegistroHeader240(NumeroRemessa));
                foreach (var titulo in ListadeBoletos)
                    Remessa.Add(Banco.GerarRegistroTransacao240(titulo));
                Remessa.Add(Banco.GerarRegistroTrailler240(Remessa));
            }

            File.WriteAllLines(NomeArq, Remessa);
            return NomeArq;
        }

        /// <summary>
        /// Le o arquivo de retorno e adicionar o titulos a lista.
        /// </summary>
        /// <exception cref="ACBrException">NomeArqRetorno deve ser informado.
        /// or
        /// or
        /// or
        /// or
        /// or</exception>
        public void LerRetorno()
        {
            if(string.IsNullOrEmpty(NomeArqRetorno))
                throw new ACBrException("NomeArqRetorno deve ser informado.");
            
            string NomeArq = string.Format(@"{0}\{1}", DirArqRetorno, NomeArqRetorno);
            
            if(!File.Exists(NomeArq))
                throw new ACBrException(string.Format("Arquivo não encontrado:{0}{1}", Environment.NewLine, NomeArq));

            var SlRetorno = File.ReadAllLines(NomeArq).ToList();

            if(SlRetorno.Count < 1)
                throw new ACBrException(string.Format("O Arquivo de Retorno:{0}{1}{0}está vazio.{0}Não há dados para processar",
                    Environment.NewLine, NomeArq));
            
            switch(SlRetorno[0].Length)
            {
                case 240:
                    if(!SlRetorno[0].ExtrairDaPosicao(143, 144).Equals("2"))
                        throw new ACBrException(string.Format("{1}{0}Não é um arquivo de Retorno de cobrança com layout CNAB240",
                            Environment.NewLine, NomeArq));
                   LayoutRemessa = LayoutRemessa.CNAB240;
                   break;
                    
                case 400:
                   if (!SlRetorno[0].ExtrairDaPosicao(1, 9).Equals("02RETORNO"))
                        throw new ACBrException(string.Format("{1}{0}Não é um arquivo de Retorno de cobrança com layout CNAB400",
                            Environment.NewLine, NomeArq));
                   LayoutRemessa = LayoutRemessa.CNAB400;
                   break;

                default:
                   throw new ACBrException(string.Format("{1}{0}Não é um arquivo de Retorno de cobrança CNAB240 ou CNAB400",
                       Environment.NewLine, NomeArq));
            }

            if (LayoutRemessa == LayoutRemessa.CNAB240)
                Banco.LerRetorno240(SlRetorno);
            else
                Banco.LerRetorno400(SlRetorno);
        }

        /// <summary>
        /// Checars the dados obrigatorios.
        /// </summary>
        /// <exception cref="ACBrException">Informações do Cedente incompletas</exception>
        private void ChecarDadosObrigatorios()
        {
            if (string.IsNullOrEmpty(Cedente.Nome) || string.IsNullOrEmpty(Cedente.Conta) || 
               (string.IsNullOrEmpty(Cedente.ContaDigito) && Banco.TipoCobranca != TipoCobranca.Banestes) ||
               string.IsNullOrEmpty(Cedente.Agencia) || (string.IsNullOrEmpty(Cedente.AgenciaDigito) && Banco.TipoCobranca != TipoCobranca.Banestes))
                throw new ACBrException("Informações do Cedente incompletas");
        }

        #endregion Funções

        #region Override Methods

        /// <summary>
        /// Called when [initialize].
        /// </summary>
        protected override void OnInitialize()
        {
            Cedente = new Cedente(this);
            Banco = new Banco(this);            
            ListadeBoletos = new TituloCollection(this);
            DataArquivo = DateTime.Now;
            DataCreditoLanc = DateTime.Now;
            LeCedenteRetorno = false;
            NumeroArquivo = 0;            
            LayoutRemessa = LayoutRemessa.CNAB400;
            DirArqRemessa = string.Empty;
            DirArqRetorno = string.Empty;
            NomeArqRemessa = string.Empty;
            NomeArqRetorno = string.Empty;
        }

        /// <summary>
        /// Called when [disposing].
        /// </summary>
        protected override void OnDisposing()
        {
            ListadeBoletos = null;
            Banco = null;
            Cedente = null;
            if (boletofc != null)
                boletofc.Dispose();
        }

        #endregion Override Methods        
    }
}