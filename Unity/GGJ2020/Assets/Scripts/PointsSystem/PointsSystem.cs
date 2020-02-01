using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointsSystem : MonoBehaviour
{
    public static UnityEvent PlayerWinEvent = new UnityEvent();

    public static int WinningPlayer;

    public int PointsRequiredToWin;

    private Dictionary<int, int> PlayerPoints = new Dictionary<int, int>();

    void Start()
    {
        JunkMachine.RequirementsMetEvent.AddListener(OnMachineRequirementsMet);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            OnMachineRequirementsMet(0);
        }
    }

    private void OnMachineRequirementsMet(int PlayerId)
    {
        if (PlayerPoints.ContainsKey(PlayerId))
        {
            PlayerPoints[PlayerId]++;
        }
        else
        {
            PlayerPoints.Add(PlayerId, 1);
        }
        if (PlayerPoints[PlayerId] == PointsRequiredToWin)
        {
            WinningPlayer = PlayerId;
            PlayerWinEvent.Invoke();
        }
    }

    public void Reset()
    {
        PlayerPoints.Clear();
        WinningPlayer = -1;
    }
}
