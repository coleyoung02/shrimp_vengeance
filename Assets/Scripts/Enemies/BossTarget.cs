using UnityEngine;

public class BossTarget : Enemy
{
    [SerializeField] private BossAttack boss;
    private string eventPath = "event:/metalpipe";
    public override void Damage(float damage = 1)
    {
        FMODUnity.RuntimeManager.PlayOneShot(eventPath);
        boss.NotifyDead();
        base.Damage(damage);
    }
}
