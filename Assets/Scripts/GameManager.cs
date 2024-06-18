using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TMP_Text Score;
    public TMP_Text Money;
    private int totalScore = 0;
    private int totalMoney = 0;
    private int moneyIncrease = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        return;
    }

    public void AddScore(int score)
    {
        totalScore += score;
        Score.text = totalScore.ToString();
        
        if (totalScore % 10 == 0)
        {
            AddMoney(moneyIncrease);
        }
    }

    public void AddMoney(int money)
    {
        totalMoney += money;
        Money.text = totalMoney.ToString();
    }

    public int CheckTotalMoney()
    {
        return totalMoney;
    }

    public void SubtractMoney(int money)
    {
        totalMoney -= money;
        Money.text = totalMoney.ToString();
    }
}
