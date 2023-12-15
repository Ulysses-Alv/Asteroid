using UnityEngine;
using UnityEngine.UI;

public class BackGroundMovement : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;

    private RawImage image => GetComponent<RawImage>();
    public static BackGroundMovement instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }
    public void MoveBackGround(Vector2 input)
    {
        image.uvRect = new Rect(image.uvRect.position + input * velocity, image.uvRect.size);
    }
}