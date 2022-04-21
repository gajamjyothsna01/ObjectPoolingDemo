using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject asteroid;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*  
          if(Random.Range(0,100) < 3f)
          {
              //float x = Random.Range(-15f, 15f);
              Debug.Log("Asteroid Spawned");
             GameObject temp =  PoolScript.instance.GetObjectsFromPool("Asteroid");
              temp.SetActive(true);
          }*/
        time = time + Time.deltaTime;
        if (time > 3f)
        {
            Debug.Log("Asteroid");
            GameObject temp = PoolScript.instance.GetObjectsFromPool("Asteroid");
            Debug.Log("Asteroid spawn");
            temp.transform.position = this.transform.position + new Vector3(Random.Range(-10f, 15f),4f ,0f);
            temp.SetActive(true);
            //time=0;


            Debug.Log("Health");
            GameObject tempHealth = PoolScript.instance.GetObjectsFromPool("Health");
            Debug.Log("Health spawn");
            tempHealth.transform.position = this.transform.position + new Vector3(Random.Range(-10f, 15f), 4f, 0f);
            tempHealth.SetActive(true);
            time = 0;
        }
          

        
        //Debug.Log(temp);
        /*if (temp != null)
        {

            temp.transform.position = this.transform.position + new Vector3(0f,Random.Range(-3f,3f),0f);
            temp.SetActive(true);

        }*/
       
    }
}
