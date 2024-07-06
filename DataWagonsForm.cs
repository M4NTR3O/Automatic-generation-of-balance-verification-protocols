using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automatic_generation_of_balance_verification_protocols
{
    public partial class DataWagonsForm : Form
    {
        private DataSet WagonsAndTransinDataSet;
        public DataWagonsForm()
        {
            InitializeComponent();
            WagonsAndTransinDataSet = new DataSet();
            CreateDGV();
        }

        public DataWagonsForm(DataSet table)
        {
            InitializeComponent();
            //inputTable(table);
            WagonsAndTransinDataSet = table;
            numericUpDownWagons.Value = (int)WagonsAndTransinDataSet.Tables[0].Rows.Count;
            numericUpDownTransit.Value = (int)WagonsAndTransinDataSet.Tables.Count;
        }

        private void inputTable(DataGridView table)
        {
            tableWagonsAndTransit.ColumnCount = table.Columns.Count;
            tableWagonsAndTransit.RowCount = table.Rows.Count;
            for (int i = 0; i < tableWagonsAndTransit.Columns.Count; i++)
            {
                tableWagonsAndTransit.Columns[i].HeaderText = table.Columns[i].HeaderText;
                tableWagonsAndTransit.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (i == 0)
                {
                    tableWagonsAndTransit.Columns[i].Frozen = true;
                }
            }
            tableWagonsAndTransit.RowHeadersVisible = true;
            tableWagonsAndTransit.ColumnHeadersVisible = true;
            for (int i = 0; i < tableWagonsAndTransit.Rows.Count; i++)
            {
                for (int j = 0; j < tableWagonsAndTransit.Columns.Count; j++)
                {
                    tableWagonsAndTransit.Rows[i].Cells[j].Value = table.Rows[i].Cells[j].Value;
                }
            }
        }

        private void CreateDGV()
        {
            int transitCount = Convert.ToInt16(numericUpDownTransit.Value);
            int wagonsCount = Convert.ToInt16(numericUpDownWagons.Value);
            for (int i = 0; i < transitCount; i++)
            {
                DataTable db = CreateTable(i);
                if (i == 0)
                {
                    menuStripTransitButton.Items[i].BackColor = Color.DarkGray;
                    tableWagonsAndTransit.DataSource = db;
                }
                for (int j = 0; j < wagonsCount; j++)
                {
                    db.Rows.Add();
                    db.Rows[j].ItemArray[2] = 0;
                    db.Rows[j].ItemArray[3] = "0.000";
                }
            }
            tableWagonsAndTransit.RowHeadersVisible = true;
            tableWagonsAndTransit.ColumnHeadersVisible = true;
            tableWagonsAndTransit.Columns[0].Frozen = true;
            tableWagonsAndTransit.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableWagonsAndTransit.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableWagonsAndTransit.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableWagonsAndTransit.Columns[3].ReadOnly = true;
            tableWagonsAndTransit.Columns[3].DefaultCellStyle.BackColor = Color.Gray;
            tableWagonsAndTransit.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableWagonsAndTransit.Columns[4].ReadOnly = true;
            tableWagonsAndTransit.Columns[4].DefaultCellStyle.BackColor = Color.Gray;
            tableWagonsAndTransit.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void OnClick_menuStripTransitButtons(object sender, EventArgs e)
        {
            for (int i = 0; i < menuStripTransitButton.Items.Count; i++)
            {
                for (int j = 0; j < tableWagonsAndTransit.Rows.Count; j++)
                {
                    WagonsAndTransinDataSet.Tables[i].Rows[j].SetField(0, tableWagonsAndTransit.Rows[j].Cells[0].Value);
                    WagonsAndTransinDataSet.Tables[i].Rows[j].SetField(1,tableWagonsAndTransit.Rows[j].Cells[1].Value);
                }
                if (menuStripTransitButton.Items[i] == (sender as ToolStripItem))
                {
                    menuStripTransitButton.Items[i].BackColor = Color.DarkGray;
                    tableWagonsAndTransit.DataSource = WagonsAndTransinDataSet.Tables[i];
                }
                else if (menuStripTransitButton.Items[i].BackColor == Color.DarkGray)
                {
                    menuStripTransitButton.Items[i].BackColor = SystemColors.Control;
                }
            }
        }

        private DataTable CreateTable(int i)
        {
            DataTable db = new DataTable($"{i + 1}");
            db.Columns.Add("№ вагона");
            db.Columns.Add("Вес в статике");
            db.Columns.Add($"Проезд №{i + 1}");
            menuStripTransitButton.Items.Add($"Проезд №{i + 1}");
            menuStripTransitButton.Items[i].Click += OnClick_menuStripTransitButtons;
            db.Columns.Add("Погрешность абсолютная");
            db.Columns.Add("Погрешность относительная");
            WagonsAndTransinDataSet.Tables.Add(db);
            foreach (var wagons in WagonsAndTransinDataSet.Tables[0].Rows)
            {
                db.Rows.Add();
            }
            return db;
        }

        private void updateTable()
        {
            tableWagonsAndTransit.ColumnCount = 2 + 3 * Convert.ToInt32(numericUpDownTransit.Value);
            tableWagonsAndTransit.RowCount = Convert.ToInt32(numericUpDownWagons.Value);
            tableWagonsAndTransit.RowHeadersVisible = true;
            tableWagonsAndTransit.ColumnHeadersVisible = true;
            tableWagonsAndTransit.Columns[0].HeaderText = "№ Вагона";
            tableWagonsAndTransit.Columns[0].Frozen = true;
            tableWagonsAndTransit.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            tableWagonsAndTransit.Columns[1].HeaderText = "Вес в статике";
            tableWagonsAndTransit.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            for (int i = 0; i < (tableWagonsAndTransit.Columns.Count - 2) / 3; i++)
            {
                tableWagonsAndTransit.Columns[2 + i * 3].HeaderText = $"Проезд №{i + 1}";
                tableWagonsAndTransit.Columns[2 + i * 3].SortMode = DataGridViewColumnSortMode.NotSortable;
                tableWagonsAndTransit.Columns[3 + i * 3].HeaderText = "Погрешность абсолютная";
                tableWagonsAndTransit.Columns[3 + i * 3].ReadOnly = true;
                tableWagonsAndTransit.Columns[3 + i * 3].DefaultCellStyle.BackColor = Color.Gray;
                tableWagonsAndTransit.Columns[3 + i * 3].SortMode = DataGridViewColumnSortMode.NotSortable;
                tableWagonsAndTransit.Columns[4 + i * 3].HeaderText = "Погрешность относительная";
                tableWagonsAndTransit.Columns[4 + i * 3].ReadOnly = true;
                tableWagonsAndTransit.Columns[4 + i * 3].DefaultCellStyle.BackColor = Color.Gray;
                tableWagonsAndTransit.Columns[4 + i * 3].SortMode = DataGridViewColumnSortMode.NotSortable;
                for (int j = 0; j < tableWagonsAndTransit.Rows.Count; j++)
                {
                    try
                    {
                        tableWagonsAndTransit.Rows[j].Cells[3 + i * 3].Value = Convert.ToInt32(tableWagonsAndTransit.Rows[j].Cells[2 + i * 3].Value) - Convert.ToInt32(tableWagonsAndTransit.Rows[j].Cells[1].Value);
                        tableWagonsAndTransit.Rows[j].Cells[4 + i * 3].Value = string.Format("{0:f3}", ((Convert.ToInt32(tableWagonsAndTransit.Rows[j].Cells[2 + i * 3].Value) * 100) / Convert.ToInt32(tableWagonsAndTransit.Rows[j].Cells[1].Value)) - 100);
                    }
                    catch 
                    {
                        tableWagonsAndTransit.Rows[j].Cells[3 + i * 3].Value = 0;
                        tableWagonsAndTransit.Rows[j].Cells[4 + i * 3].Value = "0.000";
                    }
                }
            }
        }

        private void calculationTable()
        {
            for (int i = 0; i < (tableWagonsAndTransit.Columns.Count - 2) / 3; i++)
            {
                for (int j = 0; j < tableWagonsAndTransit.Rows.Count; j++)
                {
                    //Уточнить по Относительной погрешности
                    try
                    {
                        if (tableWagonsAndTransit.Rows[j].Cells[2 + i * 3].Value == null || tableWagonsAndTransit.Rows[j].Cells[1 + i * 3].Value == null)
                        {
                            throw new Exception();
                        }
                        tableWagonsAndTransit.Rows[j].Cells[3 + i * 3].Value = Convert.ToInt32(tableWagonsAndTransit.Rows[j].Cells[2 + i * 3].Value) - Convert.ToInt32(tableWagonsAndTransit.Rows[j].Cells[1].Value);
                        double A = 0.0;
                        A = (Convert.ToDouble(tableWagonsAndTransit.Rows[j].Cells[2 + i * 3].Value) * 100) / Convert.ToInt32(tableWagonsAndTransit.Rows[j].Cells[1].Value);
                        tableWagonsAndTransit.Rows[j].Cells[4 + i * 3].Value = string.Format("{0:f3}", A - 100);
                    }
                    catch
                    {
                        tableWagonsAndTransit.Rows[j].Cells[3 + i * 3].Value = 0;
                        tableWagonsAndTransit.Rows[j].Cells[4 + i * 3].Value = "0.000";
                    }
                }
            }
        }

        private void numericUpDownWagons_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownWagons.Value > WagonsAndTransinDataSet.Tables[0].Rows.Count)
            {
                int count = WagonsAndTransinDataSet.Tables[0].Rows.Count;
                foreach (DataTable tables in WagonsAndTransinDataSet.Tables)
                {
                    for (int i = count; i < numericUpDownWagons.Value; i++)
                    {
                        tables.Rows.Add();
                    }
                }
            }
            else if (numericUpDownWagons.Value < WagonsAndTransinDataSet.Tables[0].Rows.Count)
            {
                int count = WagonsAndTransinDataSet.Tables[0].Rows.Count;
                foreach (DataTable tables in WagonsAndTransinDataSet.Tables)
                {
                    for (int i = count; i > numericUpDownWagons.Value; i--)
                    {
                        tables.Rows.Remove(tables.Rows[i - 1]);
                    }
                }
            }

        }

        private void numericUpDownTransit_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownTransit.Value > WagonsAndTransinDataSet.Tables.Count)
            {
                int count = WagonsAndTransinDataSet.Tables.Count;
                for (int i = count; i < numericUpDownTransit.Value; i++)
                {
                    CreateTable(i);
                }
            }
            else
            {
                int count = WagonsAndTransinDataSet.Tables.Count;
                for (int i = count; i > numericUpDownTransit.Value; i--)
                {
                    WagonsAndTransinDataSet.Tables.Remove($"{i}");
                    menuStripTransitButton.Items.Remove(menuStripTransitButton.Items[i - 1]);
                }
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            calculationTable();
        }

        private void buttonSaveData_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        public DataSet callData()
        {
            return WagonsAndTransinDataSet;
        }
        public (List<Double>, List<Double>) calculateResult()
        {
            List<Double> result = new List<Double>();
            List<Double> maxDelta = new List<Double>();

            for (int i = 0; i < WagonsAndTransinDataSet.Tables.Count; i++)
            {
                if (i == 0)
                {
                    result.Add(0);
                }
                result.Add(0);
                result.Add(0);
                result.Add(0);
                maxDelta.Add(0);
                maxDelta.Add(0);
                for (int j = 0; j < WagonsAndTransinDataSet.Tables[0].Rows.Count; j++)
                {
                    if (i == 0)
                    {
                        result[0] += Convert.ToInt32(WagonsAndTransinDataSet.Tables[i].Rows[j].ItemArray[1]);
                    }
                    result[1 + i * 3] = Convert.ToInt32(WagonsAndTransinDataSet.Tables[i].Rows[j].ItemArray[2]);
                    if (Math.Abs(maxDelta[i * 2]) < Math.Abs(Convert.ToDouble(WagonsAndTransinDataSet.Tables[i].Rows[j].ItemArray[3])))
                    {
                        maxDelta[i * 2] = Convert.ToDouble(WagonsAndTransinDataSet.Tables[i].Rows[j].ItemArray[3]);
                    }
                    if (Math.Abs(maxDelta[i * 2 + 1]) < Math.Abs(Convert.ToDouble(WagonsAndTransinDataSet.Tables[i].Rows[j].ItemArray[4])))
                    {
                        maxDelta[i * 2 + 1] = Convert.ToDouble(WagonsAndTransinDataSet.Tables[i].Rows[j].ItemArray[4]);
                    }
                }
            }

            for (int i = 2; i < tableWagonsAndTransit.Columns.Count; i++)
            {
                if (i % 3 == 2)
                {
                    result[i] = result[i - 1] - result[0];
                }
                else if (i % 3 == 0)
                {
                    result[i] = (result[i - 2] * 100) / (double)result[0] - 100;
                    i++;
                }
            }

            return (result, maxDelta);
        }
    }
}
