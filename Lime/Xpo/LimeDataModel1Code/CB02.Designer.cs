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

	public partial class CB02 : XPLiteObject
	{
		string fCB201;
		[Key]
		[Size(10)]
		public string CB201
		{
			get { return fCB201; }
			set { SetPropertyValue<string>(nameof(CB201), ref fCB201, value); }
		}
		string fCB001;
		[Size(10)]
		public string CB001
		{
			get { return fCB001; }
			set { SetPropertyValue<string>(nameof(CB001), ref fCB001, value); }
		}
		string fCB021;
		[Size(10)]
		public string CB021
		{
			get { return fCB021; }
			set { SetPropertyValue<string>(nameof(CB021), ref fCB021, value); }
		}
		string fCB022;
		[Size(3)]
		public string CB022
		{
			get { return fCB022; }
			set { SetPropertyValue<string>(nameof(CB022), ref fCB022, value); }
		}
		int fCB030;
		public int CB030
		{
			get { return fCB030; }
			set { SetPropertyValue<int>(nameof(CB030), ref fCB030, value); }
		}
	}

}