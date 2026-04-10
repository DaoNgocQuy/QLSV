using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO_QuanLy;
using BUS_QuanLy;
namespace GUI_QuanLy
{
    public partial class formQuanLy : Form
    {
        BUS_SinhVien busSV = new BUS_SinhVien();
        public formQuanLy()
        {
            InitializeComponent();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "" && txtName.Text != "" && txtSDT.Text != "")
            {
                // Tạo DTo
                DTO_SinhVien tv = new DTO_SinhVien(0, txtName.Text, txtSDT.Text,
               txtEmail.Text); // Vì ID tự tăng nên để ID số gì cũng dc
                               // Them
                if (busSV.themSinhVien(tv))
                {
                    MessageBox.Show("Thêm thành công");
                    dgvSV.DataSource = busSV.getSinhVien(); // refresh datagridview
                }
                else
                {
                    MessageBox.Show("Thêm ko thành công");
                }
            }
            else
            {
                MessageBox.Show("Xin hãy nhập đầy đủ");
            }
        }
        private void formQuanLy_Load(object sender, EventArgs e)
        {
            dgvSV.DataSource = busSV.getSinhVien();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có chọn table rồi
            if (dgvSV.CurrentRow != null)
            {
                if (txtEmail.Text != "" && txtName.Text != "" && txtSDT.Text != "")
                {
                    int id = Convert.ToInt32(dgvSV.CurrentRow.Cells[0].Value);

                    DTO_SinhVien sv = new DTO_SinhVien(
                        id,
                        txtName.Text,
                        txtSDT.Text,
                        txtEmail.Text
                    );

                    if (busSV.suaSinhVien(sv))
                    {
                        MessageBox.Show("Sửa thành công");
                        dgvSV.DataSource = busSV.getSinhVien();
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Xin hãy nhập đầy đủ");
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn sinh viên muốn sửa");
            }
        }
        private void dgvSV_Click(object sender, EventArgs e)
        {
            // Lấy row hiện tại
            if (dgvSV.CurrentRow != null)
            {
                DataGridViewRow row = dgvSV.CurrentRow;

                txtName.Text = row.Cells[1].Value.ToString();
                txtSDT.Text = row.Cells[2].Value.ToString();
                txtEmail.Text = row.Cells[3].Value.ToString();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSV.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvSV.CurrentRow.Cells[0].Value);

                if (busSV.xoaSinhVien(id))
                {
                    MessageBox.Show("Xóa thành công");
                    dgvSV.DataSource = busSV.getSinhVien();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn thành viên để xóa");
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dt = busSV.getSinhVien();

            string name = txtFindName.Text.Trim().ToLower();
            string phone = txtFindPhone.Text.Trim().ToLower();
            string email = txtFindEmail.Text.Trim().ToLower();

            var filtered = dt.AsEnumerable()
                .Where(row =>
                    (string.IsNullOrEmpty(name) ||
                        row["SV_Name"].ToString().ToLower().Contains(name)) &&

                    (string.IsNullOrEmpty(phone) ||
                        row["SV_Phone"].ToString().ToLower().Contains(phone)) &&

                    (string.IsNullOrEmpty(email) ||
                        row["SV_Email"].ToString().ToLower().Contains(email))
                );

            if (filtered.Any())
            {
                dgvSV.DataSource = filtered.CopyToDataTable();
            }
            else
            {
                dgvSV.DataSource = null;
                MessageBox.Show("Không tìm thấy sinh viên");
            }
        }


    }
}