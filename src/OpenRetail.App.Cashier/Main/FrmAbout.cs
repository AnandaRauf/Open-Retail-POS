/**
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OpenRetail.Helper;

namespace OpenRetail.App.Cashier.Main
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
            ColorManagerHelper.SetTheme(this, this);

            ShowInfoAbout();
        }

        private void ShowInfoAbout()
        {
            var firstReleaseYear = 2017;
            var currentYear = DateTime.Today.Year;
            var copyright = currentYear > firstReleaseYear ? string.Format("{0} - {1}", firstReleaseYear, currentYear) : firstReleaseYear.ToString();

            lblVersion.Text = string.Format("Version {0}{1}", MainProgram.currentVersion, MainProgram.stageOfDevelopment);
            lblCopyright.Text = string.Format("Copyright © {0} Ananda Rauf Maududi | Email: anandarauf02@gmail.com | Phone: +62 838 7962 7956", copyright);

            lblUrl1.Text = "https://instagram.com/anandarauf08";
            lblUrl1.LinkClicked += lblUrl_LinkClicked;

            lblUrl2.Text = "https://goo.gl/maps/s4z7ujEHGfYJfsbu7";
            lblUrl2.LinkClicked += lblUrl_LinkClicked;
        }

        private void lblUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var link = (LinkLabel)sender;

            // Specify that the link was visited.
            link.LinkVisited = true;

            // Navigate to a URL.
            System.Diagnostics.Process.Start(link.Text);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAbout_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressHelper.IsEsc(e))
                btnOk_Click(sender, e);
        }

        private void imgDonate_Click(object sender, EventArgs e)
        {
            var url = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=2M3R3VLR7BZ36";

            // Navigate to a URL.
            System.Diagnostics.Process.Start(url);
        }        
    }
}
