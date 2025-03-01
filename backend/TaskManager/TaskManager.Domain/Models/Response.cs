using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Models
{
    public class ResponsesModel<T>
    {
        public bool Success { get; set; }        
        public string Message { get; set; }   
        public T? Data { get; set; }            
        public List<string> Errors { get; set; } 
        public ResponsesModel(bool success, string message, T? data = default)
        {
            Success = success;
            Message = message;
            Data = data;
            Errors = new List<string>();
        }

        public ResponsesModel(bool success, string message, List<string> errors)
        {
            Success = success;
            Message = message;
            Errors = errors;
        }
    }
}
