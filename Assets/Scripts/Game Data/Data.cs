using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    // Start is called before the first frame update
    private int lastLevel, coins;

    public Data()
    {
        lastLevel = 0;
        coins = 0;
    }

    public void SetLastLevel(int lastLevel)
    {
        this.lastLevel = lastLevel;
    }

    public void SetCoins(int coins){
        this.coins = coins;
    }

    public int GetCoins() {
        return this.coins;
    }

    public int GetLastLevel()
    {
        return this.lastLevel;
    }
}
