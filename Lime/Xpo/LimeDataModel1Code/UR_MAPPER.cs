﻿using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace Lime.Xpo.orcl
{

	public partial class UR_MAPPER
	{
		public UR_MAPPER(Session session) : base(session) { }
		public override void AfterConstruction() { base.AfterConstruction(); }
	}

}
