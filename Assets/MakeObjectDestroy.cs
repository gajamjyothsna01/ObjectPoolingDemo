using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeObjectDestroy : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    private void OnBecameInvisible()
    {
        //Destroy(gameObject);
       this.gameObject.SetActive(false);

    }
}
