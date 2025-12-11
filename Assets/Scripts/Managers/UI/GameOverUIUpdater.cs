using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUIUpdater : MonoBehaviour
{
    public TextMeshProUGUI OldScore;
    public GameObject RoundStatsPanel;
    public TextMeshProUGUI GameOverTMP;
    public TextMeshProUGUI RoundScoreTMP;
    public TextMeshProUGUI HighscoreTMP;
    public TextMeshProUGUI CoinsTMP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI() {
        StartCoroutine(GameOverCoroutine());
    }

    IEnumerator GameOverCoroutine() {
        yield return new WaitForSeconds(0.25f);
        
        OldScore.text = "";
        GameOverTMP.text = "Game Over";
        yield return new WaitForSeconds(1f);
        GameOverTMP.text = "";
        RoundStatsPanel.SetActive(true);
        RoundScoreTMP.text = "Score: " + (int)GameData.Instance.RoundScore + "m";

        if (GameData.Instance.NewHighscoreWasSest) 
        {
            HighscoreTMP.text = "Highscore: " + (int)GameData.Instance.Highscore + "m (NEW)";
        } 
        else 
        { 
            HighscoreTMP.text = "Highscore: " + (int)GameData.Instance.Highscore + "m";
        }
        
        CoinsTMP.text = "Coins collected: " + GameData.Instance.RoundCoins;
        
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("MainScreen");
    }
}
