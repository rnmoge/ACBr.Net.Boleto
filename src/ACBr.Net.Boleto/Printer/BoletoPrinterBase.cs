// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 04-18-2014
//
// Last Modified By : RFTD
// Last Modified On : 04-24-2014
// ***********************************************************************
// <copyright file="BoletoFCBase.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using ACBr.Net.Boleto.Enums;
using ACBr.Net.Boleto.EventArgs;
using ACBr.Net.Boleto.Interfaces;
using ACBr.Net.Core;
using ACBr.Net.Core.Exceptions;
using ACBr.Net.Core.Extensions;

#region COM Interop Attributes

#if COM_INTEROP
using System.Runtime.InteropServices;
#endif

#endregion COM Interop Attributes

namespace ACBr.Net.Boleto.Printer
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
	[Guid("3B1C794C-5FAB-484D-90DB-9726D586E402")]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IACBrBoletoFCEvents
	{
		[DispId(1)]
		void OnObterLogo(OnObterLogoEventArgs e);
    }

    #endregion IDispatch Interface

    #region Delegates

    #region Comments

	///os componentes COM não suportam Generics
	///Estas são implementações específicas de delegates que no .Net são representados como EventHandler<T>

    #endregion Comments	

    public delegate void OnObterLogoEventHandler(OnObterLogoEventArgs e);

    #endregion Delegates

