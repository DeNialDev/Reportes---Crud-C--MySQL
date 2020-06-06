using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynamicData;
using MetroFramework.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;

namespace BD_Ima
{
    public partial class Report : MetroForm
    {
        static ParamBD Obj = new ParamBD();
        static String paramCon = "DataBase=" + Obj.getDBName() + "; Data Source=" + Obj.getDBServer() + "; Port=" + Obj.getDBPort() + "; User Id=" + Obj.getDBUser() + "; Password=" + Obj.getDBPass();
        MySqlCommand cmd;
        public Report()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MySqlConnection conDB = new MySqlConnection(paramCon);
            MySqlDataAdapter adp;
            DataTable table;
            try
            {
                table = new DataTable();
                conDB.Open();
                cmd = new MySqlCommand("SELECT * FROM students", conDB);
                adp = new MySqlDataAdapter(cmd);
                adp.Fill(table);
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rp = new ReportDataSource("DataSet1", table);
                reportViewer1.LocalReport.DataSources.Add(rp);
                


            }
            catch (MySqlException exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conDB.Close();
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
