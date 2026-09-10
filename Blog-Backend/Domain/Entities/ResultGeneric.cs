using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ResultGeneric<T>
    {
        public bool isSucces {  get; set; }
        public string Error { get; set; } = string.Empty;
        public T? value { get; }
        private ResultGeneric(bool isSucces, string error, T? value)
        {
            this.isSucces = isSucces;
            Error = error;
            this.value = value;
        }
        public static ResultGeneric<T> Succes(T value) => new ResultGeneric<T>(true, string.Empty, value);
        public static ResultGeneric<T> Failure(string error) => new ResultGeneric<T>(false, error, default);

    }
}
