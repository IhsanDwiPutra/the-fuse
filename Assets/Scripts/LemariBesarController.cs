using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemariBesarController : MonoBehaviour
{
    private Animator anim;
    private bool isBuka = false;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteraksiLemari() {
        isBuka = !isBuka;

        anim.SetBool("isBuka", isBuka);
    }
}
