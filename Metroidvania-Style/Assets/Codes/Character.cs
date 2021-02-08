using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected float xMin, xMax;
    protected Rigidbody2D myBody;

    [SerializeField] float padding = 0.5f;
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] float jumpSpeed = 2f;

    public abstract void Attack();
    public void Move()
    {
        //if user clicks input command that sets from unity at edit-> project settings->input manager
        //which is currently a and d
        float deltaX = Input.GetAxis("Horizontal");
        //creating variable for move the character
        float newXPos = transform.position.x + deltaX * Time.deltaTime * moveSpeed;
        //checking if new position is between the edges of the screen if not set closest edge of the screen
        if (newXPos < xMin)
            newXPos = xMin;
        else if (newXPos > xMax)
            newXPos = xMax;

        //move the character
        transform.position = new Vector2(newXPos, transform.position.y);
    }

    public void Jump()
    {

        //checking if character already jumped or not and if user click space button
        if (Input.GetKeyDown("space") && myBody.velocity.y < 0.0001 && myBody.velocity.y > -0.0001)
        {
            myBody.velocity = new Vector2(0, jumpSpeed);
        }
        else if(Input.GetKeyDown("space"))
        {
            //if character is jumped checking for special jump
            StartCoroutine(SpecialJump());
        }
    }

    public abstract IEnumerator SpecialJump();

    public void SetUpMoveBoundaries()
    {
        //setting margins for the screen
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }
}
