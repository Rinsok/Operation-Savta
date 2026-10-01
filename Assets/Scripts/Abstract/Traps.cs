using UnityEngine;

public abstract class Traps : IDamagable
{
    LayerMask whatIDamage;

    void ApplyDamage(IDamagable damagable)
    {
        damagable.TakeDamage(1);
    }

    public void TakeDamage(int howMuch)
    {
        Die();
    }

    public virtual void Die()
    {
        //Implementation of destroying the trap
    }

}