using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitikAkhir : MonoBehaviour
{
    public Image layarHitam;

    private void Start() {
        layarHitam.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {

            layarHitam.CrossFadeAlpha(0, 3.0f, false);
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
