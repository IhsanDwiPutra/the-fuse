using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenterController : MonoBehaviour
{
    public Light lampuSenter; // Tempat kita memasukkan senter nanti
    private bool senterNyala = false;
    public bool punyaSenter = false;
    public AudioSource senterOn;

    // Start is called before the first frame update
    void Start()
    {
        lampuSenter.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (punyaSenter == true && Input.GetKeyDown(KeyCode.F)) {
            senterOn.Play();
            senterNyala = !senterNyala;
            lampuSenter.enabled = senterNyala;
        }
    }
}
