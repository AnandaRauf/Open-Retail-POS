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

namespace OpenRetail.Helper
{
    public static class DatabaseVersionHelper
    {
        /// <summary>
        /// Versi database yang terakhir
        /// </summary>
        public const int DatabaseVersion = 11;

        /// <summary>
        /// Script SQL untuk mengupgrade database v1 ke v2
        /// </summary>
        private const string UpgradeStrukturDatabase_v1_to_v2 = "db_v1_to_v2.sql";

        /// <summary>
        /// Script SQL untuk mengupgrade database v2 ke v3
        /// </summary>
        private const string UpgradeStrukturDatabase_v2_to_v3 = "db_v2_to_v3.sql";

        /// <summary>
        /// Script SQL untuk mengupgrade database v3 ke v4
        /// </summary>
        private const string UpgradeStrukturDatabase_v3_to_v4 = "db_v3_to_v4.sql";

        /// <summary>
        /// Script SQL untuk mengupgrade database v4 ke v5
        /// </summary>
        private const string UpgradeStrukturDatabase_v4_to_v5 = "db_v4_to_v5.sql";

        /// <summary>
        /// Script SQL untuk mengupgrade database v5 ke v6
        /// </summary>
        private const string UpgradeStrukturDatabase_v5_to_v6 = "db_v5_to_v6.sql";

        /// <summary>
        /// Script SQL untuk mengupgrade database v6 ke v7
        /// </summary>
        private const string UpgradeStrukturDatabase_v6_to_v7 = "db_v6_to_v7.sql";

        /// <summary>
        /// Script SQL untuk mengupgrade database v7 ke v8
        /// </summary>
        private const string UpgradeStrukturDatabase_v7_to_v8 = "db_v7_to_v8.sql";

        /// <summary>
        /// Script SQL untuk mengupgrade database v8 ke v9
        /// </summary>
        private const string UpgradeStrukturDatabase_v8_to_v9 = "db_v8_to_v9.sql";

        /// <summary>
        /// Script SQL untuk mengupgrade database v9 ke v10
        /// </summary>
        private const string UpgradeStrukturDatabase_v9_to_v10 = "db_v9_to_v10.sql";

        /// <summary>
        /// Script SQL untuk mengupgrade database v10 ke v11
        /// </summary>
        private const string UpgradeStrukturDatabase_v10_to_v11 = "db_v10_to_v11.sql";

        public static Dictionary<int, string> ListOfUpgradeDatabaseScript = new Dictionary<int, string>
                                                                            {
                                                                                { 2, DatabaseVersionHelper.UpgradeStrukturDatabase_v1_to_v2 },
                                                                                { 3, DatabaseVersionHelper.UpgradeStrukturDatabase_v2_to_v3 },
                                                                                { 4, DatabaseVersionHelper.UpgradeStrukturDatabase_v3_to_v4 },
                                                                                { 5, DatabaseVersionHelper.UpgradeStrukturDatabase_v4_to_v5 },
                                                                                { 6, DatabaseVersionHelper.UpgradeStrukturDatabase_v5_to_v6 },
                                                                                { 7, DatabaseVersionHelper.UpgradeStrukturDatabase_v6_to_v7 },
                                                                                { 8, DatabaseVersionHelper.UpgradeStrukturDatabase_v7_to_v8 },
                                                                                { 9, DatabaseVersionHelper.UpgradeStrukturDatabase_v8_to_v9 },
                                                                                { 10, DatabaseVersionHelper.UpgradeStrukturDatabase_v9_to_v10 },
                                                                                { 11, DatabaseVersionHelper.UpgradeStrukturDatabase_v10_to_v11 }
                                                                            };
    }
}
