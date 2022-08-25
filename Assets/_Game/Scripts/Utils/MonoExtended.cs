using UnityEngine;

public class MonoExtended : MonoBehaviour
{
    protected Transform target;
    
    public void PlayAudioClip2D(SOAudioClip clip)
    {
        SOAudioClip.PlayClip(clip);
    }

    public void PlayVFXAtTarget(ParticleSystem ps)
    {
        GameObject go = SpawnVFX(ps);
        
        Transform t = go.transform;
        t.position = target.position;
        t.rotation = target.rotation;
    }

    public void PlayVFXAtTargetParented(ParticleSystem ps)
    {
        GameObject go = SpawnVFX(ps);
        
        Transform t = go.transform;
        t.SetParent(target);
        t.localPosition = Vector3.zero;
        t.localRotation = Quaternion.identity;;
    }

    public void PlayVFX(ParticleSystem ps)
    {
        GameObject go = SpawnVFX(ps);
        
        Transform t = go.transform;
        t.position = transform.position;
        t.rotation = transform.rotation;
    }

    GameObject SpawnVFX(ParticleSystem ps)
    {
        GameObject go = Instantiate(ps.gameObject);
        Destroy(go, ps.main.duration);
        return go;
    }
}