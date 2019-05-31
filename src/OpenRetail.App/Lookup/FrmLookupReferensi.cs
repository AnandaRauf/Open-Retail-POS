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
using OpenRetail.Model.RajaOngkir;
using OpenRetail.Helper;
using Syncfusion.Windows.Forms.Grid;
using OpenRetail.Helper.UI.Template;

namespace OpenRetail.App.Lookup
{
    public partial class FrmLookupReferensi : FrmLookupEmptyBody
    {
        private IList<Supplier> _listOfSupplier = null;
        private IList<Customer> _listOfCustomer = null;
        private IList<Dropshipper> _listOfDropshipper = null;
        private IList<Produk> _listOfProduk = null;
        private IList<JenisPengeluaran> _listOfJenisPengeluaran = null;
        private IList<KabupatenAsalRajaOngkir> _listOfKabupatenAsal = null;
        private IList<KabupatenTujuanRajaOngkir> _listOfKabupatenTujuan = null;

        private ReferencesType _referensiType = ReferencesType.Supplier;
        private bool _isShowHargaPembelian = false;

        public IListener Listener { private get; set; }

        public FrmLookupReferensi(string header, IList<JenisPengeluaran> listOfJenisPengeluaran)
            : base()
        {
            InitializeComponent();

            base.SetHeader(header);
            this._listOfJenisPengeluaran = listOfJenisPengeluaran;
            this._referensiType = ReferencesType.JenisPengeluaran;

            InitGridList();
            base.SetActiveBtnPilih(listOfJenisPengeluaran.Count > 0);
        }

        public FrmLookupReferensi(string header, IList<Supplier> listOfSupplier)
            : base()
        {
            InitializeComponent();

            base.SetHeader(header);
            this._listOfSupplier = listOfSupplier;
            this._referensiType = ReferencesType.Supplier;

            InitGridList();
            base.SetActiveBtnPilih(listOfSupplier.Count > 0);
        }

        public FrmLookupReferensi(string header, IList<Customer> listOfCustomer)
            : base()
        {
            InitializeComponent();

            base.SetHeader(header);
            this._listOfCustomer = listOfCustomer;
            this._referensiType = ReferencesType.Customer;

            InitGridList();
            base.SetActiveBtnPilih(listOfCustomer.Count > 0);
        }

        public FrmLookupReferensi(string header, IList<Dropshipper> listOfDropshipper)
            : base()
        {
            InitializeComponent();

            base.SetHeader(header);
            this._listOfDropshipper = listOfDropshipper;
            this._referensiType = ReferencesType.Dropshipper;

            InitGridList();
            base.SetActiveBtnPilih(listOfDropshipper.Count > 0);
        }

        public FrmLookupReferensi(string header, IList<Produk> listOfProduk, bool isShowHargaPembelian = false)
            : base()
        {
            InitializeComponent();

            base.SetHeader(header);
            this._listOfProduk = listOfProduk;
            this._referensiType = ReferencesType.Produk;
            this._isShowHargaPembelian = isShowHargaPembelian;

            InitGridList();
            base.SetActiveBtnPilih(listOfProduk.Count > 0);
        }

        public FrmLookupReferensi(string header, IList<KabupatenAsalRajaOngkir> listOfKabupatenAsal)
            : base()
        {
            InitializeComponent();

            base.SetHeader(header);
            this._listOfKabupatenAsal = listOfKabupatenAsal;
            this._referensiType = ReferencesType.KabupatenAsal;

            InitGridList();
            base.SetActiveBtnPilih(listOfKabupatenAsal.Count > 0);
        }

        public FrmLookupReferensi(string header, IList<KabupatenTujuanRajaOngkir> listOfKabupatenTujuan)
            : base()
        {
            InitializeComponent();

            base.SetHeader(header);
            this._listOfKabupatenTujuan = listOfKabupatenTujuan;
            this._referensiType = ReferencesType.KabupatenTujuan;

            InitGridList();
            base.SetActiveBtnPilih(listOfKabupatenTujuan.Count > 0);
        }

