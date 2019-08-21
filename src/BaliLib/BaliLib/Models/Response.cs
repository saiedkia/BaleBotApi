using System;

namespace BaleLib.Models
{
    public class Response
    {
        public bool Ok { get; set; }
        public int Errorcode { get; set; }
        public string Description { get; set; }
        public Result Result { get; set; }
    }


    public class Response<T>
    {
        public bool Ok { get; set; }
        public int ErrorCode { get; set; }
        public string Description { get; set; }
        public T Result { get; set; }
    }
}
