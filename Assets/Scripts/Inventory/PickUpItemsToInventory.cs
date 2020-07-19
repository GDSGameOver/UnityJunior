using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PickUpItemsToInventory : MonoBehaviour
{
   [SerializeField] private int _numberOfCoins;
   [SerializeField] private int _numberOfRings;

    private void CollectCoins()
    {
        _numberOfCoins += 1;
        Debug.Log("Количество собранных монет - " + _numberOfCoins);
    }

    private void CollectRings()
    {
        _numberOfRings += 1;
        Debug.Log("Количество собранных колец - " + _numberOfRings);
    }

    
}