        private void InitGridList()
        {
            var gridListProperties = new List<GridListControlProperties>();

            gridListProperties.Add(new GridListControlProperties { Header = "No", Width = 30 });

            var listCount = 0;

            switch (this._referensiType)
            {
                case ReferencesType.JenisPengeluaran:
                    gridListProperties.Add(new GridListControlProperties { Header = "Jenis Biaya" });

                    GridListControlHelper.InitializeGridListControl<JenisPengeluaran>(this.gridList, _listOfJenisPengeluaran, gridListProperties);
                    this.gridList.Grid.QueryCellInfo += GridJenisPengeluaran_QueryCellInfo;

                    listCount = _listOfJenisPengeluaran.Count;

                    break;

                case ReferencesType.Customer:
                    gridListProperties.Add(new GridListControlProperties { Header = "Nama Customer", Width = 200 });
                    gridListProperties.Add(new GridListControlProperties { Header = "Alamat" });

                    GridListControlHelper.InitializeGridListControl<Customer>(this.gridList, _listOfCustomer, gridListProperties);
                    this.gridList.Grid.QueryCellInfo += GridCustomer_QueryCellInfo;

                    listCount = _listOfCustomer.Count;

                    break;

                case ReferencesType.Supplier:
                    gridListProperties.Add(new GridListControlProperties { Header = "Nama Supplier", Width = 200 });
                    gridListProperties.Add(new GridListControlProperties { Header = "Alamat" });

                    GridListControlHelper.InitializeGridListControl<Supplier>(this.gridList, _listOfSupplier, gridListProperties);
                    this.gridList.Grid.QueryCellInfo += GridSupplier_QueryCellInfo;

                    listCount = _listOfSupplier.Count;
                    break;

                case ReferencesType.Dropshipper:
                    gridListProperties.Add(new GridListControlProperties { Header = "Nama Dropshipper", Width = 200 });
                    gridListProperties.Add(new GridListControlProperties { Header = "Alamat" });

                    GridListControlHelper.InitializeGridListControl<Dropshipper>(this.gridList, _listOfDropshipper, gridListProperties);
                    this.gridList.Grid.QueryCellInfo += GridDropshipper_QueryCellInfo;

                    listCount = _listOfDropshipper.Count;
                    break;

                case ReferencesType.Produk:
                    gridListProperties.Add(new GridListControlProperties { Header = "Kode Produk", Width = 100 });
                    gridListProperties.Add(new GridListControlProperties { Header = "Nama Produk", Width = 260 });
                    gridListProperties.Add(new GridListControlProperties { Header = "Harga", Width = 70 });
                    gridListProperties.Add(new GridListControlProperties { Header = "Stok", Width = 50 });
                    gridListProperties.Add(new GridListControlProperties { Header = "Golongan" });

                    GridListControlHelper.InitializeGridListControl<Produk>(this.gridList, _listOfProduk, gridListProperties);
                    this.gridList.Grid.QueryCellInfo += GridProduk_QueryCellInfo;

                    listCount = _listOfProduk.Count;
                    break;

                case ReferencesType.KabupatenAsal:
                    gridListProperties.Add(new GridListControlProperties { Header = "Provinsi", Width = 250 });
                    gridListProperties.Add(new GridListControlProperties { Header = "Kota/Kabupaten", Width = 250 });
                    gridListProperties.Add(new GridListControlProperties { Header = "Kode Pos" });
                    GridListControlHelper.InitializeGridListControl<KabupatenAsalRajaOngkir>(this.gridList, _listOfKabupatenAsal, gridListProperties);
                    this.gridList.Grid.QueryCellInfo += GridKabupatenAsal_QueryCellInfo;

                    listCount = _listOfKabupatenAsal.Count;
                    break;

                case ReferencesType.KabupatenTujuan:
                    gridListProperties.Add(new GridListControlProperties { Header = "Provinsi", Width = 250 });
                    gridListProperties.Add(new GridListControlProperties { Header = "Kota/Kabupaten", Width = 250 });
                    gridListProperties.Add(new GridListControlProperties { Header = "Kode Pos" });
                    GridListControlHelper.InitializeGridListControl<KabupatenTujuanRajaOngkir>(this.gridList, _listOfKabupatenTujuan, gridListProperties);
                    this.gridList.Grid.QueryCellInfo += GridKabupatenTujuan_QueryCellInfo;

                    listCount = _listOfKabupatenTujuan.Count;
                    break;

                default:
                    break;
            }

            if (listCount > 0)
                this.gridList.SetSelected(0, true);
        }

