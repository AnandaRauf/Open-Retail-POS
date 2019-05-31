﻿/**
 * Copyright (C) 2017 Kamarudin (http://coding4ever.net/)
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not
 * use this file except in compliance with the License. You may obtain a copy of
 * the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under
 * the License.
 *
 * The latest version of this file can be found at https://github.com/rudi-krsoftware/open-retail
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OpenRetail.Helper;
using Microsoft.Reporting.WinForms;
using OpenRetail.Model;
using OpenRetail.Helper.UserControl;

namespace OpenRetail.Helper.UI.Template
{
    public partial class FrmSettingReportStandard : Form
    {
        private string _toolTip;

        public FrmSettingReportStandard()
        {
            InitializeComponent();
            ColorManagerHelper.SetTheme(this, this);

            dtpTanggalMulai.Value = DateTime.Today;
            dtpTanggalSelesai.Value = DateTime.Today;  
        }

        protected void SetHeader(string header)
        {
            this.Text = header;
            this.lblHeader.Text = header;
        }

        protected void SetCheckBoxTitle(string title)
        {
            this.chkBoxTitle.Text = title;
        }

        protected void SetToolTip(string toolTip)
        {
            this._toolTip = toolTip;
            txtKeyword.Text = this._toolTip;
        }

        /// <summary>
        /// Method protected untuk mengeset ulang ukuran form
        /// </summary>
        /// <param name="newSize">Ukuran form standar dikurangi dengan nilai newSize</param>
        protected void ReSize(int newSize)
        {
            this.Size = new Size(this.Width - newSize, this.Height);
        }

        protected void ShowReport(string header, string reportName, ReportDataSource reportDataSource, IEnumerable<ReportParameter> parameters = null)
        {
            var frmPreview = new FrmPreviewReport(header, reportName, reportDataSource, parameters);
            frmPreview.ShowDialog();
        }

        protected void ShowReport(string header, string reportName, IList<ReportDataSource> reportDataSources, IEnumerable<ReportParameter> parameters = null)
        {
            var frmPreview = new FrmPreviewReport(header, reportName, reportDataSources, parameters);
            frmPreview.ShowDialog();
        }

        protected IList<string> GetSupplierId(IList<Supplier> listOfSupplier)
        {
            var listOfSupplierId = new List<string>();

            for (var i = 0; i < chkListBox.Items.Count; i++)
            {
                if (chkListBox.GetItemChecked(i))
                {
                    var supplier = listOfSupplier[i];
                    listOfSupplierId.Add(supplier.supplier_id);
                }
            }

            return listOfSupplierId;
        }

        protected IList<string> GetCustomerId(IList<Customer> listOfCustomer)
        {
            var listOfCustomerId = new List<string>();

            for (var i = 0; i < chkListBox.Items.Count; i++)
            {
                if (chkListBox.GetItemChecked(i))
                {
                    var customer = listOfCustomer[i];
                    listOfCustomerId.Add(customer.customer_id);
                }
            }

            return listOfCustomerId;
        }

        protected IList<string> GetGolonganId(IList<Golongan> listOfGolongan)
        {
            var listOfGolonganId = new List<string>();

            for (var i = 0; i < chkListBox.Items.Count; i++)
            {
                if (chkListBox.GetItemChecked(i))
                {
                    var golongan = listOfGolongan[i];
                    listOfGolonganId.Add(golongan.golongan_id);
                }
            }

            return listOfGolonganId;
        }

        /// <summary>
        /// Method override untuk menghandle proses preview
        /// </summary>
        protected virtual void Preview()
        {
        }

        protected virtual void PilihCheckBoxTampilkanNota()
        {
        }

        protected virtual void Cari()
        {
        }

        protected virtual void PilihSemua()
        {
            for (int i = 0; i < chkListBox.Items.Count; i++)
            {
                chkListBox.SetItemChecked(i, chkPilihSemua.Checked);
            }
        }

        protected virtual void PilihCheckBoxTitle()
        {
            txtKeyword.Enabled = chkBoxTitle.Checked;
            chkListBox.Enabled = chkBoxTitle.Checked;
            chkPilihSemua.Enabled = chkBoxTitle.Checked;

            if (!chkBoxTitle.Checked)
            {
                for (int i = 0; i < chkListBox.Items.Count; i++)
                {
                    chkListBox.SetItemChecked(i, false);
                }

                chkPilihSemua.Checked = false;
                txtKeyword.Text = _toolTip;
            }
        }

        /// <summary>
        /// Method override untuk menghandle proses selesai
        /// </summary>
        protected virtual void Selesai()
        {
            this.Close();
        }                

        private void chkBoxTitle_CheckedChanged(object sender, EventArgs e)
        {
            PilihCheckBoxTitle();
        }

        private void chkTampilkanNota_CheckedChanged(object sender, EventArgs e)
        {
            PilihCheckBoxTampilkanNota();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Preview();
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            Selesai();
        }        

        private void chkPilihSemua_CheckedChanged(object sender, EventArgs e)
        {
            PilihSemua();
        }

        private void FrmSettingReportStandard_KeyDown(object sender, KeyEventArgs e)
        {
            if (KeyPressHelper.IsShortcutKey(Keys.F10, e))
            {
                Preview();

                e.SuppressKeyPress = true;
            }                
        }

        private void FrmSettingReportStandard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressHelper.IsEsc(e))
                Selesai();
        }

        private void txtKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressHelper.IsEnter(e))
                Cari();
        }

        private void txtKeyword_Leave(object sender, EventArgs e)
        {
            var txt = (AdvancedTextbox)sender;

            if (txt.Text.Length == 0)
                txt.Text = _toolTip;
        }

        private void txtKeyword_Enter(object sender, EventArgs e)
        {
            ((AdvancedTextbox)sender).Clear();
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            var txt = (AdvancedTextbox)sender;

            if (txt.Text.Length == 0)
                Cari();
        }
    }
}
