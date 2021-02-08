using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] Sprite brokenblock=null;
    [SerializeField] Sprite brokenblock2=null;
    SpriteRenderer blockSprite;
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject BlockSparkles;

    LevelScript level;
    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<LevelScript>();
        if (CompareTag("one shot")|| CompareTag("two shot") ||CompareTag("three shot") )
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        blockSprite = gameObject.GetComponent<SpriteRenderer>();
        Debug.Log(blockSprite.tag);
        Debug.Log(blockSprite.color.a);
        if (blockSprite.color.a==0.5f || CompareTag("one shot"))
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
            Destroy(gameObject);
            TriggerSparkles();
            FindObjectOfType<GameStatus>().AddScore(blockSprite.tag);
            level.DeleteBrokenBlocks();
        }
        else if(blockSprite.color.a==0.8f || CompareTag("two shot"))
        {
            blockSprite.color = new Color(blockSprite.color.r,blockSprite.color.g,blockSprite.color.b, 0.5f);
        }
        else if(CompareTag("three shot"))
        {
            blockSprite.color = new Color(blockSprite.color.r, blockSprite.color.g, blockSprite.color.b, 0.8f);
        }
        
    }
    private void TriggerSparkles()
    {
        GameObject sparkles = Instantiate(BlockSparkles,this.transform.position,transform.rotation);
        Destroy(sparkles, 2f);
    }
}
