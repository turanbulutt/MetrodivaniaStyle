using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallComponent : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 5f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float RandomFactor = 0.2f;
    Vector2 PaddleToBallVector;
    int IsLaunch = 0;
    AudioSource MyAudioSource;
    Rigidbody2D myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        PaddleToBallVector = transform.position - paddle1.transform.position;
        MyAudioSource = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (IsLaunch==0)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
            
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody.velocity = new Vector2(xPush, yPush);
            IsLaunch = 1;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 PaddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = PaddlePos + PaddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0, RandomFactor), UnityEngine.Random.Range(0, RandomFactor));
        if(IsLaunch==1)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            MyAudioSource.PlayOneShot(clip);
            myRigidBody.velocity += velocityTweak;
            
        }
        
    }
}
