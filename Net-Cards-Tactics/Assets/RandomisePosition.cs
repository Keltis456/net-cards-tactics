using Unity.Netcode;
using UnityEngine;

public class RandomisePosition : NetworkBehaviour
{
    public NetworkVariable<Vector2> State = new();
    
    public override void OnNetworkSpawn()
    {
        State.OnValueChanged += OnStateChanged;
        if (IsServer)
        {
            State.Value = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }

        if (IsClient)
        {
            transform.position = State.Value;
        }
    }
    
    public override void OnNetworkDespawn()
    {
        State.OnValueChanged -= OnStateChanged;
    }
    
    private void OnStateChanged(Vector2 previous, Vector2 current)
    {
        transform.position = current;
    }
}
