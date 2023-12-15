using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public static PlayerMovementController instance;

    [Range(10f, 100f)]
    [SerializeField] private float speed;

    [Range(5f, 50f)]
    [SerializeField] private float brakeForce;

    private Rigidbody2D rb => GetComponent<Rigidbody2D>();

    #region SetUp Instance
    private void Awake()
    {
        SetInstance();
    }

    private void SetInstance()
    {
        if (instance != null && instance != this)
            Destroy(instance);

        instance = this;
    }
    #endregion


    public void Move(Vector2 inputMovement)
    {
        rb.AddForce(speed * inputMovement);

        if (IsOppositeForceDirectionInX(inputMovement))
        {
            rb.AddForce(Vector2.left * rb.velocity.x * brakeForce);
        }
        if (IsOppositeForceDirectionInY(inputMovement))
        {
            rb.AddForce(Vector2.down * rb.velocity.y * brakeForce);
        }
        Rotate(inputMovement);

        BackGroundMovement.instance.MoveBackGround(rb.velocity);
    }

    #region Private Functions

    private void Rotate(Vector2 movement)
    {
        Vector2 rotationMovement = new(-movement.x, movement.y);

        if (rotationMovement.magnitude == 0) return;

        var shipRotation = Mathf.Atan2(rotationMovement.x, rotationMovement.y) * Mathf.Rad2Deg;
        if (rb.rotation <= -90 && shipRotation >= 90)
        {
            rb.rotation += 360;
            rb.rotation = Mathf.Lerp(rb.rotation, shipRotation, 0.33f);
        }
        if (rb.rotation >= 90 && shipRotation <= -90)
        {
            rb.rotation -= 360;
            rb.rotation = Mathf.Lerp(rb.rotation, shipRotation, 0.3f);
        }
        else
        {
            rb.rotation = Mathf.Lerp(rb.rotation, shipRotation, 0.33f);
        }

    }

    private bool IsOppositeForceDirectionInX(Vector2 inputMovement)
    {
        //Verifica si el jugador quiere mover de manera opuesta a la inercia actual, de ser así devuelve verdadero.
        return (inputMovement.x > 0 && rb.velocity.x < 0) ||
                            (inputMovement.x < 0 && rb.velocity.x > 0);
    }

    private bool IsOppositeForceDirectionInY(Vector2 inputMovement)
    {
        return ((inputMovement.y > 0 && rb.velocity.y < 0) ||
                            (inputMovement.y < 0 && rb.velocity.y > 0));
    }

    #endregion
}