using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public GameObject bullet;
    public Vector3 offSet;
    int maxHealth = 10;
    int health = 10;
    public bool isGameOver = false;
    public Text displayHealthText;
    public Text healthText;
    public Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            healthSlider.value = (float)health / 10;
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");

            transform.Translate(Vector3.right * playerSpeed * inputY* Time.deltaTime);

            transform.Translate(Vector3.down * playerSpeed * inputX * Time.deltaTime);
            
            if (transform.position.y > 3.9f)
            {
                transform.position = new Vector3(transform.position.x, 3.9f, 0);
            }
            else if (transform.position.y < -3.9f)
            {
                transform.position = new Vector3(transform.position.x, -3.9f, 0);
            }
            if (transform.position.x > 15.1f)
            {
                transform.position = new Vector3(15.1f, transform.position.y, 0);
            }
            else if (transform.position.x < -14.8f)
            {
                transform.position = new Vector3(-14.8f, transform.position.y, 0);
            }


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
        //Debug.Log("Collision");
        if(collision.gameObject.tag == "Asteroid")
        {
           
            health--;
            collision.gameObject.SetActive(false);
           // Debug.Log("Current Player Health" + health);
            healthText.text = health.ToString();

            GameObject tempAsteroid = collision.gameObject;
            tempAsteroid.SetActive(false);

        }
        
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Health" && health < maxHealth)
        {
            //Debug.Log("tRIGGERED");
            health = Mathf.Clamp(health + 1, 0, maxHealth);
            collision.gameObject.SetActive(false);
            //Debug.Log("iNCREASED HEALTH " + health);
            healthText.text = health.ToString();    

        }
    }

}
