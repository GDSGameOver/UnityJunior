
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class GhostGuardAlarm : MonoBehaviour
{
    [SerializeField] private GhostGuardSpawnPoint _ghostGuardSpawnPoint;
    [SerializeField] private Ghost _ghostPrefab;
    private Vector3 _ghostSpawnPoint;
    private bool _isVolumeIncrease;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player platform))
        {
            if (_audioSource.volume == 0)
            {
                _audioSource.Play();
            }
            _isVolumeIncrease = true;
            StartCoroutine(IncreaseVolume());
            StartCoroutine(SpawnGhostAfter2Seconds());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player platform))
        {
            _isVolumeIncrease = false;
            StartCoroutine(ReduceVolume());
        }
    }
    private IEnumerator ReduceVolume()
    {
        while (_isVolumeIncrease == false)
        {
            _audioSource.volume -=  0.1f * Time.deltaTime;
            yield return null;
        }
    }
    private IEnumerator IncreaseVolume()
    {
        while (_isVolumeIncrease == true) 
        {
            _audioSource.volume +=  0.1f * Time.deltaTime;
            yield return null;
        }
    }


    private IEnumerator SpawnGhostAfter2Seconds()
    {
        yield return new WaitForSeconds(2);
        _ghostSpawnPoint = new Vector3(Random.Range(_ghostGuardSpawnPoint.GetComponent<Transform>().position.x, _ghostGuardSpawnPoint.GetComponent<Transform>().position.x - 100), Random.Range(_ghostGuardSpawnPoint.GetComponent<Transform>().position.y, _ghostGuardSpawnPoint.GetComponent<Transform>().position.y - 100), 0);
        Instantiate(_ghostPrefab, _ghostSpawnPoint, Quaternion.identity);
        StartCoroutine(SpawnGhostAfter2Seconds());
    }
}