        private void GridDropshipper_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {            
            if (_listOfDropshipper.Count > 0)
            {
                if (e.RowIndex > 0)
                {
                    var rowIndex = e.RowIndex - 1;

                    if (rowIndex < _listOfDropshipper.Count)
                    {
                        var dropshipper = _listOfDropshipper[rowIndex];

                        switch (e.ColIndex)
                        {
                            case 2:
                                e.Style.CellValue = dropshipper.nama_dropshipper;
                                break;

                            case 3:
                                e.Style.CellValue = dropshipper.alamat;
                                break;

                            default:
                                break;
                        }

                        // we handled it, let the grid know
                        e.Handled = true;
                    }
                }
            }
        }

        private void GridKabupatenTujuan_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {            
            if (_listOfKabupatenTujuan.Count > 0)
            {
                if (e.RowIndex > 0)
                {
                    var rowIndex = e.RowIndex - 1;

                    if (rowIndex < _listOfKabupatenTujuan.Count)
                    {
                        var kabupaten = _listOfKabupatenTujuan[rowIndex];

                        switch (e.ColIndex)
                        {
                            case 2:
                                e.Style.CellValue = kabupaten.Provinsi.nama_provinsi;
                                break;

                            case 3:
                                e.Style.CellValue = kabupaten.nama_kabupaten;
                                break;

                            case 4:
                                e.Style.HorizontalAlignment = GridHorizontalAlignment.Center;
                                e.Style.CellValue = kabupaten.kode_pos;
                                break;

                            default:
                                break;
                        }

                        // we handled it, let the grid know
                        e.Handled = true;
                    }
                }
            }
        }

        private void GridKabupatenAsal_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {            
            if (_listOfKabupatenAsal.Count > 0)
            {
                if (e.RowIndex > 0)
                {
                    var rowIndex = e.RowIndex - 1;

                    if (rowIndex < _listOfKabupatenAsal.Count)
                    {
                        var kabupaten = _listOfKabupatenAsal[rowIndex];

                        switch (e.ColIndex)
                        {
                            case 2:
                                e.Style.CellValue = kabupaten.Provinsi.nama_provinsi;
                                break;

                            case 3:
                                e.Style.CellValue = kabupaten.nama_kabupaten;
                                break;

                            case 4:
                                e.Style.HorizontalAlignment = GridHorizontalAlignment.Center;
                                e.Style.CellValue = kabupaten.kode_pos;
                                break;

                            default:
                                break;
                        }

                        // we handled it, let the grid know
                        e.Handled = true;
                    }
                }
            }
        }

        private void GridJenisPengeluaran_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {            
            if (_listOfJenisPengeluaran.Count > 0)
            {
                if (e.RowIndex > 0)
                {
                    var rowIndex = e.RowIndex - 1;

                    if (rowIndex < _listOfJenisPengeluaran.Count)
                    {
                        var jenisPengeluaran = _listOfJenisPengeluaran[rowIndex];

                        switch (e.ColIndex)
                        {
                            case 2:
                                e.Style.CellValue = jenisPengeluaran.nama_jenis_pengeluaran;
                                break;

                            default:
                                break;
                        }

                        // we handled it, let the grid know
                        e.Handled = true;
                    }
                }
            }
        }

        private void GridCustomer_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            if (_listOfCustomer.Count > 0)
            {
                if (e.RowIndex > 0)
                {
                    var rowIndex = e.RowIndex - 1;

                    if (rowIndex < _listOfCustomer.Count)
                    {
                        var customer = _listOfCustomer[rowIndex];

                        switch (e.ColIndex)
                        {
                            case 2:
                                e.Style.CellValue = customer.nama_customer;
                                break;

                            case 3:
                                e.Style.CellValue = customer.alamat;
                                break;

                            default:
                                break;
                        }

                        // we handled it, let the grid know
                        e.Handled = true;
                    }
                }
            }
        }

