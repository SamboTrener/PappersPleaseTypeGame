using UnityEngine;

public class EmployeeMover : MonoBehaviour
{
    [SerializeField] float maxTimeMove;
    [SerializeField] float movementSpeed;

    float timeMove;
    bool isMoving;
    bool destroyAfterMove = false;
    Vector3 moveDir;

    private void Start()
    {
        moveDir = Vector3.right;
    }

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
        ButtonOnMoving.OnEmployeeMoving?.Invoke();
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
                if (destroyAfterMove)
                {
                    Destroy(gameObject);
                }
                else
                {
                    isMoving = false;
                }
                timeMove = 0;
                ButtonOnMoving.OnEmployeeStopped?.Invoke();
            }
        }
    }
}
