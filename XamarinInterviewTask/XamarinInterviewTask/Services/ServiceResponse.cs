﻿using System;
namespace XamarinInterviewTask.Services
{
    public class ServiceResponse<T> : ResponseBase
    {
        public T Data { get; set; }

    }
}