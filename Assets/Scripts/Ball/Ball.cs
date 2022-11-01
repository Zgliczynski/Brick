using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    public static event Action<Ball> OnBallDeath;
    public static event Action<Ball> OnLightingBallEnable;
    public static event Action<Ball> OnLightingBallDisable;

    public bool isLightingBall;
    private SpriteRenderer sr;

    public ParticleSystem lightingBallEffect;

    private float lightingBallDuration = 10;

    private void Awake()
    {
        this.sr = GetComponentInChildren<SpriteRenderer>();
    }

    public void StartLightingBall()
    {
        if (!this.isLightingBall)
        {
            this.isLightingBall = true;
            this.sr.enabled = false;
            lightingBallEffect.gameObject.SetActive(true);
            StartCoroutine(StopLightingBallAfterTime(this.lightingBallDuration));

            OnLightingBallEnable?.Invoke(this);
        }
    }

    private IEnumerator StopLightingBallAfterTime(float secends)
    {
        yield return new WaitForSeconds(secends);

        StopLightingBallAfterTime();
    }

    private void StopLightingBallAfterTime()
    {
        if (this.isLightingBall)
        {
            this.isLightingBall = false;
            this.sr.enabled = true;
            lightingBallEffect.gameObject.SetActive(false);

            OnLightingBallDisable?.Invoke(this);
        }
    }

    public void Die()
    {
        OnBallDeath?.Invoke(this);
        Destroy(gameObject, 1);
    }
}
