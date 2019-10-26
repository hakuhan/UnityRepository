namespace BaiBehaviourTree
{
    /// <summary>
    /// parent of leafs
    /// </summary>
    public class Leaf : ATreeNode
    {
        E_leafNodeStatus LeafState;
        object userData;

#region Override
        public override E_LogicNodeStatus UpdateNode()
        {
            // init
            if (LeafState == E_leafNodeStatus.Uninitialized)
            {
                Initialize();
            }

            // tick
            if (LeafState == E_leafNodeStatus.Running)
            {
                Status = Tick(userData);
            }

            // -- Leaf status check
            LeafState = CheckLeafStatus(self.m_status);

            // end
            if (LeafState == E_leafNodeStatus.Terminated)
            {
                Ending();
            }

            return Status;
        }
#endregion

#region LifeControl

        /// <summary>
        /// Get running state by leaf state
        /// </summary>
        /// <param name="leafState"></param>
        /// <returns></returns>
        E_LogicNodeStatus CheckLeafStatus(E_leafNodeStatus leafState)
        {
            E_LogicNodeStatus result = E_LogicNodeStatus.Success;
            switch (leafState)
            {
                case E_leafNodeStatus.Uninitialized:
                    result = E_LogicNodeStatus.Resting;
                break;

                case E_leafNodeStatus.Running:
                    result = E_LogicNodeStatus.Running;

                default:
                    result = E_LogicNodeStatus.Terminated;
                break;
            }
            return result;
        }

        /// <summary>
        /// Called when switch to this leaf
        /// </summary>
        public abstract void Init(object userData);
        /// <summary>
        /// Called every frame
        /// </summary>
        public abstract E_LogicNodeStatus Tick(object userData);
        /// <summary>
        /// Called when end this action
        /// </summary>
        public abstract void End(object userData);

        /// <summary>
        /// handle initialize
        /// </summary>
        private void Initialize()
        {
            this.LeafState = E_leafNodeStatus.Running;

            try
            {
                Init(this.userData);
            }
            catch(Exception e)
            {
                Debug.Log("Behaviour tree leaf init func error:" + e);
            }
        }

        /// <summary>
        /// Handle end state
        /// </summary>
        private void Ending()
        {
            this.LeafState = E_leafNodeStatus.Uninitialized;

            try
            {
                End(this.userData);
            }
            catch(Exception e)
            {
                Debug.Log("Behaviour tree leaf End func error:" + e);
            }
        }

#endregion
    }
}