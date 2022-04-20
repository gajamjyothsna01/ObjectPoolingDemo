using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        transform.Translate(Vector3.up * playerSpeed * inputX* Time.deltaTime);

        transform.Translate(Vector3.left* playerSpeed * inputY * Time.deltaTime);

        //need to clamp player position - restricts out of the Box

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0,90,0));
        }


    }
}
