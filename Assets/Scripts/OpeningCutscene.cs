using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningCutscene : MonoBehaviour
{
    public GameObject pemainAsli;
    public GameObject kameraOpening;
    public Image layarHitam;
    public AudioSource ambienceNight;

    [Header("Event Mati Listrik")]
    public Light lampuUtama;
    public AudioSource listrikMati;


    // Start is called before the first frame update
    void Start()
    {
        ambienceNight.Play();
        Cursor.lockState = CursorLockMode.Locked;
        pemainAsli.SetActive(false);
        kameraOpening.SetActive(true);

        layarHitam.gameObject.SetActive(true);

        if (lampuUtama != null) {
            lampuUtama.enabled = true;
        }

        StartCoroutine(MulaiAdegan());
    }

    IEnumerator MulaiAdegan() {
        layarHitam.CrossFadeAlpha(0, 3.0f, false);

        yield return new WaitForSeconds(2.5f);

        if (lampuUtama != null) {
            listrikMati.Play();
            lampuUtama.enabled = false;
            yield return new WaitForSeconds(0.5f);
            lampuUtama.enabled = true;
            yield return new WaitForSeconds(0.5f);
            lampuUtama.enabled = false;

        }

        yield return new WaitForSeconds(1.5f);

        pemainAsli.SetActive(true);
        kameraOpening.gameObject.SetActive(false);
        layarHitam.gameObject.SetActive(false);

        Destroy(gameObject);
    }
}
