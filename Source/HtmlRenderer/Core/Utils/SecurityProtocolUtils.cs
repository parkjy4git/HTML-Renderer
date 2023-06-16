using System;
using System.Net;

namespace TheArtOfDev.HtmlRenderer.Core.Utils
{
    public static class SecurityProtocolUtils
    {
        private const SecurityProtocolType Tls12 = (SecurityProtocolType)3072;

        /// <summary>
        /// Platform의 TLS1.2 지원 여부
        /// </summary>
        public static bool SupportsTls12 { get; }

        static SecurityProtocolUtils()
        {
            SupportsTls12 = CheckIfPlatformSupportsTls12();
        }

        private static bool CheckIfPlatformSupportsTls12()
        {
            foreach (SecurityProtocolType protocol in Enum.GetValues(typeof(SecurityProtocolType)))
            {
                if (protocol.GetHashCode() == (int)Tls12)
                {
                    return true;
                }
            }

            return false;
        }

        public static void SetTls12()
        {
            // enable Tls12, if possible
            if (!ServicePointManager.SecurityProtocol.HasFlag(Tls12))
            {
                if (SupportsTls12)
                {
                    ServicePointManager.SecurityProtocol |= Tls12;
                }
            }
        }

    }
}
