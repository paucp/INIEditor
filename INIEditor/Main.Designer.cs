﻿namespace INIEditor
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.NameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValueHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CommentHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonNewE = new System.Windows.Forms.Button();
            this.buttonEditE = new System.Windows.Forms.Button();
            this.buttonDeleteE = new System.Windows.Forms.Button();
            this.buttonDelelteG = new System.Windows.Forms.Button();
            this.buttonEditG = new System.Windows.Forms.Button();
            this.buttonNewG = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearchNext = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(901, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.saveAsToolStripMenuItem.Text = "SaveAs";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(108, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHeader,
            this.ValueHeader,
            this.CommentHeader});
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 58);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(877, 461);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListView1_KeyDown);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView1_MouseDoubleClick);
            // 
            // NameHeader
            // 
            this.NameHeader.Text = "Name";
            this.NameHeader.Width = 280;
            // 
            // ValueHeader
            // 
            this.ValueHeader.Text = "Value";
            this.ValueHeader.Width = 300;
            // 
            // CommentHeader
            // 
            this.CommentHeader.Text = "Comment";
            this.CommentHeader.Width = 290;
            // 
            // buttonNewE
            // 
            this.buttonNewE.Enabled = false;
            this.buttonNewE.Location = new System.Drawing.Point(785, 525);
            this.buttonNewE.Name = "buttonNewE";
            this.buttonNewE.Size = new System.Drawing.Size(104, 30);
            this.buttonNewE.TabIndex = 2;
            this.buttonNewE.Text = "New Entry";
            this.buttonNewE.UseVisualStyleBackColor = true;
            this.buttonNewE.Click += new System.EventHandler(this.buttonNewE_Click);
            // 
            // buttonEditE
            // 
            this.buttonEditE.Enabled = false;
            this.buttonEditE.Location = new System.Drawing.Point(698, 525);
            this.buttonEditE.Name = "buttonEditE";
            this.buttonEditE.Size = new System.Drawing.Size(81, 30);
            this.buttonEditE.TabIndex = 3;
            this.buttonEditE.Text = "Edit Entry";
            this.buttonEditE.UseVisualStyleBackColor = true;
            this.buttonEditE.Click += new System.EventHandler(this.buttonEditE_Click);
            // 
            // buttonDeleteE
            // 
            this.buttonDeleteE.Enabled = false;
            this.buttonDeleteE.Location = new System.Drawing.Point(582, 525);
            this.buttonDeleteE.Name = "buttonDeleteE";
            this.buttonDeleteE.Size = new System.Drawing.Size(110, 30);
            this.buttonDeleteE.TabIndex = 4;
            this.buttonDeleteE.Text = "Delete Entry";
            this.buttonDeleteE.UseVisualStyleBackColor = true;
            this.buttonDeleteE.Click += new System.EventHandler(this.buttonDeleteE_Click);
            // 
            // buttonDelelteG
            // 
            this.buttonDelelteG.Enabled = false;
            this.buttonDelelteG.Location = new System.Drawing.Point(582, 561);
            this.buttonDelelteG.Name = "buttonDelelteG";
            this.buttonDelelteG.Size = new System.Drawing.Size(110, 30);
            this.buttonDelelteG.TabIndex = 7;
            this.buttonDelelteG.Text = "Delete Group";
            this.buttonDelelteG.UseVisualStyleBackColor = true;
            this.buttonDelelteG.Click += new System.EventHandler(this.ButtonDelelteG_Click);
            // 
            // buttonEditG
            // 
            this.buttonEditG.Enabled = false;
            this.buttonEditG.Location = new System.Drawing.Point(698, 561);
            this.buttonEditG.Name = "buttonEditG";
            this.buttonEditG.Size = new System.Drawing.Size(81, 30);
            this.buttonEditG.TabIndex = 6;
            this.buttonEditG.Text = "Edit Group";
            this.buttonEditG.UseVisualStyleBackColor = true;
            this.buttonEditG.Click += new System.EventHandler(this.ButtonEditG_Click);
            // 
            // buttonNewG
            // 
            this.buttonNewG.Enabled = false;
            this.buttonNewG.Location = new System.Drawing.Point(785, 561);
            this.buttonNewG.Name = "buttonNewG";
            this.buttonNewG.Size = new System.Drawing.Size(104, 30);
            this.buttonNewG.TabIndex = 5;
            this.buttonNewG.Text = "New Group";
            this.buttonNewG.UseVisualStyleBackColor = true;
            this.buttonNewG.Click += new System.EventHandler(this.ButtonNewG_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Enabled = false;
            this.textBoxSearch.Location = new System.Drawing.Point(213, 27);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(579, 25);
            this.textBoxSearch.TabIndex = 8;
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxSearch_KeyDown);
            // 
            // buttonSearchNext
            // 
            this.buttonSearchNext.Enabled = false;
            this.buttonSearchNext.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchNext.Location = new System.Drawing.Point(798, 27);
            this.buttonSearchNext.Name = "buttonSearchNext";
            this.buttonSearchNext.Size = new System.Drawing.Size(91, 25);
            this.buttonSearchNext.TabIndex = 9;
            this.buttonSearchNext.Text = "Search Next";
            this.buttonSearchNext.UseVisualStyleBackColor = true;
            this.buttonSearchNext.Click += new System.EventHandler(this.ButtonSearchNext_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Name",
            "Value",
            "Comment"});
            this.comboBox1.Location = new System.Drawing.Point(86, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 25);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Search by:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(901, 604);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonSearchNext);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonDelelteG);
            this.Controls.Add(this.buttonEditG);
            this.Controls.Add(this.buttonNewG);
            this.Controls.Add(this.buttonDeleteE);
            this.Controls.Add(this.buttonEditE);
            this.Controls.Add(this.buttonNewE);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INIEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader NameHeader;
        private System.Windows.Forms.ColumnHeader ValueHeader;
        private System.Windows.Forms.Button buttonNewE;
        private System.Windows.Forms.Button buttonEditE;
        private System.Windows.Forms.Button buttonDeleteE;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.Button buttonDelelteG;
        private System.Windows.Forms.Button buttonEditG;
        private System.Windows.Forms.Button buttonNewG;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearchNext;
        private System.Windows.Forms.ColumnHeader CommentHeader;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}

