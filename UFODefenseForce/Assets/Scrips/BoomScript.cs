using UnityEngine;

public class BoomScript : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      gameObject.transform.GetChild(1).gameObject.SetActive(true);
   }
}
