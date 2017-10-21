using System;

namespace ModernEncryption.Utils
{
    internal class TimeManagement
    {
        public static int UnixTimestampNow => (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
    }
}
