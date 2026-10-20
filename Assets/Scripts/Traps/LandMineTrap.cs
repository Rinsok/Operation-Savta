using UnityEngine;

public class LandMineTrap : Traps
{
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
                ApplyDamage(damagable);
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
                gameObject.SetActive(false);
            }
        }
    }
}
