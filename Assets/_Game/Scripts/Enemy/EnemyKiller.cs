public class EnemyKiller : Enemy
{
    protected override void HitPlayer(Player player)
    {
        player.Kill();
    }
}