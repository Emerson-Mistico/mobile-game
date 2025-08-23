using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    [Header("Itens Collectable Setup")]
    public SOInt itemCoins;

    [Header("Player Item Init Setup")]
    public int initialCoins = 0;

    private void Start()
    {
        ResetItens();
    }

    private void ResetItens()
    {
        itemCoins.value = initialCoins;
    }

    public void AddItemCoins(int amountCoins) {

        itemCoins.value += amountCoins;

    }

}
