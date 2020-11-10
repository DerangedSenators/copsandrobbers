using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{

    public static long moneyCount;
    
    // Start is called before the first frame update
    void Start()
    {
        moneyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CollectMoney()
    {
        moneyCount += 100;
    }

    public long getMoneyCount() {

        return moneyCount;
    }


}
