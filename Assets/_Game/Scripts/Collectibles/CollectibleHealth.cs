using UnityEngine;

public class CollectibleHealth : CollectibleBase
{
    [SerializeField]
    int _healAmt = 1;
    
    protected override void Collect(Player player)
    {
        player.Heal(_healAmt);
    }
}