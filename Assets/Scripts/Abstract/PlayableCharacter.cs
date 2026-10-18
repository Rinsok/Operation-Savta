using UnityEngine;

public abstract class PlayableCharacter : MonoBehaviour, IDamagable
{
    protected int speed = 15;
    protected int maxHP = 3;
    protected int currentHP = 3;
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
        Debug.Log("You dead");
    }
    public int GetCurrentHP()
    {
        return currentHP;
    }
    public int GetMaxHP()
    {
        return maxHP;
    }

    public void SetHP(int newHP)
    {
        maxHP = newHP;
    }
    public void updateHP(int newCurrentHP)
    {
        currentHP = newCurrentHP;
    }


}