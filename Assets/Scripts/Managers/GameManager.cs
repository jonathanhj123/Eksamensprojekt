using System.Collections;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private float scoremultiplier;
   // [SerializeField] private AudioClip backgroundMusic;
    public static GameManager Instance;
    public TextMeshProUGUI scoreText;
    private int castInt;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(GameData.Instance == null){
            GameObject dataObj = new GameObject("GameData");
            dataObj.AddComponent<GameData>();
        }
        SetScoremultiplierByDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
 //       if(GameData.Instance.GameRunning) {
            GameData.Instance.RoundScore += Time.deltaTime * scoremultiplier; 
            scoreText.text = (int)GameData.Instance.RoundScore + " Meters";    
//        }
    }
    
    public void StartGame() {
        GameData.Instance.RoundScore = 0;
        GameData.Instance.RoundCoins = 0;
        GameData.Instance.GameRunning = true;
        //SoundFXManager.Instance.PlayMusic(backgroundMusic, 1f);
    }

//Potentielt fjernes
    void SetScoremultiplierByDifficulty() {
        if (GameData.Instance.Difficulty == "Easy") {
            scoremultiplier = 1f;
        }
        if (GameData.Instance.Difficulty == "Normal") {
            scoremultiplier = 1.25f;
        }
        if (GameData.Instance.Difficulty == "Hard") {
            scoremultiplier = 2f;
        }
    }

    public void EndRound() {
        SaveCoins();
        CheckIfHighscore();
        GameData.Instance.GameRunning = false;
    }

    public void CheckIfHighscore() {
        if (GameData.Instance.RoundScore > GameData.Instance.Highscore)
        {
            GameData.Instance.LastHighscore = GameData.Instance.Highscore;
            GameData.Instance.Highscore = GameData.Instance.RoundScore;
            GameData.Instance.NewHighscoreWasSest = true;
        }
        else GameData.Instance.NewHighscoreWasSest = false;
    }

    public void SaveCoins()
    {
        GameData.Instance.LastTotalCoins = GameData.Instance.NewTotalCoins;
        GameData.Instance.NewTotalCoins += GameData.Instance.RoundCoins;
    }

}