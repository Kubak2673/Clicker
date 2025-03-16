using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int clicks;
    public float timeSpend;
    public int building1Count;
    public int building2Count;
    public int building3Count;
    public float timeLeft;
    public int buildingsIncome;
    public int goldenButtons;
    public int clickMultiplayer;
    public bool clickMultiplayer1;
    public bool clickMultiplayer2;

    public PlayerData (MainGameLoop mainGameLoop, Buildings buildings)
    {
        clicks = MainGameLoop.clicks;
        timeSpend = mainGameLoop.timeSpend;
        building1Count = buildings.building1Count;
        building2Count = buildings.building2Count;
        building3Count = buildings.building3Count;
        buildingsIncome = Buildings.buildingsIncome;
        goldenButtons = GoldenButtons.goldenButtons;
        clickMultiplayer1 = GoldenButtons.clickMultiplayer1;
        clickMultiplayer2 = GoldenButtons.clickMultiplayer2;
        clickMultiplayer = MainGameLoop.clickMultiplayer;
        timeLeft = GoldenButtons.timeLeft;
    }

}
