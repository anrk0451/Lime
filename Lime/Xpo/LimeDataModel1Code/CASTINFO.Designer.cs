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

	public partial class CASTINFO : XPLiteObject
	{
		string fSERVICESALESTYPE;
		[Key]
		[Size(3)]
		public string SERVICESALESTYPE
		{
			get { return fSERVICESALESTYPE; }
			set { SetPropertyValue<string>(nameof(SERVICESALESTYPE), ref fSERVICESALESTYPE, value); }
		}
		string fTYPEDESC;
		[Size(50)]
		public string TYPEDESC
		{
			get { return fTYPEDESC; }
			set { SetPropertyValue<string>(nameof(TYPEDESC), ref fTYPEDESC, value); }
		}
	}

}
