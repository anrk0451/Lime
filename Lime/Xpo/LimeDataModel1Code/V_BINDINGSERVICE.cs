using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace Lime.Xpo.orcl
{

	public partial class V_BINDINGSERVICE
	{
		public V_BINDINGSERVICE(Session session) : base(session) { }
		public override void AfterConstruction() { base.AfterConstruction(); }
	}

}
