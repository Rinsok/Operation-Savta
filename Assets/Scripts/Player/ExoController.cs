using UnityEngine;

public class ExoController : PlayableCharacter
{
    [SerializeField] Controller2D character;
    [SerializeField] private float horizontal;
    [SerializeField] private bool jump = false;
    [SerializeField] private bool wall;
    [SerializeField] private bool enableAbility;
    [SerializeField] private Animator exoAnim;


    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal == 0)
        {
            exoAnim.SetBool("isRun", false);

        }
        else
        {
            exoAnim.SetBool("isRun", true);

        }
    }

    void FixedUpdate()
    {
        Movement();

        if (enableAbility)
        {
            SpecialAbility();
        }

        jump = false;
    }

    public override void Movement()
    {
        character.Move(horizontal * speed * Time.fixedDeltaTime, false, jump, wall);
    }

    public override void SpecialAbility()
    {

    }

    public override void ApplyDamage(IDamagable damagable)
    {
        TakeDamage(1);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       if(col.CompareTag("Wall"))
        {
            Debug.Log("walls");
            wall = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("no walls");
        wall = false;
    }
}
