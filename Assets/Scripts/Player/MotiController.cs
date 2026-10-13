using UnityEngine;

public class MotiController : PlayableCharacter
{
    [SerializeField] Controller2D character;
    [SerializeField] private float horizontal;
    [SerializeField] private bool jump = false;
    [SerializeField] private float vertical;
    [SerializeField] private bool fish;
    [SerializeField] private bool water;
    [SerializeField] private bool enableAbility;
    [SerializeField] private Animator motiAnim;

    public MotiController()
    {
        speed = 10;
        maxHP = 4;
        currentHP = 4;

    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Debug.Log(speed + " " + maxHP + " " + currentHP);
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal == 0)
        {
            motiAnim.SetBool("isRun", false);

        }
        else
        {
            motiAnim.SetBool("isRun", true);

        }
        if (character.m_Grounded)
        {
            motiAnim.SetBool("isJump", false);
        }
        else
        {
            motiAnim.SetBool("isJump", true);
        }
        if (Input.GetButtonDown("Jump"))
        {
            motiAnim.SetBool("isJump", true);
            jump = true;
        }
        SpecialAbility();

    }

    void FixedUpdate()
    {
        Movement();


        jump = false;
    }

    public override void Movement()
    {
        character.Move(horizontal * speed * Time.fixedDeltaTime, false, jump, false);
    }

    public override void SpecialAbility()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Shoot");
            motiAnim.SetBool("isShoot", true);
        }
        else
        {
            motiAnim.SetBool("isShoot", false);

        }

    }

    public override void ApplyDamage(IDamagable damagable)
    {
        TakeDamage(1);
    }

}
