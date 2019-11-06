using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endgame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if (ScoreChest.scoreValue < 6)
            {
                SceneManager.LoadScene("Homebound Ending");
            }
            else{
                SceneManager.LoadScene("Pirate Ending");
            }

        }
    }

}
