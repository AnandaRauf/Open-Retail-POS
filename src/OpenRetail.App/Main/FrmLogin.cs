﻿/**
 * Copyright (C) 2019 Tech Source Code Store (https://goo.gl/maps/s4z7ujEHGfYJfsbu7)
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
 * The latest version of this file can be found at https://github.com/AnandaRauf/open-retail
 */

using ConceptCave.WaitCursor;
using log4net;
using OpenRetail.Helper;
using OpenRetail.Bll.Api;
using OpenRetail.Bll.Service;
using OpenRetail.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace OpenRetail.App.Main
{    
    public partial class FrmLogin : Form
    {
        private ILog _log;
        private string _appConfigFile = string.Format("{0}\\OpenRetail.exe.config", Utils.GetAppPath());

        public FrmLogin()
        {
            InitializeComponent();
            ColorManagerHelper.SetTheme(this, this);

            _log = MainProgram.log;
            
            LoadAppConfig();
        }

        private void LoadAppConfig()
        {
            txtServer.Text = AppConfigHelper.GetValue("server", _appConfigFile);

            if (Utils.IsRunningUnderIDE()) // mode debug, set user dan password default untuk development
            {
                txtUserName.Text = "admin";
                txtPassword.Text = "admin";
            }

            // baca setting pageSize
            var pageSize = AppConfigHelper.GetValue("pageSize", _appConfigFile).Length > 0 ? Convert.ToInt32(AppConfigHelper.GetValue("pageSize", _appConfigFile)) : 0;

            if (pageSize > 0)
                MainProgram.pageSize = pageSize;
        }

        private void SaveAppConfig()
        {
            AppConfigHelper.SaveValue("server", txtServer.Text, _appConfigFile);
        }

        private void SetProfil()
        {
            IProfilBll profilBll = new ProfilBll(_log);
            MainProgram.profil = profilBll.GetProfil();
        }

        private void SetPengaturanUmum()
        {
            // set pengaturan lokal (setting di simpan di file app.config)
            MainProgram.pengaturanUmum = new PengaturanUmum();
            MainProgram.pengaturanUmum.nama_printer = AppConfigHelper.GetValue("printerName", _appConfigFile);
            MainProgram.pengaturanUmum.is_auto_print = AppConfigHelper.GetValue("isAutoPrinter", _appConfigFile).ToLower() == "true" ? true : false;
            MainProgram.pengaturanUmum.is_auto_print_label_nota = AppConfigHelper.GetValue("isAutoPrinterLabelNota", _appConfigFile).ToLower() == "true" ? true : false;
            MainProgram.pengaturanUmum.is_show_minimal_stok = AppConfigHelper.GetValue("isShowMinimalStok", _appConfigFile).ToLower() == "true" ? true : false;
            MainProgram.pengaturanUmum.is_customer_required = AppConfigHelper.GetValue("isCustomerRequired", _appConfigFile).ToLower() == "true" ? true : false;
            MainProgram.pengaturanUmum.is_cetak_keterangan_nota = AppConfigHelper.GetValue("isCetakKeteranganNota", _appConfigFile, "true").ToLower() == "true" ? true : false;            
            MainProgram.pengaturanUmum.is_singkat_penulisan_ongkir = AppConfigHelper.GetValue("isSingkatPenulisanOngkir", _appConfigFile).ToLower() == "true" ? true : false;
            MainProgram.pengaturanUmum.default_ppn = Convert.ToDouble(AppConfigHelper.GetValue("defaultPPN", _appConfigFile, "0"));

            // set info printer mini pos
            var jumlahKarakter = AppConfigHelper.GetValue("jumlahKarakter", _appConfigFile).Length > 0 ? Convert.ToInt32(AppConfigHelper.GetValue("jumlahKarakter", _appConfigFile)) : 40;
            var jumlahGulung = AppConfigHelper.GetValue("jumlahGulung", _appConfigFile).Length > 0 ? Convert.ToInt32(AppConfigHelper.GetValue("jumlahGulung", _appConfigFile)) : 5;
            var isCetakCustomer = AppConfigHelper.GetValue("isCetakCustomer", _appConfigFile).Length > 0 ? Convert.ToBoolean(AppConfigHelper.GetValue("isCetakCustomer", _appConfigFile)) : true;
            var ukuranFont = AppConfigHelper.GetValue("ukuranFont", _appConfigFile).Length > 0 ? Convert.ToInt32(AppConfigHelper.GetValue("ukuranFont", _appConfigFile)) : 0;

            MainProgram.pengaturanUmum.is_autocut = AppConfigHelper.GetValue("isAutocut", _appConfigFile, "false").ToLower() == "true" ? true : false;
            MainProgram.pengaturanUmum.autocut_code = AppConfigHelper.GetValue("autocutCode", _appConfigFile, "27,112,0,75,250");

            MainProgram.pengaturanUmum.is_open_cash_drawer = AppConfigHelper.GetValue("isOpenCashDrawer", _appConfigFile, "false").ToLower() == "true" ? true : false;
            MainProgram.pengaturanUmum.open_cash_drawer_code = AppConfigHelper.GetValue("openCashDrawerCode", _appConfigFile, "27,112,0,25,250");

            MainProgram.pengaturanUmum.jenis_printer = AppConfigHelper.GetValue("jenis_printer", _appConfigFile).Length > 0 ? (JenisPrinter)Convert.ToInt32(AppConfigHelper.GetValue("jenis_printer", _appConfigFile)) : JenisPrinter.InkJet;
            MainProgram.pengaturanUmum.is_cetak_customer = isCetakCustomer;
            MainProgram.pengaturanUmum.jumlah_karakter = jumlahKarakter;
            MainProgram.pengaturanUmum.jumlah_gulung = jumlahGulung;
            MainProgram.pengaturanUmum.ukuran_font = ukuranFont;

            // set pengaturan global (setting disimpan di database)
            ISettingAplikasiBll settingAplikasiBll = new SettingAplikasiBll();
            var settingAplikasi = settingAplikasiBll.GetAll().SingleOrDefault();

            if (settingAplikasi != null)
            {
                MainProgram.pengaturanUmum.is_stok_produk_boleh_minus = settingAplikasi.is_stok_produk_boleh_minus;
                MainProgram.pengaturanUmum.is_update_harga_jual = settingAplikasi.is_update_harga_jual_master_produk;
                MainProgram.pengaturanUmum.is_fokus_input_kolom_jumlah = settingAplikasi.is_fokus_input_kolom_jumlah;
                MainProgram.pengaturanUmum.is_tampilkan_keterangan_tambahan_item_jual = settingAplikasi.is_tampilkan_keterangan_tambahan_item_jual;
                MainProgram.pengaturanUmum.keterangan_tambahan_item_jual = settingAplikasi.keterangan_tambahan_item_jual;
            }            

            // set header nota
            IHeaderNotaBll headerNotaBll = new HeaderNotaBll();
            MainProgram.pengaturanUmum.list_of_header_nota = headerNotaBll.GetAll();

            // set header nota minipos
            IHeaderNotaMiniPosBll headerNotaMiniPosBll = new HeaderNotaMiniPosBll();
            MainProgram.pengaturanUmum.list_of_header_nota_mini_pos = headerNotaMiniPosBll.GetAll();

            // set footer nota minipos
            IFooterNotaMiniPosBll footerNotaMiniPosBll = new FooterNotaMiniPosBll();
            MainProgram.pengaturanUmum.list_of_footer_nota_mini_pos = footerNotaMiniPosBll.GetAll();

            // set label nota
            ILabelNotaBll labelNotaBll = new LabelNotaBll();
            MainProgram.pengaturanUmum.list_of_label_nota = labelNotaBll.GetAll();
        }

        private void SetPengaturanBarcode()
        {
            MainProgram.pengaturanBarcode = new PengaturanBarcode();
            MainProgram.pengaturanBarcode.nama_printer = AppConfigHelper.GetValue("printerBarcode", _appConfigFile);

            MainProgram.pengaturanBarcode.header_label = AppConfigHelper.GetValue("headerLabel", _appConfigFile).Length == 0 ? MainProgram.profil.nama_profil.NullToString() 
                                                                                                                            : AppConfigHelper.GetValue("headerLabel", _appConfigFile);

            MainProgram.pengaturanBarcode.batas_atas_baris1 = Convert.ToSingle(AppConfigHelper.GetValue("batasAtasBaris1", _appConfigFile, "43"));
            MainProgram.pengaturanBarcode.batas_atas_baris2 = Convert.ToSingle(AppConfigHelper.GetValue("batasAtasBaris2", _appConfigFile, "187"));
            MainProgram.pengaturanBarcode.batas_atas_baris3 = Convert.ToSingle(AppConfigHelper.GetValue("batasAtasBaris3", _appConfigFile, "344"));
            MainProgram.pengaturanBarcode.batas_atas_baris4 = Convert.ToSingle(AppConfigHelper.GetValue("batasAtasBaris4", _appConfigFile, "496"));

            MainProgram.pengaturanBarcode.batas_kiri_kolom1 = Convert.ToSingle(AppConfigHelper.GetValue("batasKiriKolom1", _appConfigFile, "11"));
            MainProgram.pengaturanBarcode.batas_kiri_kolom2 = Convert.ToSingle(AppConfigHelper.GetValue("batasKiriKolom2", _appConfigFile, "277"));
            MainProgram.pengaturanBarcode.batas_kiri_kolom3 = Convert.ToSingle(AppConfigHelper.GetValue("batasKiriKolom3", _appConfigFile, "540"));
        }

        private void SetSettingPort()
        {
            MainProgram.settingPort = new SettingPort();
            MainProgram.settingPort.portNumber = AppConfigHelper.GetValue("portNumber", _appConfigFile, "COM1");
            MainProgram.settingPort.baudRate = Convert.ToInt32(AppConfigHelper.GetValue("baudRate", _appConfigFile, "9600"));
            MainProgram.settingPort.parity = (Parity)Convert.ToInt32(AppConfigHelper.GetValue("parity", _appConfigFile, "1"));
            MainProgram.settingPort.dataBits = Convert.ToInt32(AppConfigHelper.GetValue("dataBits", _appConfigFile, "8"));
            MainProgram.settingPort.stopBits = (StopBits)Convert.ToInt32(AppConfigHelper.GetValue("stopBits", _appConfigFile, "1"));
        }

        private void SetSettingCustomerDisplay()
        {
            MainProgram.settingCustomerDisplay = new SettingCustomerDisplay();
            MainProgram.settingCustomerDisplay.is_active_customer_display = AppConfigHelper.GetValue("isActiveCustomerDisplay", _appConfigFile, "false").ToLower() == "true" ? true : false;
            MainProgram.settingCustomerDisplay.opening_sentence_line1 = AppConfigHelper.GetValue("customerDisplayOpeningSentenceLine1", _appConfigFile, "Selamat Datang di");
            MainProgram.settingCustomerDisplay.opening_sentence_line2 = AppConfigHelper.GetValue("customerDisplayOpeningSentenceLine2", _appConfigFile, "KR Software");
            MainProgram.settingCustomerDisplay.closing_sentence_line1 = AppConfigHelper.GetValue("customerDisplayClosingSentenceLine1", _appConfigFile, "Terima Kasih");
            MainProgram.settingCustomerDisplay.closing_sentence_line2 = AppConfigHelper.GetValue("customerDisplayClosingSentenceLine2", _appConfigFile, "Selamat Dtg Kembali");
            MainProgram.settingCustomerDisplay.delay_display_closing_sentence = Convert.ToInt32(AppConfigHelper.GetValue("customerDisplayDelayDisplayClosingSentence", _appConfigFile, "5"));
        }

        /// <summary>
        /// Load data kabupaten untuk keperluan pengecekan ongkos kirim
        /// </summary>
        private void LoadKabupaten()
        {
            IKabupatenRajaOngkirBll bll = new KabupatenRajaOngkirBll();
            MainProgram.ListOfKabupaten = bll.GetAll();
        }

        /// <summary>
        /// Load data wilayah (provinsi, kabupaten dan kecamatan) untuk alamat customer
        /// </summary>
        private void LoadWilayah()
        {
            IWilayahBll bll = new WilayahBll();
            MainProgram.ListOfWilayah = bll.GetAll();
        }

        private void LoadInfoMinimalStokProduk()
        {
            IProdukBll bll = new ProdukBll(_log);
            MainProgram.listOfMinimalStokProduk = bll.GetInfoMinimalStok();
        }

        private bool ExecSQL(string fileName)
        {
            var result = false;
            var fileSql = string.Format(@"{0}\sql\{1}", Utils.GetAppPath(), fileName);

            if (File.Exists(fileSql))
            {
                IDbConnectionHelper dbHelper = new DbConnectionHelper();

                using (var reader = new StreamReader(fileSql))
                {
                    var sql = reader.ReadToEnd();
                    result = dbHelper.ExecSQL(sql);
                }
            }

            return result;
        }

        private void UpgradeDatabase(int newDatabaseVersion)
        {
            IDatabaseVersionBll bll = new DatabaseVersionBll(_log);
            
            var dbVersion = bll.Get();
            if (dbVersion != null)
            {
                var result = true;
                var upgradeTo = dbVersion.version_number + 1;
                
                while (upgradeTo <= newDatabaseVersion)
                {
                    var scriptUpgrade = DatabaseVersionHelper.ListOfUpgradeDatabaseScript[upgradeTo];
                    result = ExecSQL(scriptUpgrade);

                    if (!result)
                        break;

                    upgradeTo++;
                    if (!(bll.UpdateVersion() > 0))
                        break;
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var isConnected = false;

            SaveAppConfig();

            // tes koneksi ke server
            using (new StCursor(Cursors.WaitCursor, new TimeSpan(0, 0, 0, 0)))
            {
                IDbConnectionHelper dbConn = new DbConnectionHelper();
                isConnected = dbConn.IsOpenConnection();
            }

            if (!isConnected)
            {
                var msg = "Maaf koneksi ke database gagal !!!\n\n" +
                          "Disarankan untuk menginstall OpenRetail di 'Drive D'.\n" +
                          "Silahkan uninstall dulu OpenRetailnya, kemudian install lagi di 'Drive D'.";

                MsgHelper.MsgError(msg);
                return;
            }

            using (new StCursor(Cursors.WaitCursor, new TimeSpan(0, 0, 0, 0)))
            {
                IPenggunaBll penggunaBll = new PenggunaBll(_log);

                var pass = CryptoHelper.GetMD5Hash(txtPassword.Text, MainProgram.securityCode);
                var isLogin = penggunaBll.IsValidPengguna(txtUserName.Text, pass);

                if (isLogin)
                {
                    UpgradeDatabase(DatabaseVersionHelper.DatabaseVersion);

                    log4net.GlobalContext.Properties["UserName"] = txtUserName.Text;
                    MainProgram.pengguna = penggunaBll.GetByID(txtUserName.Text);

                    SetProfil();
                    SetPengaturanUmum();
                    SetPengaturanBarcode();
                    SetSettingPort();
                    SetSettingCustomerDisplay();
                    LoadKabupaten();
                    LoadWilayah();

                    if (MainProgram.pengaturanUmum.is_show_minimal_stok)
                    {
                        LoadInfoMinimalStokProduk();
                    }                        

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MsgHelper.MsgWarning("User name atau password salah !!!");
                    txtUserName.Focus();
                }
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl_Click(object sender, EventArgs e)
        {
            switch (((TabControl)sender).SelectedIndex)
            {
                case 0:
                    txtUserName.Focus();
                    break;

                case 1:
                    txtServer.Focus();
                    break;

                default:
                    break;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressHelper.IsEnter(e))
                btnLogin_Click(sender, e);
        }        
    }
}
