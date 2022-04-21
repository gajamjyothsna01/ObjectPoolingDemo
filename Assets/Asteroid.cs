using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float asteroidSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left* asteroidSpeed * Time.deltaTime);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject.Find("ScoreManager").GetComponent<ScoreManagerScript>().Score(10);
            collision.gameObject.SetActive(false); //Bullet has to false

            this.gameObject.SetActive(false); //Asteroid to be false

        }
    }
}
