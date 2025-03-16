using TMPro;
using UnityEditor;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GoldenButtons : MonoBehaviour
{
    public static int goldenButtons = 0;
    public int chance;
    [SerializeField] TextMeshProUGUI rewardText;
    public static float timeLeft = 0;
    public static float timeTillGoldenButton = goldenButtonDelay;
    public static float goldenButtonDelay = 90;
    public GameObject goldenButton;
    public static bool clickMultiplayer1 = false;
    public static bool clickMultiplayer2 = false;

    public void Click()
    {
        goldenButtons++;
        goldenButton.SetActive(false);
        timeTillGoldenButton = goldenButtonDelay;
        chance = Random.Range(0, 11);
        switch (chance)
        {
            case 1:
                timeLeft = 25;
                rewardText.text = "You got x7 clicks for 25 seconds!";
                Invoke(nameof(ResetText), 5f);
                MainGameLoop.clickMultiplayer *= 255;
                clickMultiplayer1 = true;
                break;
            case 2:
                timeLeft = 15;
                rewardText.text = "You got x5 CPS for 15 seconds!";
                Invoke(nameof(ResetText), 5f);
                Buildings.buildingsIncome *= 5;
                clickMultiplayer2 = true;
                break;
            case 3:
                rewardText.text = "You got x5 clicks!";
                Invoke(nameof(ResetText), 5f);
                MainGameLoop.clicks *= 5;
                break;
            default:
                rewardText.text = "You got nothing!";
                Invoke(nameof(ResetText), 5f);
                break;
        }
    }
    void Update()
    {
        timeTillGoldenButton -= Time.deltaTime;
        if (timeTillGoldenButton <= 0)
        {
            goldenButton.SetActive(true);
        }
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                if (clickMultiplayer1)
                {
                    MainGameLoop.clickMultiplayer = 1;
                    clickMultiplayer1 = false;
                }
                if (clickMultiplayer2)
                {
                    Buildings.buildingsIncome /= 5;
                    clickMultiplayer2 = false;
                }
            }
        }
    }

    void ResetText()
    {
        rewardText.text = "";
    }
}
