using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicText : LocalizedText
{
    private int i = 0;
    // Start is called before the first frame update
    protected override void Initialize()
    {
        StartCoroutine(RepeatMethodEvery3Seconds());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator RepeatMethodEvery3Seconds()
    {
        while (true)
        {
            // Call your method or code block here
            YourMethodToBeCalled();

            // Wait for 3 seconds before the next iteration
            yield return new WaitForSeconds(2f);
        }
    }
    private void YourMethodToBeCalled()
    {
        switch (i)
        {
            case 0:
                TextKey = "Welcome";
                break;
            case 1:
                TextKey = "Music";
                break;
            case 2:
                TextKey = "Start";
                break;
            default:
                break;
        }
        ++i;
        if (i > 2) i = 0;
        SetText();
    }
}
