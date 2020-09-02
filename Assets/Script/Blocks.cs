using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFXS;
    
    [SerializeField] Sprite[] hitSprites;
    Level level;
    [SerializeField] int timesHit;


    private void Start()
    {
        CountBreakableBlocks();

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();

        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();

        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }

        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        {
           GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is missing from array! " + gameObject.name);
        }


    }

    private void DestroyBlock()
    {
        PlayBlocksDestroy();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggleSparks();
    }

    private void PlayBlocksDestroy()
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    public void TriggleSparks()
    {
        GameObject sparks = Instantiate(blockSparklesVFXS, transform.position, transform.rotation);
        Destroy(sparks,1f);



        Debug.Log("hiDFodhq97rhd");
    }

    

}
