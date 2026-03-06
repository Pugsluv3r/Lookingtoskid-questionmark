        public static void Buildgun()
        {
            if (ControllerInputPoller.instance.rightControllerGripFloat > 0.6f)
            {
                var GunData = RenderGun();
                GameObject NewPointer = GunData.NewPointer;
                if (ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f)
                {

                    if (canShoot && lastShootTime + 0.5f < Time.time)
                    {
                        lastShootTime = Time.time;
                        GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = NewPointer.transform.position;
                    }

                }
            }
        }
