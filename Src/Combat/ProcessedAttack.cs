namespace FlowerRpg.Combat;

public class ProcessedAttack(ICollection<Damage> damageDone, ICollection<Damage> damageDefended)
{
    public ICollection<Damage> DamageDone { get; } = damageDone;
    public ICollection<Damage> DamageDefended { get; } = damageDefended;
}