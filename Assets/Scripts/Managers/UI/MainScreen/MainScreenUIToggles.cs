using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainScreenUIToggles : MonoBehaviour
{
    [Header("MainScreen Objects")]
    [SerializeField] private GameObject mainScreenPanel;
    [SerializeField] private TextMeshProUGUI highscoreText;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject closeSettingsButton;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject shopStump;
    [SerializeField] private TextMeshProUGUI loadoutCoinsText;

    [Header("Shop Screen Objects")]
    [SerializeField] private GameObject shopButtonsPanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject closeShopButton;

    [Header("Dino placement")]
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 mainDinoPosition;
    [SerializeField] private Vector3 shopDinoPosition;

    [Header("Settings script")]
    [SerializeField] private SettingsUIToggle settingsToggle;
    
    [SerializeField] private WeaponShopUI weaponShopUI;
   
   void Awake() {
    player = GameObject.FindWithTag("Player");
    mainDinoPosition = player.transform.position;
    shopDinoPosition = new Vector3(0f, 0f, 0f);
    settingsToggle = GetComponent<SettingsUIToggle>();
    if (GameData.Instance != null) {
    UpdateStatsPanel();
    }
   }

   public void StartGame() {
     SceneManager.LoadScene("Play Scene");
   }

   public void ShowShopUI() {
        mainScreenPanel.SetActive(false);
        shopButtonsPanel.SetActive(true);
        settingsToggle.changeSettingsButton();
        player.transform.position = shopDinoPosition;
        shopStump.SetActive(true);
        UpdateCoinsUI();
        weaponShopUI.RefreshUpgradeInfo();
   }

   public void ShowLoadoutShopUI()
    {
        mainScreenPanel.SetActive(false);
        shopButtonsPanel.SetActive(false);
        shopPanel.SetActive(true);
        UpdateCoinsUI();
        //settingsToggle.changeSettingsButton();
    }

    /*public void GoToMainScreen() {
        mainScreenPanel.SetActive(true);
        shopPanel.SetActive(false);
        MoveDinosaurBack();
        UpdateStatsPanel();
    } */

    private void UpdateCoinsUI()
    {
        if (coinsText != null && loadoutCoinsText != null && GameData.Instance != null)
        {
            coinsText.text = "Coins: " + GameData.Instance.NewTotalCoins;
            loadoutCoinsText.text = "Coins: " + GameData.Instance.NewTotalCoins;
        }
    }

    public void MoveDinosaurBack() {
        player.transform.position = mainDinoPosition;
    }

    public void UpdateStatsPanel() {
    highscoreText.text = "Highscore: " + (int)GameData.Instance.Highscore; 
    coinsText.text = "Coins: " + GameData.Instance.NewTotalCoins; 
    }
}

