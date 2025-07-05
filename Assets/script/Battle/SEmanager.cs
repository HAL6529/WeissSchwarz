using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEmanager : MonoBehaviour
{
    [SerializeField] AudioClip AttackSE;
    [SerializeField] AudioClip EffectSE;
    [SerializeField] AudioClip DrawSE;
    [SerializeField] AudioClip LevelUpSE;
    [SerializeField] AudioClip PlaySE;
    [SerializeField] AudioClip ShuffleSE;
    [SerializeField] AudioSource m_AudioSource;

    public void AttackSE_Play()
    {
        m_AudioSource.PlayOneShot(AttackSE);
    }

    public void DrawSE_Play()
    {
        m_AudioSource.PlayOneShot(DrawSE);
    }

    public void EffectSE_Play()
    {
        m_AudioSource.PlayOneShot(EffectSE);
    }

    public void LevelUpSE_Play()
    {
        m_AudioSource.PlayOneShot(LevelUpSE);
    }

    public void PlaySE_Play()
    {
        m_AudioSource.PlayOneShot(PlaySE);
    }

    public void ShuffleSE_Play()
    {
        m_AudioSource.PlayOneShot(ShuffleSE);
    }
}
