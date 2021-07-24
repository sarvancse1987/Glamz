using System.Collections.Generic;

namespace Glamz.Domain.Localization
{
    /// <summary>
    /// Represents a translation entity
    /// </summary>
    public interface ITranslationEntity
    {
        IList<TranslationEntity> Locales { get; set; }
    }
}
