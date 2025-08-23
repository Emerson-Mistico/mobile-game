using UnityEngine;

public class TouchController : MonoBehaviour
{

    public Vector2 pastPosition;
    public float velocity = 3.5f;   

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move(Input.mousePosition.x - pastPosition.x);
        }

        pastPosition = Input.mousePosition;

    }

    public void Move(float moveSpeed)
    {
        transform.position += moveSpeed * Time.deltaTime * velocity * Vector3.right;
    }

}
