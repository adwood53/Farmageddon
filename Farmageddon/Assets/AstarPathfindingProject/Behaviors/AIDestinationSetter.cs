using UnityEngine;
using System.Collections;

namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : VersionedMonoBehaviour {
		/// <summary>The object that the AI should move to</summary>
		public Transform target1;
        public Transform target2;
        public Transform target;

        private Transform agent;
        private float yDis1;
        private float xDis1;
        private float yDis2;
        private float xDis2;

        public float Damage;

        IAstarAI ai;

        void Start()
        {
            agent = gameObject.GetComponent<Transform>();
            yDis1 = Mathf.Abs(target1.position.y - agent.position.y);
            xDis1 = Mathf.Abs(target1.position.x - agent.position.x);
            yDis2 = Mathf.Abs(target2.position.y - agent.position.y);
            xDis2 = Mathf.Abs(target2.position.x - agent.position.x);
            target = target1;
        }

		void OnEnable () {
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
        }

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update ()
        {
            yDis1 = Mathf.Abs(target1.position.y - agent.position.y);
            xDis1 = Mathf.Abs(target1.position.x - agent.position.x);
            yDis2 = Mathf.Abs(target2.position.y - agent.position.y);
            xDis2 = Mathf.Abs(target2.position.x - agent.position.x);

            if(Mathf.Sqrt((yDis1 * yDis1) + (xDis1 * xDis1)) > Mathf.Sqrt((yDis2 * yDis2) + (xDis2 * xDis2)))
            {
                target = target2;
            }
            else
            {
                target = target1;
            }

            if (target != null && ai != null) ai.destination = target.position;
        }
	}
}
