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

    [Header("Event Awal Game")]
    public SenterController kontrolSenter;
    public PintuController[] daftarPintuKamarLain;
    private bool sudahCekKotak = false;

    [Header("Event Kamar Khusus")]
    public PintuController pintuKamarKhusus;
    public AudioSource suaraTangisan;


    // Start is called before the first frame update
    void Start()
    {
        teksLayar.text = "Ambil Senter di atas meja";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            // Menyiapkan variabel untuk menyimpan informasi benda apa yang ketabrak laser
            RaycastHit hit;

            // Menembakkan sinar laser (Raycast) dari kamera ke arah depan sepanjang 'jarakAmbil'
            if (Physics.Raycast(transform.position, transform.forward, out hit, jarakAmbil)) {
                // Mengecek apakah benda yang ketabrak punya tag "sekering"
                if (hit.transform.CompareTag("Sekering")) {
                    if (sudahCekKotak == true) {
                        jumlahSekering++;
                        Destroy(hit.transform.gameObject);
                        teksLayar.text = "Sekering: " + jumlahSekering + " / 3";

                        // Event nangis
                        if (jumlahSekering == 2) {
                            if (pintuKamarKhusus != null) {
                                pintuKamarKhusus.isTerkunci = false;
                            }
                            if (suaraTangisan != null) { 
                                suaraTangisan.Play();
                            }
                        }

                        if (jumlahSekering >= 3) {
                            teksLayar.text = "Perbaiki Kotak Sekering!";
                        }
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
                    LemariBesarController lemari = hit.transform.GetComponentInParent<LemariBesarController>();

                    if (lemari != null) {
                        lemari.InteraksiLemari();
                    }
                } else if (hit.transform.CompareTag("Laci")) {
                    LaciController laci = hit.transform.GetComponent<LaciController>();

                    if (laci != null) {
                        laci.InteraksiLaci();
                    }
                // else if (hit.transform.CompareTag("PintuKotakSekering")) {
                //    PintuKotakSekeringController pintu = hit.transform.GetComponentInParent<PintuKotakSekeringController>();

                //    if (pintu != null) {
                //        pintu.InteraksiPintuKotakSekering();
                //    }
                } else if (hit.transform.CompareTag("TuasKotakSekering")) {
                    TuasController tuas = hit.transform.GetComponentInParent<TuasController>();

                    if (tuas != null) {
                        tuas.InteraksiTuas();
                    }
                } else if (hit.transform.CompareTag("LaciDinding")) {
                    LaciDindingController pintu = hit.transform.GetComponentInParent<LaciDindingController>();

                    if (pintu != null) {
                        pintu.InteraksiLaci();
                    }
                } else if (hit.transform.CompareTag("LaciDapur")) {
                    LaciDapurController laci = hit.transform.GetComponentInParent<LaciDapurController>();

                    if (laci != null) {
                        laci.InteraksiLaci();
                    }
                } else if (hit.transform.CompareTag("PintuBawahDapur")) {
                    PintuBawahDapurController pintu = hit.transform.GetComponentInParent<PintuBawahDapurController>();

                    if (pintu != null) {
                        pintu.InteraksiPintu();
                    }
                } else if (hit.transform.CompareTag("Saklar")) {
                    SaklarController saklar = hit.transform.GetComponentInParent<SaklarController>();

                    if (saklar != null) {
                        saklar.InteraksiSaklar();
                    }

                } else if (hit.transform.CompareTag("Senter")) {
                    if (kontrolSenter != null) {
                        kontrolSenter.punyaSenter = true;
                    }

                    Destroy(hit.transform.gameObject);
                    teksLayar.text = "Cek Kotak Sekering di luar";

                } else if (hit.transform.CompareTag("PintuKotakSekering")) {
                    if (sudahCekKotak == false) {
                        sudahCekKotak = true;
                        teksLayar.text = "Sekering: 0 / 3";

                        foreach (PintuController pintuu in daftarPintuKamarLain) {
                            if (pintuu != null) {
                                pintuu.isTerkunci = false;
                            }
                        }
                    }
                    PintuKotakSekeringController pintu = hit.transform.GetComponentInParent<PintuKotakSekeringController>();
                    if (pintu != null) { 
                        pintu.InteraksiPintuKotakSekering();
                    }
                } 
            }
        }
    }
}
