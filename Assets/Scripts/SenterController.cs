using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenterController : MonoBehaviour
{
    public Light lampuSenter; // Tempat kita memasukkan senter nanti
    private bool senterNyala = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Mengecek apakah pemain menekan tombol F di keyboard
        if (Input.GetKeyDown(KeyCode.F)) {
            // Membalikkan keadaan. kalau nyala jadi mati, mati jadi nyala.
            senterNyala = !senterNyala;

            // Menerapkan keadaan tersebut ke lampunya
            lampuSenter.enabled = senterNyala;
        }
    }
}
