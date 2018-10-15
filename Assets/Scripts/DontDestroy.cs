using System.Collections;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1) 
            Destroy(objs[0]);
        DontDestroyOnLoad(this.gameObject);
        
    }
}
