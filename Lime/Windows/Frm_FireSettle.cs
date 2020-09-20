using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Lime.BaseObject;
using Lime.Action;

namespace Lime.Windows
{
	public partial class Frm_FireSettle : MyDialog
	{
		public Frm_FireSettle()
		{
			InitializeComponent();
			gridView1.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
		}
	}
}