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

	public partial class BI01 : XPLiteObject
	{
		string fBI001;
		[Key]
		[Size(10)]
		public string BI001
		{
			get { return fBI001; }
			set { SetPropertyValue<string>(nameof(BI001), ref fBI001, value); }
		}
		string fRG001;
		[Size(10)]
		public string RG001
		{
			get { return fRG001; }
			set { SetPropertyValue<string>(nameof(RG001), ref fRG001, value); }
		}
		string fBI020;
		[Size(10)]
		public string BI020
		{
			get { return fBI020; }
			set { SetPropertyValue<string>(nameof(BI020), ref fBI020, value); }
		}
		string fBI030;
		[Size(10)]
		public string BI030
		{
			get { return fBI030; }
			set { SetPropertyValue<string>(nameof(BI030), ref fBI030, value); }
		}
		int fBI002;
		public int BI002
		{
			get { return fBI002; }
			set { SetPropertyValue<int>(nameof(BI002), ref fBI002, value); }
		}
		string fBI003;
		[Indexed(Name = @"IDX_BI01_BI003")]
		[Size(50)]
		public string BI003
		{
			get { return fBI003; }
			set { SetPropertyValue<string>(nameof(BI003), ref fBI003, value); }
		}
		int fBI005;
		public int BI005
		{
			get { return fBI005; }
			set { SetPropertyValue<int>(nameof(BI005), ref fBI005, value); }
		}
		string fBI007;
		[Size(3)]
		[ColumnDbDefaultValue("0")]
		public string BI007
		{
			get { return fBI007; }
			set { SetPropertyValue<string>(nameof(BI007), ref fBI007, value); }
		}
		int fBI008;
		public int BI008
		{
			get { return fBI008; }
			set { SetPropertyValue<int>(nameof(BI008), ref fBI008, value); }
		}
		decimal fBI009;
		public decimal BI009
		{
			get { return fBI009; }
			set { SetPropertyValue<decimal>(nameof(BI009), ref fBI009, value); }
		}
		string fBI010;
		[Indexed(Name = @"IDX_BI01_BI010")]
		[Size(10)]
		public string BI010
		{
			get { return fBI010; }
			set { SetPropertyValue<string>(nameof(BI010), ref fBI010, value); }
		}
		string fSTATUS;
		[Size(3)]
		[ColumnDbDefaultValue("9\n")]
		public string STATUS
		{
			get { return fSTATUS; }
			set { SetPropertyValue<string>(nameof(STATUS), ref fSTATUS, value); }
		}
	}

}