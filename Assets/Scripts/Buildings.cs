using TMPro;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    private MainGameLoop mainGameLoop;

    [Header("Building 1")]
    int building1Cost = 50;
    public int building1Count = 0;
    [SerializeField] TextMeshProUGUI building1CountText;
    [SerializeField] TextMeshProUGUI building1CostText;

    [Header("Building 2")]
    int building2Cost = 250;
    public int building2Count = 0;
    [SerializeField] TextMeshProUGUI building2CountText;
    [SerializeField] TextMeshProUGUI building2CostText;

    [Header("Building 3")]
    int building3Cost = 1000;
    public int building3Count = 0;
    [SerializeField] TextMeshProUGUI building3CountText;
    [SerializeField] TextMeshProUGUI building3CostText;

    [Header("Buildings settings")]
    public static int buildingsIncome = 0;
    public double priceMultiplayer = 1.15;
    [SerializeField] TextMeshProUGUI clicksPerSecondText;


    [System.Obsolete]
    void Start()
    {
        mainGameLoop = FindObjectOfType<MainGameLoop>();
        InvokeRepeating(nameof(CPS), 1f, 1f);
    }
    void Update()
    {
        // building 1
        building1CountText.text = "Owned: " + building1Count;
        building1CostText.text = "Cost: " + (int)GetBuilding1Cost();
        // building 2
        building2CountText.text = "Owned: " + building2Count;
        building2CostText.text = "Cost: " + (int)GetBuilding2Cost();
        // building 3
        building3CountText.text = "Owned: " + building3Count;
        building3CostText.text = "Cost: " + (int)GetBuilding3Cost();
        // CPS
        clicksPerSecondText.text = "CPS: " + buildingsIncome;
    }
    public double GetBuilding1Cost()
    {
        return building1Cost * Mathf.Pow((float)priceMultiplayer, building1Count);
    }
    public void BuyBuilding1()
    {
        double cost = GetBuilding1Cost();
        if (mainGameLoop.clicks >= cost)
        {
            mainGameLoop.clicks -= (int)cost;
            building1Count++;
            buildingsIncome += 1;
        }
        else
        {
            mainGameLoop.saveText.text = "Not enough clicks!";
            Invoke(nameof(mainGameLoop.ClearSaveText), 2f);
        }
    }
    public double GetBuilding2Cost()
    {
        return building2Cost * Mathf.Pow((float)priceMultiplayer, building2Count);
    }
    public void BuyBuilding2()
    {
        double cost = GetBuilding2Cost();
        if (mainGameLoop.clicks >= cost)
        {
            mainGameLoop.clicks -= (int)cost;
            building2Count++;
            buildingsIncome += 15;
        }
        else
        {
            mainGameLoop.saveText.text = "Not enough clicks!";
            Invoke(nameof(mainGameLoop.ClearSaveText), 2f);
        }
    }
    public double GetBuilding3Cost()
    {
        return building3Cost * Mathf.Pow((float)priceMultiplayer, building3Count);
    }
    public void BuyBuilding3()
    {
        double cost = GetBuilding3Cost();
        if (mainGameLoop.clicks >= cost)
        {
            mainGameLoop.clicks -= (int)cost;
            building3Count++;
            buildingsIncome += 50;
        }
        else
        {
            mainGameLoop.saveText.text = "Not enough clicks!";
            Invoke(nameof(mainGameLoop.ClearSaveText), 2f);
        }
    }
    void CPS()
    {
        mainGameLoop.clicks += buildingsIncome;
    }
}
