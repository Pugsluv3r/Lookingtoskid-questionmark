 public static void ReturnToStump()
 {
     if (RightB)
     {
         UnityEngine.Vector3 targetPosition = new UnityEngine.Vector3(-66.9039f, 11.8661f, -82.1227f);
         UnityEngine.Quaternion targetRotation = UnityEngine.Quaternion.identity;
         GTPlayer.Instance.TeleportTo(targetPosition, targetRotation);

     }

 }
