using UnityEngine;

public class SpikeTrap : Traps
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
                    side = Vector2.left;
                }
                else
                {
                    side = Vector2.right;
                }
                ApplyDamage(damagable);
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10f + side * 10f, ForceMode2D.Impulse);
            }
        }
    }
}
