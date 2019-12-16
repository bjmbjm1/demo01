using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

// ham dang nhap su dung qlcontext tuwj khoi tao du lieu;
namespace BUS
{
    public class TaiKhoanBUS
    {
        QLTaiKhoanDataContext TaiKhoans = new QLTaiKhoanDataContext();
        public bool KTDANGNHAP(String tendangnhap, string matkhau) // trong qlcotext tao ra tk1 va mk
        {
            int taikhoan = (from tk in TaiKhoans.TAIKHOANs
                            where tk.TaiKhoan1 == tendangnhap && tk.MatKhau == matkhau
                            select tk).Count();
            if (taikhoan == 1)
                return true;
            else return false;


        }
        public IEnumerable<TAIKHOAN> LAYTATCA() // lay tat ca tai khoan
        {
            IEnumerable<TAIKHOAN> taikhoan = from tk in TaiKhoans.TAIKHOANs
                                             select tk;
            return taikhoan;
                                             
        }
      public bool kttontai(string taikhoan)//kiem tra tai khoan them
        {
            int kt = (from tk in TaiKhoans.TAIKHOANs
                      where tk.TaiKhoan1 == taikhoan
                      select tk).Count();
            if (kt == 1) return true;
            else return false;
        }
   
       public void ThemTaiKhoan(string taikhoan, string matkhau, string ten, string gioitinh, string dienthoai,string email)
        {
            
            TAIKHOAN themtaikhoan = new TAIKHOAN();
            themtaikhoan.TaiKhoan1 = taikhoan;
            themtaikhoan.MatKhau = matkhau;
            themtaikhoan.Ten = ten;
            themtaikhoan.GioiTinh = gioitinh;
            themtaikhoan.DienThoai = dienthoai;
            themtaikhoan.Email = email;
            TaiKhoans.TAIKHOANs.InsertOnSubmit(themtaikhoan);// CHO LEN CSDL
            TaiKhoans.SubmitChanges();//LUU TAI KHOAN
             
        }

        public void Suataikhoan(String taikhoan,string matkhau,string ten, string gioitinh,string dienthoai,string email)
        {
            TAIKHOAN SUATAIKHOAN = (from tk in TaiKhoans.TAIKHOANs
                                    select tk).Single(t => t.TaiKhoan1 == taikhoan);
           SUATAIKHOAN.MatKhau = matkhau;
            SUATAIKHOAN.Ten = ten;
           SUATAIKHOAN.GioiTinh = gioitinh;
             SUATAIKHOAN.DienThoai = dienthoai;
          SUATAIKHOAN.Email = email;
          
            TaiKhoans.SubmitChanges();//LUU TAI KHOAN
        }
        public void xoataikhoan(string taikhoan)
        {
            TAIKHOAN XOATK = (from tk in TaiKhoans.TAIKHOANs
                                    select tk).Single(t => t.TaiKhoan1 == taikhoan);
            TaiKhoans.TAIKHOANs.DeleteOnSubmit(XOATK);
            TaiKhoans.SubmitChanges();  
        }
        public bool PhanQuyen(string taikhoan)// phan quyen
        {
            if (taikhoan == "admin")
            { return true; }

            else return false;
        
        }
    }
}
