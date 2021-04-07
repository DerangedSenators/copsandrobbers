using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// @authors Nisath Mohamed Nasar
    /// <summary>
    ///     Remove Duplicates of this objects
    /// </summary>
    public class RemoveOtherInstances : MonoBehaviour
    {
        private void Awake()
        {
            if (GameObject.FindGameObjectsWithTag("SFX").Length <= 1)
            {
            }
            else // if theres more than one object of this type, keep this and remove others
            {
                Destroy(GameObject.FindWithTag("SFX"));
            }
        }
    }
}