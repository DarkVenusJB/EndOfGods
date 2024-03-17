using UnityEngine;

public class PlateCheck : MonoBehaviour
{
    [SerializeField] private Material availableMat;
    [SerializeField] private Material notAvailableMat;
    [SerializeField] private float buildPositionY;

    private GameObject towerBuild;
    private Renderer currentMaterial;
    private Material defaultMaterial;
    private Vector3 buidPositionOnPlate;
    private int _childcount;

    private void Awake()
    {
        
        buidPositionOnPlate = new Vector3(0, buildPositionY,0);
    }
    private void Start()
    {
        currentMaterial = GetComponent<Renderer>();
        defaultMaterial = currentMaterial.material;
    }

    private void OnMouseDown()
    {
        if (BuildSystem.instance.GetTowerToBuild() == null)
        {

            return;
        }

        else
        {
            if (_childcount > 0)
                return;

            else
                BuildTower();
        }
       
    }

    private void OnMouseEnter()
    {
        if (BuildSystem.instance.GetTowerToBuild() != null)
        {
            _childcount = transform.childCount;

            if (_childcount > 0)
                currentMaterial.material = notAvailableMat;

            else
                currentMaterial.material = availableMat;
        }
           

        else
        {
            return;
        }
    }


    private void OnMouseExit()
    {
        currentMaterial.material = defaultMaterial;
    }

    private void BuildTower()
    {
        GameObject towerPref = BuildSystem.instance.GetTowerToBuild();
        towerBuild = (GameObject)Instantiate(towerPref, transform.position, transform.rotation);

        towerBuild.transform.parent = this.transform;
        towerBuild.transform.localPosition = buidPositionOnPlate;
        BuildSystem.instance.SetTowerToBuild(null);

    }
}
