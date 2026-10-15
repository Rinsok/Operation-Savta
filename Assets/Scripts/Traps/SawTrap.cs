using UnityEngine;

public class SawTrap : Traps
{
    [SerializeField] SwitchPlayer character;
    private Vector2 side;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(0, 0, 1);
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            IDamagable damagable = col.GetComponent<IDamagable>();
            if (damagable != null)
            {
                if (character.GetCurrentCharacter().transform.localScale.x < 0)
                {
                    side = Vector2.right;
                }
                else
                {
                    side = Vector2.left;
                }
                ApplyDamage(damagable);
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(side * 50f, ForceMode2D.Impulse);
            }
        }
    }
}

