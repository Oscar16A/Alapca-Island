﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreChest : MonoBehaviour
{
    public int scoreValue = 0;
    Text score;
    void Start()
    {
        score = GetComponent<Text>();
    }
    
    void Update()
    {
        score.text = "Score " + scoreValue;
    }
}
