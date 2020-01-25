﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MadniPharmacy.Classes;
using System.Data.Linq;

namespace MadniPharmacy
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }
        //DataContext dc = new DataContext("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");
        DataContext dc = new DataContext(Connection.dcc);
        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
          
                Table<MadniPharmacy.Classes.Product> p = dc.GetTable<MadniPharmacy.Classes.Product>();
                MadniPharmacy.Classes.Product p1 = new MadniPharmacy.Classes.Product();
                p1.Name = metroTextBox12.Text;
                p1.Type = metroComboBox5.SelectedItem.ToString();
                p1.Package_name = metroComboBox2.SelectedItem.ToString();
                p1.Purchase_rate = Convert.ToDouble(metroTextBox1.Text);
                p1.Sale_rate = Convert.ToDouble(metroTextBox5.Text);
                p1.No_of_items_in_pack = Convert.ToInt32(metroTextBox2.Text);
                p1.Item_type = metroComboBox3.SelectedItem.ToString();
                p1.Item_unit_cost = Convert.ToDouble(metroTextBox4.Text);
                p1.No_of_sub_items_in_item = Convert.ToInt32(metroTextBox3.Text);
            if(metroComboBox4.SelectedText == "")
            {
                metroComboBox4.Text = "none";
                p1.Sub_item_type = metroComboBox4.Text;
            }
            else
            {
                p1.Sub_item_type = metroComboBox4.SelectedItem.ToString();
            }
                
                p1.Sub_item_unit_cost = Convert.ToDouble(metroTextBox6.Text);
                p1.No_of_tablets_in_pack = Convert.ToInt32(metroTextBox8.Text);
                p1.Quantity = Convert.ToInt32(metroTextBox9.Text);
                p1.Date = Convert.ToDateTime(metroDateTime1.Text);
                p1.Batchno = metroTextBox7.Text;
                p1.Cname = metroTextBox10.Text;
                p.InsertOnSubmit(p1);
                dc.SubmitChanges();
                MetroFramework.MetroMessageBox.Show(this, "Saved");
            AdminMenu am = new AdminMenu();
            this.Close();
            am.Show();
                }

        private void PurchaseProduct_Load(object sender, EventArgs e)
        {
            this.ActiveControl = metroTextBox12;
        }

        private void metroTextBox4_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void metroTextBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void metroLabel14_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox2_TextChanged(object sender, EventArgs e)
        {
            if(metroTextBox2.Text == "")
            {
                metroTextBox2.Text = "0";
            }
            double sale_rate = Convert.ToDouble(metroTextBox5.Text);
            int no_of_item_in_pack = Convert.ToInt32(metroTextBox2.Text);
            double item_unit_cost = Convert.ToDouble(metroTextBox4.Text);
            item_unit_cost = sale_rate / no_of_item_in_pack;
            metroTextBox4.Text = Convert.ToString(Math.Round(item_unit_cost,2));
        }

        private void metroTextBox3_Click(object sender, EventArgs e)
        {
            

        }

        private void metroTextBox3_TextChanged(object sender, EventArgs e)
        {
            int no_of_sub_items_in_item = Convert.ToInt32(metroTextBox3.Text);
            double item_unit_cost = Convert.ToDouble(metroTextBox4.Text);
            double sub_item_unit_cost = Convert.ToDouble(metroTextBox6.Text);
            sub_item_unit_cost = item_unit_cost / no_of_sub_items_in_item;
            metroTextBox6.Text = Convert.ToString(Math.Round(sub_item_unit_cost,2));
            int no_of_items_in_pack = Convert.ToInt32(metroTextBox2.Text);
            int no_of_tablets_in_pack = Convert.ToInt32(metroTextBox8.Text);
            int no_of_sub_item_in_item = Convert.ToInt32(metroTextBox3.Text);
            no_of_tablets_in_pack = no_of_items_in_pack * no_of_sub_item_in_item;
            metroTextBox8.Text = Convert.ToString(no_of_tablets_in_pack);
        }

        private void metroTextBox9_TextChanged(object sender, EventArgs e)
        {
            if(metroTextBox9.Text == "")
            {
                metroTextBox9.Text = "0";
            }
            int no_of_tablets_in_pack = Convert.ToInt32(metroTextBox8.Text);
            int quantity = Convert.ToInt32(metroTextBox9.Text);
            double total_quantity = Convert.ToDouble(metroTextBox11.Text);
            total_quantity = quantity * no_of_tablets_in_pack;
            metroTextBox11.Text = Convert.ToString(total_quantity);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            AdminMenu am = new AdminMenu();
            this.Close();
            am.Show();
        }

        private void metroTextBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.ShiftKey)
            {
                metroComboBox5.Focus();
            }
        }

        private void metroComboBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroComboBox2.Focus();
            }
        }

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            metroTextBox5.Focus();
        }

        private void metroComboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroTextBox1.Focus();
            }
        }

        private void metroTextBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroTextBox2.Focus();
            }
        }

        private void metroTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroComboBox3.Focus();
            }
        }

        private void metroComboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroTextBox3.Focus();
            }
        }

        private void metroTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroComboBox4.Focus();
            }
        }

        private void metroComboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroTextBox9.Focus();
            }
        }

        private void metroTextBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroTextBox7.Focus();
            }
        }

        private void metroTextBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroTextBox10.Focus();
            }
        }

        private void metroTextBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroButton1.Focus();
            }
        }

        private void metroButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroButton2.Focus();
            }
        }

        private void metroButton2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroTextBox12.Focus();
            }
        }

        private void metroTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
