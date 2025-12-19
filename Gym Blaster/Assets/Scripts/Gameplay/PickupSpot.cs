using UnityEngine;

public class PickupSpot : MonoBehaviour
{
    [SerializeField] private GameObject pickupPrefab;

    public GameObject PickupPrefab => pickupPrefab;
}
