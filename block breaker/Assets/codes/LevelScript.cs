using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    [SerializeField] int NumberOfBreakableBlocks=0;
    SceneLoader sceneloader;
    private void Start()
    {
        sceneloader = GetComponent<SceneLoader>();
    }
    public void CountBlocks()
    {
        NumberOfBreakableBlocks++;
    }
    public void DeleteBrokenBlocks()
    {
        NumberOfBreakableBlocks--;
        if(NumberOfBreakableBlocks<=0)
        {
            sceneloader.LoadNextScene();
        }
    }
}
