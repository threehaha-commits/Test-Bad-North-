using UnityEngine;

public class Attacker
{
    private readonly float _damage;
    
    public Attacker(float damage)
    {
        _damage = damage;
    }

    public void AttackTo(Transform target)
    {
        var damageable = target.GetComponents<IDamageable>();
        foreach (var damage in damageable)
        {
            damage.ApplyDamage(_damage);
        }
    }
}