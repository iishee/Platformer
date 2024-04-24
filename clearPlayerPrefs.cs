using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearPlayerPrefs : MonoBehaviour

  {
    void Awake()
    {
        PlayerPrefs.DeleteAll();
    }
}