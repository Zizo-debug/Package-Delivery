using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Delivery : MonoBehaviour
    {
        public bool hasPackage;

        [SerializeField] float DestroyDelay = 0.5f;
        [SerializeField] Color32 hasPackageColor = new Color32(255, 43, 128, 255);
        [SerializeField] Color32 notPackageColor = new Color32(1, 1, 1, 1);

        [SerializeField] MessageDisplay messageDisplay;  // <-- Add reference

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Package" && !hasPackage)
            {
                hasPackage = true;
                Destroy(other.gameObject, DestroyDelay);
                messageDisplay.ShowMessage("Package picked up");
            }
            else if (other.tag == "Customer" && hasPackage)
            {
                hasPackage = false;
                messageDisplay.ShowMessage(" Package delivered");
            }
        }
    }

