using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class Card : MonoBehaviour
{
    public bool hasBeenPlayed;

    public int handIndex;

    private GameManager gm;

    public Enemy enemyTakeDamage;

    public int cardDamage;

    // Start is called before the first frame update
    void Start()
    {
       
        gm = FindObjectOfType<GameManager>();
        Enemy enemyTakeDamage = gameObject.GetComponent<Enemy>();
    }

    private void OnMouseDown()
    {
        if (hasBeenPlayed == false)
        {
            transform.position += Vector3.up * 5;
            hasBeenPlayed = true;
            gm.availbleCardSlots[handIndex] = true;
            enemyTakeDamage.EnemyTakeDamage(cardDamage);
            Invoke("MoveToDiscardPile", 0.5f);
        }
    }

    void MoveToDiscardPile()
    {
        gm.discardPile.Add(this);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
