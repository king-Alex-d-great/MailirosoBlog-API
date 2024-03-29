﻿using Newtonsoft.Json;

namespace MalirosoBlog.Services.Infrastructure
{
    public class SuccessResponse
    {
        public bool Success { get; set; }
        public object Data { get; set; }
    }

    public enum ResponseStatus
    {
        OK = 1,
        APP_ERROR = 2,
        FATAL_ERROR = 3,
        NOT_FOUND = 4,
        UNAUTHORIZED = 5
    }

    public class ErrorResponse
    {
        public ResponseStatus Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
