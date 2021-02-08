﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadBobScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadAliceScene()
    {
        SceneManager.LoadScene(2);
    }
}
