using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score;
    [SerializeField] TMP_Text playerscore;

    public void AddScore(int value)
    {
        score += value;
        playerscore.text = $"Score: {score.ToString()}";
    }
}
