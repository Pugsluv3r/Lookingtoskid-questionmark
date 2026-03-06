// you need this for alot of the methods to work
  #region controller inputs
  // Right controller
  public static bool RightTrigger => ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f;
  public static bool RightGrab => ControllerInputPoller.instance.rightGrab;
  public static bool RightA => ControllerInputPoller.instance.rightControllerSecondaryButton;
  public static bool RightB => ControllerInputPoller.instance.rightControllerSecondaryButton;
  //Left Controller
  public static bool LeftTrigger => ControllerInputPoller.instance.leftControllerIndexFloat > 0.5f;
  public static bool LeftGrab => ControllerInputPoller.instance.leftGrab;
  public static bool LeftX => ControllerInputPoller.instance.leftControllerPrimaryButton;
  public static bool LeftY => ControllerInputPoller.instance.leftControllerSecondaryButton;
  #endregion
  #region Helpers
  #endregion
