using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class WinnerDisplay : MonoBehaviour
{
    private float DisplayTimer;
    void Start()
    {
        Text MyText = GetComponent<Text>();
        MyText.text = "P" + (PointsSystem.WinningPlayer + 1) + " WINS!";
    }
}
