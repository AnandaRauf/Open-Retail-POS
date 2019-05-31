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

using OpenRetail.Model;
using OpenRetail.Bll.Api;
using OpenRetail.Helper.UI.Template;
using OpenRetail.Helper;
using ConceptCave.WaitCursor;

namespace OpenRetail.App.Referensi
{
    public partial class FrmEntryGolongan : FrmEntryStandard
    {
        private IGolonganBll _bll = null; // deklarasi objek business logic layer 
        private Golongan _golongan = null;
        private bool _isNewData = false;

        public IListener Listener { private get; set; }

        public FrmEntryGolongan(string header, IGolonganBll bll)
            : base()
        {
            InitializeComponent();
            ColorManagerHelper.SetTheme(this, this);

            base.SetHeader(header);
            this._bll = bll;

            this._isNewData = true;
        }

        public FrmEntryGolongan(string header, Golongan golongan, IGolonganBll bll)
            : base()
        {
            InitializeComponent();
            ColorManagerHelper.SetTheme(this, this);

            base.SetHeader(header);
            base.SetButtonSelesaiToBatal();
            this._bll = bll;
            this._golongan = golongan;

            txtGolongan.Text = this._golongan.nama_golongan;
            txtKeuntungan.Text = this._golongan.persentase_keuntungan.ToString();
            txtDiskon.Text = this._golongan.diskon.ToString();
        }

        protected override void Simpan()
        {
            if (_isNewData)
                _golongan = new Golongan();

            _golongan.nama_golongan = txtGolongan.Text;
            _golongan.persentase_keuntungan = NumberHelper.StringToDouble(txtKeuntungan.Text, true);
            _golongan.diskon = NumberHelper.StringToDouble(txtDiskon.Text, true);

            var result = 0;
            var validationError = new ValidationError();

            using (new StCursor(Cursors.WaitCursor, new TimeSpan(0, 0, 0, 0)))
            {
                if (_isNewData)
                    result = _bll.Save(_golongan, ref validationError);
                else
                    result = _bll.Update(_golongan, ref validationError);

                if (result > 0)
                {
                    Listener.Ok(this, _isNewData, _golongan);

                    if (_isNewData)
                    {
                        base.ResetForm(this);
                        txtGolongan.Focus();

                    }
                    else
                        this.Close();

                }
                else
                {
                    if (validationError.Message.NullToString().Length > 0)
                    {
                        MsgHelper.MsgWarning(validationError.Message);
                        base.SetFocusObject(validationError.PropertyName, this);
                    }
                    else
                        MsgHelper.MsgUpdateError();
                }
            }                            
        }

        private void txtDiskon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressHelper.IsEnter(e))
                Simpan();
        }        
    }
}
