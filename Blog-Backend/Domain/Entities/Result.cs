using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Result
    {
        public bool isSucces {  get; set; }
        public string Error { get; set; }=string.Empty;
        private Result(bool isSucces,string error)
        {
            this.isSucces = isSucces;
            Error = error;
        }
        public static Result Succes() => new Result(true, string.Empty);
        public static Result Failure(string Error) => new Result(false, Error);


    }
}
