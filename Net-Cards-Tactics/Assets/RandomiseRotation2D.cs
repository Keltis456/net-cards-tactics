using Unity.Netcode;
using UnityEngine;

public class RandomiseRotation2D : NetworkBehaviour
{
    public NetworkVariable<float> State = new();
    
    public override void OnNetworkSpawn()
    {
        State.OnValueChanged += OnStateChanged;
        if (IsServer)
        {
            State.Value = Random.Range(-1f, 1f);
        }

        if (IsClient)
        {
            transform.Rotate(Vector3.back, State.Value);;
        }
    }
    
    public override void OnNetworkDespawn()
    {
        State.OnValueChanged -= OnStateChanged;
    }
    
    private void OnStateChanged(float previous, float current)
    {
        transform.Rotate(Vector3.back, current);
    }
}
