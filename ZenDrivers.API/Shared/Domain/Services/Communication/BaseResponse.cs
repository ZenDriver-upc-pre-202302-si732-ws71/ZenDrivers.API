﻿namespace ZenDrivers.API.Shared.Domain.Services.Communication
{
    public class BaseResponse<T>
    {
        protected BaseResponse(string message)
        {
            Success = false;
            Message = message;
            Resource = default!;
        }

        protected BaseResponse(T resource)
        {
            Success = true;
            Message = string.Empty;
            Resource = resource;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public T Resource { get; set; }
        
        public static BaseResponse<T> Of(string message)
        {
            return new BaseResponse<T>(message);
        }
        public static BaseResponse<T> Of(T entity)
        {
            return new BaseResponse<T>(entity);
        }
    }
}
