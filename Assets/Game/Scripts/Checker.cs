using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private int _maxUnitsCount = 10;

    public event Action<Collider2D> Founded;
    
    private Collider2D[] _hitColliders;

    private void Start()
    {
        _hitColliders = new Collider2D[_maxUnitsCount];
    }

    private void FixedUpdate()
    {
        var count = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _hitColliders, _layerMask);

        for (int i = 0; i < count; i++)
        {
            Founded?.Invoke(_hitColliders[i]);
        }
    }
}