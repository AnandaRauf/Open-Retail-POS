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

using Newtonsoft.Json;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace OpenRetail.WebAPI.Models.DTO
{        
    public class PenggunaDTO
    {
		[Display(Name = "pengguna_id")]		
		public string pengguna_id { get; set; }
		
		[Display(Name = "role_id")]
		public string role_id { get; set; }

		[JsonIgnore]
        public RoleDTO Role { get; set; }

		[Display(Name = "nama_pengguna")]
		public string nama_pengguna { get; set; }
		
		[Display(Name = "pass_pengguna")]
		public string pass_pengguna { get; set; }
		
		[Display(Name = "is_active")]
		public bool is_active { get; set; }
		
		[Display(Name = "status_user")]
		public int status_user { get; set; }
		
		[Display(Name = "email")]
		public string email { get; set; }
		
	}

    public class PenggunaDTOValidator : AbstractValidator<PenggunaDTO>
    {
        public PenggunaDTOValidator()
        {
            CascadeMode = FluentValidation.CascadeMode.StopOnFirstFailure;

			var msgError1 = "'{PropertyName}' tidak boleh kosong !";
            var msgError2 = "'{PropertyName}' maksimal {MaxLength} karakter !";			

			RuleSet("save", () =>
            {
                DefaultRule(msgError1, msgError2);
            });

            RuleSet("update", () =>
            {
                RuleFor(c => c.pengguna_id).NotEmpty().WithMessage(msgError1).Length(1, 36).WithMessage(msgError2);
                DefaultRule(msgError1, msgError2);
            });

            RuleSet("delete", () =>
            {
                RuleFor(c => c.pengguna_id).NotEmpty().WithMessage(msgError1).Length(1, 36).WithMessage(msgError2);
            });
		}

        private void DefaultRule(string msgError1, string msgError2)
        {
            RuleFor(c => c.role_id).NotEmpty().WithMessage(msgError1).Length(1, 36).WithMessage(msgError2);
            RuleFor(c => c.nama_pengguna).NotEmpty().WithMessage(msgError1).Length(1, 50).WithMessage(msgError2);
            RuleFor(c => c.pass_pengguna).NotEmpty().WithMessage(msgError1).Length(1, 32).WithMessage(msgError2);
            RuleFor(c => c.email).NotEmpty().WithMessage(msgError1).Length(1, 100).WithMessage(msgError2);			
        }
	}
}
