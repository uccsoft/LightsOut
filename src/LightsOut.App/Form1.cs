using LightsOut.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightsOut.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            LightsOutApiClient lightsOutApiClient = new LightsOutApiClient("localhost", "5000");
            var gameSettings = await lightsOutApiClient.GetGameSettings(1);

            initBoard(gameSettings);
        }

        private void initBoard(GameSettings gameSettings)
        {
            dgvBoard.Rows.Clear();
            dgvBoard.ColumnCount = gameSettings.BoardSize;

            foreach (var row in gameSettings.InitialState)
            {
                var dgvRow = new DataGridViewRow();

                foreach (var val in row)
                {
                    var dgvCell = new DataGridViewTextBoxCell()
                    {
                        Value = val
                    };

                    dgvRow.Cells.Add(dgvCell);
                    dgvCell.ReadOnly = true;
                }

                dgvBoard.Rows.Add(dgvRow);
            }
        }

        private void dgvBoard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //toggle the value of cell
            toggleCellValue(dgvBoard.Rows[e.RowIndex].Cells[e.ColumnIndex]);

            //toggle the value of adjacent cells
            //up
            if(e.RowIndex - 1 >= 0)
            {
                toggleCellValue(dgvBoard.Rows[e.RowIndex - 1].Cells[e.ColumnIndex]);
            }

            //down
            if (e.RowIndex + 1 <= dgvBoard.Rows.Count - 1)
            {
                toggleCellValue(dgvBoard.Rows[e.RowIndex + 1].Cells[e.ColumnIndex]);
            }

            //left
            if (e.ColumnIndex - 1 >= 0)
            {
                toggleCellValue(dgvBoard.Rows[e.RowIndex].Cells[e.ColumnIndex - 1]);
            }

            //right
            if (e.ColumnIndex + 1 <= dgvBoard.Columns.Count - 1)
            {
                toggleCellValue(dgvBoard.Rows[e.RowIndex].Cells[e.ColumnIndex + 1]);
            }
        }

        private void toggleCellValue(DataGridViewCell cell)
        {
            cell.Value = ((int)cell.Value == 0 ? 1 : 0);
        }
    }
}
