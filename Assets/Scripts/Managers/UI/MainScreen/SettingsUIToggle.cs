using UnityEngine;
using UnityEngine.InputSystem;


public class SettingsUIToggle : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject closeSettingsButton;
    [SerializeField] private InputAction escapeAction;

  void Awake()
    {
        escapeAction = InputSystem.actions.FindAction("Escape");
    if (escapeAction != null)
    {
        escapeAction.Enable();
        escapeAction.performed += ctx => ShowAndHideSettings();
    }
    }

 public void ShowAndHideSettings()
    {
        if(settingsButton.activeSelf) {
        settingsPanel.SetActive(true);
        changeSettingsButton();
        Time.timeScale = 0f;
        }
        else if(closeSettingsButton.activeSelf)
        {
        settingsPanel.SetActive(false);
        changeSettingsButton();
        Time.timeScale = 1f;
        }
    }

    private void changeSettingsButton() {
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
