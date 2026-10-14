using System;
using System.Collections.Generic;

namespace SistemKaryawan
{
    // ==========================================
    // Kelas Utama
    // ==========================================

    // Kelas Karyawan
    public class Karyawan
    {
        public string Nama { get; set; }
        public double Gaji { get; set; }

        public Karyawan(string nama, double gaji)
        {
            Nama = nama;
            Gaji = gaji;
        }

        public virtual void Kerja()
        {
            Console.WriteLine($"{Nama} sedang bekerja.");
        }

        public virtual void InfoKaryawan()
        {
            Console.WriteLine($"Nama: {Nama} | Gaji: Rp{Gaji:N0}");
        }
    }

    // Kelas Tetap (Inheritance Karyawan)
    public class Tetap : Karyawan
    {
        public double Tunjangan { get; set; }

        public Tetap(string nama, double gaji, double tunjangan) : base(nama, gaji)
        {
            Tunjangan = tunjangan;
        }

        public double HitungGajiTotal()
        {
            return Gaji + Tunjangan;
        }

        public override void Kerja()
        {
            Console.WriteLine($"{Nama} sedang bekerja sebagai karyawan tetap.");
        }

        public override void InfoKaryawan()
        {
            Console.WriteLine($"[Tetap] Nama: {Nama} | Gaji Pokok: Rp{Gaji:N0} | Tunjangan: Rp{Tunjangan:N0} | Total: Rp{HitungGajiTotal():N0}");
        }
    }

    // Kelas Kontrak (Inheritance Karyawan)
    public class Kontrak : Karyawan
    {
        public int Durasi { get; set; }

        public Kontrak(string nama, double gaji, int durasi) : base(nama, gaji)
        {
            Durasi = durasi;
        }

        public void CekKontrak()
        {
            Console.WriteLine($"Sisa durasi kontrak {Nama} adalah {Durasi} bulan.");
        }

        public override void Kerja()
        {
            Console.WriteLine($"{Nama} sedang bekerja sesuai durasi kontrak.");
        }

        public override void InfoKaryawan()
        {
            Console.WriteLine($"[Kontrak] Nama: {Nama} | Gaji: Rp{Gaji:N0} | Durasi Kontrak: {Durasi} bulan");
        }
    }

    // Subclass dari Class Tetap
    public class Manager : Tetap
    {
        public Manager(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan) { }

        public override void Kerja()
        {
            Console.WriteLine($"Manager {Nama} sedang mengawasi jalannya proyek dan kinerja tim.");
        }

        public void Memimpin()
        {
            Console.WriteLine($"Manager {Nama} sedang memimpin rapat divisi.");
        }
    }

    public class Staff : Tetap
    {
        public Staff(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan) { }

        public override void Kerja()
        {
            Console.WriteLine($"Staff {Nama} sedang menyelesaikan tugas operasional harian.");
        }

        public void KerjakanTugas()
        {
            Console.WriteLine($"Staff {Nama} sedang mengerjakan tugas spesifik yang diberikan.");
        }
    }

    // Subclass dari Class Kontrak
    public class Magang : Kontrak
    {
        public Magang(string nama, double gaji, int durasi) : base(nama, gaji, durasi) { }

        public override void Kerja()
        {
            Console.WriteLine($"Anak Magang {Nama} sedang belajar dan membantu tugas-tugas dasar.");
        }

        public void Belajar()
        {
            Console.WriteLine($"Magang {Nama} sedang mempelajari modul operasional perusahaan.");
        }
    }

    public class Freelancer : Kontrak
    {
        public Freelancer(string nama, double gaji, int durasi) : base(nama, gaji, durasi) { }

        public override void Kerja()
        {
            Console.WriteLine($"Freelancer {Nama} sedang menggarap proyek sesuai kesepakatan.");
        }

        public void AmbilProyek()
        {
            Console.WriteLine($"Freelancer {Nama} telah mengambil proyek baru.");
        }
    }

    // ==========================================
    // KELAS PERUSAHAAN
    // ==========================================
    public class Perusahaan
    {
        private List<Karyawan> daftarKaryawan = new List<Karyawan>();

        public void TambahKaryawan(Karyawan karyawan)
        {
            daftarKaryawan.Add(karyawan);
            Console.WriteLine($"Berhasil menambahkan {karyawan.Nama} ke sistem perusahaan.");
        }

        public void DaftarKaryawan()
        {
            Console.WriteLine("\n[   DAFTAR SELURUH KARYAWAN   ]");
            foreach (var k in daftarKaryawan)
            {
                k.InfoKaryawan();
            }
        }
    }

    // ==========================================
    // MAIN METHOD / DEMONSTRASI
    // ==========================================
    class Program
    {
        static void Main(string[] args)
        {
            // Buat objek perushaan
            Perusahaan ptMaju = new Perusahaan();

            // Buat objek karyawan
            Manager mgr = new Manager("Budi", 15000000, 5000000);
            Staff stf = new Staff("Siti", 6000000, 1000000);
            Magang mgng = new Magang("Rian", 2000000, 6);
            Freelancer fl = new Freelancer("Andi", 8000000, 3);

            // Tambahkan ke perusahaan
            Console.WriteLine("[   PROSES PENAMBAHAN KARYAWAN   ]");
            ptMaju.TambahKaryawan(mgr);
            ptMaju.TambahKaryawan(stf);
            ptMaju.TambahKaryawan(mgng);
            ptMaju.TambahKaryawan(fl);

            // Tampilkan semua data
            ptMaju.DaftarKaryawan();

            // Polymorphism
            Console.WriteLine("\n[  DEMONSTRASI POLYMORPHISM (Method Kerja)  ]");
            List<Karyawan> listKaryawan = new List<Karyawan> { mgr, stf, mgng, fl };
            foreach (var k in listKaryawan)
            {
                k.Kerja();
            }

            // Panggil method khusus
            Console.WriteLine("\n[   PEMANGGILAN METHOD KHUSUS   ]");
            mgr.Memimpin();
            stf.KerjakanTugas();
            mgng.Belajar();
            fl.AmbilProyek();
            Console.WriteLine($"Total Gaji Manager: Rp{mgr.HitungGajiTotal():N0}");
            mgng.CekKontrak();
        }
    }
}