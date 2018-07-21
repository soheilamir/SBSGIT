﻿using System;
using log4net;

namespace SBSWebProject.Common.Logging
{
    public interface ILogManager
    {
        ILog GetLog(Type typeAssociatedWithRequestedLog);
    }
}
