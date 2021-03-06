﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VHMIS.Model;

namespace VHMIS
{
    public partial class SpecimenForm : Form
    {
        DataTable t;
        List<Specimens> _specimens = new List<Specimens>();
        Specimens _specimen;
        DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
        public SpecimenForm()
        {
            InitializeComponent();
            LoadData();
          
            btnDelete.Name = "btnDelete";
            btnDelete.Text = "Delete";
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Width = 30;
            btnDelete.CellTemplate.Style.BackColor = Color.Wheat;
            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.HeaderText = "Delete";

            btnEdit.Name = "btnEdit";
            btnEdit.Text = "Edit";
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Width = 30;
            btnEdit.CellTemplate.Style.BackColor = Color.Orange;
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.HeaderText = "Edit";

        }
        bool loaded = false;
        public void LoadData()
        {

            _specimens = Global._specimens;
            t = new DataTable();


            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("id");//1          
            t.Columns.Add("Code");//2            
            t.Columns.Add("Name");//3
            t.Columns.Add("Service");//4            
            t.Columns.Add("Created");// 5
            t.Columns.Add("Delete");// 6

            foreach (Specimens r in Global._specimens)
            {
                t.Rows.Add(new object[] { false, r.Id,  r.Code, r.Name, r.Service, r.Created, "Delete" });

            }
            dtGrid.DataSource = t;
            dtGrid.AllowUserToAddRows = false;
            dtGrid.Columns[6].DefaultCellStyle.BackColor = Color.OrangeRed;           
            dtGrid.Columns[1].Visible = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        List<string> fileIDs = new List<string>();

        public object CollectionViewSource { get; private set; }
        public object UserFilter { get; private set; }

        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == dtGrid.Columns[0].Index && e.RowIndex >= 0)
            {
                if (fileIDs.Contains(dtGrid.Rows[e.RowIndex].Cells[1].Value.ToString()))
                {
                    fileIDs.Remove(dtGrid.Rows[e.RowIndex].Cells[1].Value.ToString());
                    Console.WriteLine("REMOVED this id " + dtGrid.Rows[e.RowIndex].Cells[0].Value.ToString());

                }
                else
                {
                    fileIDs.Add(dtGrid.Rows[e.RowIndex].Cells[1].Value.ToString());
                    Console.WriteLine("ADDED ITEM " + dtGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }

            
            if (e.ColumnIndex == 6)
            {
                if (MessageBox.Show("YES or No?", "Are you sure you want to delete this information? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DBConnect.Delete("specimens", dtGrid.Rows[e.RowIndex].Cells[1].Value.ToString());

                    MessageBox.Show("Information deleted");
                    LoadData();

                }
            }
           

        }
        string updateID;

      
       
        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            updateID = dtGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            _specimen = new Specimens(updateID, dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[3].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells[4].Value.ToString(), DateTime.Now.ToString("dd-MM-yyyy H:mm:ss"), Helper.orgID);

            DBConnect.Update(_specimen, updateID);
            Global._specimens.RemoveAll(x => x.Id == updateID);
            Global._specimens.Add(_specimen);

        }

        private void dtGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SpecimenDialog form = new SpecimenDialog())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
    }
}
