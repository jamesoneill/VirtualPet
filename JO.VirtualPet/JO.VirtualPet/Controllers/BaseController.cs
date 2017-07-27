using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace JO.VirtualPet.Controllers
{
    public class BaseController : Controller
    {
        internal List<string> GetErrors(Exception ex, List<string> errors)
        {
            errors.Add(ex.Message);

            if (ex.InnerException != null)
            {
                return GetErrors(ex.InnerException , errors);
            }

            return errors;
        }
    }
}
