namespace ComparingEngine
{
    public interface IDiff
    {
        #region Public Properties

        string Name { get; }

        #endregion Public Properties
    }

    public interface IDiff<T> : IDiff
    {
        #region Public Properties

        T ObjA { get; }
        T ObjB { get; }

        #endregion Public Properties
    }
}