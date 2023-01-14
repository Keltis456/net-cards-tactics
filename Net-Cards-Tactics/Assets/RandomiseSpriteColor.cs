using Unity.Netcode;
using UnityEngine;

public class RandomiseSpriteColor : NetworkBehaviour
{
    public NetworkVariable<Color> State = new();
    
    public override void OnNetworkSpawn()
    {
        State.OnValueChanged += OnStateChanged;
        if (IsServer)
        {
            State.Value = Random.ColorHSV();
        }

        if (IsClient)
        {
            GetComponentInParent<SpriteRenderer>().color = State.Value;
        }
    }
    
    public override void OnNetworkDespawn()
    {
        State.OnValueChanged -= OnStateChanged;
    }
    
    private void OnStateChanged(Color previous, Color current)
    {
        GetComponentInParent<SpriteRenderer>().color = current;
    }
}
