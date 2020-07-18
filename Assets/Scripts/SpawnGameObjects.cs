using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnGameObjects : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Ring _ringPrefab;
    [SerializeField] private GhostGuard _ghostGuardPrefab;
    [SerializeField] private CoinSpawnPoints _coinSpawnPoints;
    [SerializeField] private Inventory _inventoryPrefab;
    [SerializeField] private GhostGuardSpawnPoint _ghostGuardSpawnPoint;
    [SerializeField] private RingSpawnPoint _ringSpawnPoint;

    private List<Transform> _arrayPointsOfSpawnCoin = new List<Transform>();
    private List<Transform> _arrayPointsOfSpawnSkeleton = new List<Transform>();
   
    private void Start()
    {
        Instantiate(_inventoryPrefab, new Vector3(0,0,0), Quaternion.identity);
        Instantiate(_ghostGuardPrefab, _ghostGuardSpawnPoint.GetComponent<Transform>().position, Quaternion.identity);
        Instantiate(_ringPrefab, _ringSpawnPoint.GetComponent<Transform>().position, Quaternion.identity);
        for (int i = 0; i < _coinSpawnPoints.GetComponent<Transform>().childCount; i++)
        {
            _arrayPointsOfSpawnCoin.Add(_coinSpawnPoints.GetComponent<Transform>().GetChild(i));
        }
        foreach (var point in _arrayPointsOfSpawnCoin)
        {
            Instantiate(_coinPrefab, point.localPosition, Quaternion.identity);
        }
    }

    
   
}
