using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainPage;

    [SerializeField]
    private GameObject settingsPage;

    // Used for initialize keyboard input for UI
    [SerializeField]
    private GameObject firstSelectableOnMainPage;

    [SerializeField]
    private GameObject firstSelectableOnSettings;


    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstSelectableOnMainPage);
    }

    public void StartGame()
    {
        
    }

    public void SwitchToMainPage()
    {
        mainPage.SetActive(true);
        settingsPage.SetActive(false);
        EventSystem.current.SetSelectedGameObject(firstSelectableOnMainPage);
    }

    public void SwitchToSettings()
    {
        mainPage.SetActive(false);
        settingsPage.SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstSelectableOnSettings);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }
}
