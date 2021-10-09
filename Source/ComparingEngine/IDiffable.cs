using System.Collections.Generic;

namespace ComparingEngine
{
    public interface IDiffable<T> where T : IDiffable<T>
    {
        #region Public Methods

        IEnumerable<IDiff> DiffWith(T diffable);

        #endregion Public Methods
    }
}