using ComparingEngine;
using EiwmModel.Base;
using System.Collections.Generic;

namespace EiwmModel.Comparable
{
    public class AssociationDiffable : AssociationEiwm, IDiffable<AssociationDiffable>
    {
        #region Public Methods

        public IEnumerable<IDiff> DiffWith(AssociationDiffable diffable)
        {
            if (!ClassId.Equals(diffable.ClassId))
                yield return new Diff<string>("", ClassId, diffable.ClassId);

            if (!Type.Equals(diffable.Type))
                yield return new Diff<string>("", Type, diffable.Type);

            //if (Object.Equals(diffable.Object))
            //    yield return new Diff<ObjectDiffable>("", Object, diffable.Object);
        }

        #endregion Public Methods
    }
}