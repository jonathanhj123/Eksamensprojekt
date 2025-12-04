using UnityEngine;

public class GameData : MonoBehaviour
{
 public static GameData Instance { get; private set; }

    [Header("Score Data")]
    public float RoundScore { get; set; }
    public float LastHighscore { get; set; }
    public float Highscore { get; set; }
    public bool NewHighscoreWasSest { get; set; }

    [Header("Coin Data")]
    public int RoundCoins { get; set; }
    public int LastTotalCoins { get; set; }
    public int NewTotalCoins { get; set; }

    [Header("Other")]
    public bool GameRunning { get; set; } 
    public string Difficulty { get; set; }


    //For loading highscore and coins at initial launch
    [SerializeField] MainScreenUIToggles mainScreenUI;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Initialize default values
            LastHighscore = 0;
            Highscore = 0;
            LastTotalCoins = 0;
            NewTotalCoins = 0;
            Difficulty = "Hard";
            GameRunning = false;
            NewHighscoreWasSest = false;

            // Initialize TMP's on main screen at launch
            mainScreenUI = GameObject.Find("UIToggler").GetComponent<MainScreenUIToggles>();
            mainScreenUI.UpdateStatsPanel();
        } 
        else
        {
            Destroy(gameObject);
        }
    }
}
