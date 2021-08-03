using System.Application.Models;
using System.Application.Services;
using System.Application.Services.CloudService;
using System.Application.UI.Resx;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.WebSocket;
using System.Net.WebSocket.EventArgs;
using System.Windows;
using System.Security.Cryptography;

namespace System.Application.UI.ViewModels
{
    partial class LoginOrRegisterWindowViewModel : WindowViewModel
    {
        ServerWebSocket? server;
        static int port;
        static Aes? aes;
        public override void Activation()
        {
            if (IsFirstActivation)
            {
                server = new ServerWebSocket("127.0.0.1", out port);
                server.OnClientReceived += Handle;
                server.Start();
            }
            base.Activation();
        }
        public static bool IsBind { get; set; } = false;
        public static FastLoginChannel Channel { get; set; }
        public async Task Handle(ReceivedEventArgs msg)
        { 
            var response = ApiResponse.Deserialize<LoginOrRegisterResponse>(aes.Decrypt(msg.Message.Base64UrlDecodeToByteArray()));
            var retResponse = new LoginWebSocket();
            if (response.IsSuccess && response.Content == null)
            {
                //retResponse.Msg = AppResources.UserChange_NoUserTip;
                await msg.Client.WriteAsync(retResponse);
                return;

            }
            var conn_helper = DI.Get<IApiConnectionPlatformHelper>();
            if (response.IsSuccess)
            {
                retResponse.State = true;
                if (IsBind)
                {
                    await MainThread2.InvokeOnMainThreadAsync(async () =>
                    {
                        await UserService.Current.BindAccountAfterUpdateAsync(Channel, response.Content!);
                        var msg = AppResources.Success_.Format(AppResources.User_AccountBind);
                        Toast.Show(msg);
                        Close?.Invoke();
                    });
                }
                else
                {
                    await conn_helper.OnLoginedAsync(response.Content!, response.Content!);
                    await MainThread2.InvokeOnMainThreadAsync(async () =>
                    {
                        await SuccessAsync(response.Content!);
                        Close?.Invoke();
                    });
                }
                await msg.Client.WriteAsync(retResponse);
                //登录完成释放
                server!.Dispose();
                return;
            }
            else
            {
                MainThread2.BeginInvokeOnMainThread(() =>
                {
                    conn_helper.ShowResponseErrorMessage(response);
                });
            }
            await msg.Client.WriteAsync(retResponse);

        }
        internal static Task FastLoginOrRegisterAsync(Action? close = null, FastLoginChannel channel = FastLoginChannel.Steam, bool isBind = false)
        {
            var conn_helper = DI.Get<IApiConnectionPlatformHelper>();
            var apiBaseUrl = "https://127.0.0.1:28110"; //ICloudServiceClient.Instance.ApiBaseUrl;
            if (aes == null)
                aes = AESUtils.Create();
            var skey_bytes = aes.ToParamsByteArray();
            var skey_str = conn_helper.RSA.EncryptToString(skey_bytes);
            var sc = DI.Get<CloudServiceClientBase>();
            var url = apiBaseUrl +
                 (channel == FastLoginChannel.Steam ?
                 "/ExternalLoginDetection" : $"/ExternalLoginDetection/{(int)channel}") + $"?websocket=true&port={port}&sKey={skey_str}&Version={sc.Settings.AppVersionStr}" +
                 (isBind ? "&isBind=true" : string.Empty);
            IsBind = isBind;
            Channel = channel;
            Services.CloudService.Constants.BrowserOpen(url);



            //if (!AppHelper.IsSystemWebViewAvailable) return;
            ////var apiBaseUrl = ICloudServiceClient.Instance.ApiBaseUrl;
            //var urlExternalLoginCallback = apiBaseUrl + "/ExternalLoginCallback";
            //WebView3WindowViewModel? vm = null;
            //vm = new WebView3WindowViewModel
            //{
            //    Url = apiBaseUrl +
            //        (channel == FastLoginChannel.Steam ?
            //        "/ExternalLogin" :
            //        $"/ExternalLogin/{(int)channel}") +
            //        (isBind ?
            //        "?isBind=true" :
            //        string.Empty),
            //    StreamResponseFilterUrls = new[]
            //    {
            //        urlExternalLoginCallback,
            //    },
            //    OnStreamResponseFilterResourceLoadComplete = _OnStreamResponseFilterResourceLoadComplete,
            //    FixedSinglePage = true,
            //    Title = AppResources.User_FastLogin_.Format(channel),
            //    TimeoutErrorMessage = channel == FastLoginChannel.Steam ? AppResources.User_SteamFastLoginTimeoutErrorMessage : null,
            //    IsSecurity = true,
            //    UseLoginUsingSteamClient = channel == FastLoginChannel.Steam,
            //    Close = close,
            //};
            //async void _OnStreamResponseFilterResourceLoadComplete(string url, Stream data)
            //{
            //    if (url.StartsWith(urlExternalLoginCallback, StringComparison.OrdinalIgnoreCase))
            //    {
            //        var response = await ApiResponse.DeserializeAsync<LoginOrRegisterResponse>(data, default);
            //        if (response.IsSuccess && response.Content == null)
            //        {
            //            response.Code = ApiResponseCode.NoResponseContent;
            //        }
            //        var conn_helper = DI.Get<IApiConnectionPlatformHelper>();
            //        if (response.IsSuccess)
            //        {
            //            if (isBind)
            //            {
            //                await MainThread2.InvokeOnMainThreadAsync(async () =>
            //                {
            //                    await UserService.Current.BindAccountAfterUpdateAsync(channel, response.Content!);
            //                    vm?.Close?.Invoke();
            //                    var msg = AppResources.Success_.Format(AppResources.User_AccountBind);
            //                    Toast.Show(msg);
            //                });
            //            }
            //            else
            //            {
            //                await conn_helper.OnLoginedAsync(response.Content!, response.Content!);
            //                await MainThread2.InvokeOnMainThreadAsync(async () =>
            //                {
            //                    await SuccessAsync(response.Content!, vm?.Close);
            //                });
            //            }
            //        }
            //        else
            //        {
            //            MainThread2.BeginInvokeOnMainThread(() =>
            //            {
            //                vm?.Close?.Invoke();
            //                conn_helper.ShowResponseErrorMessage(response);
            //            });
            //        }
            //    }
            //}
            //await IShowWindowService.Instance.Show(CustomWindow.WebView3, vm,
            //    resizeMode: ResizeModeCompat.CanResize,
            //    isDialog: true // 锁定父窗口，防止打开多个 WebViewWindow
            //    );
        }

        internal Task GoToLoginOrRegisterByPhoneNumberAsync()
        {
            LoginState = 1;
            return Task.CompletedTask;
        }
    }
}