using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f; // Kecepatan nengok
    public Transform playerBody; // Untuk menyambungkan kepala dengan badan

    float xRotation = 0f; // Untuk mengingat seberapa jauh kita nunduk

    // Start is called before the first frame update
    void Start()
    {
        // Menyembunyikan dan mengunci kursor mouse di tengah layar
        // Biar kursornya gak keluar-keluar dari jendela game
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // 1. Membaca pergerakan mouse (Kiri-Kanan dan Atas-Bawah)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 2. Mengatur pergerakan nengok atas-bawah
        // Kenapa dikurang (-)? Kalau ditambah, saat mouse ke atas, kameranya malah nunduk (kebalik)
        xRotation -= mouseY;

        // 3. Membatasi nengok atas-bawah biar lehernya gak "patah" muter 360 derajat
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // 4. Menerapkan rotasi atas-bawah ke Kamera (Mata)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 5. Memutar badan (kapsul) ke kiri dan kanan)
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
