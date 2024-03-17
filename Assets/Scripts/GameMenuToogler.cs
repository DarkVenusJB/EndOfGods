using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuToogler : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject pauseButton;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        shopPanel.SetActive(false);
        pauseButton.SetActive(false);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        shopPanel.SetActive(true);
        pauseButton.SetActive(true);
    }

    public void Restart()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(index);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
   
}
