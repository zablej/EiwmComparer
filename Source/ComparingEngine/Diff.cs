namespace ComparingEngine
{
    public class Diff<T> : IDiff<T>
    {
        #region Public Constructors

        public Diff(string name, T objA, T objB)
        {
            Name = name;
            ObjA = objA;
            ObjB = objB;
        }

        #endregion Public Constructors

        #region Public Properties

        public string Name { get; }
        public T ObjA { get; }
        public T ObjB { get; }

        #endregion Public Properties
    }
}