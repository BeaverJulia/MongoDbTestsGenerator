﻿namespace BlackRose.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Pictures
        {
            public const string GetAll = Base + "/picture/GetAll";
            public const string Create = Base + "/picture";
            public const string Delete = Base + "/picture/delete";
            public const string Get = Base + "/picture/{pictureId}";
        }
        public static class Identity
        {
            public const string Login = Base + "/identity/login";
            public const string Register = Base + "/identity/register";

        }
    }
}