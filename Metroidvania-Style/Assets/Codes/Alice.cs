using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alice : Character
{
    [SerializeField] float dashSpeed = 3f;
    [SerializeField] float dashDuration = 0.3f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float projectileSpeed = 1f;

    public override void Attack()
    {
        //if user clicks left click creating game object for bullet and fire it to the right
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
        }

    }

    public override IEnumerator SpecialJump()
    {
        //special jump condition for alice
        myBody.velocity = new Vector2(dashSpeed, myBody.velocity.y);
        yield return new WaitForSeconds(dashDuration);
        myBody.velocity = new Vector2(0, myBody.velocity.y);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
        myBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Attack();
    }
}
