using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    public float min_Z = -55f, max_Z = 55f; //rotation
    public float rotatingSpeed = 50f;
    public float min_Y = -2.3f;
    private float initial_Y;
    private bool moveDown;
    
    private float rotateAngle;
    private bool rotateRight;
    private bool canRotate;

    public float moveSpeed = 3f;
    private float initialSpeed;

    private RopeRenderer ropeRenderer;
    private GameObject item;

    private void Awake()
    {
        ropeRenderer = GetComponent<RopeRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        initial_Y = transform.position.y;
        initialSpeed = moveSpeed;
        canRotate = true;

    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        GetInput();
        MoveRope();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        item = collision.gameObject;
    }

    void Rotate()
    {
        if (!canRotate) return;
        if (rotateRight) rotateAngle += rotatingSpeed * Time.deltaTime;
        else rotateAngle -= rotatingSpeed * Time.deltaTime;

        transform.rotation = Quaternion.AngleAxis(rotateAngle, Vector3.forward);
        if (rotateAngle >= max_Z) rotateRight = false;
        else if (rotateAngle <= min_Z) rotateRight = true;
    }

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canRotate)
            {
                canRotate = false;
                moveDown = true;
            }
        }
    }

    void MoveRope()
    {
        if (canRotate) return;
        else
        {
            //sound
            Vector3 temp = transform.position;
            if (moveDown)
            {
                temp -= transform.up * Time.deltaTime * moveSpeed;
            }
            else
            {
                temp += transform.up * Time.deltaTime * moveSpeed;
            }

            transform.position = temp;

            if (temp.y <= min_Y) moveDown = false;
            if (temp.y >= initial_Y)
            {
                item.GetComponent<Item>().get();
                // destroy the object
                canRotate = true;
                // deactivate renderer
                ropeRenderer.RenderLine(Vector3.zero, false);
                //reset move speed
                moveSpeed = initialSpeed;
            }
            ropeRenderer.RenderLine(temp, true);
        }
        
    }

    public void moveup()
    {
        moveDown = false;
    }
}
