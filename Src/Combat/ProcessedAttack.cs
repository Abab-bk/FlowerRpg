namespace FlowerRpg.Combat;

public struct ProcessedAttack(
        ICollection<Damage> damageDone, ICollection<Damage> damageDefended
        )
{
    public ICollection<Damage> DamageDone { get; } = damageDone;
    public ICollection<Damage> DamageDefended { get; } = damageDefended;
}