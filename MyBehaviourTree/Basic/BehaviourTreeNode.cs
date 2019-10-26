namespace BaiBehaviourTree
{
    /// <summary>
    /// parent node of logic node
    /// </summary>
    public class BehaviourTreeNode : ATreeNode
    {
        protected List<ATreeNode> children = new List<ATreeNode>();
        private E_traverseType traverseType;
        
        public E_traverseType TraverseType { get => traverseType; set => traverseType = value; }

        #region Override

        public override E_LogicNodeStatus UpdateNode()
        {
            return this.Status;
        }

        #endregion

        #region Manage children node
        /// <summary>
        /// You can add Child node by this method
        /// </summary>
        /// <param name="node"></param>
        public void AddChildNode(ATreeNode node)
        {
            if (children.Contains(node) == false)
            {
                children.Add(node);
            }
            else
            {
                Debug.Log("Child Node has been added: " + node.name);
            }
        }

        /// <summary>
        /// Remove node
        /// </summary>
        /// <param name="node"></param>
        public void RemoveChildNode(ATreeNode node)
        {
            if (children.Contains(nodeName))
            {
                children.Remove(node);
            }
        }

        /// <summary>
        /// Change node
        /// </summary>
        public void UpdateChild(ATreeNode oldNode, ATreeNode newNode)
        {
            int oldNodeIndex = children.FindIndex((node)=>{
                return oldNode.Equals(node);
            });

            if (oldNodeIndex != -1)
            {
                children[oldNodeIndex] = newNode;
            }
            else
            {
                Debug.Log("Old node: " + oldNode.ToString() + "Not exists!");
            }
        }

#endregion
    

    }
}