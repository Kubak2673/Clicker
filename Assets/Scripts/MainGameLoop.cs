using TMPro;
using UnityEngine;

public class MainGameLoop : MonoBehaviour
{
    private Buildings buildings;
    public static int clicks = 0;
    float timerToSave = 0f;
    public float timeSpend = 0f;
    public TextMeshProUGUI saveText;
    public float saveInterval = 30f;
    public static int clickMultiplayer = 1;
    [SerializeField] TextMeshProUGUI clickText;

    [System.Obsolete]
    void Start()
    {
        buildings = FindObjectOfType<Buildings>();
        if (SaveSystem.LoadPlayer() != null)
        {
            Load();
        }
        else
        {
            Save();
        }
    }

    public void Load()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        clicks = data.clicks;
        timeSpend = data.timeSpend;
        buildings.building1Count = data.building1Count;
        buildings.building2Count = data.building2Count;
        buildings.building3Count = data.building3Count;
        Buildings.buildingsIncome = data.buildingsIncome;
        GoldenButtons.goldenButtons = data.goldenButtons;
        GoldenButtons.clickMultiplayer1 = data.clickMultiplayer1;
        GoldenButtons.clickMultiplayer2 = data.clickMultiplayer2;
        GoldenButtons.timeLeft = data.timeLeft;
        clickMultiplayer = data.clickMultiplayer;
    }
    void Update()
    {
        timeSpend += Time.deltaTime;
        timerToSave += Time.deltaTime;
        if (timerToSave >= saveInterval)
        {
            Save();
        }
        clickText.text = "Clicks: " + clicks;
    }
    public void Click()
    {
        clicks += clickMultiplayer;
    }

    public void Save()
    {
        saveText.text = "Saved!";
        SaveSystem.SavePlayer(this, buildings);
        timerToSave = 0f;
        Invoke(nameof(ClearSaveText), 2f);
    }
    public void ClearSaveText()
    {
        saveText.text = "";
    }

}
