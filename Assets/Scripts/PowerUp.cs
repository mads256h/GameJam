using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public Consts.PowerUpType PowerUpType = Consts.PowerUpType.Health;

    public Sprite HealthSprite;
    public Sprite OneshotSprite;
    public Sprite FirerateSprite;
    public Sprite BlastSprite;

    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();

        int rnd = Random.Range(0, 4);

        PowerUpType = (Consts.PowerUpType)rnd;


        switch (PowerUpType)
        {
            case Consts.PowerUpType.Health:
                spriteRenderer.sprite = HealthSprite;
                break;
            case Consts.PowerUpType.Oneshot:
                spriteRenderer.sprite = OneshotSprite;
                break;
            case Consts.PowerUpType.Firerate:
                spriteRenderer.sprite = FirerateSprite;
                break;
            case Consts.PowerUpType.Blast:
                spriteRenderer.sprite = BlastSprite;
                break;
        }

    }
}
