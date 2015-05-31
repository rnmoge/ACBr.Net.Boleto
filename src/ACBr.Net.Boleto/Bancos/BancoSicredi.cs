// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 05-31-2015
//
// Last Modified By : RFTD
// Last Modified On : 05-31-2015
// ***********************************************************************
// <copyright file="Class1.cs" company="">
// Esta biblioteca é software livre; você pode redistribuí-la e/ou modificá-la
// sob os termos da Licença Pública Geral Menor do GNU conforme publicada pela
// Free Software Foundation; tanto a versão 2.1 da Licença, ou (a seu critério)
// qualquer versão posterior.
//
// Esta biblioteca é distribuída na expectativa de que seja útil, porém, SEM
// NENHUMA GARANTIA; nem mesmo a garantia implícita de COMERCIABILIDADE OU
// ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA. Consulte a Licença Pública Geral Menor
// do GNU para mais detalhes. (Arquivo LICENÇA.TXT ou LICENSE.TXT)
//
// Você deve ter recebido uma cópia da Licença Pública Geral Menor do GNU junto
// com esta biblioteca; se não, escreva para a Free Software Foundation, Inc.,
// no endereço 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.
// Você também pode obter uma copia da licença em:
// http://www.opensource.org/licenses/lgpl-license.php
// </copyright>
// <summary></summary>
// ***********************************************************************

using ACBr.Net.Boleto.Enums;

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
	[Guid("41D9AAD6-C953-4935-A15F-9C5A36E8163C")]
	[ComSourceInterfaces(typeof(IACBrBoletoFCEvents))]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

	#endregion COM Interop Attributes
	/// <summary>
	/// Classe BancoSicredi. Está classe não pode ser herdada.
	/// </summary>
	public sealed class BancoSicredi : BancoBase
	{
		#region Fields
		#endregion Fields

		#region Constructors

		/// <summary>
		/// Inicializa uma nova instancia da classe <see cref="BancoDoBrasil" />.
		/// </summary>
		/// <param name="parent">Classe Banco.</param>
		internal BancoSicredi(Banco parent)
			: base(parent)
        {
            TipoCobranca = TipoCobranca.BancoDoBrasil;
            Digito = 10;
			Nome = "Sicredi";
            Numero = 748;
            TamanhoMaximoNossoNum = 8;
            TamanhoConta = 5;
            TamanhoAgencia = 4;
            TamanhoCarteira = 1;
			CodigosMoraAceitos = "AB";
			CodigosGeracaoAceitos = "23456789";
        }

		#endregion Constructors

		#region Propriedades
		#endregion Propriedades

		#region Methods
		#endregion Methods
	}
}