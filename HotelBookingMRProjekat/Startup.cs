using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelBookingMRProjekat.Startup))]
namespace HotelBookingMRProjekat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
