using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private HandleInput handleInput;


    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstSelectableOnMainPage);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void SwitchToMainPage()
    {
        handleInput.OnBackKeyDown -= SwitchToMainPage;

        mainPage.SetActive(true);
        settingsPage.SetActive(false);
        EventSystem.current.SetSelectedGameObject(firstSelectableOnMainPage);
    }

    public void SwitchToSettings()
    {
        handleInput.OnBackKeyDown += SwitchToMainPage;

        mainPage.SetActive(false);
        settingsPage.SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstSelectableOnSettings);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }
}
