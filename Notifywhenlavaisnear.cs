public static void NotifyWhenLavaIsNear()
{
    if (PhotonNetwork.InRoom)
        try
        {
            foreach (VRRig vRRig in GorillaParent.instance.vrrigs)
                if (vRRig.isLocal && ((GorillaTagManager)GorillaGameManager.instance).isCurrentlyTag == false) 
                {
                    float playerpos = UnityEngine.Vector3.Distance(vRRig.bodyTransform.position, GTPlayer.Instance.transform.position);
                    if (playerpos < range)
                        if (Time.time > Notifdelay)
                            if (((GorillaTagManager)GorillaGameManager.instance).currentInfected.Contains(vRRig.Creator))
                            {
                                Notifdelay = Time.time + 2f;
                                NotifiLib.SendNotification("<color=purple>[WARNING]</color> Lava near you");
                            }

                }
            if (VRRig.LocalRig.isLocal &&((GorillaTagManager)GorillaGameManager.instance).isCurrentlyTag == false)
            {
                return;
                
            }
        }
        catch { } 
