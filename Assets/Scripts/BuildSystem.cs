using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    public static BuildSystem instance {get; private set;}


    private GameObject towerToBuid;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }

        Destroy(this.gameObject);
    }

    public GameObject GetTowerToBuild()
    {
        return towerToBuid;
    }

    public void SetTowerToBuild(GameObject newTower)
    {
        towerToBuid=newTower;
    }
}
