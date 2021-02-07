using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    /// <summary>
    /// This interface must be implemented by any and all classes that want to provide an additonal perspective for the player in the form of a Camera.
    /// </summary>
    public interface IPlayerCamera
    {
        /// <summary>
        /// Assigns the camera with a transform to follow
        /// </summary>
        /// <param name="transform">The transform that the camera must follow</param>
        void assignFollowTransform(Transform transform);

        /// <summary>
        /// Checks if a Transform is already assigned to the player
        /// </summary>
        /// <returns> True if the camera has a transform assigned otherwise false.</returns>
        bool isAssigned();
    }
}