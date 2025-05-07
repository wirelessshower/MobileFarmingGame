using UnityEngine;


public class MobileJoystick : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private RectTransform joysticOutline;
    [SerializeField] private RectTransform joysticKnob;

    [Header("Settings")]
    [SerializeField] private float moveFactor;
    private Vector3 clickedPosition;
    private Vector3 move;
    private bool canControl;

    void Start()
    {
        HideJoystick();
    }

    void Update()
    {
        if(canControl)
            ControlJoystick();
    }

    public void ClickedOnJoystickZoneCallback(){
        clickedPosition = Input.mousePosition;    
        joysticOutline.position = clickedPosition;
        ShowJoystick();
    }

    private void ShowJoystick(){
        joysticOutline.gameObject.SetActive(true);
        canControl = true;
    }

    private void HideJoystick(){
        joysticOutline.gameObject.SetActive(false);
        canControl = false;

        move = Vector3.zero;
    }

    private void ControlJoystick(){
        Vector3 currentPosition = Input.mousePosition;
        Vector3 direction = currentPosition - clickedPosition;

        float canvasScale = GetComponentInParent<Canvas>().GetComponent<RectTransform>().localScale.x;

        float moveMagnitude = direction.magnitude * moveFactor * canvasScale;
        
        float absaluteWidth = joysticOutline.rect.width / 2;
        float realWidth = absaluteWidth * canvasScale;         

        moveMagnitude = Mathf.Min(moveMagnitude, realWidth);

        move = direction.normalized * moveMagnitude;

        Vector3 targetPosition = clickedPosition + move;

        joysticKnob.position = targetPosition;

        if(Input.GetMouseButtonUp(0))
            HideJoystick();
    }

    public Vector3 GetMoveVector(){
        return move;
    }

}
