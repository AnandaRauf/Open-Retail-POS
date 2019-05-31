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
using System.Linq;
using System.Text;

using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenRetail.Model;
using OpenRetail.Bll.Api.Report;
using OpenRetail.Bll.Service.Report;

namespace OpenRetail.Bll.Service.UnitTest.Report
{
    [TestClass]
    public class ReportHutangBeliProdukBllTest
    {
        private ILog _log;
        private IReportHutangBeliProdukBll _bll;

        [TestInitialize]
        public void Init()
        {
            _log = LogManager.GetLogger(typeof(ReportHutangBeliProdukBllTest));
            _bll = new ReportHutangBeliProdukBll(_log);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _bll = null;
        }

        [TestMethod]
        public void GetByBulanAndTahunTest()
        {
            var bulan = 1;
            var tahun = 2017;

            var oList = _bll.GetByBulan(bulan, tahun);

            var index = 0;
            var obj = oList[index];

            Assert.IsNotNull(obj);
            Assert.AreEqual(0, obj.ppn);
            Assert.AreEqual(0, obj.diskon);
            Assert.AreEqual(980000, obj.total_nota);
            Assert.AreEqual(0, obj.total_pelunasan);
            Assert.AreEqual("85ecb92b-3cb7-4d98-8390-cc76a942b880", obj.supplier_id);
            Assert.AreEqual("Sigma komputer", obj.nama_supplier);
        }

        [TestMethod]
        public void GetByRangeBulanAndTahunTest()
        {
            var bulanAwal = 1;
            var bulanAkhir = 2;
            var tahun = 2017;

            var oList = _bll.GetByBulan(bulanAwal, bulanAkhir, tahun);

            var index = 0;
            var obj = oList[index];

            Assert.IsNotNull(obj);
            Assert.AreEqual(0, obj.ppn);
            Assert.AreEqual(0, obj.diskon);
            Assert.AreEqual(980000, obj.total_nota);
            Assert.AreEqual(0, obj.total_pelunasan);
            Assert.AreEqual("85ecb92b-3cb7-4d98-8390-cc76a942b880", obj.supplier_id);
            Assert.AreEqual("Sigma komputer", obj.nama_supplier);
        }

        [TestMethod]
        public void GetByTanggalTest()
        {
            var tanggalMulai = new DateTime(2017, 1, 1);
            var tanggalSelesai = new DateTime(2017, 1, 31);

            var oList = _bll.GetByTanggal(tanggalMulai, tanggalSelesai);

            var index = 0;
            var obj = oList[index];

            Assert.IsNotNull(obj);
            Assert.AreEqual(0, obj.ppn);
            Assert.AreEqual(0, obj.diskon);
            Assert.AreEqual(980000, obj.total_nota);
            Assert.AreEqual(0, obj.total_pelunasan);
            Assert.AreEqual("85ecb92b-3cb7-4d98-8390-cc76a942b880", obj.supplier_id);
            Assert.AreEqual("Sigma komputer", obj.nama_supplier);
        }

        [TestMethod]
        public void DetailGetByBulanAndTahunTest()
        {
            var bulan = 1;
            var tahun = 2017;

            var oList = _bll.DetailGetByBulan(bulan, tahun);

            var index = 0;
            var obj = oList[index];

            Assert.IsNotNull(obj);

            Assert.AreEqual("201701310073", obj.nota);
            Assert.AreEqual(new DateTime(2017, 1, 31), obj.tanggal);
            Assert.AreEqual(new DateTime(2017, 2, 4), obj.tanggal_tempo);
            Assert.AreEqual(0, obj.ppn);
            Assert.AreEqual(0, obj.diskon);
            Assert.AreEqual(980000, obj.total_nota);
            Assert.AreEqual(0, obj.total_pelunasan);

            Assert.AreEqual("85ecb92b-3cb7-4d98-8390-cc76a942b880", obj.supplier_id);
            Assert.AreEqual("Sigma komputer", obj.nama_supplier);
            
        }

        [TestMethod]
        public void DetailGetByRangeBulanAndTahunTest()
        {
            var bulanAwal = 1;
            var bulanAkhir = 2;
            var tahun = 2017;

            var oList = _bll.DetailGetByBulan(bulanAwal, bulanAkhir, tahun);

            var index = 0;
            var obj = oList[index];

            Assert.IsNotNull(obj);

            Assert.AreEqual("201701310073", obj.nota);
            Assert.AreEqual(new DateTime(2017, 1, 31), obj.tanggal);
            Assert.AreEqual(new DateTime(2017, 2, 4), obj.tanggal_tempo);
            Assert.AreEqual(0, obj.ppn);
            Assert.AreEqual(0, obj.diskon);
            Assert.AreEqual(980000, obj.total_nota);
            Assert.AreEqual(0, obj.total_pelunasan);

            Assert.AreEqual("85ecb92b-3cb7-4d98-8390-cc76a942b880", obj.supplier_id);
            Assert.AreEqual("Sigma komputer", obj.nama_supplier);
        }

        [TestMethod]
        public void DetailGetByTanggalTest()
        {
            var tanggalMulai = new DateTime(2017, 1, 1);
            var tanggalSelesai = new DateTime(2017, 1, 31);

            var oList = _bll.DetailGetByTanggal(tanggalMulai, tanggalSelesai);

            var index = 0;
            var obj = oList[index];

            Assert.IsNotNull(obj);

            Assert.AreEqual("201701310073", obj.nota);
            Assert.AreEqual(new DateTime(2017, 1, 31), obj.tanggal);
            Assert.AreEqual(new DateTime(2017, 2, 4), obj.tanggal_tempo);
            Assert.AreEqual(0, obj.ppn);
            Assert.AreEqual(0, obj.diskon);
            Assert.AreEqual(980000, obj.total_nota);
            Assert.AreEqual(0, obj.total_pelunasan);

            Assert.AreEqual("85ecb92b-3cb7-4d98-8390-cc76a942b880", obj.supplier_id);
            Assert.AreEqual("Sigma komputer", obj.nama_supplier);
        }
    }
}
