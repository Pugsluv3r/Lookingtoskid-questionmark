   public static void Fling() // ts is pretty shit
   {
       if (LeftX)
       {
           GTPlayer.Instance.RightHand.controllerTransform.position = new Vector3(0, -299f, 0);
           GTPlayer.Instance.LeftHand.controllerTransform.position = new Vector3(0, -299f, 0);
       }
   }
