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
using Dapper.Contrib.Extensions;

using OpenRetail.Model;
using OpenRetail.Repository.Api;
 
namespace OpenRetail.Repository.Service
{        
    public class ItemMenuRepository : IItemMenuRepository
    {
        private IDapperContext _context;
		private ILog _log;
		
        public ItemMenuRepository(IDapperContext context, ILog log)
        {
            this._context = context;
            this._log = log;
        }

        public ItemMenu GetByID(string id)
        {
            ItemMenu obj = null;

            try
            {
                obj = _context.db.Get<ItemMenu>(id);
            }
            catch (Exception ex)
            {
                _log.Error("Error:", ex);
            }

            return obj;
        }

        public IList<ItemMenu> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IList<ItemMenu> GetByMenu(string menuId)
        {
            IList<ItemMenu> oList = new List<ItemMenu>();

            try
            {
                oList = _context.db.GetAll<ItemMenu>()
                                .Where(f => f.menu_id == menuId)
                                .OrderBy(f => f.grant_id)
                                .ToList();
            }
            catch (Exception ex)
            {
                _log.Error("Error:", ex);
            }

            return oList;
        }

        public IList<ItemMenu> GetAll()
        {
            IList<ItemMenu> oList = new List<ItemMenu>();

            try
            {
                oList = _context.db.GetAll<ItemMenu>()
                                .ToList();
            }
            catch (Exception ex)
            {
                _log.Error("Error:", ex);
            }

            return oList;
        }

        public int Save(ItemMenu obj)
        {
            var result = 0;

            try
            {
                obj.item_menu_id = _context.GetGUID();

                _context.db.Insert<ItemMenu>(obj);
                result = 1;
            }
            catch (Exception ex)
            {
                _log.Error("Error:", ex);
            }

            return result;
        }

        public int Update(ItemMenu obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(ItemMenu obj)
        {
            throw new NotImplementedException();
        }        
    }
}     
