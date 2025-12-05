using UnityEngine;
using TMPro;

public class MainScreenUIToggles : MonoBehaviour
{
    [Header("MainScreen Objects")]
    [SerializeField] private GameObject mainScreenPanel;
    [SerializeField] private TextMeshProUGUI highscoreText;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject closeSettingsButton;

    [Header("Shop Screen Objects")]
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject closeShopButton;

    [Header("Dino placement")]
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 mainDinoPosition;
    [SerializeField] private Vector3 shopDinoPosition;

    [Header("Settings script")]
    [SerializeField] private SettingsUIToggle settingsToggle;
   
   void Awake() {
    player = GameObject.FindWithTag("Player");
    mainDinoPosition = player.transform.position;
    shopDinoPosition = new Vector3(0.5f, 0.25f, 0f);
    settingsToggle = GetComponent<SettingsUIToggle>();
    if (GameData.Instance != null) {
    UpdateStatsPanel();
    }
   }

   public void ShowShopUI()
    {
        mainScreenPanel.SetActive(false);
        shopPanel.SetActive(true);
        settingsToggle.changeSettingsButton();

        player.transform.position = shopDinoPosition;
      /*  if(buttonSettings.activeSelf) {
        settingsPanel.SetActive(true);
        changeSettingsButton();
        Time.timeScale = 0f;
        }
        else if(closeSettingsButton.activeSelf)
        {
        settingsPanel.SetActive(false);
        changeSettingsButton();
        Time.timeScale = 1f;
        }*/
    }

    /*public void GoToMainScreen() {
        mainScreenPanel.SetActive(true);
        shopPanel.SetActive(false);
        MoveDinosaurBack();
        UpdateStatsPanel();
    } */

    public void MoveDinosaurBack() {
        player.transform.position = mainDinoPosition;
    }

    public void UpdateStatsPanel() {
    highscoreText.text = "Highscore: " + (int)GameData.Instance.Highscore; 
    coinsText.text = "Coins: " + GameData.Instance.NewTotalCoins; 
    }
}

