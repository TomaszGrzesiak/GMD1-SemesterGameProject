using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public sealed class GameState : MonoBehaviour
{
    public static GameState I { get; private set; }
    public float TimeLeft = 300f;
    
    [FormerlySerializedAs("_hasCreatine")] public bool hasCreatine = false;
    [FormerlySerializedAs("_hasWhey")] public bool hasWhey = false;

    private void Awake()
    {
        if (I != null && I != this)
        {
            Destroy(gameObject);
            return;
        }

        I = this;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CollectCreatine()
    {
        hasCreatine =  true;
    }

    public void CollectWhey()
    {
        hasWhey =  true;
    }
    
    public bool CheckWinCondition()
    {
        return hasCreatine && hasWhey;
    }
    
    private void Update()
    {
        TimeLeft -= Time.deltaTime;

        if (TimeLeft <= 0f && !CheckWinCondition())
        {
            Restart();
        }
    }

}