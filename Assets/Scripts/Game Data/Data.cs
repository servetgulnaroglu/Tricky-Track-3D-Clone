using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Data class will be used to form data if necessary
 *  (Not used in the project yet)
 */
[System.Serializable]
public class Data
{
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
