using Platformer.Core;
using Platformer.Model;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] Color activatedColor;

    //Para que não seja ativado repetidamente
    bool activated = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player" && !activated)
        {
            //altera o ponto de respawn, com troca de cor e efeito de partículas para feedback do jogador
            Simulation.GetModel<PlatformerModel>().spawnPoint = transform;
            activated = true;
            GetComponentInChildren<SpriteRenderer>().color = activatedColor;
            GetComponentInChildren<ParticleSystem>().Play();
        }
    }
}
