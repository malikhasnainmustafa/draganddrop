using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private bool Moved;
        private Point MouseDownLocation;
        private Point OriginalLocation1;
        private Point OriginalLocation2;
        private Point OriginalLocation3;
        private Point OriginalLocation4;
     //   String val;
        String removal;

        public Form1()
        {
            InitializeComponent();
        }


      

        private void ClearPanel(Panel panel)
        {
            if (panel.Controls.Count > 0)
            {
                if (((Label)panel.Controls[0]).Name == "label1")
                { ((Label)panel.Controls[0]).Location = OriginalLocation1; }
                else if (((Label)panel.Controls[0]).Name == "label2")
                { ((Label)panel.Controls[0]).Location = OriginalLocation2; }
                else if (((Label)panel.Controls[0]).Name == "label3")
                { ((Label)panel.Controls[0]).Location = OriginalLocation3; }
                else if (((Label)panel.Controls[0]).Name == "label4")
                { ((Label)panel.Controls[0]).Location = OriginalLocation4; }
               
                ((Label)panel.Controls[0]).Parent = this;
            }
            removal = panel.Name;
            //string remov = Regex.Match(removal, @"\d+").Value;
            //string xx = "label1" + remov;
            //Label lab = new Label();
            //lab.Name = xx;
            //lab.Visible = true;

        }

        private void FillPanel(Label label, Point Location)
        {
            Point CurrentLocation = new Point(label.Left + Location.X, label.Top + Location.Y);

            if (this.panel1.Bounds.Contains(CurrentLocation))
            {
                ClearPanel(panel1);

                label.Parent = this.panel1;
                label.Left = 10;
                label.Top = 5;

                string val = label.Text;
                saveDB(val);
                label11.Visible = false;
                if (panel1.Controls.Count == 0) { label11.Visible = true; panel1.Controls.Add(label11); }
                if (panel2.Controls.Count == 0) { label12.Visible = true; panel2.Controls.Add(label12); }
                if (panel3.Controls.Count == 0) { label13.Visible = true; panel3.Controls.Add(label13); }
                if (panel4.Controls.Count == 0) { label14.Visible = true; panel4.Controls.Add(label14); }
            }
            else if (this.panel2.Bounds.Contains(CurrentLocation))
            {
                ClearPanel(panel2);

                label.Parent = this.panel2;
                label.Left = 10;
                label.Top = 5;

                string val = label.Text;
                saveDB(val);
                label12.Visible = false;
                if (panel1.Controls.Count == 0) { label11.Visible = true; panel1.Controls.Add(label11); }
                if (panel2.Controls.Count == 0) { label12.Visible = true; panel2.Controls.Add(label12); }
                if (panel3.Controls.Count == 0) { label13.Visible = true; panel3.Controls.Add(label13); }
                if (panel4.Controls.Count == 0) { label14.Visible = true; panel4.Controls.Add(label14); }
            }
            else if (this.panel3.Bounds.Contains(CurrentLocation))
            {
                ClearPanel(panel3);

                label.Parent = this.panel3;
                label.Left = 10;
                label.Top = 5;
                string val = label.Text;
                saveDB(val);
                label13.Visible = false;
                if (panel1.Controls.Count == 0) { label11.Visible = true; panel1.Controls.Add(label11); }
                if (panel2.Controls.Count == 0) { label12.Visible = true; panel2.Controls.Add(label12); }
                if (panel3.Controls.Count == 0) { label13.Visible = true; panel3.Controls.Add(label13); }
                if (panel4.Controls.Count == 0) { label14.Visible = true; panel4.Controls.Add(label14); }
            }
            else if (this.panel4.Bounds.Contains(CurrentLocation))
            {
                ClearPanel(panel4);

                label.Parent = this.panel4;
                label.Left = 10;
                label.Top = 5;
                string val = label.Text;
                saveDB(val);
                label14.Visible = false;
                if (panel1.Controls.Count == 0) { label11.Visible = true; panel1.Controls.Add(label11); }
                if (panel2.Controls.Count == 0) { label12.Visible = true; panel2.Controls.Add(label12); }
                if (panel3.Controls.Count == 0) { label13.Visible = true; panel3.Controls.Add(label13); }
                if (panel4.Controls.Count == 0) { label14.Visible = true; panel4.Controls.Add(label14); }
            }
            else
            {
                if (Moved)
                {
                    label.Parent = this;

                    string val = "";
                    saveDB(val);
                    if (panel1.Controls.Count == 0) { label11.Visible = true; panel1.Controls.Add(label11);}
                    if (panel2.Controls.Count == 0) { label12.Visible = true; panel2.Controls.Add(label12); }
                    if (panel3.Controls.Count == 0) { label13.Visible = true; panel3.Controls.Add(label13); }
                    if (panel4.Controls.Count == 0) { label14.Visible = true; panel4.Controls.Add(label14); }
                   

                    if (label.Name == "label1")
                        label.Location = OriginalLocation1;
                    else if (label.Name == "label2")
                        label.Location = OriginalLocation2;
                    else if (label.Name == "label3")
                        label.Location = OriginalLocation3;
                    else if (label.Name == "label4")
                        label.Location = OriginalLocation4;
                }
            }
        }

        private void SaveLocation(Label label, Point CurrentLocation)
        {
            Moved = false;

            MouseDownLocation = CurrentLocation;

            if (label.Parent == this)
            {
                if (label.Name == "label1")
                    OriginalLocation1 = label.Location;
                else if (label.Name == "label2")
                    OriginalLocation2 = label.Location;
                else if (label.Name == "label3")
                    OriginalLocation3 = label.Location;
                else if (label.Name == "label4")
                    OriginalLocation4 = label.Location;
            }
        }

        private void MoveLabel(Label label, Point CurrentLocation)
        {
            Moved = true;

            label.Parent = this;
            label.BringToFront();

            label.Left = label.Left + CurrentLocation.X - MouseDownLocation.X;
            label.Top = label.Top + CurrentLocation.Y - MouseDownLocation.Y;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                SaveLocation(label1, e.Location);
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                FillPanel(label1, e.Location);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MoveLabel(label1, e.Location);
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                SaveLocation(label2, e.Location);
        }

        private void label2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                FillPanel(label2, e.Location);
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MoveLabel(label2, e.Location);
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                SaveLocation(label3, e.Location);
        }

        private void label3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                FillPanel(label3, e.Location);
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MoveLabel(label3, e.Location);
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                SaveLocation(label4, e.Location);
        }

        private void label4_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                FillPanel(label4, e.Location);
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MoveLabel(label4, e.Location);
        }



        public void saveDB(string a)
        {
          // string resultString = Regex.Match(a, @"\d+").Value;
          // string c = "Ans" + resultString;
            try
            {
                string remov = Regex.Match(removal, @"\d+").Value;
                string xx = "Ans" + remov;
                String cn = @"Server=58.65.172.36\SQLEXPRESS;Initial Catalog=ACCAStdRecSQL;Integrated Security=False;User ID=sqluser;Password=santro";
              //  String cn = @"Server=DBSERVER\SQLEXPRESS;Initial Catalog=ACCAStdRecSQL;Integrated Security=True";
                SqlConnection con = new SqlConnection(cn);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                string updat = "Update CBEAttempt SET " + xx + "='" + a + "' where AttemptID ='3606079' ";
                SqlCommand cmd = new SqlCommand(updat, con);
                int res = cmd.ExecuteNonQuery();
                if (res == 1)
                {
                    // MessageBox.Show("Record Successfully Updated", "Record Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                con.Close();
                con.Open();
                string sql = "Select Ans1, Ans2, Ans3, Ans4 from CBEAttempt where AttemptID='3606079'";
                SqlCommand cmd1 = new SqlCommand(sql, con);
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd1);
                adp.Fill(dt);
                string sum = dt.Rows[0][0].ToString() + "-" + dt.Rows[0][1].ToString() + "-" + dt.Rows[0][2].ToString() + "-" + dt.Rows[0][3].ToString();
                //  string ans = "label3label1label4label2";
                string ans = label5.Text;
                int marks = 0;
                if (sum == ans)
                {
                    marks = Convert.ToInt32(label6.Text);


                }

                string updat2 = "Update CBEAttempt SET Marks='" + marks + "' where AttemptID ='3606079' ";
                SqlCommand cmd2 = new SqlCommand(updat2, con);
                int res2 = cmd2.ExecuteNonQuery();
            }
            catch(Exception){}

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aCCAStdRecSQLDataSet.CBEAttempt' table. You can move, or remove it, as needed.
          //  this.cBEAttemptTableAdapter.Fill(this.aCCAStdRecSQLDataSet.CBEAttempt);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveLocation(label1, label1.Location);
            SaveLocation(label2, label2.Location);
            SaveLocation(label3, label3.Location);
            SaveLocation(label4, label4.Location);
            panel1.Controls.Remove(label11);
            panel2.Controls.Remove(label12);
            panel3.Controls.Remove(label13);
            panel4.Controls.Remove(label14);
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            panel1.Controls.Add(label3);
            label3.Left = 10;
            label3.Top = 5;
            panel2.Controls.Add(label2);
            label2.Left = 10;
            label2.Top = 5;
            panel3.Controls.Add(label4);
            label4.Left = 10;
            label4.Top = 5;
            panel4.Controls.Add(label1);
            label1.Left = 10;
            label1.Top = 5;
          


            //String cn = @"Server=DBSERVER\SQLEXPRESS;Initial Catalog=ACCAStdRecSQL;Integrated Security=True";
            //SqlConnection con = new SqlConnection(cn);
            //if (con.State == ConnectionState.Open)
            //{
            //    con.Close();
            //}
            //con.Open();
            //string sql = "Select Ans1, Ans2, Ans3, Ans4 from CBEAttempt where AttemptID='5510'";
            //SqlCommand cmd1 = new SqlCommand(sql, con);
            //DataTable dt = new DataTable();
            //SqlDataAdapter adp = new SqlDataAdapter(cmd1);
            //adp.Fill(dt);

            //Panel panel = new Panel();
            //for (int i = 1; i <= 4; i++)
            //{
            //    int y = 1;
            //    string abc = Convert.ToString(y);

            //    panel.Name = panel + abc;

                //if (panel1.Tag == label1.Text)
                //    //   ((Label)panel1.Controls[0]).Parent = this;
                //    panel1.Controls.Add(label1);
                //if (panel.Tag == label2.Text)
                //    panel.Controls.Add(label2);
                //if (panel.Tag == label3.Text)
                //    panel.Controls.Add(label3);
                //if (panel.Tag == label4.Text)
                //    panel.Controls.Add(label4);
              //  y++;
         //   }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
