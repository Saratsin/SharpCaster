using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SharpCaster.Models;

namespace SharpCaster.Services
{
    public class ChromecastService
    {
        private static readonly Lazy<ChromecastService> _current = new Lazy<ChromecastService>(() => new ChromecastService());
        public static ChromecastService Current => _current.Value;

        public DeviceLocator DeviceLocator { get; }
        public ChromeCastClient ChromeCastClient { get; }
        public Chromecast ConnectedChromecast { get; set; }

        public ChromecastService()
        {
            DeviceLocator = new DeviceLocator();
            ChromeCastClient = new ChromeCastClient();
        }

  
        public Task ConnectToChromecast(Chromecast chromecast)
        {
            ConnectedChromecast = chromecast;
            return ChromeCastClient.ConnectChromecast(chromecast.DeviceUri);
        }
        

        public Task<ObservableCollection<Chromecast>> StartLocatingDevices()
        {
            return DeviceLocator.LocateDevicesAsync();
        }

        public Task<ObservableCollection<Chromecast>> StartLocatingDevices(string localIpAdress)
        {
            return DeviceLocator.LocateDevicesAsync(localIpAdress);
        }
    }
}