using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuToogler : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject controlMenu;
    
    public void OpenControlMenu()
    {
        mainMenu.SetActive(false);
        controlMenu.SetActive(true);
    }

    public void OpenMainMenu()
    {
        controlMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
