using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//for playermovement
public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    public float min_Y, max_Y;
    public float min_X, max_X;

    [SerializeField]
    private GameObject Laser;

    [SerializeField]
    private Transform attackPoint;

    public float attackTimer = .2f;
    private float currentAttackTimer;
    private bool canAttack;
    private bool canMove = true;
    private bool canShoot = true;

    private Animator anim;
    private AudioSource explosionSound;

    public static int dead = 3;

    void Awake()
    {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
    }

    //store current value attack
    private void Start()
    {
        currentAttackTimer = attackTimer;
    }

    //player inputs
    void FixedUpdate()
    {
        MovePlayer();
        Attack();
    }

    //actions after the input
    void MovePlayer()
    {
        if (canMove)
        {
            //vertical movement
            if (Input.GetAxisRaw("Vertical") > 0f)
            {
                Vector3 temp = transform.position;
                temp.y += speed * Time.deltaTime;

                if (temp.y > max_Y)
                {
                    temp.y = max_Y;
                }

                transform.position = temp;

            }
            else if (Input.GetAxisRaw("Vertical") < 0f)
            {
                Vector3 temp = transform.position;
                temp.y -= speed * Time.deltaTime;

                if (temp.y < min_Y)
                {
                    temp.y = min_Y;
                }

                transform.position = temp;
            }

            //horizontal movement
            //Horizontal has some default keys like the arrow cluster and classic wasd
            if (Input.GetAxisRaw("Horizontal") > 0f)
            {
                Vector3 temp = transform.position;
                temp.x += speed * Time.deltaTime;

                if (temp.x > max_X)
                {
                    temp.x = max_X;
                }

                transform.position = temp;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {
                Vector3 temp = transform.position;
                temp.x -= speed * Time.deltaTime;

                if (temp.x < min_X)
                {
                    temp.x = min_X;
                }
                transform.position = temp;
            }
        }
    }

    //player attack/shoot laser
    void Attack()
    {
        if (canShoot)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer > currentAttackTimer)
            {
                canAttack = true;
            }
            if (Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.L))
            {
                if (canAttack)
                {
                    Instantiate(Laser, attackPoint.position, attackPoint.rotation);
                    canAttack = false;
                    attackTimer = 0f;
                }
            }
        }

    }
    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }
    void Respawn()
	{
        if (lifeScript.lifeValue >= 1)
            GameManager.instance.Respawn();
    }

    void Quit()
	{
        Application.Quit();
	}
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "EnemyLaser" || target.tag == "Enemy")
        {
            if (dead > 0)
            {
                dead -= 1;
                lifeScript.lifeValue -= 1;

                canMove = false;
                canShoot = false;

                Invoke("TurnOffGameObject", 0.7f);
                anim.Play("Destroy");

                Invoke("Respawn", 0.7f);
            }
            else if (dead <= 0)
            {
                canMove = false;
                canShoot = false;

                Invoke("TurnOffGameObject", 0.7f);

                explosionSound.Play();
                anim.Play("Destroy");

                Debug.Log("GAME OVER");

                Invoke("Quit", 2f);
            }

        }
    }
}
