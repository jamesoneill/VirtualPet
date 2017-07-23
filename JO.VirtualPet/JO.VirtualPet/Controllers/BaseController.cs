using JO.Core.Services;
using JO.Data;
using JO.VirtualPet.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
