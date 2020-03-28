using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Models
{
    public class Response
    {
        /// <summary>
        /// Segir hvort aðgerð tókst eða ekki.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Almenn skilaboð frá aðgerð.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Villuskilaboð, ef við á.
        /// </summary>
        public string Error { get; set; }

        public Response() { }

        public Response(string message)
        {
            Success = true;
            Message = message;
        }

        public Response(string message, string error)
        {
            Success = false;
            Message = message;
            Error = error;
        }
    }

    public class Response<T> : Response
    {
        public T Item { get; set; }

        public Response(string message, T item) : base(message)
        {
            Item = item;
        }

        public Response(string message, string error) : base(message, error) { }
    }
}
