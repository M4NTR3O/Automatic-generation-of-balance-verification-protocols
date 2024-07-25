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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Automatic_generation_of_balance_verification_protocols
{
    public partial class DataWagonsForm : Form
    {
        private DataSet WagonsAndTransinDataSet;
        public DataWagonsForm()
        {
            InitializeComponent(); 
            DoubleBuffered = true;
            WagonsAndTransinDataSet = new DataSet();
            progressBar.Maximum = 1;
            progressBar.Value = 0;
            CreateDGV();
            
        }

        public DataWagonsForm(DataSet table)
        {
            InitializeComponent();
            DoubleBuffered = true;
            if (WagonsAndTransinDataSet != null)
            {
                WagonsAndTransinDataSet.Tables.Clear();
            }
            WagonsAndTransinDataSet = table;
            UpdateDGV();
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
                    (menuStripTransitButton.Items[i / 5] as ToolStripDropDownButton).DropDownItems[i % 5].BackColor = Color.DarkGray;
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

        private void UpdateDGV()
        {
            progressBar.Maximum = WagonsAndTransinDataSet.Tables.Count;
            numericUpDownTransit.Value = WagonsAndTransinDataSet.Tables.Count;
            numericUpDownWagons.Value = WagonsAndTransinDataSet.Tables[0].Rows.Count;
            tableWagonsAndTransit.DataSource = WagonsAndTransinDataSet.Tables[0];
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
            for (int i = 0; i < WagonsAndTransinDataSet.Tables.Count; i++)
            {
                if (i % 5 == 0)
                {
                    ToolStripDropDownButton btn = new ToolStripDropDownButton($"Проезды №{i + 1}-{i + 5}");
                    menuStripTransitButton.Items.Add(btn);
                }
                (menuStripTransitButton.Items[i / 5] as ToolStripDropDownButton).DropDownItems.Add($"Проезд №{i + 1}");
                (menuStripTransitButton.Items[i / 5] as ToolStripDropDownButton).DropDownItems[i % 5].Click += OnClick_menuStripTransitButtons;
                if (i == 0 && checkTableValue(WagonsAndTransinDataSet.Tables[i]))
                {
                    (menuStripTransitButton.Items[i / 5] as ToolStripDropDownButton).DropDownItems[i % 5].BackColor = Color.DarkGreen;
                    progressBar.Value++;
                }
                else if (i == 0)
                {
                    (menuStripTransitButton.Items[i / 5] as ToolStripDropDownButton).DropDownItems[i % 5].BackColor = Color.DarkGray;
                }
                else if (checkTableValue(WagonsAndTransinDataSet.Tables[i]))
                {
                    (menuStripTransitButton.Items[i / 5] as ToolStripDropDownButton).DropDownItems[i % 5].BackColor = Color.LightGreen;
                    progressBar.Value++;
                }
                if (i % 5 == 0 && i != 0)
                {
                    menuStripTransitButton.Items[i / 5 - 1].BackColor = Color.LightGreen;
                    for (int j = 0; j < 5; j++)
                    {
                        if ((menuStripTransitButton.Items[i / 5 - 1] as ToolStripDropDownButton).DropDownItems[j].BackColor == SystemColors.Control)
                        {
                            menuStripTransitButton.Items[i / 5 - 1].BackColor = SystemColors.Control;
                        }
                        else if ((menuStripTransitButton.Items[i / 5 - 1] as ToolStripDropDownButton).DropDownItems[j].BackColor == Color.DarkGreen && (menuStripTransitButton.Items[i / 5 - 1].BackColor == Color.LightGreen))
                        {
                            menuStripTransitButton.Items[i / 5 - 1].BackColor = Color.DarkGreen;
                        }
                        else if ((menuStripTransitButton.Items[i / 5 - 1] as ToolStripDropDownButton).DropDownItems[j].BackColor == Color.DarkGreen && (menuStripTransitButton.Items[i / 5 - 1].BackColor == SystemColors.Control))
                        {
                            menuStripTransitButton.Items[i / 5 - 1].BackColor = Color.DarkGray;
                        }
                    }
                }
            }
            if (WagonsAndTransinDataSet.Tables.Count % 5 > 0)
            {
                menuStripTransitButton.Items[(WagonsAndTransinDataSet.Tables.Count - 1) / 5].BackColor = Color.LightGreen;
                for (int j = 0; j < WagonsAndTransinDataSet.Tables.Count % 5; j++)
                {
                    if ((menuStripTransitButton.Items[(WagonsAndTransinDataSet.Tables.Count - 1) / 5] as ToolStripDropDownButton).DropDownItems[j].BackColor == SystemColors.Control)
                    {
                        menuStripTransitButton.Items[(WagonsAndTransinDataSet.Tables.Count - 1) / 5].BackColor = SystemColors.Control;
                    }
                    else if ((menuStripTransitButton.Items[(WagonsAndTransinDataSet.Tables.Count - 1) / 5] as ToolStripDropDownButton).DropDownItems[j].BackColor == Color.DarkGreen && (menuStripTransitButton.Items[(WagonsAndTransinDataSet.Tables.Count - 1) / 5].BackColor == Color.LightGreen))
                    {
                        menuStripTransitButton.Items[(WagonsAndTransinDataSet.Tables.Count - 1) / 5].BackColor = Color.DarkGreen;
                    }
                    else if ((menuStripTransitButton.Items[(WagonsAndTransinDataSet.Tables.Count - 1) / 5] as ToolStripDropDownButton).DropDownItems[j].BackColor == Color.DarkGreen && (menuStripTransitButton.Items[(WagonsAndTransinDataSet.Tables.Count - 1) / 5].BackColor == SystemColors.Control))
                    {
                        menuStripTransitButton.Items[(WagonsAndTransinDataSet.Tables.Count - 1) / 5].BackColor = Color.DarkGray;
                    }
                }
            }
            CheckProgressBar();
        }

        private void OnClick_menuStripTransitButtons(object sender, EventArgs e)
        {
            for (int j = 0; j < tableWagonsAndTransit.Rows.Count; j++)
            {
                for (int k = 0; k < WagonsAndTransinDataSet.Tables.Count; k++)
                {
                    WagonsAndTransinDataSet.Tables[k].Rows[j].SetField(0, tableWagonsAndTransit.Rows[j].Cells[0].Value);
                    WagonsAndTransinDataSet.Tables[k].Rows[j].SetField(1, tableWagonsAndTransit.Rows[j].Cells[1].Value);
                }
            }
            for (int i = 0; i < menuStripTransitButton.Items.Count; i++)
            {
                if ((menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems.Contains(sender as ToolStripItem))
                {
                    for (int j = 0; j < (menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems.Count; j++)
                    {
                        if ((menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems[j] == (sender as ToolStripItem))
                        {
                            if (checkTableValue(WagonsAndTransinDataSet.Tables[i * 5 + j]))
                            {
                                //menuStripTransitButton.Items[i].BackColor = Color.DarkGreen;
                                (menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems[j].BackColor = Color.DarkGreen;
                            }
                            else
                            {
                                //menuStripTransitButton.Items[i].BackColor = Color.DarkGray;
                                (menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems[j].BackColor = Color.DarkGray;
                            }
                            tableWagonsAndTransit.DataSource = WagonsAndTransinDataSet.Tables[i * 5 + j];
                            tableWagonsAndTransit.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                            tableWagonsAndTransit.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                            tableWagonsAndTransit.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                        }
                        else if ((menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems[j].BackColor == Color.DarkGreen || (menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems[j].BackColor == Color.DarkGray)
                        {
                            if (checkTableValue(WagonsAndTransinDataSet.Tables[i * 5 + j]))
                            {
                                if ((menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems[j].BackColor == Color.DarkGray)
                                {
                                    progressBar.Value++;
                                    CheckProgressBar();
                                }
                                (menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems[j].BackColor = Color.LightGreen;
                            }
                            else
                            {
                                if ((menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems[j].BackColor == Color.DarkGreen)
                                {
                                    progressBar.Value--;
                                    CheckProgressBar();
                                }
                                (menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems[j].BackColor = SystemColors.Control;
                            }
                        }
                    }
                    ToolStripItem[] items = new ToolStripItem[(menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems.Count];
                    ((menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems).CopyTo(items, 0);
                    if (items.Any(s => s.BackColor == SystemColors.Control || s.BackColor == Color.DarkGray))
                    {
                        menuStripTransitButton.Items[i].BackColor = Color.DarkGray;
                    }
                    else
                    {
                        menuStripTransitButton.Items[i].BackColor = Color.DarkGreen;
                    }
                }
                else
                {
                    for (int j = 0; j < (menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems.Count; j++)
                    {
                        if ((menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems[j].BackColor == Color.DarkGreen || (menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems[j].BackColor == Color.DarkGray)
                        {
                            if (checkTableValue(WagonsAndTransinDataSet.Tables[i * 5 + j]))
                            {
                                if ((menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems[j].BackColor == Color.DarkGray)
                                {
                                    progressBar.Value++;
                                    CheckProgressBar();
                                }
                                (menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems[j].BackColor = Color.LightGreen;
                            }
                            else
                            {
                                if ((menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems[j].BackColor == Color.DarkGreen)
                                {
                                    progressBar.Value--;
                                    CheckProgressBar();
                                }
                                (menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems[j].BackColor = SystemColors.Control;
                            }
                        }
                    }
                    ToolStripItem[] items = new ToolStripItem[(menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems.Count];
                    (menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems.CopyTo(items, 0);
                    if (items.Any(s => s.BackColor == SystemColors.Control))
                    {
                        menuStripTransitButton.Items[i].BackColor = SystemColors.Control;
                    }
                    else
                    {
                        menuStripTransitButton.Items[i].BackColor = Color.LightGreen;
                    }
                }
            }
        }

        private void CheckProgressBar()
        {
            if (progressBar.Value == progressBar.Maximum)
            {
                buttonSaveData.Enabled = true;
            }
            else
            {
                buttonSaveData.Enabled = false;
            }
        }

        private DataTable CreateTable(int i)
        {
            DataTable db = new DataTable($"{i + 1}");
            db.Columns.Add("№ вагона");
            db.Columns.Add("Вес в статике");
            db.Columns.Add($"Проезд №{i + 1}");
            db.Columns[1].DataType = typeof(int);
            db.Columns[2].DataType = typeof(int);
            if (i % 5 == 0)
            {
                ToolStripDropDownButton btn = new ToolStripDropDownButton($"Проезды №{i + 1}-{i + 5}");
                menuStripTransitButton.Items.Add(btn);
            }
            (menuStripTransitButton.Items[i / 5] as ToolStripDropDownButton).DropDownItems.Add($"Проезд №{i + 1}");
            (menuStripTransitButton.Items[i / 5] as ToolStripDropDownButton).DropDownItems[i % 5].Click += OnClick_menuStripTransitButtons;
            db.Columns.Add("Погрешность абсолютная");
            db.Columns.Add("Погрешность относительная");
            db.Columns[3].DataType = typeof(int);
            WagonsAndTransinDataSet.Tables.Add(db);
            foreach (var wagons in WagonsAndTransinDataSet.Tables[0].Rows)
            {
                db.Rows.Add();
            }
            return db;
        }

        private void updateTable()
        {
            for (int i = 1; i < 3; i++)
            {
                for (int j = 0; j < tableWagonsAndTransit.Rows.Count; j++)
                {
                    try {
                        Convert.ToInt32(tableWagonsAndTransit.Rows[j].Cells[i].Value);
                    }
                    catch
                    {
                        tableWagonsAndTransit.Rows[j].Cells[i].Value = DBNull.Value;
                        tableWagonsAndTransit.Rows[j].Cells[3].Value = DBNull.Value;
                        tableWagonsAndTransit.Rows[j].Cells[4].Value = DBNull.Value;
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
                progressBar.Value = 0;
                CheckProgressBar();
                foreach (ToolStripDropDownButton item in menuStripTransitButton.Items)
                {
                    if (item.BackColor == Color.DarkGreen || item.BackColor == Color.DarkGray)
                    {
                        item.BackColor = Color.DarkGray;
                        foreach (ToolStripItem stripItem in item.DropDownItems)
                        {
                            if (stripItem.BackColor == Color.DarkGreen || stripItem.BackColor == Color.DarkGray)
                            {
                                stripItem.BackColor = Color.DarkGray;
                            }
                            else
                            {
                                stripItem.BackColor = SystemColors.Control;
                            }
                        }
                    }
                    else
                    {
                        item.BackColor = SystemColors.Control;
                        foreach (ToolStripItem stripItem in item.DropDownItems)
                        {
                             stripItem.BackColor = SystemColors.Control;
                        }
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
                for (int i = 0; i < count / 5; i++)
                {
                    ToolStripItem[] toolStripItems = new ToolStripItem[(menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems.Count];
                    (menuStripTransitButton.Items[i] as ToolStripDropDownButton).DropDownItems.CopyTo(toolStripItems, 0);
                    if (toolStripItems.Any(s => s.BackColor == Color.DarkGray || s.BackColor == Color.DarkGreen))
                    {
                        menuStripTransitButton.Items[i].BackColor = Color.DarkGray;
                    }
                }
            }
            else if (numericUpDownTransit.Value < WagonsAndTransinDataSet.Tables.Count)
            {
                int count = WagonsAndTransinDataSet.Tables.Count;
                for (int i = count; i > numericUpDownTransit.Value; i--)
                {
                    if (checkTableValue(WagonsAndTransinDataSet.Tables[i-1]))
                    {
                        progressBar.Value -= 1;
                    }
                    if (WagonsAndTransinDataSet.Tables[i - 1] == tableWagonsAndTransit.DataSource)
                    {
                        tableWagonsAndTransit.DataSource = WagonsAndTransinDataSet.Tables[i - 2];
                        if ((menuStripTransitButton.Items[(i - 2) / 5] as ToolStripDropDownButton).DropDownItems[(i - 2) % 5].BackColor == Color.LightGreen)
                        {
                            (menuStripTransitButton.Items[(i - 2) / 5] as ToolStripDropDownButton).DropDownItems[(i - 2) % 5].BackColor = Color.DarkGreen;
                        }
                        else
                        {
                            (menuStripTransitButton.Items[(i - 2) / 5] as ToolStripDropDownButton).DropDownItems[(i - 2) % 5].BackColor = Color.DarkGray;
                        }
                        ToolStripItem[] toolStripItems = new ToolStripItem[(menuStripTransitButton.Items[(i - 2) / 5] as ToolStripDropDownButton).DropDownItems.Count];
                        (menuStripTransitButton.Items[(i - 2) / 5] as ToolStripDropDownButton).DropDownItems.CopyTo(toolStripItems, 0);
                        if (toolStripItems.All(s => s.BackColor == Color.LightGreen || s.BackColor == Color.DarkGreen))
                        {
                            menuStripTransitButton.Items[(i - 2) / 5].BackColor = Color.DarkGreen;
                        }
                        else
                        {
                            menuStripTransitButton.Items[(i - 2) / 5].BackColor = Color.DarkGray;
                        }
                    }
                    WagonsAndTransinDataSet.Tables.Remove($"{i}");
                    if (i % 5 - 1 == 0)
                    {
                        menuStripTransitButton.Items.Remove(menuStripTransitButton.Items[i / 5]);
                    }
                    else
                    {
                        (menuStripTransitButton.Items[(i - 1) / 5] as ToolStripDropDownButton).DropDownItems.RemoveAt((i - 1) % 5);
                    }
                }
            }
            progressBar.Maximum = (int)numericUpDownTransit.Value;
            CheckProgressBar();
        }

        private void buttonSaveData_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public DataSet callData()
        {
            return WagonsAndTransinDataSet;
        }

        public (Dictionary<string, double>, Dictionary<string, double>) calculateResult()
        {
            Dictionary<string, double> result = new Dictionary<string, double>();
            Dictionary<string, double> maxDelta = new Dictionary<string, double>();

            for (int i = 0; i < WagonsAndTransinDataSet.Tables.Count; i++)
            {
                if (i == 0)
                {
                    result.Add("i" + i.ToString(), 0);
                }
                result.Add("i" + (i * 3 + 1).ToString(), 0);
                result.Add("i" + (i * 3 + 2).ToString(), 0);
                result.Add("i" + (i * 3 + 3).ToString(), 0);
                maxDelta.Add("i" + (i * 2).ToString(), 0);
                maxDelta.Add("i" + (i * 2 + 1).ToString(), 0);
                for (int j = 0; j < WagonsAndTransinDataSet.Tables[0].Rows.Count; j++)
                {
                    if (i == 0)
                    {
                        result["i" + 0.ToString()] += Convert.ToInt32(WagonsAndTransinDataSet.Tables[i].Rows[j].ItemArray[1]);
                    }
                    result["i" + (1 + i * 3).ToString()] += Convert.ToInt32(WagonsAndTransinDataSet.Tables[i].Rows[j].ItemArray[2]);
                    if (Math.Abs(maxDelta["i" + (i * 2).ToString()]) < Math.Abs(Convert.ToDouble(WagonsAndTransinDataSet.Tables[i].Rows[j].ItemArray[3])))
                    {
                        maxDelta["i" + (i * 2).ToString()] = Convert.ToDouble(WagonsAndTransinDataSet.Tables[i].Rows[j].ItemArray[3]);
                    }
                    if (Math.Abs(maxDelta["i" + (i * 2 + 1).ToString()]) < Math.Abs(Convert.ToDouble(WagonsAndTransinDataSet.Tables[i].Rows[j].ItemArray[4])))
                    {
                        maxDelta["i" + (i * 2 + 1).ToString()] = Convert.ToDouble(WagonsAndTransinDataSet.Tables[i].Rows[j].ItemArray[4]);
                    }
                }
            }

            for (int i = 2; i < result.Count; i++)
            {
                if (i % 3 == 2)
                {
                    result["i" + i.ToString()] = Math.Round(result["i" + (i - 1).ToString()] - result["i0"], 3);
                }
                else if (i % 3 == 0)
                {
                    result["i" + i.ToString()] = Math.Round((result["i" + (i - 2).ToString()] * 100) / (double)result["i0"] - 100, 3);
                    i++;
                }
            }

            return (result, maxDelta);
        }
        private bool check3ColsTable(DataTable db)
        {
            foreach (DataRow row in db.Rows)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (row.ItemArray[i].ToString() == "")
                    {
                        updateTable();
                        return false;
                    }
                    if (i > 1)
                    {
                        try
                        {
                            Convert.ToInt32(row.ItemArray[i]);
                        }
                        catch
                        {
                            updateTable();
                            MessageBox.Show("Введено неверное значение");
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private bool checkTableValue(DataTable db)
        {
            foreach (DataRow row in db.Rows)
            {
                for (int i = 0; i < db.Columns.Count; i++)
                {
                    if (row.ItemArray[i].ToString() == "")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool checkSet()
        {
            foreach (DataTable db in WagonsAndTransinDataSet.Tables) 
            {
                if (!checkTableValue(db))
                {
                    return false;
                }
            }
            return true;
        }

        private void tableWagonsAndTransit_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (check3ColsTable(tableWagonsAndTransit.DataSource as DataTable))
            {
                calculationTable();
                if (checkTableValue(tableWagonsAndTransit.DataSource as DataTable))
                {
                    foreach(ToolStripDropDownButton item in menuStripTransitButton.Items)
                    {
                        if (item.BackColor == Color.DarkGray)
                        {
                            foreach (ToolStripItem stripitem in item.DropDownItems)
                            {
                                if (stripitem.BackColor == Color.DarkGray)
                                {
                                    stripitem.BackColor = Color.DarkGreen;
                                    progressBar.Value++;
                                    CheckProgressBar();
                                    break;
                                }
                            }
                            ToolStripItem[] toolStrips = new ToolStripItem[item.DropDownItems.Count];
                            item.DropDownItems.CopyTo(toolStrips, 0);
                            if(toolStrips.Any(s => s.BackColor == SystemColors.Control)){
                                item.BackColor = Color.DarkGray;
                            }
                            else
                            {
                                item.BackColor = Color.DarkGreen;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (ToolStripDropDownButton item in menuStripTransitButton.Items)
                {
                    if (item.BackColor == Color.DarkGreen || item.BackColor == Color.DarkGray)
                    {
                        foreach (ToolStripItem stripitem in item.DropDownItems)
                        {
                            if (stripitem.BackColor == Color.DarkGreen)
                            {
                                item.BackColor = Color.DarkGray;
                                stripitem.BackColor = Color.DarkGray;
                                progressBar.Value--;
                                CheckProgressBar();
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
        }

        private void menuStripTransitButton_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            
        }
    }
}
