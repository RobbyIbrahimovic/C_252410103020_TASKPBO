## Sistem Manajemen Karyawan (TASK PBO - Kelas C)

Repository ini berisi implementasi program **Sistem Manajemen Karyawan** menggunakan bahasa pemrograman **C#** (.NET) untuk memenuhi Tugas Praktikum Pemrograman Berorientasi Objek (PBO) Kelas C.

---

## Penjelasan Struktur Program & Kelas

Proyek ini dibuat dengan menerapkan konsep utama **Object-Oriented Programming (OOP)** seperti *Inheritance*, *Polymorphism*, *Method Overriding*, dan *Abstraction*. Berikut adalah komponen/kelas yang ada di dalam proyek ini:

1. **`Karyawan` (Base Class):**
   - Kelas induk utama yang menyimpan data dasar karyawan.
   - Properti: `Nama`, `Gaji`
   - Method: `Kerja()`, `InfoKaryawan()`

2. **`Tetap` (Turunan dari `Karyawan`):**
   - Kelas untuk karyawan bernstatus tetap.
   - Properti tambahan: `Tunjangan`
   - Method tambahan: `HitungGajiTotal()`

3. **`Kontrak` (Turunan dari `Karyawan`):**
   - Kelas untuk karyawan berspesifikasi kontrak.
   - Properti tambahan: `Durasi`
   - Method tambahan: `CekKontrak()`

4. **`Manager` (Turunan dari `Tetap`):**
   - Meng-override method `Kerja()` untuk tugas manajerial.
   - Method khusus: `Memimpin()`

5. **`Staff` (Turunan dari `Tetap`):**
   - Meng-override method `Kerja()` untuk operasional.
   - Method khusus: `KerjakanTugas()`

6. **`Magang` (Turunan dari `Kontrak`):**
   - Meng-override method `Kerja()` untuk kegiatan magang.
   - Method khusus: `Belajar()`

7. **`Freelancer` (Turunan dari `Kontrak`):**
   - Meng-override method `Kerja()` untuk pengerjaan proyek.
   - Method khusus: `AmbilProyek()`

8. **`Perusahaan`:**
   - Mengelola koleksi data karyawan berbasis `List<Karyawan>`.
   - Method: `TambahKaryawan()`, `DaftarKaryawan()`

9. **`Program.cs`:**
   - Main entry point tempat pengujian objek, demonstrasi *Polymorphism*, dan pemanggilan method-method khusus.

---

## 📐 Class Diagram (UML)

Berikut adalah diagram kelas (*Class Diagram*) dari Sistem Manajemen Karyawan:

<img width="827" height="745" alt="image" src="https://github.com/user-attachments/assets/5f925351-bf52-448d-9872-59f5e52042ab" />

---

## 👨‍💻 Identitas

- **Nama:** Robby Ibrahimovic Wibowo
- **NIM:** 252410103020
- **Kelas:** C
- **Prodi:** Informatika - Universitas Jember
