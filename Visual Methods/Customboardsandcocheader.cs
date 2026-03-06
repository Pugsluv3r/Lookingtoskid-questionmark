  public static GameObject messageofthedih;
  public static GameObject Motdtext;
  public static GameObject CocHeader;
  
  private static List<TextMeshPro> udTMP = new List<TextMeshPro>();


  public static void Customboards()
  {
      if (messageofthedih == null && Motdtext == null && CocHeader == null)
      {
          GameObject motdObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdHeadingText");
          messageofthedih = UnityEngine.Object.Instantiate(motdObject, motdObject.transform.parent);
          motdObject.SetActive(false);
          GameObject MotdBody = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdBodyText");
          Motdtext = UnityEngine.Object.Instantiate(MotdBody, MotdBody.transform.parent);
          MotdBody.GetComponent<PlayFabTitleDataTextDisplay>().Destroy();
          MotdBody.SetActive(false);
          GameObject CoCheadingfr = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/CodeOfConductHeadingText");
          CocHeader = GameObject.Instantiate(CoCheadingfr, CoCheadingfr.transform.parent);
          CoCheadingfr.SetActive(false);

      }

      TextMeshPro motdTc = messageofthedih.GetComponent<TextMeshPro>();
      if (!udTMP.Contains(motdTc))
          udTMP.Add(motdTc);

      motdTc.richText = true;
      motdTc.fontSize = 70;
      motdTc.text = "What you want here"; //MOTD HEADER


      TextMeshPro motdBodyTc = Motdtext.GetComponent<TextMeshPro>();
      if (!udTMP.Contains(motdBodyTc))
          udTMP.Add(motdBodyTc);
      GameObject Fuckoffplayfab = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdBodyText(Clone)");
      Fuckoffplayfab.GetComponent<PlayFabTitleDataTextDisplay>().Destroy();
      motdBodyTc.richText = true;
      motdBodyTc.fontSize = 90;
      motdBodyTc.text = "Custom MOTD here!"; //Actual MOTD contents
      motdBodyTc.color = Color.pink; // color shit
      motdBodyTc.alignment = TextAlignmentOptions.Center;

      TextMeshPro cocHeaderTc = CocHeader.GetComponent<TextMeshPro>();
      if (!udTMP.Contains(cocHeaderTc))
          udTMP.Add(cocHeaderTc);
      cocHeaderTc.richText = true;
      cocHeaderTc.fontSize = 70;
      cocHeaderTc.text = "Coc Headerplaceholder"; // COC header

  }
