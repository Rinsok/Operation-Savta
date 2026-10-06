using System;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : PlayableCharacter
{
    [SerializeField] Controller2D character;
    [SerializeField] private float horizontal;
    [SerializeField] private bool jump = false;
    [SerializeField] private float vertical;
    [SerializeField] private bool fish;
    [SerializeField] private bool water;
    [SerializeField] private bool enableAbility;
    [SerializeField] private bool WallWalk = false;

    public CharacterController()
    {
        speed = 10;
        maxHP = 4;
        currentHP = 4;

    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        
        if (WallWalk)
        {
            transform.parent.rotation = Quaternion.Euler(transform.parent.rotation.x, transform.parent.rotation.y, 90);
        }
        else
        {
            transform.parent.rotation = Quaternion.Euler(transform.parent.rotation.x, transform.parent.rotation.y, 0);
        }
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        
        if(water && fish)
        {
            vertical = Input.GetAxis("Vertical");
        }
        if (enableAbility)
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
        character.Move(horizontal * speed * Time.fixedDeltaTime, false, jump);
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Destroy"))
        {
            Debug.Log("Enabled");

            enableAbility = true;
        }
        else if (col.CompareTag("Wall"))
        {
            Debug.Log("Enabled");

            WallWalk = !WallWalk;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Destroy"))
        {
            Debug.Log("Disable");

            enableAbility = false;
        }
    }
}