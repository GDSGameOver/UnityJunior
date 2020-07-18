using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]

public class RingCollect : MonoBehaviour
{
    [SerializeField] UnityEvent _spawnGhostsReached;
    [SerializeField] UnityEvent _collectRingReached;

    private AudioSource _ringAudioSource;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _ringAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player platform))
        {
            _animator.SetTrigger("Collect");
            _collectRingReached?.Invoke();
            SpawnGhosts();
        }
    }

    public void PlaySoundWhenCoinCollect()
    {
        _ringAudioSource.Play();
    }

    private void DestroyRing()
    {
        Destroy(gameObject);
    }

    private void SpawnGhosts()
    {
        _spawnGhostsReached?.Invoke();
        _spawnGhostsReached?.Invoke();
        _spawnGhostsReached?.Invoke();
        _spawnGhostsReached?.Invoke();
        _spawnGhostsReached?.Invoke();
        _spawnGhostsReached?.Invoke();
        _spawnGhostsReached?.Invoke();
        _spawnGhostsReached?.Invoke();
    }
}
