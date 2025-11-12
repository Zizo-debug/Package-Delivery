using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.1f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float DestroyDelay = 0.5f;
    [SerializeField] float boostSpeed = 30f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal")*steerSpeed * Time.deltaTime;
        float steerVertical = Input.GetAxis("Vertical")*moveSpeed* Time.deltaTime;
        transform.Translate(0, steerVertical, 0);
        transform.Rotate(0, 0, -steerAmount);
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fast")
        {
            Debug.Log("Im here");
            //  spriteRenderer.color = hasPackageColor; 
            float steerVertical = Input.GetAxis("Vertical") * boostSpeed * Time.deltaTime;
            float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
            transform.Translate(0, steerVertical, 0);
            transform.Rotate(0, 0, -steerAmount);
            Destroy(other.gameObject, DestroyDelay);
        }
        else if(other.tag == "Slow")
        {
            Debug.Log("Im here");
            float steerVertical = Input.GetAxis("Vertical") * slowSpeed * Time.deltaTime;
            float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
            transform.Translate(0, steerVertical, 0);
            transform.Rotate(0, 0, -steerAmount);
            Destroy(other.gameObject, DestroyDelay);
        }
    }
}
