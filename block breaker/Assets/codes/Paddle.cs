using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;

    GameStatus MyGameStatus;
    BallComponent MyBall;
    // Start is called before the first frame update
    void Start()
    {
        MyGameStatus = FindObjectOfType<GameStatus>();
        MyBall = FindObjectOfType<BallComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Paddle: "+Input.mousePosition.x+" Ball: "+MyBall.transform.position.x);
        
        Vector2 PaddlePos = new Vector2(transform.position.x, 0.3f);
        PaddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = PaddlePos;

    }
    private float GetXPos()
    {
        if(MyGameStatus.isAutoPlayEnabled())
        {
            return MyBall.transform.position.x;
        }
        return Input.mousePosition.x/Screen.width*screenWidthInUnits;
    }
}
