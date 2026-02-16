using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuasController : MonoBehaviour
{
    private Animator anim;
    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteraksiTuas() {
        isOpen = !isOpen;

        anim.SetBool("isBuka", isOpen);
    }
}
