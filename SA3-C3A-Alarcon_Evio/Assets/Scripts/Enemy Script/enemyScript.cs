using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 50f;

    public bool canShoot;
    public bool canRotate;
    private bool canMove = true;

    public float bound_Y = -6.45f;

    public Transform attackPoint;
    public GameObject enemyLaser;

    private Animator anim;
    private AudioSource explosionSound;

    void Awake()
    {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
    }
  
    void Start()
	{
		if (canRotate)
		{
            if(Random.Range(0, 2) > 0)
			{
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
                rotateSpeed *= -1f;
			}
            else
			{
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
			}
		}

        if (canShoot)
            Invoke("StartShoot", Random.Range(1f, 3f));
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        RotateEnemy();

        if (PlayerMovement.dead <= 0)
		{
            canMove = false;

            if (canShoot)
            {
                canShoot = false;
                CancelInvoke("StartShoot");
            }
        }
    }

    void Move()
	{
		if (canMove)
		{
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;
            transform.position = temp;

            if (temp.y < bound_Y)
			{
                canMove = false;

                if (canShoot)
                {
                    canShoot = false;
                    CancelInvoke("StartShoot");
                }

                gameObject.SetActive(false);
            }
                
		}
	}

    void RotateEnemy()
	{
		if (canRotate)
		{
            transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime), Space.World);
		}
	}

    void StartShoot()
	{
        GameObject laser = Instantiate(enemyLaser, attackPoint.position, attackPoint.rotation);
        laser.GetComponent<laserScript>().is_EnemyLaser = true;

        if (canShoot)
            Invoke("StartShoot", Random.Range(1f, 3f));
	}

    void TurnOffGameObject()
	{
        gameObject.SetActive(false);
	}

    void OnTriggerEnter2D(Collider2D target)
	{
        if(target.tag == "Laser" || target.tag == "Player")
		{
            scoreScript.scoreValue += 1;
            canMove = false;

			if (canShoot)
			{
                canShoot = false;
                CancelInvoke("StartShoot");
			}

            Invoke("TurnOffGameObject", 0.4f);

            explosionSound.Play();
            anim.Play("Destroy");

		}
	}
}
