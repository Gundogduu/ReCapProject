using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}

//Bu yapılar gerçek hayatta %90 projede anlaşılamadığı için kullanılamıyor.En ileri seviye yapıyı çok basit bir mantıkla gösteriyorum.
//Soyutlama kısmında geldiğimiz nokta gerçek hayatta üst seviyeler.
