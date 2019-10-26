namespace BaiBehaviourTree
{
    /// <summary>
    /// Main class of behaviour tree
    /// </summary>
    public class BehaviourTree : BehaviourTreeNode
    {
        /// <summary>
        /// judge continue or not when receive children's hehaviour
        /// </summary>
        /// <typeparam name="BaiBehaviourTree.E_LogicNodeStatus"></typeparam>
        /// <typeparam name="bool"></typeparam>
        /// <returns></returns>
        protected const Dictionary<E_LogicNodeStatus, E_conditionType> conditions 
            = new Dictionary<E_LogicNodeStatus, E_conditionType>()
            {
                {E_LogicNodeStatus.Running, E_conditionType.StopTraverse},
                {E_LogicNodeStatus.Success, E_conditionType.StopTraverse},
                {E_LogicNodeStatus.Resting, E_conditionType.StopTraverse},
                {E_LogicNodeStatus.Error, E_conditionType.ContinueTraverse},
                {E_LogicNodeStatus.Failure, E_conditionType.ContinueTraverse},
            };

        /// <summary>
        /// Store current node for previous mode
        /// </summary>
        protected int runningNodeOffset = 0;

        /// <summary>
        /// First Node of behaviour tree has no parent
        /// </summary>
        /// <value></value>
        private new ATreeNode Parent
        {
            get => base.Parent;
            set => base.Parent = value;
        }

        /// <summary>
        /// Call every frame to traverse tree self
        /// </summary>
        public override E_LogicNodeStatus UpdateNode()
        {
            // check children
            if (children.Count == 0)
            {
                Debug.Log("BehaviorTree has no children");   
            }

            if (TraverseType == E_traverseType.LoadFromPreNode)
            {
                
            }

            // Traverse all node
            for (int i = 0; i < children.Count; ++i)
            {

            }

            // -- Traverse
            // local _index = 1
            // while _index <= #self.m_children do
            //     if self.m_traverseType == TraverseType.LoadFromPreNode then
            //         -- Check preNode with runing state
            //         if self.m_runingIndex ~= nil then
            //             _index = self.m_runingIndex
            //             self.m_runingIndex = nil
            //         end                
            //     end

                
            //     local _status = self.m_children[_index]:Update(_deltaTime)
                
            //     -- judge
            //     local _nextStep = _condition[_status]
            //     if _nextStep == "break" then
            //         -- Runing check
            //         if self.m_traverseType == TraverseType.LoadFromPreNode and _status == NodeStatus.Running then
            //             self.m_runingIndex = _index
            //         end
            //         break
            //     end

            //     _index = _index + 1
            // end
            return this.Status;
        }

        /// <summary>
        /// Add node
        /// </summary>
        /// <param name="node"></param>
        public void AddNode(ATreeNode node)
        {
            AddChildNode(node);
        }
    }
}