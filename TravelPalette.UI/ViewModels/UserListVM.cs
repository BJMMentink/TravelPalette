using TravelPalette.BL;
using TravelPalette.BL.Models;

namespace TravelPalette.UI.ViewModels
{
    public class UserListVM
    {
        public User User { get; set; }
        public UserList UserList { get; set; }

        public UserListVM(int userId)
        {
            User = UserManager.LoadById(userId);
            UserList = new UserList();
        }  
    }
}
