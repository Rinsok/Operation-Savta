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

    public MotiController()
    {
        speed = 10;
        maxHP = 4;
        currentHP = 4;

    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (water && fish)
        {
            vertical = Input.GetAxis("Vertical");
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
        character.Move(horizontal * speed * Time.fixedDeltaTime, false, jump);
    }

    public override void SpecialAbility()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Shoot");
        }

    }

    public override void ApplyDamage(IDamagable damagable)
    {
        TakeDamage(1);
    }

}
