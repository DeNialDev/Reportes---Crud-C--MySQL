using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Microsoft.ReportingServices.RdlExpressions;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing.Imaging;

namespace BD_Ima
{
    public partial class User : MetroForm
    {
        static ParamBD Obj = new ParamBD();
        static String paramCon = "DataBase=" + Obj.getDBName() + "; Data Source=" + Obj.getDBServer() + "; Port=" + Obj.getDBPort() + "; User Id=" + Obj.getDBUser() + "; Password=" + Obj.getDBPass();
        String Query;
        String img;
        MySqlConnection conDB = new MySqlConnection(paramCon);
        MySqlCommand cmd;
        
        public User()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtBoxAdd.Text = openFileDialog1.InitialDirectory;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Image Files | *.jpg";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    img = openFileDialog1.FileName;
                    pictureBox1.Image = Image.FromFile(img);
                    txtBoxImg.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }
        private void RefreshDataGrid()
        {
            MySqlDataAdapter adp;
            DataTable table;
            try
            {
                table = new DataTable();
                conDB.Open();
                cmd = new MySqlCommand("SELECT * FROM students", conDB);
                adp = new MySqlDataAdapter(cmd);
                adp.Fill(table);
                dataGridView1.DataSource = table;


            }
            catch (MySqlException exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conDB.Close();
            }
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            MySqlConnection conDB = new MySqlConnection(paramCon);
            MySqlCommand cmd;
           
            MemoryStream ms;
            if (!(txtBoxLName.Text.Equals("") && txtBoxFName.Text.Equals("") && txtBoxAdd.Text.Equals("")))
            {
                byte[] imgData;
                
                ms = new MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                imgData = ms.ToArray();
                
                
                Query = "Insert into students (FirstName, LastName, Image, Address ) values ('" + txtBoxFName.Text + "', '" + txtBoxLName.Text + "', @imagen , '"+txtBoxAdd.Text+"')";
                
                try
                {
                    conDB.Open();
                    cmd = new MySqlCommand(Query, conDB);
                    cmd.Parameters.AddWithValue("imagen", imgData);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Insert Successfully");
                }
                catch (MySqlException ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conDB.Close();
                    RefreshDataGrid();
                    RefreshDataGrid();
                    RefreshDataGrid();
                    RefreshDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Fill all fields");
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.Show();
        }
    }
}
