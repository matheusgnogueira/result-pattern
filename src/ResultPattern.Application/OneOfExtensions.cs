﻿using OneOf;
using ResultPattern.Application.Error;

namespace ResultPattern.Application
{
    public static class OneOfExtensions
    {
        public static bool IsSuccess<TResult>(this OneOf<TResult, AppError> obj) => obj.IsT0;
        public static TResult GetSuccessResult<TResult>(this OneOf<TResult, AppError> obj) => obj.AsT0;
        public static bool IsError<TResult>(this OneOf<TResult, AppError> obj) => obj.IsT1;
        public static AppError GetError<TResult>(this OneOf<TResult, AppError> obj) => obj.AsT1;
    }
}
