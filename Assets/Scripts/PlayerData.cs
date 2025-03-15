using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int clicks;
    public float timeSpend;
    public int building1Count;
    public int building2Count;
    public int building3Count;
    public int buildingsIncome;

    public PlayerData (MainGameLoop mainGameLoop, Buildings buildings)
    {
        clicks = mainGameLoop.clicks;
        timeSpend = mainGameLoop.timeSpend;
        building1Count = buildings.building1Count;
        building2Count = buildings.building2Count;
        building3Count = buildings.building3Count;
        buildingsIncome = buildings.buildingsIncome;
    }

}
