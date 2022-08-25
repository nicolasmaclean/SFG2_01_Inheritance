public class PowerupInvincibility : PowerupBase
{
    protected override void PowerUp()
    {
        Player.Instance.Invincible = true;
    }

    protected override void PowerDown()
    {
        Player.Instance.Invincible = false;
    }
}