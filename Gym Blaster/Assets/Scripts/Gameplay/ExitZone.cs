using System.Collections;
using UnityEngine;

public sealed class ExitZone : MonoBehaviour
{
    [SerializeField] private FloatingMessage floatingMessagePrefab;
    [SerializeField] private Transform messageSpawnPoint;
    

    private bool lockedSpamGuard;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (GameState.I.CheckWinCondition())
        {
            
           ShowMessage("Congrats! You won!", 1.6f);
           StartCoroutine(RestartAfterDelay(1.6f));
           return;
        }

        ShowLocked();
    }

    private void ShowLocked()
    {
        if (lockedSpamGuard) return;
        lockedSpamGuard = true;

        Vector3 pos = messageSpawnPoint != null ? messageSpawnPoint.position : transform.position;

        var msg = Instantiate(floatingMessagePrefab, pos, Quaternion.identity);
        msg.Show("LOCKED");

        Invoke(nameof(ResetGuard), 1.3f);
    }

    private void ResetGuard() => lockedSpamGuard = false;
    
    private void RestartNow() => GameState.I.Restart();

    private void ShowMessage(string text, float guardTime)
    {
        if (lockedSpamGuard) return;
        lockedSpamGuard = true;

        Vector3 pos = messageSpawnPoint != null ? messageSpawnPoint.position : transform.position;

        var msg = Instantiate(floatingMessagePrefab, pos, Quaternion.identity);
        msg.Show(text);

        Invoke(nameof(ResetGuard), guardTime);
    }

    private IEnumerator RestartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameState.I.Restart();
    }
}