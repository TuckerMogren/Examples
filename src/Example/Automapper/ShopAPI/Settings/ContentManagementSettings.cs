﻿using System;
using System.Diagnostics.CodeAnalysis;
using Domain.Interfaces.Settings;

namespace ShopAPI.Settings
{
    [ExcludeFromCodeCoverage]
    public class ContentManagementSettings : IContentManagementSettings
    {
        public string Uri { get; set; }
    }
}

