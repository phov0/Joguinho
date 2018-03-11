using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ButtonController : MonoBehaviour
{

    private SpriteRenderer theSprite;

    public AudioSource thisAudioSource;

    public int thisButtonNumber;

    private GameManager theGM;


    // Use this for initialization
    void Start()
    {
        theSprite = GetComponent<SpriteRenderer>();
        theGM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        theSprite.color = new Color(theSprite.color.r, theSprite.color.g, theSprite.color.b, 1f);
    }

    void OnMouseUp()
    {
        theSprite.color = new Color(theSprite.color.r, theSprite.color.g, theSprite.color.b, 0.5f);
        theGM.NotasPressed(thisButtonNumber);
        thisAudioSource.Play();
    }
}