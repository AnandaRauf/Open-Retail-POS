Open Retail POS

Developed Year : 2018 .
Developed By : Ananda Rauf Maududi .

How to using Open Retail Source Code :

1. Install Vs Studio 2015
2. Open Vs Studio 2015
3. Click, File Open Project
4. Choose Open Retail.sln

How to using Open Retail, Open Retail Cashier and Backup Database Open Retail :

1. Go to FolderOpen Retail, Open Retail Cashier and Backup Database Open Retail
2. Then go to folder bin/release

How to using import database :
Struktur Database OpenRetail
==============================================

OpenRetail using database [PostgreSQL](https://www.postgresql.org/) version 9.3.16, suggest download same version for compatible.

Import Database OpenRetail
-----------------------------------------------
For import database OpenRetail you can using tools  [psql](https://www.postgresql.org/docs/9.2/static/app-psql.html) dengan perintah berikut: 

```
psql -U USERNAME DbOpenRetail < DbOpenRetail.sql
```

for `USERNAME` can using user default [PostgreSQL](https://www.postgresql.org/) is `postgres`, and before using command database `DbOpenRetail` must has been created.

Import Data Awal (prerequisites)
-----------------------------------------------
Same as previous OpenReatil import database, we can also using this tools [psql](https://www.postgresql.org/docs/9.2/static/app-psql.html) with following command: 

```
psql -U postgres DbOpenRetail < 01_data-menu.sql
psql -U postgres DbOpenRetail < 02_data-item_menu.sql
psql -U postgres DbOpenRetail < 03_data-role.sql
psql -U postgres DbOpenRetail < 04_data-role_privilege.sql
psql -U postgres DbOpenRetail < 05_data-pengguna.sql
psql -U postgres DbOpenRetail < 06_data-alasan_penyesuaian_stok.sql
psql -U postgres DbOpenRetail < 07_data-database_version.sql
psql -U postgres DbOpenRetail < 08_data-jenis_pengeluaran.sql
psql -U postgres DbOpenRetail < 09_data-jabatan.sql
psql -U postgres DbOpenRetail < 10_data-profil.sql
psql -U postgres DbOpenRetail < 11_data-header-nota.sql
psql -U postgres DbOpenRetail < 12_data-label-nota.sql
psql -U postgres DbOpenRetail < 13_data-provinsi.sql
psql -U postgres DbOpenRetail < 14_data-kabupaten.sql
psql -U postgres DbOpenRetail < 15_data-header_nota_mini_pos.sql
psql -U postgres DbOpenRetail < 16_data-footer_nota_mini_pos.sql
psql -U postgres DbOpenRetail < 17_data-kartu.sql
psql -U postgres DbOpenRetail < 18_data-setting_aplikasi.sql
psql -U postgres DbOpenRetail < 19_data-provinsi2.sql
psql -U postgres DbOpenRetail < 20_data-kabupaten2.sql
psql -U postgres DbOpenRetail < 21_data-kecamatan.sql
```

Please Read File  Licence.rtf Before Your Using  Open Retail POS App ^-^ .

Thanks for using this source code, don't forget click star at My Github Repository and you wanna this source code has been completed developed by me and release, click donate button for my life needs at under this :


[![paypal](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=M2PAQFSADHMTA)
<form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
<input type="hidden" name="cmd" value="_s-xclick" />
<input type="hidden" name="hosted_button_id" value="M2PAQFSADHMTA" />
<input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif" border="0" name="submit" title="PayPal - The safer, easier way to pay online!" alt="Donate with PayPal button"/>
<img alt="" border="0" src="https://www.paypal.com/en_ZA/i/scr/pixel.gif" width="1" height="1"/>
</form>


See you next year and have good day ^-^
