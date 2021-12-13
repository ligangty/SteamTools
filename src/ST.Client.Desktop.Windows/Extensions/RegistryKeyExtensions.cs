using Microsoft.Win32;
using System.Runtime.Versioning;

// ReSharper disable once CheckNamespace
namespace System
{
#if NET5_0_OR_GREATER
    [SupportedOSPlatform("Windows7.0")]
#endif
    public static class RegistryKeyExtensions
    {
        /// <summary>
        /// 读取注册表值
        /// </summary>
        /// <param name="registryKey"></param>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string Read(this RegistryKey registryKey, string path, string name)
        {
            var rk = registryKey.OpenSubKey(path);
            if (rk != null)
            {
                var value = rk.GetValue(name)?.ToString();
                rk.Close();
                return value ?? string.Empty;
            }
            return string.Empty;
        }

        /// <summary>
        /// 新增或修改注册表值
        /// </summary>
        /// <param name="registryKey"></param>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="valueKind"></param>
        public static void AddOrUpdate(this RegistryKey registryKey, string path, string name, string value, RegistryValueKind valueKind)
        {
            var rk = registryKey.OpenSubKey(path, true);
            if (rk != null) // 该项必须已存在
            {
                rk.SetValue(name, value, valueKind);
                rk.Close();
            }
        }
    }
}