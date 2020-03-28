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

        /// <summary>
        /// Býr til jákvætt Response.
        /// </summary>
        /// <param name="message">Almenn skilaboð frá aðgerð.</param>
        public Response(string message)
        {
            Success = true;
            Message = message;
        }

        /// <summary>
        /// Býr til neikvætt Response.
        /// </summary>
        /// <param name="message">Almenn skilaboð frá aðgerð.</param>
        /// <param name="error">Villulýsing</param>
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

        /// <summary>
        /// Býr til jákvætt Response.
        /// </summary>
        /// <param name="message">Almenn skilaboð frá aðgerð.</param>
        /// <param name="item">Villulýsing</param>
        public Response(string message, T item) : base(message)
        {
            Item = item;
        }

        /// <summary>
        /// Býr til neikvætt Response.
        /// </summary>
        /// <param name="message">Almenn skilaboð frá aðgerð.</param>
        /// <param name="error">Villulýsing</param>
        public Response(string message, string error) : base(message, error) { }
    }
}
