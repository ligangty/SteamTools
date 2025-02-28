#pragma warning disable IDE0079 // 请删除不必要的忽略
#pragma warning disable SA1634 // File header should show copyright
// <console-tools-generated/>
#pragma warning restore SA1634 // File header should show copyright
#pragma warning restore IDE0079 // 请删除不必要的忽略
using static BD.WTTS.Settings.Abstractions.IGeneralSettings;

// ReSharper disable once CheckNamespace
namespace BD.WTTS.Settings;

[JsonSourceGenerationOptions(WriteIndented = true, IgnoreReadOnlyProperties = true)]
[JsonSerializable(typeof(GeneralSettings_))]
internal partial class GeneralSettingsContext : JsonSerializerContext
{
    static GeneralSettingsContext? instance;

    public static GeneralSettingsContext Instance
        => instance ??= new GeneralSettingsContext(ISettings.GetDefaultOptions());
}

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class GeneralSettings_ : IGeneralSettings, ISettings, ISettings<GeneralSettings_>
{
    public const string Name = nameof(GeneralSettings);

    static string ISettings.Name => Name;

    static JsonSerializerContext ISettings.JsonSerializerContext
        => GeneralSettingsContext.Instance;

    static JsonTypeInfo ISettings.JsonTypeInfo
        => GeneralSettingsContext.Instance.GeneralSettings_;

    static JsonTypeInfo<GeneralSettings_> ISettings<GeneralSettings_>.JsonTypeInfo
        => GeneralSettingsContext.Instance.GeneralSettings_;

    /// <summary>
    /// 自动检查应用更新
    /// </summary>
    [MPKey(0), MP2Key(0), JsonPropertyOrder(0)]
    public bool? AutoCheckAppUpdate { get; set; }

    /// <summary>
    /// 选择下载更新渠道
    /// </summary>
    [MPKey(1), MP2Key(1), JsonPropertyOrder(1)]
    public UpdateChannelType? UpdateChannel { get; set; }

    /// <summary>
    /// 开机自启动
    /// </summary>
    [MPKey(2), MP2Key(2), JsonPropertyOrder(2)]
    public bool? AutoRunOnStartup { get; set; }

    /// <summary>
    /// 启动时最小化
    /// </summary>
    [MPKey(3), MP2Key(3), JsonPropertyOrder(3)]
    public bool? MinimizeOnStartup { get; set; }

    /// <summary>
    /// 启用托盘图标
    /// </summary>
    [MPKey(4), MP2Key(4), JsonPropertyOrder(4)]
    public bool? TrayIcon { get; set; }

    /// <summary>
    /// 游戏列表使用本地缓存
    /// </summary>
    [MPKey(5), MP2Key(5), JsonPropertyOrder(5)]
    public bool? GameListUseLocalCache { get; set; }

    /// <summary>
    /// 文本阅读器提供商，值为程序路径
    /// </summary>
    [MPKey(6), MP2Key(6), JsonPropertyOrder(6)]
    public Dictionary<Platform, string>? TextReaderProvider { get; set; }

    /// <summary>
    /// Hosts 文件编码类型
    /// </summary>
    [MPKey(7), MP2Key(7), JsonPropertyOrder(7)]
    public EncodingType? HostsFileEncodingType { get; set; }

    /// <summary>
    /// 是否使用硬件加速
    /// </summary>
    [MPKey(8), MP2Key(8), JsonPropertyOrder(8)]
    public bool? GPU { get; set; }

    /// <summary>
    /// 使用本机 OpenGL
    /// </summary>
    [MPKey(9), MP2Key(9), JsonPropertyOrder(9)]
    public bool? NativeOpenGL { get; set; }

    /// <summary>
    /// 屏幕捕获/允许截图，在一些含有机密的页面上是否允许截图，默认为 <see langword="false"/>
    /// </summary>
    [MPKey(10), MP2Key(10), JsonPropertyOrder(10)]
    public bool? ScreenCapture { get; set; }

}

public static partial class GeneralSettings
{
    /// <summary>
    /// 自动检查应用更新
    /// </summary>
    public static SettingsStructProperty<bool, GeneralSettings_> AutoCheckAppUpdate { get; }
        = new(DefaultAutoCheckAppUpdate);

    /// <summary>
    /// 选择下载更新渠道
    /// </summary>
    public static SettingsStructProperty<UpdateChannelType, GeneralSettings_> UpdateChannel { get; }
        = new(DefaultUpdateChannel);

    /// <summary>
    /// 开机自启动
    /// </summary>
    public static SettingsStructProperty<bool, GeneralSettings_> AutoRunOnStartup { get; }
        = new(DefaultAutoRunOnStartup);

    /// <summary>
    /// 启动时最小化
    /// </summary>
    public static SettingsStructProperty<bool, GeneralSettings_> MinimizeOnStartup { get; }
        = new(DefaultMinimizeOnStartup);

    /// <summary>
    /// 启用托盘图标
    /// </summary>
    public static SettingsStructProperty<bool, GeneralSettings_> TrayIcon { get; }
        = new(DefaultTrayIcon);

    /// <summary>
    /// 游戏列表使用本地缓存
    /// </summary>
    public static SettingsStructProperty<bool, GeneralSettings_> GameListUseLocalCache { get; }
        = new(DefaultGameListUseLocalCache);

    /// <summary>
    /// 文本阅读器提供商，值为程序路径
    /// </summary>
    public static SettingsProperty<Platform, string, Dictionary<Platform, string>, GeneralSettings_> TextReaderProvider { get; }
        = new(DefaultTextReaderProvider);

    /// <summary>
    /// Hosts 文件编码类型
    /// </summary>
    public static SettingsStructProperty<EncodingType, GeneralSettings_> HostsFileEncodingType { get; }
        = new(DefaultHostsFileEncodingType);

    /// <summary>
    /// 是否使用硬件加速
    /// </summary>
    public static SettingsStructProperty<bool, GeneralSettings_> GPU { get; }
        = new(DefaultGPU);

    /// <summary>
    /// 使用本机 OpenGL
    /// </summary>
    public static SettingsStructProperty<bool, GeneralSettings_> NativeOpenGL { get; }
        = new(DefaultNativeOpenGL);

    /// <summary>
    /// 屏幕捕获/允许截图，在一些含有机密的页面上是否允许截图，默认为 <see langword="false"/>
    /// </summary>
    public static SettingsStructProperty<bool, GeneralSettings_> ScreenCapture { get; }
        = new(DefaultScreenCapture);

}
