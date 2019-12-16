using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS; using DAL;
// lop bus dung de xu ly cac thuat toan , toan tu , kiemtra;
//Lop dal dung de tao csdl bang Linq to sql sever;
namespace XULYDANGNHAP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        TaiKhoanBUS taikhoanbus = new TaiKhoanBUS();
        private void btndangnhap_Click(object sender, EventArgs e)// KIEM TRA DANG NHAP
        {
            try
            {
                    if (taikhoanbus.KTDANGNHAP(txtdangnhap.Text, txtMatkhau.Text) == true)
                    {
                        this.Hide();
                        Form2 frm = new Form2(txtdangnhap.Text);
                        
                        frm.Show();
                    MessageBox.Show("dang nhap thanh cong");
                }
                    else
                        MessageBox.Show("Tai Khoan hoac mat khau sai!");
                
            }
            catch { MessageBox.Show("Dang nhap sai!"); }
            
        }

        private void button1_Click(object sender, EventArgs e)// Exit chuong trinh
        {
            DialogResult dlr = MessageBox.Show("Ban muon thooat chuong trinh?", "Thông báo!", MessageBoxButtons.YesNo);
            if (dlr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                Form1 a = new Form1();
                a.Hide();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtdangnhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMatkhau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
