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
    public partial class FrmEntryDropshipper : FrmEntryStandard
    {        
        private IDropshipperBll _bll = null; // deklarasi objek business logic layer 
        private Dropshipper _dropshipper = null;
        private bool _isNewData = false;

        public IListener Listener { private get; set; }

        public FrmEntryDropshipper(string header, IDropshipperBll bll)
            : base()
        {
            InitializeComponent();
            ColorManagerHelper.SetTheme(this, this);

            base.SetHeader(header);
            this._bll = bll;
            this._isNewData = true;
        }

        public FrmEntryDropshipper(string header, Dropshipper dropshipper, IDropshipperBll bll)
            : base()
        {
            InitializeComponent();
            ColorManagerHelper.SetTheme(this, this);

            base.SetHeader(header);
            base.SetButtonSelesaiToBatal();
            this._bll = bll;
            this._dropshipper = dropshipper;

            txtDropshipper.Text = this._dropshipper.nama_dropshipper;
            txtAlamat.Text = this._dropshipper.alamat;
            txtTelepon.Text = this._dropshipper.telepon;
        }

        protected override void Simpan()
        {
            if (_isNewData)
                _dropshipper = new Dropshipper();

            _dropshipper.nama_dropshipper = txtDropshipper.Text;
            _dropshipper.alamat = txtAlamat.Text;
            _dropshipper.telepon = txtTelepon.Text;

            var result = 0;
            var validationError = new ValidationError();

            using (new StCursor(Cursors.WaitCursor, new TimeSpan(0, 0, 0, 0)))
            {
                if (_isNewData)
                    result = _bll.Save(_dropshipper, ref validationError);
                else
                    result = _bll.Update(_dropshipper, ref validationError);

                if (result > 0)
                {
                    Listener.Ok(this, _isNewData, _dropshipper);

                    if (_isNewData)
                    {
                        base.ResetForm(this);
                        txtDropshipper.Focus();
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

        private void txtTelepon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressHelper.IsEnter(e))
                Simpan();
        }        
    }
}
