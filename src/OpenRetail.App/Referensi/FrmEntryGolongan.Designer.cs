﻿namespace OpenRetail.App.Referensi
{
    partial class FrmEntryGolongan
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGolongan = new OpenRetail.Helper.UserControl.AdvancedTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiskon = new OpenRetail.Helper.UserControl.AdvancedTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKeuntungan = new OpenRetail.Helper.UserControl.AdvancedTextbox();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtGolongan, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtDiskon, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtKeuntungan, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 41);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(347, 79);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Golongan";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGolongan
            // 
            this.txtGolongan.AutoEnter = true;
            this.txtGolongan.Conversion = OpenRetail.Helper.UserControl.EConversion.Normal;
            this.txtGolongan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGolongan.EnterFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtGolongan.LeaveFocusColor = System.Drawing.Color.White;
            this.txtGolongan.LetterOnly = false;
            this.txtGolongan.Location = new System.Drawing.Point(91, 3);
            this.txtGolongan.Name = "txtGolongan";
            this.txtGolongan.NumericOnly = false;
            this.txtGolongan.SelectionText = false;
            this.txtGolongan.Size = new System.Drawing.Size(253, 20);
            this.txtGolongan.TabIndex = 0;
            this.txtGolongan.Tag = "nama_golongan";
            this.txtGolongan.ThousandSeparator = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Diskon";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDiskon
            // 
            this.txtDiskon.AutoEnter = false;
            this.txtDiskon.Conversion = OpenRetail.Helper.UserControl.EConversion.Normal;
            this.txtDiskon.EnterFocusColor = System.Drawing.Color.White;
            this.txtDiskon.LeaveFocusColor = System.Drawing.Color.White;
            this.txtDiskon.LetterOnly = false;
            this.txtDiskon.Location = new System.Drawing.Point(91, 53);
            this.txtDiskon.MaxLength = 5;
            this.txtDiskon.Name = "txtDiskon";
            this.txtDiskon.NumericOnly = true;
            this.txtDiskon.SelectionText = false;
            this.txtDiskon.Size = new System.Drawing.Size(40, 20);
            this.txtDiskon.TabIndex = 2;
            this.txtDiskon.Text = "0";
            this.txtDiskon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiskon.ThousandSeparator = false;
            this.txtDiskon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiskon_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Keuntungan (%)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKeuntungan
            // 
            this.txtKeuntungan.AutoEnter = true;
            this.txtKeuntungan.Conversion = OpenRetail.Helper.UserControl.EConversion.Normal;
            this.txtKeuntungan.EnterFocusColor = System.Drawing.Color.White;
            this.txtKeuntungan.LeaveFocusColor = System.Drawing.Color.White;
            this.txtKeuntungan.LetterOnly = false;
            this.txtKeuntungan.Location = new System.Drawing.Point(91, 28);
            this.txtKeuntungan.MaxLength = 5;
            this.txtKeuntungan.Name = "txtKeuntungan";
            this.txtKeuntungan.NumericOnly = true;
            this.txtKeuntungan.SelectionText = false;
            this.txtKeuntungan.Size = new System.Drawing.Size(40, 20);
            this.txtKeuntungan.TabIndex = 1;
            this.txtKeuntungan.Text = "0";
            this.txtKeuntungan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKeuntungan.ThousandSeparator = false;
            // 
            // FrmEntryGolongan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 161);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "FrmEntryGolongan";
            this.Text = "FrmEntryGolongan";
            this.Controls.SetChildIndex(this.tableLayoutPanel3, 0);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private OpenRetail.Helper.UserControl.AdvancedTextbox txtGolongan;
        private System.Windows.Forms.Label label2;
        private OpenRetail.Helper.UserControl.AdvancedTextbox txtDiskon;
        private System.Windows.Forms.Label label3;
        private Helper.UserControl.AdvancedTextbox txtKeuntungan;
    }
}