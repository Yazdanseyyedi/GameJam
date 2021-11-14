using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public Text greenScore;
    public Text redScore;
    public bool GameReload;
    // Start is called before the first frame update
    void Start()
    {
        
        if (PlayerPrefs.GetInt("ReloadGame") == 1)
        {
            
            greenScore.text = PlayerPrefs.GetInt("GreenScore").ToString();
            redScore.text = PlayerPrefs.GetInt("RedScore").ToString();
            Debug.Log("Reloaded");
        }
        else
        {
            greenScore.text = "0";
            redScore.text = "0";
        }
        PlayerPrefs.SetInt("ReloadGame", 0);
    }

    // Update is called once per frame
    public void UpdateGreenScore()
    {
        int newTextValue = int.Parse(greenScore.text) + 1;
        greenScore.text = newTextValue.ToString();
    }

    public void ReloadGame()
    {
        Debug.Log(int.Parse(redScore.text));

        PlayerPrefs.SetInt("RedScore", int.Parse(redScore.text));
        PlayerPrefs.SetInt("GreenScore", int.Parse(greenScore.text));
        PlayerPrefs.SetInt("ReloadGame", 1);
        SceneManager.LoadScene(0);

    }

    public void UpdateRedScore()
    {
        int newTextValue = int.Parse(redScore.text) + 1;
        redScore.text = newTextValue.ToString();
    }
}
