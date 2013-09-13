using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Responses;

namespace permute.me {

    public class IndexModule : NancyModule {

        public IndexModule() {
            Get["/"] = _ => new RedirectResponse("/Content/html/site.html");
        }

    }
}