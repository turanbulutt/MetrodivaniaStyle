using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : Character
{
    public override void Attack()
    {

    }

    public override IEnumerator SpecialJump()
    {
        //to move down quickly 
        myBody.velocity = new Vector2(0, -10);
        yield return 0;
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
    }
}
