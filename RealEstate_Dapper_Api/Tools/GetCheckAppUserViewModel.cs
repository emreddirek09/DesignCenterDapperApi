﻿namespace RealEstate_Dapper_Api.Tools
{
    public class GetCheckAppUserViewModel
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public bool IsExsist { get; set; }
    }
}
