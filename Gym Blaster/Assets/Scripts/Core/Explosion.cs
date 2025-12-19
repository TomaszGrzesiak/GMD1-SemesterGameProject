using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float life = 0.25f;

    private void Start() => Destroy(gameObject, life);
    }