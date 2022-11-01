public class LightingBall : Collectable
{
    protected override void ApplyEffect()
    {
        foreach(var ball in BallsManager.Instance.Balls)
        {
            ball.StartLightingBall();
        }
    }
}
