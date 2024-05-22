using UnityEngine;

public class ScoreItem : Item
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Managers.Game.Score += 1000;
            Destroy(gameObject);
        }
    }
}
