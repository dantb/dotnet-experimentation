namespace ResultsTableTransformation
{
    partial class ResultsViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDoStuff = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ModuleNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnDoStuff
            // 
            this.btnDoStuff.Location = new System.Drawing.Point(23, 12);
            this.btnDoStuff.Name = "btnDoStuff";
            this.btnDoStuff.Size = new System.Drawing.Size(160, 129);
            this.btnDoStuff.TabIndex = 0;
            this.btnDoStuff.Text = "Do stuff";
            this.btnDoStuff.UseVisualStyleBackColor = true;
            this.btnDoStuff.Click += new System.EventHandler(this.btnDoStuff_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ModuleNameCol,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(46, 190);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(2026, 1120);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ModuleNameCol
            // 
            this.ModuleNameCol.Text = "ModuleName";
            this.ModuleNameCol.Width = 200;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Submitted";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "90-100";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "80-89";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "70-79";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "60-69";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "55-59";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "50-55";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "40-49";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "30-39";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "20-29";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "0-19";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2422, 1636);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnDoStuff);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDoStuff;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ModuleNameCol;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
    }
}

