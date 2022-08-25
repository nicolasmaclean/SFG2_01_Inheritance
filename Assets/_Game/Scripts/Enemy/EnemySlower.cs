public class EnemySlower : Enemy
{
    protected override void HitPlayer(Player player)
    {
        TankController tank = player.GetComponent<TankController>();
        tank.MaxSpeed *= _damage;
    }
}