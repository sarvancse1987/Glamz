﻿using System.Threading.Tasks;

namespace Glamz.Business.Common.Interfaces.Directory
{
    public interface IConsentCookie
    {
        string SystemName { get; }
        bool AllowToDisable { get; }
        bool? DefaultState { get; }
        int DisplayOrder { get; }
        Task<string> Name();
        Task<string> FullDescription();
    }
}
