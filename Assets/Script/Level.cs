using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    // parameters
    [SerializeField] int breakableBlocks;  // Serialized for debugging purposes

    // cached reference
    ScenesLoader sceneloader;

    internal ScenesLoader Sceneloader { get => sceneloader; set => sceneloader = value; }

    private void Start()
    {
        sceneloader = FindObjectOfType<ScenesLoader>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneloader.LoadNextScene();
        }
    }

}