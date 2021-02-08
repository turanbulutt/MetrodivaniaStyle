using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCommands : MonoBehaviour
{
    protected float xMin, xMax;
    [SerializeField] float padding = 0.5f;
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] GameObject character;
    [SerializeField] float jumpSpeed = 2f;
    [SerializeField] float dashSpeed = 3f;
    [SerializeField] float dashDuration = 0.3f;

    private void Start()
    {
        //setting margins for the screen
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }
    public void MoveLeft()
    {
        //creating variable for move the character
        float newXPos = character.transform.position.x + -1 * Time.deltaTime * moveSpeed;
        //checking if new position is between the edges of the screen if not set closest edge of the screen
        if (newXPos < xMin)
            newXPos = xMin;
        else if (newXPos > xMax)
            newXPos = xMax;

        //move the character
        character.transform.position = new Vector2(newXPos, character.transform.position.y);
    }

    public void MoveRight()
    {
        //creating variable for move the character
        float newXPos = character.transform.position.x + Time.deltaTime * moveSpeed;
        //checking if new position is between the edges of the screen if not set closest edge of the screen
        if (newXPos < xMin)
            newXPos = xMin;
        else if (newXPos > xMax)
            newXPos = xMax;

        //move the character
        character.transform.position = new Vector2(newXPos, character.transform.position.y);
    }

    public void Jump()
    {
        Rigidbody2D myBody;
        myBody = character.GetComponent<Rigidbody2D>();

        //checking if character already jumped or not
        if (myBody.velocity.y < 0.0001 && myBody.velocity.y > -0.0001)
        {
            myBody.velocity = new Vector2(0, jumpSpeed);
        }
        else
        {
            //if character is jumped checking for special jump
            StartCoroutine(SpecialJump(myBody));
        }
    }

    public IEnumerator SpecialJump(Rigidbody2D myBody)
    {
        //making special jump conditions 
        myBody.velocity = new Vector2(dashSpeed, myBody.velocity.y);
        yield return new WaitForSeconds(dashDuration);
        myBody.velocity = new Vector2(0, myBody.velocity.y);

    }
}
