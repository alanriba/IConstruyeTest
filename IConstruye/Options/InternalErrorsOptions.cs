using System;
using System.Diagnostics.CodeAnalysis;

namespace IConstruye.Api.Options
{
    [ExcludeFromCodeCoverage]
    public class InternalErrorsOptions
    {
        public const string SettingName = "InternalErrors";

        public bool Hidden { get; set; }
    }
}

