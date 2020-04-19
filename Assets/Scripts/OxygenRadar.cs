using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenRadar : MonoBehaviour
{
    private Animator anim;
    private bool isOn = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float oxygenPercent = Oxygen.GetOxygenPercent();
        if (oxygenPercent < 0.3f && !isOn)
        {
            isOn = true;
            anim.SetTrigger("BadTrigger");
        }
        else if (oxygenPercent > 0.3f && isOn)
        {
            isOn = false;
            anim.SetTrigger("GoodTrigger");
        }
    }
}
