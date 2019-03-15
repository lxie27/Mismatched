using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Mousedown");
        Play();
    }
    void Play()
    {
        Debug.Log("Pressed play");
        Application.LoadLevel("Game");
    }
}
