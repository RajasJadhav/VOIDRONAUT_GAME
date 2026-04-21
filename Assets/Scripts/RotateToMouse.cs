using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); //shoots a 3d ray from the camera to the mouse cursor

        if(Physics.Raycast(ray , out RaycastHit hit , 200f , groundLayer))
        {
            Vector3 targetPosition = hit.point;

            Vector3 direction = targetPosition - transform.position;
            direction.y = 0f;

            if(direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);

                transform.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);
            }
        }
    }
}
