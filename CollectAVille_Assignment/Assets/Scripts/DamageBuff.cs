using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageBuff : Collectible
{
    public int BuffAmount = 2;
    public Color ColorChange = Color.red;
    public TextMeshProUGUI BuffMessage;

    private void Start()
    {
        BuffMessage.enabled = false;
    }
    public override void Collect()
    {
        BuffMessage.enabled = true;
    }


}
