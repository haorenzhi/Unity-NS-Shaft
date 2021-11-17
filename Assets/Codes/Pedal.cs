using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedal : MonoBehaviour
{
    private Vector2 Velocity;
    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Velocity = new Vector2(0, 12);
        rigidBody.velocity = Velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.WorldToScreenPoint(gameObject.transform.position).y > Screen.height)
        {
            Destroy(gameObject);
        }
    }
}
