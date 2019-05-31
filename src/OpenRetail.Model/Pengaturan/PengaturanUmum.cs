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

namespace OpenRetail.Model
{
    public enum JenisPrinter
    {
        /// <summary>
        /// Jenis printer inkjet/lasetjet
        /// </summary>
        InkJet = 1, 

        /// <summary>
        /// Jenis printer dot matrix
        /// </summary>
        DotMatrix = 2, 

        /// <summary>
        /// Jenis printer mini pos
        /// </summary>
        MiniPOS = 3
    }

    public class PengaturanUmum
    {
        public string nama_printer { get; set; }
        public bool is_auto_print { get; set; }
        public bool is_auto_print_label_nota { get; set; }
        public JenisPrinter jenis_printer { get; set; }
        public bool is_cetak_customer { get; set; }
        public bool is_show_minimal_stok { get; set; }
        public bool is_customer_required { get; set; }
        public bool is_cetak_keterangan_nota { get; set; }
        public bool is_fokus_input_kolom_jumlah { get; set; }

        public bool is_autocut { get; set; }
        public string autocut_code { get; set; }

        public bool is_open_cash_drawer { get; set; }
        public string open_cash_drawer_code { get; set; }

        /// <summary>
        /// Validasi stok produk boleh minus ketika penjualan
        /// </summary>
        public bool is_stok_produk_boleh_minus { get; set; }

        /// <summary>
        /// Update harga jual master produk jika terjadi perubahan harga pada saat penjualan
        /// </summary>
        public bool is_update_harga_jual { get; set; }

        public double default_ppn { get; set; }
        public bool is_singkat_penulisan_ongkir { get; set; }
        public bool is_tampilkan_keterangan_tambahan_item_jual { get; set; }
        public string keterangan_tambahan_item_jual { get; set; }
        public int jumlah_karakter { get; set; }
        public int jumlah_gulung { get; set; }
        public int ukuran_font { get; set; }
        public IList<HeaderNota> list_of_header_nota { get; set; }
        public IList<HeaderNotaMiniPos> list_of_header_nota_mini_pos { get; set; }
        public IList<FooterNotaMiniPos> list_of_footer_nota_mini_pos { get; set; }
        public IList<LabelNota> list_of_label_nota { get; set; }        
    }
}
