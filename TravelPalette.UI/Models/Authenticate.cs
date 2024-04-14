using TravelPalette.BL.Models;
using TravelPalette.UI.Extensions;
using TravelPalette.UI.Models;

namespace TravelPalette.UI.Models
{
    public static class Authenticate
    {
        public static bool IsAuthenticated(HttpContext context)
        {
            if (context.Session.GetObject<User>("user") != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
