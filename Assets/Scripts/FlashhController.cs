using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashhController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteraksiSenter() {
        Debug.Log("Anda mengambil senter!");
        Destroy(gameObject);
    }
}
