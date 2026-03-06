 public static void Joinroom(string roomName)
 {
     PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(roomName, JoinType.Solo);
 } // if you cant figure this shit out on your own dont make a menu
