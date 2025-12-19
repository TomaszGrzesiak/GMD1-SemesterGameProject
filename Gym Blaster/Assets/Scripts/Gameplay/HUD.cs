using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class HUD : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    public Image creatineIndicator;
    public Image wheyIndicator;

    [SerializeField] private Sprite offSprite;
    [SerializeField] private Sprite onSprite;
    private void Update()
    {
        if (GameState.I == null) return;

        UpdateTimer();
        UpdateIndicators();
    }

    private void UpdateTimer()
    {
        timerText.text = FormatTime(GameState.I.TimeLeft);
    }

    private void UpdateIndicators()
    {
        creatineIndicator.sprite =
            GameState.I.hasCreatine ? onSprite : offSprite;

        wheyIndicator.sprite =
            GameState.I.hasWhey ? onSprite : offSprite;
    }

    private static string FormatTime(float seconds)
    {
        if (seconds < 0f) seconds = 0f;

        int total = Mathf.CeilToInt(seconds);
        int minutes = total / 60;
        int secs = total % 60;

        return $"{minutes:00}:{secs:00}";
    }
}