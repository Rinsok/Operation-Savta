using System;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : PlayableCharacter
{
    [SerializeField] Controller2D character;
    [SerializeField] private float horizontal;
    [SerializeField] private bool jump = false;
    [SerializeField] private float vertical;
    [SerializeField] private Animator ortalAnim;

    void Update()
    {
        Debug.Log(speed + " " + maxHP + " " + currentHP);
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal == 0)
        {
            ortalAnim.SetBool("isRun", false);
        }
        else
        {
            ortalAnim.SetBool("isRun", true);
        }
        if (character.m_Grounded)
        {
            ortalAnim.SetBool("isJump", false);
        }
        else 
        {
            ortalAnim.SetBool("isJump", true);
        }
        if (Input.GetButtonDown("Jump"))
        {
            ortalAnim.SetBool("isJump", true);
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
            Debug.Log("kick");
        }

    }

    public override void ApplyDamage(IDamagable damagable)
    {
        TakeDamage(1);
    }

}