using System;
using System.Collections.Generic;

namespace uts_pbo
{
    public class Karyawan
    {
        public string Nama { get; set; }
        public string Gaji { get; set; }
        public Karyawan(string Nama, string Gaji)
        {
            this.Nama = Nama;
            this.Gaji = Gaji;
        }

        public virtual void Kerja()
        {
            Console.WriteLine($"{Nama} sedang bekerja.");
        }
        public virtual void InfoKaryawan()
        {
            Console.WriteLine($"Nama: {Nama}, Gaji: Rp{Gaji:N0}");
        }

    }
    public class Tetap : Karyawan
    {
        public double Tunjangan { get; set; }

        public Tetap(string nama, string gaji, double tunjangan) : base(nama, gaji)
        {
            this.Tunjangan = tunjangan;
        }

        public double HitungGajiTotal()
        {
            return double.Parse(Gaji) + Tunjangan;
        }

        public override void InfoKaryawan()
        {
            Console.WriteLine($"Nama: {Nama}, Gaji: Rp{Gaji:N0}, Tunjangan: Rp{Tunjangan:N0}, Gaji Total: Rp{HitungGajiTotal():N0}");
        }
        public class Kontrak : Karyawan
        {
            public int JamKerja { get; set; }
            public Kontrak(string nama, string gaji, int jamKerja) : base(nama, gaji)
            {
                this.JamKerja = jamKerja;
            }
            public void CekKontrak()
            {
                Console.WriteLine($"Sisa/Durasi kontrak {Nama} adalah {JamKerja} jam.");
            }
        }

        public class Manager : Tetap
        {
            public Manager(string Nama, string Gaji, double Tunjangan) : base(Nama, Gaji, Tunjangan) { }
           
            public override void Kerja()
            {
                Console.WriteLine($"{Nama} (Manager) sedang memimpin divisi dan merencanakan strategi.");
            }
            public void Memimpin()
            {
                Console.WriteLine($"{Nama} sedang memimpin rapat tim");
            }
            
        }
        public class Staff : Tetap
        {
            public Staff(string Nama, string Gaji, double Tunjangan) : base(Nama, Gaji, Tunjangan) { }

            public override void Kerja()
            {
                Console.WriteLine($"{Nama} (Staff) sedang mengerjakan tugas-tugas operasional.");
            }
            public void KerjakanTUGAS()
            {
                Console.WriteLine($"{Nama} sedang menyelesaikan tugas bulanan.");
            }
        }
        public class Magang : Kontrak
        {
            public Magang(string Nama, string Gaji, int JamKerja) : base(Nama, Gaji, JamKerja) { }
            public override void Kerja()
            {
                Console.WriteLine($"{Nama} (Magang) sedang membantu pekerjaan tim senior.");
            }
            public void Belajar()
            {
                Console.WriteLine($"{Nama} sedang mempelajari modul dan alur perusahaan.");
            }
        }
        public class Freelancer : Kontrak
        {
            public Freelancer(string Nama, string Gaji, int JamKerja) : base(Nama, Gaji, JamKerja) { }
            public override void Kerja()
            {
                Console.WriteLine($"{Nama} (Freelancer) sedang menyelesaikan deliverable proyek.");
            }
            public void AmbilProyek()
            {
                Console.WriteLine($"{Nama} telah mengambil proyek baru.");
            }
        }
        public class Perusahaan
        {
            private List <Karyawan> daftarkaryawan = new List<Karyawan>();
            public void TambahKaryawan(Karyawan karyawan)
            {
                daftarkaryawan.Add(karyawan);
                Console.WriteLine ($"berhasil menambahkan {karyawan.Nama} ke perusahaan.");
            }
            public void DaftarKaryawan()
            {
                Console.WriteLine ("\n=== Daftar Karyawan Perusahaan ===");
                foreach (var k in daftarkaryawan)
                {
                    k.InfoKaryawan();
                }
            }
        }
        class program
        {
            static void Main(string[] args)
            {
                Perusahaan corp = new Perusahaan();
                Manager mgr = new Manager("Andi", "10000000", 2000000);
                Staff stf = new Staff("Budi", "7000000", 1000000);
                Magang mgng = new Magang("Citra", "3000000", 6);
                Freelancer frl = new Freelancer("Dewi", "5000000", 3);
                corp.TambahKaryawan(mgr);
                corp.TambahKaryawan(stf);
                corp.TambahKaryawan(mgng);
                corp.TambahKaryawan(frl);
                
                corp.DaftarKaryawan();
                
                Console.WriteLine("\n=== Demo polimorphism ===");
                List <  Karyawan> daftarPolymorphism = new List<Karyawan> { mgr, stf, mgng, frl };
                foreach (Karyawan k in daftarPolymorphism)
                {
                    k.Kerja();
                }
                Console.WriteLine("\n=== Demo method khusus ===");
                mgr.Memimpin();
                stf.KerjakanTUGAS();
                mgng.Belajar();
                frl.AmbilProyek();
            }
        }
    }
}