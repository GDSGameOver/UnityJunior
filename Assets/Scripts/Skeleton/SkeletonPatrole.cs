using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class SkeletonPatrole : MonoBehaviour
{
    [SerializeField] private Transform _patrolePath;
    [SerializeField] private float _speed;

    private Transform[] _patrolePoints;
    private int _currentPatrolePoint;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Start()
    {
        _spriteRenderer.flipX=true;
        _patrolePoints = new Transform [_patrolePath.childCount];

        for (int i = 0; i < _patrolePath.childCount; i++)
        {
            _patrolePoints[i] = _patrolePath.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Transform target = _patrolePoints[_currentPatrolePoint];
        transform.position =  Vector3.MoveTowards(transform.position, target.position, _speed*Time.deltaTime);

        if (transform.position==target.position)
        {
            _currentPatrolePoint++;

            _spriteRenderer.flipX = !_spriteRenderer.flipX;

            if (_currentPatrolePoint>=_patrolePoints.Length)
            {
                _currentPatrolePoint = 0;
            }
        }
    }
}
