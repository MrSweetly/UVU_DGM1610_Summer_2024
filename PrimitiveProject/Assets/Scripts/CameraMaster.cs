using UnityEngine;

public class CameraMaster : MonoBehaviour
{
   [SerializeField] private Transform target;
   private Vector3 offset;
   private Vector3 currentVelocity = Vector3.zero;
   
   private float distanceToPlayer;
   private float smoothTime = 0.25f;

   private void Awake()
   {
      // Offset Camera
      offset = transform.position - target.position;
   }

   private void LateUpdate()
   {
      // Follow Camera
      var targetPosition = target.position + offset;
      transform.position = Vector3.SmoothDamp(transform.position, targetPosition,
         ref currentVelocity, smoothTime);
   }

}
