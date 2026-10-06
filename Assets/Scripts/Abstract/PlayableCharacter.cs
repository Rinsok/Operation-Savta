using UnityEngine;

public abstract class PlayableCharacter : MonoBehaviour, IDamagable
{
    protected int speed;
    protected int maxHP;
    protected int currentHP;
    public abstract void Movement();

    public abstract void SpecialAbility();

    public abstract void ApplyDamage(IDamagable damagable);

    public void TakeDamage(int howMuch)
    {
        currentHP -= howMuch;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //
        Debug.Log("You dead");
    }
}