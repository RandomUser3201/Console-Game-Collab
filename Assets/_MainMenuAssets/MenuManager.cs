using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void PlaySurvivalGame()
    {
        SceneManager.LoadScene("SurvivalScene");
    }

    public void PlayStealthGame()
    {
        SceneManager.LoadScene("StealthScene");
    }

    public void PlayFightingGame()
    {
        SceneManager.LoadScene("FightingScene");
    }

}
