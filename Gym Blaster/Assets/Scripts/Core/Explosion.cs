using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float life = 0.55f;

    private void Start() => Destroy(gameObject, life);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player should be destroyed: " + other.name);
            Destroy(other.gameObject);
        }
    }
}