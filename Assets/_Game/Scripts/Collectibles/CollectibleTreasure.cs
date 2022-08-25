using UnityEngine;

public class CollectibleTreasure : CollectibleBase
{
    [SerializeField]
    [Min(0)]
    int _scoreAdder = 10;
    
    protected override void Collect(Player player)
    {
        Score.Update(_scoreAdder);
    }
}