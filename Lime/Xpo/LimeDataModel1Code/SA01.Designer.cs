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

	public partial class SA01 : XPLiteObject
	{
		string fSA001;
		[Key]
		[Size(10)]
		public string SA001
		{
			get { return fSA001; }
			set { SetPropertyValue<string>(nameof(SA001), ref fSA001, value); }
		}
		string fAC001;
		[Indexed(Name = @"IDX_SA01_SA005")]
		[Size(10)]
		public string AC001
		{
			get { return fAC001; }
			set { SetPropertyValue<string>(nameof(AC001), ref fAC001, value); }
		}
		string fSA002;
		[Size(3)]
		public string SA002
		{
			get { return fSA002; }
			set { SetPropertyValue<string>(nameof(SA002), ref fSA002, value); }
		}
		string fSA003;
		[Size(50)]
		public string SA003
		{
			get { return fSA003; }
			set { SetPropertyValue<string>(nameof(SA003), ref fSA003, value); }
		}
		string fSA004;
		[Size(10)]
		public string SA004
		{
			get { return fSA004; }
			set { SetPropertyValue<string>(nameof(SA004), ref fSA004, value); }
		}
		string fSA005;
		[Size(3)]
		public string SA005
		{
			get { return fSA005; }
			set { SetPropertyValue<string>(nameof(SA005), ref fSA005, value); }
		}
		decimal fPRICE;
		public decimal PRICE
		{
			get { return fPRICE; }
			set { SetPropertyValue<decimal>(nameof(PRICE), ref fPRICE, value); }
		}
		decimal fNUMS;
		public decimal NUMS
		{
			get { return fNUMS; }
			set { SetPropertyValue<decimal>(nameof(NUMS), ref fNUMS, value); }
		}
		decimal fSA007;
		public decimal SA007
		{
			get { return fSA007; }
			set { SetPropertyValue<decimal>(nameof(SA007), ref fSA007, value); }
		}
		decimal fSA006;
		public decimal SA006
		{
			get { return fSA006; }
			set { SetPropertyValue<decimal>(nameof(SA006), ref fSA006, value); }
		}
		string fSA008;
		[Size(3)]
		public string SA008
		{
			get { return fSA008; }
			set { SetPropertyValue<string>(nameof(SA008), ref fSA008, value); }
		}
		string fSA010;
		[Indexed(Name = @"IDX_SA01_SA010")]
		[Size(10)]
		public string SA010
		{
			get { return fSA010; }
			set { SetPropertyValue<string>(nameof(SA010), ref fSA010, value); }
		}
		string fSA100;
		[Size(10)]
		public string SA100
		{
			get { return fSA100; }
			set { SetPropertyValue<string>(nameof(SA100), ref fSA100, value); }
		}
		DateTime fSA200;
		public DateTime SA200
		{
			get { return fSA200; }
			set { SetPropertyValue<DateTime>(nameof(SA200), ref fSA200, value); }
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