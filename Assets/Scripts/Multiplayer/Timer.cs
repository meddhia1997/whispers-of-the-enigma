using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using DapperDino.UMT.Lobby.Networking;

public class Timer : MonoBehaviour
{

    [SerializeField] private GameObject Anchor,timeCanvas;
    public InputActionProperty toggleTimer;
    public bool UIActive=true;
    [SerializeField] private Image uiFill;
    [SerializeField] private Text uiText;

    public int Duration;

    private int remainingDuration;


    private void Start()
    {
        Being(Duration);
    }

    private void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }

    private void Update()
    {
        if (toggleTimer.action.WasPressedThisFrame())
        {
            UIActive = !UIActive;
            timeCanvas.SetActive(UIActive);
        }
        if (UIActive)
        {
            transform.position = Anchor.transform.position;
            transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        }
    }
    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {

            uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
            uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);

            yield return null;
        }
        OnEnd();
    }

    private void OnEnd()
    {
        ServerGameNetPortal.Instance.EndRound();
        Debug.Log("Timer Ended");
    }
}
