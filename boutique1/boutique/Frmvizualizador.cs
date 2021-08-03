using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace boutique
{
    public partial class Frmvizualizador : Form
    {
        public Frmvizualizador(CrystalDecisions.CrystalReports.Engine.ReportDocument reporte)
        {
            InitializeComponent();
            this.crystalReportViewer1.ReportSource = reporte;
        }
    }
}
