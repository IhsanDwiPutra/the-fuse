using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareMendekat : MonoBehaviour
{
    public GameObject hantuDuduk;
    public GameObject hantuKaget1;
    public AudioSource suaraKaget;
    public AudioSource suaraTangisan;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")){
            StartCoroutine(KagetinDong());
        }
    }

    IEnumerator KagetinDong() {
        if (suaraTangisan != null) {
            suaraTangisan.Stop();
        }

        hantuDuduk.SetActive(false);
        hantuKaget1.SetActive(true);
        if (suaraKaget != null) {
            suaraKaget.Play();

            yield return new WaitForSeconds(2f);
        }
        hantuKaget1.SetActive(false);
        Destroy(gameObject);
    }
}
