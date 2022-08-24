using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupBase : MonoBehaviour
{
    [SerializeField]
    [Min(0)]
    protected float _powerupDuration;

    protected abstract void Powerup();
}