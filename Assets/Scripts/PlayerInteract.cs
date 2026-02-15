using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    public float jarakAmbil = 3f; // Seberapa panjang tanganmu bisa nyampe
    public int jumlahSekering = 0; // Mengingat sudah berapa sekering yang keambil
    public TextMeshProUGUI teksLayar; // Wadah untuk teks UI
    public Light lampuRumah; // Wadah untuk lampu utama (matahari)

    // Start is called before the first frame update
    void Start()
    {
        // Memastikan saat awal main, tulisannya 0 / 3
        teksLayar.text = "Sekering: 0 / 3";
    }

    // Update is called once per frame
    void Update()
    {
        // 1. Mengecek apakah pemain menekan tombol 'E'
        if (Input.GetKeyDown(KeyCode.E)) {
            // 2. Menyiapkan variabel untuk menyimpan informasi benda apa yang ketabrak laser
            RaycastHit hit;

            // 3. Menembakkan sinar laser (Raycast) dari kamera ke arah depan sepanjang 'jarakAmbil'
            if (Physics.Raycast(transform.position, transform.forward, out hit, jarakAmbil)) {
                // 4. Mengecek apakah benda yang ketabrak punya tag "sekering"
                if (hit.transform.CompareTag("Sekering")) {
                    // 5. Kalau benar itu sekering, kita ambil!
                    jumlahSekering++; // Tambah jumlah sekering kita
                    Debug.Log("Dapat satu sekering! Total sekarang: " + jumlahSekering);

                    // 6. Hancurkan/hilangkan sekering dari dunia (karena ceritanya udah masok kantong)
                    Destroy(hit.transform.gameObject);

                    // Update tulisan id layar setiap dapat sekering
                    teksLayar.text = "Sekering: " + jumlahSekering + " / 3";

                    // Logika menang: Cek apakah sekering sudah 3 atau lebih?
                    if (jumlahSekering >= 3) {
                        // Nyalakan lampu utama
                        lampuRumah.enabled = true;

                        // Ubah tulisan menjadi menang
                        teksLayar.text = "Listrik Menyala! Keluarrr!!!";
                    }
                } else if (hit.transform.CompareTag("Pintu")) {
                    // Ambil script pintu controller
                    PintuController pintu = hit.transform.GetComponentInParent<PintuController>();

                    // Kalau scriptnya ketemu, suruh jalankan animasi!
                    if (pintu != null) {
                        pintu.InteraksiPintu();
                    }
                } else if (hit.transform.CompareTag("PintuDepan")) {
                    PintuDepanController pintu = hit.transform.GetComponentInParent<PintuDepanController>();

                    if (pintu != null) {
                        pintu.InteraksiPintu();
                    }
                } else if (hit.transform.CompareTag("LemariBesar")) {
                    Debug.Log("Halo dari lemari");
                    LemariBesarController lemari = hit.transform.GetComponentInParent<LemariBesarController>();

                    if (lemari != null) {
                        lemari.InteraksiLemari();
                    }
                }
            }
        }
    }
}
