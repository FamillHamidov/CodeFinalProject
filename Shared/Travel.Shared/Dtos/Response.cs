using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Travel.Shared.Dtos
{
    public class Response<T>
    {
        public T Data { get;private set; }
        [JsonIgnore]
        public int StatucCode { get;private set; }
        [JsonIgnore]
        public bool IsSuccessful{ get;private set; }
        public List<string> Errors { get;  set; }
        public static Response<T> Success(T data, int statucCode)
        {
            return new Response<T> { Data = data, StatucCode = statucCode, IsSuccessful = true };
        }
        public static Response<T> Success(int statucCode)
        {
            return new Response<T> { Data = default(T), IsSuccessful = true, StatucCode = statucCode };
        }
        public static Response<T> Fail(List<string> errors, int statusCode)
        {
            return new Response<T> { Errors = errors, StatucCode = statusCode, IsSuccessful = false };
        }
        public static Response<T> Fail(string error, int statusCode)
        {
            return new Response<T> { Errors=new List<string>() { error }, StatucCode=statusCode, IsSuccessful = false };
        }
    }
}
