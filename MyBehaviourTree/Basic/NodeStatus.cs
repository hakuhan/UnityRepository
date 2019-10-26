namespace BaiBehaviourTree
{
    /// <summary>
    /// How behaviour tree traverse
    /// </summary>
    public enum E_traverseType
    {
        /// from root every time
        LoadFromRootNode = 1,
        /// from previous node every time
        LoadFromPreNode = 2,
    }

    /// <summary>
    /// tree node state
    /// </summary>
    public enum E_LogicNodeStatus
    {
        Failure = 1,
        Success = 2,
        Running = 3,
        Resting = 4,
        Error = 5,
    }

    /// <summary>
    /// type to judge when getting children's behaviour
    /// </summary>
    public enum E_conditionType
    {
        ContinueTraverse,
        StopTraverse,
    }

    /// <summary>
    /// leaf node has some type
    /// </summary>
    public enum E_leafNodeStatus
    {
        Uninitialized = 0,
        Running,
        Terminated,
    }

    /// <summary>
    /// parallel mode
    /// </summary>
    public enum E_parallelType
    {
        SequenceParallel = 1,
        SelectorParallel = 2,
        FallOnAllParallel = 3,
        SuccessOnAllParallel = 4,
        HybirdParallel = 5,
        SuccessBySpecifiedChildren = 6,
    }
}