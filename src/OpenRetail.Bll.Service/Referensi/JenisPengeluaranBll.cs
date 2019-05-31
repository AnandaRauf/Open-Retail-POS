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

using log4net;
using OpenRetail.Model;
using OpenRetail.Bll.Api;
using OpenRetail.Repository.Api;
using OpenRetail.Repository.Service;
 
namespace OpenRetail.Bll.Service
{    
    public class JenisPengeluaranBll : IJenisPengeluaranBll
    {
        private ILog _log;
        private IUnitOfWork _unitOfWork;
		private JenisPengeluaranValidator _validator;

        private bool _isUseWebAPI;
        private string _baseUrl;

		public JenisPengeluaranBll(ILog log)
        {
            _log = log;
            _validator = new JenisPengeluaranValidator();
        }

        public JenisPengeluaranBll(bool isUseWebAPI, string baseUrl, ILog log)
            : this(log)
        {
            _isUseWebAPI = isUseWebAPI;
            _baseUrl = baseUrl;
        }

        public JenisPengeluaran GetByID(string id)
        {
            JenisPengeluaran obj = null;

            if (_isUseWebAPI)
            {
                _unitOfWork = new UnitOfWork(_isUseWebAPI, _baseUrl, _log);
                obj = _unitOfWork.JenisPengeluaranRepository.GetByID(id);
            }
            else
            {
                using (IDapperContext context = new DapperContext())
                {
                    _unitOfWork = new UnitOfWork(context, _log);
                    obj = _unitOfWork.JenisPengeluaranRepository.GetByID(id);
                }
            }            

            return obj;
        }

        public IList<JenisPengeluaran> GetByName(string name)
        {
            IList<JenisPengeluaran> oList = null;

            if (_isUseWebAPI)
            {
                _unitOfWork = new UnitOfWork(_isUseWebAPI, _baseUrl, _log);
                oList = _unitOfWork.JenisPengeluaranRepository.GetByName(name);
            }
            else
            {
                using (IDapperContext context = new DapperContext())
                {
                    _unitOfWork = new UnitOfWork(context, _log);
                    oList = _unitOfWork.JenisPengeluaranRepository.GetByName(name);
                }
            }            

            return oList;
        }

        public IList<JenisPengeluaran> GetAll()
        {
            IList<JenisPengeluaran> oList = null;

            if (_isUseWebAPI)
            {
                _unitOfWork = new UnitOfWork(_isUseWebAPI, _baseUrl, _log);
                oList = _unitOfWork.JenisPengeluaranRepository.GetAll();
            }
            else
            {
                using (IDapperContext context = new DapperContext())
                {
                    _unitOfWork = new UnitOfWork(context, _log);
                    oList = _unitOfWork.JenisPengeluaranRepository.GetAll();
                }
            }            

            return oList;
        }

		public int Save(JenisPengeluaran obj)
        {
            var result = 0;

            if (_isUseWebAPI)
            {
                obj.jenis_pengeluaran_id = Guid.NewGuid().ToString();

                _unitOfWork = new UnitOfWork(_isUseWebAPI, _baseUrl, _log);                
                result = _unitOfWork.JenisPengeluaranRepository.Save(obj);
            }
            else
            {
                using (IDapperContext context = new DapperContext())
                {
                    _unitOfWork = new UnitOfWork(context, _log);
                    result = _unitOfWork.JenisPengeluaranRepository.Save(obj);
                }
            }            

            return result;
        }

        public int Save(JenisPengeluaran obj, ref ValidationError validationError)
        {
			var validatorResults = _validator.Validate(obj);

            if (!validatorResults.IsValid)
            {
                foreach (var failure in validatorResults.Errors)
                {
                    validationError.Message = failure.ErrorMessage;
                    validationError.PropertyName = failure.PropertyName;
                    return 0;
                }
            }

            return Save(obj);
        }

		public int Update(JenisPengeluaran obj)
        {
            var result = 0;

            if (_isUseWebAPI)
            {
                _unitOfWork = new UnitOfWork(_isUseWebAPI, _baseUrl, _log);
                result = _unitOfWork.JenisPengeluaranRepository.Update(obj);
            }
            else
            {
                using (IDapperContext context = new DapperContext())
                {
                    _unitOfWork = new UnitOfWork(context, _log);
                    result = _unitOfWork.JenisPengeluaranRepository.Update(obj);
                }
            }            

            return result;
        }

        public int Update(JenisPengeluaran obj, ref ValidationError validationError)
        {
            var validatorResults = _validator.Validate(obj);

            if (!validatorResults.IsValid)
            {
                foreach (var failure in validatorResults.Errors)
                {
                    validationError.Message = failure.ErrorMessage;
                    validationError.PropertyName = failure.PropertyName;
                    return 0;
                }
            }

            return Update(obj);
        }

        public int Delete(JenisPengeluaran obj)
        {
            var result = 0;

            if (_isUseWebAPI)
            {
                _unitOfWork = new UnitOfWork(_isUseWebAPI, _baseUrl, _log);
                result = _unitOfWork.JenisPengeluaranRepository.Delete(obj);
            }
            else
            {
                using (IDapperContext context = new DapperContext())
                {
                    _unitOfWork = new UnitOfWork(context, _log);
                    result = _unitOfWork.JenisPengeluaranRepository.Delete(obj);
                }
            }            

            return result;
        }
    }
}     
