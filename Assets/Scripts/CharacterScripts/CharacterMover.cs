using System;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] float maxTimeMove;
    [SerializeField] float movementSpeed;

    float timeMove;
    bool isMoving;
    bool destroyAfterMove = false;
    Vector3 moveDir;

    public static Action OnCharacterStopped;
    public static Action OnCharacterStartMove;

    public void MoveLeft(bool destroyAfterMove)
    {
        MoveCommon(destroyAfterMove, Vector3.left);
    }

    public void MoveRight(bool destroyAfterMove)
    {
        MoveCommon(destroyAfterMove, Vector3.right);
    }

    void MoveCommon(bool destroyAfterMove, Vector3 dir)
    {
        OnCharacterStartMove?.Invoke();
        ButtonInteractableController.OnButtonsDisable?.Invoke();
        moveDir = dir;
        this.destroyAfterMove = destroyAfterMove;
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            if(timeMove < maxTimeMove)
            {
                transform.position += movementSpeed * Time.deltaTime * moveDir;
                timeMove += Time.deltaTime;
            }
            else
            {
                timeMove = 0;
                if (destroyAfterMove)
                {
                    Destroy(gameObject);
                }
                else
                {
                    ButtonInteractableController.OnButtonsEnable?.Invoke();
                    OnCharacterStopped?.Invoke();
                    isMoving = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        timeMove = maxTimeMove;
    }
}














