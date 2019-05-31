/**
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
using System.Threading.Tasks;

using FluentValidation;
using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OpenRetail.Model.Report;

namespace OpenRetail.Model
{        
	[Table("t_mesin")]
    public class MesinKasir
    {
		[ExplicitKey]
		[Display(Name = "mesin_id")]		
		public string mesin_id { get; set; }
		
		[Display(Name = "pengguna_id")]
		public string pengguna_id { get; set; }

		[Write(false)]
        public Pengguna Pengguna { get; set; }

        [Write(false)]
		[Display(Name = "tanggal")]
		public Nullable<DateTime> tanggal { get; set; }
		
		[Display(Name = "saldo_awal")]
		public double saldo_awal { get; set; }
		
		[Display(Name = "uang_masuk")]
		public double uang_masuk { get; set; }        
		
		[Display(Name = "shift_id")]
		public string shift_id { get; set; }
		
		[Display(Name = "uang_keluar")]
		public double uang_keluar { get; set; }

        [JsonIgnore]
        [Write(false)]
        [Display(Name = "tanggal_sistem")]
        public Nullable<DateTime> tanggal_sistem { get; set; }
	}

    public class MesinValidator : AbstractValidator<MesinKasir>
    {
        public MesinValidator()
        {
            CascadeMode = FluentValidation.CascadeMode.StopOnFirstFailure;

			var msgError1 = "'{PropertyName}' tidak boleh kosong !";
            var msgError2 = "Inputan '{PropertyName}' maksimal {MaxLength} karakter !";

			RuleFor(c => c.pengguna_id).NotEmpty().WithMessage(msgError1).Length(1, 36).WithMessage(msgError2);
			//RuleFor(c => c.shift_id).NotEmpty().WithMessage(msgError1).Length(1, 36).WithMessage(msgError2);
		}
	}
}
