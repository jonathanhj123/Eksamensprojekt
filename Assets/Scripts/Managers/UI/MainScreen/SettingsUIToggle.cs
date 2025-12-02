using UnityEngine;
using UnityEngine.InputSystem;


public class SettingsUIToggle : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject closeSettingsButton;
    [SerializeField] private InputAction escapeAction;

    [Header("If in Main Screen")]
    [SerializeField] private GameObject mainScreenPanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private MainScreenUIToggles mainScreenUI;

  void Awake()
    {
        escapeAction = InputSystem.actions.FindAction("Escape");
    if (escapeAction != null)
    {
        escapeAction.Enable();
        escapeAction.performed += ctx => ShowAndHideSettings();
    }
    if (escapeAction != null) {
       mainScreenUI = GetComponent<MainScreenUIToggles>();
    }
    }

 public void ShowAndHideSettings()
    {
        if(settingsButton.activeSelf) {
        settingsPanel.SetActive(true);
        changeSettingsButton();
        Time.timeScale = 0f;
        if(mainScreenPanel != null && shopPanel != null) {
            mainScreenPanel.SetActive(false);
            shopPanel.SetActive(false);
        }
        }
        else if(closeSettingsButton.activeSelf)
        {
        settingsPanel.SetActive(false);
        changeSettingsButton();
        Time.timeScale = 1f;
        if(mainScreenPanel != null && shopPanel != null) {
            mainScreenPanel.SetActive(true);
            shopPanel.SetActive(false);
            mainScreenUI.MoveDinosaurBack();
            mainScreenUI.UpdateStatsPanel();
        }
        }
    }

    public void changeSettingsButton() {
        if(settingsButton.activeSelf) {
            settingsButton.SetActive(false);
            closeSettingsButton.SetActive(true);
        } 
        else if(closeSettingsButton.activeSelf)
        {
            settingsButton.SetActive(true);
            closeSettingsButton.SetActive(false);
        }
    }
}
