using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LevelSelectorManager : MonoBehaviour {

    public void StartTutorial()
    {
        SceneManager.LoadScene(2);
    }

	public void StartMajorScales () {

        SceneManager.LoadScene(3);

    }

    public void StartMinorScales()
    {

        SceneManager.LoadScene(4);

    }

    public void StartHarmonicMinor()
    {

        SceneManager.LoadScene(5);

    }

    public void StartMelodicMinor()
    {

        SceneManager.LoadScene(6);

    }

}
