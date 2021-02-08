using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{

    [SerializeField] float speed = 0.2f;
    Material myMaterial;
    Vector2 offSet;
    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(speed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //if user click to move right which is "d", I am moving background and ground to the right
        float deltaX = Input.GetAxis("Horizontal");
        if (deltaX > 0)
            myMaterial.mainTextureOffset += offSet * Time.deltaTime * deltaX;

    }
}
