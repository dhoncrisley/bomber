using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject bomb;
    public int force = 2;
    public int bombCount = 1;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        PutBomb();
        Movements();
    }

    void PutBomb()
    {

        if (Input.GetKeyDown(KeyCode.Space) && bombCount > 0)
        {
            print("pressed");
            float z = Mathf.Round(gameObject.transform.position.z);
            float x = Mathf.Round(gameObject.transform.position.x);

            Vector3 pos = new Vector3(x, gameObject.transform.position.y, z);
            Bomb b = Instantiate(bomb, pos, gameObject.transform.rotation).GetComponent<Bomb>();
            b.force = force;
            b.owner = this;
            bombCount--;
        }
    }
    void Movements()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (movement != Vector3.zero)
            rb.transform.rotation = Quaternion.LookRotation(movement);

        rb.velocity = (movement * speed);
    }


}
