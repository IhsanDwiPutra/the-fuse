using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Biar bisa mengatur perpindahan antar scene (Bangunan)

public class MenuUtama : MonoBehaviour
{
    // Fungsi ini akan dipanggil saat tombol mulai di klik
    public void MulaiGame() {
        // Menyuruh Unity memuat scene bernama "level1"
        SceneManager.LoadScene("level1");
    }

    // Fungsi ini akan dipanggil saat tombol keluar diklik
    public void KeluarGame() {
        // Menutup aplikasi game
        Debug.Log("Game Ditutup!");
        Application.Quit();
    }


}
