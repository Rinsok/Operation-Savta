using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    [SerializeField] MotiController moti;
    private float side;
    private Rigidbody2D bullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
        moti = FindAnyObjectByType<MotiController>();
        side = Mathf.Sign(moti.gameObject.transform.localScale.x);
    }

    // Update is called once per frame
    void Update()
    {
       bullet.linearVelocity = new Vector2(side * 10, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);

    }
}
