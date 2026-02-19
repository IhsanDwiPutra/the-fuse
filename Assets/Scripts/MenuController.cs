using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public AudioSource ambience;

    private void Start() {
        ambience.Play();
    }

    public void KlikMulai() {
        SceneManager.LoadScene("Level1");
        ambience.Stop();
    }

    public void KlikKeluar() {
        Application.Quit();
    }

}
