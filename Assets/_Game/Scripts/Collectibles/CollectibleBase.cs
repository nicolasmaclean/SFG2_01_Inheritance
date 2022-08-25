using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.LowLevel;

[RequireComponent(typeof(Rigidbody))]
public abstract class CollectibleBase : MonoExtended
{
    [SerializeField]
    float _movementSpeed = 1;

    [Header("Events")]
    public UnityEvent OnCollect;

    Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Movement(_rb);
    }

    void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (!player) return;

        Collect(player);
        
        target = player.transform;
        OnCollect?.Invoke();
        
        gameObject.SetActive(false);
    }

    protected virtual void Movement(Rigidbody rb)
    {
        Quaternion turnOffset = Quaternion.Euler(0, _movementSpeed, 0);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
    
    protected abstract void Collect(Player player);
}