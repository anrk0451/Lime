﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace Lime.Xpo.orcl
{

	[Persistent(@"NEWTOMB.T_VERSION")]
	public partial class NEWTOMB_T_VERSION : XPLiteObject
	{
		DateTime fINSTALLDATE;
		public DateTime INSTALLDATE
		{
			get { return fINSTALLDATE; }
			set { SetPropertyValue<DateTime>(nameof(INSTALLDATE), ref fINSTALLDATE, value); }
		}
		string fVERSIONDESC;
		[Size(200)]
		public string VERSIONDESC
		{
			get { return fVERSIONDESC; }
			set { SetPropertyValue<string>(nameof(VERSIONDESC), ref fVERSIONDESC, value); }
		}
		char fFORCE;
		public char FORCE
		{
			get { return fFORCE; }
			set { SetPropertyValue<char>(nameof(FORCE), ref fFORCE, value); }
		}
		public struct CompoundKey1Struct
		{
			[Persistent("VERSION_NUM")]
			public decimal VERSION_NUM { get; set; }
		}
		[Key, Persistent]
		public CompoundKey1Struct CompoundKey1;
	}

}
