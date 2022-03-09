using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour
{
    public float speed = 5f;
    public float deactivateTimer = 2f;

    [HideInInspector]
    public bool is_EnemyLaser = false;

    private AudioSource laserSound;

    void Awake()
	{
        laserSound = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (is_EnemyLaser)
            speed *= -1f;

        laserSound.Play();
        Invoke("deactivateGameObject", deactivateTimer);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //laser movement
    void Move()
	{
        Vector3 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;
	}

    void deactivateGameObject()
	{
        gameObject.SetActive(false);
	}

    void OnTriggerEnter2D(Collider2D target)
	{
        if(target.tag == "Laser" || target.tag == "Enemy" || target.tag == "EnemyLaser")
        gameObject.SetActive(false);
	}
}
