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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using ACBr.Net.Boleto.Bancos;
using ACBr.Net.Boleto.Enums;
using ACBr.Net.Boleto.Interfaces;
using ACBr.Net.Boleto.Printer;
using ACBr.Net.Boleto.Utils;
using ACBr.Net.Core;
using ACBr.Net.Core.Exceptions;
using ACBr.Net.Core.Extensions;

#region COM Interop Attributes

#if COM_INTEROP
using System.Runtime.InteropServices;
#endif

#endregion COM Interop Attributes

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
    // ReSharper disable once InconsistentNaming
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

	            var @base = value as BoletoPrinterBase;
	            if (@base == null)
					return;

	            if (boletofc != null)
		            boletofc.Dispose();

	            boletofc = @base;
	            boletofc.Boleto = this;
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
			Guard.Against<ACBrException>(BoletoPrinter == null, "Nenhum componente \"IBoletoFCClass\" associado");
			Guard.Against<ACBrException>(Banco.Numero == 0, "Banco não definido, impossivel listar boleto");

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
			Guard.Against<ACBrException>(BoletoPrinter == null, "Nenhum componente \"IBoletoFCClass\" associado");
			Guard.Against<ACBrException>(Banco.Numero == 0, "Banco não definido, impossivel listar boleto");

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
            Guard.Against<ACBrException>(BoletoPrinter == null, "Nenhum componente \"IBoletoFCClass\" associado");
            Guard.Against<ACBrException>(Banco.Numero == 0, "Banco não definido, impossivel listar boleto");

            ChecarDadosObrigatorios();
            BoletoPrinter.GerarHTML();
        }

        /// <summary>
        /// Enviars the email.
        /// </summary>
        /// <param name="smtpHost">The SMTP host.</param>
        /// <param name="smtpPort">The SMTP port.</param>
        /// <param name="smtpUser">The SMTP user.</param>
        /// <param name="smtpPasswd">The SMTP passwd.</param>
        /// <param name="from">From.</param>
        /// <param name="sTo">The s to.</param>
        /// <param name="assunto">The assunto.</param>
        /// <param name="mensagem">The mensagem.</param>
        /// <param name="ssl">if set to <c>true</c> [SSL].</param>
        /// <param name="enviaPdf">if set to <c>true</c> [envia PDF].</param>
        /// <param name="CC">The cc.</param>
        /// <param name="anexos">The anexos.</param>
        /// <param name="pedeConfirma">if set to <c>true</c> [pede confirma].</param>
        /// <param name="aguardarEnvio">if set to <c>true</c> [aguardar envio].</param>
        /// <param name="nomeRemetente">The nome remetente.</param>
        /// <param name="tls">if set to <c>true</c> [TLS].</param>
        public void EnviarEmail(string smtpHost, int smtpPort, string smtpUser, string smtpPasswd, string @from, string sTo,
                                string assunto, string[] mensagem, bool ssl, bool enviaPdf = true, string[] CC = null,
                                string[] anexos = null, bool pedeConfirma = false,
                                bool aguardarEnvio = false, string nomeRemetente = "", bool tls = true)
        {
            try
            {
                if (string.IsNullOrEmpty(@from) || string.IsNullOrEmpty(sTo) ||
                    string.IsNullOrEmpty(smtpHost) || string.IsNullOrEmpty(smtpUser) ||
                    string.IsNullOrEmpty(smtpPasswd) || string.IsNullOrEmpty(assunto))
                    return;

                if (smtpPort <= 0)
                    smtpPort = ssl ? 465 : 25;

                using (var smtpClient = new SmtpClient(smtpHost, smtpPort))
                {
                    using (var message = new MailMessage())
                    {
                        smtpClient.Credentials = new NetworkCredential(smtpUser, smtpPasswd);                        
                        if (tls)
                        {
                            smtpClient.EnableSsl = true;
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                        }
                        else
                            smtpClient.EnableSsl = ssl;

                        if (CC != null && CC.Length > 0)
                        {
                            foreach (var cc in CC)
                                message.CC.Add(cc);
                        }

                        message.Priority = MailPriority.High;
                        if (pedeConfirma)
                        {
                            message.Headers.Add("Disposition-Notification-To", string.Format("<{0}>", @from));
                            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                        }

                        message.To.Add(sTo);
                        message.ReplyToList.Add(@from);
                        message.From = !string.IsNullOrEmpty(nomeRemetente) ? 
                            new MailAddress(@from, nomeRemetente) : new MailAddress(@from);

                        if (anexos != null && anexos.Length > 0)
                        {
                            foreach (var anexo in anexos)
                            {
                                if (File.Exists(anexo))
                                    continue;

                                var file = File.Open(anexo, FileMode.Open);
                                var fileName = Path.GetFileName(anexo);
                                message.Attachments.Add(new Attachment(file, fileName));
                            }
                        }

                        if (enviaPdf)
                        {
							if (BoletoPrinter.NomeArquivo.IsEmpty())
                                BoletoPrinter.NomeArquivo = "boleto.pdf";

                            GerarPDF();
                        }
                        else
                        {
                            if (BoletoPrinter.NomeArquivo.IsEmpty())
                                BoletoPrinter.NomeArquivo = "boleto.html";

                            GerarHTML();
                        }

                        var boleto = File.Open(BoletoPrinter.NomeArquivo, FileMode.Open);
                        var boletoName = Path.GetFileName(BoletoPrinter.NomeArquivo);
                        message.Attachments.Add(new Attachment(boleto, boletoName));

                        if (!string.IsNullOrEmpty(assunto))
                        {
                            message.Subject = assunto;
                        }

                        message.Body = mensagem.AsString();
                        if (aguardarEnvio)
                            smtpClient.Send(message);
                        else
                            smtpClient.SendAsync(message, null);
                    }
                }
            }
            finally
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            }
        }

        /// <summary>
        /// Adicionar menssagens padrão ao titulo.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <param name="stringList">The string list.</param>
        public void AdicionarMensagensPadroes(Titulo titulo, List<string> stringList)
        {
            if (!ImprimirMensagemPadrao)
                return;
						
            if (titulo.DataProtesto.HasValue)
            {
                if (titulo.TipoDiasProtesto == TipoDiasIntrucao.Corridos)
                    stringList.Add(string.Format("Protestar em {0} dias corridos após o vencimento",
                        titulo.DataProtesto.Value.Date.Subtract(titulo.Vencimento.Date).Days));
                else
                    stringList.Add(string.Format("Protestar no {0} dia útil após o vencimento",
                        titulo.DataProtesto.Value.Date.Subtract(titulo.Vencimento.Date).Days));
            }

            if (titulo.ValorAbatimento > 0)
            {
                if (titulo.DataAbatimento > DateTime.Now)
                    stringList.Add(string.Format("Conceder abatimento de {0:c} para pagamento ate {1:dd/MM/yyy}", 
                        titulo.ValorAbatimento, titulo.DataAbatimento));
                else
                    stringList.Add(string.Format("Conceder abatimento de {0:c} para pagamento ate {1:dd/MM/yyy}", 
                        titulo.ValorAbatimento, titulo.Vencimento));
            }

            if (titulo.ValorDesconto > 0)
            {
                if (titulo.DataDesconto > DateTime.Now)
                    stringList.Add(string.Format("Conceder desconto de {0:c} para pagamento até {1:dd/MM/yyyy}", 
                        titulo.ValorDesconto, titulo.DataDesconto));
                else
                    stringList.Add(string.Format("Conceder desconto de {0:c} por dia de antecipaçao", titulo.ValorDesconto));
            }

            if (titulo.ValorMoraJuros > 0)
            {
                if (titulo.DataMoraJuros > DateTime.Now)
                    stringList.Add(string.Format("Cobrar juros de {0:c} por dia de atraso para pagamento a partir de {1:dd/MM/yyyy}", 
                        titulo.ValorMoraJuros, titulo.Vencimento == titulo.DataMoraJuros ? titulo.Vencimento.AddDays(1) : titulo.DataMoraJuros));
                else
                    stringList.Add(string.Format("Cobrar juros de {0:c} por dia de atraso", titulo.ValorMoraJuros));
            }

            if (titulo.PercentualMulta > 0)
                stringList.Add(string.Format("Cobrar Multa de {0:c}  após o vencimento.", 
                    (titulo.ValorDocumento * (1 + titulo.PercentualMulta / 100) - titulo.ValorDocumento)));
        }

        /// <summary>
        /// Gera o arquivo de remessa.
        /// </summary>
        /// <param name="numeroRemessa">The numero remessa.</param>
        /// <returns>Retorna o local onde foi salvo o arquivo de remessa</returns>
        /// <exception cref="ACBrException">Lista de boletos está vazia</exception>
        public string GerarRemessa(int numeroRemessa)
        {
            Guard.Against<ACBrException>(ListadeBoletos.Count < 1, "Lista de boletos está vazia");

            ChecarDadosObrigatorios();

            if(!Directory.Exists(DirArqRemessa))
                Directory.CreateDirectory(DirArqRemessa);

            string nomeArq;
            if (string.IsNullOrEmpty(NomeArqRemessa))
            {
                nomeArq = Banco.CalcularNomeArquivoRemessa();
                NomeArqRemessa = Path.GetFileName(nomeArq);
            }
            else
                nomeArq = string.Format(@"{0}\{1}", DirArqRemessa, NomeArqRemessa);

            var remessa = new List<string>();
			switch (LayoutRemessa)
			{
				case LayoutRemessa.DBT627:
					remessa.Add(Banco.GerarRegistroHeaderDBT627(numeroRemessa));
					remessa.AddRange(ListadeBoletos.Select(titulo => Banco.GerarRegistroTransacaoDBT627(titulo)));
					remessa.Add(Banco.GerarRegistroTraillerDBT627(remessa));
					break;

				case LayoutRemessa.CNAB400:
					Banco.GerarRegistroHeader400(numeroRemessa, remessa);
					foreach (var titulo in ListadeBoletos)
						Banco.GerarRegistroTransacao400(titulo, remessa);
					Banco.GerarRegistroTrailler400(remessa);
					break;

				default:
					remessa.AddText(Banco.GerarRegistroHeader240(numeroRemessa));
					foreach (var titulo in ListadeBoletos)
						remessa.AddText(Banco.GerarRegistroTransacao240(titulo));
					remessa.AddText(Banco.GerarRegistroTrailler240(remessa));
					break;
			}

            File.WriteAllLines(nomeArq, remessa);
            return nomeArq;
        }

        /// <summary>
        /// Lers the retorno.
        /// </summary>
        /// <exception cref="ACBrException">
        /// NomeArqRetorno deve ser informado.
        /// or
        /// or
        /// or
        /// or
        /// or
        /// </exception>
        public void LerRetorno()
        {
            Guard.Against<ACBrException>(string.IsNullOrEmpty(NomeArqRetorno), 
				"NomeArqRetorno deve ser informado.");
            
            var nomeArq = string.Format(@"{0}\{1}", DirArqRetorno, NomeArqRetorno);
            
            Guard.Against<ACBrException>(!File.Exists(nomeArq),
				"Arquivo não encontrado:{0}{1}", Environment.NewLine, nomeArq);

            var slRetorno = File.ReadAllLines(nomeArq).ToList();

            Guard.Against<ACBrException>(slRetorno.Count < 1,
			"O Arquivo de Retorno:{0}{1}{0}está vazio.{0}Não há dados para processar", Environment.NewLine, nomeArq);
            
            switch(slRetorno[0].Length)
            {
                case 240:                    
                    Guard.Against<ACBrException>(!slRetorno[0].ExtrairDaPosicao(143, 143).Equals("2"),
                        "{1}{0}Não é um arquivo de Retorno de cobrança com layout CNAB240", Environment.NewLine, nomeArq);
                   LayoutRemessa = LayoutRemessa.CNAB240;
                   break;
                    
                case 400:
                   Guard.Against<ACBrException>(!slRetorno[0].ExtrairDaPosicao(1, 9).Equals("02RETORNO"),
                        "{1}{0}Não é um arquivo de Retorno de cobrança com layout CNAB400", Environment.NewLine, nomeArq);
                   LayoutRemessa = LayoutRemessa.CNAB400;
                   break;

				case 150:
				   Guard.Against<ACBrException>(!slRetorno[0].ExtrairDaPosicao(1, 2).Equals("A2"),
					   "{1}{0}Não é um arquivo de Retorno de cobrança com layout DBT627", Environment.NewLine, nomeArq);
				   LayoutRemessa = LayoutRemessa.DBT627;
				   break;

                default:
				   throw new ACBrException(string.Format("{1}{0}Não é um arquivo de Retorno de cobrança CNAB240, CNAB400 ou DBT627",
                       Environment.NewLine, nomeArq));
            }

			switch (LayoutRemessa)
			{
				case LayoutRemessa.DBT627:
					Banco.LerRetornoDBT627(slRetorno);
					break;

				case LayoutRemessa.CNAB240:
					Banco.LerRetorno240(slRetorno);
					break;

				default:
					Banco.LerRetorno400(slRetorno);
					break;
			}
        }

        /// <summary>
        /// Checars the dados obrigatorios.
        /// </summary>
        /// <exception cref="ACBrException">Informações do Cedente incompletas</exception>
        private void ChecarDadosObrigatorios()
        {
            Guard.Against<ACBrException>(Cedente.Nome.IsEmpty() || Cedente.Conta.IsEmpty() || 
               (Cedente.ContaDigito.IsEmpty() && Banco.TipoCobranca != TipoCobranca.Banestes) ||
               Cedente.Agencia.IsEmpty() || (Cedente.AgenciaDigito.IsEmpty() && Banco.TipoCobranca != TipoCobranca.Banestes),
                "Informações do Cedente incompletas");
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