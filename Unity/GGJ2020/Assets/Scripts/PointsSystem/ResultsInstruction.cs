using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ResultsInstruction : MonoBehaviour
{
    private float DisplayTimer;
    private Text MyText;
    void Start()
    {
        MyText = GetComponent<Text>();
        MyText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayTimer += Time.deltaTime;

        if (DisplayTimer < ResultsState.ResultDelay)
        {
            return;
        }
        else if (MyText.enabled == false)
        {
            MyText.enabled = true;
        }
    }
}
