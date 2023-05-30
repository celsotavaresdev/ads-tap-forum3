using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;

namespace ParaCasa1
{
    public partial class RelatorioLivrosUIL : Form
    {
        public static readonly String reportPath = Application.StartupPath + "\\relatorio.rpt";

        public RelatorioLivrosUIL()
        {
            InitializeComponent();
        }

        private void crystalReportViewer_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("titulo");
            dataTable.Columns.Add("autor");
            dataTable.Columns.Add("editora");
            dataTable.Columns.Add("ano");

            foreach (Livro livro in LivroDAL.listarLivros())
            {
                dataTable.Rows.Add(livro.getTitulo(), livro.getAutor(), livro.getEditora(), livro.getAno());
            }

            try
            {
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load(reportPath);
                reportDocument.SetDataSource(dataTable);
                crystalReportViewer.ReportSource = reportDocument;
                crystalReportViewer.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }
    }
}