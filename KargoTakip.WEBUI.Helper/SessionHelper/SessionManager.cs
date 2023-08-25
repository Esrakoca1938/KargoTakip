using KargoTakip.Core.DTO;
using Microsoft.AspNetCore.Http;


namespace KargoTakip.WebUI.Helper.SessionHelper
{
    public class SessionManager
    {
      
        public static LoginDto? LoggedUser 
        {
            get => AppHttpContext.Current.Session.GetObject<LoginDto>("LoginDTO");
            set => AppHttpContext.Current.Session.SetObject("LoginDTO", value);
        }

       
    }
}
