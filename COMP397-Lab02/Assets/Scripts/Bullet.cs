using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log(other.transform.name);
        //if (other.gameObject.tag == "Enemy")
        if (other.gameObject.CompareTag("NPC"))
        {
            Destroy(other.gameObject);
        }
    }
}
