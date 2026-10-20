using System;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : PlayableCharacter
{
    [SerializeField] Controller2D character;
    [SerializeField] private float horizontal;
    [SerializeField] private bool jump = false;
    [SerializeField] private float vertical;
    [SerializeField] public Animator anim;
   
    private GameObject breakableFloor;
    private bool isSpecial = false;
    void Start()
    {
    }


    void Update()
    {
        Debug.Log(speed + " " + maxHP + " " + currentHP);
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal == 0)
        {
            anim.SetBool("isRun", false);
        }
        else
        {
            anim.SetBool("isRun", true);
        }
        if (character.m_Grounded)
        {
            anim.SetBool("isJump", false);
        }
        else 
        {
            anim.SetBool("isJump", true);
        }
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("isJump", true);
            jump = true;
        }
        if(isSpecial)
        {
            SpecialAbility();
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
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("kick");
            breakableFloor.SetActive(false); 
        }

    }

    public override void ApplyDamage(IDamagable damagable)
    {
        TakeDamage(1);
    }
    public override void DoIdle()
    {
        anim.SetBool("isRun", false);
        anim.SetBool("isJump", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Breakable"))
        {
            breakableFloor = collision.gameObject;
            isSpecial = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Breakable"))
        {

            breakableFloor = null;
            isSpecial = false;
        }
    }

}