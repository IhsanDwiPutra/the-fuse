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

    [Header("Event Mendapatkan 3 Sekering")]
    public PintuDepanController pintuDepan;
    public Light[] lampuRuangan;
    public BoxCollider jumpscareBalikBadan;
    public GameObject visualSekering1;
    public GameObject visualSekering2;
    public GameObject visualSekering3;

    [Header("SFX")]
    public AudioSource ambilItem;
    public AudioSource bukaLaci;
    public AudioSource bukaLemari;
    public AudioSource bukaPintu;
    public AudioSource saklarOn;
    public AudioSource tuasOn;

    // Start is called before the first frame update
    void Start()
    {
        teksLayar.text = "Ambil Senter di atas meja";
        foreach (Light lampu in lampuRuangan) {
            if (lampu != null) {
                lampu.enabled = false;
            }
        }
        jumpscareBalikBadan.enabled = false;
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
                        teksLayar.text = "Cari Sekering: " + jumlahSekering + " / 3";
                        ambilItem.Play();
                        Destroy(hit.transform.gameObject);

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
                    bukaPintu.Play();

                    // Kalau scriptnya ketemu, suruh jalankan animasi!
                    if (pintu != null) {
                        pintu.InteraksiPintu();
                    }
                } else if (hit.transform.CompareTag("PintuDepan")) {
                    PintuDepanController pintu = hit.transform.GetComponentInParent<PintuDepanController>();
                    bukaPintu.Play();

                    if (pintu != null) {
                        pintu.InteraksiPintu();
                    }
                } else if (hit.transform.CompareTag("LemariBesar")) {
                    LemariBesarController lemari = hit.transform.GetComponentInParent<LemariBesarController>();
                    bukaLemari.Play();

                    if (lemari != null) {
                        lemari.InteraksiLemari();
                    }
                } else if (hit.transform.CompareTag("Laci")) {
                    LaciController laci = hit.transform.GetComponent<LaciController>();
                    bukaLaci.Play();

                    if (laci != null) {
                        laci.InteraksiLaci();
                    }
                } else if (hit.transform.CompareTag("KotakSekering")) {
                    KotakSekeringController kotak = hit.transform.GetComponentInParent<KotakSekeringController>();
                    ambilItem.Play();

                    if (jumlahSekering >= 3) {
                        teksLayar.text = "Berhasil Memasukkan Sekering, Tarik Tuas";
                        visualSekering1.SetActive(true);
                        visualSekering2.SetActive(true);
                        visualSekering3.SetActive(true);
                    }

                } else if (hit.transform.CompareTag("TuasKotakSekering")) {
                    TuasController tuas = hit.transform.GetComponentInParent<TuasController>();
                    tuasOn.Play();

                    if (jumlahSekering >= 3) {
                        teksLayar.text = "Keluar dari Pintu Depan!!!";
                        pintuDepan.isTerkunci = false;
                        jumpscareBalikBadan.enabled = true;
                        foreach (Light lampu in lampuRuangan) {
                            if (lampu != null) {
                                lampu.enabled = true;
                            }
                        }

                        if (tuas != null) {
                            tuas.InteraksiTuas();
                        }
                    }

                } else if (hit.transform.CompareTag("LaciDinding")) {
                    LaciDindingController pintu = hit.transform.GetComponentInParent<LaciDindingController>();
                    bukaLaci.Play();

                    if (pintu != null) {
                        pintu.InteraksiLaci();
                    }
                } else if (hit.transform.CompareTag("LaciDapur")) {
                    LaciDapurController laci = hit.transform.GetComponentInParent<LaciDapurController>();
                    bukaLaci.Play();

                    if (laci != null) {
                        laci.InteraksiLaci();
                    }
                } else if (hit.transform.CompareTag("PintuBawahDapur")) {
                    PintuBawahDapurController pintu = hit.transform.GetComponentInParent<PintuBawahDapurController>();
                    bukaLaci.Play();

                    if (pintu != null) {
                        pintu.InteraksiPintu();
                    }
                } else if (hit.transform.CompareTag("Saklar")) {
                    SaklarController saklar = hit.transform.GetComponentInParent<SaklarController>();
                    saklarOn.Play();

                    if (saklar != null && jumlahSekering >= 3) {
                        saklar.InteraksiSaklar();
                    }

                } else if (hit.transform.CompareTag("Senter")) {
                    if (kontrolSenter != null) {
                        kontrolSenter.punyaSenter = true;
                    }

                    ambilItem.Play();
                    Destroy(hit.transform.gameObject);
                    teksLayar.text = "Cek Kotak Sekering di luar";

                } else if (hit.transform.CompareTag("PintuKotakSekering")) {
                    if (sudahCekKotak == false) {
                        sudahCekKotak = true;
                        teksLayar.text = "Cari Sekering: 0 / 3";

                        foreach (PintuController pintuu in daftarPintuKamarLain) {
                            if (pintuu != null) {
                                pintuu.isTerkunci = false;
                            }
                        }
                    }
                    PintuKotakSekeringController pintu = hit.transform.GetComponentInParent<PintuKotakSekeringController>();
                    bukaLaci.Play();
                    if (pintu != null) {
                        pintu.InteraksiPintuKotakSekering();
                    }
                } 
            }
        }
    }
}
