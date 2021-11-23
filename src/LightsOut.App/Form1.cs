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
        private readonly string _winMessage = "Congratulations you turned all the lights off! You win :)";
        private readonly string _canNotStartProperlyMessage = "Game can not start properly. Please start the game again.";

        private readonly Color _lightOn = Color.FromArgb(142, 251, 142);
        private readonly Color _lightOff = Color.FromArgb(0, 102, 0);

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            LightsOutApiClient lightsOutApiClient = new LightsOutApiClient("localhost", "5000");
            var gameSettings = await lightsOutApiClient.GetGameSettings(1);

            initBoard(gameSettings);

            if (isAllLightsOff())
            {
                MessageBox.Show(_canNotStartProperlyMessage);
                dgvBoard.Rows.Clear();
                return;
            }
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

                    dgvCell.Style.BackColor = (val == 1 ? _lightOn : _lightOff);
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

            if (isAllLightsOff())
            {
                MessageBox.Show(_winMessage);
                dgvBoard.Rows.Clear();
            }
        }

        private void toggleCellValue(DataGridViewCell cell)
        {
            cell.Value = ((int)cell.Value == 1 ? 0 : 1);
            cell.Style.BackColor = ((int)cell.Value == 1 ? _lightOn : _lightOff);
        }

        private void dgvBoard_SelectionChanged(object sender, EventArgs e)
        {
            dgvBoard.ClearSelection();
        }

        private bool isAllLightsOff()
        {
            for (int row = 0; row < dgvBoard.RowCount; row++)
            {
                for(int col = 0; col < dgvBoard.ColumnCount; col++)
                {
                    int value = (int)dgvBoard.Rows[row].Cells[col].Value;

                    if(value == 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        //TODO Check if user wins after each cell click.
        //TODO Select board size.
        //TODO Include in the solution any documentation and test cases required and any tests written for this solution.
        //TODO Sql scripts
    }
}