#endif

    #endregion COM Interop

    #region COM Interop Attributes

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("CD99F0CD-1BCA-459A-96DF-3ED1F975834E")]
	[ComSourceInterfaces(typeof(IACBrBoletoFCEvents))]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes
    /// <summary>
    /// Class BoletoFCBase.
    /// </summary>
    public abstract class BoletoPrinterBase : ACBrComponent, IBoletoPrinter
    {
        #region Events

#if !COM_INTEROP
        /// <summary>
        /// Occurs when [on obter logo].
        /// </summary>
        public event EventHandler<OnObterLogoEventArgs> OnObterLogo;
#else
        public event OnObterLogoEventHandler OnObterLogo;
#endif

        #endregion Events

        #region fields

        /// <summary>
        /// The dirlogo
        /// </summary>
        protected string dirlogo;

        #endregion fields

        #region Constructor

        /// <summary>
		/// Initializes a new instance of the <see cref="BoletoPrinterBase"/> class.
        /// </summary>
        protected BoletoPrinterBase()
        {
            Layout = LayoutBoleto.Padrao;
            dirlogo = string.Empty;
            MostrarPreview = true;
            MostrarSetup = true;
            NumCopias = 1;
            Filtro = BoletoFCFiltro.Nenhum;
            NomeArquivo = string.Empty;
            SoftwareHouse = string.Empty;
        }

        #endregion Constructor

        #region Propriedades

        /// <summary>
        /// Get/Set Layout de impressão do boleto
        /// </summary>
        /// <value>The layout.</value>
        [Browsable(true)]
        [Description("Layout de impressão do boleto")]
        public virtual LayoutBoleto Layout { get; set; }

        /// <summary>
        /// Gets the boleto.
        /// </summary>
        /// <value>The boleto.</value>
        [Browsable(false)]
        public virtual AcBrBoleto Boleto { get; internal set; }

        /// <summary>
        /// Get/Set Diretorio onde se encontra os logos dos bancos para impressão
        /// </summary>
        /// <value>The dir logo.</value>
        [DefaultValue("")]
        [Description("Diretorio onde se encontra os logos dos bancos para impressão")]
        public virtual string DirLogo
        {
            get
            {
	            if (string.IsNullOrEmpty(dirlogo.Trim()))
                    return string.Format(@"{0}\Logos\", Assembly.GetExecutingAssembly().GetPath());
	            return dirlogo;
            }
	        set
            {
                dirlogo = value;
            }
        }

        /// <summary>
        /// Get/Set Mostrar tela de preview
        /// </summary>
        /// <value><c>true</c> if [mostrar preview]; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        [Description("Mostrar tela de preview")]
        public virtual bool MostrarPreview { get; set; }

        /// <summary>
        /// Get/Set Mostrar tela setup na exportação
        /// </summary>
        /// <value><c>true</c> if [mostrar setup]; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        [Description("Mostrar tela setup na exportação")]
        public virtual bool MostrarSetup { get; set; }

        /// <summary>
        /// Get/Set Numero de copias para impressão
        /// </summary>
        /// <value>The number copias.</value>
        [DefaultValue(1)]
        [Description("Numero de copias para impressão")]
        public virtual int NumCopias { get; set; }

        /// <summary>
        /// Get/Set Filtro de impressão
        /// </summary>
        /// <value>The filtro.</value>
        [DefaultValue(BoletoFCFiltro.Nenhum)]
        [Description("Filtro de impressão")]
        public virtual BoletoFCFiltro Filtro { get; set; }

        /// <summary>
        /// Get/Set Nome do arquivo de exportação
        /// </summary>
        /// <value>The nome arquivo.</value>
        [DefaultValue("")]
        [Description("Nome do arquivo de exportação")]
        public virtual string NomeArquivo { get; set; }

        /// <summary>
        /// Get/Set Nome da softwarehouse
        /// </summary>
        /// <value>The software house.</value>
        [DefaultValue("")]
        [Description("Nome da softwarehouse")]
        public virtual string SoftwareHouse { get; set; }

        /// <summary>
        /// Get Nome do arquivo de logo
        /// </summary>
        /// <value>The arquivo logo.</value>
        [Description("Nome do arquivo de logo")]
        public virtual string ArquivoLogo
        {
            get
            {
	            if (Boleto == null || Boleto.Banco == null)
                    return "";
	            return string.Format(@"{0}\{1:000}.bmp", DirLogo, Boleto.Banco.Numero);
            }
        }

        #endregion Propriedades

        #region Methods

        /// <summary>
        /// Imprimi os boletos.
        /// </summary>
        /// <exception cref="ACBrException">
        /// Componente não está associado ao ACBrBoleto
        /// or
        /// Lista de Boletos está vazia
        /// </exception>
        public virtual void Imprimir()
        {
            if (Boleto == null)
                throw new ACBrException("Componente não está associado ao ACBrBoleto");

            if (Boleto.ListadeBoletos.Count < 1)
                throw new ACBrException("Lista de Boletos está vazia");
        }

        /// <summary>
        /// Gera um arquivo PDF dos boletos.
        /// </summary>
        public virtual void GerarPDF()
        {
            var oldfiltro = Filtro;
            var oldpreview = MostrarPreview;
            var oldsetup = MostrarSetup;
            try
            {
                Filtro = BoletoFCFiltro.PDF;
                MostrarPreview = false;
                MostrarSetup = false;
                Imprimir();
            }
            finally
            {
                Filtro = oldfiltro;
                MostrarPreview = oldpreview;
                MostrarSetup = oldsetup;
            }
        }

        /// <summary>
        /// Gera um arquivo HTML dos boletos.
        /// </summary>
        public virtual void GerarHTML()
        {
            var oldfiltro = Filtro;
            var oldpreview = MostrarPreview;
            var oldsetup = MostrarSetup;
            try
            {
                Filtro = BoletoFCFiltro.HTML;
                MostrarPreview = false;
                MostrarSetup = false;
                Imprimir();
            }
            finally
            {
                Filtro = oldfiltro;
                MostrarPreview = oldpreview;
                MostrarSetup = oldsetup;
            }
        }

        /// <summary>
        /// Função usada para caregar o logo para impressão no boleto.
        /// </summary>
        /// <param name="PictureLogo">The picture logo.</param>
        /// <param name="NumeroBanco">The numero banco.</param>
        public virtual void CarregaLogo(ref Image PictureLogo, int NumeroBanco)
        {
            if (OnObterLogo != null)
            {
                var sync = OnObterLogo.Target as ISynchronizeInvoke;
                var e = new OnObterLogoEventArgs(NumeroBanco);

#if !COM_INTEROP
                if (sync != null)
                    sync.Invoke(OnObterLogo, new object[] { this, e });
                else
                    OnObterLogo.Invoke(this, e);
#else
				if (sync != null)
					sync.Invoke(OnObterLogo, new object[] { e });
				else
					OnObterLogo.Invoke(e);
#endif
                PictureLogo = e.Logo;
            }
            else
            {
                if (File.Exists(ArquivoLogo))
                    PictureLogo = Image.FromFile(ArquivoLogo);
            }
        }

        #endregion Methods
    }
}
