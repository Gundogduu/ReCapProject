using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool success,string message) : base(success, message)
        {
            Data = data;
        }

        public DataResult(T data,bool success) : base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
//DataResult'a; sen bir generic'sin, türünü çağırdığımda vereceğim, sen bir Result'sın(onu inherit ediyorsun), 
//aynı zamanda IDataResult implementasyonusun T için, diyoruz
//buradaki base'ler Result'ı ifade ediyor
//iki constructor'ın da içine datayı set'etmemiz gerekiyor çünkü ilk constructor datayı,yani alttaki constructordaki yapıyı çağıramıyor.