using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO_QuanLy;


namespace DAL_QuanLy
{
    public class DAL_SinhVien : DBConnect
    {
        /// <summary>
        /// Get toan bo SinhVien
        /// </summary>
        /// <returns></returns>

        public DataTable getSinhVien()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SINHVIEN", _conn);
            DataTable dtSinhvien = new DataTable();
            da.Fill(dtSinhvien);
            return dtSinhvien;
        }

        /// <summary>
        /// Thêm Sinh viên
        /// </summary>
        public bool themSinhVien(DTO_SinhVien sv)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format(
                    "INSERT INTO SINHVIEN(SV_NAME, SV_PHONE, SV_EMAIL) VALUES(N'{0}', '{1}', '{2}')",
                    sv.SINHVIEN_NAME, sv.SINHVIEN_PHONE, sv.SINHVIEN_EMAIL
                );

                SqlCommand cmd = new SqlCommand(SQL, _conn);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Sửa Sinh viên
        /// </summary>
        /// <returns></returns>
        public bool suaSinhVien(DTO_SinhVien sv)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format(
                    "UPDATE SINHVIEN SET SV_NAME = N'{0}', SV_PHONE = '{1}', SV_EMAIL = '{2}' WHERE SV_ID = {3}",
                    sv.SINHVIEN_NAME, sv.SINHVIEN_PHONE, sv.SINHVIEN_EMAIL, sv.SINHVIEN_ID
                );

                SqlCommand cmd = new SqlCommand(SQL, _conn);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        /// <summary>
        /// Xóa Sinh viên
        /// </summary>
        /// <returns></returns>
        public bool xoaSinhVien(int SV_ID)
        {
            try
            {
                _conn.Open();

                string SQL = string.Format(
                    "DELETE FROM SINHVIEN WHERE SV_ID = {0}",
                    SV_ID
                );

                SqlCommand cmd = new SqlCommand(SQL, _conn);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
    }
}