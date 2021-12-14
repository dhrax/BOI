using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bulletPrefab;

    public float reloadTime;
    private float lastShot = 0f;
    public float bulletSpeed;
    float shootVer, shootHor;

    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        shootHor = Input.GetAxis("ShootHorizontal");
        shootVer= Input.GetAxis("ShootVertical");

        movement.x = shootHor < 0 ? Mathf.Floor(shootHor) : Mathf.Ceil(shootHor);
        movement.y = shootVer < 0 ? Mathf.Floor(shootVer) : Mathf.Ceil(shootVer);
    }

    private void FixedUpdate() {
        if((shootHor != 0 || shootVer != 0) && Time.time > reloadTime + lastShot){
            Shoot();
            lastShot = Time.time;
        }
    }

    public void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        Rigidbody2D bullertRB = bullet.GetComponent<Rigidbody2D>();
        bullertRB.MovePosition(bullertRB.position + movement * bulletSpeed * Time.fixedDeltaTime);
        bullertRB.velocity = new Vector3( movement.x * bulletSpeed, movement.y * bulletSpeed);
    }
}
