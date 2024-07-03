using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automatic_generation_of_balance_verification_protocols
{
    public partial class DataWagonsForm : Form
    {
        public DataWagonsForm()
        {
            InitializeComponent();
            updateTable();
        }

        public DataWagonsForm(DataGridView table)
        {
            InitializeComponent();
            inputTable(table);
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
                tableWagonsAndTransit.Columns[3 + i * 3].SortMode = DataGridViewColumnSortMode.NotSortable;
                tableWagonsAndTransit.Columns[4 + i * 3].HeaderText = "Погрешность относительная";
                tableWagonsAndTransit.Columns[4 + i * 3].ReadOnly = true;
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
            updateTable();
        }

        private void numericUpDownTransit_ValueChanged(object sender, EventArgs e)
        {
            updateTable();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            calculationTable();
        }

        private void buttonSaveData_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        public DataGridView callData()
        {
            return tableWagonsAndTransit;
        }
        public (List<Double>, List<Double>) calculateResult()
        {
            List<Double> result = new List<Double>();
            List<Double> maxDelta = new List<Double>();

            for (int i = 0; i < tableWagonsAndTransit.Columns.Count - 1; i++)
            {
                result.Add(0);
                if ((i-1) % 3 == 0 || (i - 1) % 3 == 1)
                {
                    maxDelta.Add(0);
                }
            }

            for (int i = 0; i < tableWagonsAndTransit.Rows.Count; i++)
            {
                for (int j = 1; j < tableWagonsAndTransit.Columns.Count; j++)
                {
                    if (j == 1 || (j + 1) % 3 == 0)
                    {
                        result[j - 1] += Convert.ToDouble(tableWagonsAndTransit.Rows[i].Cells[j].Value);
                    }
                    else if (j % 3 == 0)
                    {
                        if (Math.Abs(maxDelta[(j / 3 - 1) * 2]) < Math.Abs(Convert.ToDouble(tableWagonsAndTransit.Rows[i].Cells[j].Value))){
                            maxDelta[(j / 3 - 1) * 2] = Convert.ToDouble(tableWagonsAndTransit.Rows[i].Cells[j].Value);
                        }
                    }
                    else
                    {
                        if (Math.Abs(maxDelta[(j / 3 - 1) * 2 + 1]) < Math.Abs(Convert.ToDouble(tableWagonsAndTransit.Rows[i].Cells[j].Value)))
                        {
                            maxDelta[(j / 3 - 1) * 2 + 1] = Convert.ToDouble(tableWagonsAndTransit.Rows[i].Cells[j].Value);
                        }
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
