using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class CreditsManager : MonoBehaviour {

    private SpriteRenderer theSprite;
    public AudioSource AudioCredits;

    // Use this for initialization
    void Start()
    {
        theSprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitFor());
    }

    IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(23);

        SceneManager.LoadScene(0);
    }

    void OnMouseDown()
    {
        Time.timeScale = 0f;
    }

    void OnMouseUp()
    {
        Time.timeScale = 1f;
    }
}
