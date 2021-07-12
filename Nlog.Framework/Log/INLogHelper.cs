using System;
using System.Collections.Generic;
using System.Text;

namespace Nlog.Framework.Log
{
    public interface INLogHelper
    {
        void LogError(LogMessage logMessage);
    }
}
