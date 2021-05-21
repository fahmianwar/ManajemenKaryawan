using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManajemenKaryawan
{
    class Karyawan
    {
        public string Nama { get; set; }
        public int Gaji { get; set; }

        public Karyawan(string nama, int gaji)
        {
            Nama = nama;
            Gaji = gaji;
        }
    }
}
