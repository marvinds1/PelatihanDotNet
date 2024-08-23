# Pelatihan .NET
Pelatihan Terkait:

Day 2:
1. OOP:
- Sudah dilakukan beberapa perubahan kode minor untuk merapikan kode sebelumnya.
- Menambahkan fitur show other account (member) yang telah didaftarkan.
- Menambahkan fitur management password untuk mengganti password serta verifikasinya.
2. Database SQL
- Telah dibuat beberapa table yang mengandung relational yang telah ditentukan sebelumnya
- Telah dicoba query left join untuk menampilkan data pada table
- Disertakan Foto dan Query SQLnya

Day 3:
1. LearnWebApi
- Telah menambahkan endpoint sesuai task yang diberikan
- Salah satunya adalah create tablespecification dengan runtutan array table yang dimasukkan sekaligus, berikut contoh json requestnya:
{
  "listTable": [
    {
        "tableNumber": 11,
        "chairNumber": 4,
        "tablePic": "table1.jpg",
        "Type": "Dining"
    },
    {
        "tableNumber": 12,
        "chairNumber": 6,
        "tablePic": "table2.jpg",
        "Type": "Conference"
    },
    {
        "tableNumber": 13,
        "chairNumber": 2,
        "tablePic": "table3.jpg",
        "Type": "Coffee"
    }
  ]
}

Day 3:
1. Telah menambahkan koneksi dengan redis beserta TTL 10 menit.
2. Telah menambahkan snyc add terhadap redis setiap ada penambahan data
3. Ketika redis mati akan otomatis hit ke SQL