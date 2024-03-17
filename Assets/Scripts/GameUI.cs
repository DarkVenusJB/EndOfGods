using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI instance { get; private set; }

    [SerializeField] private int startCoinsValue;
    [SerializeField] Image hpPanel;
    [SerializeField] TMP_Text coinsTXT;
    [SerializeField] TMP_Text wavesTXT;
    [SerializeField] GameData gameData;
    [SerializeField] GameObject finishMenu;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GateHealthSystem healthSystem;   

    private float gateMaxHp = 100;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }

        Destroy(this.gameObject);

    }

    private void Start()
    {
        gameData.coins = startCoinsValue;
        SetInformationPanel();
    }

    public void SetInformationPanel()
    {
        coinsTXT.text = string.Format("Coins: {0}", gameData.coins);
        wavesTXT.text = string.Format("Waves: {0}/5", gameData.waveNumber);
        hpPanel.fillAmount = healthSystem.MaxHP / gateMaxHp;
    }

    public void FinishLevel()
    {
        Time.timeScale = 0;
        finishMenu.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);
    }


}
