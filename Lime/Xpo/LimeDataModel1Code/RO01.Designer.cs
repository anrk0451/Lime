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

	public partial class RO01 : XPLiteObject
	{
		string fRO001;
		[Key]
		[Size(6)]
		public string RO001
		{
			get { return fRO001; }
			set { SetPropertyValue<string>(nameof(RO001), ref fRO001, value); }
		}
		string fRO003;
		[Size(50)]
		public string RO003
		{
			get { return fRO003; }
			set { SetPropertyValue<string>(nameof(RO003), ref fRO003, value); }
		}
		string fRO004;
		public string RO004
		{
			get { return fRO004; }
			set { SetPropertyValue<string>(nameof(RO004), ref fRO004, value); }
		}
		string fSTATUS;
		[Size(3)]
		public string STATUS
		{
			get { return fSTATUS; }
			set { SetPropertyValue<string>(nameof(STATUS), ref fSTATUS, value); }
		}
	}

}
