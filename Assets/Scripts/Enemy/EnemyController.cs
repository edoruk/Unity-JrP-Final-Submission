using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int layer = 10;
    private int layerAsLayerMask;

    private void Start()
    {
        layerAsLayerMask = (1 << layer);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
