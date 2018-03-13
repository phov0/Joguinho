using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour {

    //carregar o audio do jogo.
    public AudioMixer audioMixer;
    public List <AudioSource> Audiofundo;

    public void StartGame()
    {
        SceneManager.LoadScene(1);

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void Credits()
    {
        SceneManager.LoadScene(4);
    }

    public void SetVolume(float volume)
    {   
        //atribuir o slider na UI com o mixer criado para controlar o volume do jogo.
        audioMixer.SetFloat("volume", volume);
    }

    public void resetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
