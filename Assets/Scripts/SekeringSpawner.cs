using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SekeringSpawner : MonoBehaviour
{
    [Header("Cetakan Sekering")]
    public GameObject sekeringPrefab; // Ini tempat naruh file biru (Prefab)

    [Header("Lokasi Spawn")]
    // List ini ibarat daftar belanjaan, biar lokasi yang udah kepilih bisa kita coret
    public List<Transform> daftarTitikNormal;
    public Transform titikKamarKhusus;



    // Start is called before the first frame update
    void Start()
    {
        SpawnSekering();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnSekering() {
        // 1. Kita munculkan 2 sekering di lokasi acak
        for (int i = 0; i < 2; i++) {
            // Pilih satu nomor urut secara acak dari daftar yang ada
            int indeksAcak = Random.Range(0, daftarTitikNormal.Count);

            // Munculkan cetakan sekering di titik acak yang terpilih
            Instantiate(sekeringPrefab, daftarTitikNormal[indeksAcak].position, daftarTitikNormal[indeksAcak].rotation, daftarTitikNormal[indeksAcak]);

            // Coret/hapus titik ini dari daftar, supaya sekering ke-2 nggak muncul di laci yang sama
            daftarTitikNormal.RemoveAt(indeksAcak);
        }

        // Kita munculkan 1 sekering di kamar khusus
        if (titikKamarKhusus != null) {
            Instantiate(sekeringPrefab, titikKamarKhusus.position, titikKamarKhusus.rotation, titikKamarKhusus);
        }
    }
}
