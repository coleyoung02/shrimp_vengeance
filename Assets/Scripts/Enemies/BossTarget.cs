using UnityEngine;

public class BossTarget : Enemy
{
    [SerializeField] private BossAttack boss;
    public override void Damage(float damage = 1)
    {
        boss.NotifyDead();
        base.Damage(damage);
    }
}
