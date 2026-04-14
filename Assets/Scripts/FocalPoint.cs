using UnityEngine;

public class FocalPoint : MonoBehaviour
{
    void Update()
    {
        if(!GameManager.Instance.LockCamera)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, 100.0f * horizontalInput * Time.deltaTime);
        }
    }
}
