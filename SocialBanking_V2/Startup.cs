﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialBanking_V2.Startup))]
namespace SocialBanking_V2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
