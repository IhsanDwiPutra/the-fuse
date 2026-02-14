using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f; // Kecepatan Jalan


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. Membaca tombol yang ditekan (W,A,S,D)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // 2. Menentukan arah gerak sesuai posisi karakter menghahadap
        Vector3 move = transform.right * x + transform.forward * z;

        // 3. Menyuruh karaktere bergerak sesuai arah dan kecepatan
        controller.Move(move * speed * Time.deltaTime);
    }
}
