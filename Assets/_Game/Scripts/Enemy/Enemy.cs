using System;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoExtended
{
    [SerializeField]
    protected float _damage = 1;

    [Header("Events")]
    public UnityEvent<Player> OnHit;

    Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
    }
    
    protected virtual void Move() { }

    void OnCollisionEnter(Collision other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (!player) return;

        HitPlayer(player);
        OnHit?.Invoke(player);
    }

    protected virtual void HitPlayer(Player player)
    {
        player.Hurt((int) _damage);
    }
}