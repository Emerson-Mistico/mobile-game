using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    [Header("Itens Collectable Setup")]
    public SOInt itemCoins;
    private void Start()
    {
        itemCoins.value = PlayerPrefs.GetInt("Totalcoins");
    }

    public void AddItemCoins(int amountCoins) {

        itemCoins.value += amountCoins;
        PlayerPrefs.SetInt("Totalcoins", itemCoins.value);
    }

}
