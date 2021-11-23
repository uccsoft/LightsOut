
namespace LightsOut.App
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.dgvBoard = new System.Windows.Forms.DataGridView();
            this.cbBoardSize = new System.Windows.Forms.ComboBox();
            this.lbBoardSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(179, 27);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // dgvBoard
            // 
            this.dgvBoard.AllowUserToAddRows = false;
            this.dgvBoard.AllowUserToDeleteRows = false;
            this.dgvBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBoard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBoard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBoard.ColumnHeadersVisible = false;
            this.dgvBoard.Location = new System.Drawing.Point(21, 64);
            this.dgvBoard.Name = "dgvBoard";
            this.dgvBoard.RowHeadersVisible = false;
            this.dgvBoard.RowTemplate.Height = 25;
            this.dgvBoard.Size = new System.Drawing.Size(767, 365);
            this.dgvBoard.TabIndex = 1;
            this.dgvBoard.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBoard_CellClick);
            this.dgvBoard.SelectionChanged += new System.EventHandler(this.dgvBoard_SelectionChanged);
            // 
            // cbBoardSize
            // 
            this.cbBoardSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoardSize.FormattingEnabled = true;
            this.cbBoardSize.Items.AddRange(new object[] {
            "5 x 5",
            "8 x 8",
            "10 x 10"});
            this.cbBoardSize.Location = new System.Drawing.Point(91, 27);
            this.cbBoardSize.Name = "cbBoardSize";
            this.cbBoardSize.Size = new System.Drawing.Size(82, 23);
            this.cbBoardSize.TabIndex = 2;
            // 
            // lbBoardSize
            // 
            this.lbBoardSize.AutoSize = true;
            this.lbBoardSize.Location = new System.Drawing.Point(21, 30);
            this.lbBoardSize.Name = "lbBoardSize";
            this.lbBoardSize.Size = new System.Drawing.Size(64, 15);
            this.lbBoardSize.TabIndex = 3;
            this.lbBoardSize.Text = "Board Size:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbBoardSize);
            this.Controls.Add(this.cbBoardSize);
            this.Controls.Add(this.dgvBoard);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Lights Out Game";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridView dgvBoard;
        private System.Windows.Forms.ComboBox cbBoardSize;
        private System.Windows.Forms.Label lbBoardSize;
    }
}

