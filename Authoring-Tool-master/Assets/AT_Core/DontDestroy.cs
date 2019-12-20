using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach to objects that need to be kept when switching scenes
/// </summary>
public class DontDestroy : MonoBehaviour
{
    private static bool created = false;
    private bool isNew = true;

    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            isNew = false;
        }
         if (isNew)
        {
            Destroy(this.gameObject);
        }
    }
}
