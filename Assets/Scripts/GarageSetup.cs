using UnityEngine;

public class GarageSetup : MonoBehaviour
{
    public GameObject shelfPrefab;
    public GameObject pickupPrefab;

    void Start()
    {
        Instantiate(shelfPrefab, shelfPrefab.transform.position, Quaternion.identity);
        Instantiate(pickupPrefab, pickupPrefab.transform.position, Quaternion.identity);
    }
}