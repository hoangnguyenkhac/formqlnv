using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FormQLNV.Connect;
using DataLayer;

namespace FormQLNV
{
    public partial class FormBanHang : Form
    {

        private Database Db;
        private DataTable tbbhang;
        public FormBanHang()
        {
            InitializeComponent();
            Load_BhangList();
        }

        private void Load_BhangList()
        {
            string error = "";
            //Hàm GetDataTable hỗ trợ lấy dữ liệu từ CSDL, là hàm thành viên của lớp Database.
            string sql = " select sp.MaSP, hd.MaNV, sp.TenSP, sp.Vendor, sp.DonGia, ct.SoLuong, hd.NgayLap " +
                                " from (CTHD ct inner join SanPham sp on ct.MaSP = ct.MaSP) inner join HoaDon hd on ct.MaHD = hd.MaHD";
            tbbhang = Db.GetDataTable(sql, CommandType.Text, ref error);
            dgBhanglist.DataSource = tbbhang;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string error = "";
        
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string error = "";

        }

        private void dgBhanglist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMasp.Text = dgBhanglist.CurrentRow.Cells["MaSP"].Value.ToString();
            txtMaNV.Text = dgBhanglist.CurrentRow.Cells["MaNV"].Value.ToString();
            txtTen.Text = dgBhanglist.CurrentRow.Cells["TenSP"].Value.ToString();
            txtVendor.Text = dgBhanglist.CurrentRow.Cells["Vendor"].Value.ToString();
            txtDonGia.Text = dgBhanglist.CurrentRow.Cells["DonGia"].Value.ToString();
            txtSL.Text = dgBhanglist.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtNgayLapHD.Text = dgBhanglist.CurrentRow.Cells["NgayLapHD"].Value.ToString();
        }
    }
}
