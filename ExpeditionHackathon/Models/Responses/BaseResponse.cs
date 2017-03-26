using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpeditionHackathon.Models.Responses
{
    public abstract class BaseResponse
    {
        public bool IsSuccessful { get; set; }

    }
}