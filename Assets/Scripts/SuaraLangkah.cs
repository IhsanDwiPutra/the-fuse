using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuaraLangkah : MonoBehaviour
{
    public AudioSource speakerKaki;

    [Header("Daftar Suara Langkah")]
    public AudioClip[] kasetLangkah;

    [Header("Pengaturan Waktu")]
    public float jedaLangkah = 0.5f;

    private float waktuLangkahSelanjutnya = 0f;

    private void Update() {
        float gerakX = Input.GetAxis("Horizontal");
        float gerakZ = Input.GetAxis("Vertical");

        bool sedangJalan = (Mathf.Abs(gerakX) > 0.1f || Mathf.Abs(gerakZ) > 0.1f);

        if (sedangJalan) {
            if (Time.time >= waktuLangkahSelanjutnya) {
                MainkanSuaraLangkah();
                waktuLangkahSelanjutnya = Time.time + jedaLangkah;
            }
        }
    }

    void MainkanSuaraLangkah() {
        if (speakerKaki != null && kasetLangkah.Length > 0) {
            int indeksAcak = Random.Range(0, kasetLangkah.Length);

            speakerKaki.clip = kasetLangkah[indeksAcak];
            speakerKaki.Play();
        }
    }

}
