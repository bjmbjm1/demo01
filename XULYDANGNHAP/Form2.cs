using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL;
    


namespace XULYDANGNHAP
{
    public partial class Form2 : Form
    {
        string a;//bien toan cuc
        public Form2()
        {
            InitializeComponent();
            

        }
        public Form2(string giatrinhan) : this()// lay gia tri form1
        {
            txtdangnhap = giatrinhan;
            a = giatrinhan;

        }
        

        TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
        private readonly object txtdangnhap;

        private void button4_Click(object sender, EventArgs e)//Xoa tai khoan
        {
            try
            {
                DialogResult dlr = MessageBox.Show("Ban muon thoat tai khoan?", "Thông báo!", MessageBoxButtons.YesNo);
                if (dlr == DialogResult.No)
                {
                    Form2 a = new Form2();
                    a.Hide();
                }
                else
                {
                    taikhoanbus.xoataikhoan(txtTaiKhoan.Text);
                    dvgQLTK.DataSource = taikhoanbus.LAYTATCA();//luu lai
                    MessageBox.Show("Xoa thanh cong!");
                }
            }
            catch { MessageBox.Show("Xoa bi loi!"); }   
        }
        
        
        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Ban muon them tai khoan?", "Thông báo!", MessageBoxButtons.YesNo);
            if (dlr == DialogResult.No)
            {
                Form2 a = new Form2();
                a.Hide();
            }
            else
            {
                this.Hide();
                Form1 a = new Form1();
                a.Show();
            }
        }
       
        private void Form2_Load(object sender, EventArgs e)// HIEN THI TAT CA DU LIEU
        {
            laten.Text = a;
            if (taikhoanbus.PhanQuyen(a)==true)
                {
                dvgQLTK.DataSource = taikhoanbus.LAYTATCA();
            } else
            {
                txtTaiKhoan.Enabled = false;
                btnxoa.Enabled = false;
                btnthem.Enabled = false;
                dvgQLTK.DataSource = taikhoanbus.LAYTATCA();
                dvgQLTK.Columns["MatKhau"].Visible = false;
            }
            
        }

        private void btnthem_Click(object sender, EventArgs e)//them tai khoan
        {
           try
           {
                DialogResult dlr = MessageBox.Show("Ban muon them tai khoan?", "Thông báo!", MessageBoxButtons.YesNo);
                if (dlr == DialogResult.No)
                {
                    Form2 a = new Form2();
                    a.Hide();
                }
                else
                {
                    String gioitinh = "";
                    if (radnam.Checked == true)
                        gioitinh = "Nam";
                    else
                        gioitinh = "Nu";
                    if (taikhoanbus.kttontai(txtTaiKhoan.Text) == false)
                    {
                        taikhoanbus.ThemTaiKhoan(txtTaiKhoan.Text, txtMatKhau.Text, txtTen.Text, gioitinh, txtDienThoai.Text, txtEmail.Text);
                        dvgQLTK.DataSource = taikhoanbus.LAYTATCA();
                        MessageBox.Show("Them thanh cong!");
                    }
                    else
                    { MessageBox.Show("Tai Khoan da ton tai!"); }
                }
            }
            catch { MessageBox.Show("Them Bi Loi!"); }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtDienThoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnluu_Click(object sender, EventArgs e)// sua tai khoan
        {
           try
            {
                DialogResult dlr = MessageBox.Show("Ban muon luu tai khoan?", "Thông báo!", MessageBoxButtons.YesNo);
                if (dlr == DialogResult.No)
                {
                    Form2 a = new Form2();
                    a.Hide();
                }
                else
                {
                    String gioitinh = "";
                    if (radnam.Checked == true)
                        gioitinh = "Nam";
                    else
                        gioitinh = "Nu";

                    taikhoanbus.Suataikhoan(txtTaiKhoan.Text, txtMatKhau.Text, txtTen.Text, gioitinh, txtDienThoai.Text, txtEmail.Text);
                    MessageBox.Show("sua thanh cong!");
                }
                
               
           }
            catch { MessageBox.Show("Sua Bi Loi!"); }
        }

        private void abc(object sender, EventArgs e)//show cac gia tri vao cac o
        {
            try
            {
                DataGridViewRow dr = dvgQLTK.SelectedRows[0];
                txtTaiKhoan.Text = dr.Cells["TaiKhoan1"].Value.ToString();
                txtMatKhau.Text = dr.Cells["MatKhau"].Value.ToString();
                txtTen.Text = dr.Cells["Ten"].Value.ToString();
                txtDienThoai.Text = dr.Cells["DienThoai"].Value.ToString();
                txtEmail.Text = dr.Cells["Email"].Value.ToString();
                if (dr.Cells["GioiTinh"].Value.ToString() == "Nam")
                    radnam.Checked = true;
                else radnu.Checked = true;
            }
            catch { MessageBox.Show("loi"); }
                
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dvgQLTK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void radnam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radnu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void laten_Click(object sender, EventArgs e)
        {

        }
    }
}
