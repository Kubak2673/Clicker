using TMPro;
using UnityEditor;
using UnityEngine;

public class GoldenButtons : MonoBehaviour
{
    public static int goldenButtons = 0;
    public int chance;
    public int zapas;
    [SerializeField] TextMeshProUGUI rewardText;
    public static float timeLeft = 0;

    public void Click()
    {
        goldenButtons++;
        chance = Random.Range(0, 100);
        switch (chance)
        {
            case 1:
                timeLeft = 25;
                rewardText.text = "You got x7 clicks for 25 seconds!";
                Invoke(nameof(ResetText), 5f);
                MainGameLoop.clickMultiplayer *= 7;
                break;
            case 2:
                timeLeft = 15;
                rewardText.text = "You got x5 CPS for 15 seconds!";
                Invoke(nameof(ResetText), 5f);
                zapas = Buildings.buildingsIncome;
                Buildings.buildingsIncome *= 5;
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            default:
                break;
        }
    }
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                MainGameLoop.clickMultiplayer = 1;
                Buildings.buildingsIncome = zapas;
            }
        }
    }
    void ResetText()
    {
        rewardText.text = "";
    }
}
