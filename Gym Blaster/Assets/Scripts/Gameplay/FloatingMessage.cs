using System.Collections;
using TMPro;
using UnityEngine;

public sealed class FloatingMessage : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private float life = 1.3f;
    [SerializeField] private float riseSpeed = 1f;

    [SerializeField] private string sortingLayerName = "UIWorld";
    [SerializeField] private int sortingOrder = 2000;
    
    private void Awake()
    {
        // TMP world text uses a MeshRenderer internally
        var r = text != null ? text.GetComponent<Renderer>() : null;
        if (r != null)
        {
            r.sortingLayerName = sortingLayerName;
            r.sortingOrder = sortingOrder;
        }
    }
    
    public void Show(string message)
    {
        text.text = message;
        StartCoroutine(LifeRoutine());
    }

    private IEnumerator LifeRoutine()
    {
        float t = 0f;
        while (t < life)
        {
            t += Time.deltaTime;
            transform.position += Vector3.up * (riseSpeed * Time.deltaTime);
            yield return null;
        }
        Destroy(gameObject);
    }
}