using UnityEngine;

public class ExoController : PlayableCharacter
{
    [SerializeField] Controller2D character;
    [SerializeField] private float horizontal;
    [SerializeField] private bool jump = false;
    [SerializeField] private bool wall = false;
    [SerializeField] public Animator exoAnim;


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
        jump = false;
    }

    public override void Movement()
    {
        character.Move(horizontal * speed * Time.fixedDeltaTime, false, jump, wall);
    }

    public override void SpecialAbility()
    {
        wall = !wall;
    }

    public override void ApplyDamage(IDamagable damagable)
    {
        TakeDamage(1);
    }

    public override void DoIdle()
    {
        exoAnim.SetBool("isRun", false);
    }

        void OnTriggerEnter2D(Collider2D col)
    {
       if(col.CompareTag("Wall"))
        {
            SpecialAbility();
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Wall"))
        {
            SpecialAbility();
        }
    }





}
