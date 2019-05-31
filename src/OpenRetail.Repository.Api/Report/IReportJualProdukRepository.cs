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

using OpenRetail.Model;
using OpenRetail.Model.Report;

namespace OpenRetail.Repository.Api.Report
{
    public interface IReportJualProdukRepository : IBaseReportRepository<ReportPenjualanProdukHeader>
    {
        IList<ReportPenjualanProdukDetail> DetailGetByBulan(int bulan, int tahun);
        IList<ReportPenjualanProdukDetail> DetailGetByBulan(int bulanAwal, int bulanAkhir, int tahun);
        IList<ReportPenjualanProdukDetail> DetailGetByTanggal(DateTime tanggalMulai, DateTime tanggalSelesai);

        IList<ReportPenjualanProduk> PerProdukGetByBulan(int bulan, int tahun);
        IList<ReportPenjualanProduk> PerProdukGetByBulan(int bulanAwal, int bulanAkhir, int tahun);
        IList<ReportPenjualanProduk> PerProdukGetByTanggal(DateTime tanggalMulai, DateTime tanggalSelesai);

        IList<ReportProdukFavorit> ProdukFavoritGetByBulan(int bulan, int tahun, int limit);
        IList<ReportProdukFavorit> ProdukFavoritGetByBulan(int bulanAwal, int bulanAkhir, int tahun, int limit);
        IList<ReportProdukFavorit> ProdukFavoritGetByTanggal(DateTime tanggalMulai, DateTime tanggalSelesai, int limit);

        IList<ReportPenjualanPerKasir> PerKasirGetByBulan(int bulan, int tahun);
        IList<ReportPenjualanPerKasir> PerKasirGetByBulan(int bulanAwal, int bulanAkhir, int tahun);
        IList<ReportPenjualanPerKasir> PerKasirGetByTanggal(DateTime tanggalMulai, DateTime tanggalSelesai);

        IList<ReportCustomerProduk> CustomerProdukGetByBulan(int bulan, int tahun);
        IList<ReportCustomerProduk> CustomerProdukGetByBulan(int bulanAwal, int bulanAkhir, int tahun);
        IList<ReportCustomerProduk> CustomerProdukGetByTanggal(DateTime tanggalMulai, DateTime tanggalSelesai);

        IList<ReportPenjualanProdukPerGolongan> PerGolonganGetByBulan(int bulan, int tahun);
        IList<ReportPenjualanProdukPerGolongan> PerGolonganGetByBulan(int bulanAwal, int bulanAkhir, int tahun);
        IList<ReportPenjualanProdukPerGolongan> PerGolonganGetByTanggal(DateTime tanggalMulai, DateTime tanggalSelesai);

        IList<ReportPenjualanProduk> PerGolonganDetailGetByBulan(int bulan, int tahun);
        IList<ReportPenjualanProduk> PerGolonganDetailGetByBulan(int bulanAwal, int bulanAkhir, int tahun);
        IList<ReportPenjualanProduk> PerGolonganDetailGetByTanggal(DateTime tanggalMulai, DateTime tanggalSelesai);
    }
}
