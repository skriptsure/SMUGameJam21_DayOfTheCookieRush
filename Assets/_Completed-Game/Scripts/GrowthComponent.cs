using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowthComponent : MonoBehaviour
{
    public AnimationCurve radius;
    public AnimationCurve mass;
    public AnimationCurve jump;
    public AnimationCurve speed;

    public Text countText;
    public float turnonPhysicsMultiplier = 2.0f;

    public int count = 0;
    private Rigidbody rb;
    private PlayerController pc;
    private SphereCollider sphere;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pc = GetComponent<PlayerController>();
        sphere = GetComponent<SphereCollider>();

        GrowFromStats();
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // When this game object intersects a collider with 'is trigger' checked, 
    // store a reference to that collider in a variable named 'other'..
    void OnTriggerEnter(Collider other)
    {
        // ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.CompareTag("Pick Up"))
        {
            // Make the other game object (the pick up) inactive, to make it disappear
            other.gameObject.SetActive(false);

            // Add one to the score variable 'count'
            count = count + 1;

            GrowFromStats();
            SetCountText();
        }
    }

    void GrowFromStats()
    {
        gameObject.transform.localScale = Vector3.one * radius.Evaluate(count);
        rb.mass = mass.Evaluate(count);
        //sphere.radius = radius.Evaluate(count);
        pc.jump = jump.Evaluate(count);
        pc.speed = speed.Evaluate(count);
    }

    // Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
    void SetCountText()
    {
        // Update the text field of our 'countText' variable
        countText.text = "Count: " + count.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Debug-draw all contact points and normals

        Rigidbody otherBody = collision.gameObject.GetComponent<Rigidbody>();
        if (otherBody)
        {
            if (rb.mass * turnonPhysicsMultiplier > otherBody.mass && otherBody.isKinematic)
            {
                otherBody.isKinematic = false;
            }
        }


        // Play a sound if the colliding objects had a big impact.
        //if (collision.relativeVelocity.magnitude > 2)
        //    audioSource.Play();
    }
}
