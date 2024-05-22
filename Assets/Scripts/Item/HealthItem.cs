using UnityEngine;

public class HealthItem : Item
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponentInChildren<HPBar>().IncreaseHP(10);
            Destroy(gameObject);
        }
    }

}
