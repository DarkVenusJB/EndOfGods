using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [Space]
    [Space]
    [SerializeField] private GameObject cannonTower;
    [Space]
    [SerializeField] private int cannonPrice;
    [Header("Buttons")]
    [SerializeField] private Button cannonButton;


    private void Update()
    {
        if (gameData.coins < cannonPrice)
            cannonButton.interactable = false;
        else
            cannonButton.interactable=true;
    }

    public void BuyCannonTower()
    {
        gameData.coins-= cannonPrice;
        BuildSystem.instance.SetTowerToBuild(cannonTower);
        GameUI.instance.SetInformationPanel();
    }
}
