using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearY_Goblin : MonoBehaviour
{
    [SerializeField]
    GameObject[] mYellowGoblins;

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject goblins in mYellowGoblins)
        {
            goblins.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
