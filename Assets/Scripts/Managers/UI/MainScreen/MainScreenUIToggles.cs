using UnityEngine;

public class MainScreenUIToggles : MonoBehaviour
{
   [SerializeField] private GameObject mainScreenPanel;
   [SerializeField] private GameObject statsPanel;
   [SerializeField] private GameObject shopPanel;

   [SerializeField] private GameObject player;
   [SerializeField] private Vector3 mainDinoPosition;

   
   void Awake() {
    player = GameObject.FindWithTag("Player");
    mainDinoPosition = player.transform.position;
   }

   public void ShowShopUI()
    {

        
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

    public void GoToMainScreen() {
        statsPanel.SetActive(true);
        mainScreenPanel.SetActive(true);
        shopPanel.SetActive(false);
    }
}

