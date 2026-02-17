using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintuController : MonoBehaviour
{
    private Animator anim;
    private bool kondisiBuka = false;

    public bool isTerkunci = false;

    // Start is called before the first frame update
    void Start()
    {
        // Mengambil komponen Animator yang ada di pintu ini
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Fungsi ini akan dipanggil oleh tembakan laser pemain nanti
    public void InteraksiPintu() {

        if (isTerkunci) {
            Debug.Log("Pintu Terkunci");
        } else { 
            // Membalikkan keadaaan
            kondisiBuka = !kondisiBuka;

            // Mengirim perintah ke Animtor
            anim.SetBool("isBuka", kondisiBuka);
        }

    }
}
