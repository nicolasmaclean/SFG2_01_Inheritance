using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupBase : MonoBehaviour
{
    [SerializeField]
    [Min(0)]
    protected float _duration;
    
    [SerializeField]
    [Min(0.01f)]
    protected float _downDuration;

    [SerializeField]
    GameObject _art;

    protected abstract void PowerUp();
    protected abstract void PowerDown();

    void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (!player) return;
        
        Hide();
        PowerUp();
        
        StartCoroutine(Coroutines.WaitThen(_duration, PowerDown));
        Destroy(gameObject, _duration + _downDuration);
    }

    void Hide()
    {
        _art.SetActive(false);
    }
}