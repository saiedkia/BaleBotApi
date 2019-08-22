using BaleLib.Models.Parameters;
using System;

namespace BaleLib.Models
{
    public class Response
    {
        public bool Ok { get; set; }
        public int Errorcode { get; set; }
        public string Description { get; set; }
        public Result Result { get; set; }

        public static Response CreateInstance<T>(string description)
        {
            if (typeof(T) == typeof(VoidType))
                return new Response() { Description = description };
            else
                return new Response<T>() { Description = description };
        }
    }


    public class Response<T> : Response
    {
        //public bool Ok { get; set; }
        //public int ErrorCode { get; set; }
        //public string Description { get; set; }
        public new T Result { get; set; }
    }
}
