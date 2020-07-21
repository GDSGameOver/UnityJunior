using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class CoinCollect : MonoBehaviour
{
    [SerializeField] private UnityEvent _collectReached;
    private Animator _animator;
    private AudioSource _coinAudioSource;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _coinAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player platform))
        {
            _animator.SetTrigger("Collect");
            _collectReached?.Invoke();
           
        }
    }

    public void PlaySoundWhenCoinCollect()
    {
        _coinAudioSource.Play();
    }

    private void DestroyCoin()
    {
        Destroy(gameObject);
    }

}
