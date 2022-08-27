using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PowerupBase : MonoExtended
{
    [SerializeField]
    [Min(0)]
    protected float _duration;
    
    [SerializeField]
    [Min(0.01f)]
    protected float _downDuration;

    [SerializeField]
    GameObject _art;

    [Header("Events")]
    public UnityEvent OnCollect;

    protected abstract void PowerUp();
    protected abstract void PowerDown();

    void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (!player) return;
        
        Hide();
        PowerUp();
        
        OnCollect?.Invoke();
        
        StartCoroutine(Coroutines.WaitThen(_duration, PowerDown));
        Destroy(gameObject, _duration + _downDuration);
    }

    void Hide()
    {
        _art.SetActive(false);
    }
}