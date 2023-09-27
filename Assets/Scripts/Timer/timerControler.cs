using UnityEngine;
using TMPro;

public class timerControler : MonoBehaviour {
    public TextMeshProUGUI timerText;
    private float runDuration;
    private bool isRunning;

    void Start() {
        runDuration = 0f;
        isRunning = true;
    }

    void Update() {
        if (isRunning) {
            runDuration += Time.deltaTime;
            UpdateTimerText();
        }
    }

    void UpdateTimerText() {
        int minutes = Mathf.FloorToInt(runDuration / 60f);
        int seconds = Mathf.FloorToInt(runDuration % 60f);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timerString;
    }

    public void StopTimer() {
        isRunning = false;
    }
}
