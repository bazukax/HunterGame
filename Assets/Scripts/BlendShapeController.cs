using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendShapeController : MonoBehaviour
{
    public List<SkinnedMeshRenderer> renderers;

    void Start()
    {
        SetBlendShapesForAllRenderers(0.0f);
    }

   public void SetBlendShapesForAllRenderers(float amount)
    {
        foreach (SkinnedMeshRenderer renderer in renderers)
        {
            SetBlendShapes(renderer, amount);
        }
    }

    void SetBlendShapes(SkinnedMeshRenderer renderer, float amount)
    {
        if (renderer == null)
        {
            Debug.LogWarning("SkinnedMeshRenderer is null!");
            return;
        }

        // Iterate through all blend shapes in the SkinnedMeshRenderer
        for (int i = 0; i < renderer.sharedMesh.blendShapeCount; i++)
        {
            // Set blend shape values based on the provided amount
            float currentWeight = renderer.GetBlendShapeWeight(i);
            renderer.SetBlendShapeWeight(i, currentWeight + amount);
        }
    }
}
