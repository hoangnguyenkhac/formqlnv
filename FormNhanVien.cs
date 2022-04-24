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
    public partial class FormNhanVien : Form
    {
        private Database Db;
        private DataTable tbnvien;
        public FormNhanVien()
        {
            InitializeComponent();
            Db = new Database();
            tbnvien = new DataTable();
            Load_NvienList();
        }
        private void Load_NvienList()
        {
            string error = "";
            //Hàm GetDataTable hỗ trợ lấy dữ liệu từ CSDL, là hàm thành viên của lớp Database.
            string sql = " select * " + " from NhanVien ";
            tbnvien = Db.GetDataTable(sql, CommandType.Text, ref error);
            dgNvienlist.DataSource = tbnvien;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string error = "";
            string sql = " insert into NhanVien(MaNV,Ho,Ten,DiaChi,SDT,Email,NgayBD,CMND)" + "value(@MaNV,@Ho,@Ten,@DiaChi,@SDT,@Email,@NgayBD,@CMND)";

            bool kq = Db.MyExecuteQuery(sql, CommandType.Text, ref error, 
                                        new SqlParameter("@MaNV", txtMa),
                                        new SqlParameter("@Ho", txtHo.Text),
                                        new SqlParameter("@Ten", txtTen.Text),
                                        new SqlParameter("@DiaChi", txtDiachi.Text),
                                        new SqlParameter("@SDT", txtSDT.Text),
                                        new SqlParameter("@Email", txtEmail.Text),
                                        new SqlParameter("@NgayBD", txtNgayBd.Text),
                                        new SqlParameter("@CMND", txtCMND.Text)
                                        );

            if (kq == true)
            {
                Load_NvienList();
            }
        }

        private void dgNvienlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgNvienlist.CurrentRow.Cells["MaNV"].Value.ToString();
            txtHo.Text = dgNvienlist.CurrentRow.Cells["Ho"].Value.ToString();
            txtTen.Text = dgNvienlist.CurrentRow.Cells["Ten"].Value.ToString();
            txtDiachi.Text = dgNvienlist.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtSDT.Text = dgNvienlist.CurrentRow.Cells["SDT"].Value.ToString();
            txtEmail.Text = dgNvienlist.CurrentRow.Cells["Email"].Value.ToString();
            txtNgayBd.Text = dgNvienlist.CurrentRow.Cells["NgayBD"].Value.ToString();
            txtCMND.Text = dgNvienlist.CurrentRow.Cells["CMND"].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string error = "";
            string sql = " delete from NhanVien where MaNV=@MaNV";

            bool kq = Db.MyExecuteQuery(sql, CommandType.Text, ref error, new SqlParameter("@MaNV", txtMa.Text));
            
            if (kq == true)
            {
                Load_NvienList();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string error = "";
            string sql = " update NhanVien " + " set Ho=@Ho," + "Ten=@Ten," + " DiaChi=@DiaChi," + " SDT = @SDT," + "Email=@Email," + "NgayBD=@NgayBD," + "CMND=@CMND" + " where MaNV=@MaNV";

            bool kq = Db.MyExecuteQuery(sql, CommandType.Text, ref error,
                                        new SqlParameter("@MaNV", txtMa),
                                        new SqlParameter("@Ho", txtHo.Text),
                                        new SqlParameter("@Ten", txtTen.Text),
                                        new SqlParameter("@DiaChi", txtDiachi.Text),
                                        new SqlParameter("@SDT", txtSDT.Text),
                                        new SqlParameter("@Email", txtEmail.Text),
                                        new SqlParameter("@NgayBD", txtNgayBd.Text),
                                        new SqlParameter("@CMND", txtCMND.Text)
                                        );

            if (kq == true)
            {
                Load_NvienList();
            }
        }
    }
}
