using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public GameObject bullet;
    public Vector3 offSet;
    int maxHealth = 10;
    int health = 10;
    public bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            float inputX = Input.GetAxis("Horizontal");
            //float inputY = Input.GetAxis("Vertical");

            //transform.Translate(Vector3.up * playerSpeed * inputX* Time.deltaTime);

            transform.Translate(Vector3.down * playerSpeed * inputX * Time.deltaTime);

            //need to clamp player position - restricts out of the Box

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Instantiate(bullet, transform.position, Quaternion.Euler(0,90,0));
                GameObject tempBullet = PoolScript.instance.GetObjectsFromPool("Bullet");
                // tempBullet.transform.position = this.transform.position + new Vector3(Random.Range(-15f,15f),Random.Range(-5f,5f),0f);
                tempBullet.transform.position = this.transform.position + offSet;
                tempBullet.SetActive(true);
            }
        }
        if(health <= 0)
        {
            isGameOver = true;
            Debug.Log("GameOver");
            Destroy(gameObject);
        }

        


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if(collision.gameObject.tag == "Asteroid")
        {
           
            health--;
            collision.gameObject.SetActive(false);
            Debug.Log("Current Player Health" + health);

        }
    }
}
