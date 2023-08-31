using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Enemy : Unit
{

    public GameObject projectilePrefab;

    public float throwForce = 10f; //the speed at which the projectile is thrown
    public float throwAngle = 45f; //the angle at which the projectile is thrown
    public float rotationSpeed = 5f; //how fast the enemy may rotate to face the player;
    public float shotCooldown = 2f; //number of seconds to wait between shots;

    private Transform projectileSpawnPoint;
    private Transform playerTransform;
    [SerializeField] private GameObject player;
    [SerializeField] private HealthBar healthBar;

    public bool playerInRange;

    private float timeSinceLastShot = 0f; //used to enforce the cooldown


    // Start is called before the first frame update
    new void Awake()
    {
        base.Awake();
        projectileSpawnPoint = GetComponent<Transform>();
        healthBar = GetComponent<HealthBar>();
        playerTransform = player.transform;

    }

    public void playDeathSound()
    {
        AudioController.instance.Play("EnemyDeath");
    }

    public void updateHealth()
    {
        healthBar.UpdateHealthBar(HP, MaxHP);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            timeSinceLastShot += Time.deltaTime;
            if(timeSinceLastShot >= shotCooldown) {
                fireProjectile();
                timeSinceLastShot = 0f;
            }
            rotateToPlayer();
        }
    }

    private void rotateToPlayer()
    {
        // Rotate towards the player using Quaternion.Slerp
        Vector3 direction = playerTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void fireProjectile()

    {
        // Calculate the initial velocity for the projectile
        Vector3 throwDirection = Quaternion.AngleAxis(-throwAngle, transform.right) * transform.forward;
        Vector3 throwVelocity = throwDirection.normalized * throwForce;

        // Throw the projectile using a parabolic arc
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        ProjectileController projectileController = projectile.GetComponent<ProjectileController>();
        projectileController.Throw(throwVelocity, Physics.gravity) ;
        Debug.Log("Shots fired!");
    }
}