        private void GridProduk_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            if (_listOfProduk.Count > 0)
            {
                if (e.RowIndex > 0)
                {
                    var rowIndex = e.RowIndex - 1;

                    if (rowIndex < _listOfProduk.Count)
                    {
                        var produk = _listOfProduk[rowIndex];

                        switch (e.ColIndex)
                        {
                            case 2:
                                e.Style.CellValue = produk.kode_produk;
                                break;

                            case 3:
                                e.Style.CellValue = produk.nama_produk;
                                e.Style.CellTipText = e.Style.Text;
                                break;

                            case 4:
                                e.Style.HorizontalAlignment = GridHorizontalAlignment.Right;
                                e.Style.CellValue = _isShowHargaPembelian ? NumberHelper.NumberToString(produk.harga_beli) : NumberHelper.NumberToString(produk.harga_jual);
                                break;

                            case 5:
                                e.Style.HorizontalAlignment = GridHorizontalAlignment.Center;
                                e.Style.CellValue = (produk.stok + produk.stok_gudang);
                                break;

                            case 6:
                                var golongan = produk.Golongan;

                                if (golongan != null)
                                    e.Style.CellValue = golongan.nama_golongan;

                                break;

                            default:
                                break;
                        }

                        // we handled it, let the grid know
                        e.Handled = true;
                    }
                }
            }
        }

        private void GridSupplier_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            if (_listOfSupplier.Count > 0)
            {
                if (e.RowIndex > 0)
                {
                    var rowIndex = e.RowIndex - 1;

                    if (rowIndex < _listOfSupplier.Count)
                    {
                        var supplier = _listOfSupplier[rowIndex];

                        switch (e.ColIndex)
                        {
                            case 2:
                                e.Style.CellValue = supplier.nama_supplier;
                                break;

                            case 3:
                                e.Style.CellValue = supplier.alamat;
                                break;

                            default:
                                break;
                        }

                        // we handled it, let the grid know
                        e.Handled = true;
                    }
                }
            }
        }

        private void gridList_DoubleClick(object sender, EventArgs e)
        {
            if (base.IsButtonPilihEnabled)
                Pilih();
        }

        protected override void Pilih()
        {
            var rowIndex = this.gridList.SelectedIndex;

            if (!base.IsSelectedItem(rowIndex, this.Text))
                return;

            switch (this._referensiType)
            {
                case ReferencesType.JenisPengeluaran:
                    var jenisPengeluaran = _listOfJenisPengeluaran[rowIndex];
                    this.Listener.Ok(this, jenisPengeluaran);
                    break;

                case ReferencesType.Supplier:
                    var supplier = _listOfSupplier[rowIndex];
                    this.Listener.Ok(this, supplier);
                    break;

                case ReferencesType.Customer:
                    var customer = _listOfCustomer[rowIndex];
                    this.Listener.Ok(this, customer);
                    break;

                case ReferencesType.Dropshipper:
                    var dropshipper = _listOfDropshipper[rowIndex];
                    this.Listener.Ok(this, dropshipper);
                    break;

                case ReferencesType.Produk:
                    var produk = _listOfProduk[rowIndex];
                    this.Listener.Ok(this, produk);
                    break;

                case ReferencesType.KabupatenAsal:
                    var kabupatenAsal = _listOfKabupatenAsal[rowIndex];
                    this.Listener.Ok(this, kabupatenAsal);
                    break;

                case ReferencesType.KabupatenTujuan:
                    var kabupatenTujuan = _listOfKabupatenTujuan[rowIndex];
                    this.Listener.Ok(this, kabupatenTujuan);
                    break;

                default:
                    break;
            }

            this.Close();
        }

        private void gridList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressHelper.IsEnter(e))
            {
                if (base.IsButtonPilihEnabled)
                    Pilih();
            }
        }
    }
}
