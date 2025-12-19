using UnityEngine;

public sealed class Pickup : MonoBehaviour
{
    public enum PickupType
    {
        Creatine,
        Whey
    }

    [SerializeField] private PickupType type;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.CompareTag("Player"))
            return;

        switch (type)
        {
            case PickupType.Creatine:
                GameState.I.CollectCreatine();
                break;

            case PickupType.Whey:
                GameState.I.CollectWhey();
                break;
        }

        Destroy(gameObject);
    }
}