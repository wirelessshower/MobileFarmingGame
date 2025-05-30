using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CashManager : MonoBehaviour
{
    public static CashManager instance;

    [Header(" Settings ")]
    private int coins;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        LoadData();
        UpdateCoinsContainers();

    }

    public void UseCoins(int amount)
    {
        AddCoins(-amount);
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateCoinsContainers();
        Debug.Log($"We now have {coins} coins");

        SaveData();
    }

    public int GetCoins()
    {
        return coins;
    }


    private void SaveData()
    {
        PlayerPrefs.SetInt("Coins", coins);
    }

    [NaughtyAttributes.Button]
    private void Add500Coins()
    {
        AddCoins(500);
    }


    private void UpdateCoinsContainers()
    {
        GameObject[] coinContainers = GameObject.FindGameObjectsWithTag("CoinAmount");

        foreach (GameObject coinContainer in coinContainers)
            coinContainer.GetComponent<TextMeshProUGUI>().text = coins.ToString();
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey("Coins"))
            coins = PlayerPrefs.GetInt("Coins");
    }
}
