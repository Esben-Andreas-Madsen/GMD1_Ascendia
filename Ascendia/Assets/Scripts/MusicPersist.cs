using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPersist : MonoBehaviour
{
    public static MusicPersist instance;

    void Awake()
    {
        if (instance != null)
        Destroy(gameObject);

        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
       

    }
}
