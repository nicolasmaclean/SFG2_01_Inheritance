using UnityEngine;

public class CollectibleSpeed : CollectibleBase
{
    [SerializeField]
    float _speedDelta = 5;
    
    protected override void Collect(Player player)
    {
        TankController tank = player.GetComponent<TankController>();
        if (!tank) return;

        tank.MaxSpeed += _speedDelta;
    }
}