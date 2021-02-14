using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DontDestroy : MonoBehaviour
{
   
    public GameObject[] musicObj;
    RectTransform rect;
   private void Awake()
   {
        musicObj = GameObject.FindGameObjectsWithTag("Music");
        
        if (musicObj.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
       
   }

    private void Slider()
    {
       
    }
}
