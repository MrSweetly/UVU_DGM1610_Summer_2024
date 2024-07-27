using System;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
   InManager inManager;

   private void Start()
   {
      inManager = GameObject.Find("Canvas").GetComponent<InManager>();
   }

   private void OnTriggerEnter(Collider collider)
   {
      if (collider.gameObject.CompareTag("Player"))
      {
         inManager.ItemCounter();
         Debug.Log("Item picked up!");
         Destroy(gameObject);
      }
   }
}
