using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class JoystickHandler : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _joystickArea;
    [SerializeField] private Image _joystick;
    [SerializeField] private Image _joystickBackGround;

    private Vector2 _joystickBackGroundStartPosition;
    protected Vector2 InputVector;

    private void Start()
    {
        _joystickBackGroundStartPosition = _joystickBackGround.rectTransform.anchoredPosition;
    }


    public void OnDrag(PointerEventData eventData)
    {
        Vector2 sizeDelta = _joystickBackGround.rectTransform.sizeDelta;
        Vector2 joystickPosition;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBackGround.rectTransform,
                eventData.position, null, out joystickPosition))
        {
            joystickPosition.x = (joystickPosition.x * 2 / sizeDelta.x);
            joystickPosition.y = (joystickPosition.y * 2 / sizeDelta.y);

            InputVector = new Vector2(joystickPosition.x, joystickPosition.y);

            InputVector = (InputVector.magnitude > 1f) ? InputVector.normalized : InputVector;

            _joystick.rectTransform.anchoredPosition = new Vector2(
                InputVector.x * (sizeDelta.x / 2),
                InputVector.y * (sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _joystickBackGround.rectTransform.anchoredPosition = _joystickBackGroundStartPosition;

        InputVector = Vector2.zero;
        _joystick.rectTransform.anchoredPosition = Vector2.zero;
    }
}