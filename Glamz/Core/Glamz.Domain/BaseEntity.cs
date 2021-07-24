using Glamz.Domain.Common;
using System.Collections.Generic;

namespace Glamz.Domain
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract partial class BaseEntity : ParentEntity
    {
        protected BaseEntity()
        {
            UserFields = new List<UserField>();
        }

        public IList<UserField> UserFields { get; set; }

    }
}
