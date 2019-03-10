using UnityEngine;

namespace Alexplay.Balda.App
{
    [RequireComponent(typeof(Camera))]
    public class CamResizer : MonoBehaviour
    {
        
        private void Awake() {
            
            GetComponent<Camera>().orthographicSize = ViewUtils.ScreenHalfHeight;
        }
        
    }
}