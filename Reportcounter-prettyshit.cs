       public static float Lastreporttime = 0f;
       public static float threshold = 0.115f;
       public static int reportcount = 0;
       public static float Notifdelay;
       public static float Thing1 { get; private set; }
       public static float Thing2 { get; private set; }
       public static bool diddyhereportingyoublud = false;
       private static bool wasBeingReported = false;

       public static void AntiReport()
       {
           if (!PhotonNetwork.InRoom)
           {
               wasBeingReported = false;
               return;
           }

           try
           {
               foreach (GorillaPlayerScoreboardLine line in GorillaScoreboardTotalUpdater.allScoreboardLines)
               {
                   if (line.linePlayer != NetworkSystem.Instance.LocalPlayer) continue;

                   Transform report = line.reportButton.gameObject.transform;
                   float nearestRight = float.MaxValue;
                   float nearestLeft = float.MaxValue;
                   bool currentlyReported = false;

                   foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                   {
                       if (vrrig == VRRig.LocalRig) continue;

                       float dRight = Vector3.Distance(vrrig.rightHandTransform.position, report.position);
                       float dLeft = Vector3.Distance(vrrig.leftHandTransform.position, report.position);

                       if (dRight < nearestRight) nearestRight = dRight;
                       if (dLeft < nearestLeft) nearestLeft = dLeft;

                       if (dRight < threshold || dLeft < threshold)
                       {
                           currentlyReported = true;
                           break;
                       }
                   }
                   Thing1 = nearestRight;
                   Thing2 = nearestLeft;
                   diddyhereportingyoublud = currentlyReported;

                   if (currentlyReported && !wasBeingReported)
                   {
                       wasBeingReported = true;
                       if (Time.time > Notifdelay)
                       {
                           Notifdelay = Time.time + 4f;
                           reportcount++;
                           NotifiLib.SendNotification("<color=Red>[AR]:</color> You've been reported " + reportcount + " times (Note this may be inaccurate)");
                       }
                   }
                   else if (!currentlyReported)
                   {
                       wasBeingReported = false;
                   }
               }
           }
           catch (Exception)
           {

           }
