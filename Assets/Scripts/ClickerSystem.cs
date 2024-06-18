using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerSystem : MonoBehaviour
{
    private int score = 1;
    private int AutoClickCost = 10;
    private int UpgradeClickPowerCost = 5;

    public Button AutoClickButton;
    public Button UpgradeClickPowerButton;

    public float clickInterval = 0.5f;
    private Coroutine autoClickCorutine;

    private void Start()
    {
        ButtonInteractable();
    }

    public void OnMouseDown()
    {
        GameManager.instance.AddScore(score);
        ButtonInteractable();
    }

    public void UpgradeClickPower()
    {
        score += 1;
        GameManager.instance.SubtractMoney(UpgradeClickPowerCost);
    }

    public void StartAutoClick()
    {
        if (autoClickCorutine == null)
        {
            autoClickCorutine = StartCoroutine(AutoClick());
        }
        GameManager.instance.SubtractMoney(AutoClickCost);
    }

    public void ButtonInteractable()
    {
        if (GameManager.instance.CheckTotalMoney() >= 10)
        {
            AutoClickButton.interactable = true;
        }
        else
        {
            AutoClickButton.interactable = false;
        }

        if (GameManager.instance.CheckTotalMoney() >= 5)
        {
            UpgradeClickPowerButton.interactable = true;
        }
        else
        {
            UpgradeClickPowerButton.interactable= false;
        }
    }

    IEnumerator AutoClick()
    {
        while (true)
        {
            yield return new WaitForSeconds(clickInterval);
            GameManager.instance.AddScore(score);
        }
    }
}
