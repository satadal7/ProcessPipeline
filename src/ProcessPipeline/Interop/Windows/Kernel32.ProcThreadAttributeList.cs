// Copyright 2018 @asmichi (on github). Licensed under the MIT License. See LICENCE in the project root for details.

using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1310 // Field names must not contain underscore
#pragma warning disable SA1313 // Parameter names must begin with lower-case letter

namespace Asmichi.Utilities.Interop.Windows
{
    internal static partial class Kernel32
    {
        public static readonly IntPtr PROC_THREAD_ATTRIBUTE_HANDLE_LIST = new IntPtr(0x20002);

        [DllImport(DllName, SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public static extern bool InitializeProcThreadAttributeList(
            [In] IntPtr lpAttributeList,
            [In] int dwAttributeCount,
            [In] int dwFlags,
            [In][Out] ref IntPtr lpSize);

        [DllImport(DllName, SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static extern void DeleteProcThreadAttributeList(
            [In] IntPtr lpAttributeList);

        [DllImport(DllName, SetLastError = true)]
        public static extern unsafe bool UpdateProcThreadAttribute(
            [In] SafeUnmanagedProcThreadAttributeList lpAttributeList,
            [In] int dwFlags,
            [In] IntPtr Attribute,
            [In] void* lpValue,
            [In] IntPtr cbSize,
            [In] IntPtr lpPreviousValue,
            [In] IntPtr lpReturnSize);
    }
}
