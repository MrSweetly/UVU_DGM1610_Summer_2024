using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
   private void OnTriggerEnter(Collider collider)
   {
      if (collider.gameObject.CompareTag("Player"))
      {
         Debug.Log("Item picked up!");
         Destroy(gameObject);
      }
   }
}
