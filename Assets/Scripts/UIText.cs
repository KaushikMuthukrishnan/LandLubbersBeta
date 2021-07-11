using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public int Score { get; set; }

    private void Update()
    {
        scoreText.text = "Coins: " + Score;
        int secs = (int)Time.timeSinceLevelLoad;

        timerText.text = string.Format("{0}:{1,2:00.##}", (300 - secs) / 60, (300 - secs) % 60);

        if (secs >= 300)
            SceneManager.LoadScene(1);

        
    }

}
