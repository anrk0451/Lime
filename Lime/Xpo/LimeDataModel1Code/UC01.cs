﻿using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace Lime.Xpo.orcl
{

	public partial class UC01
	{
		public UC01(Session session) : base(session) { }
		public override void AfterConstruction() { base.AfterConstruction(); }
	}

}
