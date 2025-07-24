public class MisselePool : Pool<Missele>
{
    protected override void Spawn(Missele mislele)
    {
        base.Spawn(mislele);
        mislele.Releasing += OnReleasing;
    }

    protected override void OnReleasing(Missele missele)
    {
        base.OnReleasing(missele);
        missele.Releasing -= OnReleasing;
    }
}
