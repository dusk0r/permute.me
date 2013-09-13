using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace permute.me {
    public class NancyBootstrapper : DefaultNancyBootstrapper {

        protected override void ConfigureConventions(Nancy.Conventions.NancyConventions nancyConventions) {
            //nancyConventions.StaticContentsConventions.Add(Nancy.Conventions.StaticContentConventionBuilder.AddDirectory("/Content"));
            nancyConventions.StaticContentsConventions.Add(Nancy.Conventions.StaticContentConventionBuilder.AddDirectory("/Scripts"));
            base.ConfigureConventions(nancyConventions);
        }
    }
}