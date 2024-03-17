using UnityEngine;

public class WaypointsSystem : MonoBehaviour
{
   [SerializeField] private Transform[] waypoints;

    public static WaypointsSystem instance { get; private set; }

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            return;
        }

        Destroy(this.gameObject);
    }


    public Transform[] GetWaypoints()
    {
        return waypoints;
    }
    
}
