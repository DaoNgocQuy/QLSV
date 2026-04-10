using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
   public class DTO_SinhVien
    {
        private int _SINHVIEN_ID;
        private string _SINGVIEN_NAME;
        private string _SINHVIEN_PHONE;
        private string _SINHVIEN_EMAIL;
        /*===============GETTER/SETTER================*/
        public int SINHVIEN_ID
        {
            get
            {
                return _SINHVIEN_ID;
            }
            set
            {
                _SINHVIEN_ID = value;
            }
        }
        public string SINHVIEN_NAME
        {
            get
            {
                return _SINGVIEN_NAME;
            }
            set
            {
                _SINGVIEN_NAME = value;
            }
        }
        public string SINHVIEN_PHONE
        {
            get
            {
                return _SINHVIEN_PHONE;
            }
            set
            {
                   _SINHVIEN_PHONE = value;
            }
        }
        public string SINHVIEN_EMAIL
        {
            get
            {
                return _SINHVIEN_EMAIL;
            }
            set
            {
                _SINHVIEN_EMAIL = value;
            }
        }
        /*===============Constructor================*/
        public DTO_SinhVien()
        {

        }
        public DTO_SinhVien(int id, string name, string phone, string email)
        {
            this.SINHVIEN_ID = id;
            this.SINHVIEN_NAME = name;
            this.SINHVIEN_PHONE = phone;
            this._SINHVIEN_EMAIL = email;
        }
    }

}
