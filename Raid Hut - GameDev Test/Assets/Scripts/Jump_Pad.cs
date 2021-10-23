using Platformer.Mechanics;
using UnityEngine;

public class Jump_Pad : MonoBehaviour
{
    [SerializeField] float force = 7;

    Collider2D myCollider;
    Animator anim;

    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.bounds.min.y > myCollider.bounds.center.y)
        {
            if(col.GetComponent<PlayerController>() != null)
            {
                col.GetComponent<PlayerController>().Bounce(force);
                GetComponentInChildren<ParticleSystem>().Play();
                anim.SetTrigger("Bounce");
            }
        }
    }
}
