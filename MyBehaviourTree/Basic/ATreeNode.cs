using System.Collections.Generic;

namespace BaiBehaviourTree
{
    /// <summary>
    /// Base node of all tree node
    /// </summary>
    public abstract class ATreeNode
    {
        private string nodeName;
        /// <summary>
        /// parent node
        /// </summary>
        private E_LogicNodeStatus status;
        private ATreeNode parent;

#region Property

        public string NodeName { get => nodeName; set => nodeName = value; }
        /// <summary>
        /// Showing current state
        /// </summary>
        public E_LogicNodeStatus Status { get => status; set => status = value; }
        public ATreeNode Parent { get => parent; set => parent = value; }

        #endregion

        #region Generated method

        public override bool Equals(ATreeNode other)
        {
            return this.NodeName.Equals(other.NodeName);
        }

        public override string ToString()
        {
            return "this is node of behaviour tree, witch name is : " + NodeName;
        }

#endregion

#region Abstract method
        /// <summary>
        /// called for updating node behaviour
        /// </summary>
        public abstract E_LogicNodeStatus UpdateNode();

#endregion
        
    }
}