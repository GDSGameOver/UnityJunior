using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    [SerializeField] private Transform _alarmPoint;
    [SerializeField] private float _speed;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _alarmPoint.position, _speed * Time.deltaTime);
    }
}
