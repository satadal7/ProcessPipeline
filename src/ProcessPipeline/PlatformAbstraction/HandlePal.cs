// Copyright 2018 @asmichi (on github). Licensed under the MIT License. See LICENCE in the project root for details.

using System;
using Microsoft.Win32.SafeHandles;

namespace Asmichi.Utilities.PlatformAbstraction
{
    internal static class HandlePal
    {
        public static SafeWaitHandle ToWaitHandle(SafeProcessHandle handle)
        {
            switch (Pal.PlatformKind)
            {
                case PlatformKind.Win32:
                    return Windows.HandlePalWindows.ToWaitHandle(handle);
                case PlatformKind.Linux:
                    return Linux.HandlePalLinux.ToWaitHandle(handle);
                case PlatformKind.Unknown:
                default:
                    throw new PlatformNotSupportedException();
            }
        }
    }
}
