using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float _smoothedSpeed = 0.125f;
    [SerializeField] private float _viewDistance = 5.0f;
    
    private void CameraChasing()
    {
        if (player != null)
        {
            Vector3 playerInitialPosition = player.transform.position - _viewDistance * player.transform.forward;
            
            Vector3 smoothedPosition =
                Vector3.Lerp(transform.position, playerInitialPosition, _smoothedSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
            
    }

    private void LateUpdate()
    {
        CameraChasing();
    }
}
