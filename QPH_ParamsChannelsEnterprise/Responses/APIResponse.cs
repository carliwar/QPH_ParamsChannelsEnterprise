﻿using QPH_ParamsChannelsEnterprise.Core.CustomEntities;

namespace QPH_ParamsChannelsEnterprise.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Metadata Meta { get; set; }
    }
}
