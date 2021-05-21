using System;
using System.Collections.Generic;
using System.Linq;

namespace ManajemenKaryawan
{
    class Program
    {
        static int tableWidth = 73;
        private static void Main(string[] args)
        {
            List<Karyawan> karyawans = new List<Karyawan>();
            karyawans.Add(new Karyawan("Budi", 10000000));
            karyawans.Add(new Karyawan("Agus", 8000000));
            karyawans.Add(new Karyawan("Dani", 14000000));

            while (true)
            {
                Console.WriteLine("--- Menu ---");
                Console.WriteLine("1. Tampilkan Data Karyawan");
                Console.WriteLine("2. Tambah Karyawan");
                Console.WriteLine("3. Ubah Karyawan");
                Console.WriteLine("4. Hapus Karyawan");
                Console.WriteLine("5. Keluar Aplikasi");
                Console.WriteLine("Masukan pilihan [1-5]: ");
                try
                {
                    int pilihan = Convert.ToInt32(Console.ReadLine());
                    if (pilihan < 1 || pilihan > 5)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    switch (pilihan)
                    {
                        case 1:
                            Console.Clear();
                            TampilkanDataKaryawan(karyawans);
                            Console.WriteLine();
                            //MainMenu();
                            break;
                        case 2:
                            Console.Clear();
                            try
                            {
                                Console.WriteLine("Masukan nama karyawan yang akan ditambahkan : ");
                                string namaTemp = Console.ReadLine();
                                Console.WriteLine("Masukan gaji karyawan yang akan ditambahkan : ");
                                int gajiTemp = Convert.ToInt32(Console.ReadLine());

                                karyawans.Add(new Karyawan(namaTemp, gajiTemp));
                            }
                            catch (Exception e)
                            {

                                if (e is FormatException)
                                {

                                    PesanKesalahan(" Format inputan untuk gaji harus menggunakan angka");
                                }
                            }

                            TampilkanDataKaryawan(karyawans);
                            Console.WriteLine();
                            //MainMenu();
                            break;
                        case 3:
                            Console.Clear();
                            TampilkanDataKaryawan(karyawans);
                            try
                            {
                                Console.WriteLine("Masukan ID karyawan yang akan diubah: [1-" + karyawans.Count() + "]");
                                int ubah = Convert.ToInt32(Console.ReadLine());
                                if (ubah < 1 || ubah > karyawans.Count())
                                {
                                    throw new ArgumentOutOfRangeException();
                                }
                                Console.WriteLine("Masukan nama karyawan yang baru : ");
                                string namaTemp1 = Console.ReadLine();
                                Console.WriteLine("Masukan gaji karyawan yang baru : ");
                                int gajiTemp1 = Convert.ToInt32(Console.ReadLine());

                                karyawans[ubah - 1].Nama = namaTemp1;
                                karyawans[ubah - 1].Gaji = gajiTemp1;
                            }
                            catch (Exception e)
                            {
                                if (e is ArgumentOutOfRangeException)
                                {

                                    PesanKesalahan("ID karyawan tidak ditemukan");
                                }

                                if (e is FormatException)
                                {

                                    PesanKesalahan("Format inputan untuk gaji harus menggunakan angka");
                                }

                            }


                            TampilkanDataKaryawan(karyawans);
                            Console.WriteLine();
                            //MainMenu();
                            break;
                        case 4:
                            Console.Clear();
                            TampilkanDataKaryawan(karyawans);
                            try
                            {
                                Console.WriteLine("Masukan nomor karyawan yang akan dihapus: ");
                                int hapus = Convert.ToInt32(Console.ReadLine());

                                karyawans.RemoveAt(hapus - 1);
                            }
                            catch (Exception e)
                            {

                                if (e is ArgumentOutOfRangeException)
                                {

                                    PesanKesalahan("ID karyawan tidak ditemukan");
                                }
                            }


                            TampilkanDataKaryawan(karyawans);
                            Console.WriteLine();
                            //MainMenu();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.Clear();
                            //MainMenu();
                            PesanKesalahan("Masukan pilihan dengan benar antara [1-5]");
                            break;
                    }
                }
                catch (Exception e)
                {
                    if (e is FormatException)
                    {
                        PesanKesalahan("Format inputan untuk pilihan menu harus menggunakan angka");
                    }

                    if (e is ArgumentOutOfRangeException)
                    {
                        Console.Clear();
                        PesanKesalahan("Menu pilihan tidak ditemukan");
                        PesanKesalahan("Masukan pilihan dengan benar antara [1-5]");
                    }

                }
            }
        }

        public static void PesanKesalahan(string pesanKesalahan)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[ERROR]");
            Console.ResetColor();
            Console.WriteLine(" " + pesanKesalahan);
        }

        public static void TampilkanDataKaryawan(List<Karyawan> karyawans)
        {
            //Console.Clear();
            Console.WriteLine("DATA KARYAWAN");
            PrintLine();
            PrintRow("ID", "Nama", "Gaji Kotor", "Pajak", "Gaji Bersih");
            PrintLine();
            if (karyawans.Count() >= 1)
            {
                for (int index = 0; index < karyawans.Count; index++)
                {
                    int nomor = index + 1;
                    PrintRow(nomor.ToString(), karyawans[index].Nama, karyawans[index].Gaji.ToString(), HitungPajak(karyawans[index].Gaji).ToString(), (karyawans[index].Gaji - HitungPajak(karyawans[index].Gaji)).ToString());
                }
            }
            else
            {
                Console.WriteLine("================================= Kosong ================================");
            }
            PrintLine();
        }

        static int HitungPajak(int gaji)
        {
            return Convert.ToInt32((gaji * 0.1));
        }

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }


    }
}
