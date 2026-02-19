using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareBalikBadan : MonoBehaviour
{
    public GameObject hantuKaget;
    public AudioSource suaraKaget;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")){
            StartCoroutine(KagetinDong());
        }
    }

    IEnumerator KagetinDong() { 
        hantuKaget.SetActive(true);
        if (suaraKaget != null) {
            suaraKaget.Play();

            yield return new WaitForSeconds(1f);
        }
        hantuKaget.SetActive(false);
        Destroy(gameObject);
    }
}
