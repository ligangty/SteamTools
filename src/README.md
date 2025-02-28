# Steam++ v3.X Source Code

### 🏗️ 项目结构
TODO
<!-- TODO
- Common **通用基础类库**
    - Common.AreaLib **地区数据**
    - Common.ClientLib **适用于客户端的通用基础类库**
    - Common.ClientLib.Droid **适用于 Android 的通用基础类库**
    - Common.ClientLib.iOS **适用于 iOS 的通用基础类库**
    - Common.CoreLib **全局通用基础类库**
    - Common.ServerLib **适用于服务端(AspNetCore)的通用基础类库**
    - Common.PinyinLib **汉字转拼音库**
    - Common.PinyinLib.CFStringTransform **仅适用于 iOS 平台，由 [CFStringTransform](https://developer.apple.com/documentation/corefoundation/1542411-cfstringtransform) 实现**
    - Common.PinyinLib.ChnCharInfo **由 Microsoft Visual Studio International Pack 1.0 中的 Simplified Chinese Pin-Yin Conversion Library（简体中文拼音转换类库）实现，多音字将返回首个拼音**
    - Common.PinyinLib.TinyPinyin **在 Android 上由 [TinyPinyin](https://github.com/promeG/TinyPinyin) 实现，其他平台由 [TinyPinyin.Net](https://github.com/hueifeng/TinyPinyin.Net) 实现**
    - Repositories.EFCore **EF Core 仓储层实现**
    - Repositories.sqlite-net-pcl **SQLite 仓储层实现**
    - Services.SmsSender **统一短信发送服务**
- Test **单元测试**
    - Common.UnitTest **通用基础类库的单元测试**
    - Common.UnitTest.Droid **适用于 Android 通用基础类库的单元测试**
        - Common.UnitTest.Droid.App **启动项**
- Lib **类库**
    - ST **业务通用类库**
    - ST.Client **客户端通用类库**
    - Bindings **平台原生绑定库**
    - Platforms
        - ST.Client.Windows **用于 Windows 的实现**
        - ST.Client.Mac **用于 macOS 的实现**
        - ST.Client.Linux **用于 GNU/Linux 的实现**
        - ST.Client.Android **用于 Android 的实现**
        - ST.Client.iOS **用于 iOS 的实现**
    - ResSecrets **使用资源存储的密钥**
    - UI Framework
        - ST.Client.Avalonia **使用 Avalonia 实现的 View 层**            
            - Avalonia.Ref **通过友元程序集调用内部函数或空程序集实现手动裁剪**
        - ~~ST.Client.WPF~~ **使用 Avalonia 实现的 WPF 层**
        - ~~ST.Client.WinUI~~ **使用 Avalonia 实现的 WinUI 层**
        - ST.Client.XamarinForms **使用 Xamarin.Forms/MAUI 实现的 View 层**
    - Web API
        - ST.Services.CloudService **客户端调用服务端 API 定义**
        - ST.Services.CloudService.Models **服务端 API 数据传输对象(DTO)定义**
        - ST.Services.CloudService.ViewModels **客户端视图模型**
- Tool **工具**
    - ST.Tools.AndroidResourceLink **将 Android Studio Project 中的 res 资源 Link 到 csproj 中(生成 XML)**
    - ST.Tools.AreaImport **从高德城市编码表 Excel 文件中导入地区数据**
    - ~~ST.Tools.DesktopBridgeLink~~ **Link DesktopBridge 打包中的内容，例如 CEF**
    - ~~ST.Tools.MinifyStaticSites~~ **用于将静态 html 删除空行缩小体积的命令行工具**
    - ST.Tools.OpenSourceLibraryList **开源许可协议清单生成工具**
        - 需要 [GitHub API Token](https://docs.github.com/en/github/authenticating-to-github/creating-a-personal-access-token)
    - ST.Tools.Packager **带进度的压缩与解压演示**
    - ~~ST.Tools.Packager.InstallerSetup~~ **安装程序**
    - ST.Tools.Publish **用于发布的控制台工具**
    - ST.Tools.Translate **Resx自动翻译工具**
        - 需要 [Azure Translation Key](https://azure.microsoft.com/zh-cn/services/cognitive-services/translator)
    - ~~ST.Tools.Win7Troubleshoot~~ **适用于 Windwos 7 OS 的 疑难解答助手**
        - 目标框架使用 .NET FX 3.5 并通过 App.config 配置 [supportedRuntime](https://docs.microsoft.com/zh-cn/dotnet/framework/configure-apps/file-schema/startup/supportedruntime-element) 允许在 4.X 中运行 实现在 Windows 上兼容所有的运行库环境
- Launch **启动项**
    - FDELauncher FDE(框架依赖) 启动器，判断运行时是否安装与提示，使用 .NET FX 3.5
    - ST.Client.Android.App **Android 客户端(Xamarin.Android)**
    - ST.Client.Android.App.Modern **Android 客户端(.NET 6+)**
    - ST.Client.Desktop.Avalonia.App **桌面客户端**
    - 5_DesktopBridge\ST.Client.Avalonia.App.Bridge.Package **[Desktop Bridge](https://docs.microsoft.com/zh-cn/windows/msix/desktop/desktop-to-uwp-packaging-dot-net)**
    - ST.Client.Avalonia.App.MsixPackage **桌面客户端[单项目 MSIX 打包](https://docs.microsoft.com/zh-cn/windows/apps/windows-app-sdk/single-project-msix?tabs=csharp)**
    - ~~ST.Client.Desktop.Avalonia.Demo.App~~ **桌面客户端(UI演示)**
    - ST.Client.Maui.App **MAUI 客户端**

### 🗂️ 命名空间/文件夹
- ~~中划线~~ 表示此文件夹下的命名空间使用上一级的值
- Properties
    - AssemblyInfo.cs **程序集信息**
    - InternalsVisibleTo.cs **指定 internal 对单元测试可见**
    - SR **本地化资源**
- ~~Extensions~~ **扩展函数静态类**
- Application **业务应用**
    - Columns **模型、实体列定义接口**
    - Converters **视图模型(VM)值绑定到视图(V)中的值转换器**
    - Data **EFCore DbContext**
    - Entities **ORM 表实体**
    - Filters **AspNetCore Mvc Filters**
    - Models **模型类**
    - Mvvm **MVVM 基础组件**
    - Repositories **仓储层**
    - UI
        - Assets **资源资产**
        - Styles **Xaml 样式**
        - Activities **Android 活动**
        - Adapters **Android 适配器**
        - Fragments **Android 片段**
        - ViewModels **视图模型**
        - Views **视图**
            - Controls **自定义控件**
            - Pages **页面**
            - Windows **窗口**
        - Resx **本地化资源**
    - Windows.winmd **Windows 10 UWP API 投影 Win32**
    - Resources **Android res、iOS BundleResource、其他嵌入的资源**
    - Security **应用安全**
    - Services **业务服务定义公开的接口或抽象类**
        - ~~Mvvm~~ **用于 MVVM 绑定的业务服务**
        - Implementation **业务服务的实现**
    - Serialization **业务相关的序列化、反序列化**
- Logging **日志自定义实现**
- ServiceCollectionExtensions.cs **DI 注册服务扩展类，命名空间统一使用**  
<pre>
// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
</pre>
-->

### 自定义 .NET Host 文档
- [编写自定义 .NET 主机以从本机代码控制 .NET 运行时](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/netcore-hosting)  
- [.NET 分发打包](https://learn.microsoft.com/zh-cn/dotnet/core/distribution-packaging)  
- [环境变量 - 指定 .NET 运行时的位置](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-environment-variables#dotnet_root-dotnet_rootx86)  

### 程序目录结构(Windows)
- dotnet 共享运行时，删除后将使用已安装的运行时，此目录参考 ```C:\Program Files\dotnet```，可自行升级运行库小版本号，二进制兼容
	- host
		- fxr
			- 7.0.x
				- hostfxr.dll
	- shared
		- Microsoft.AspNetCore.App
			- 7.0.x
		- Microsoft.NETCore.App
			- 7.0.x
- native
    - win-x64
        - 7z.dll
        - av_libglesv2.dll
        - e_sqlite3.dll
        - libHarfBuzzSharp.dll
        - libSkiaSharp.dll
        - WebView2Loader.dll
        - WinDivert.dll
        - WinDivert64.sys
- assemblies 主模块程序集
- modules 可选模块
    - Update 自更新模块，删除该文件夹后禁用更新
        - Steam++.Update.exe 更新程序，CDN 分发更新包，下载与解压在主程序中，此进程仅退出主程序执行覆盖操作
    - Accelerator 网络加速
        - Steam++.Accelerator.exe 控制台子服务进程，使用匿名管道与主进程通信，无参数或指定某个参数(待定)启动时可读取配置文件启动加速，可完全独立运行，ASP.NET Core Web API 项目，可支持 Docker
        - Steam++.Plugins.Accelerator.dll 插件程序集
    - AccountSwitch 账号切换
        - Steam++.Plugins.AccountSwitch.dll
    - ArchiSteamFarm
        - Steam++.ArchiSteamFarm.exe
        - Steam++.Plugins.ArchiSteamFarm.dll
    - GameList 库存游戏
        - Steam++.Plugins.GameList.dll
    - LocalAuth 本地令牌
        - Steam++.Plugins.LocalAuth.dll
    - GameTools 游戏工具
        - Steam++.Plugins.GameTools.dll
- Steam++.exe .NET Framework 二进制主程序  
- Steam++.exe.config 使用该配置文件以允许在 .NET Framework 3.5 ~ 4.8.1 中任意版本中兼容运行(从 Windows 7 ~ 11 中所有系统自带运行时)  
- Steam++.Uninstall.exe 卸载程序(WinForms?AOT?)  

### 程序目录结构(Linux)
- Steam++ 本机二进制主程序  
- libe_sqlite3.so  
- libHarfBuzzSharp.so  
- libSkiaSharp.so  
- native
    - linux-x64
        - TODO?
- modules 可选模块
    - TODO
```
改成 Windows 的目录结构，但在 AOT 的 AppHost 中无法加载已使用框架依赖发布的程序集，错误 Initialization for self-contained components is not supported
参考  
https://github.com/dotnet/runtime/issues/35329  
https://github.com/dotnet/runtime/search?l=C%2B%2B&q=get_is_framework_dependent  
https://github.com/dotnet/runtime/blob/6702dc5c7814e624a42ab4615224920a5635beeb/src/native/corehost/runtime_config.cpp  
https://github.com/dotnet/runtime/blob/main/docs/design/features/host-error-codes.md  
https://github.com/dotnet/samples/blob/91355ef22a10ec614a2e8daefd68785066860d57/core/hosting/src/NativeHost/nativehost.cpp  
```

### 程序目录结构(macOS)
- Steam++.app  
    - Contents  
        - Info.plist 
        - MacOS  
            - Steam++ 本机二进制主程序  
        - MonoBundle  
            - Steam++.Accelerator.X64 网络加速控制台子服务进程二进制程序  
            - Steam++.Accelerator.Arm64   
        - PkgInfo  
        - Resources  

对子服务进程二进制程序的 RID 使用 ```RuntimeInformation.ProcessArchitecture.ToString()```  
通过 ```PublishFolderType="Assembly"``` 指定 Copy 到 MonoBundle 中，没有其他选项能够将其放在 MacOS 文件夹中

### 应用分发(安装包程序方案)
- Steam 软件商店
    - 待上架
    - 对接 API 加入 CI/CD 自动化
- Windows
    - 应用商店分发受限于网络情况，一些用户连不上 Microsoft Store，比如应用商店显示错误 ```我们这边出了错 0x80240438```😅
    - msix 格式不够简单方便  
    - msi 格式在小部分用户设备上会因权限问题导致 2502/2503 错误  
    - NSIS 现使用的自定义方面不够好
    - exe 单文件 Setup.exe 最合适，使用 net4.0 WinForms Or net8 WinForms AOT? UI 可参考 .NET Runtime 安装界面  
        - UI 多语言支持
        - 注册表写入软件信息
        - 7z 解压程序文件(进度条)
- Linux
    - tar.zst 压缩包
    - deb Debian 软件包
    - rpm RPM 包
- macOS
    - dmg 磁盘镜像安装包
- iOS
    - AppStore
        - 待上架
        - 对接 API 加入 CI/CD 自动化
- Android
    - Google Play 
        - 待上架
    - 酷安
        - 待上架
    - 手机厂商应用商店
        - TODO

### 📁 存储空间
- AppData
    - Microsoft Store ```%USERPROFILE%\AppData\Local\Packages\4651ED44255E.47979655102CE_k6txddmbb6c52\LocalState```
    - Windows ```\AppData``` or ```%LocalAppData%\Steam++```
    - macOS ```~/Library/Steam++```
    - Linux ```$XDG_DATA_HOME/Steam++``` or ```$HOME/.local/share/Steam++```
    - Android ```/data/data/net.steampp.app/files```
- Cache
    - Microsoft Store ```%USERPROFILE%\AppData\Local\Packages\4651ED44255E.47979655102CE_k6txddmbb6c52\LocalCache```
    - Windows ```\Cache``` or ```%Tmp%\Steam++```
    - macOS ```~/Library/Caches/Steam++```
    - Linux ```$XDG_CACHE_HOME/Steam++``` or ```$HOME/.cache/Steam++```
    - Android ```/data/data/net.steampp.app/cache```
- Logs
    - Microsoft Store ```%USERPROFILE%\AppData\Local\Packages\4651ED44255E.47979655102CE_k6txddmbb6c52\LocalCache\Logs```
    - Windows ```\Logs``` or ```%Tmp%\Steam++\Logs```
    - macOS ```~/Library/Caches/Steam++/Logs```
    - Linux ```$XDG_CACHE_HOME/Steam++/Logs``` or ```$HOME/.cache/Steam++/Logs```
    - Android ```/data/data/net.steampp.app/cache/Logs```