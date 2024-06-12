using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Assets.Scripts;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToPvP()
    {
        GameSettings.gameMode = GameMode.PvP;
        SceneManager.LoadScene("GameScene");
    }

    public void GoToPvE()
    {
        GameSettings.gameMode = GameMode.PvE;
        SceneManager.LoadScene("GameScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
