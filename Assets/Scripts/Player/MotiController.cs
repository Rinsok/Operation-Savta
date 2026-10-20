using UnityEngine;

public class MotiController : PlayableCharacter
{
    [SerializeField] Controller2D character;
    [SerializeField] private float horizontal;
    [SerializeField] private bool jump = false;
    [SerializeField] private float vertical;
    [SerializeField] private GameObject bullet;
    [SerializeField] public Animator motiAnim;
    [SerializeField] public Transform gun;

    void Update()
    {
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
        if (Input.GetKeyDown(KeyCode.K))
        {
            SpecialAbility();
        }
        else
        {
            motiAnim.SetBool("isShoot", false);
        }
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
        motiAnim.SetBool("isShoot", true);

        Instantiate(bullet, gun.position, Quaternion.identity);
    }

    public override void ApplyDamage(IDamagable damagable)
    {
        TakeDamage(1);
    }
    public override void DoIdle()
    {
        motiAnim.SetBool("isRun", false);
        motiAnim.SetBool("isJump", false);
        motiAnim.SetBool("isShoot", false);
    }
}
