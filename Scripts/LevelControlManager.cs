using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelControlManager : MonoBehaviour {

    public int sceneIndex, levelPassed;
    

    // Use this for initialization
    void Start () {
       
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
	
	}
	
	public void youWin()
    {
        if (levelPassed < sceneIndex)
        {
            PlayerPrefs.SetInt("LevelPassed", sceneIndex);
        }
    }

    public void SceneIndex()
    {
        sceneIndex = sceneIndex++;
    }
}
