using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaklarController : MonoBehaviour
{
    private Animator anim;
    private bool isHidup = true;

    public Light cahayaLampu;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteraksiSaklar() {
        isHidup = !isHidup;

        anim.SetBool("isHidup", isHidup);

        if (cahayaLampu != null) {
            cahayaLampu.enabled = isHidup;
        }

    }
}
